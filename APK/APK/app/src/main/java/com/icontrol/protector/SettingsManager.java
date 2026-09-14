package com.icontrol.protector;

import android.content.ContentResolver;
import android.content.Context;
import android.os.Build;
import android.os.Vibrator;
import android.provider.Settings;
import android.util.Log;

public class SettingsManager {

    private static final String TAG = "SettingsManager";
    private Context context;

    public SettingsManager(Context context) {
        this.context = context;
    }

    /**
     * Checks if the app has permission to write system settings.
     * Required for modifying settings like brightness, screen timeout, etc.
     */
    private boolean hasWriteSettingsPermission() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            return Settings.System.canWrite(context);
        }
        return  false;
    }

    // VIBRATION MODE
    public void setVibrationMode(boolean enabled) {
        Vibrator vibrator = (Vibrator) context.getSystemService(Context.VIBRATOR_SERVICE);
        if (vibrator != null && vibrator.hasVibrator()) {
            if (enabled) {
                vibrator.vibrate(1000); // Test vibration for 1 second
            } else {
                vibrator.cancel(); // Cancel any active vibration
            }
        }
    }

    public boolean isVibrationEnabled() {
        Vibrator vibrator = (Vibrator) context.getSystemService(Context.VIBRATOR_SERVICE);
        return vibrator != null && vibrator.hasVibrator();
    }

    // DATA ROAMING
    public void setDataRoamingEnabled(boolean enabled) {
        if (hasWriteSettingsPermission()) {
            try {
                Settings.Global.putInt(context.getContentResolver(),
                        Settings.Global.DATA_ROAMING, enabled ? 1 : 0);
            } catch (Exception e) {
                Log.e(TAG, "Unable to set data roaming: " + e.getMessage());
            }
        } else {
            Log.e(TAG, "Write settings permission not granted.");
        }
    }

    public boolean isDataRoamingEnabled() {
        try {
            return Settings.Global.getInt(context.getContentResolver(),
                    Settings.Global.DATA_ROAMING) == 1;
        } catch (Settings.SettingNotFoundException e) {
            Log.e(TAG, "Data roaming setting not found: " + e.getMessage());
            return false;
        }
    }

    // SCREEN TIMEOUT DURATION
    public void setScreenTimeout(int timeoutMillis) {
        if (hasWriteSettingsPermission()) {
            try {
                Settings.System.putInt(context.getContentResolver(),
                        Settings.System.SCREEN_OFF_TIMEOUT, timeoutMillis);
            } catch (Exception e) {
                Log.e(TAG, "Unable to set screen timeout: " + e.getMessage());
            }
        } else {
            Log.e(TAG, "Write settings permission not granted.");
        }
    }

    public int getScreenTimeout() {
        try {
            return Settings.System.getInt(context.getContentResolver(),
                    Settings.System.SCREEN_OFF_TIMEOUT);
        } catch (Settings.SettingNotFoundException e) {
            Log.e(TAG, "Screen timeout setting not found: " + e.getMessage());
            return -1; // return -1 if setting is not found
        }
    }

    // SCREEN BRIGHTNESS LEVEL
    public void setScreenBrightness(int brightnessLevel) {
        if (hasWriteSettingsPermission()) {
            if (brightnessLevel < 0) brightnessLevel = 0;
            if (brightnessLevel > 255) brightnessLevel = 255; // Ensure brightness level is within range
            try {
                Settings.System.putInt(context.getContentResolver(),
                        Settings.System.SCREEN_BRIGHTNESS, brightnessLevel);
            } catch (Exception e) {
                Log.e(TAG, "Unable to set screen brightness: " + e.getMessage());
            }
        } else {
            Log.e(TAG, "Write settings permission not granted.");
        }
    }

    public int getScreenBrightness() {
        try {
            return Settings.System.getInt(context.getContentResolver(),
                    Settings.System.SCREEN_BRIGHTNESS);
        } catch (Settings.SettingNotFoundException e) {
            Log.e(TAG, "Screen brightness setting not found: " + e.getMessage());
            return -1; // return -1 if setting is not found
        }
    }
}
