Public Class frmMenu

    Private Sub llbl_End_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbl_End.LinkClicked
        Me.Hide()
        frmMsgbox.Show()
    End Sub

    Private Sub llbl_WeaponSel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbl_WeaponSel.LinkClicked
        frmLoading.Show()
        frmLoading.Timer1.Start()

        Me.Hide()
        frmBarracks.Show()
    End Sub

    Private Sub llbl_StartNormal_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbl_StartNormal.LinkClicked
        frmParent.player.Ctlcontrols.stop()
        frmParent.SendCommand("pause")

        Me.Hide()
        frmGamevb.Show()
        frmGamevb.processStart(My.Application.Info.DirectoryPath & "\cstrike.exe", "")
    End Sub

    Private Sub llbl_CreateGame_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbl_CreateGame.LinkClicked
        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub llbl_Settings_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbl_Settings.LinkClicked
        Me.Hide()
        frmOption.Show()
    End Sub

    Private Sub llbl_JoinSvr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbl_JoinSvr.LinkClicked
        Me.Hide()
        frmJoin.Show()
    End Sub
End Class