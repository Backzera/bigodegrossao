Imports WebSocket4Net
Imports Newtonsoft.Json
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Net

Public Class WebSocketClient
    Private websocket As WebSocket
    Private reconnectThread As Thread
    'Private messageQueue As ConcurrentQueue(Of String)



    'Private cancellationTokenSource As CancellationTokenSource
    Private My_IDF As String = ""
    Public Property Authorized As Boolean
    Public Property IsConnected As Boolean
    Public Property SocketState As String

    Public Property ShouldReconnect As Boolean = True
    Public ReadOnly LockSend As New Object()

    Public Sub New(Forwhat As String, address As String)
        'messageQueue = New ConcurrentQueue(Of String)()
        'cancellationTokenSource = New CancellationTokenSource()
        SocketState = "Starting"
        BTEngine.SocketsCount += 1
        BTEngine.MainForm.LogConnection(BTConst.nesocketstr, connectionicon("info"), address, Forwhat)
    End Sub
    Public Sub Connect(uidf As String)

        My_IDF = uidf

        ' Initialize and open WebSocket connection
        InitializeWebSocket()

        'Do
        '    Thread.Sleep(1)
        'Loop While Not IsConnected


    End Sub

    Public Sub InitializeWebSocket()
        ' If websocket exists, clear event handlers to avoid duplicates
        If websocket IsNot Nothing Then
            RemoveHandler websocket.Opened, AddressOf OnOpen
            RemoveHandler websocket.Closed, AddressOf OnClose
            RemoveHandler websocket.Error, AddressOf OnError
            RemoveHandler websocket.MessageReceived, AddressOf OnMessageReceived
        End If


        ' Create a new WebSocket instance and set up event handlers
        websocket = New WebSocket(socketapi)
        AddHandler websocket.Opened, AddressOf OnOpen
        AddHandler websocket.Closed, AddressOf OnClose
        AddHandler websocket.Error, AddressOf OnError
        AddHandler websocket.MessageReceived, AddressOf OnMessageReceived
        SocketState = "Connecting"

        ' Attempt to open the WebSocket connection
        websocket.Open()
    End Sub

    Public Sub joinserver()
        Dim joinMessage = JsonConvert.SerializeObject(New With {
                          .itype = "slr_panel",
                          .subc = "join",
                          .idf = My_IDF
                    })

        SendMessage(joinMessage)
    End Sub

    Public Sub OutServer()
        Dim joinMessage = JsonConvert.SerializeObject(New With {
                          .itype = "slr_panel",
                          .subc = "out",
                          .idf = My_IDF
                    })

        SendMessage(joinMessage)
        Thread.Sleep(1)
        ' Disconnect("Out", "Out")

    End Sub

    Private Sub OnOpen(sender As Object, e As EventArgs)
        IsConnected = True
        SocketState = "Connected"
        ShouldReconnect = False ' No need to reconnect if connected
        joinserver()


    End Sub

    Private Sub OnClose(sender As Object, e As EventArgs)
        SocketState = "reconnect"
        IsConnected = False
        ShouldReconnect = True ' Trigger reconnect attempts in the loop
    End Sub

    Private Sub OnError(sender As Object, e As SuperSocket.ClientEngine.ErrorEventArgs)
        Console.WriteLine("WebSocket error: " & e.Exception.Message)
        SocketState = "reconnect"
        IsConnected = False
        ShouldReconnect = True ' Trigger reconnect attempts in the loop
    End Sub

    Public Sub SendComCommand(chatData As Dictionary(Of String, Object), mobpid As String)

        Dim comMessage As New Dictionary(Of String, Object) From {
        {"itype", "slr_panel"},
        {"subc", "com"},
        {"idf", My_IDF},
        {"pid", mobpid},
        {"pdata", chatData}
        }

        Dim jsonMessage As String = JsonConvert.SerializeObject(comMessage)


        SendMessage(jsonMessage)
    End Sub

    Public Sub Sender(message As String)
        Try

            'SyncLock LockSend
            Thread.Sleep(1)
                websocket.Send(message)
                BTEngine.BytesSent += message.Length
            ' End SyncLock

        Catch ex As Exception
            Console.WriteLine($"Sender error {EXtoString(ex)}.")
        End Try
    End Sub
    Public Sub SendMessage(message As String)
        If websocket IsNot Nothing AndAlso websocket.State = WebSocketState.Open Then
            Thread.Sleep(1)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(Sub() Sender(message)), message)
            Dim sendthread As New Thread(Sub()
                                             Sender(message)
                                         End Sub)
            sendthread.IsBackground = True
            sendthread.Start()
            ' Send the message
            '  websocket.Send(message)

            ' Update the BytesSent count
            '  BTEngine.BytesSent += message.Length



        Else
            Console.WriteLine("WebSocket is not connected. Unable to send message.")
        End If
    End Sub


    Private Sub OnMessageReceived(sender As Object, e As MessageReceivedEventArgs)
        'SyncLock messageQueue
        '    messageQueue.Enqueue(e.Message)
        'End SyncLock
        'SyncLock MessagesHandler.listLock
        '    MessagesHandler.stringList.Add(e.Message)
        'End SyncLock
        ' MessagesHandler.EnqueueMessage(e.Message)
        Dim themsg As String = e.Message
        If themsg.StartsWith("{""type"":""msg"",""data"":""{\""type\"":\""add\"",") Or
            themsg.StartsWith("{""type"":""msg"",""data"":""{\""type\"":\""png\"",") Then
            MessagesHandler.EnqueueMessage(e.Message)
        Else
            Dim handlthread As New Thread(Sub()
                                              SyncLock BTEngine.lockworker
                                                  BTEngine.HandleMessage(e.Message)
                                              End SyncLock

                                          End Sub)
            handlthread.IsBackground = True
            handlthread.Start()
        End If
        BTEngine.BytesReceived += e.Message.Length


        '        Await Task.Run(Sub()
        '                           BTEngine.HandleMessage(e.Message)
        ''
        '                       End Sub)

    End Sub




    Public Sub Disconnect(Forwhat As String, address As String)

        BTEngine.MainForm.LogConnection(BTConst.disconnt, connectionicon("discon"), address, Forwhat)

        BTEngine.SocketsCount -= 1
        SocketState = "Disconnected"
        ShouldReconnect = False ' Stop any further reconnection attempts
        Try
            If websocket IsNot Nothing Then
                websocket.Close()
                websocket.Dispose()
                IsConnected = False
                websocket = Nothing
                'cancellationTokenSource.Cancel()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
