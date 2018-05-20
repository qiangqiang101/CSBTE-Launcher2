Public Class ucWeapon

    Private Sub btn_Equip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Equip.Click
        Dim model As String = Me.lbl_Use.Text
        Dim name As String = Me.lbl_Name.Text

        If frmBarracks.SuperTabControl1.SelectedTab Is frmBarracks.SuperTabItem1 Then
            If frmBarracks.selModel.Contains(model & ",") Then
                Exit Sub
            Else
                frmBarracks.txt_SelName.Text = frmBarracks.txt_SelName.Text + name & ", "
                frmBarracks.selModel = frmBarracks.selModel + model & ","
                frmBarracks.lbl_SelWpn.Text = frmBarracks.lbl_SelWpn.Text + 1

                Dim i As ListViewItem = frmBarracks.lv_SelPrimary.Items.Add(name)
                i.SubItems.Add(model)

                If frmBarracks.lbl_SelWpn.Text > 29 Then
                    frmBarracks.lbl_SelWpn.ForeColor = Color.Red
                Else
                    frmBarracks.lbl_SelWpn.ForeColor = Color.White
                End If
            End If
        ElseIf frmBarracks.SuperTabControl1.SelectedTab Is frmBarracks.SuperTabItem2 Then
            If frmBarracks.selModel.Contains(model & ",") Then
                Exit Sub
            Else
                frmBarracks.txt_SelName.Text = frmBarracks.txt_SelName.Text + name & ", "
                frmBarracks.selModel = frmBarracks.selModel + model & ","
                frmBarracks.lbl_SelWpn.Text = frmBarracks.lbl_SelWpn.Text + 1

                Dim i As ListViewItem = frmBarracks.lv_SelSecondary.Items.Add(name)
                i.SubItems.Add(model)

                If frmBarracks.lbl_SelWpn.Text > 9 Then
                    frmBarracks.lbl_SelWpn.ForeColor = Color.Red
                Else
                    frmBarracks.lbl_SelWpn.ForeColor = Color.White
                End If
            End If
        ElseIf frmBarracks.SuperTabControl1.SelectedTab Is frmBarracks.SuperTabItem3 Then
            If frmBarracks.selModel.Contains(model & ",") Then
                Exit Sub
            Else
                frmBarracks.txt_SelName.Text = frmBarracks.txt_SelName.Text + name & ", "
                frmBarracks.selModel = frmBarracks.selModel + model & ","
                frmBarracks.lbl_SelWpn.Text = frmBarracks.lbl_SelWpn.Text + 1

                Dim i As ListViewItem = frmBarracks.lv_SelMelee.Items.Add(name)
                i.SubItems.Add(model)

                If frmBarracks.lbl_SelWpn.Text > 4 Then
                    frmBarracks.lbl_SelWpn.ForeColor = Color.Red
                Else
                    frmBarracks.lbl_SelWpn.ForeColor = Color.White
                End If
            End If
        ElseIf frmBarracks.SuperTabControl1.SelectedTab Is frmBarracks.SuperTabItem4 Then
            If frmBarracks.selModel.Contains(model & ",") Then
                Exit Sub
            Else
                frmBarracks.txt_SelName.Text = frmBarracks.txt_SelName.Text + name & ", "
                frmBarracks.selModel = frmBarracks.selModel + model & ","
                frmBarracks.lbl_SelWpn.Text = frmBarracks.lbl_SelWpn.Text + 1

                Dim i As ListViewItem = frmBarracks.lv_SelGrenades.Items.Add(name)
                i.SubItems.Add(model)

                If frmBarracks.lbl_SelWpn.Text > 4 Then
                    frmBarracks.lbl_SelWpn.ForeColor = Color.Red
                Else
                    frmBarracks.lbl_SelWpn.ForeColor = Color.White
                End If
            End If
        End If
    End Sub

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
End Class
