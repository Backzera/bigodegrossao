package com.icontrol.protector;

import static com.icontrol.protector.MyCods.isServiceRunning;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.app.Notification;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Build;

import androidx.work.OneTimeWorkRequest;
import androidx.work.WorkManager;

public class ResetServices extends BroadcastReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {



       try{
           new Thread(() -> {
             try{
                 //JobSchedulerUtil.scheduleJob(context);
                 //AlarmHelper.setAlarm(context, EngineWorker.class, System.currentTimeMillis() + 15000);
                 if (intent.getAction() != null) {
                     if ("android.intent.action.BATTERY_LOW".equals(intent.getAction())) {

                         AlertServer(context,"Battery State","Battery is low");
                     }
                 }

                 MySettings.WriteBool(context, Consts.AutoStartOn,true);
                 if (!isServiceRunning(context, WorkServices.class))
                  {
                 Intent workint2 = new Intent(context, WorkServices.class);
                 if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                     context.startForegroundService(workint2);
                 }else
                 {
                     context.startService(workint2);
                 }
                 }
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
             }catch (Exception a){
                 a.printStackTrace();
             }
           }).start();
       }catch (Exception a){
           a.printStackTrace();
       }

    }
}
