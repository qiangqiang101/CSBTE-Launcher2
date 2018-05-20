<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPause
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPause))
        Me.llbl_DC = New System.Windows.Forms.LinkLabel()
        Me.llbl_Resume = New System.Windows.Forms.LinkLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'llbl_DC
        '
        Me.llbl_DC.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_DC.BackColor = System.Drawing.Color.Transparent
        Me.llbl_DC.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_DC.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_DC.ForeColor = System.Drawing.Color.White
        Me.llbl_DC.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_DC.LinkColor = System.Drawing.Color.White
        Me.llbl_DC.Location = New System.Drawing.Point(12, 83)
        Me.llbl_DC.Name = "llbl_DC"
        Me.llbl_DC.Size = New System.Drawing.Size(317, 37)
        Me.llbl_DC.TabIndex = 84
        Me.llbl_DC.TabStop = True
        Me.llbl_DC.Text = "Disconnect"
        Me.llbl_DC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_DC.VisitedLinkColor = System.Drawing.Color.White
        '
        'llbl_Resume
        '
        Me.llbl_Resume.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_Resume.BackColor = System.Drawing.Color.Transparent
        Me.llbl_Resume.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_Resume.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_Resume.ForeColor = System.Drawing.Color.White
        Me.llbl_Resume.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_Resume.LinkColor = System.Drawing.Color.White
        Me.llbl_Resume.Location = New System.Drawing.Point(12, 46)
        Me.llbl_Resume.Name = "llbl_Resume"
        Me.llbl_Resume.Size = New System.Drawing.Size(317, 37)
        Me.llbl_Resume.TabIndex = 83
        Me.llbl_Resume.TabStop = True
        Me.llbl_Resume.Text = "Resume"
        Me.llbl_Resume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_Resume.VisitedLinkColor = System.Drawing.Color.White
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'frmPause
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(341, 169)
        Me.Controls.Add(Me.llbl_DC)
        Me.Controls.Add(Me.llbl_Resume)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPause"
        Me.Opacity = 0.9R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Counter-Strike Breakthrough Edition"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents llbl_DC As System.Windows.Forms.LinkLabel
    Friend WithEvents llbl_Resume As System.Windows.Forms.LinkLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
