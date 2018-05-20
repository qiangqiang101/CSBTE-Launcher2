<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJoin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJoin))
        Me.SteamEngineTheme1 = New CS_BTE_Launcher.SteamEngineTheme()
        Me.txt_Port = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_IPAddress = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSave = New CS_BTE_Launcher.SteamButton()
        Me.lblEnd = New System.Windows.Forms.LinkLabel()
        Me.SteamEngineTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SteamEngineTheme1
        '
        Me.SteamEngineTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.SteamEngineTheme1.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamEngineTheme1.Controls.Add(Me.lblEnd)
        Me.SteamEngineTheme1.Controls.Add(Me.btnSave)
        Me.SteamEngineTheme1.Controls.Add(Me.txt_Port)
        Me.SteamEngineTheme1.Controls.Add(Me.Label10)
        Me.SteamEngineTheme1.Controls.Add(Me.txt_IPAddress)
        Me.SteamEngineTheme1.Controls.Add(Me.Label9)
        Me.SteamEngineTheme1.Customization = ""
        Me.SteamEngineTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SteamEngineTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SteamEngineTheme1.Image = Nothing
        Me.SteamEngineTheme1.Location = New System.Drawing.Point(0, 0)
        Me.SteamEngineTheme1.Movable = True
        Me.SteamEngineTheme1.Name = "SteamEngineTheme1"
        Me.SteamEngineTheme1.NoRounding = False
        Me.SteamEngineTheme1.Sizable = True
        Me.SteamEngineTheme1.Size = New System.Drawing.Size(360, 182)
        Me.SteamEngineTheme1.TabIndex = 0
        Me.SteamEngineTheme1.Text = "Join Game"
        Me.SteamEngineTheme1.TransparencyKey = System.Drawing.Color.Empty
        '
        'txt_Port
        '
        Me.txt_Port.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txt_Port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Port.ForeColor = System.Drawing.Color.White
        Me.txt_Port.Location = New System.Drawing.Point(121, 83)
        Me.txt_Port.Name = "txt_Port"
        Me.txt_Port.Size = New System.Drawing.Size(183, 23)
        Me.txt_Port.TabIndex = 55
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(86, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 15)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Port"
        '
        'txt_IPAddress
        '
        Me.txt_IPAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txt_IPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_IPAddress.ForeColor = System.Drawing.Color.White
        Me.txt_IPAddress.Location = New System.Drawing.Point(121, 54)
        Me.txt_IPAddress.Name = "txt_IPAddress"
        Me.txt_IPAddress.Size = New System.Drawing.Size(183, 23)
        Me.txt_IPAddress.TabIndex = 54
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(53, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 15)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "IP Address"
        '
        'btnSave
        '
        Me.btnSave.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.btnSave.Customization = ""
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSave.Image = Nothing
        Me.btnSave.Location = New System.Drawing.Point(99, 112)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.NoRounding = False
        Me.btnSave.Size = New System.Drawing.Size(162, 28)
        Me.btnSave.TabIndex = 120
        Me.btnSave.Text = "OK"
        Me.btnSave.Transparent = False
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
        Me.lblEnd.Location = New System.Drawing.Point(334, -7)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(27, 40)
        Me.lblEnd.TabIndex = 121
        Me.lblEnd.TabStop = True
        Me.lblEnd.Text = "×"
        Me.lblEnd.UseCompatibleTextRendering = True
        Me.lblEnd.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        '
        'frmJoin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 182)
        Me.ControlBox = False
        Me.Controls.Add(Me.SteamEngineTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmJoin"
        Me.Opacity = 0.9R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Join Game"
        Me.TopMost = True
        Me.SteamEngineTheme1.ResumeLayout(False)
        Me.SteamEngineTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SteamEngineTheme1 As CS_BTE_Launcher.SteamEngineTheme
    Friend WithEvents txt_Port As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_IPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSave As CS_BTE_Launcher.SteamButton
    Friend WithEvents lblEnd As System.Windows.Forms.LinkLabel
End Class
