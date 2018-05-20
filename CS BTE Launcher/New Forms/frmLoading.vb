Public Class frmLoading

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        CircularProgress1.Value += 1
        If CircularProgress1.Value = 100 Then
            Timer1.Stop()
            CircularProgress1.Value = 0
            Me.Hide()
        End If
    End Sub

    Private Sub frmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width - 300
        y = Screen.PrimaryScreen.WorkingArea.Height - 100
        Me.Location = New Point(x, y)
    End Sub
End Class