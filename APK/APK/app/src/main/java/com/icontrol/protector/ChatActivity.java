package com.icontrol.protector;



import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.drawable.GradientDrawable;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.TextView;

import org.json.JSONObject;


public class ChatActivity extends Activity {

    private EditText messageEditText;
    private TextView chattitle;
    private LinearLayout chatLayout; // Changed to LinearLayout
    private ScrollView scrollView2;
    private SharedPreferences sharedPreferences;

    private static final String CHAT_PREFS = "chat_prefs";
    private static final String CHAT_KEY = "chat_key";

    // Flag to track if ChatActivity is open
    public boolean isChatActivityOpen = false;

    private static ChatActivity instance;

    public static ChatActivity getInstance() {
        return instance;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        requestWindowFeature(Window.FEATURE_NO_TITLE);

        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);


        setContentView(R.layout.activity_chat);
        instance = this;
        messageEditText = findViewById(R.id.messageEditText);
        chattitle = findViewById(R.id.chattitle);
        scrollView2 = findViewById(R.id.scrollView2);
        chatLayout = findViewById(R.id.chatLayout); // Changed to chatLayout

        Button sendButton = findViewById(R.id.sendButton);

        Intent mydata = getIntent();

        if(mydata != null){
            if(mydata.hasExtra("title")){
                chattitle.setText(mydata.getStringExtra("title"));
            }
        }
//        sharedPreferences = getSharedPreferences(CHAT_PREFS, MODE_PRIVATE);
//
//        String chatHistory = sharedPreferences.getString(CHAT_KEY, "");
//
//        // Populate chatLayout with existing chat history
//        if (!chatHistory.isEmpty()) {
//            String[] messages = chatHistory.split("\n");
//            for (String msg : messages) {
//                String[] parts = msg.split(": ");
//                String sender = parts[0];
//                String message = parts[1];
//                appendToChat(sender, message);
//            }
//        }

        sendButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String message = messageEditText.getText().toString().trim();
                if (!message.isEmpty()) {
                    appendToChat("You", message);
                    messageEditText.setText("");
                    try{
                        JSONObject jsonObject = new JSONObject();
                        jsonObject.put("type", "chat");
                        jsonObject.put("data", message);
                        String jsonData = jsonObject.toString();

                        LiveChat.instance(getApplicationContext()).Livemessage(getApplicationContext(),jsonData);
                    }catch (Exception a){}
                }
            }
        });
    }
    public void appendToChat(String sender, String message) {
        if (isChatActivityOpen) {
            runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    // Create a new LinearLayout to hold the message bubble
                    LinearLayout messageLayout = new LinearLayout(ChatActivity.this);
                    LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(
                            LinearLayout.LayoutParams.WRAP_CONTENT,
                            LinearLayout.LayoutParams.WRAP_CONTENT
                    );

                    // Set layout parameters for the message bubble
                    if (sender.equals("You")) {
                        layoutParams.gravity = Gravity.END; // Align sender messages to the right
                    } else {
                        layoutParams.gravity = Gravity.START; // Align receiver messages to the left
                    }
                    messageLayout.setLayoutParams(layoutParams);
                    messageLayout.setPadding(7, 7, 7, 7);
                    // Create a TextView to display the message
                    TextView messageTextView = new TextView(ChatActivity.this);
                    messageTextView.setText(message);
                    messageTextView.setTextColor(Color.WHITE);
                    messageTextView.setPadding(16, 8, 16, 8);


                    // Set background color and shape for the message bubble
                    GradientDrawable drawable = new GradientDrawable();
                    drawable.setShape(GradientDrawable.RECTANGLE);
                    if (sender.equals("You")) {
                        drawable.setColor(Color.parseColor("#2979FF")); // Blue for sender messages
                    } else {
                        drawable.setColor(Color.parseColor("#4CAF50")); // Green for receiver messages
                    }
                    drawable.setCornerRadius(16);
                    messageTextView.setBackground(drawable);

                    // Add the TextView to the message bubble layout
                    messageLayout.addView(messageTextView);

                    // Add the message bubble layout to the chat layout
                    LinearLayout chatLayout = findViewById(R.id.chatLayout);
                    chatLayout.addView(messageLayout);

                    // Scroll to the bottom of the chat
                    scrollView2.post(new Runnable() {
                        @Override
                        public void run() {
                            scrollView2.fullScroll(ScrollView.FOCUS_DOWN);
                        }
                    });
                }
            });
        }
    }



    // Override onStart and onStop methods to track the activity state
    @Override
    protected void onStart() {
        super.onStart();
        isChatActivityOpen = true;
    }

    @Override
    protected void onStop() {
        super.onStop();
        isChatActivityOpen = false;
    }
}
