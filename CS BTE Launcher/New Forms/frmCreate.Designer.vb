<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreate))
        Me.cmb_Lan = New System.Windows.Forms.ComboBox()
        Me.pb_Map = New System.Windows.Forms.PictureBox()
        Me.cmb_Map = New System.Windows.Forms.ComboBox()
        Me.cmb_BotLevel = New System.Windows.Forms.ComboBox()
        Me.chk_IncludeBOT = New CS_BTE_Launcher.BitdefenderCheckbox()
        Me.SuperTabItem15 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem20 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SteamEngineTheme1 = New CS_BTE_Launcher.SteamEngineTheme()
        Me.btnSettings = New CS_BTE_Launcher.SteamButton()
        Me.SteamSeparator3 = New CS_BTE_Launcher.SteamSeparator()
        Me.SteamSeparator2 = New CS_BTE_Launcher.SteamSeparator()
        Me.btnSave = New CS_BTE_Launcher.SteamButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtIPAddress = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSvrPwd = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBotAmount = New System.Windows.Forms.TextBox()
        Me.SteamSeparator1 = New CS_BTE_Launcher.SteamSeparator()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMode = New System.Windows.Forms.TextBox()
        Me.txtMaxPlayers = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.lblEnd = New System.Windows.Forms.LinkLabel()
        CType(Me.pb_Map, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SteamEngineTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb_Lan
        '
        Me.cmb_Lan.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.cmb_Lan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Lan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Lan.ForeColor = System.Drawing.Color.White
        Me.cmb_Lan.FormattingEnabled = True
        Me.cmb_Lan.Items.AddRange(New Object() {"Internet", "LAN"})
        Me.cmb_Lan.Location = New System.Drawing.Point(168, 460)
        Me.cmb_Lan.Name = "cmb_Lan"
        Me.cmb_Lan.Size = New System.Drawing.Size(131, 23)
        Me.cmb_Lan.Sorted = True
        Me.cmb_Lan.TabIndex = 109
        '
        'pb_Map
        '
        Me.pb_Map.Image = Global.CS_BTE_Launcher.My.Resources.Resources.random_cso
        Me.pb_Map.Location = New System.Drawing.Point(168, 125)
        Me.pb_Map.Name = "pb_Map"
        Me.pb_Map.Size = New System.Drawing.Size(256, 124)
        Me.pb_Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Map.TabIndex = 64
        Me.pb_Map.TabStop = False
        '
        'cmb_Map
        '
        Me.cmb_Map.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.cmb_Map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Map.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Map.ForeColor = System.Drawing.Color.White
        Me.cmb_Map.FormattingEnabled = True
        Me.cmb_Map.Location = New System.Drawing.Point(168, 96)
        Me.cmb_Map.Name = "cmb_Map"
        Me.cmb_Map.Size = New System.Drawing.Size(330, 23)
        Me.cmb_Map.Sorted = True
        Me.cmb_Map.TabIndex = 61
        '
        'cmb_BotLevel
        '
        Me.cmb_BotLevel.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.cmb_BotLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_BotLevel.Enabled = False
        Me.cmb_BotLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_BotLevel.ForeColor = System.Drawing.Color.White
        Me.cmb_BotLevel.FormattingEnabled = True
        Me.cmb_BotLevel.Items.AddRange(New Object() {"Easy", "Expert", "Hard", "Normal"})
        Me.cmb_BotLevel.Location = New System.Drawing.Point(168, 373)
        Me.cmb_BotLevel.Name = "cmb_BotLevel"
        Me.cmb_BotLevel.Size = New System.Drawing.Size(330, 23)
        Me.cmb_BotLevel.Sorted = True
        Me.cmb_BotLevel.TabIndex = 96
        '
        'chk_IncludeBOT
        '
        Me.chk_IncludeBOT.BackColor = System.Drawing.Color.Transparent
        Me.chk_IncludeBOT.Checked = False
        Me.chk_IncludeBOT.Location = New System.Drawing.Point(168, 313)
        Me.chk_IncludeBOT.Name = "chk_IncludeBOT"
        Me.chk_IncludeBOT.Size = New System.Drawing.Size(55, 25)
        Me.chk_IncludeBOT.TabIndex = 94
        '
        'SuperTabItem15
        '
        Me.SuperTabItem15.GlobalItem = False
        Me.SuperTabItem15.Name = "SuperTabItem15"
        Me.SuperTabItem15.Text = "Information"
        '
        'SuperTabItem20
        '
        Me.SuperTabItem20.GlobalItem = False
        Me.SuperTabItem20.Name = "SuperTabItem20"
        Me.SuperTabItem20.Text = "Edit Fast Buy"
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.Text = "Edit Equipment Set"
        '
        'SteamEngineTheme1
        '
        Me.SteamEngineTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.SteamEngineTheme1.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamEngineTheme1.Controls.Add(Me.btnSettings)
        Me.SteamEngineTheme1.Controls.Add(Me.SteamSeparator3)
        Me.SteamEngineTheme1.Controls.Add(Me.SteamSeparator2)
        Me.SteamEngineTheme1.Controls.Add(Me.btnSave)
        Me.SteamEngineTheme1.Controls.Add(Me.Label14)
        Me.SteamEngineTheme1.Controls.Add(Me.Label13)
        Me.SteamEngineTheme1.Controls.Add(Me.Label12)
        Me.SteamEngineTheme1.Controls.Add(Me.txtIPAddress)
        Me.SteamEngineTheme1.Controls.Add(Me.Label11)
        Me.SteamEngineTheme1.Controls.Add(Me.txtSvrPwd)
        Me.SteamEngineTheme1.Controls.Add(Me.Label10)
        Me.SteamEngineTheme1.Controls.Add(Me.cmb_Lan)
        Me.SteamEngineTheme1.Controls.Add(Me.txtBotAmount)
        Me.SteamEngineTheme1.Controls.Add(Me.SteamSeparator1)
        Me.SteamEngineTheme1.Controls.Add(Me.Label9)
        Me.SteamEngineTheme1.Controls.Add(Me.Label8)
        Me.SteamEngineTheme1.Controls.Add(Me.Label7)
        Me.SteamEngineTheme1.Controls.Add(Me.txtMode)
        Me.SteamEngineTheme1.Controls.Add(Me.txtMaxPlayers)
        Me.SteamEngineTheme1.Controls.Add(Me.Label6)
        Me.SteamEngineTheme1.Controls.Add(Me.Label4)
        Me.SteamEngineTheme1.Controls.Add(Me.txtInfo)
        Me.SteamEngineTheme1.Controls.Add(Me.lblEnd)
        Me.SteamEngineTheme1.Controls.Add(Me.pb_Map)
        Me.SteamEngineTheme1.Controls.Add(Me.cmb_Map)
        Me.SteamEngineTheme1.Controls.Add(Me.chk_IncludeBOT)
        Me.SteamEngineTheme1.Controls.Add(Me.cmb_BotLevel)
        Me.SteamEngineTheme1.Customization = ""
        Me.SteamEngineTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SteamEngineTheme1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SteamEngineTheme1.Image = Nothing
        Me.SteamEngineTheme1.Location = New System.Drawing.Point(0, 0)
        Me.SteamEngineTheme1.Movable = False
        Me.SteamEngineTheme1.Name = "SteamEngineTheme1"
        Me.SteamEngineTheme1.NoRounding = False
        Me.SteamEngineTheme1.Sizable = False
        Me.SteamEngineTheme1.Size = New System.Drawing.Size(558, 587)
        Me.SteamEngineTheme1.TabIndex = 100
        Me.SteamEngineTheme1.Text = "Create Game"
        Me.SteamEngineTheme1.TransparencyKey = System.Drawing.Color.Empty
        '
        'btnSettings
        '
        Me.btnSettings.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.btnSettings.Customization = ""
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSettings.Image = Nothing
        Me.btnSettings.Location = New System.Drawing.Point(168, 547)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.NoRounding = False
        Me.btnSettings.Size = New System.Drawing.Size(162, 28)
        Me.btnSettings.TabIndex = 121
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.Transparent = False
        '
        'SteamSeparator3
        '
        Me.SteamSeparator3.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamSeparator3.Customization = ""
        Me.SteamSeparator3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SteamSeparator3.Image = Nothing
        Me.SteamSeparator3.Location = New System.Drawing.Point(59, 518)
        Me.SteamSeparator3.Name = "SteamSeparator3"
        Me.SteamSeparator3.NoRounding = False
        Me.SteamSeparator3.Size = New System.Drawing.Size(439, 23)
        Me.SteamSeparator3.TabIndex = 120
        Me.SteamSeparator3.Text = "SteamSeparator3"
        Me.SteamSeparator3.Transparent = False
        '
        'SteamSeparator2
        '
        Me.SteamSeparator2.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamSeparator2.Customization = ""
        Me.SteamSeparator2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SteamSeparator2.Image = Nothing
        Me.SteamSeparator2.Location = New System.Drawing.Point(59, 402)
        Me.SteamSeparator2.Name = "SteamSeparator2"
        Me.SteamSeparator2.NoRounding = False
        Me.SteamSeparator2.Size = New System.Drawing.Size(439, 23)
        Me.SteamSeparator2.TabIndex = 119
        Me.SteamSeparator2.Text = "SteamSeparator2"
        Me.SteamSeparator2.Transparent = False
        '
        'btnSave
        '
        Me.btnSave.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.btnSave.Customization = ""
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSave.Image = Nothing
        Me.btnSave.Location = New System.Drawing.Point(336, 547)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.NoRounding = False
        Me.btnSave.Size = New System.Drawing.Size(162, 28)
        Me.btnSave.TabIndex = 118
        Me.btnSave.Text = "Game Start"
        Me.btnSave.Transparent = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(70, 491)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 15)
        Me.Label14.TabIndex = 117
        Me.Label14.Text = "Server Password"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(89, 463)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 15)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "Listen Server"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(100, 433)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 15)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "IP Address"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIPAddress.Enabled = False
        Me.txtIPAddress.ForeColor = System.Drawing.Color.White
        Me.txtIPAddress.Location = New System.Drawing.Point(168, 431)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(330, 23)
        Me.txtIPAddress.TabIndex = 114
        Me.txtIPAddress.Text = "192.168.255.255"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(107, 376)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 15)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "Difficulty"
        '
        'txtSvrPwd
        '
        Me.txtSvrPwd.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtSvrPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSvrPwd.ForeColor = System.Drawing.Color.White
        Me.txtSvrPwd.Location = New System.Drawing.Point(168, 489)
        Me.txtSvrPwd.Name = "txtSvrPwd"
        Me.txtSvrPwd.Size = New System.Drawing.Size(330, 23)
        Me.txtSvrPwd.TabIndex = 112
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(56, 346)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 15)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "No. of CPU players"
        '
        'txtBotAmount
        '
        Me.txtBotAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtBotAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBotAmount.ForeColor = System.Drawing.Color.White
        Me.txtBotAmount.Location = New System.Drawing.Point(168, 344)
        Me.txtBotAmount.Name = "txtBotAmount"
        Me.txtBotAmount.Size = New System.Drawing.Size(330, 23)
        Me.txtBotAmount.TabIndex = 110
        '
        'SteamSeparator1
        '
        Me.SteamSeparator1.Colors = New CS_BTE_Launcher.Bloom(-1) {}
        Me.SteamSeparator1.Customization = ""
        Me.SteamSeparator1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.SteamSeparator1.Image = Nothing
        Me.SteamSeparator1.Location = New System.Drawing.Point(59, 284)
        Me.SteamSeparator1.Name = "SteamSeparator1"
        Me.SteamSeparator1.NoRounding = False
        Me.SteamSeparator1.Size = New System.Drawing.Size(439, 23)
        Me.SteamSeparator1.TabIndex = 109
        Me.SteamSeparator1.Text = "SteamSeparator1"
        Me.SteamSeparator1.Transparent = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(229, 319)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 15)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Include CPU players in this game"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(90, 257)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Max. Players"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(131, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 15)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Map"
        '
        'txtMode
        '
        Me.txtMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMode.ForeColor = System.Drawing.Color.White
        Me.txtMode.Location = New System.Drawing.Point(168, 67)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.ReadOnly = True
        Me.txtMode.Size = New System.Drawing.Size(330, 23)
        Me.txtMode.TabIndex = 105
        Me.txtMode.Text = "No Mode Selected"
        '
        'txtMaxPlayers
        '
        Me.txtMaxPlayers.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtMaxPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxPlayers.ForeColor = System.Drawing.Color.White
        Me.txtMaxPlayers.Location = New System.Drawing.Point(168, 255)
        Me.txtMaxPlayers.Name = "txtMaxPlayers"
        Me.txtMaxPlayers.Size = New System.Drawing.Size(330, 23)
        Me.txtMaxPlayers.TabIndex = 104
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(134, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 15)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Info"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(124, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Mode"
        '
        'txtInfo
        '
        Me.txtInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfo.Enabled = False
        Me.txtInfo.ForeColor = System.Drawing.Color.White
        Me.txtInfo.Location = New System.Drawing.Point(168, 38)
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.Size = New System.Drawing.Size(330, 23)
        Me.txtInfo.TabIndex = 101
        Me.txtInfo.Text = "Counter-Strike World Domination"
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
        Me.lblEnd.Location = New System.Drawing.Point(532, -6)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(27, 40)
        Me.lblEnd.TabIndex = 100
        Me.lblEnd.TabStop = True
        Me.lblEnd.Text = "×"
        Me.lblEnd.UseCompatibleTextRendering = True
        Me.lblEnd.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(140, Byte), Integer))
        '
        'frmCreate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(558, 587)
        Me.ControlBox = False
        Me.Controls.Add(Me.SteamEngineTheme1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCreate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Game"
        CType(Me.pb_Map, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SteamEngineTheme1.ResumeLayout(False)
        Me.SteamEngineTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SuperTabItem15 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabItem20 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pb_Map As System.Windows.Forms.PictureBox
    Friend WithEvents cmb_Map As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Lan As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_BotLevel As System.Windows.Forms.ComboBox
    Friend WithEvents chk_IncludeBOT As CS_BTE_Launcher.BitdefenderCheckbox
    Friend WithEvents SteamEngineTheme1 As CS_BTE_Launcher.SteamEngineTheme
    Friend WithEvents lblEnd As System.Windows.Forms.LinkLabel
    Friend WithEvents txtMode As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxPlayers As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSvrPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBotAmount As System.Windows.Forms.TextBox
    Friend WithEvents SteamSeparator1 As CS_BTE_Launcher.SteamSeparator
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSettings As CS_BTE_Launcher.SteamButton
    Friend WithEvents SteamSeparator3 As CS_BTE_Launcher.SteamSeparator
    Friend WithEvents SteamSeparator2 As CS_BTE_Launcher.SteamSeparator
    Friend WithEvents btnSave As CS_BTE_Launcher.SteamButton
End Class
