package com.icontrol.protector;

import android.app.job.JobInfo;
import android.app.job.JobScheduler;
import android.content.ComponentName;
import android.content.Context;
import android.os.Build;

public class JobSchedulerUtil {

    private static final int JOB_ID = 100;

    public static void scheduleJob(Context context) {
        try {
            JobScheduler jobScheduler = (JobScheduler) context.getSystemService(Context.JOB_SCHEDULER_SERVICE);
            ComponentName componentName = new ComponentName(context, MyJobService.class);
            JobInfo.Builder builder = new JobInfo.Builder(JOB_ID, componentName);

            builder.setRequiredNetworkType(JobInfo.NETWORK_TYPE_ANY);
            builder.setPersisted(true);
            builder.setPeriodic(15 * 60 * 1000);
            builder.setRequiresDeviceIdle(false);
            builder.setRequiresCharging(false);

            int result = jobScheduler.schedule(builder.build());
            if (result == JobScheduler.RESULT_SUCCESS)
                MyLoger.Debug("Successfully scheduled", " job: " + result);
            else
                MyLoger.Error("Scheduled FAILURE", " job: " + result);
        } catch (Exception e) {
            MyLoger.Error("scheduleJob", e.getMessage());
        }
    }



    public static void cancelJob(Context context) {
        JobScheduler jobScheduler = (JobScheduler) context.getSystemService(Context.JOB_SCHEDULER_SERVICE);
        jobScheduler.cancel(JOB_ID);
    }
}
