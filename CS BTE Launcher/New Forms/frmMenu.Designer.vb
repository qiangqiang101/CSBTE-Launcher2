<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.llbl_StartNormal = New System.Windows.Forms.LinkLabel()
        Me.llbl_End = New System.Windows.Forms.LinkLabel()
        Me.llbl_JoinSvr = New System.Windows.Forms.LinkLabel()
        Me.llbl_Update = New System.Windows.Forms.LinkLabel()
        Me.llbl_Settings = New System.Windows.Forms.LinkLabel()
        Me.llbl_WeaponSel = New System.Windows.Forms.LinkLabel()
        Me.llbl_CreateGame = New System.Windows.Forms.LinkLabel()
        Me.llbl_Store = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.llblUserProfile = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'llbl_StartNormal
        '
        Me.llbl_StartNormal.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_StartNormal.BackColor = System.Drawing.Color.Transparent
        Me.llbl_StartNormal.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_StartNormal.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_StartNormal.ForeColor = System.Drawing.Color.White
        Me.llbl_StartNormal.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_StartNormal.LinkColor = System.Drawing.Color.White
        Me.llbl_StartNormal.Location = New System.Drawing.Point(12, 218)
        Me.llbl_StartNormal.Name = "llbl_StartNormal"
        Me.llbl_StartNormal.Size = New System.Drawing.Size(727, 37)
        Me.llbl_StartNormal.TabIndex = 88
        Me.llbl_StartNormal.TabStop = True
        Me.llbl_StartNormal.Text = "Start Normally"
        Me.llbl_StartNormal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_StartNormal.VisitedLinkColor = System.Drawing.Color.White
        '
        'llbl_End
        '
        Me.llbl_End.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_End.BackColor = System.Drawing.Color.Transparent
        Me.llbl_End.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_End.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_End.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_End.LinkColor = System.Drawing.Color.White
        Me.llbl_End.Location = New System.Drawing.Point(12, 537)
        Me.llbl_End.Name = "llbl_End"
        Me.llbl_End.Size = New System.Drawing.Size(727, 37)
        Me.llbl_End.TabIndex = 87
        Me.llbl_End.TabStop = True
        Me.llbl_End.Text = "Exit"
        Me.llbl_End.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_End.VisitedLinkColor = System.Drawing.Color.White
        '
        'llbl_JoinSvr
        '
        Me.llbl_JoinSvr.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_JoinSvr.BackColor = System.Drawing.Color.Transparent
        Me.llbl_JoinSvr.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_JoinSvr.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_JoinSvr.ForeColor = System.Drawing.Color.White
        Me.llbl_JoinSvr.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_JoinSvr.LinkColor = System.Drawing.Color.White
        Me.llbl_JoinSvr.Location = New System.Drawing.Point(12, 255)
        Me.llbl_JoinSvr.Name = "llbl_JoinSvr"
        Me.llbl_JoinSvr.Size = New System.Drawing.Size(727, 37)
        Me.llbl_JoinSvr.TabIndex = 86
        Me.llbl_JoinSvr.TabStop = True
        Me.llbl_JoinSvr.Text = "Join Game"
        Me.llbl_JoinSvr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_JoinSvr.VisitedLinkColor = System.Drawing.Color.White
        '
        'llbl_Update
        '
        Me.llbl_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_Update.BackColor = System.Drawing.Color.Transparent
        Me.llbl_Update.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_Update.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_Update.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_Update.LinkColor = System.Drawing.Color.White
        Me.llbl_Update.Location = New System.Drawing.Point(12, 480)
        Me.llbl_Update.Name = "llbl_Update"
        Me.llbl_Update.Size = New System.Drawing.Size(727, 37)
        Me.llbl_Update.TabIndex = 85
        Me.llbl_Update.TabStop = True
        Me.llbl_Update.Text = "Check for Updates"
        Me.llbl_Update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_Update.VisitedLinkColor = System.Drawing.Color.White
        '
        'llbl_Settings
        '
        Me.llbl_Settings.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_Settings.BackColor = System.Drawing.Color.Transparent
        Me.llbl_Settings.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_Settings.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_Settings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_Settings.LinkColor = System.Drawing.Color.White
        Me.llbl_Settings.Location = New System.Drawing.Point(12, 443)
        Me.llbl_Settings.Name = "llbl_Settings"
        Me.llbl_Settings.Size = New System.Drawing.Size(727, 37)
        Me.llbl_Settings.TabIndex = 84
        Me.llbl_Settings.TabStop = True
        Me.llbl_Settings.Text = "Settings"
        Me.llbl_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_Settings.VisitedLinkColor = System.Drawing.Color.White
        '
        'llbl_WeaponSel
        '
        Me.llbl_WeaponSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_WeaponSel.BackColor = System.Drawing.Color.Transparent
        Me.llbl_WeaponSel.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_WeaponSel.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_WeaponSel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_WeaponSel.LinkColor = System.Drawing.Color.White
        Me.llbl_WeaponSel.Location = New System.Drawing.Point(12, 349)
        Me.llbl_WeaponSel.Name = "llbl_WeaponSel"
        Me.llbl_WeaponSel.Size = New System.Drawing.Size(727, 37)
        Me.llbl_WeaponSel.TabIndex = 83
        Me.llbl_WeaponSel.TabStop = True
        Me.llbl_WeaponSel.Text = "Barracks"
        Me.llbl_WeaponSel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_WeaponSel.VisitedLinkColor = System.Drawing.Color.White
        '
        'llbl_CreateGame
        '
        Me.llbl_CreateGame.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_CreateGame.BackColor = System.Drawing.Color.Transparent
        Me.llbl_CreateGame.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_CreateGame.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_CreateGame.ForeColor = System.Drawing.Color.White
        Me.llbl_CreateGame.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_CreateGame.LinkColor = System.Drawing.Color.White
        Me.llbl_CreateGame.Location = New System.Drawing.Point(12, 181)
        Me.llbl_CreateGame.Name = "llbl_CreateGame"
        Me.llbl_CreateGame.Size = New System.Drawing.Size(727, 37)
        Me.llbl_CreateGame.TabIndex = 81
        Me.llbl_CreateGame.TabStop = True
        Me.llbl_CreateGame.Text = "Create Game"
        Me.llbl_CreateGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_CreateGame.VisitedLinkColor = System.Drawing.Color.White
        '
        'llbl_Store
        '
        Me.llbl_Store.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llbl_Store.BackColor = System.Drawing.Color.Transparent
        Me.llbl_Store.DisabledLinkColor = System.Drawing.Color.White
        Me.llbl_Store.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llbl_Store.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbl_Store.LinkColor = System.Drawing.Color.White
        Me.llbl_Store.Location = New System.Drawing.Point(12, 312)
        Me.llbl_Store.Name = "llbl_Store"
        Me.llbl_Store.Size = New System.Drawing.Size(727, 37)
        Me.llbl_Store.TabIndex = 90
        Me.llbl_Store.TabStop = True
        Me.llbl_Store.Text = "Store"
        Me.llbl_Store.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llbl_Store.VisitedLinkColor = System.Drawing.Color.White
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.CS_BTE_Launcher.My.Resources.Resources.cswd
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(2, -36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(748, 316)
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'llblUserProfile
        '
        Me.llblUserProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblUserProfile.BackColor = System.Drawing.Color.Transparent
        Me.llblUserProfile.DisabledLinkColor = System.Drawing.Color.White
        Me.llblUserProfile.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.llblUserProfile.ForeColor = System.Drawing.Color.White
        Me.llblUserProfile.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llblUserProfile.LinkColor = System.Drawing.Color.White
        Me.llblUserProfile.Location = New System.Drawing.Point(12, 406)
        Me.llblUserProfile.Name = "llblUserProfile"
        Me.llblUserProfile.Size = New System.Drawing.Size(727, 37)
        Me.llblUserProfile.TabIndex = 92
        Me.llblUserProfile.TabStop = True
        Me.llblUserProfile.Text = "User Profile"
        Me.llblUserProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.llblUserProfile.VisitedLinkColor = System.Drawing.Color.White
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(751, 629)
        Me.Controls.Add(Me.llblUserProfile)
        Me.Controls.Add(Me.llbl_Store)
        Me.Controls.Add(Me.llbl_StartNormal)
        Me.Controls.Add(Me.llbl_End)
        Me.Controls.Add(Me.llbl_JoinSvr)
        Me.Controls.Add(Me.llbl_Update)
        Me.Controls.Add(Me.llbl_Settings)
        Me.Controls.Add(Me.llbl_WeaponSel)
        Me.Controls.Add(Me.llbl_CreateGame)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMenu"
        Me.Opacity = 0.5R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.PaleGreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents llbl_StartNormal As System.Windows.Forms.LinkLabel
    Friend WithEvents llbl_End As System.Windows.Forms.LinkLabel
    Friend WithEvents llbl_JoinSvr As System.Windows.Forms.LinkLabel
    Friend WithEvents llbl_Update As System.Windows.Forms.LinkLabel
    Friend WithEvents llbl_Settings As System.Windows.Forms.LinkLabel
    Friend WithEvents llbl_WeaponSel As System.Windows.Forms.LinkLabel
    Friend WithEvents llbl_CreateGame As System.Windows.Forms.LinkLabel
    Friend WithEvents llbl_Store As System.Windows.Forms.LinkLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents llblUserProfile As System.Windows.Forms.LinkLabel
End Class
