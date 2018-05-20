Public Class frmBuy

    Public model As String
    Public myName As ucBuyWeapon
    Private bteSave As String = My.Application.Info.DirectoryPath & "\launcher\vault\bte_save.ini"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Sub refreshCtrls()
        pb_Damage.Width = 0
        pb_HitRate.Width = 0
        pb_Reaction.Width = 0
        pb_FiringSpeed.Width = 0
        pb_Weight.Width = 0
    End Sub

    Private Sub btnBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuy.Click
        If frmStore.SuperTabControl1.SelectedTab Is frmStore.SuperTabItem1 Then
            myName.buy = "1"
            Dim priShop As String = My.Application.Info.DirectoryPath & "\launcher\vault\pri_wpn.ini"
            Dim SW As New System.IO.StreamWriter(priShop)
            For Each priShopItem As ucBuyWeapon In frmStore.wpnList1.Controls
                SW.Write("[name]" & priShopItem.lbl_Name.Text & "[model]" & priShopItem.model & "[point]" & priShopItem.point & _
                         "[cash]" & priShopItem.cash & "[buy]" & priShopItem.buy & Environment.NewLine)
            Next
            SW.Close()
            WriteCfgValue("points", lblMyPointsAfterPur.Text, bteSave)
            frmStore.wpnList1.Controls.Clear()
            frmStore.readPrimary()
            frmStore.txtPoint.Text = ReadCfgValue("points", bteSave)
            frmStore.txtCash.Text = ReadCfgValue("cash", bteSave)
        End If
    End Sub
End Class