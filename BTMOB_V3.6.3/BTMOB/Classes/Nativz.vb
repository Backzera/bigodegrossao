Imports System.IO
Imports System.Runtime.InteropServices
Imports BTMOB.My

Module Nativz




    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    Private Const WM_VSCROLL As Integer = 277
    Private Const SB_PAGEBOTTOM As Integer = 7

    Friend Sub ScrollToBottom(richTextBox As RichTextBox)
        SendMessage(richTextBox.Handle, WM_VSCROLL, CType(SB_PAGEBOTTOM, IntPtr), IntPtr.Zero)
        richTextBox.SelectionStart = richTextBox.Text.Length
    End Sub




    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    <DllImportAttribute("user32.dll")>
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Function ReleaseCapture() As Boolean
    End Function


    Private Const MAX_PATH As Int32 = 260
    Private Const SHGFI_ICON As Int32 = &H100
    Private Const SHGFI_USEFILEATTRIBUTES As Int32 = &H10
    Private Const FILE_ATTRIBUTE_NORMAL As Int32 = &H80
    Private Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Int32
        Public dwAttributes As Int32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)>
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)>
        Public szTypeName As String
    End Structure
    <DllImport("shell32.dll", CharSet:=CharSet.Auto)>
    Private Function SHGetFileInfo(
                ByVal pszPath As String,
                ByVal dwFileAttributes As Int32,
                ByRef psfi As SHFILEINFO,
                ByVal cbFileInfo As Int32,
                ByVal uFlags As Int32) As IntPtr
    End Function
    Public Enum IconSize
        SHGFI_LARGEICON = 0
        SHGFI_SMALLICON = 1
    End Enum
    <DllImport("user32.dll", SetLastError:=True)>
    Private Function DestroyIcon(ByVal hIcon As IntPtr) As Boolean
    End Function
    Public Function GetFileIcon(ByVal fileExt As String) As Bitmap
        Dim shinfo As New SHFILEINFO
        Dim flags As Integer = SHGFI_ICON Or IconSize.SHGFI_LARGEICON Or SHGFI_USEFILEATTRIBUTES

        SHGetFileInfo(fileExt, FILE_ATTRIBUTE_NORMAL, shinfo, Marshal.SizeOf(shinfo), flags)

        If shinfo.hIcon = IntPtr.Zero Then
            Return New Bitmap(1, 1) ' fallback
        End If

        Dim bmp As Bitmap

        Using ico As Icon = Icon.FromHandle(shinfo.hIcon)
            bmp = CType(ico.ToBitmap().Clone(), Bitmap) ' Clone immediately
        End Using

        DestroyIcon(shinfo.hIcon) ' Safe now

        Return bmp
    End Function



    Private Const SHGFI_LARGEICON As Integer = &H0
    Private Const SHGFI_SMALLICON As Integer = &H1
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.[Unicode])>
    Public Structure SHFILEINFOW
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public szTypeName As String
    End Structure

    <DllImport("shell32.dll", EntryPoint:="SHGetFileInfoW")>
    Private Function SHGetFileInfoW(<InAttribute(), MarshalAs(UnmanagedType.LPTStr)> ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFOW, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As Integer
    End Function
    Public Function GetIcon(ByVal PathName As String, ByVal LargeIco As Boolean) As Bitmap
        Dim fi As New SHFILEINFOW
        Dim flags As Integer = If(LargeIco, SHGFI_ICON Or SHGFI_LARGEICON, SHGFI_ICON Or SHGFI_SMALLICON)
        Dim hIconResult As IntPtr = SHGetFileInfoW(PathName, 0, fi, Marshal.SizeOf(fi), flags)

        If fi.hIcon = IntPtr.Zero Then
            Return New Bitmap(1, 1) ' fallback
        End If

        Dim bmp As Bitmap

        Using ico As Icon = Icon.FromHandle(fi.hIcon)
            bmp = CType(ico.ToBitmap().Clone(), Bitmap) ' Important: clone immediately
        End Using

        DestroyIcon(fi.hIcon) ' Now safe to destroy

        Return bmp
    End Function



    Private ReadOnly HWND_TOPMOST As IntPtr = New IntPtr(-1)
    Private Const SWP_NOSIZE As UInt32 = &H1
    Private Const SWP_NOMOVE As UInt32 = &H2
    Public Const TOPMOST_FLAGS As UInt32 = SWP_NOMOVE Or SWP_NOSIZE

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer, cx As Integer, cy As Integer, uFlags As UInt32) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

End Module
