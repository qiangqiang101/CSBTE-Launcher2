Public Class ucBuyWeapon

    Public point As String
    Public cash As String
    Public model As String
    Public buy As String

    Private Sub btn_Equip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Equip.Click
        frmBuy.Show()
        frmBuy.myName.Name = Me.Name
        If lbl_Use.Text.Contains("Point") Then
            frmBuy.lblPoint1.Text = "Points"
            frmBuy.lblPoint2.Text = "Points"
            frmBuy.lblPoint3.Text = "Points"
            frmBuy.lblCurrent.Text = "Current Points"
            frmBuy.lblAfterPur.Text = "Points after purchase"
            frmBuy.lblName.Text = lbl_Name.Text
            frmBuy.model = model
            frmBuy.lblPrice.Text = point
            frmBuy.lblMyPoints.Text = frmStore.txtPoint.Text
            frmBuy.lblMyPointsAfterPur.Text = frmStore.txtPoint.Text - point
            frmBuy.PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & model & ".png")
            On Error Resume Next
            frmBuy.refreshCtrls()
            frmBuy.pb_Damage.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Damage")
            frmBuy.pb_HitRate.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "HitRate")
            frmBuy.pb_Reaction.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Reaction")
            frmBuy.pb_FiringSpeed.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "FiringSpeed")
            frmBuy.pb_Weight.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Weight")
            'frmStore.lbl_Points.Text = frmStore.lbl_Cash.Text - point
        ElseIf lbl_Use.Text.Contains("Cash") Then
            frmBuy.lblPoint1.Text = "Cash"
            frmBuy.lblPoint2.Text = "Cash"
            frmBuy.lblPoint3.Text = "Cash"
            frmBuy.lblCurrent.Text = "Current Cash"
            frmBuy.lblAfterPur.Text = "Cash after purchase"
            frmBuy.lblName.Text = lbl_Name.Text
            frmBuy.model = model
            frmBuy.lblPrice.Text = cash
            frmBuy.lblMyPoints.Text = frmStore.txtCash.Text
            frmBuy.lblMyPointsAfterPur.Text = frmStore.txtCash.Text - cash
            frmBuy.PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & model & ".png")
            On Error Resume Next
            frmBuy.refreshCtrls()
            frmBuy.pb_Damage.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Damage")
            frmBuy.pb_HitRate.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "HitRate")
            frmBuy.pb_Reaction.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Reaction")
            frmBuy.pb_FiringSpeed.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "FiringSpeed")
            frmBuy.pb_Weight.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Weight")
            'frmStore.lbl_Cash.Text = frmStore.lbl_Cash.Text - cash
        End If
    End Sub

    Private Sub ucWeapon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, PictureBox1.Click
        On Error Resume Next
        frmStore.BitdefenderGroupbox2.Show()
        frmStore.BitdefenderGroupbox2.Title = lbl_Name.Text
        frmStore.refreshCtrls()
        frmStore.pb_Damage.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Damage")
        frmStore.pb_HitRate.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "HitRate")
        frmStore.pb_Reaction.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Reaction")
        frmStore.pb_FiringSpeed.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "FiringSpeed")
        frmStore.pb_Weight.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", model.ToUpper, "Weight")
    End Sub

    Private Sub ucWeapon_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        frmStore.BitdefenderGroupbox2.Hide()
    End Sub
End Class
