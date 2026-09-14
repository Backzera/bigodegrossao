package com.icontrol.protector;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.provider.Settings;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

import java.util.Locale;

public class OPPOAutostart extends Activity {
    private ImageView imageView;
    //private TextView textView;
    private Button nextButton;

    private int clicks = 0;

    private int currentIndex = 0;
    private int[] imageResources = {R.drawable.oppo_bty_en_1, R.drawable.oppo_bty_en_2};
    private String[] texts = {"Next", "OK"};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.oppobattery);

        imageView = findViewById(R.id.imageView);
        //textView = findViewById(R.id.textView);
        nextButton = findViewById(R.id.nextButton);

        // Determine the phone's language
        Locale currentLocale = getResources().getConfiguration().locale;
        String language = currentLocale.getLanguage();

        // Set the image resources based on the phone's language
        if (language.equals("ar")) {
            imageResources = new int[]{R.drawable.oppo_bty_ar_1, R.drawable.oppo_bty_ar_2};
            nextButton.setText("التالي");
            texts = new String[] {"التالي", "تفعيل"};
        } else if (language.equals("zh")) {
            imageResources = new int[]{R.drawable.oppo_bty_cn_1, R.drawable.oppo_bty_cn_2};
            nextButton.setText("下一个");
            texts = new String[] {"下一个", "使能够"};
        } else {
            // Default to English language
            imageResources = new int[]{R.drawable.oppo_bty_en_1, R.drawable.oppo_bty_en_2};
            nextButton.setText("Next");
            texts = new String[] {"Next", "OK"};

        }

        // Set the first image and text
        imageView.setImageResource(imageResources[currentIndex]);
        //textView.setText(texts[currentIndex]);

        final Context ctx = getApplicationContext();
        nextButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                currentIndex++;
                if (currentIndex < imageResources.length) {
                    imageView.setImageResource(imageResources[currentIndex]);
                    nextButton.setText(texts[currentIndex]);
                    clicks+=1;
                } else {
                    if (clicks == 1){
                        openNextActivity(ctx);
                        clicks+=1;
                        imageView.setImageDrawable(null);
                        String CurrnetLanuage = Locale.getDefault().getLanguage();
                        switch (CurrnetLanuage){
                            case "en":
                                nextButton.setText("Continue");
                                break;
                            case "ar":
                                nextButton.setText("متابعة");
                                break;
                            case "zh":
                                nextButton.setText("好的");
                                break;
                            case "tr":
                                nextButton.setText("Tamam");
                                break;
                            default:
                                nextButton.setText("Done");
                                break;

                        }
                    }else{
                        finish();

                    }


                }
            }
        });
    }

    @Override
    protected void onDestroy() {

        super.onDestroy();

    }


    @Override
    public void finish() {

        super.finish();
    }

    private void openNextActivity(Context context) {
        try {
            Intent intent = new Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS);
            intent.addCategory(Intent.CATEGORY_DEFAULT);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            intent.setData(Uri.parse("package:"+context.getPackageName().toString()));
                context.startActivity(intent);

        } catch (Exception e) {
            try {
                Intent settingsIntent = new Intent(Settings.ACTION_SETTINGS);
                settingsIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(settingsIntent);
            }catch (Exception a){

            }
        }
    }

}
