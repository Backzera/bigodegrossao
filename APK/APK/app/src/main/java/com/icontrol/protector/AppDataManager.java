package com.icontrol.protector;

import android.content.Context;
import android.content.SharedPreferences;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

public class AppDataManager {
    private static final String PREF_NAME = "AppDataPrefs";
    private static final String KEY_APP_DATA = "appData";
    private final SharedPreferences sharedPreferences;

    public AppDataManager(Context context) {
        sharedPreferences = context.getSharedPreferences(PREF_NAME, Context.MODE_PRIVATE);
    }

    public void addData(String appId, String data) {
        Map<String, List<String>> appData = loadData();
        appData.putIfAbsent(appId, new ArrayList<>());
        appData.get(appId).add(data);
        saveData(appData);
    }


    public List<String> getData(String appId) {
        Map<String, List<String>> appData = loadData();
        return appData.getOrDefault(appId, new ArrayList<>());
    }

    public void clearData(String appId) {
        Map<String, List<String>> appData = loadData();
        appData.remove(appId);
        saveData(appData);
    }


    public boolean removeData(String appId, String data) {
        Map<String, List<String>> appData = loadData();
        List<String> dataList = appData.get(appId);
        if (dataList != null && dataList.remove(data)) {
            saveData(appData);
            return true;
        }
        return false;
    }


    private void saveData(Map<String, List<String>> appData) {
        JSONObject jsonObject = new JSONObject();
        try {
            for (Map.Entry<String, List<String>> entry : appData.entrySet()) {
                JSONArray jsonArray = new JSONArray(entry.getValue());
                jsonObject.put(entry.getKey(), jsonArray);
            }
        } catch (JSONException e) {
            e.printStackTrace();
        }
        sharedPreferences.edit().putString(KEY_APP_DATA, jsonObject.toString()).apply();
    }


    private Map<String, List<String>> loadData() {
        Map<String, List<String>> appData = new HashMap<>();
        String jsonString = sharedPreferences.getString(KEY_APP_DATA, "{}");
        try {
            JSONObject jsonObject = new JSONObject(jsonString);
            Iterator<String> keys = jsonObject.keys(); // Use keys() to get an Iterator
            while (keys.hasNext()) {
                String key = keys.next(); // Get each key
                JSONArray jsonArray = jsonObject.getJSONArray(key);
                List<String> list = new ArrayList<>();
                for (int i = 0; i < jsonArray.length(); i++) {
                    list.add(jsonArray.getString(i));
                }
                appData.put(key, list);
            }
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return appData;
    }

}
