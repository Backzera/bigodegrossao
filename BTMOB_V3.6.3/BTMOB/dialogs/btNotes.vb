Public Class btNotes

    Public Tclient As BTClient

    Private Sub btNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myico.Image = Tclient.wallpaper

        loadworker.RunWorkerAsync()
    End Sub

    Private Sub loadworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles loadworker.DoWork
        Try
            Dim allnotes As List(Of String) = NotesManager.LoadNotes(Tclient.mobid)
            If allnotes.Count > 0 Then
                Me.Invoke(Sub()
                              notecount.Text = $"{allnotes.Count} {NotesStr}"
                              viewpanel.Controls.Clear()
                              For Each nt As String In allnotes
                                  Dim noteLabel As New Label()
                                  noteLabel.Text = nt
                                  noteLabel.AutoSize = False
                                  noteLabel.Dock = DockStyle.Top
                                  noteLabel.Height = 35 ' Set a fixed height
                                  noteLabel.TextAlign = ContentAlignment.MiddleLeft
                                  noteLabel.Padding = New Padding(5)
                                  noteLabel.BackColor = Color.FromArgb(35, 35, 35)
                                  noteLabel.ForeColor = Color.White ' Text color
                                  noteLabel.BorderStyle = BorderStyle.FixedSingle
                                  noteLabel.Tag = 0
                                  ' Add Click Event to change color
                                  AddHandler noteLabel.Click, Sub(sndr As Object, evnt As EventArgs)
                                                                  ' Reset all labels to white
                                                                  For Each ctrl As Control In viewpanel.Controls
                                                                      If TypeOf ctrl Is Label Then
                                                                          ctrl.ForeColor = Color.White
                                                                          ctrl.Tag = 0
                                                                      End If
                                                                  Next
                                                                  ' Set clicked label to DodgerBlue
                                                                  noteLabel.ForeColor = Color.DodgerBlue
                                                                  noteLabel.Tag = 1
                                                              End Sub

                                  ' Add label to panel
                                  viewpanel.Controls.Add(noteLabel)
                              Next

                          End Sub)

            Else
                Me.Invoke(Sub()
                              viewpanel.Controls.Clear()
                              notecount.Text = $"0 {NotesStr}"
                          End Sub)
            End If
        Catch ex As Exception
            BTAlerter.erroes(ex.Message)
        End Try
    End Sub

    Private Sub sndbtn_Click(sender As Object, e As EventArgs) Handles sndbtn.Click
        Dim btinput As New myinputs
        btinput.msgtitle.Text = "New Note"
        btinput.inputtext.Text = ""

        btinput.inputtext2.Visible = False
        btinput.checkfolder.Visible = False
        btinput.inputtext.Watermark = "this is note ..."

        If btinput.ShowDialog <> DialogResult.OK Then
            Return
        End If

        Dim notetext As String = btinput.inputtext.Text
        NotesManager.SaveNote(Tclient.mobid, notetext)
        BTAlerter.Success("New Note Add")
        loadworker.RunWorkerAsync()
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        If viewpanel.Controls.Count = 0 Then
            BTAlerter.infos("No notes founded.")
            Exit Sub
        End If


        Dim selectedLabel As Label = Nothing
        For Each ctrl As Control In viewpanel.Controls
            If TypeOf ctrl Is Label AndAlso ctrl.Tag = 1 Then
                selectedLabel = DirectCast(ctrl, Label)
                Exit For
            End If
        Next


        If selectedLabel IsNot Nothing Then
            Dim selectedText As String = selectedLabel.Text
            NotesManager.RemoteNote(Tclient.mobid, selectedText)
            loadworker.RunWorkerAsync()
        Else
            'MessageBox.Show("Please select a note first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BTAlerter.Warnings("Please select a note first!")
        End If
    End Sub
End Class