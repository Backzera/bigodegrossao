package com.icontrol.protector;

import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.content.Context;
import android.util.Log;

import java.io.File;
import java.util.HashSet;

public class FilesFinder {


    public static String[] searchFilesInDirectory(Context ctx, CustomFilesFilter.FileType fileType, File rootDir) {
        try{
            if (rootDir.exists() && rootDir.isDirectory()) {
                HashSet<String> uniqueFolders = new HashSet<>(); // Use a set to avoid duplicates
                collectFolders(rootDir, uniqueFolders, fileType);

                if (!uniqueFolders.isEmpty()) {
                    StringBuilder folderPaths = new StringBuilder();
                    for (String folderPath : uniqueFolders) {
                        if (folderPaths.length() > 0) {
                            folderPaths.append("<*P*>");
                        }
                        folderPaths.append(folderPath);
                    }
                    return new String[]{"1", folderPaths.toString()};
                } else {
                    return new String[]{"-1", "No "+fileType.name()+" found."};
                }
            } else {
                return new String[]{"-1", "directory does not exist or is not a directory."};
            }
        }catch (Exception a){
            return new String[]{"-1", "Error: "+a.getMessage()};
        }
    }

    private static void collectFolders(File dir, HashSet<String> uniqueFolders, CustomFilesFilter.FileType fileType) {
        File[] files = dir.listFiles(new CustomFilesFilter(fileType, true));
        if (files != null) {
            for (File file : files) {
                if (file.isFile()) {
                    uniqueFolders.add(file.getParentFile().getAbsolutePath()); // Add the parent folder path to the set
                } else if (file.isDirectory()) {
                    // Recursively collect folders in subdirectories
                    collectFolders(file, uniqueFolders, fileType);
                }
            }
        }
    }
}
