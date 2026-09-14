Imports System.IO
Imports System.Net.Http
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS


Public Class ijectionlab
    Private fctb As FastColoredTextBoxNS.FastColoredTextBox
    Private updatePreviewTimer As New Timer With {.Interval = 500} ' 500ms delay
    Private skipchange As Boolean = False
    Private tagStyle, attrNameStyle, attrValueStyle, tagBracketStyle As TextStyle
    Private contentTextStyle, jsFunctionStyle, cssSelectorStyle, commentStyle As TextStyle
    Private Sub translateme()
        Select Case BTRegistry.GetValue(Regz.Language, "null")

            Case "AR"
                searchtext.Watermark = "⌕ بحث"
                delsbtn1.Text = "حذف"
                delallbtn.Text = "حذف الكل"
                addnbtn.Text = "أضافة جديد"
                BTtiptool.SetToolTip(savebtn, "حفظ التغيرات")
                BTtiptool.SetToolTip(prevbtn, "عرض\اخفاء")
                Exit Select

            Case "CN" ' Chinese
                searchtext.Watermark = "⌕ 搜索"
                delsbtn1.Text = "删除"
                delallbtn.Text = "全部删除"
                addnbtn.Text = "新增"
                BTtiptool.SetToolTip(savebtn, "保存更改")
                BTtiptool.SetToolTip(prevbtn, "显示/隐藏")
                Exit Select

            Case "RU" ' Russian
                searchtext.Watermark = "⌕ Поиск"
                delsbtn1.Text = "Удалить"
                delallbtn.Text = "Удалить всё"
                addnbtn.Text = "Добавить новое"
                BTtiptool.SetToolTip(savebtn, "Сохранить изменения")
                BTtiptool.SetToolTip(prevbtn, "Показать/Скрыть")
                Exit Select

            Case "TR" ' Turkish
                searchtext.Watermark = "⌕ Ara"
                delsbtn1.Text = "Sil"
                delallbtn.Text = "Tümünü Sil"
                addnbtn.Text = "Yeni Ekle"
                BTtiptool.SetToolTip(savebtn, "Değişiklikleri kaydet")
                BTtiptool.SetToolTip(prevbtn, "Göster/Gizle")
                Exit Select

            Case "SP" ' Spanish
                searchtext.Watermark = "⌕ Buscar"
                delsbtn1.Text = "Eliminar"
                delallbtn.Text = "Eliminar todo"
                addnbtn.Text = "Agregar nuevo"
                BTtiptool.SetToolTip(savebtn, "Guardar cambios")
                BTtiptool.SetToolTip(prevbtn, "Mostrar/Ocultar")
                Exit Select

            Case "PR" ' Brazilian Portuguese
                searchtext.Watermark = "⌕ Buscar"
                delsbtn1.Text = "Excluir"
                delallbtn.Text = "Excluir tudo"
                addnbtn.Text = "Adicionar novo"
                BTtiptool.SetToolTip(savebtn, "Salvar alterações")
                BTtiptool.SetToolTip(prevbtn, "Mostrar/Ocultar")
                Exit Select

            Case Else
                ' Handle any other cases or defaults here
        End Select
    End Sub


    Private Async Sub jectslist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles jectslist.SelectedIndexChanged
        If jectslist.SelectedItem IsNot Nothing Then
            Dim selectedject As String = MyRes.injections_Path & $"\{jectslist.SelectedItem.ToString()}.zip"
            If Not System.IO.File.Exists(selectedject) Then
                Return
            End If
            Dim htmlContent As String = ExtractHtmlFromZip(selectedject)
            If htmlContent Is Nothing Then
                BTAlerter.erroes(nohtfindstr)
                Return
            End If
            skipchange = True
            fctb.Text = htmlContent
            Await jectview.EnsureCoreWebView2Async()
            jectview.NavigateToString(htmlContent)
            jectview.Visible = True
        End If

    End Sub

    Private searchDelayTimer As New Timer With {.Interval = 300}

    Private Sub prevbtn_Click(sender As Object, e As EventArgs) Handles prevbtn.Click
        If prevbtn.Tag.ToString = "f" Then
            jectview.Visible = False
            prevbtn.Tag = "t"
        Else
            jectview.Visible = True
            prevbtn.Tag = "f"
        End If
    End Sub

    Private Sub DrakeUIButtonIcon1_Click(sender As Object, e As EventArgs) Handles delsbtn1.Click
        If jectslist.Items.Count > 0 Then
            If jectslist.SelectedItem Is Nothing Then
                BTAlerter.infos(slctidstr)
                Return
            End If
            Dim selectedject As String = MyRes.injections_Path & $"\{jectslist.SelectedItem.ToString()}.zip"
            If Not System.IO.File.Exists(selectedject) Then
                Return
            End If
            If MyMsg.Show(delfilstr, $"{surdelestr}:{vbNewLine}{jectslist.SelectedItem.ToString()}", msgtype.Confirm, True) = DialogResult.OK Then
                System.IO.File.Delete(selectedject)
                jectslist.Items.RemoveAt(jectslist.SelectedIndex)
                fctb.Text = ""
                jectview.CoreWebView2.Navigate("about:blank")

            End If
        End If
    End Sub

    Private Sub DrakeUIButtonIcon3_Click(sender As Object, e As EventArgs) Handles savebtn.Click
        Try
            If jectslist.Items.Count > 0 Then
                If jectslist.SelectedItem Is Nothing Then
                    BTAlerter.infos(slctidstr)
                    Return
                End If
                If MyMsg.Show(confirmstr, $"{svchngstr}:{vbNewLine}{jectslist.SelectedItem.ToString()}", msgtype.Confirm, True) = DialogResult.OK Then
                    Dim htmltext As String = fctb.Text
                    Dim tempsave As String = Createtemp(htmltext)
                    Dim savepath As String = MyRes.injections_Path & $"\{jectslist.SelectedItem.ToString()}.zip"
                    ZipJectFile(tempsave, savepath, $"{jectslist.SelectedItem.ToString()}.html")
                    System.IO.File.Delete(tempsave)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DrakeUIButtonIcon2_Click(sender As Object, e As EventArgs) Handles addnbtn.Click
        Try
            Dim openFileDialog As New OpenFileDialog()

            openFileDialog.Filter = "HTML Files (*.html;*.htm)|*.html;*.htm"
            openFileDialog.Title = slcthtmstr
            openFileDialog.CheckFileExists = True
            openFileDialog.Multiselect = False

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedFilePath As String = openFileDialog.FileName

input1:
                Dim packageid As String = ""
                Dim btinput As New myinputs
                btinput.msgtitle.Text = tappidstr
                btinput.inputtext.Text = ""
                btinput.inputtext.Watermark = "com.example.app"
                If btinput.ShowDialog <> DialogResult.OK Then
                    Return
                End If

                packageid = btinput.inputtext.Text
                If isEmpty(packageid) Then
                    BTAlerter.infos(slctidstr)
                    GoTo input1
                End If

                Dim savepath As String = MyRes.injections_Path & $"\{packageid}.zip"
                ZipJectFile(selectedFilePath, savepath, $"{packageid}.html")

                Dim addindx As Integer = jectslist.Items.Add(packageid)
                jectslist.SelectedIndex = addindx

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrakeUIButtonIcon4_Click(sender As Object, e As EventArgs) Handles delallbtn.Click
        If MyMsg.Show(confirmstr, $"{delallvstr}?", msgtype.Confirm, True) = DialogResult.OK Then
            'delete all .zip from > MyRes.injections_Path
            Dim mainfolder As String = MyRes.injections_Path
            If Directory.Exists(mainfolder) Then
                Try
                    Directory.Delete(mainfolder, True) ' Delete folder and all contents
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                    Exit Sub
                End Try
            End If

            ' Recreate the folder
            Directory.CreateDirectory(mainfolder)
        End If
    End Sub

    Private Sub searchtext_TextChanged(sender As Object, e As EventArgs) Handles searchtext.TextChanged
        searchDelayTimer.Stop()
        searchDelayTimer.Start()
    End Sub

    Private Sub PerformSearch(sender As Object, e As EventArgs)
        searchDelayTimer.Stop()

        Dim tofind As String = searchtext.Text.Trim().ToLower()
        If Not String.IsNullOrEmpty(tofind) AndAlso jectslist.Items.Count > 0 Then
            For index = 0 To jectslist.Items.Count - 1
                Dim currentItem As String = jectslist.Items(index).ToString().ToLower()
                If currentItem.Contains(tofind) Then
                    jectslist.SelectedIndex = index
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Async Sub UpdatePreview(sender As Object, e As EventArgs)
        updatePreviewTimer.Stop()

        Dim html As String = fctb.Text
        If String.IsNullOrWhiteSpace(html) Then Return

        Await jectview.EnsureCoreWebView2Async()
        jectview.NavigateToString(html)
    End Sub
    Private Sub reflect()
        If skipchange Then
            skipchange = False
            Return
        End If
        updatePreviewTimer.Stop()
        updatePreviewTimer.Start()
    End Sub

    Private Sub ijectionlab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler searchDelayTimer.Tick, AddressOf PerformSearch
        AddHandler updatePreviewTimer.Tick, AddressOf UpdatePreview



        fctb = New FastColoredTextBoxNS.FastColoredTextBox
        fctb.Dock = DockStyle.Fill
        fctb.Language = FastColoredTextBoxNS.Language.HTML
        fctb.Font = New Font("Consolas", 12)
        fctb.BackColor = Color.FromArgb(30, 30, 30)
        fctb.ForeColor = Color.Gainsboro
        fctb.Font = New Font("Consolas", 10)
        fctb.Language = Language.Custom
        fctb.ClearStylesBuffer()
        fctb.AllowSeveralTextStyleDrawing = False
        fctb.LeftPadding = 15

        ' Define styles
        tagStyle = New TextStyle(Brushes.DeepSkyBlue, Nothing, FontStyle.Regular)
        attrNameStyle = New TextStyle(Brushes.LightSkyBlue, Nothing, FontStyle.Regular)
        attrValueStyle = New TextStyle(Brushes.SandyBrown, Nothing, FontStyle.Regular)
        tagBracketStyle = New TextStyle(New SolidBrush(Color.DimGray), Nothing, FontStyle.Regular)
        contentTextStyle = New TextStyle(Brushes.Gainsboro, Nothing, FontStyle.Regular)
        jsFunctionStyle = New TextStyle(Brushes.Gold, Nothing, FontStyle.Regular)
        cssSelectorStyle = New TextStyle(Brushes.Gold, Nothing, FontStyle.Regular)
        commentStyle = New TextStyle(Brushes.DarkSeaGreen, Nothing, FontStyle.Italic)

        ' Register styles (important!)
        fctb.AddStyle(tagStyle)
        fctb.AddStyle(attrNameStyle)
        fctb.AddStyle(attrValueStyle)
        fctb.AddStyle(tagBracketStyle)
        fctb.AddStyle(contentTextStyle)
        fctb.AddStyle(jsFunctionStyle)
        fctb.AddStyle(cssSelectorStyle)
        fctb.AddStyle(commentStyle)

        ' Hook into delayed text changed
        AddHandler fctb.TextChangedDelayed, AddressOf ApplyHighlighting

        fctb.Text = ""
        AddHandler fctb.TextChanged, AddressOf reflect

        Dim resizediotr As New ResizeableControl(jectview)
        resizediotr.AllowedEdge = ResizeableControl.EdgeEnum.Left


        Panel4.Controls.Add(fctb)

        SetDoubleBuffered(fctb)
        translateme()
    End Sub
    Private Sub ApplyHighlighting(sender As Object, e As EventArgs)
        Dim range = fctb.Range
        range.ClearStyle(tagStyle, attrNameStyle, attrValueStyle, tagBracketStyle,
                     contentTextStyle, jsFunctionStyle, cssSelectorStyle, commentStyle)

        ' Tag brackets like <, >, </
        range.SetStyle(tagBracketStyle, "</?|/>")

        ' Tag names like div, input
        range.SetStyle(tagStyle, "(?<=</?)(\w+)")

        ' Attribute names like id=, name=
        range.SetStyle(attrNameStyle, "(?<=\s)([\w-]+)(?==)")

        ' Attribute values like "text"
        range.SetStyle(attrValueStyle, """[^""]*""")

        ' HTML content between tags
        range.SetStyle(contentTextStyle, "(?<=>)[^<>]+(?=<)")

        ' Function names in JS
        range.SetStyle(jsFunctionStyle, "(?<=function\s+)\w+|(?<=\.)\w+(?=\()")

        ' CSS Selectors
        range.SetStyle(cssSelectorStyle, "\b(body|input|div|img|button|a)\b(?=\s*\{)")

        ' Comments
        range.SetStyle(commentStyle, "<!--.*?-->", RegexOptions.Singleline)
    End Sub

End Class