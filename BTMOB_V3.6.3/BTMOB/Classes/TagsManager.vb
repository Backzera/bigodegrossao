Imports System.IO
Imports Newtonsoft.Json

Public Class TagsManager
    Private tags As List(Of String)

    Public Sub New()
        LoadTags()
    End Sub

    Public Sub AddTag(tag As String)
        If Not tags.Contains(tag) Then
            tags.Add(tag)
            SaveTags()
        End If
    End Sub

    Public Sub RemoveTag(tag As String)
        If tags.Contains(tag) Then
            tags.Remove(tag)
            SaveTags()
        End If
    End Sub

    Public Function GetTags() As List(Of String)
        Return New List(Of String)(tags)
    End Function

    Private Sub LoadTags()
        Try
            If File.Exists(TAGS_path) Then
                Dim json As String = File.ReadAllText(TAGS_path)
                tags = JsonConvert.DeserializeObject(Of List(Of String))(json)
                Exit Sub
            End If
        Catch ex As Exception
            ' Optional: log or display the error
        End Try

        tags = New List(Of String)()
        AddTag("A1")
        SaveTags()
    End Sub

    Private Sub SaveTags()
        Try
            Dim json As String = JsonConvert.SerializeObject(tags, Formatting.Indented)
            File.WriteAllText(TAGS_path, json)
        Catch ex As Exception

        End Try
    End Sub
End Class
