Imports System.IO

Public Class SMSmaker
    Private Sub numslist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles numslist.SelectedIndexChanged
        If numslist.SelectedItems.Count > 0 Then
            remnum.Enabled = True
        Else
            remnum.Enabled = False
        End If
    End Sub

    Private Sub addnum_Click(sender As Object, e As EventArgs) Handles addnum.Click
        If String.IsNullOrEmpty(phonetext.Text) Or String.IsNullOrWhiteSpace(phonetext.Text) Then
            BTAlerter.infos("Enter number to add")
            Return
        End If
        numslist.Items.Add(phonetext.Text)
    End Sub

    Private Sub remnum_Click(sender As Object, e As EventArgs) Handles remnum.Click
        If numslist.Items.Count = 0 Then
            Return
        End If
        If numslist.SelectedItem.Count = 0 Then
            BTAlerter.infos("select number from list to remove")
            Return
        End If
        For index = 0 To numslist.SelectedItem.Count - 1
            Try
                numslist.Items.Remove(numslist.SelectedItem(index))
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon2.Click
        Dim openFD As New OpenFileDialog
        openFD.InitialDirectory = "C:\"
        openFD.Title = "Open a Text File"
        openFD.Filter = "Text Files|*.txt"
        If openFD.ShowDialog() = DialogResult.OK Then
            Try
                Dim targetfile As String = openFD.FileName
                If Not String.IsNullOrEmpty(targetfile) AndAlso Not String.IsNullOrWhiteSpace(targetfile) Then
                    Dim linreader() As String = File.ReadAllLines(targetfile)
                    If linreader.Length > 0 Then
                        For index = 0 To linreader.Length - 1
                            Dim newnum As String = linreader(index).Replace(" ", "")
                            If IsNumeric(newnum) Then

                                numslist.Items.Add(newnum)

                            End If
                        Next
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub DrakeUIButtonIcon3_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon3.Click
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click

        If numslist.Items.Count = 0 Then
            MyMsg.Show("No numbers", "please add numbers to the list first", msgtype.warning, False)
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class