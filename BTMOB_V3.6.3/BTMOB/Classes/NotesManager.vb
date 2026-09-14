Imports System.IO
Imports Newtonsoft.Json

Module NotesManager


    ' Ensure the Notes directory exists
    Private Sub EnsureDirectoryExists()
        If Not Directory.Exists(NotesDirectory) Then
            Directory.CreateDirectory(NotesDirectory)
        End If
    End Sub

    ' Get the full file path for a given ID
    Private Function GetFilePath(id As String) As String
        Return Path.Combine(NotesDirectory, $"note_{id}.json")
    End Function

    ' Save a new note for an ID (append if file exists)
    Public Sub SaveNote(id As String, noteText As String)
        EnsureDirectoryExists()
        Dim filePath As String = GetFilePath(id)

        Dim notes As List(Of String) = LoadNotes(id)
        notes.Add(noteText)

        Dim json As String = JsonConvert.SerializeObject(notes, Formatting.Indented)
        File.WriteAllText(filePath, Encrypt(json, "BT-MOB" + "BTMOB" + "H1N1X4lrC"))
    End Sub

    Public Function LoadNotes(id As String) As List(Of String)
        EnsureDirectoryExists()
        Dim filePath As String = GetFilePath(id)

        If Not File.Exists(filePath) Then
            Return New List(Of String)()
        End If

        Dim json As String = File.ReadAllText(filePath)
        Dim notes As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(Decrypt(json, "BT-MOB" + "BTMOB" + "H1N1X4lrC"))

        Return If(notes IsNot Nothing, notes, New List(Of String)())
    End Function



    Public Sub RemoteNote(id As String, noteText As String)
        EnsureDirectoryExists()
        Dim filePath As String = GetFilePath(id)

        If Not File.Exists(filePath) Then Exit Sub

        Dim notes As List(Of String) = LoadNotes(id)
        notes.Remove(noteText)

        If notes.Count = 0 Then
            File.Delete(filePath) ' Delete the file if no notes remain
        Else
            Dim json As String = JsonConvert.SerializeObject(notes, Formatting.Indented)
            File.WriteAllText(filePath, Encrypt(json, "BT-MOB" + "BTMOB" + "H1N1X4lrC"))
        End If
    End Sub


    Public Sub RemoteAll(id As String)
        EnsureDirectoryExists()
        Dim filePath As String = GetFilePath(id)

        If File.Exists(filePath) Then
            File.Delete(filePath)
        End If
    End Sub
End Module
