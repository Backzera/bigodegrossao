<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class downloader
    Inherits basestyle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.downprogress = New DrakeUI.Framework.DrakeUITrackBar()
        Me.WorkerCustomapp = New System.ComponentModel.BackgroundWorker()
        Me.WorkerStoreapp = New System.ComponentModel.BackgroundWorker()
        Me.countlabel = New System.Windows.Forms.Label()
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'myscr
        '
        Me.myscr.Visible = False
        '
        'pinbtn
        '
        Me.pinbtn.Location = New System.Drawing.Point(529, 5)
        '
        'minibtn
        '
        Me.minibtn.Location = New System.Drawing.Point(576, 5)
        '
        'closbtn
        '
        Me.closbtn.Location = New System.Drawing.Point(623, 5)
        '
        'myico
        '
        Me.myico.Visible = False
        '
        'mytitle
        '
        Me.mytitle.Size = New System.Drawing.Size(655, 18)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.BTMOB.My.Resources.Resources.uploading
        Me.PictureBox1.Location = New System.Drawing.Point(567, 71)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 41
        Me.PictureBox1.TabStop = False
        '
        'downprogress
        '
        Me.downprogress.DisableColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.downprogress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.downprogress.Enabled = False
        Me.downprogress.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.downprogress.Font = New System.Drawing.Font("Cascadia Code", 12.0!)
        Me.downprogress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.downprogress.Location = New System.Drawing.Point(71, 71)
        Me.downprogress.Name = "downprogress"
        Me.downprogress.RectColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.downprogress.Size = New System.Drawing.Size(496, 55)
        Me.downprogress.Style = DrakeUI.Framework.UIStyle.Custom
        Me.downprogress.TabIndex = 44
        '
        'WorkerCustomapp
        '
        '
        'WorkerStoreapp
        '
        '
        'countlabel
        '
        Me.countlabel.Dock = System.Windows.Forms.DockStyle.Left
        Me.countlabel.Font = New System.Drawing.Font("Cascadia Code", 10.0!, System.Drawing.FontStyle.Bold)
        Me.countlabel.Location = New System.Drawing.Point(2, 71)
        Me.countlabel.Name = "countlabel"
        Me.countlabel.Size = New System.Drawing.Size(69, 55)
        Me.countlabel.TabIndex = 45
        Me.countlabel.Text = "0%"
        Me.countlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'downloader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(669, 128)
        Me.Controls.Add(Me.downprogress)
        Me.Controls.Add(Me.countlabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximumSize = New System.Drawing.Size(669, 128)
        Me.MinimumSize = New System.Drawing.Size(669, 128)
        Me.Name = "downloader"
        Me.Text = "downloader"
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.countlabel, 0)
        Me.Controls.SetChildIndex(Me.downprogress, 0)
        CType(Me.myscr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.myico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents downprogress As DrakeUI.Framework.DrakeUITrackBar
    Friend WithEvents WorkerCustomapp As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerStoreapp As System.ComponentModel.BackgroundWorker
    Friend WithEvents countlabel As Label
End Class
