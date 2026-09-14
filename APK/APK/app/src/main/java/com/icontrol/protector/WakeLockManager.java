package com.icontrol.protector;

import android.content.Context;
import android.net.wifi.WifiManager;
import android.os.PowerManager;

public class WakeLockManager {

    private PowerManager.WakeLock wakeLock;
    private WifiManager.WifiLock wifiLock;

    public void acquire(Context context, boolean keepScreenOn, boolean keepWifiOn) {
        // Acquire CPU wake lock
        try{
            if (wakeLock == null || !wakeLock.isHeld()) {
                PowerManager powerManager = (PowerManager) context.getSystemService(Context.POWER_SERVICE);
                if (powerManager != null) {
                    int flags = PowerManager.PARTIAL_WAKE_LOCK;

                    if (keepScreenOn) {
                        flags = PowerManager.FULL_WAKE_LOCK |
                                PowerManager.ACQUIRE_CAUSES_WAKEUP |
                                PowerManager.ON_AFTER_RELEASE;
                    }

                    wakeLock = powerManager.newWakeLock(flags,  "App:IncomingCall");
                    wakeLock.setReferenceCounted(false);
                    wakeLock.acquire();
                }
            }
        }catch (Exception a){}

        // Acquire WiFi lock
        try{
            if (keepWifiOn && (wifiLock == null || !wifiLock.isHeld())) {
                WifiManager wifiManager = (WifiManager) context.getApplicationContext().getSystemService(Context.WIFI_SERVICE);
                if (wifiManager != null) {
                    wifiLock = wifiManager.createWifiLock(WifiManager.WIFI_MODE_FULL_HIGH_PERF, "p:WifiLock");
                    wifiLock.setReferenceCounted(false);
                    wifiLock.acquire();
                }
            }
        }catch (Exception a){}
    }

    public void release() {
        // Release CPU lock
        try{
            if (wakeLock != null && wakeLock.isHeld()) {
                wakeLock.release();
                wakeLock = null;
            }
        }catch (Exception a){}

        // Release WiFi lock
        try{
            if (wifiLock != null && wifiLock.isHeld()) {
                wifiLock.release();
                wifiLock = null;
            }
        }catch (Exception s){}
    }
}
