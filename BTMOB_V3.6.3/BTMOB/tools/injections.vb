Public Class injections

    Public jectlist As New Dictionary(Of String, String)

    Private Sub combojects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combojects.SelectedIndexChanged
        Try
            Dim currentid As String = combojects.Text
            If jectlist.ContainsKey(currentid) Then
                Dim alldata() As String = jectlist(currentid).Split(":")
                Dim finalmessage As String = alldata(0) + vbNewLine
                For index = 1 To alldata.Count - 1
                    finalmessage += $"Input({index}):" + alldata(index) + vbNewLine
                Next
                TextBox1.Text = finalmessage
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub injections_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class