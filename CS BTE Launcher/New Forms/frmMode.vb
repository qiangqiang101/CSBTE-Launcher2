Imports System.IO
Imports System.Runtime.InteropServices
Imports CS_BTE_Launcher.WinApi

Public Class frmMode

#Region "Window Behavior"

#Region "Fields"
    Private dwmMargins As Dwm.MARGINS
    Private _marginOk As Boolean
    Private _aeroEnabled As Boolean = False
#End Region
#Region "Ctor"
    Public Sub New()
        SetStyle(ControlStyles.ResizeRedraw, True)

        InitializeComponent()

        DoubleBuffered = True

    End Sub
#End Region
#Region "Props"
    Public ReadOnly Property AeroEnabled() As Boolean
        Get
            Return _aeroEnabled
        End Get
    End Property
#End Region
#Region "Methods"
    Public Shared Function LoWord(ByVal dwValue As Integer) As Integer
        Return dwValue And &HFFFF
    End Function
    ''' <summary>
    ''' Equivalent to the HiWord C Macro
    ''' </summary>
    ''' <param name="dwValue"></param>
    ''' <returns></returns>
    Public Shared Function HiWord(ByVal dwValue As Integer) As Integer
        Return (dwValue >> 16) And &HFFFF
    End Function
#End Region

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dwm.DwmExtendFrameIntoClientArea(Me.Handle, dwmMargins)
    End Sub

    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        Dim WM_NCCALCSIZE As Integer = &H83
        Dim WM_NCHITTEST As Integer = &H84
        Dim result As IntPtr

        Dim dwmHandled As Integer = Dwm.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, result)

        If dwmHandled = 1 Then
            m.Result = result
            Exit Sub
        End If

        If m.Msg = WM_NCCALCSIZE AndAlso CInt(m.WParam) = 1 Then
            Dim nccsp As NCCALCSIZE_PARAMS = _
              DirectCast(Marshal.PtrToStructure(m.LParam, _
              GetType(NCCALCSIZE_PARAMS)), NCCALCSIZE_PARAMS)

            ' Adjust (shrink) the client rectangle to accommodate the border:
            nccsp.rect0.Top += 0
            nccsp.rect0.Bottom += 0
            nccsp.rect0.Left += 0
            nccsp.rect0.Right += 0

            If Not _marginOk Then
                'Set what client area would be for passing to DwmExtendIntoClientArea. Also remember that at least one of these values NEEDS TO BE > 1, else it won't work.
                dwmMargins.cyTopHeight = 0
                dwmMargins.cxLeftWidth = 0
                dwmMargins.cyBottomHeight = 3
                dwmMargins.cxRightWidth = 0
                _marginOk = True
            End If

            Marshal.StructureToPtr(nccsp, m.LParam, False)

            m.Result = IntPtr.Zero
        ElseIf m.Msg = WM_NCHITTEST AndAlso CInt(m.Result) = 0 Then
            m.Result = HitTestNCA(m.HWnd, m.WParam, m.LParam)
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Function HitTestNCA(ByVal hwnd As IntPtr, ByVal wparam _
                                      As IntPtr, ByVal lparam As IntPtr) As IntPtr
        Dim HTNOWHERE As Integer = 0
        Dim HTCLIENT As Integer = 1
        Dim HTCAPTION As Integer = 2
        Dim HTGROWBOX As Integer = 4
        Dim HTSIZE As Integer = HTGROWBOX
        Dim HTMINBUTTON As Integer = 8
        Dim HTMAXBUTTON As Integer = 9
        Dim HTLEFT As Integer = 10
        Dim HTRIGHT As Integer = 11
        Dim HTTOP As Integer = 12
        Dim HTTOPLEFT As Integer = 13
        Dim HTTOPRIGHT As Integer = 14
        Dim HTBOTTOM As Integer = 15
        Dim HTBOTTOMLEFT As Integer = 16
        Dim HTBOTTOMRIGHT As Integer = 17
        Dim HTREDUCE As Integer = HTMINBUTTON
        Dim HTZOOM As Integer = HTMAXBUTTON
        Dim HTSIZEFIRST As Integer = HTLEFT
        Dim HTSIZELAST As Integer = HTBOTTOMRIGHT

        Dim p As New Point(LoWord(CInt(lparam)), HiWord(CInt(lparam)))

        Dim topleft As Rectangle = RectangleToScreen(New Rectangle(0, 0, _
                                   dwmMargins.cxLeftWidth, dwmMargins.cxLeftWidth))

        If topleft.Contains(p) Then
            Return New IntPtr(HTTOPLEFT)
        End If

        Dim topright As Rectangle = _
          RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, 0, _
          dwmMargins.cxRightWidth, dwmMargins.cxRightWidth))

        If topright.Contains(p) Then
            Return New IntPtr(HTTOPRIGHT)
        End If

        Dim botleft As Rectangle = _
           RectangleToScreen(New Rectangle(0, Height - dwmMargins.cyBottomHeight, _
           dwmMargins.cxLeftWidth, dwmMargins.cyBottomHeight))

        If botleft.Contains(p) Then
            Return New IntPtr(HTBOTTOMLEFT)
        End If

        Dim botright As Rectangle = _
            RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, _
            Height - dwmMargins.cyBottomHeight, _
            dwmMargins.cxRightWidth, dwmMargins.cyBottomHeight))

        If botright.Contains(p) Then
            Return New IntPtr(HTBOTTOMRIGHT)
        End If

        Dim top As Rectangle = _
            RectangleToScreen(New Rectangle(0, 0, Width, dwmMargins.cxLeftWidth))

        If top.Contains(p) Then
            Return New IntPtr(HTTOP)
        End If

        Dim cap As Rectangle = _
            RectangleToScreen(New Rectangle(0, dwmMargins.cxLeftWidth, _
            Width, dwmMargins.cyTopHeight - dwmMargins.cxLeftWidth))

        If cap.Contains(p) Then
            Return New IntPtr(HTCAPTION)
        End If

        Dim left As Rectangle = _
            RectangleToScreen(New Rectangle(0, 0, dwmMargins.cxLeftWidth, Height))

        If left.Contains(p) Then
            Return New IntPtr(HTLEFT)
        End If

        Dim right As Rectangle = _
            RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, _
            0, dwmMargins.cxRightWidth, Height))

        If right.Contains(p) Then
            Return New IntPtr(HTRIGHT)
        End If

        Dim bottom As Rectangle = _
            RectangleToScreen(New Rectangle(0, Height - dwmMargins.cyBottomHeight, _
            Width, dwmMargins.cyBottomHeight))

        If bottom.Contains(p) Then
            Return New IntPtr(HTBOTTOM)
        End If

        Return New IntPtr(HTCLIENT)
    End Function

    Private Const BorderWidth As Integer = 6

    Private _resizeDir As ResizeDirection = ResizeDirection.None

    Private Sub Form1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.Width - BorderWidth > e.Location.X AndAlso e.Location.X > BorderWidth AndAlso e.Location.Y > BorderWidth Then
                MoveControl(Me.Handle)
            Else
                If Me.WindowState <> FormWindowState.Maximized Then
                    ResizeForm(resizeDir)
                End If
            End If
        End If
    End Sub

    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 4
        TopRight = 8
        Right = 16
        BottomRight = 32
        Bottom = 64
        BottomLeft = 128
    End Enum

    Private Property resizeDir() As ResizeDirection
        Get
            Return _resizeDir
        End Get
        Set(ByVal value As ResizeDirection)
            _resizeDir = value

            'Change cursor
            Select Case value
                Case ResizeDirection.Left
                    Me.Cursor = Cursors.SizeWE

                Case ResizeDirection.Right
                    Me.Cursor = Cursors.SizeWE

                Case ResizeDirection.Top
                    Me.Cursor = Cursors.SizeNS

                Case ResizeDirection.Bottom
                    Me.Cursor = Cursors.SizeNS

                Case ResizeDirection.BottomLeft
                    Me.Cursor = Cursors.SizeNESW

                Case ResizeDirection.TopRight
                    Me.Cursor = Cursors.SizeNESW

                Case ResizeDirection.BottomRight
                    Me.Cursor = Cursors.SizeNWSE

                Case ResizeDirection.TopLeft
                    Me.Cursor = Cursors.SizeNWSE

                Case Else
                    Me.Cursor = Cursors.Default
            End Select
        End Set
    End Property

    Private Sub Form1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        'Calculate which direction to resize based on mouse position

        If e.Location.X < BorderWidth And e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.TopLeft

        ElseIf e.Location.X < BorderWidth And e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.BottomLeft

        ElseIf e.Location.X > Me.Width - BorderWidth And e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.BottomRight

        ElseIf e.Location.X > Me.Width - BorderWidth And e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.TopRight

        ElseIf e.Location.X < BorderWidth Then
            resizeDir = ResizeDirection.Left

        ElseIf e.Location.X > Me.Width - BorderWidth Then
            resizeDir = ResizeDirection.Right

        ElseIf e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.Top

        ElseIf e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.Bottom

        Else
            resizeDir = ResizeDirection.None
        End If
    End Sub

    Private Sub MoveControl(ByVal hWnd As IntPtr)
        ReleaseCapture()
        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub

    Private Sub ResizeForm(ByVal direction As ResizeDirection)
        Dim dir As Integer = -1
        Select Case direction
            Case ResizeDirection.Left
                dir = HTLEFT
            Case ResizeDirection.TopLeft
                dir = HTTOPLEFT
            Case ResizeDirection.Top
                dir = HTTOP
            Case ResizeDirection.TopRight
                dir = HTTOPRIGHT
            Case ResizeDirection.Right
                dir = HTRIGHT
            Case ResizeDirection.BottomRight
                dir = HTBOTTOMRIGHT
            Case ResizeDirection.Bottom
                dir = HTBOTTOM
            Case ResizeDirection.BottomLeft
                dir = HTBOTTOMLEFT
        End Select

        If dir <> -1 Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, dir, 0)
        End If

    End Sub

    <DllImport("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14
#End Region

    Dim map As String = My.Application.Info.DirectoryPath
    Dim gmp As String = "\cstrike\addons\amxmodx\configs\"
    Dim mg As String = map & gmp

    Dim nomod As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-none.ini" 'Original
    Dim teamdm As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-td.ini" 'Team Deathmatch
    Dim funmod As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-funmode.ini" 'Fun Mode
    Dim zb3 As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-zb3.ini" 'Zombie Mode 3
    Dim zbs As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-npc.ini" 'Zombie Scenerio
    Dim drun As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-dr.ini" 'Deathrun
    Dim basic As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-basic.ini" 'Basic
    Dim gundm As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-gd.ini" 'Gun Deathmatch
    Dim zbe As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-ze.ini" 'Zombie Escape
    Dim zb1 As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-zb1.ini" 'Zombie Mode 1
    Dim singledm As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-single.ini" 'Deathmatch
    Dim hidden As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-hidden.ini" 'Hidden Mode
    Dim zb4 As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-zb4.ini" 'Zombie Mode 4
    Dim nndm As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\plugins-dm.ini" 'NN Deathmatch

    Private Sub chkFile()
        Try
            If File.Exists(nomod) Then
                If File.Exists(map & gmp & "disabled-none.ini") Then
                    File.Delete(nomod)
                End If
            End If
            If File.Exists(teamdm) Then
                If File.Exists(map & gmp & "disabled-td.ini") Then
                    File.Delete(teamdm)
                End If
            End If
            If File.Exists(funmod) Then
                If File.Exists(map & gmp & "disabled-funmode.ini") Then
                    File.Delete(funmod)
                End If
            End If
            If File.Exists(zb3) Then
                If File.Exists(map & gmp & "disabled-zb3.ini") Then
                    File.Delete(zb3)
                End If
            End If
            If File.Exists(zbs) Then
                If File.Exists(map & gmp & "disabled-npc.ini") Then
                    File.Delete(zbs)
                End If
            End If
            If File.Exists(drun) Then
                If File.Exists(map & gmp & "disabled-dr.ini") Then
                    File.Delete(drun)
                End If
            End If
            If File.Exists(basic) Then
                If File.Exists(map & gmp & "disabled-basic.ini") Then
                    File.Delete(basic)
                End If
            End If
            If File.Exists(gundm) Then
                If File.Exists(map & gmp & "disabled-gd.ini") Then
                    File.Delete(gundm)
                End If
            End If
            If File.Exists(zbe) Then
                If File.Exists(map & gmp & "disabled-ze.ini") Then
                    File.Delete(zbe)
                End If
            End If
            If File.Exists(zb1) Then
                If File.Exists(map & gmp & "disabled-zb1.ini") Then
                    File.Delete(zb1)
                End If
            End If
            If File.Exists(singledm) Then
                If File.Exists(map & gmp & "disabled-single.ini") Then
                    File.Delete(singledm)
                End If
            End If
            If File.Exists(hidden) Then
                If File.Exists(map & gmp & "disabled-hidden.ini") Then
                    File.Delete(hidden)
                End If
            End If
            If File.Exists(zb4) Then
                If File.Exists(map & gmp & "disabled-zb4.ini") Then
                    File.Delete(zb4)
                End If
            End If
            If File.Exists(nndm) Then
                If File.Exists(map & gmp & "disabled-dm.ini") Then
                    File.Delete(nndm)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    

    Private Sub frmCreate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkFile()

        Try
            If File.Exists(nomod) Then
                pic_none.Image = My.Resources.none_s
                lbl_Mode.Text = "Original"
            ElseIf File.Exists(teamdm) Then
                pic_tdm.Image = My.Resources.td_s
                lbl_Mode.Text = "Team Deathmatch"
            ElseIf File.Exists(funmod) Then
                pic_fun.Image = My.Resources.fun_s
                lbl_Mode.Text = "Fun Mode"
            ElseIf File.Exists(zb3) Then
                pic_zb3.Image = My.Resources.zb3_s
                lbl_Mode.Text = "Zombie Mode 3"
            ElseIf File.Exists(zb4) Then
                pic_zb4.Image = My.Resources.zb4_s
                lbl_Mode.Text = "Zombie Mode 4"
            ElseIf File.Exists(zb1) Then
                pic_zb1.Image = My.Resources.zb1_s
                lbl_Mode.Text = "Zombie Mode 1"
            ElseIf File.Exists(zbs) Then
                pic_npc.Image = My.Resources.npc_s
                lbl_Mode.Text = "Zombie Scenario"
            ElseIf File.Exists(drun) Then
                pic_dr.Image = My.Resources.dr_s
                lbl_Mode.Text = "Deathrun"
            ElseIf File.Exists(basic) Then
                pic_basic.Image = My.Resources.basic_s
                lbl_Mode.Text = "Basic"
            ElseIf File.Exists(gundm) Then
                pic_gd.Image = My.Resources.gdm_s
                lbl_Mode.Text = "Gun Deathmatch"
            ElseIf File.Exists(zbe) Then
                pic_ze.Image = My.Resources.ze_s
                lbl_Mode.Text = "Zombie Escape"
            ElseIf File.Exists(singledm) Then
                pic_dm.Image = My.Resources.dm_s
                lbl_Mode.Text = "Deathmatch"
            ElseIf File.Exists(hidden) Then
                pic_hd.Image = My.Resources.hd_s
                lbl_Mode.Text = "Hidden Mode"
            ElseIf File.Exists(nndm) Then
                pic_nndm.Image = My.Resources.nndm_s
                lbl_Mode.Text = "NN Deathmatch"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub pic_basic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_basic.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-basic.ini", "plugins-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Basic"
        frmCreate.txtMode.Text = "Basic"

        pic_basic.Image = My.Resources.basic_s
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_none_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_none.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-none.ini", "plugins-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Original"
        frmCreate.txtMode.Text = "Original"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_s
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_dm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_dm.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-single.ini", "plugins-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Deathmatch"
        frmCreate.txtMode.Text = "Deathmatch"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_s
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_nndm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_nndm.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-dm.ini", "plugins-dm.ini")
        lbl_Mode.Text = "NN Deathmatch"
        frmCreate.txtMode.Text = "NN Deathmatch"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_s
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_tdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_tdm.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-td.ini", "plugins-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Team Deathmatch"
        frmCreate.txtMode.Text = "Team Deathmatch"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_s
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_gd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_gd.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-gd.ini", "plugins-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Gun Deathmatch"
        frmCreate.txtMode.Text = "Gun Deathmatch"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_s
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_hd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_hd.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-hidden.ini", "plugins-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Hidden Mode"
        frmCreate.txtMode.Text = "Hidden Mode"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_s
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_fun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_fun.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-funmode.ini", "plugins-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Fun Mode"
        frmCreate.txtMode.Text = "Fun Mode"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_s
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_dr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_dr.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-dr.ini", "plugins-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Deathrun"
        frmCreate.txtMode.Text = "Deathrun"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_s
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_zb1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_zb1.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-zb1.ini", "plugins-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Zombie Mode 1"
        frmCreate.txtMode.Text = "Zombie Mode 1"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_s
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_zb3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_zb3.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-zb3.ini", "plugins-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Zombie Mode 3"
        frmCreate.txtMode.Text = "Zombie Mode 3"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_s
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_zb4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_zb4.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-zb4.ini", "plugins-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Zombie Mode 4"
        frmCreate.txtMode.Text = "Zombie Mode 4"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_s
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_npc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_npc.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-ze.ini", "disabled-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-npc.ini", "plugins-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Zombie Scenario"
        frmCreate.txtMode.Text = "Zombie Scenario"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_s
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_n

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub pic_ze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_ze.Click
        On Error Resume Next
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-none.ini", "disabled-none.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb3.ini", "disabled-zb3.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dr.ini", "disabled-dr.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-gd.ini", "disabled-gd.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "disabled-ze.ini", "plugins-ze.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-td.ini", "disabled-td.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-single.ini", "disabled-single.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-npc.ini", "disabled-npc.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb1.ini", "disabled-zb1.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-basic.ini", "disabled-basic.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-funmode.ini", "disabled-funmode.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-hidden.ini", "disabled-hidden.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-zb4.ini", "disabled-zb4.ini")
        My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\" & "plugins-dm.ini", "disabled-dm.ini")
        lbl_Mode.Text = "Zombie Escape"
        frmCreate.txtMode.Text = "Zombie Escape"

        pic_basic.Image = My.Resources.basic_n
        pic_dm.Image = My.Resources.dm_n
        pic_dr.Image = My.Resources.dr_n
        pic_fun.Image = My.Resources.fun_n
        pic_gd.Image = My.Resources.gdm_n
        pic_hd.Image = My.Resources.hd_n
        pic_nndm.Image = My.Resources.nndm_n
        pic_none.Image = My.Resources.none_n
        pic_npc.Image = My.Resources.npc_n
        pic_tdm.Image = My.Resources.td_n
        pic_zb1.Image = My.Resources.zb1_n
        pic_zb3.Image = My.Resources.zb3_n
        pic_zb4.Image = My.Resources.zb4_n
        pic_ze.Image = My.Resources.ze_s

        frmCreate.cmb_Map.Items.Clear()
        frmCreate.readMap()

        Me.Hide()
        frmCreate.Show()
    End Sub

    Private Sub lblEnd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblEnd.LinkClicked
        Me.Hide()
        frmCreate.Show()
    End Sub
End Class