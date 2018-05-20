<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMsgbox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMsgbox))
        Me.SteamEngineTheme1 = New CS_BTE_Launcher.SteamEngineTheme()
        Me.lblEnd = New System.Windows.Forms.LinkLabel()
        Me.SteamButton1 = New CS_BTE_Launcher.SteamButton()
        Me.SteamSeparator1 = New CS_BTE_Launcher.SteamSeparator()
        Me.btnCancel = New CS_BTE_Launcher.SteamButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SteamEngineTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SteamEngineTheme1
        '
        Me.SteamEngineTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.SteamEngineTheme1.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamEngineTheme1.Controls.Add(Me.lblEnd)
        Me.SteamEngineTheme1.Controls.Add(Me.SteamButton1)
        Me.SteamEngineTheme1.Controls.Add(Me.SteamSeparator1)
        Me.SteamEngineTheme1.Controls.Add(Me.btnCancel)
        Me.SteamEngineTheme1.Controls.Add(Me.Label1)
        Me.SteamEngineTheme1.Customization = ""
        Me.SteamEngineTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SteamEngineTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SteamEngineTheme1.Image = Nothing
        Me.SteamEngineTheme1.Location = New System.Drawing.Point(0, 0)
        Me.SteamEngineTheme1.Movable = False
        Me.SteamEngineTheme1.Name = "SteamEngineTheme1"
        Me.SteamEngineTheme1.NoRounding = False
        Me.SteamEngineTheme1.Sizable = False
        Me.SteamEngineTheme1.Size = New System.Drawing.Size(394, 149)
        Me.SteamEngineTheme1.TabIndex = 0
        Me.SteamEngineTheme1.Text = "Quit"
        Me.SteamEngineTheme1.TransparencyKey = System.Drawing.Color.Empty
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
        Me.lblEnd.Location = New System.Drawing.Point(368, -6)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(27, 40)
        Me.lblEnd.TabIndex = 94
        Me.lblEnd.TabStop = True
        Me.lblEnd.Text = "×"
        Me.lblEnd.UseCompatibleTextRendering = True
        Me.lblEnd.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        '
        'SteamButton1
        '
        Me.SteamButton1.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamButton1.Customization = ""
        Me.SteamButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SteamButton1.Image = Nothing
        Me.SteamButton1.Location = New System.Drawing.Point(32, 127)
        Me.SteamButton1.Name = "SteamButton1"
        Me.SteamButton1.NoRounding = False
        Me.SteamButton1.Size = New System.Drawing.Size(162, 28)
        Me.SteamButton1.TabIndex = 93
        Me.SteamButton1.Text = "Yes"
        Me.SteamButton1.Transparent = False
        '
        'SteamSeparator1
        '
        Me.SteamSeparator1.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamSeparator1.Customization = ""
        Me.SteamSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SteamSeparator1.Image = Nothing
        Me.SteamSeparator1.Location = New System.Drawing.Point(16, 98)
        Me.SteamSeparator1.Name = "SteamSeparator1"
        Me.SteamSeparator1.NoRounding = False
        Me.SteamSeparator1.Size = New System.Drawing.Size(366, 23)
        Me.SteamSeparator1.TabIndex = 92
        Me.SteamSeparator1.Text = "SteamSeparator1"
        Me.SteamSeparator1.Transparent = False
        '
        'btnCancel
        '
        Me.btnCancel.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.btnCancel.Customization = ""
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancel.Image = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(200, 127)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.NoRounding = False
        Me.btnCancel.Size = New System.Drawing.Size(162, 28)
        Me.btnCancel.TabIndex = 91
        Me.btnCancel.Text = "No"
        Me.btnCancel.Transparent = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(370, 37)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Do you wish to stop playing now?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMsgbox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(394, 149)
        Me.Controls.Add(Me.SteamEngineTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMsgbox"
        Me.Opacity = 0.9R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quit Game"
        Me.TopMost = True
        Me.SteamEngineTheme1.ResumeLayout(False)
        Me.SteamEngineTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SteamEngineTheme1 As CS_BTE_Launcher.SteamEngineTheme
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SteamButton1 As CS_BTE_Launcher.SteamButton
    Friend WithEvents SteamSeparator1 As CS_BTE_Launcher.SteamSeparator
    Friend WithEvents btnCancel As CS_BTE_Launcher.SteamButton
    Friend WithEvents lblEnd As System.Windows.Forms.LinkLabel
End Class
