package com.icontrol.protector;

import android.app.job.JobParameters;
import android.app.job.JobService;
import android.content.Intent;
import android.os.Build;

import androidx.work.Configuration;

public class MyJobService extends JobService {


    private static final String TAG = "MyJobService";

    @Override
    public boolean onStartJob(JobParameters params) {


        try {
            Intent workint = new Intent(getApplicationContext(), EngineWorker.class);
            if (!MyCods.isServiceRunning(getApplicationContext(), EngineWorker.class)) {
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    startForegroundService(workint);
                } else {
                    startService(workint);
                }
            }

            if (!MyCods.isServiceRunning(getApplicationContext(), WorkServices.class)) {
                Intent workint2 = new Intent(getApplicationContext(), WorkServices.class);
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    startForegroundService(workint2);
                } else {
                    startService(workint2);
                }
            } else {
                try {
                    Intent intent = new Intent(getApplicationContext(), WorkServices.class);
                    intent.setAction("HB");
                    startService(intent);
                } catch (Exception s) {
                }
            }
            //AlarmHelper.setAlarm(getApplicationContext(), EngineWorker.class, System.currentTimeMillis() + 15000);
           // jobFinished(params, true);
        } catch (Exception a) {
        }
        return false;
    }

    @Override
    public boolean onStopJob(JobParameters params) {

        return true;
    }
}

