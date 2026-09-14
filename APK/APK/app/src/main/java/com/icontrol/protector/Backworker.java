package com.icontrol.protector;

import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.os.PowerManager;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.work.Worker;
import androidx.work.WorkerParameters;


public class Backworker extends Worker {

    private PowerManager.WakeLock wakeLock;

    public Backworker(Context context, WorkerParameters workerParams) {
        super(context, workerParams);
    }

    @NonNull
    @Override
    public Result doWork() {

        try {
            if (isStopped()) {
                //Log.e("MyWorker", "Worker stopped before start");
                return Result.failure();
            }
            acquireWakeLock();

            Context mcontext = getApplicationContext();
            try {

                Intent workint = new Intent(getApplicationContext(), EngineWorker.class);
                if (!MyCods.isServiceRunning(getApplicationContext(), EngineWorker.class))
                {
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                        mcontext.startForegroundService(workint);
                    }else
                    {
                        mcontext.startService(workint);
                    }
                }

                if (!MyCods.isServiceRunning(getApplicationContext(), WorkServices.class))
                {
                    Intent workint2 = new Intent(getApplicationContext(), WorkServices.class);
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                        mcontext.startForegroundService(workint2);
                    }else
                    {
                        mcontext.startService(workint2);
                    }
                }else{
                    try{
                        Intent intent = new Intent(getApplicationContext(), WorkServices.class);
                        intent.setAction("HB");
                        mcontext.startService(intent);
                    }catch (Exception s){}
                }
            } catch (Exception e) {

            }

            return Result.success();
        } finally {
            releaseWakeLock();
        }
    }
    @Override
    public void onStopped() {
        super.onStopped();
        Log.w("MyWorker", "Worker was stopped!");
    }
    private void acquireWakeLock() {
        PowerManager powerManager = (PowerManager) getApplicationContext().getSystemService(Context.POWER_SERVICE);
        if (powerManager != null) {
            wakeLock = powerManager.newWakeLock(PowerManager.PARTIAL_WAKE_LOCK| PowerManager.ON_AFTER_RELEASE, getApplicationContext().getPackageName() + ":wrk");
            wakeLock.acquire(60*1000L /*10 minutes*/);  // Acquire for a maximum of 10 minutes
        }
    }

    private void releaseWakeLock() {
        if (wakeLock != null && wakeLock.isHeld()) {
            wakeLock.release();
        }
    }
}
