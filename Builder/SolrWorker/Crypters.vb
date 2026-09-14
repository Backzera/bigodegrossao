Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security.Cryptography

Public Class Crypters



    Private Shared singleCrypters As Crypters = Nothing

    Private Shared MY_IV As String = "2230209522049090" 'length 16

    Private Shared My_PASSWORD As String = "4814780584699673"

    Private Shared SALT As String = "2894356330652558"

    Public Shared Function Create() As Crypters
        If singleCrypters IsNot Nothing Then
            Return singleCrypters
        End If
        singleCrypters = New Crypters()
        Return singleCrypters
    End Function
    Public Function Encrypt(ByVal raw As String) As String
        Using csp = New AesCryptoServiceProvider()
            Dim e As ICryptoTransform = GetCryptoTransform(csp, True)
            Dim inputBuffer As Byte() = Encoding.GetBytes(raw) 'Reference to a non-shared member requires an object reference
            Dim output As Byte() = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length)
            Dim encrypted As String = Convert.ToBase64String(output)
            Return encrypted
        End Using
    End Function

    Public Function Decrypt(ByVal encrypted As String) As String
        Using csp = New AesCryptoServiceProvider()
            Dim d = GetCryptoTransform(csp, False)
            Dim output As Byte() = Convert.FromBase64String(encrypted)
            Dim decryptedOutput As Byte() = d.TransformFinalBlock(output, 0, output.Length)
            Dim decypted As String = Encoding.GetString(decryptedOutput) 'Reference to a non-shared member requires an object reference
            Return decypted
        End Using
    End Function
    Private Function GetCryptoTransform(ByVal csp As AesCryptoServiceProvider, ByVal encrypting As Boolean) As ICryptoTransform
        csp.Mode = CipherMode.CBC
        csp.Padding = PaddingMode.PKCS7
        Dim spec = New Rfc2898DeriveBytes(Encoding.GetBytes(My_PASSWORD), Encoding.GetBytes(SALT), 65536) 'Reference to a non-shared member requires an object reference
        Dim key As Byte() = spec.GetBytes(16)
        csp.IV = Encoding.GetBytes(MY_IV) 'Reference to a non-shared member requires an object reference
        csp.Key = key

        If encrypting Then
            Return csp.CreateEncryptor()
        End If

        Return csp.CreateDecryptor()
    End Function
End Class
