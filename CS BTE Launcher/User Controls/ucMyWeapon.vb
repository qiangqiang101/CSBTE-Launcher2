Public Class ucMyWeapon

    Private Sub ucWeapon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, PictureBox1.Click
        On Error Resume Next
        frmBarracks.BitdefenderGroupbox2.Show()
        frmBarracks.BitdefenderGroupbox2.Title = lbl_Name.Text
        frmBarracks.refreshCtrls()
        frmBarracks.pb_Damage.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", lbl_Use.Text.ToUpper, "Damage")
        frmBarracks.pb_HitRate.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", lbl_Use.Text.ToUpper, "HitRate")
        frmBarracks.pb_Reaction.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", lbl_Use.Text.ToUpper, "Reaction")
        frmBarracks.pb_FiringSpeed.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", lbl_Use.Text.ToUpper, "FiringSpeed")
        frmBarracks.pb_Weight.Width = ReadIniValue(My.Application.Info.DirectoryPath & "\metahook\weapons.ini", lbl_Use.Text.ToUpper, "Weight")
    End Sub

    Private Sub ucWeapon_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        frmBarracks.BitdefenderGroupbox2.Hide()
    End Sub

    Private Sub btn_Equip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Equip.Click
        Dim model As String = Me.lbl_Use.Text
        Dim name As String = Me.lbl_Name.Text

        If frmBarracks.fromWhere = "pri1e" Then
            frmBarracks.pri1m = model
            frmBarracks.lbl_PriWpn1.Text = name
            frmBarracks.pb_PriWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.pri1m & ".png")
            frmBarracks.wpnList11.Controls.Clear()
            frmBarracks.readSelectedPrimary()
        ElseIf frmBarracks.fromWhere = "pri2e" Then
            frmBarracks.pri2m = model
            frmBarracks.lbl_PriWpn2.Text = name
            frmBarracks.pb_PriWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.pri2m & ".png")
            frmBarracks.wpnList11.Controls.Clear()
            frmBarracks.readSelectedPrimary()
        ElseIf frmBarracks.fromWhere = "pri3e" Then
            frmBarracks.pri3m = model
            frmBarracks.lbl_PriWpn3.Text = name
            frmBarracks.pb_PriWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.pri3m & ".png")
            frmBarracks.wpnList11.Controls.Clear()
            frmBarracks.readSelectedPrimary()
        ElseIf frmBarracks.fromWhere = "sec1e" Then
            frmBarracks.sec1m = model
            frmBarracks.lbl_SecWpn1.Text = name
            frmBarracks.pb_SecWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.sec1m & ".png")
            frmBarracks.wpnList12.Controls.Clear()
            frmBarracks.readSelectedSecondary()
        ElseIf frmBarracks.fromWhere = "sec2e" Then
            frmBarracks.sec2m = model
            frmBarracks.lbl_SecWpn2.Text = name
            frmBarracks.pb_SecWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.sec2m & ".png")
            frmBarracks.wpnList12.Controls.Clear()
            frmBarracks.readSelectedSecondary()
        ElseIf frmBarracks.fromWhere = "sec3e" Then
            frmBarracks.sec3m = model
            frmBarracks.lbl_SecWpn3.Text = name
            frmBarracks.pb_SecWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.sec3m & ".png")
            frmBarracks.wpnList12.Controls.Clear()
            frmBarracks.readSelectedSecondary()
        ElseIf frmBarracks.fromWhere = "mel1e" Then
            frmBarracks.mel1m = model
            frmBarracks.lbl_MelWpn1.Text = name
            frmBarracks.pb_MelWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.mel1m & ".png")
            frmBarracks.wpnList13.Controls.Clear()
            frmBarracks.readSelectedMelee()
        ElseIf frmBarracks.fromWhere = "mel2e" Then
            frmBarracks.mel2m = model
            frmBarracks.lbl_MelWpn2.Text = name
            frmBarracks.pb_MelWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.mel2m & ".png")
            frmBarracks.wpnList13.Controls.Clear()
            frmBarracks.readSelectedMelee()
        ElseIf frmBarracks.fromWhere = "mel3e" Then
            frmBarracks.mel3m = model
            frmBarracks.lbl_MelWpn3.Text = name
            frmBarracks.pb_MelWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.mel3m & ".png")
            frmBarracks.wpnList13.Controls.Clear()
            frmBarracks.readSelectedMelee()
        ElseIf frmBarracks.fromWhere = "gre1e" Then
            frmBarracks.gre1m = model
            frmBarracks.lbl_GreWpn1.Text = name
            frmBarracks.pb_GreWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.gre1m & ".png")
            frmBarracks.wpnList14.Controls.Clear()
            frmBarracks.readSelectedGrenade()
        ElseIf frmBarracks.fromWhere = "gre2e" Then
            frmBarracks.gre2m = model
            frmBarracks.lbl_GreWpn2.Text = name
            frmBarracks.pb_GreWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.gre2m & ".png")
            frmBarracks.wpnList14.Controls.Clear()
            frmBarracks.readSelectedGrenade()
        ElseIf frmBarracks.fromWhere = "gre3e" Then
            frmBarracks.gre3m = model
            frmBarracks.lbl_GreWpn3.Text = name
            frmBarracks.pb_GreWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.gre3m & ".png")
            frmBarracks.wpnList14.Controls.Clear()
            frmBarracks.readSelectedGrenade()


        ElseIf frmBarracks.fromWhere = "pri11e" Then
            frmBarracks.pri11m = model
            frmBarracks.lbl_PriWpn11.Text = name
            frmBarracks.pb_PriWpn11.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.pri11m & ".png")
            frmBarracks.wpnList11.Controls.Clear()
            frmBarracks.readSelectedPrimary()
        ElseIf frmBarracks.fromWhere = "pri12e" Then
            frmBarracks.pri12m = model
            frmBarracks.lbl_PriWpn12.Text = name
            frmBarracks.pb_PriWpn12.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.pri12m & ".png")
            frmBarracks.wpnList11.Controls.Clear()
            frmBarracks.readSelectedPrimary()
        ElseIf frmBarracks.fromWhere = "pri13e" Then
            frmBarracks.pri13m = model
            frmBarracks.lbl_PriWpn13.Text = name
            frmBarracks.pb_PriWpn13.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.pri13m & ".png")
            frmBarracks.wpnList11.Controls.Clear()
            frmBarracks.readSelectedPrimary()
        ElseIf frmBarracks.fromWhere = "pri14e" Then
            frmBarracks.pri14m = model
            frmBarracks.lbl_PriWpn14.Text = name
            frmBarracks.pb_PriWpn14.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.pri14m & ".png")
            frmBarracks.wpnList11.Controls.Clear()
            frmBarracks.readSelectedPrimary()
        ElseIf frmBarracks.fromWhere = "pri15e" Then
            frmBarracks.pri15m = model
            frmBarracks.lbl_PriWpn15.Text = name
            frmBarracks.pb_PriWpn15.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.pri15m & ".png")
            frmBarracks.wpnList11.Controls.Clear()
            frmBarracks.readSelectedPrimary()
        ElseIf frmBarracks.fromWhere = "sec11e" Then
            frmBarracks.sec11m = model
            frmBarracks.lbl_SecWpn11.Text = name
            frmBarracks.pb_SecWpn11.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.sec11m & ".png")
            frmBarracks.wpnList12.Controls.Clear()
            frmBarracks.readSelectedSecondary()
        ElseIf frmBarracks.fromWhere = "sec12e" Then
            frmBarracks.sec12m = model
            frmBarracks.lbl_SecWpn12.Text = name
            frmBarracks.pb_SecWpn12.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.sec12m & ".png")
            frmBarracks.wpnList12.Controls.Clear()
            frmBarracks.readSelectedSecondary()
        ElseIf frmBarracks.fromWhere = "sec13e" Then
            frmBarracks.sec13m = model
            frmBarracks.lbl_SecWpn13.Text = name
            frmBarracks.pb_SecWpn13.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.sec13m & ".png")
            frmBarracks.wpnList12.Controls.Clear()
            frmBarracks.readSelectedSecondary()
        ElseIf frmBarracks.fromWhere = "sec14e" Then
            frmBarracks.sec14m = model
            frmBarracks.lbl_SecWpn14.Text = name
            frmBarracks.pb_SecWpn14.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.sec14m & ".png")
            frmBarracks.wpnList12.Controls.Clear()
            frmBarracks.readSelectedSecondary()
        ElseIf frmBarracks.fromWhere = "sec15e" Then
            frmBarracks.sec15m = model
            frmBarracks.lbl_SecWpn15.Text = name
            frmBarracks.pb_SecWpn15.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.sec15m & ".png")
            frmBarracks.wpnList12.Controls.Clear()
            frmBarracks.readSelectedSecondary()
        ElseIf frmBarracks.fromWhere = "mel11e" Then
            frmBarracks.mel11m = model
            frmBarracks.lbl_MelWpn11.Text = name
            frmBarracks.pb_MelWpn11.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.mel11m & ".png")
            frmBarracks.wpnList13.Controls.Clear()
            frmBarracks.readSelectedMelee()
        ElseIf frmBarracks.fromWhere = "mel12e" Then
            frmBarracks.mel12m = model
            frmBarracks.lbl_MelWpn12.Text = name
            frmBarracks.pb_MelWpn12.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.mel12m & ".png")
            frmBarracks.wpnList13.Controls.Clear()
            frmBarracks.readSelectedMelee()
        ElseIf frmBarracks.fromWhere = "mel13e" Then
            frmBarracks.mel13m = model
            frmBarracks.lbl_MelWpn13.Text = name
            frmBarracks.pb_MelWpn13.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.mel13m & ".png")
            frmBarracks.wpnList13.Controls.Clear()
            frmBarracks.readSelectedMelee()
        ElseIf frmBarracks.fromWhere = "mel14e" Then
            frmBarracks.mel14m = model
            frmBarracks.lbl_MelWpn14.Text = name
            frmBarracks.pb_MelWpn14.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.mel14m & ".png")
            frmBarracks.wpnList13.Controls.Clear()
            frmBarracks.readSelectedMelee()
        ElseIf frmBarracks.fromWhere = "mel15e" Then
            frmBarracks.mel15m = model
            frmBarracks.lbl_MelWpn15.Text = name
            frmBarracks.pb_MelWpn15.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.mel15m & ".png")
            frmBarracks.wpnList13.Controls.Clear()
            frmBarracks.readSelectedMelee()
        ElseIf frmBarracks.fromWhere = "gre11e" Then
            frmBarracks.gre11m = model
            frmBarracks.lbl_GreWpn11.Text = name
            frmBarracks.pb_GreWpn11.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.gre11m & ".png")
            frmBarracks.wpnList14.Controls.Clear()
            frmBarracks.readSelectedGrenade()
        ElseIf frmBarracks.fromWhere = "gre12e" Then
            frmBarracks.gre12m = model
            frmBarracks.lbl_GreWpn12.Text = name
            frmBarracks.pb_GreWpn12.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.gre12m & ".png")
            frmBarracks.wpnList14.Controls.Clear()
            frmBarracks.readSelectedGrenade()
        ElseIf frmBarracks.fromWhere = "gre13e" Then
            frmBarracks.gre13m = model
            frmBarracks.lbl_GreWpn13.Text = name
            frmBarracks.pb_GreWpn13.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.gre13m & ".png")
            frmBarracks.wpnList14.Controls.Clear()
            frmBarracks.readSelectedGrenade()
        ElseIf frmBarracks.fromWhere = "gre14e" Then
            frmBarracks.gre14m = model
            frmBarracks.lbl_GreWpn14.Text = name
            frmBarracks.pb_GreWpn14.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.gre14m & ".png")
            frmBarracks.wpnList14.Controls.Clear()
            frmBarracks.readSelectedGrenade()
        ElseIf frmBarracks.fromWhere = "gre15e" Then
            frmBarracks.gre15m = model
            frmBarracks.lbl_GreWpn15.Text = name
            frmBarracks.pb_GreWpn15.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & frmBarracks.gre15m & ".png")
            frmBarracks.wpnList14.Controls.Clear()
            frmBarracks.readSelectedGrenade()
        End If
    End Sub
End Class
