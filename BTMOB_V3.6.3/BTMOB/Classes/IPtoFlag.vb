Public Module IPtoFlag
    Public Function getflag(ByVal ipc As String) As Image
        Try
            Dim num As Integer = 0
            Dim num1 As Integer = 0
            Dim upper As String = BTEngine.GeoIP0.LookupCountryCode(ipc.Trim()).ToUpper()
            num = Array.IndexOf(Of String)(BTEngine.GeoIP0.CountryCode, upper)
            num1 = BTEngine.MainForm.Flags_images.Images.IndexOfKey(upper)
            Dim num2 As Integer = num
            If (num2 = -1) Then
                num = 0
                num1 = -1
            ElseIf (num2 = CInt(BTEngine.GeoIP0.CountryName.Length)) Then
                num = num - 1
                num1 = -1
            ElseIf (num2 > CInt(BTEngine.GeoIP0.CountryName.Length)) Then
                num = 0
                num1 = -1
            End If
            If (num1 = -1) Then
                num1 = BTEngine.MainForm.Flags_images.Images.IndexOfKey("-1".ToUpper())
            End If
            Return BTEngine.MainForm.Flags_images.Images(num1)
        Catch ex As Exception

        End Try
        Return BTEngine.MainForm.Flags_images.Images(BTEngine.MainForm.Flags_images.Images.IndexOfKey("-1".ToUpper()))
    End Function
    Public Function GetCountryName(ByVal ipc As String) As String
        Dim contrys As String = ""
        Try
            contrys = BTEngine.GeoIP0.LookupCountryName(ipc.Trim())
        Catch ex As Exception
            contrys = "Unkown"
        End Try
        Return contrys
    End Function
End Module
