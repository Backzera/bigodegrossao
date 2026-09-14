<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LocationMap
    Inherits basestyle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.mapview = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.savitbtn = New DrakeUI.Framework.DrakeUIButtonIcon()
        Me.comboacctype = New DrakeUI.Framework.DrakeUIComboBox()
        Me.savetimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mapview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(659, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(706, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(753, 5)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(785, 18)
        '
        'mapview
        '
        Me.mapview.AllowExternalDrop = True
        Me.mapview.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mapview.CreationProperties = Nothing
        Me.mapview.DefaultBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mapview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mapview.Location = New System.Drawing.Point(2, 115)
        Me.mapview.Name = "mapview"
        Me.mapview.Size = New System.Drawing.Size(795, 591)
        Me.mapview.TabIndex = 40
        Me.mapview.ZoomFactor = 1.0R
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.savitbtn)
        Me.Panel2.Controls.Add(Me.comboacctype)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(795, 44)
        Me.Panel2.TabIndex = 41
        '
        'savitbtn
        '
        Me.savitbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.savitbtn.Dock = System.Windows.Forms.DockStyle.Right
        Me.savitbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.savitbtn.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.savitbtn.FillHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.savitbtn.FillPressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.savitbtn.FillSelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.savitbtn.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.savitbtn.ForeHoverColor = System.Drawing.Color.Gray
        Me.savitbtn.Location = New System.Drawing.Point(730, 10)
        Me.savitbtn.Name = "savitbtn"
        Me.savitbtn.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.savitbtn.RectColor = System.Drawing.Color.Gray
        Me.savitbtn.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.savitbtn.RectHoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.savitbtn.RectPressColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.savitbtn.RectSelectedColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.savitbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.savitbtn.Size = New System.Drawing.Size(55, 24)
        Me.savitbtn.Style = DrakeUI.Framework.UIStyle.Custom
        Me.savitbtn.Symbol = 57572
        Me.savitbtn.TabIndex = 50
        Me.savitbtn.Tag = "n"
        Me.savitbtn.TagString = ""
        '
        'comboacctype
        '
        Me.comboacctype.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.comboacctype.Dock = System.Windows.Forms.DockStyle.Left
        Me.comboacctype.DropDownStyle = DrakeUI.Framework.UIDropDownStyle.DropDownList
        Me.comboacctype.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.comboacctype.FillDisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.comboacctype.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.comboacctype.ForeColor = System.Drawing.Color.White
        Me.comboacctype.Items.AddRange(New Object() {"Satellite", "Dark", "Light"})
        Me.comboacctype.Location = New System.Drawing.Point(10, 10)
        Me.comboacctype.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.comboacctype.MinimumSize = New System.Drawing.Size(63, 0)
        Me.comboacctype.Name = "comboacctype"
        Me.comboacctype.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.comboacctype.RadiusSides = DrakeUI.Framework.UICornerRadiusSides.None
        Me.comboacctype.RectColor = System.Drawing.Color.Gray
        Me.comboacctype.RectDisableColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.comboacctype.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom
        Me.comboacctype.Size = New System.Drawing.Size(213, 25)
        Me.comboacctype.Style = DrakeUI.Framework.UIStyle.Custom
        Me.comboacctype.TabIndex = 49
        Me.comboacctype.Text = "Satellite"
        Me.comboacctype.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.comboacctype.Watermark = "install type"
        '
        'savetimer
        '
        Me.savetimer.Interval = 1000
        '
        'LocationMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 708)
        Me.Controls.Add(Me.mapview)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "LocationMap"
        Me.Text = "LocationMap"
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.mapview, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mapview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mapview As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Panel2 As Panel
    Friend WithEvents comboacctype As DrakeUI.Framework.DrakeUIComboBox
    Friend WithEvents savitbtn As DrakeUI.Framework.DrakeUIButtonIcon
    Friend WithEvents savetimer As Timer
End Class
