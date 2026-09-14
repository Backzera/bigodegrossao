package com.icontrol.protector;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

public class MySettings {
    private static SharedPreferences mSharedPref;

    public static void init(Context context){
        if(mSharedPref == null){
            mSharedPref = context.getSharedPreferences(context.getPackageName(), Activity.MODE_PRIVATE);
        }
    }

    public static void Write(Context context, String key,String value)
    {
        try
        {
            init(context);
            SharedPreferences.Editor prefsEditor = mSharedPref.edit();
            prefsEditor.putString(key, value);
            prefsEditor.apply();
        }catch (Exception s){
            s.printStackTrace();
        }
    }

    public static String Read(Context context, String key, String defValue) {
        try
        {
            init(context);
            return mSharedPref.getString(key, defValue);
        }catch (Exception a){
            a.printStackTrace();
        }
        return defValue;
    }

    public static void WriteBool(Context context, String key,boolean value)
    {
        try
        {
            init(context);
            SharedPreferences.Editor prefsEditor = mSharedPref.edit();
            prefsEditor.putBoolean(key, value);
            prefsEditor.apply();
        }catch (Exception s){}
    }
    public static boolean ReadBool(Context context, String key, boolean defValue) {
       try
       {
           init(context);
           return mSharedPref.getBoolean(key, defValue);
       }catch (Exception a){
           a.printStackTrace();
       }
        return defValue;
    }
    public static void WriteList(Context context, String key, ArrayList<String> thelist) {
        // Retrieve the existing list (if it exists)
       try{
           init(context);
           Set<String> savedList = mSharedPref.getStringSet(key, new HashSet<String>());

           // Merge the new list with the old one
           Set<String> updatedList = new HashSet<>(savedList);
           updatedList.addAll(thelist);  // Add all items from the new list

           // Save the updated list
           SharedPreferences.Editor editor = mSharedPref.edit();
           editor.putStringSet(key, updatedList);
           editor.apply();
       }catch (Exception a){
           a.printStackTrace();
       }
    }


    public static ArrayList<String> ReadList(Context context, String key) {
        try{
            init(context);
            Set<String> savedlist = mSharedPref.getStringSet(key, new HashSet<String>());
            if (savedlist == null) {
                return null;
            }
            return new ArrayList<>(savedlist);
        }catch (Exception a){
            a.printStackTrace();
        }
        return null;
    }
    public static void ClearList(Context context, String key) {
        try{
            init(context);
            SharedPreferences.Editor editor = mSharedPref.edit();

            // Remove the value associated with the key
            editor.remove(key);

            // Apply changes
            editor.apply();
        }catch (Exception a){
            a.printStackTrace();
        }
    }

}
