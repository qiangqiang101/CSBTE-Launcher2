Public Class frmPause

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer

    Private Sub llbl_Resume_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbl_Resume.LinkClicked
        frmGamevb.Enabled = True
        Me.Hide()
    End Sub

    Private Sub llbl_DC_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbl_DC.LinkClicked
        Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("cstrike")

        For Each p As Process In pProcess
            p.Kill()
        Next

        frmMenu.Show()

        frmParent.player.Ctlcontrols.play()
        frmParent.SendCommand("play")

        frmGamevb.Close()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim esc As Boolean = GetAsyncKeyState(Keys.P)
        If esc = True Then
            frmGamevb.Enabled = True
            Me.Hide()
        End If
    End Sub
End Class