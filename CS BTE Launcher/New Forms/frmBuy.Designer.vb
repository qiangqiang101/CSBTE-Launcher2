<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuy
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
        Me.BitdefenderForm1 = New CS_BTE_Launcher.BitdefenderForm()
        Me.btnCancel = New CS_BTE_Launcher.BitdefenderButton()
        Me.btnBuy = New CS_BTE_Launcher.BitdefenderButton()
        Me.lblPoint3 = New System.Windows.Forms.Label()
        Me.lblPoint2 = New System.Windows.Forms.Label()
        Me.lblPoint1 = New System.Windows.Forms.Label()
        Me.lblMyPointsAfterPur = New System.Windows.Forms.Label()
        Me.lblMyPoints = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblAfterPur = New System.Windows.Forms.Label()
        Me.lblCurrent = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pb_Weight = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pb_FiringSpeed = New System.Windows.Forms.PictureBox()
        Me.pb_Damage = New System.Windows.Forms.PictureBox()
        Me.pb_Reaction = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pb_HitRate = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BitdefenderForm1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Weight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_FiringSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Damage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Reaction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_HitRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BitdefenderForm1
        '
        Me.BitdefenderForm1.BackColor = System.Drawing.Color.Fuchsia
        Me.BitdefenderForm1.Controls.Add(Me.btnCancel)
        Me.BitdefenderForm1.Controls.Add(Me.btnBuy)
        Me.BitdefenderForm1.Controls.Add(Me.lblPoint3)
        Me.BitdefenderForm1.Controls.Add(Me.lblPoint2)
        Me.BitdefenderForm1.Controls.Add(Me.lblPoint1)
        Me.BitdefenderForm1.Controls.Add(Me.lblMyPointsAfterPur)
        Me.BitdefenderForm1.Controls.Add(Me.lblMyPoints)
        Me.BitdefenderForm1.Controls.Add(Me.lblPrice)
        Me.BitdefenderForm1.Controls.Add(Me.lblAfterPur)
        Me.BitdefenderForm1.Controls.Add(Me.lblCurrent)
        Me.BitdefenderForm1.Controls.Add(Me.Label1)
        Me.BitdefenderForm1.Controls.Add(Me.lblName)
        Me.BitdefenderForm1.Controls.Add(Me.PictureBox2)
        Me.BitdefenderForm1.Controls.Add(Me.pb_Weight)
        Me.BitdefenderForm1.Controls.Add(Me.PictureBox1)
        Me.BitdefenderForm1.Controls.Add(Me.pb_FiringSpeed)
        Me.BitdefenderForm1.Controls.Add(Me.pb_Damage)
        Me.BitdefenderForm1.Controls.Add(Me.pb_Reaction)
        Me.BitdefenderForm1.Controls.Add(Me.Label5)
        Me.BitdefenderForm1.Controls.Add(Me.pb_HitRate)
        Me.BitdefenderForm1.Controls.Add(Me.Label6)
        Me.BitdefenderForm1.Controls.Add(Me.Label7)
        Me.BitdefenderForm1.Controls.Add(Me.Label9)
        Me.BitdefenderForm1.Controls.Add(Me.Label8)
        Me.BitdefenderForm1.DisableControlboxClose = True
        Me.BitdefenderForm1.DisableControlboxMax = True
        Me.BitdefenderForm1.DisableControlboxMin = True
        Me.BitdefenderForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BitdefenderForm1.Location = New System.Drawing.Point(0, 0)
        Me.BitdefenderForm1.Name = "BitdefenderForm1"
        Me.BitdefenderForm1.Size = New System.Drawing.Size(515, 246)
        Me.BitdefenderForm1.TabIndex = 0
        Me.BitdefenderForm1.Text = "Decide to buy"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(371, 182)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 40)
        Me.btnCancel.TabIndex = 106
        Me.btnCancel.Text = "Cancel"
        '
        'btnBuy
        '
        Me.btnBuy.BackColor = System.Drawing.Color.Transparent
        Me.btnBuy.Location = New System.Drawing.Point(247, 182)
        Me.btnBuy.Name = "btnBuy"
        Me.btnBuy.Size = New System.Drawing.Size(118, 40)
        Me.btnBuy.TabIndex = 105
        Me.btnBuy.Text = "Buy"
        '
        'lblPoint3
        '
        Me.lblPoint3.AutoSize = True
        Me.lblPoint3.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblPoint3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPoint3.ForeColor = System.Drawing.Color.White
        Me.lblPoint3.Location = New System.Drawing.Point(447, 161)
        Me.lblPoint3.Name = "lblPoint3"
        Me.lblPoint3.Size = New System.Drawing.Size(41, 15)
        Me.lblPoint3.TabIndex = 104
        Me.lblPoint3.Text = "Points"
        '
        'lblPoint2
        '
        Me.lblPoint2.AutoSize = True
        Me.lblPoint2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblPoint2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPoint2.ForeColor = System.Drawing.Color.White
        Me.lblPoint2.Location = New System.Drawing.Point(447, 146)
        Me.lblPoint2.Name = "lblPoint2"
        Me.lblPoint2.Size = New System.Drawing.Size(41, 15)
        Me.lblPoint2.TabIndex = 103
        Me.lblPoint2.Text = "Points"
        '
        'lblPoint1
        '
        Me.lblPoint1.AutoSize = True
        Me.lblPoint1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblPoint1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPoint1.ForeColor = System.Drawing.Color.White
        Me.lblPoint1.Location = New System.Drawing.Point(447, 131)
        Me.lblPoint1.Name = "lblPoint1"
        Me.lblPoint1.Size = New System.Drawing.Size(41, 15)
        Me.lblPoint1.TabIndex = 102
        Me.lblPoint1.Text = "Points"
        '
        'lblMyPointsAfterPur
        '
        Me.lblMyPointsAfterPur.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblMyPointsAfterPur.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMyPointsAfterPur.ForeColor = System.Drawing.Color.White
        Me.lblMyPointsAfterPur.Location = New System.Drawing.Point(382, 161)
        Me.lblMyPointsAfterPur.Name = "lblMyPointsAfterPur"
        Me.lblMyPointsAfterPur.Size = New System.Drawing.Size(59, 15)
        Me.lblMyPointsAfterPur.TabIndex = 101
        Me.lblMyPointsAfterPur.Text = "0000"
        Me.lblMyPointsAfterPur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMyPoints
        '
        Me.lblMyPoints.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblMyPoints.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMyPoints.ForeColor = System.Drawing.Color.White
        Me.lblMyPoints.Location = New System.Drawing.Point(382, 146)
        Me.lblMyPoints.Name = "lblMyPoints"
        Me.lblMyPoints.Size = New System.Drawing.Size(59, 15)
        Me.lblMyPoints.TabIndex = 100
        Me.lblMyPoints.Text = "0000"
        Me.lblMyPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPrice
        '
        Me.lblPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblPrice.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrice.ForeColor = System.Drawing.Color.White
        Me.lblPrice.Location = New System.Drawing.Point(382, 131)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(59, 15)
        Me.lblPrice.TabIndex = 99
        Me.lblPrice.Text = "0000"
        Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAfterPur
        '
        Me.lblAfterPur.AutoSize = True
        Me.lblAfterPur.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblAfterPur.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAfterPur.ForeColor = System.Drawing.Color.White
        Me.lblAfterPur.Location = New System.Drawing.Point(251, 161)
        Me.lblAfterPur.Name = "lblAfterPur"
        Me.lblAfterPur.Size = New System.Drawing.Size(125, 15)
        Me.lblAfterPur.TabIndex = 98
        Me.lblAfterPur.Text = "Points after purchase"
        '
        'lblCurrent
        '
        Me.lblCurrent.AutoSize = True
        Me.lblCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblCurrent.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrent.ForeColor = System.Drawing.Color.White
        Me.lblCurrent.Location = New System.Drawing.Point(251, 146)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(87, 15)
        Me.lblCurrent.TabIndex = 97
        Me.lblCurrent.Text = "Current points"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(251, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Item price"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(260, 77)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(69, 15)
        Me.lblName.TabIndex = 95
        Me.lblName.Text = "Wpn Name"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Image = Global.CS_BTE_Launcher.My.Resources.Resources.textbox
        Me.PictureBox2.Location = New System.Drawing.Point(254, 70)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(190, 28)
        Me.PictureBox2.TabIndex = 94
        Me.PictureBox2.TabStop = False
        '
        'pb_Weight
        '
        Me.pb_Weight.BackColor = System.Drawing.Color.Aqua
        Me.pb_Weight.Location = New System.Drawing.Point(124, 199)
        Me.pb_Weight.Name = "pb_Weight"
        Me.pb_Weight.Size = New System.Drawing.Size(108, 11)
        Me.pb_Weight.TabIndex = 93
        Me.pb_Weight.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(27, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(218, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'pb_FiringSpeed
        '
        Me.pb_FiringSpeed.BackColor = System.Drawing.Color.Aqua
        Me.pb_FiringSpeed.Location = New System.Drawing.Point(124, 182)
        Me.pb_FiringSpeed.Name = "pb_FiringSpeed"
        Me.pb_FiringSpeed.Size = New System.Drawing.Size(108, 11)
        Me.pb_FiringSpeed.TabIndex = 92
        Me.pb_FiringSpeed.TabStop = False
        '
        'pb_Damage
        '
        Me.pb_Damage.BackColor = System.Drawing.Color.Aqua
        Me.pb_Damage.Location = New System.Drawing.Point(124, 131)
        Me.pb_Damage.Name = "pb_Damage"
        Me.pb_Damage.Size = New System.Drawing.Size(108, 11)
        Me.pb_Damage.TabIndex = 89
        Me.pb_Damage.TabStop = False
        '
        'pb_Reaction
        '
        Me.pb_Reaction.BackColor = System.Drawing.Color.Aqua
        Me.pb_Reaction.Location = New System.Drawing.Point(124, 165)
        Me.pb_Reaction.Name = "pb_Reaction"
        Me.pb_Reaction.Size = New System.Drawing.Size(108, 11)
        Me.pb_Reaction.TabIndex = 91
        Me.pb_Reaction.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(61, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Damage:"
        '
        'pb_HitRate
        '
        Me.pb_HitRate.BackColor = System.Drawing.Color.Aqua
        Me.pb_HitRate.Location = New System.Drawing.Point(124, 148)
        Me.pb_HitRate.Name = "pb_HitRate"
        Me.pb_HitRate.Size = New System.Drawing.Size(108, 11)
        Me.pb_HitRate.TabIndex = 90
        Me.pb_HitRate.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(61, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Hit Rate:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(61, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 15)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Recoil:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(61, 195)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 15)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Weight:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(61, 178)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 15)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Fire Rate:"
        '
        'frmBuy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 246)
        Me.Controls.Add(Me.BitdefenderForm1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBuy"
        Me.Opacity = 0.9R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Decide to Buy"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.BitdefenderForm1.ResumeLayout(False)
        Me.BitdefenderForm1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Weight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_FiringSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Damage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Reaction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_HitRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BitdefenderForm1 As CS_BTE_Launcher.BitdefenderForm
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_Weight As System.Windows.Forms.PictureBox
    Friend WithEvents pb_FiringSpeed As System.Windows.Forms.PictureBox
    Friend WithEvents pb_Damage As System.Windows.Forms.PictureBox
    Friend WithEvents pb_Reaction As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pb_HitRate As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblPoint3 As System.Windows.Forms.Label
    Friend WithEvents lblPoint2 As System.Windows.Forms.Label
    Friend WithEvents lblPoint1 As System.Windows.Forms.Label
    Friend WithEvents lblMyPointsAfterPur As System.Windows.Forms.Label
    Friend WithEvents lblMyPoints As System.Windows.Forms.Label
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents lblAfterPur As System.Windows.Forms.Label
    Friend WithEvents lblCurrent As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As CS_BTE_Launcher.BitdefenderButton
    Friend WithEvents btnBuy As CS_BTE_Launcher.BitdefenderButton
End Class
