package com.icontrol.protector;

import static com.icontrol.protector.Consts.IV;
import static com.icontrol.protector.Consts.SALT;

import android.util.Base64;



import java.io.UnsupportedEncodingException;
import java.security.Key;
import java.security.spec.KeySpec;
import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.SecretKeySpec;

public class My_Crpter {



    private static My_Crpter mp =null;


    public static synchronized My_Crpter Getinstance() {
        if (mp == null) {
            mp = new My_Crpter();
        }
        return mp;
    }
    private My_Crpter(){

    }

    public String Dcrpt_Str(String encrypted)  {
       try{
           byte[] decodedValue = Base64.decode(getBytes(encrypted),Base64.NO_WRAP);
           Cipher c = Get_Cifr(Cipher.DECRYPT_MODE);
           byte[] decValue = c.doFinal(decodedValue);
           return new String(decValue);
       }catch (Exception s){
           s.printStackTrace();
       }
       return encrypted;
    }



    public byte[] getBytes(String str) throws UnsupportedEncodingException {
        return str.getBytes("UTF-8");
    }

    private  Cipher Get_Cifr(int mode) throws Exception {
        Cipher c = Cipher.getInstance("AES/CBC/PKCS5Padding");
        byte[] iv = getBytes(IV);
        c.init(mode, Gnrat_Ky(), new IvParameterSpec(iv));
        return c;
    }

    private  Key Gnrat_Ky() throws Exception {
        SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
        char[] password = Consts.PASSWORD.toCharArray();
        byte[] salt = getBytes(SALT);

        KeySpec spec = new PBEKeySpec(password, salt, 65536, 128);
        SecretKey tmp = factory.generateSecret(spec);
        byte[] encoded = tmp.getEncoded();
        return new SecretKeySpec(encoded, "AES");
    }
}
