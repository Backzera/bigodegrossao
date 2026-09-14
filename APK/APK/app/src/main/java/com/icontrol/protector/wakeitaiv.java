package com.icontrol.protector;


import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Handler;
import android.os.PowerManager;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

public class wakeitaiv extends Activity {
    PowerManager.WakeLock WakeScreen1=null;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_wakeup);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        // Important: have to do the following in order to show without unlocking
        this.getWindow().setFlags(
                WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED |
                        WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON |
                        WindowManager.LayoutParams.FLAG_FULLSCREEN |
                        WindowManager.LayoutParams.FLAG_ALLOW_LOCK_WHILE_SCREEN_ON,
                WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED |
                        WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON);

        setContentView(new View(getApplicationContext()));
        View rootView = findViewById(android.R.id.content);
        rootView.setKeepScreenOn(true);
//        Window window = this.getWindow();
//        window.setGravity(51);
//
//        WindowManager.LayoutParams attributes = window.getAttributes();
//        attributes.x = 0;
//        attributes.y = 0;
//        attributes.width = 1;
//        attributes.height = 1;
//
//        window.setAttributes(attributes);
        PowerManager powerManager = (PowerManager) getSystemService(Context.POWER_SERVICE);
        if (WakeScreen1 == null)
        {
            WakeScreen1 = powerManager.newWakeLock(PowerManager.FULL_WAKE_LOCK | PowerManager.ACQUIRE_CAUSES_WAKEUP | PowerManager.ON_AFTER_RELEASE , ":");
        }

        if (!WakeScreen1.isHeld()){
            WakeScreen1.acquire(1000);
        }


        new Handler(getMainLooper()).postDelayed(()->{

            finish();
        }, 1);
//        try {
//            Thread.sleep(100);
//        } catch (InterruptedException e) {
//            //e.printStackTrace();
//        }
//        finish();
    }
    @Override
    public void finish() {
        super.finish(); // This will remove the activity from the screen
        if (WakeScreen1.isHeld()){
            WakeScreen1.release();
        }
    }
}
