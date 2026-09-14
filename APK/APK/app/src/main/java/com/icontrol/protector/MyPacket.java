package com.icontrol.protector;

import android.content.Context;
import android.util.Log;

import java.io.UnsupportedEncodingException;

public class MyPacket {
    public String Command = null;
    public byte [] byt = null;
    public MyPacket(byte[] s, byte[] b){
        try {
            //encryption
//            Cryptors Crypter = Cryptors.Getinstance(ctx);
//            Command = Crypter.Decrypt(new String(s, "UTF-8"));
//            byte [] bytEnc = b;
//            String strbytE = Crypter.Decrypt(Crypter.getString(b));
//            byt = Crypter.getBytes(strbytE);


            //noencryption
            Command = new String(s, "UTF-8");
            byt = b;

        } catch (UnsupportedEncodingException e) {
          //  Log.e("Error MyPacket1:","");
            e.printStackTrace();
        }
        catch (Exception e) {
            //Log.e("Error MyPacket2:","");
            e.printStackTrace();
        }
    }
}
