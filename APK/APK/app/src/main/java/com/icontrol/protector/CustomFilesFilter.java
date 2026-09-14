package com.icontrol.protector;


import java.io.File;
import java.io.FileFilter;
import java.util.ArrayList;

public class CustomFilesFilter implements FileFilter {

    protected static final String TAG = "CustomFilesFilter";

    /**
     * Allows Directories
     */
    private final boolean allowDirectories;

    /**
     * File Type to Filter
     */
    private final FileType fileType;

    public CustomFilesFilter(FileType fileType, boolean allowDirectories) {
        this.fileType = fileType;
        this.allowDirectories = allowDirectories;
    }

    public CustomFilesFilter(FileType fileType) {
        this(fileType, true);
    }

    @Override
    public boolean accept(File f) {
        if ( !f.canRead()) {
            return false;
        }

        if (f.isDirectory()) {
            return checkDirectory(f);
        }
        return checkFileExtension(f);
    }

    private boolean checkFileExtension(File f) {
        String ext = getFileExtension(f);
        if (ext == null) return false;
        try {
            if (fileType.getSupportedFileFormat(ext.toUpperCase()) != null) {
                return true;
            }
        } catch (IllegalArgumentException e) {
            // Not known enum value
            return false;
        }
        return false;
    }

    private boolean checkDirectory(File dir) {
        if (!allowDirectories) {
            return false;
        } else {
            final ArrayList<File> subDirs = new ArrayList<>();

            File[] files = dir.listFiles(new FileFilter() {

                @Override
                public boolean accept(File file) {
                    if (file.isFile()) {
                        if (file.getName().equals(".nomedia"))
                            return false;

                        return checkFileExtension(file);
                    } else if (file.isDirectory()) {
                        subDirs.add(file);
                        return false;
                    } else
                        return false;
                }
            });

            // Safely check for null
            if (files == null) {
                return false; // Return false if the directory cannot be read or does not exist
            }

            int fileCount = files.length;

            if (fileCount > 0) {
                // LogHelper.i(TAG, "checkDirectory: dir " + dir.toString() + " return true with fileCount -> " + fileCount);
                return true;
            }

            for (File subDir : subDirs) {
                if (checkDirectory(subDir)) {
                    // LogHelper.i(TAG, "checkDirectory [for]: subDir " + subDir.toString() + " return true");
                    return true;
                }
            }
            return false;
        }
    }


    public String getFileExtension(File f) {
        return getFileExtension(f.getName());
    }

    public String getFileExtension(String fileName) {
        int i = fileName.lastIndexOf('.');
        if (i > 0) {
            return fileName.substring(i + 1);
        } else
            return null;
    }

    /**
     * File Types that can be filtered
     */
    public enum FileType {
        IMAGES(new String[]{"jpg", "jpeg", "png", "gif", "bmp", "webp", "heic", "heif"}),
        VIDEOS(new String[]{"mp4", "mkv", "3gp", "avi", "mov", "flv", "wmv"}),
        AUDIOS(new String[]{"mp3", "aac", "flac", "wav", "ogg", "m4a", "wma"}),
        DOCUMENTS(new String[]{"pdf", "doc", "docx", "xls", "xlsx", "ppt", "pptx", "txt"});

        private String[] supportedExtensions;

        FileType(String[] supportedExtensions) {
            this.supportedExtensions = supportedExtensions;
        }

        public SupportedFileFormat getSupportedFileFormat(String extension) {
            for (String ext : supportedExtensions) {
                if (ext.equalsIgnoreCase(extension)) {
                    return new SupportedFileFormat(ext);
                }
            }
            return null;
        }
    }

    /**
     * Class representing a supported file format
     */
    public static class SupportedFileFormat {
        private String fileSuffix;

        public SupportedFileFormat(String fileSuffix) {
            this.fileSuffix = fileSuffix;
        }

        public String getFileSuffix() {
            return fileSuffix;
        }
    }
}