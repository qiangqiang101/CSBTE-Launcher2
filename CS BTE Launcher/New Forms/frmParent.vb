Imports System.Runtime.InteropServices

Public Class frmParent

    Dim args, file, time_length As String
    Dim str As Long
    Dim ps As Process = Nothing
    Dim vocal As Integer = 1

    'Show Hide Taskbar
    <DllImport("user32.dll")>
    Private Shared Function FindWindow(ByVal className As String, ByVal windowText As String) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal command As Integer) As Boolean
    End Function
    Private Const SW_HIDE As Integer = 0
    Private Const SW_SHOW As Integer = 1

    Public Function HideStartButton() As Boolean
        Dim retval = False
        HideTaskBar()
        Dim hwndStartButton = FindWindow("Button", "Start")
        If hwndStartButton <> IntPtr.Zero Then
            retval = ShowWindow(hwndStartButton, SW_HIDE)
        End If
        Return retval
    End Function
    Public Function HideTaskBar() As Boolean
        Dim retval = False
        Dim hwndTaskBar = FindWindow("Shell_TrayWnd", "")
        If hwndTaskBar <> IntPtr.Zero Then
            retval = ShowWindow(hwndTaskBar, SW_HIDE)
        End If
        Return retval
    End Function
    Public Function ShowStartButton() As Boolean
        Dim retval1 = False
        ShowHideTaskBar()
        Dim hwndstartbutton = FindWindow("Button", "Start")
        If hwndstartbutton <> IntPtr.Zero Then
            retval1 = ShowWindow(hwndstartbutton, SW_SHOW)
        End If
        Return retval1
    End Function
    Public Function ShowHideTaskBar() As Boolean
        Dim retval2 = False
        Dim hwndTaskBar = FindWindow("Shell_TrayWnd", "")
        If hwndTaskBar <> IntPtr.Zero Then
            retval2 = ShowWindow(hwndTaskBar, SW_SHOW)
        End If
        Return retval2
    End Function

    Private Sub frmParent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ps.Kill()
            ShowHideTaskBar()
            ShowStartButton()
        Catch
        End Try
    End Sub

    Private Sub frmParent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HideTaskBar()
        HideStartButton()
        frmLoading.Show()

        If My.Settings.BGM = "On" Then
            Try
                player.URL = My.Application.Info.DirectoryPath & "\launcher\sound\gamestartup.mp3"
                'player.Ctlcontrols.stop
                player.settings.setMode("loop", True)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            End Try
        End If

        Dim ctl As Control
        Dim ctlMDI As MdiClient

        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                ctlMDI.BackColor = Me.BackColor

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next

        ' To initialize process :-
        ps = New Process()
        ps.StartInfo.ErrorDialog = False
        ps.StartInfo.UseShellExecute = False
        ps.StartInfo.RedirectStandardInput = True
        ps.StartInfo.RedirectStandardOutput = True
        ps.StartInfo.FileName = "launcher\sys\mplayer.exe"
        ps.StartInfo.CreateNoWindow = True
        playIntro()

        'frmMenu.Show()
    End Sub

    Private Sub playIntro()
        time_length = ""
        str = 1
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        'btnPlay.Text = "Pause"
        'btnPlay.Enabled = True
        'tbVolume.Enabled = True
        'tbVolume.Enabled = True
        Try
            ps.Kill()
        Catch
        End Try
        file = My.Application.Info.DirectoryPath & "\launcher\movies\csbte.m4v"
        args = "-nofs -noquiet -identify -slave -volume 0 -loop 0 -nomouseinput -sub-fuzziness 1 -vo direct3d, -ao dsound -osdlevel 0 -wid " & CInt(Me.Handle.ToInt32)
        ps.StartInfo.Arguments = args & " """ & file & """"
        ps.Start()
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
    End Sub

    Public Sub SendCommand(ByVal cmd As String)
        Try
            If ps IsNot Nothing AndAlso ps.HasExited = False Then
                ps.StandardInput.Write(cmd & vbLf)
            End If
        Catch
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            ps.StandardOutput.ReadLine()
        Catch
        End Try
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If str = 1 Then
            SendCommand("get_time_length")
        Else
            SendCommand("get_time_pos")
        End If
        'SendCommand("switch_audio " & tbVocal.Value)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Hide()
        frmMsgbox.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        frmMenu.Show()
    End Sub

    Private Sub TaskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskToolStripMenuItem.Click
        ShowHideTaskBar()
        ShowStartButton()
    End Sub
End Class