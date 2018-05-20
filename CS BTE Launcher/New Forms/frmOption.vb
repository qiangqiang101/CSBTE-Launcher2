Imports System.IO
Imports System.Runtime.InteropServices
Imports CS_BTE_Launcher.WinApi

Public Class frmOption

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

    Private bteUserConfig As String = My.Application.Info.DirectoryPath & "\cstrike\userconfig.cfg"
    Private bteConfig As String = My.Application.Info.DirectoryPath & "\cstrike\config.cfg"

    Dim crosshairType As String = ReadCfgValue("cl_crosshair_type", bteUserConfig)
    Dim crosshairColor As String = ReadCfgValue("cl_crosshair_color", bteUserConfig)
    Dim crosshairSize As String = ReadCfgValue("cl_crosshair_size", bteConfig)

    Dim mouseFilter As Integer = ReadCfgValue("m_filter", bteConfig)
    Dim mouseLook As Integer = ReadCfgValue("m_forward", bteConfig)
    Dim joyStick As Integer = ReadCfgValue("joystick", bteConfig)
    Dim autoAim As Integer = ReadCfgValue("sv_aim", bteConfig)
    Dim mouseSensitivity As Integer = ReadCfgValue("sensitivity", bteConfig)

    Dim voiceEnable As Integer = ReadCfgValue("voice_enable", bteUserConfig)
    Dim voiceEnable2 As Integer = ReadCfgValue("sv_voiceenable", bteUserConfig)
    Dim voiceForceMicRecord As Integer = ReadCfgValue("voice_forcemicrecord", bteUserConfig)
    Dim voiceReceiveVolume As Integer = ReadCfgValue("voice_scale", bteConfig)

    Dim wpnAlignment As Integer = ReadCfgValue("cl_righthand", bteConfig)
    Dim switchPickedUpWpn As Integer = ReadCfgValue("_cl_autowepswitch", bteConfig)
    Dim centerPlayerName As Integer = ReadCfgValue("hud_centerid", bteConfig)
    Dim gunSmoke As Integer = ReadCfgValue("cl_gunsmoke", bteConfig)
    Dim scoreBoard As Integer = ReadCfgValue("mh_scoreboard", bteConfig)
    Dim binkAni As Integer = ReadCfgValue("mh_drawbink", bteConfig)
    Dim tabPanel As Integer = ReadCfgValue("mh_drawpanel", bteConfig)
    Dim customScope As Integer = ReadCfgValue("mh_drawscope", bteConfig)
    Dim showTMName As Integer = ReadCfgValue("mh_teammatename", bteConfig)
    Dim bloodEffect As Integer = ReadCfgValue("mh_bloodcolor", bteConfig)
    Dim customMenu As Integer = ReadCfgValue("mh_drawmenu", bteConfig)
    Dim devMode As Integer = ReadCfgValue("developer", bteConfig)
    Dim gamePause As Integer = ReadCfgValue("pausable", bteConfig)

    Private Sub frmOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SuperTabItem3.Visible = False

        txt_Name.Text = ReadCfgValue("name", bteUserConfig)
        cmb_Spray.SelectedItem = My.Settings.Spray
        If crosshairType = "0" Then
            If crosshairSize = "auto" Then
                cmb_CrosshairType.SelectedItem = "Auto-size Cross Type"
            ElseIf crosshairSize = "small" Then
                cmb_CrosshairType.SelectedItem = "Small Cross Type"
            ElseIf crosshairSize = "medium" Then
                cmb_CrosshairType.SelectedItem = "Medium Cross Type"
            ElseIf crosshairSize = "large" Then
                cmb_CrosshairType.SelectedItem = "Large Cross Type"
            End If
            pb_Crosshair.Image = My.Resources._0
        ElseIf crosshairType = "1" Then
            If crosshairSize = "auto" Then
                cmb_CrosshairType.SelectedItem = "Auto-size Target Type"
            ElseIf crosshairSize = "small" Then
                cmb_CrosshairType.SelectedItem = "Small Target Type"
            ElseIf crosshairSize = "medium" Then
                cmb_CrosshairType.SelectedItem = "Medium Target Type"
            ElseIf crosshairSize = "large" Then
                cmb_CrosshairType.SelectedItem = "Large Target Type"
            End If
            pb_Crosshair.Image = My.Resources._1
        ElseIf crosshairType = "2" Then
            If crosshairSize = "auto" Then
                cmb_CrosshairType.SelectedItem = "Auto-size Round Type"
            ElseIf crosshairSize = "small" Then
                cmb_CrosshairType.SelectedItem = "Small Round Type"
            ElseIf crosshairSize = "medium" Then
                cmb_CrosshairType.SelectedItem = "Medium Round Type"
            ElseIf crosshairSize = "large" Then
                cmb_CrosshairType.SelectedItem = "Large Round Type"
            End If
            pb_Crosshair.Image = My.Resources._2
        ElseIf crosshairType = "3" Then
            If crosshairSize = "auto" Then
                cmb_CrosshairType.SelectedItem = "Auto-size All Type"
            ElseIf crosshairSize = "small" Then
                cmb_CrosshairType.SelectedItem = "Small All Type"
            ElseIf crosshairSize = "medium" Then
                cmb_CrosshairType.SelectedItem = "Medium All Type"
            ElseIf crosshairSize = "large" Then
                cmb_CrosshairType.SelectedItem = "Large All Type"
            End If
            pb_Crosshair.Image = My.Resources._3
        ElseIf crosshairType = "4" Then
            If crosshairSize = "auto" Then
                cmb_CrosshairType.SelectedItem = "Auto-size Point Fire Type"
            ElseIf crosshairSize = "small" Then
                cmb_CrosshairType.SelectedItem = "Small Point Fire Type"
            ElseIf crosshairSize = "medium" Then
                cmb_CrosshairType.SelectedItem = "Medium Point Fire Type"
            ElseIf crosshairSize = "large" Then
                cmb_CrosshairType.SelectedItem = "Large Point Fire Type"
            End If
            pb_Crosshair.Image = My.Resources._4
        Else
            cmb_CrosshairType.SelectedItem = ""
        End If
        If crosshairColor = "50 250 50" Then
            cmb_CrosshairColor.SelectedItem = "Green"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(50, 250, 50)
        ElseIf crosshairColor = "249 254 50" Then
            cmb_CrosshairColor.SelectedItem = "Yellow"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(249, 254, 50)
        ElseIf crosshairColor = "249 0 0" Then
            cmb_CrosshairColor.SelectedItem = "Red"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(249, 0, 0)
        ElseIf crosshairColor = "0 124 249" Then
            cmb_CrosshairColor.SelectedItem = "Blue"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(0, 124, 249)
        ElseIf crosshairColor = "0 248 249" Then
            cmb_CrosshairColor.SelectedItem = "Aqua"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(0, 248, 249)
        Else
            cmb_CrosshairColor.SelectedItem = ""
        End If

        If mouseFilter = 0 Then
            chk_MouseFilter.Checked = False
        Else
            chk_MouseFilter.Checked = True
        End If
        If mouseLook = 0 Then
            chk_MouseLook.Checked = False
        Else
            chk_MouseLook.Checked = True
        End If
        If joyStick = 0 Then
            chk_Joystick.Checked = False
        Else
            chk_Joystick.Checked = True
        End If
        If autoAim = 0 Then
            chk_AutoAim.Checked = False
        Else
            chk_AutoAim.Checked = True
        End If
        sld_Sensitivity.Value = mouseSensitivity
        txt_Sensitivity.Text = mouseSensitivity
        If voiceEnable = 0 Then
            chk_Voice.Checked = False
        Else
            chk_Voice.Checked = True
        End If
        If voiceForceMicRecord = 0 Then
            chk_BoostMic.Checked = False
        Else
            chk_BoostMic.Checked = True
        End If
        sld_ReveiveVolume.Value = voiceReceiveVolume * 100

        If My.Settings.BGM = "On" Then
            chk_BGM.Checked = True
        Else
            chk_BGM.Checked = False
        End If

        txt_DeadBodiesDisappear.Text = ReadCfgValue("cl_corpsestay", bteConfig)
        txt_MPDecalLimit.Text = ReadCfgValue("mp_decals", bteConfig)
        txt_MaxShells.Text = ReadCfgValue("max_shells", bteUserConfig)
        txt_MaxSmokePuffs.Text = ReadCfgValue("max_smokepuffs", bteUserConfig)
        txt_RadarSize.Text = ReadCfgValue("mh_dynamicradar_rect", bteConfig)
        If wpnAlignment = 0 Then
            cmb_WpnAlignment.SelectedItem = "Left handed"
        Else
            cmb_WpnAlignment.SelectedItem = "Right handed"
        End If
        If switchPickedUpWpn = 0 Then
            chk_SwitchPickedUpWeapons.Checked = False
        Else
            chk_SwitchPickedUpWeapons.Checked = True
        End If
        If centerPlayerName = 0 Then
            chk_CenterPlayerNames.Checked = True
        Else
            chk_CenterPlayerNames.Checked = False
        End If
        If gunSmoke = 0 Then
            chk_GunSmoke.Checked = False
        Else
            chk_GunSmoke.Checked = True
        End If
        If scoreBoard = 0 Then
            chk_Scoreboard.Checked = False
        Else
            chk_Scoreboard.Checked = True
        End If
        If binkAni = 0 Then
            chk_Bink.Checked = False
        Else
            chk_Bink.Checked = True
        End If
        If tabPanel = 0 Then
            chk_TabPanel.Checked = False
        Else
            chk_TabPanel.Checked = True
        End If
        If customScope = 0 Then
            chk_CustomScope.Checked = False
        Else
            chk_CustomScope.Checked = True
        End If
        If showTMName = 0 Then
            chk_TeammateName.Checked = False
        Else
            chk_TeammateName.Checked = True
        End If
        If bloodEffect = 0 Then
            chk_BlookEffect.Checked = False
        Else
            chk_BlookEffect.Checked = True
        End If
        If customMenu = 0 Then
            chk_CustomMenu.Checked = False
        Else
            chk_CustomMenu.Checked = True
        End If
        If devMode = 1 Then
            chk_DevMode.Checked = True
        Else
            chk_DevMode.Checked = False
        End If
        If gamePause = 1 Then
            chk_GamePause.Checked = True
        Else
            chk_GamePause.Checked = False
        End If
    End Sub

    Private Sub cmb_Spray_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Spray.SelectedIndexChanged
        If cmb_Spray.SelectedItem = "CSO" Then
            pb_Spray.Image = My.Resources.Cso
        ElseIf cmb_Spray.SelectedItem = "Ladder" Then
            pb_Spray.Image = My.Resources.Ladderspray
        ElseIf cmb_Spray.SelectedItem = "CT" Then
            pb_Spray.Image = My.Resources.Ctspray
        ElseIf cmb_Spray.SelectedItem = "TR" Then
            pb_Spray.Image = My.Resources.Trspray
        ElseIf cmb_Spray.SelectedItem = "Host Regular Zombie" Then
            pb_Spray.Image = My.Resources.Host_regular_zombie_spray
        ElseIf cmb_Spray.SelectedItem = "Host Psycho Zombie" Then
            pb_Spray.Image = My.Resources.Pczombi_spray
        ElseIf cmb_Spray.SelectedItem = "M134" Then
            pb_Spray.Image = My.Resources.Xmas_spray
        ElseIf cmb_Spray.SelectedItem = "Watergun" Then
            pb_Spray.Image = My.Resources.Watergun_spray
        ElseIf cmb_Spray.SelectedItem = "SL8 Gold" Then
            pb_Spray.Image = My.Resources.Sl8gold_spray
        ElseIf cmb_Spray.SelectedItem = "Jennifer" Then
            pb_Spray.Image = My.Resources.Jenniferspray
        ElseIf cmb_Spray.SelectedItem = "Natasha" Then
            pb_Spray.Image = My.Resources.Natashaspray
        ElseIf cmb_Spray.SelectedItem = "Choijiyoon" Then
            pb_Spray.Image = My.Resources.Choijiyoon_spray
        ElseIf cmb_Spray.SelectedItem = "Ritsuka" Then
            pb_Spray.Image = My.Resources.Ritsuka_spray
        ElseIf cmb_Spray.SelectedItem = "Criss" Then
            pb_Spray.Image = My.Resources.Crissspray
        ElseIf cmb_Spray.SelectedItem = "Yuri" Then
            pb_Spray.Image = My.Resources.Yurispray
        ElseIf cmb_Spray.SelectedItem = "May" Then
            pb_Spray.Image = My.Resources.MeiSpray
        ElseIf cmb_Spray.SelectedItem = "Erica" Then
            pb_Spray.Image = My.Resources.EricaSpray
        ElseIf cmb_Spray.SelectedItem = "Chinese New Year" Then
            pb_Spray.Image = My.Resources.Newyearspray
        ElseIf cmb_Spray.SelectedItem = "Skull" Then
            pb_Spray.Image = My.Resources.Skullspray
        ElseIf cmb_Spray.SelectedItem = "Christmas" Then
            pb_Spray.Image = My.Resources.Xmasspray09
        ElseIf cmb_Spray.SelectedItem = "Valentine" Then
            pb_Spray.Image = My.Resources.Valentines_section_painting
        ElseIf cmb_Spray.SelectedItem = "Half Love Left" Then
            pb_Spray.Image = My.Resources.Love_the_debris_painting__left_
        ElseIf cmb_Spray.SelectedItem = "Sniper Master" Then
            pb_Spray.Image = My.Resources.Sniper_king_painting
        ElseIf cmb_Spray.SelectedItem = "Half Love Right" Then
            pb_Spray.Image = My.Resources.Love_the_debris_painting__right_
        ElseIf cmb_Spray.SelectedItem = "Complete Love" Then
            pb_Spray.Image = My.Resources.All_about_lovin__you_paint
        ElseIf cmb_Spray.SelectedItem = "Skeleton Rabbit" Then
            pb_Spray.Image = My.Resources.Skull_rabbit_painting
        ElseIf cmb_Spray.SelectedItem = "CSO 2010" Then
            pb_Spray.Image = My.Resources._2_anniversary_of_the_painting
        ElseIf cmb_Spray.SelectedItem = "WCG 2012" Then
            pb_Spray.Image = My.Resources.Wcg12spray
        ElseIf cmb_Spray.SelectedItem = "CSOWC 2013" Then
            pb_Spray.Image = My.Resources.Wc13spray
        ElseIf cmb_Spray.SelectedItem = "Army Rank" Then
            pb_Spray.Image = My.Resources.Army_rank_spray
        ElseIf cmb_Spray.SelectedItem = "Corps Rank" Then
            pb_Spray.Image = My.Resources.Corps_rank_spray
        ElseIf cmb_Spray.SelectedItem = "Brigade Rank" Then
            pb_Spray.Image = My.Resources.Brigade_rank_spray
        ElseIf cmb_Spray.SelectedItem = "Battalion Rank" Then
            pb_Spray.Image = My.Resources.Battalion_rank_spray
        ElseIf cmb_Spray.SelectedItem = "Platoon Rank" Then
            pb_Spray.Image = My.Resources.Platoon_rank_spray
        ElseIf cmb_Spray.SelectedItem = "Watch your Back" Then
            pb_Spray.Image = My.Resources.Gongmospray01
        ElseIf cmb_Spray.SelectedItem = "Target" Then
            pb_Spray.Image = My.Resources.Gongmospray02
        ElseIf cmb_Spray.SelectedItem = "Crime Scene Mark" Then
            pb_Spray.Image = My.Resources.Gongmospray03
        ElseIf cmb_Spray.SelectedItem = "Cartoon Light Zombie" Then
            pb_Spray.Image = My.Resources.Gongmospray07
        ElseIf cmb_Spray.SelectedItem = "Cartoon Yuri" Then
            pb_Spray.Image = My.Resources.Gongmospray08
        ElseIf cmb_Spray.SelectedItem = "Cartoon SAS" Then
            pb_Spray.Image = My.Resources.Gongmospray09
        ElseIf cmb_Spray.SelectedItem = "Cartoon Guerilla Warfare" Then
            pb_Spray.Image = My.Resources.Gongmospray10
        ElseIf cmb_Spray.SelectedItem = "Band Aid" Then
            pb_Spray.Image = My.Resources.Bandspray
        ElseIf cmb_Spray.SelectedItem = "Not_In_Use" Then
            pb_Spray.Image = My.Resources.Ladderspray
        Else
            pb_Spray.Image = My.Resources.Cso
        End If
        My.Settings.Spray = cmb_Spray.SelectedItem
    End Sub

    Private Sub cmb_CrosshairType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_CrosshairType.SelectedIndexChanged
        If cmb_CrosshairType.SelectedItem = "Auto-size Cross Type" Then
            pb_Crosshair.Image = My.Resources._0
            crosshairType = "0"
            crosshairSize = "auto"
        ElseIf cmb_CrosshairType.SelectedItem = "Small Cross Type" Then
            pb_Crosshair.Image = My.Resources._0
            crosshairType = "0"
            crosshairSize = "small"
        ElseIf cmb_CrosshairType.SelectedItem = "Medium Cross Type" Then
            pb_Crosshair.Image = My.Resources._0
            crosshairType = "0"
            crosshairSize = "medium"
        ElseIf cmb_CrosshairType.SelectedItem = "Large Cross Type" Then
            pb_Crosshair.Image = My.Resources._0
            crosshairType = "0"
            crosshairSize = "large"
        ElseIf cmb_CrosshairType.SelectedItem = "Auto-size Target Type" Then
            pb_Crosshair.Image = My.Resources._1
            crosshairType = "1"
            crosshairSize = "auto"
        ElseIf cmb_CrosshairType.SelectedItem = "Small Target Type" Then
            pb_Crosshair.Image = My.Resources._1
            crosshairType = "1"
            crosshairSize = "small"
        ElseIf cmb_CrosshairType.SelectedItem = "Medium Target Type" Then
            pb_Crosshair.Image = My.Resources._1
            crosshairType = "1"
            crosshairSize = "medium"
        ElseIf cmb_CrosshairType.SelectedItem = "Large Target Type" Then
            pb_Crosshair.Image = My.Resources._1
            crosshairType = "1"
            crosshairSize = "large"
        ElseIf cmb_CrosshairType.SelectedItem = "Auto-size Round Type" Then
            pb_Crosshair.Image = My.Resources._2
            crosshairType = "2"
            crosshairSize = "auto"
        ElseIf cmb_CrosshairType.SelectedItem = "Small Round Type" Then
            pb_Crosshair.Image = My.Resources._2
            crosshairType = "2"
            crosshairSize = "small"
        ElseIf cmb_CrosshairType.SelectedItem = "Medium Round Type" Then
            pb_Crosshair.Image = My.Resources._2
            crosshairType = "2"
            crosshairSize = "medium"
        ElseIf cmb_CrosshairType.SelectedItem = "Large Round Type" Then
            pb_Crosshair.Image = My.Resources._2
            crosshairType = "2"
            crosshairSize = "large"
        ElseIf cmb_CrosshairType.SelectedItem = "Auto-size All Type" Then
            pb_Crosshair.Image = My.Resources._3
            crosshairType = "3"
            crosshairSize = "auto"
        ElseIf cmb_CrosshairType.SelectedItem = "Small All Type" Then
            pb_Crosshair.Image = My.Resources._3
            crosshairType = "3"
            crosshairSize = "small"
        ElseIf cmb_CrosshairType.SelectedItem = "Medium All Type" Then
            pb_Crosshair.Image = My.Resources._3
            crosshairType = "3"
            crosshairSize = "medium"
        ElseIf cmb_CrosshairType.SelectedItem = "Large All Type" Then
            pb_Crosshair.Image = My.Resources._3
            crosshairType = "3"
            crosshairSize = "large"
        ElseIf cmb_CrosshairType.SelectedItem = "Auto-size Point Fire Type" Then
            pb_Crosshair.Image = My.Resources._4
            crosshairType = "4"
            crosshairSize = "auto"
        ElseIf cmb_CrosshairType.SelectedItem = "Small Point Fire Type" Then
            pb_Crosshair.Image = My.Resources._4
            crosshairType = "4"
            crosshairSize = "small"
        ElseIf cmb_CrosshairType.SelectedItem = "Medium Point Fire Type" Then
            pb_Crosshair.Image = My.Resources._4
            crosshairType = "4"
            crosshairSize = "medium"
        ElseIf cmb_CrosshairType.SelectedItem = "Large Point Fire Type" Then
            pb_Crosshair.Image = My.Resources._4
            crosshairType = "4"
            crosshairSize = "large"
        End If
    End Sub

    Private Sub cmb_CrosshairColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_CrosshairColor.SelectedIndexChanged
        If cmb_CrosshairColor.SelectedItem = "Green" Then
            crosshairColor = "50 250 50"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(50, 250, 50)
        ElseIf cmb_CrosshairColor.SelectedItem = "Yellow" Then
            crosshairColor = "249 254 50"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(249, 254, 50)
        ElseIf cmb_CrosshairColor.SelectedItem = "Red" Then
            crosshairColor = "249 0 0"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(249, 0, 0)
        ElseIf cmb_CrosshairColor.SelectedItem = "Blue" Then
            crosshairColor = "0 124 249"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(0, 124, 249)
        ElseIf cmb_CrosshairColor.SelectedItem = "Aqua" Then
            crosshairColor = "0 248 249"
            cmb_CrosshairColor.ForeColor = Color.FromArgb(0, 248, 249)
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            WriteCfgValue("name", txt_Name.Text, bteUserConfig)
            WriteCfgValue("cl_crosshair_type", crosshairType, bteUserConfig)
            WriteCfgValue("cl_crosshair_color", crosshairColor, bteUserConfig)
            WriteCfgValue("cl_crosshair_size", crosshairSize, bteConfig)

            My.Settings.Spray = cmb_Spray.SelectedItem

            System.IO.File.Delete(My.Application.Info.DirectoryPath & "\cstrike\tempdecal.wad")
            System.IO.File.Copy(My.Application.Info.DirectoryPath & "\launcher\logos\" & cmb_Spray.SelectedItem.ToString & "\tempdecal.wad", My.Application.Info.DirectoryPath & "\cstrike\tempdecal.wad")

            If chk_SwitchPickedUpWeapons.Checked = True Then
                switchPickedUpWpn = 1
            Else
                switchPickedUpWpn = 0
            End If
            If chk_CenterPlayerNames.Checked = True Then
                centerPlayerName = 1
            Else
                centerPlayerName = 0
            End If
            If chk_GunSmoke.Checked = True Then
                gunSmoke = 1
            Else
                gunSmoke = 0
            End If
            If chk_Scoreboard.Checked = True Then
                scoreBoard = 1
            Else
                scoreBoard = 0
            End If
            If chk_Bink.Checked = True Then
                binkAni = 1
            Else
                binkAni = 0
            End If
            If chk_TabPanel.Checked = True Then
                tabPanel = 1
            Else
                tabPanel = 0
            End If
            If chk_CustomScope.Checked = True Then
                customScope = 1
            Else
                customScope = 0
            End If
            If chk_TeammateName.Checked = True Then
                showTMName = 1
            Else
                showTMName = 0
            End If
            If chk_BlookEffect.Checked = True Then
                bloodEffect = 1
            Else
                bloodEffect = 0
            End If
            If chk_CustomMenu.Checked = True Then
                customMenu = 1
            Else
                customMenu = 0
            End If
            If chk_DevMode.Checked = True Then
                devMode = 1
            Else
                devMode = 0
            End If
            If chk_GamePause.Checked = True Then
                gamePause = 1
            Else
                gamePause = 0
            End If
            If chk_MouseLook.Checked = True Then
                mouseLook = 1
            Else
                mouseLook = 0
            End If
            If chk_MouseFilter.Checked = True Then
                mouseFilter = 1
            Else
                mouseFilter = 0
            End If
            If chk_Joystick.Checked = True Then
                joyStick = 1
            Else
                joyStick = 0
            End If
            If chk_AutoAim.Checked = True Then
                autoAim = 1
            Else
                autoAim = 0
            End If
            If chk_Voice.Checked = True Then
                voiceEnable = 1
                voiceEnable2 = 1
            Else
                voiceEnable = 0
                voiceEnable2 = 0
            End If
            If chk_BoostMic.Checked = True Then
                voiceForceMicRecord = 1
            Else
                voiceForceMicRecord = 0
            End If

            WriteCfgValue("m_filter", mouseFilter, bteConfig)
            WriteCfgValue("m_forward", mouseLook, bteConfig)
            WriteCfgValue("joystick", joyStick, bteConfig)
            WriteCfgValue("sv_aim", autoAim, bteConfig)
            WriteCfgValue("sensitivity", mouseSensitivity, bteConfig)

            WriteCfgValue("voice_enable", voiceEnable, bteUserConfig)
            WriteCfgValue("sv_voiceenable", voiceEnable2, bteUserConfig)
            WriteCfgValue("voice_forcemicrecord", voiceForceMicRecord, bteUserConfig)
            WriteCfgValue("voice_scale", voiceReceiveVolume, bteConfig)

            WriteCfgValue("cl_righthand", wpnAlignment, bteConfig)
            WriteCfgValue("_cl_autowepswitch", switchPickedUpWpn, bteConfig)
            WriteCfgValue("hud_centerid", centerPlayerName, bteConfig)
            WriteCfgValue("cl_gunsmoke", gunSmoke, bteConfig)
            WriteCfgValue("mh_scoreboard", scoreBoard, bteConfig)
            WriteCfgValue("mh_drawbink", binkAni, bteConfig)
            WriteCfgValue("mh_drawpanel", tabPanel, bteConfig)
            WriteCfgValue("mh_drawscope", customScope, bteConfig)
            WriteCfgValue("mh_teammatename", showTMName, bteConfig)
            WriteCfgValue("mh_bloodcolor", bloodEffect, bteConfig)
            WriteCfgValue("mh_drawmenu", customMenu, bteConfig)
            WriteCfgValue("developer", devMode, bteConfig)
            WriteCfgValue("pauseable", gamePause, bteConfig)

            WriteCfgValue("cl_corpsestay", txt_DeadBodiesDisappear.Text, bteConfig)
            WriteCfgValue("mp_decals", txt_MPDecalLimit.Text, bteConfig)
            WriteCfgValue("max_shells", txt_MaxShells.Text, bteUserConfig)
            WriteCfgValue("max_smokepuffs", txt_MaxSmokePuffs.Text, bteUserConfig)
            WriteCfgValue("mh_dynamicradar_rect", txt_RadarSize.Text, bteConfig)

            If chk_BGM.Checked = True Then
                My.Settings.BGM = "On"
            Else
                My.Settings.BGM = "Off"
            End If

            My.Settings.Save()

            Me.Hide()
            frmMenu.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub sld_Sensitivity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sld_Sensitivity.ValueChanged
        txt_Sensitivity.Text = sld_Sensitivity.Value
    End Sub

    Private Sub btnAdv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdv.Click
        SuperTabItem3.Visible = True
        SuperTabControl1.SelectedTab = SuperTabItem3
    End Sub

    Private Sub cmb_WpnAlignment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_WpnAlignment.SelectedIndexChanged
        If cmb_WpnAlignment.SelectedItem = "Left handed" Then
            wpnAlignment = 0
        Else
            wpnAlignment = 1
        End If
    End Sub

    Private Sub sld_ReveiveVolume_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sld_ReveiveVolume.ValueChanged
        voiceReceiveVolume = sld_ReveiveVolume.Value
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
        frmMenu.Show()
    End Sub

    Private Sub llblZBWeb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblZBWeb.LinkClicked
        Process.Start("http://zettabytetek.com/")
    End Sub

    Private Sub lblEnd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblEnd.LinkClicked
        Me.Hide()
        frmMenu.Show()
    End Sub
End Class