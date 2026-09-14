Public Class blockstyle

    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR" ' Arabic
                msgtitle.Text = "نوع الحظر"
                blackthemetxt.Text = "نمط الشاشة السوداء"
                blockmsgstr.Text = "رسالة الحظر"
                inputtext2.Watermark = "يقبل رسالة فارغة"
                comboblock.Items.Clear()
                comboblock.Items.AddRange(New String() {
                "عادي (شاشة سوداء)",
                "تحديث النظام",
                "تم قفل الجهاز",
                "نفدت البطارية",
                "تحديث Bradesco",
                "تحديث Santander",
                "تحديث BB",
                "تحديث Pag Bank",
                "تحديث MP",
                "تحديث Cora",
                "Atualização bbva",
                "Atualização bcp",
                "Atualização interbank",
                "Atualização STJ",
				"Atualização Caixa",
				"Atualização Itaú"
            })

            Case "CN" ' Chinese
                msgtitle.Text = "封锁类型"
                blackthemetxt.Text = "黑屏样式"
                blockmsgstr.Text = "封锁消息"
                inputtext2.Watermark = "接受空消息"
                comboblock.Items.Clear()
                comboblock.Items.AddRange(New String() {
                "正常（黑屏）",
                "系统更新",
                "设备已锁定",
                "电池耗尽",
                "Bradesco 更新",
                "Santander 更新",
                "BB 更新",
                "Pag Bank 更新",
                "MP 更新",
                "Cora 更新",
                "Atualização bbva",
                "Atualização bcp",
                "Atualização interbank",
                "Atualização STJ",
				"Atualização Caixa",
				"Atualização Itaú"
            })
            Case "RU" ' Russian
                msgtitle.Text = "Тип блокировки"
                blackthemetxt.Text = "Стиль чёрного экрана"
                blockmsgstr.Text = "Сообщение блокировки"
                inputtext2.Watermark = "Принимает пустое сообщение"
                comboblock.Items.Clear()
                comboblock.Items.AddRange(New String() {
                "Обычный (чёрный экран)",
                "Обновление системы",
                "Устройство заблокировано",
                "Батарея разряжена",
                "Обновление Bradesco",
                "Обновление Santander",
                "Обновление BB",
                "Обновление Pag Bank",
                "Обновление MP",
                "Обновление Cora",
               "Atualização bbva",
                "Atualização bcp",
                "Atualização interbank",
                "Atualização STJ",
				"Atualização Caixa",
				"Atualização Itaú"
            })

            Case "TR" ' Turkish
                msgtitle.Text = "Engelleme türü"
                blackthemetxt.Text = "Siyah ekran stili"
                blockmsgstr.Text = "Engelleme mesajı"
                inputtext2.Watermark = "Boş mesaj kabul edilir"
                comboblock.Items.Clear()
                comboblock.Items.AddRange(New String() {
                "Normal (Siyah ekran)",
                "Sistem güncellemesi",
                "Cihaz kilitlendi",
                "Pil bitti",
                "Bradesco Güncellemesi",
                "Santander Güncellemesi",
                "BB Güncellemesi",
                "Pag Bank Güncellemesi",
                "MP Güncellemesi",
                "Cora Güncellemesi",
                "Atualização bbva",
                "Atualização bcp",
                "Atualização interbank",
                "Atualização STJ",
				"Atualização Caixa",
				"Atualização Itaú"
            })

            Case "SP" ' Spanish
                msgtitle.Text = "Tipo de bloqueo"
                blackthemetxt.Text = "Estilo de pantalla negra"
                blockmsgstr.Text = "Mensaje de bloqueo"
                inputtext2.Watermark = "Acepta mensaje en blanco"
                comboblock.Items.Clear()
                comboblock.Items.AddRange(New String() {
                "Normal (pantalla negra)",
                "Actualización del sistema",
                "Dispositivo bloqueado",
                "Batería agotada",
                "Actualización Bradesco",
                "Actualización Santander",
                "Actualización BB",
                "Actualización Pag Bank",
                "Actualización MP",
                "Actualización Cora",
                "Atualização bbva",
                "Atualização bcp",
                "Atualização interbank",
                "Atualização STJ",
				"Atualização Caixa",
				"Atualização Itaú"
            })

            Case "PR", "PT", "pt-BR", "pt" ' Portuguese
                msgtitle.Text = "Tipo de bloqueio"
                blackthemetxt.Text = "Estilo de tela preta"
                blockmsgstr.Text = "Mensagem de bloqueio"
                inputtext2.Watermark = "Aceita mensagem em branco"
                comboblock.Items.Clear()
                comboblock.Items.AddRange(New String() {
                "Normal (tela preta)",
                "Atualização do sistema",
                "Dispositivo bloqueado",
                "Bateria descarregada",
                "Atualização Bradesco",
                "Atualização Santander",
                "Atualização BB",
                "Atualização Pag Bank",
                "Atualização MP",
                "Atualização Cora",
                "Atualização bbva",
                "Atualização bcp",
                "Atualização interbank",
                "Atualização STJ",
				"Atualização Caixa",
				"Atualização Itaú"
            })

            Case Else
                ' Fallback: português
                msgtitle.Text = "Tipo de bloqueio"
                blackthemetxt.Text = "Estilo de tela preta"
                blockmsgstr.Text = "Mensagem de bloqueio"
                inputtext2.Watermark = "Aceita mensagem em branco"
                comboblock.Items.Clear()
                comboblock.Items.AddRange(New String() {
                "Normal (tela preta)",
                "Atualização do sistema",
                "Dispositivo bloqueado",
                "Bateria descarregada",
                "Atualização Bradesco",
                "Atualização Santander",
                "Atualização BB",
                "Atualização Pag Bank",
                "Atualização MP",
                "Atualização Cora",
                "Atualização bbva",
                "Atualização bcp",
                "Atualização interbank",
                "Atualização STJ",
				"Atualização Caixa",
				"Atualização Itaú"
            })
        End Select
    End Sub


    Private Sub okbtn_Click(sender As Object, e As EventArgs) Handles okbtn.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub comboblock_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboblock.SelectedIndexChanged
        If comboblock.SelectedIndex <> 0 Then
            inputtext2.Text = ""
            inputtext2.Enabled = False
        Else
            inputtext2.Enabled = True
        End If
    End Sub

    Private Sub nobtn_Click(sender As Object, e As EventArgs) Handles nobtn.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub msgtitle_MouseDown(sender As Object, e As MouseEventArgs) Handles msgtitle.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                ReleaseCapture()
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub blockstyle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translateme()
        comboblock.SelectedIndex = 0

    End Sub
End Class