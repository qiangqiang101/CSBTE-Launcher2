'Imports System
'Imports System.Runtime.InteropServices
'Imports CS_BTE_Launcher.WinApi
Imports Microsoft.Win32

Public Class frmGamevb

    Private Const WM_SYSCOMMAND As Integer = 274
    Private Const SC_MAXIMIZE As Integer = 61488
    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Declare Auto Function SendMessage2 Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer


    Private Sub frmGamevb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chgScrnReso()
    End Sub

    Public Sub processStart(ByVal filename As String, ByVal arg As String)
        Try
            Dim proc As Process
            proc = Process.Start(filename, arg)
            proc.WaitForInputIdle()
            SetParent(proc.MainWindowHandle, Panel1.Handle)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub chgScrnReso()
        Dim key As RegistryKey = Registry.CurrentUser
        Dim subKey As RegistryKey

        subKey = key.OpenSubKey("Software\Valve\Half-Life\Settings", True)

        subKey.SetValue("ScreenWidth", Screen.PrimaryScreen.Bounds.Width, RegistryValueKind.DWord)
        subKey.SetValue("ScreenHeight", Screen.PrimaryScreen.Bounds.Height, RegistryValueKind.DWord)
        subKey.SetValue("ScreenWindowed", "0", RegistryValueKind.DWord)
        subKey.SetValue("ScreenBPP", "32", RegistryValueKind.DWord)
        subKey.SetValue("ValveKey", "AAAAA-AAAAA-AAAAA-AAAAA-AAAAA")
        subKey.Close()
    End Sub

    Private Sub lblEnd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblEnd.LinkClicked
        Me.Enabled = False
        frmPause.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim esc As Boolean = GetAsyncKeyState(Keys.P)
        If esc = True Then
            Me.Enabled = False
            frmPause.Show()
        End If
    End Sub
End Class