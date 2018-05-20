Imports System.Runtime.InteropServices
Imports CS_BTE_Launcher.WinApi

Public Class frmCreate

    Private bteUserConfig As String = My.Application.Info.DirectoryPath & "\cstrike\userconfig.cfg"
    Private bteConfig As String = My.Application.Info.DirectoryPath & "\cstrike\config.cfg"
    Private bteServer As String = My.Application.Info.DirectoryPath & "\cstrike\server.cfg"
    Private bteBotConfig As String = My.Application.Info.DirectoryPath & "\cstrike\launcher.cfg"
    Dim lines() As String = System.IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\launcher\vault\map_list.txt")

    Dim botDifficulty As Integer = ReadCfgValue("bot_difficulty", bteBotConfig)
    Dim svLan As Integer = ReadCfgValue("sv_lan", bteBotConfig)

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


    Private Function GetHostIP(ByVal af As System.Net.Sockets.AddressFamily) As String

        Dim host As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim strRet As String = ""

        For Each ip As System.Net.IPAddress In host.AddressList
            If ip.AddressFamily = af Then
                strRet = ip.ToString
                Exit For
            End If
        Next

        Return strRet

    End Function

    Public Sub readMap()
        pb_Map.Image = My.Resources.random_cso

        If frmMode.lbl_Mode.Text = "Basic" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("awp_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("dm_") Then
                                    If Not cmb_Map.Items(n).ToString.Contains("fy_") Then
                                        cmb_Map.Items.RemoveAt(n)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Original" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("awp_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("dm_") Then
                                    If Not cmb_Map.Items(n).ToString.Contains("fy_") Then
                                        cmb_Map.Items.RemoveAt(n)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Deathmatch" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("awp_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("dm_") Then
                                    If Not cmb_Map.Items(n).ToString.Contains("fy_") Then
                                        cmb_Map.Items.RemoveAt(n)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "NN Deathmatch" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("awp_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("dm_") Then
                                    If Not cmb_Map.Items(n).ToString.Contains("fy_") Then
                                        cmb_Map.Items.RemoveAt(n)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Team Deathmatch" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("awp_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("dm_") Then
                                    If Not cmb_Map.Items(n).ToString.Contains("fy_") Then
                                        If Not cmb_Map.Items(n).ToString.Contains("fun_") Then
                                            cmb_Map.Items.RemoveAt(n)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Gun Deathmatch" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("awp_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("dm_") Then
                                    If Not cmb_Map.Items(n).ToString.Contains("fy_") Then
                                        cmb_Map.Items.RemoveAt(n)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Zombie Mode 1" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("zm_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("bzm_") Then
                                    cmb_Map.Items.RemoveAt(n)
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Zombie Mode 3" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("zm_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("bzm_") Then
                                    cmb_Map.Items.RemoveAt(n)
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Zombie Mode 4" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("de_") Then
                    If Not cmb_Map.Items(n).ToString.Contains("cs_") Then
                        If Not cmb_Map.Items(n).ToString.Contains("as_") Then
                            If Not cmb_Map.Items(n).ToString.Contains("zm_") Then
                                If Not cmb_Map.Items(n).ToString.Contains("bzm_") Then
                                    cmb_Map.Items.RemoveAt(n)
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Zombie Scenario" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("zs_") Then
                    cmb_Map.Items.RemoveAt(n)
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Zombie Escape" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("ze_") Then
                    cmb_Map.Items.RemoveAt(n)
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Deathrun" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("cso_") Then
                    cmb_Map.Items.RemoveAt(n)
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Hidden Mode" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("hd_") Then
                    cmb_Map.Items.RemoveAt(n)
                End If
            Next
        End If

        If frmMode.lbl_Mode.Text = "Fun Mode" Then
            cmb_Map.Items.AddRange(lines)
            For n As Integer = cmb_Map.Items.Count - 1 To 0 Step -1
                If Not cmb_Map.Items(n).ToString.Contains("bk_") Then
                    cmb_Map.Items.RemoveAt(n)
                End If
            Next
        End If
    End Sub

    Private Sub frmLauncher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        frmMode.Show()
        frmMode.Hide()

        txtIPAddress.Text = GetHostIP(Net.Sockets.AddressFamily.InterNetwork)
        txtMaxPlayers.Text = My.Settings.HLDS_MaxPlayer
        readMap()
        'cmb_Map.Items.AddRange(lines)
        cmb_Map.SelectedItem = My.Settings.HLDS_Map
        txtMode.Text = frmMode.lbl_Mode.Text
        If My.Settings.Bot_Enable = "Enable" Then
            chk_IncludeBOT.Checked = True
        Else
            chk_IncludeBOT.Checked = False
        End If
        If chk_IncludeBOT.Checked = True Then
            txtBotAmount.Enabled = True
            cmb_BotLevel.Enabled = True
        Else
            txtBotAmount.Enabled = False
            cmb_BotLevel.Enabled = False
        End If
        txtBotAmount.Text = ReadCfgValue("bot_quota", bteBotConfig)
        If botDifficulty = 0 Then
            cmb_BotLevel.SelectedItem = "Easy"
        ElseIf botDifficulty = 1 Then
            cmb_BotLevel.SelectedItem = "Normal"
        ElseIf botDifficulty = 2 Then
            cmb_BotLevel.SelectedItem = "Hard"
        ElseIf botDifficulty = 3 Then
            cmb_BotLevel.SelectedItem = "Expert"
        Else
            cmb_BotLevel.SelectedItem = Nothing
        End If
        If svLan = 1 Then
            cmb_Lan.SelectedItem = "LAN"
        Else
            cmb_Lan.SelectedItem = "Internet"
        End If
    End Sub

    Private Sub chk_IncludeBOT_ChangeChecked(ByVal sender As System.Object, ByVal check As System.Boolean) Handles chk_IncludeBOT.ChangeChecked
        If txtBotAmount.Enabled = True And cmb_BotLevel.Enabled = True Then
            txtBotAmount.Enabled = False
            cmb_BotLevel.Enabled = False
        Else
            txtBotAmount.Enabled = True
            cmb_BotLevel.Enabled = True
        End If
    End Sub

    Private Sub cmb_Map_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Map.SelectedIndexChanged
        On Error Resume Next
        pb_Map.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\mapimg\" & cmb_Map.SelectedItem & "_cso.png")
    End Sub

    Private Sub saveUsrSetting()
        My.Settings.HLDS_Map = cmb_Map.SelectedItem
        WriteCfgValue("bot_quota", txtBotAmount.Text, bteBotConfig)
        If cmb_BotLevel.SelectedItem = "Easy" Then
            botDifficulty = 0
        ElseIf cmb_BotLevel.SelectedItem = "Normal" Then
            botDifficulty = 1
        ElseIf cmb_BotLevel.SelectedItem = "Hard" Then
            botDifficulty = 2
        ElseIf cmb_BotLevel.SelectedItem = "Expert" Then
            botDifficulty = 3
        End If
        WriteCfgValue("bot_difficulty", botDifficulty, bteBotConfig)
        If cmb_Lan.SelectedItem = "LAN" Then
            svLan = 1
        Else
            svLan = 0
        End If
        WriteCfgValue("sv_lan", svLan, bteBotConfig)
        My.Settings.Save()
    End Sub

    Private Sub pbNotice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmNews.Show()
    End Sub

    Private Sub pbOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmOption.Show()
    End Sub

    Private Sub pbRetire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmMsgbox.Show()
    End Sub

    Private Sub pbBarracks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBarracks.Show()
        Me.Hide()
    End Sub

    Private Sub BitdefenderButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            saveUsrSetting()
            'Shell(My.Application.Info.DirectoryPath & "\cstrike.exe +maxplayers " & txtMaxPlayers.Text & " +map " & cmb_Map.SelectedItem & ".bsp +exec server.cfg +exec launcher.cfg", AppWinStyle.NormalFocus)
            'HideAllForms()

            frmParent.player.Ctlcontrols.stop()
            frmParent.SendCommand("pause")

            Me.Hide()
            frmGamevb.Show()
            frmGamevb.processStart(My.Application.Info.DirectoryPath & "\cstrike.exe", "+maxplayers " & txtMaxPlayers.Text & " +map " & cmb_Map.SelectedItem & ".bsp +exec server.cfg +exec launcher.cfg")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        Me.Hide()
        frmLauncher.Show()
    End Sub

    Private Sub txtMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMode.Click
        Me.Hide()
        frmMode.Show()
    End Sub

    Private Sub lblEnd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblEnd.LinkClicked
        Me.Hide()
        frmMenu.Show()
    End Sub
End Class