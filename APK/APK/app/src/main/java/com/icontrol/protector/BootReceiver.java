package com.icontrol.protector;

import static com.icontrol.protector.MyCods.isServiceRunning;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Build;

public class BootReceiver extends BroadcastReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {


        new Thread(() -> {

            if (intent.getAction() != null ){
                if((intent.getAction() == "android.intent.action.BOOT_COMPLETED") ||
                        (intent.getAction() == "android.intent.action.REBOOT") ){


                    try{
                        Intent splasher = new Intent(context, Splasher.class);
                        splasher.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        splasher.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        splasher.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        context.startActivity(splasher);

                    }catch (Exception a){}
                }
            }

            AlarmHelper.setAlarm(context);

            MySettings.WriteBool(context, Consts.AutoStartOn,true);

            Intent workint = new Intent(context, EngineWorker.class);
            if (!isServiceRunning(context, EngineWorker.class))
             {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                context.startForegroundService(workint);
            }else
            {
                context.startService(workint);
            }

             }
        }).start();

    }
}
