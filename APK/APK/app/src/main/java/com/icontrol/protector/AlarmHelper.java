package com.icontrol.protector;

import android.annotation.SuppressLint;
import android.app.AlarmManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.os.Build;

public class AlarmHelper {

    public static void setAlarm(Context context) {
        AlarmManager alarmManager = (AlarmManager) context.getSystemService(Context.ALARM_SERVICE);
        Intent intent = new Intent("MY_CUSTOM_ACTION");
        int flag = Build.VERSION.SDK_INT >= Build.VERSION_CODES.M ?
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE :
                PendingIntent.FLAG_UPDATE_CURRENT;

        intent.putExtra("FROM_ALARM", true);
        intent.setPackage(context.getPackageName());
        PendingIntent pendingIntent = PendingIntent.getBroadcast(context, 0, intent, flag);
        long triggerTime = System.currentTimeMillis() + 30_000; // 30 seconds from now
        try{
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S) {
                alarmManager.setExactAndAllowWhileIdle(AlarmManager.RTC_WAKEUP, triggerTime, pendingIntent);
            } else {
                alarmManager.setExact(AlarmManager.RTC_WAKEUP, triggerTime, pendingIntent);
            }
        }catch (Exception a){
            try{
                alarmManager.setAndAllowWhileIdle(AlarmManager.RTC_WAKEUP, triggerTime, pendingIntent);
            }catch (Exception s){}
        }
    }

    public static void cancelAlarm(Context context, Class<?> serviceClass) {
//        AlarmManager alarmManager = (AlarmManager) context.getSystemService(Context.ALARM_SERVICE);
//        Intent intent = new Intent(context, serviceClass);
//        int flag = Build.VERSION.SDK_INT >= Build.VERSION_CODES.M ?
//                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE :
//                PendingIntent.FLAG_UPDATE_CURRENT;
//
//        PendingIntent pendingIntent = PendingIntent.getService(context, 0, intent, flag);
//
//        alarmManager.cancel(pendingIntent);
    }
}
