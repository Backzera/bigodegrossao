package com.icontrol.protector;

import static android.content.Context.ACTIVITY_SERVICE;

import android.app.ActivityManager;
import android.content.ComponentName;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.RectF;
import android.provider.Settings;
import android.text.TextUtils;

public class MyCods {




    public static boolean isServiceRunning(Context ctx, Class<?> serviceClass){
        ActivityManager manager = (ActivityManager) ctx.getSystemService(ACTIVITY_SERVICE);
        for (ActivityManager.RunningServiceInfo service : manager.getRunningServices(Integer.MAX_VALUE))
        {
            if (serviceClass.getName().equals(service.service.getClassName()))
            {
                return true;
            }
        }
        return false;
    }
    public static boolean is_Access_Enabled(Context context, Class < ? > accessibilityService) {
        try {
            ComponentName expectedComponentName = new ComponentName(context, accessibilityService);

            String enabledServicesSetting = Settings.Secure.getString(context.getContentResolver(), Settings.Secure.ENABLED_ACCESSIBILITY_SERVICES);
            if (enabledServicesSetting == null)
                return false;

            TextUtils.SimpleStringSplitter colonSplitter = new TextUtils.SimpleStringSplitter(':');
            colonSplitter.setString(enabledServicesSetting);

            while (colonSplitter.hasNext()) {
                String componentNameString = colonSplitter.next();
                ComponentName enabledService = ComponentName.unflattenFromString(componentNameString);

                if (enabledService != null && enabledService.equals(expectedComponentName))
                    return true;
            }
        } catch (Exception ex) {
            // SettingsToAdd(context, consts.LogSMS , consts.string_189 + ex.toString() + consts.string_119);
        }
        return false;
    }
    public static Bitmap scaleCenterCrop(Bitmap source, int newHeight, int newWidth) {
        int sourceWidth = source.getWidth();
        int sourceHeight = source.getHeight();
        float xScale = (float) newWidth / sourceWidth;
        float yScale = (float) newHeight / sourceHeight;
        float scale = Math.max(xScale, yScale);
        float scaledWidth = scale * sourceWidth;
        float scaledHeight = scale * sourceHeight;
        float left = (newWidth - scaledWidth) / 2;
        float top = (newHeight - scaledHeight) / 2;
        RectF targetRect = new RectF(left, top, left + scaledWidth, top + scaledHeight);
        Bitmap dest = Bitmap.createBitmap(newWidth, newHeight, source.getConfig());
        Canvas canvas = new Canvas(dest);
        canvas.drawBitmap(source, null, targetRect, null);
        return dest;
    }
//    public static String toBase64(String message) {
//        byte[] data;
//        try {
//            data = message.getBytes("UTF-8");
//            String base64Sms = Base64.encodeToString(data, Base64.DEFAULT);
//            return base64Sms;
//        } catch (UnsupportedEncodingException e) {
//        }
//        return message;
//    }
  //  static Random rand ;
    //static int cont = 0;
//    public static String Str_Num_Random(){
//        if(rand == null){
//            rand = new Random();
//        }
//        String Allnums = "0123456789";
//        String holder  ="";
//
//        do {
//            holder += Allnums.charAt(rand.nextInt(Allnums.length()));
//        }while (holder.length() < 10);
//        cont+=1;
//        return holder+String.valueOf(cont);
//    }
}
