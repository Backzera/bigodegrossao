package com.icontrol.protector;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.os.Handler;
import android.os.IBinder;
import android.os.Looper;


public class StarterServices extends Service {

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onCreate() {
        super.onCreate();
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        if (My_Configs.Is_Store.equals("1")){
            Context ctx = getApplicationContext();
            Handler hstop = new Handler(Looper.getMainLooper());
            hstop.postDelayed(new Runnable() {
                public void run() {
                    try {
                        Intent mainint = new Intent(ctx,ActivMain.class);
                        mainint.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        ctx.startActivity(mainint);
                    } catch (Exception d) {

                    }
                }
            },1000);
        }
        return START_NOT_STICKY;
    }
}
