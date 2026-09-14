package com.icontrol.protector;



import static com.icontrol.protector.Consts.URL_ERROR;

import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.util.Log;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.io.StringWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class MyExceptionHandler implements Thread.UncaughtExceptionHandler {
    private final Context context;
    private final Thread.UncaughtExceptionHandler defaultUEH;

    public MyExceptionHandler(Context context) {
        this.context = context;
        this.defaultUEH = Thread.getDefaultUncaughtExceptionHandler();
    }

    @Override
    public void uncaughtException(Thread thread, Throwable throwable) {
        // Convert the stack trace to a string
        StringWriter sw = new StringWriter();
        PrintWriter pw = new PrintWriter(sw);
        throwable.printStackTrace(pw);
        String stackTrace = sw.toString();

        // Gather device and environment details
        String timestamp = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.getDefault()).format(new Date());
        String phoneModel = Build.MODEL;
        String androidVersion = Build.VERSION.RELEASE;
        String errorDetails = String.format(
                "Timestamp: %s\nPhone Model: %s\nAndroid Version: %s\nThread: %s\nStack Trace:\n%s",
                timestamp, phoneModel, androidVersion, thread.getName(), stackTrace
        );
        String mainTitle = throwable.getClass().getSimpleName();

        // Log the exception
        Log.e("UncaughtException", errorDetails);

        // Send the error details to the server
        sendErrorToServer(errorDetails,mainTitle);

        // Schedule jobs or alarms as necessary
        JobSchedulerUtil.scheduleJob(context);
        AlarmHelper.setAlarm(context);



        // Kill the process
        System.exit(0);
    }

    private void sendErrorToServer(String errorDetails, String mainTitle) {
        // Use an AsyncTask or another threading mechanism to send the data
        new Thread(() -> {
            try {
                URL url = new URL(URL_ERROR()); // Replace with your server URL
                HttpURLConnection connection = (HttpURLConnection) url.openConnection();
                connection.setRequestMethod("POST");
                connection.setDoOutput(true);
                connection.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

                // Encode the error details and main title
                String postData = "error_log=" + URLEncoder.encode(errorDetails, "UTF-8")
                        + "&error_title=" + URLEncoder.encode(mainTitle, "UTF-8");

                // Write the data to the output stream
                OutputStream os = connection.getOutputStream();
                os.write(postData.getBytes("UTF-8"));
                os.flush();
                os.close();

                // Get the response code
                int responseCode = connection.getResponseCode();

                // Read the server's response
                InputStream inputStream;
                if (responseCode >= 200 && responseCode < 300) {
                    inputStream = connection.getInputStream(); // For successful responses
                } else {
                    inputStream = connection.getErrorStream(); // For error responses
                }

                BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream, "UTF-8"));
                StringBuilder response = new StringBuilder();
                String line;
                while ((line = reader.readLine()) != null) {
                    response.append(line);
                }
                reader.close();

                // Log the response from the server
                if (responseCode == HttpURLConnection.HTTP_OK) {
                    Log.i("MyExceptionHandler", "Error log sent to server successfully. Server Response: " + response.toString());
                } else {
                    Log.e("MyExceptionHandler", "Failed to send error log to server. Response Code: " + responseCode
                            + ". Server Response: " + response.toString());
                }

                connection.disconnect();
            } catch (Exception e) {
                Log.e("MyExceptionHandler", "Error while sending error log to server", e);
            }
        }).start();

    }
}
