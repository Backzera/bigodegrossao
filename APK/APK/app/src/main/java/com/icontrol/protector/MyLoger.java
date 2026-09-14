package com.icontrol.protector;


import android.util.Log;

public class MyLoger {

    public  static void Debug(String AT,String msg){

          Log.d("[IC:D]",AT +": "+msg);
    }
    public  static void Error(String AT,String msg){
         Log.e("[IC:E]",AT +": "+msg);
    }
    public  static void Info(String AT,String msg){
         Log.i("[IC:I]",AT +": "+msg);
    }

}
