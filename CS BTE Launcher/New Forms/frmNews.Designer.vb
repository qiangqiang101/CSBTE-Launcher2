<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNews
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNews))
        Me.SteamEngineTheme1 = New CS_BTE_Launcher.SteamEngineTheme()
        Me.SteamSeparator1 = New CS_BTE_Launcher.SteamSeparator()
        Me.btnCancel = New CS_BTE_Launcher.SteamButton()
        Me.lblEnd = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.SteamEngineTheme1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SteamEngineTheme1
        '
        Me.SteamEngineTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.SteamEngineTheme1.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamEngineTheme1.Controls.Add(Me.SteamSeparator1)
        Me.SteamEngineTheme1.Controls.Add(Me.btnCancel)
        Me.SteamEngineTheme1.Controls.Add(Me.lblEnd)
        Me.SteamEngineTheme1.Controls.Add(Me.PictureBox1)
        Me.SteamEngineTheme1.Controls.Add(Me.WebBrowser1)
        Me.SteamEngineTheme1.Customization = ""
        Me.SteamEngineTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SteamEngineTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SteamEngineTheme1.Image = Nothing
        Me.SteamEngineTheme1.Location = New System.Drawing.Point(0, 0)
        Me.SteamEngineTheme1.Movable = False
        Me.SteamEngineTheme1.Name = "SteamEngineTheme1"
        Me.SteamEngineTheme1.NoRounding = False
        Me.SteamEngineTheme1.Sizable = False
        Me.SteamEngineTheme1.Size = New System.Drawing.Size(532, 524)
        Me.SteamEngineTheme1.TabIndex = 0
        Me.SteamEngineTheme1.Text = "News"
        Me.SteamEngineTheme1.TransparencyKey = System.Drawing.Color.Empty
        '
        'SteamSeparator1
        '
        Me.SteamSeparator1.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamSeparator1.Customization = ""
        Me.SteamSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SteamSeparator1.Image = Nothing
        Me.SteamSeparator1.Location = New System.Drawing.Point(12, 473)
        Me.SteamSeparator1.Name = "SteamSeparator1"
        Me.SteamSeparator1.NoRounding = False
        Me.SteamSeparator1.Size = New System.Drawing.Size(512, 23)
        Me.SteamSeparator1.TabIndex = 90
        Me.SteamSeparator1.Text = "SteamSeparator1"
        Me.SteamSeparator1.Transparent = False
        '
        'btnCancel
        '
        Me.btnCancel.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.btnCancel.Customization = ""
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancel.Image = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(362, 502)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NoRounding = False
        Me.btnCancel.Size = New System.Drawing.Size(162, 28)
        Me.btnCancel.TabIndex = 89
        Me.btnCancel.Text = "Close"
        Me.btnCancel.Transparent = False
        '
        'lblEnd
        '
        Me.lblEnd.ActiveLinkColor = System.Drawing.Color.White
        Me.lblEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEnd.AutoSize = True
        Me.lblEnd.BackColor = System.Drawing.Color.Transparent
        Me.lblEnd.Font = New System.Drawing.Font("Segoe UI", 19.0!)
        Me.lblEnd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.lblEnd.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblEnd.LinkColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.lblEnd.Location = New System.Drawing.Point(506, -5)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(27, 40)
        Me.lblEnd.TabIndex = 88
        Me.lblEnd.TabStop = True
        Me.lblEnd.Text = "×"
        Me.lblEnd.UseCompatibleTextRendering = True
        Me.lblEnd.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.CS_BTE_Launcher.My.Resources.Resources.noticetitle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(512, 64)
        Me.PictureBox1.TabIndex = 87
        Me.PictureBox1.TabStop = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 108)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(512, 359)
        Me.WebBrowser1.TabIndex = 85
        Me.WebBrowser1.Url = New System.Uri("http://csbte.tk/bte/news2.php", System.UriKind.Absolute)
        '
        'frmNews
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 524)
        Me.ControlBox = False
        Me.Controls.Add(Me.SteamEngineTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmNews"
        Me.Opacity = 0.9R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "News"
        Me.TopMost = True
        Me.SteamEngineTheme1.ResumeLayout(False)
        Me.SteamEngineTheme1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SteamEngineTheme1 As CS_BTE_Launcher.SteamEngineTheme
    Friend WithEvents btnCancel As CS_BTE_Launcher.SteamButton
    Friend WithEvents lblEnd As System.Windows.Forms.LinkLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents SteamSeparator1 As CS_BTE_Launcher.SteamSeparator
End Class
