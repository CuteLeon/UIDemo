<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainUI
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainUI))
        Me.lbl雪豹 = New System.Windows.Forms.Label()
        Me.lblCloseButton = New System.Windows.Forms.Label()
        Me.lblClock = New System.Windows.Forms.Label()
        Me.btn_加载 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.Label()
        Me.lblArrows = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl雪豹
        '
        Me.lbl雪豹.BackColor = System.Drawing.Color.Transparent
        Me.lbl雪豹.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl雪豹.Location = New System.Drawing.Point(98, 240)
        Me.lbl雪豹.Name = "lbl雪豹"
        Me.lbl雪豹.Size = New System.Drawing.Size(124, 128)
        Me.lbl雪豹.TabIndex = 3
        '
        'lblCloseButton
        '
        Me.lblCloseButton.BackColor = System.Drawing.Color.Transparent
        Me.lblCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCloseButton.Location = New System.Drawing.Point(293, 0)
        Me.lblCloseButton.Name = "lblCloseButton"
        Me.lblCloseButton.Size = New System.Drawing.Size(27, 27)
        Me.lblCloseButton.TabIndex = 4
        '
        'lblClock
        '
        Me.lblClock.BackColor = System.Drawing.Color.Transparent
        Me.lblClock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblClock.Location = New System.Drawing.Point(12, 60)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(296, 34)
        Me.lblClock.TabIndex = 5
        '
        'btn_加载
        '
        Me.btn_加载.BackColor = System.Drawing.Color.Transparent
        Me.btn_加载.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_加载.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_加载.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_加载.Location = New System.Drawing.Point(92, 400)
        Me.btn_加载.Name = "btn_加载"
        Me.btn_加载.Size = New System.Drawing.Size(136, 53)
        Me.btn_加载.TabIndex = 6
        Me.btn_加载.Text = "ex Wallpaper"
        Me.btn_加载.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar
        '
        Me.ProgressBar.BackColor = System.Drawing.Color.Transparent
        Me.ProgressBar.ForeColor = System.Drawing.Color.White
        Me.ProgressBar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ProgressBar.Location = New System.Drawing.Point(0, 369)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(320, 32)
        Me.ProgressBar.TabIndex = 7
        Me.ProgressBar.Tag = "12"
        Me.ProgressBar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblArrows
        '
        Me.lblArrows.BackColor = System.Drawing.Color.Transparent
        Me.lblArrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblArrows.Location = New System.Drawing.Point(147, 453)
        Me.lblArrows.Name = "lblArrows"
        Me.lblArrows.Size = New System.Drawing.Size(25, 23)
        Me.lblArrows.TabIndex = 8
        '
        'MainUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.XiaoYanUI.My.Resources.UIResource.DefaultBackgrund
        Me.ClientSize = New System.Drawing.Size(320, 480)
        Me.Controls.Add(Me.lblArrows)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.btn_加载)
        Me.Controls.Add(Me.lblClock)
        Me.Controls.Add(Me.lblCloseButton)
        Me.Controls.Add(Me.lbl雪豹)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "XiaoYan Main UI"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl雪豹 As System.Windows.Forms.Label
    Friend WithEvents lblCloseButton As System.Windows.Forms.Label
    Friend WithEvents lblClock As System.Windows.Forms.Label
    Friend WithEvents btn_加载 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.Label
    Friend WithEvents lblArrows As System.Windows.Forms.Label

End Class
