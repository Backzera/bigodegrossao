Imports System.Threading
Imports Vip.Notification

Module BTAlerter
    Public Sub custom(ByVal msg As String,
                      ByVal img As Bitmap,
                      ByVal rondcolor As Color)
        Try
            Alert.ShowCustom(Translateit(msg), img, rondcolor)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Success(ByVal msg As String)

        Try
            Alert.ShowSucess(Translateit(msg))

        Catch ex As Exception

        End Try

    End Sub



    Public Sub Warnings(ByVal msg As String)
        Try
            Alert.ShowWarning(Translateit(msg))

        Catch ex As Exception

        End Try

    End Sub



    Public Sub infos(ByVal msg As String)
        Try
            If BTEngine.MainForm.InvokeRequired Then
                BTEngine.MainForm.Invoke(Sub()
                                             infos(msg)
                                         End Sub)
                Return
            Else
                Alert.ShowInformation(Translateit(msg))
            End If



        Catch ex As Exception

        End Try
    End Sub

    Public Sub erroes(ByVal msg As String)
        Try
            If BTEngine.MainForm.InvokeRequired Then
                BTEngine.MainForm.Invoke(Sub()
                                             erroes(msg)
                                         End Sub)
                Return
            Else
                Alert.ShowError(Translateit(msg))

            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Function Translateit(msg As String) As String
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                msg = Translate(msg, "en", "ar")
                Exit Select
            Case "CN" ' Chinese
                msg = Translate(msg, "en", "zh")
                Exit Select
            Case "RU" ' Russian
                msg = Translate(msg, "en", "ru")
                Exit Select
            Case "TR" ' Turkish
                msg = Translate(msg, "en", "tr")
                Exit Select
            Case "SP" ' Spanish
                msg = Translate(msg, "en", "es")
                Exit Select
            Case "PR" ' Brazilian Portuguese
                msg = Translate(msg, "en", "pt")
                Exit Select
            Case Else

        End Select
        Return msg
    End Function

End Module
