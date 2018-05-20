Public Class ucClass

    Public team As String
    Public sex As String
    Public hand As String
    Public radio As String
    Public tattoo As String
    Public emotion As String

    Private Sub btn_Equip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Equip.Click
        Dim model As String = Me.lbl_Use.Text
        Dim name As String = Me.lbl_Name.Text

        If frmBarracks.SuperTabControl1.SelectedTab Is frmBarracks.SuperTabItem9 Then
            If frmBarracks.selModel.Contains(model & ",") Then
                Exit Sub
            Else
                frmBarracks.txt_SelName.Text = frmBarracks.txt_SelName.Text + name & ", "
                frmBarracks.selModel = frmBarracks.selModel + model & ","
                frmBarracks.lbl_SelWpn.Text = frmBarracks.lbl_SelWpn.Text + 1

                Dim i As ListViewItem = frmBarracks.lv_MyPlayer.Items.Add(name)
                i.SubItems.Add(model)
                i.SubItems.Add(team)
                i.SubItems.Add(sex)
                i.SubItems.Add(hand)
                i.SubItems.Add(radio)
                i.SubItems.Add(tattoo)
                i.SubItems.Add(emotion)
            End If
        End If
    End Sub
End Class
