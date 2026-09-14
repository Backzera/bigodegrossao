Public Class ListItem
    Public Property DisplayText As String
    Public Property EncodedData As String

    Public Sub New(displayText As String, encodedData As String)
        Me.DisplayText = displayText
        Me.EncodedData = encodedData
    End Sub

    Public Overrides Function ToString() As String
        Return DisplayText
    End Function
End Class