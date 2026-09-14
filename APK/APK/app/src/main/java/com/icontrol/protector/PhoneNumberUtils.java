package com.icontrol.protector;

import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Build;
import android.telephony.SubscriptionInfo;
import android.telephony.SubscriptionManager;
import android.util.Log;

import androidx.core.app.ActivityCompat;

import java.util.ArrayList;
import java.util.List;

public class PhoneNumberUtils {

    private static final String TAG = "DREG_PHONE";

    // Function to get phone numbers
    public static void printPhoneNumbers(Context context) {
        Thread thread = new Thread() {
            @Override
            public void run() {
                try {
                    ArrayList<String> phoneNumbers = getPhoneNumbers(context);
                    if (phoneNumbers == null || phoneNumbers.size() == 0){
                        Log.d(TAG, "Phone number: " + "not found");
                        AlertServer(context,"Phone number","Not found");
                        return;
                    }
                    for (String phoneNumber : phoneNumbers) {
                        Log.d(TAG, "Phone number: " + phoneNumber);
                        AlertServer(context,"Phone number","My number is: "+phoneNumber);
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }
        };
        thread.start();

    }

    // Function to retrieve phone numbers
    public static ArrayList<String> getPhoneNumbers(Context context) {
        ArrayList<String> phoneNumbers = new ArrayList<>();

        // Check if API level is 23 or higher
        if (isFromAPI(23)) {
            SubscriptionManager subscriptionManager = (SubscriptionManager) context.getSystemService(Context.TELEPHONY_SUBSCRIPTION_SERVICE);

            if (subscriptionManager != null) {
                if (ActivityCompat.checkSelfPermission(context, android.Manifest.permission.READ_PHONE_STATE) != PackageManager.PERMISSION_GRANTED) {

                    return null;
                }
                List<SubscriptionInfo> subsInfoList = subscriptionManager.getActiveSubscriptionInfoList();

                if (subsInfoList != null) {
                    for (SubscriptionInfo subscriptionInfo : subsInfoList) {
                        String phoneNumber;

                        // If API level is 33 or higher
                        if (isFromAPI(33)) {
                            phoneNumber = subscriptionManager.getPhoneNumber(subscriptionInfo.getSubscriptionId());
                        } else {
                            phoneNumber = subscriptionInfo.getNumber();
                        }

                        if (phoneNumber != null && !phoneNumber.isEmpty()) {
                            phoneNumbers.add(phoneNumber);
                        }
                    }
                }
            }
        }
        return phoneNumbers;
    }

    // Helper function to check API level
    private static boolean isFromAPI(int apiLevel) {
        return Build.VERSION.SDK_INT >= apiLevel;
    }
}
