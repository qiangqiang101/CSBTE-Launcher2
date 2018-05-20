Imports System.Runtime.InteropServices
Imports CS_BTE_Launcher.WinApi
Imports CSBTE.Core
Imports CSBTE.FileStream
Imports System.Threading

Public Class frmBarracks

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

#Region "Old Declare"
    'Barrack
    Private btePrimary As String = My.Application.Info.DirectoryPath & "\launcher\vault\pri_wpn.ini"
    Private bteSecondary As String = My.Application.Info.DirectoryPath & "\launcher\vault\sec_wpn.ini"
    Private bteMelee As String = My.Application.Info.DirectoryPath & "\launcher\vault\mel_wpn.ini"
    Private bteGrenade As String = My.Application.Info.DirectoryPath & "\launcher\vault\gre_wpn.ini"
    Private bteMyPrimary As String = My.Application.Info.DirectoryPath & "\launcher\vault\pri_mywpn.ini"
    Private bteMySecondary As String = My.Application.Info.DirectoryPath & "\launcher\vault\sec_mywpn.ini"
    Private bteMyMelee As String = My.Application.Info.DirectoryPath & "\launcher\vault\mel_mywpn.ini"
    Private bteMyGrenade As String = My.Application.Info.DirectoryPath & "\launcher\vault\gre_mywpn.ini"
    Private launcherPlayer As String = My.Application.Info.DirectoryPath & "\launcher\vault\player.ini"
    Private launcherMyPlayer As String = My.Application.Info.DirectoryPath & "\launcher\vault\myplayer.ini"
    Private btePlayer As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_player.ini"
    Private parameters As String() = {"[name]", "[model]"}
    Private parameters2 As String() = {"[name]", "[model]", "[team]", "[sex]", "[hand]", "[radio]", "[tattoo]", "[emotion]"}
    Private items As New ListViewItem()
    Public selModel As String = ""

    'Equipment Set
    Public mHook As String = My.Application.Info.DirectoryPath & "\metahook\teamsuit.ini"
    Public launcher As String = My.Application.Info.DirectoryPath & "\launcher\vault\bte_wpn.ini"
    Public pri1m As String = ReadIniValue(mHook, "TeamSuit1", "Primary")
    Public sec1m As String = ReadIniValue(mHook, "TeamSuit1", "Secondary")
    Public mel1m As String = ReadIniValue(mHook, "TeamSuit1", "Knife")
    Public gre1m As String = ReadIniValue(mHook, "TeamSuit1", "Grenade")
    Public pri2m As String = ReadIniValue(mHook, "TeamSuit2", "Primary")
    Public sec2m As String = ReadIniValue(mHook, "TeamSuit2", "Secondary")
    Public mel2m As String = ReadIniValue(mHook, "TeamSuit2", "Knife")
    Public gre2m As String = ReadIniValue(mHook, "TeamSuit2", "Grenade")
    Public pri3m As String = ReadIniValue(mHook, "TeamSuit3", "Primary")
    Public sec3m As String = ReadIniValue(mHook, "TeamSuit3", "Secondary")
    Public mel3m As String = ReadIniValue(mHook, "TeamSuit3", "Knife")
    Public gre3m As String = ReadIniValue(mHook, "TeamSuit3", "Grenade")
    Public fromWhere As String

    'Quick buy Set
    Public mHook2 As String = My.Application.Info.DirectoryPath & "\metahook\quickbuy.ini"
    Public bteWpnBte As String = My.Application.Info.DirectoryPath & "\launcher\vault\bte_wpn.ini"
    Public pri11m As String = ReadIniValue(mHook2, "QuickBuy1", "Primary")
    Public sec11m As String = ReadIniValue(mHook2, "QuickBuy1", "Secondary")
    Public mel11m As String = ReadIniValue(mHook2, "QuickBuy1", "Knife")
    Public gre11m As String = ReadIniValue(mHook2, "QuickBuy1", "Grenade")
    Public pri12m As String = ReadIniValue(mHook2, "QuickBuy2", "Primary")
    Public sec12m As String = ReadIniValue(mHook2, "QuickBuy2", "Secondary")
    Public mel12m As String = ReadIniValue(mHook2, "QuickBuy2", "Knife")
    Public gre12m As String = ReadIniValue(mHook2, "QuickBuy2", "Grenade")
    Public pri13m As String = ReadIniValue(mHook2, "QuickBuy3", "Primary")
    Public sec13m As String = ReadIniValue(mHook2, "QuickBuy3", "Secondary")
    Public mel13m As String = ReadIniValue(mHook2, "QuickBuy3", "Knife")
    Public gre13m As String = ReadIniValue(mHook2, "QuickBuy3", "Grenade")
    Public pri14m As String = ReadIniValue(mHook2, "QuickBuy4", "Primary")
    Public sec14m As String = ReadIniValue(mHook2, "QuickBuy4", "Secondary")
    Public mel14m As String = ReadIniValue(mHook2, "QuickBuy4", "Knife")
    Public gre14m As String = ReadIniValue(mHook2, "QuickBuy4", "Grenade")
    Public pri15m As String = ReadIniValue(mHook2, "QuickBuy5", "Primary")
    Public sec15m As String = ReadIniValue(mHook2, "QuickBuy5", "Secondary")
    Public mel15m As String = ReadIniValue(mHook2, "QuickBuy5", "Knife")
    Public gre15m As String = ReadIniValue(mHook2, "QuickBuy5", "Grenade")
#End Region

#Region "New Declare"
    Private dp As New DataParser(Core.amxmodxConfigs + "bte_wpn.ini", New String() {"[type]", "[menu]", "[model]", "[p_sub]", "[p_body]", "[w_sub]", "[w_body]", "[p_sequence]", "[sequence]", "[cswpn]", "[damage]", "[speed]", "[zoomspeed]", "[zoom]", "[clip]", "[ammo]", "[maxammo]", "[ammocost]", "[recoil]", "[spread]", "[gravity]", "[knockback]", "[knockbackh]", "[stop_speed]", "[stop_time]", "[reload]", "[deploy]", "[cost]", "[sound]", "[team]", "[buy]", "[shake]", "[dmgzb]", "[dmgzs]", "[dmghms]", "[special]", "[enhance]"})
    Private kvLang As KeyValue = KeyValue.LoadAsText(Core.resourcePath + "csbte_english.txt")
    Private lang As KeyValue
    Private iniWPN As New GetProfileString(Core.amxmodxConfigs + "bte_precachewpn.ini")
    Private reg As New Register()
    Private primary_list As New List(Of String)()
    Private secondary_list As New List(Of String)()
    Private melee_list As New List(Of String)()
    Private grenade_list As New List(Of String)()
    Private wpnListPrimary As New List(Of ucWeaponPanel)()
    Private wpnListSecondary As New List(Of ucWeaponPanel)()
    Private wpnListMelee As New List(Of ucWeaponPanel)()
    Private wpnListGrenade As New List(Of ucWeaponPanel)()
#End Region

#Region "Old Read Weapon & Class List"
    Public Sub readPrimary()
        Dim bteFormat As New BTEFormatReader(btePrimary, parameters)
        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucWpn(Qty) As ucWeapon

        For i As Integer = ucWpn.GetLowerBound(0) To ucWpn.GetUpperBound(0)
            ucWpn(i) = New ucWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList1.Controls.AddRange(ucWpn)
            With ucWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
            End With
        Next
    End Sub

    Public Sub readSecondary()
        Dim bteFormat As New BTEFormatReader(bteSecondary, parameters)
        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucWpn(Qty) As ucWeapon

        For i As Integer = ucWpn.GetLowerBound(0) To ucWpn.GetUpperBound(0)
            ucWpn(i) = New ucWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList2.Controls.AddRange(ucWpn)
            With ucWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
            End With
        Next
    End Sub

    Public Sub readMelee()
        Dim bteFormat As New BTEFormatReader(bteMelee, parameters)
        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucWpn(Qty) As ucWeapon

        For i As Integer = ucWpn.GetLowerBound(0) To ucWpn.GetUpperBound(0)
            ucWpn(i) = New ucWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList3.Controls.AddRange(ucWpn)
            With ucWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
            End With
        Next
    End Sub

    Public Sub readGrenade()
        Dim bteFormat As New BTEFormatReader(bteGrenade, parameters)
        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucWpn(Qty) As ucWeapon

        For i As Integer = ucWpn.GetLowerBound(0) To ucWpn.GetUpperBound(0)
            ucWpn(i) = New ucWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList4.Controls.AddRange(ucWpn)
            With ucWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
            End With
        Next
    End Sub

    Public Sub readSelectedPrimary()
        Dim bteFormat As New BTEFormatReader(bteMyPrimary, parameters)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyWpn(Qty) As ucMyWeapon

        For i As Integer = ucMyWpn.GetLowerBound(0) To ucMyWpn.GetUpperBound(0)
            ucMyWpn(i) = New ucMyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList11.Controls.AddRange(ucMyWpn)
            With ucMyWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = False
            End With
        Next
    End Sub

    Public Sub readSelectedSecondary()
        Dim bteFormat As New BTEFormatReader(bteMySecondary, parameters)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyWpn(Qty) As ucMyWeapon

        For i As Integer = ucMyWpn.GetLowerBound(0) To ucMyWpn.GetUpperBound(0)
            ucMyWpn(i) = New ucMyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList12.Controls.AddRange(ucMyWpn)
            With ucMyWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = False
            End With
        Next
    End Sub

    Public Sub readSelectedMelee()
        Dim bteFormat As New BTEFormatReader(bteMyMelee, parameters)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyWpn(Qty) As ucMyWeapon

        For i As Integer = ucMyWpn.GetLowerBound(0) To ucMyWpn.GetUpperBound(0)
            ucMyWpn(i) = New ucMyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList13.Controls.AddRange(ucMyWpn)
            With ucMyWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = False
            End With
        Next
    End Sub

    Public Sub readSelectedGrenade()
        Dim bteFormat As New BTEFormatReader(bteMyGrenade, parameters)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyWpn(Qty) As ucMyWeapon

        For i As Integer = ucMyWpn.GetLowerBound(0) To ucMyWpn.GetUpperBound(0)
            ucMyWpn(i) = New ucMyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList14.Controls.AddRange(ucMyWpn)
            With ucMyWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = False
            End With
        Next
    End Sub

    Public Sub readSelectedPrimary2()
        Dim bteFormat As New BTEFormatReader(bteMyPrimary, parameters)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyWpn(Qty) As ucMyWeapon

        For i As Integer = ucMyWpn.GetLowerBound(0) To ucMyWpn.GetUpperBound(0)
            ucMyWpn(i) = New ucMyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList11.Controls.AddRange(ucMyWpn)
            With ucMyWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = True
            End With
        Next
    End Sub

    Public Sub readSelectedSecondary2()
        Dim bteFormat As New BTEFormatReader(bteMySecondary, parameters)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyWpn(Qty) As ucMyWeapon

        For i As Integer = ucMyWpn.GetLowerBound(0) To ucMyWpn.GetUpperBound(0)
            ucMyWpn(i) = New ucMyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList12.Controls.AddRange(ucMyWpn)
            With ucMyWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = True
            End With
        Next
    End Sub

    Public Sub readSelectedMelee2()
        Dim bteFormat As New BTEFormatReader(bteMyMelee, parameters)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyWpn(Qty) As ucMyWeapon

        For i As Integer = ucMyWpn.GetLowerBound(0) To ucMyWpn.GetUpperBound(0)
            ucMyWpn(i) = New ucMyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList13.Controls.AddRange(ucMyWpn)
            With ucMyWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = True
            End With
        Next
    End Sub

    Public Sub readSelectedGrenade2()
        Dim bteFormat As New BTEFormatReader(bteMyGrenade, parameters)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyWpn(Qty) As ucMyWeapon

        For i As Integer = ucMyWpn.GetLowerBound(0) To ucMyWpn.GetUpperBound(0)
            ucMyWpn(i) = New ucMyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList14.Controls.AddRange(ucMyWpn)
            With ucMyWpn(i)
                .Name = "ucWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = True
            End With
        Next
    End Sub

    Public Sub readClass()
        Dim bteFormat As New BTEFormatReader(launcherPlayer, parameters2)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucClass(Qty) As ucClass

        For i As Integer = ucClass.GetLowerBound(0) To ucClass.GetUpperBound(0)
            ucClass(i) = New ucClass
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            classList.Controls.AddRange(ucClass)
            With ucClass(i)
                .Name = "ucClass" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\plyimg\" & .lbl_Use.Text & ".png")
                .sex = bteFormat(i)("sex")
                .hand = bteFormat(i)("hand")
                .team = bteFormat(i)("team")
                .radio = bteFormat(i)("radio")
                .tattoo = bteFormat(i)("tattoo")
                .emotion = bteFormat(i)("emotion")
                .PictureBox2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\plyimg\" & .team & ".png")
            End With
        Next
    End Sub

    Public Sub readSelectedClass()
        Dim bteFormat As New BTEFormatReader(launcherMyPlayer, parameters2)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyClass(Qty) As ucMyClass

        For i As Integer = ucMyClass.GetLowerBound(0) To ucMyClass.GetUpperBound(0)
            ucMyClass(i) = New ucMyClass
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            classList11.Controls.AddRange(ucMyClass)
            With ucMyClass(i)
                .Name = "ucClass" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\plyimg\" & .lbl_Use.Text & ".png")
                .sex = bteFormat(i)("sex")
                .hand = bteFormat(i)("hand")
                .team = bteFormat(i)("team")
                .radio = bteFormat(i)("radio")
                .tattoo = bteFormat(i)("tattoo")
                .emotion = bteFormat(i)("emotion")
                .PictureBox2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\plyimg\" & .team & ".png")
                .btn_Equip.Visible = False
            End With
        Next
    End Sub

    Public Sub readSelectedClass2()
        Dim bteFormat As New BTEFormatReader(launcherMyPlayer, parameters2)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucMyClass(Qty) As ucMyClass

        For i As Integer = ucMyClass.GetLowerBound(0) To ucMyClass.GetUpperBound(0)
            ucMyClass(i) = New ucMyClass
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            classList11.Controls.AddRange(ucMyClass)
            With ucMyClass(i)
                .Name = "ucClass" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\plyimg\" & .lbl_Use.Text & ".png")
                .sex = bteFormat(i)("sex")
                .hand = bteFormat(i)("hand")
                .team = bteFormat(i)("tea,")
                .radio = bteFormat(i)("radio")
                .tattoo = bteFormat(i)("tattoo")
                .emotion = bteFormat(i)("emotion")
                .PictureBox2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\plyimg\" & .team & ".png")
                .btn_Equip.Visible = False
            End With
        Next
    End Sub
#End Region

#Region "Read Weapon & Class List"
    Public Sub readBteWpn()
        'wpnList1.Select()

        For i As Integer = 0 To dp.Count - 1
            Dim wpnModel As String = dp(i)("[model]")
            Dim wpnName As String = ReadIniValue(launcher, "NAME", wpnModel)
            Dim wpnMenu As String = dp(i)("[menu]")
            Dim psub As String = dp(i)("[p_sub]")

            If wpnModel = "svdex" OrElse wpnModel = "joker_knife" OrElse wpnModel = "qbarrel" OrElse wpnModel = "ak47_long" OrElse wpnModel = "dmp7a1" OrElse wpnModel = "ddeagle" OrElse wpnModel = "poisongun" AndAlso wpnModel = "nataknifed" Then
                Exit For
            End If

            If wpnModel <> "" Then

                If wpnMenu = "1" OrElse wpnMenu = "2" OrElse wpnMenu = "3" OrElse wpnMenu = "4" OrElse wpnMenu = "5" AndAlso psub <> "p_Grenade_1" Then
                    Dim wp As New ucWeaponPanel()
                    wp.WeaponName = wpnName
                    wp.WeaponModel = wpnModel
                    wpnListPrimary.Add(wp)

                ElseIf wpnMenu = "0" Then
                    Dim wp As New ucWeaponPanel()
                    wp.WeaponName = wpnName
                    wp.WeaponModel = wpnModel
                    wpnListSecondary.Add(wp)

                ElseIf wpnMenu = "6" Then
                    Dim wp As New ucWeaponPanel()
                    wp.WeaponName = wpnName
                    wp.WeaponModel = wpnModel
                    wpnListMelee.Add(wp)

                ElseIf wpnMenu = "5" AndAlso psub = "p_Grenade_1" Then
                    Dim wp As New ucWeaponPanel()
                    wp.WeaponName = wpnName
                    wp.WeaponModel = wpnModel
                    wpnListGrenade.Add(wp)
                End If

            End If

        Next
    End Sub
#End Region

    Private Sub frmBarracks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False

        'bgPrimary.RunWorkerAsync()

        readPrimary()
        readSecondary()
        readMelee()
        readGrenade()
        readClass()

        readSelectedPrimary()
        readSelectedSecondary()
        readSelectedMelee()
        readSelectedGrenade()
        readSelectedClass()

        readEquipmentSet()
        readQuickBuy()

        readBteWpn()

        frmLoading.CircularProgress1.Value = 100
    End Sub

#Region "Read Equipment & Fast Buy"
    Private Sub readEquipmentSet()
        Dim pri1n As String = ReadIniValue(launcher, "NAME", pri1m)
        Dim sec1n As String = ReadIniValue(launcher, "NAME", sec1m)
        Dim mel1n As String = ReadIniValue(launcher, "NAME", mel1m)
        Dim gre1n As String = ReadIniValue(launcher, "NAME", gre1m)
        Dim pri2n As String = ReadIniValue(launcher, "NAME", pri2m)
        Dim sec2n As String = ReadIniValue(launcher, "NAME", sec2m)
        Dim mel2n As String = ReadIniValue(launcher, "NAME", mel2m)
        Dim gre2n As String = ReadIniValue(launcher, "NAME", gre2m)
        Dim pri3n As String = ReadIniValue(launcher, "NAME", pri3m)
        Dim sec3n As String = ReadIniValue(launcher, "NAME", sec3m)
        Dim mel3n As String = ReadIniValue(launcher, "NAME", mel3m)
        Dim gre3n As String = ReadIniValue(launcher, "NAME", gre3m)

        pb_PriWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & pri1m & ".png")
        pb_PriWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & pri2m & ".png")
        pb_PriWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & pri3m & ".png")
        pb_SecWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & sec1m & ".png")
        pb_SecWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & sec2m & ".png")
        pb_SecWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & sec3m & ".png")
        pb_MelWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & mel1m & ".png")
        pb_MelWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & mel2m & ".png")
        pb_MelWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & mel3m & ".png")
        pb_GreWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & gre1m & ".png")
        pb_GreWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & gre2m & ".png")
        pb_GreWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & gre3m & ".png")
        lbl_PriWpn1.Text = pri1n
        lbl_PriWpn2.Text = pri2n
        lbl_PriWpn3.Text = pri3n
        lbl_SecWpn1.Text = sec1n
        lbl_SecWpn2.Text = sec2n
        lbl_SecWpn3.Text = sec3n
        lbl_MelWpn1.Text = mel1n
        lbl_MelWpn2.Text = mel2n
        lbl_MelWpn3.Text = mel3n
        lbl_GreWpn1.Text = gre1n
        lbl_GreWpn2.Text = gre2n
        lbl_GreWpn3.Text = gre3n
    End Sub

    Private Sub readQuickBuy()
        Dim pri11n As String = ReadIniValue(bteWpnBte, "NAME", pri11m)
        Dim sec11n As String = ReadIniValue(bteWpnBte, "NAME", sec11m)
        Dim mel11n As String = ReadIniValue(bteWpnBte, "NAME", mel11m)
        Dim gre11n As String = ReadIniValue(bteWpnBte, "NAME", gre11m)
        Dim pri12n As String = ReadIniValue(bteWpnBte, "NAME", pri12m)
        Dim sec12n As String = ReadIniValue(bteWpnBte, "NAME", sec12m)
        Dim mel12n As String = ReadIniValue(bteWpnBte, "NAME", mel12m)
        Dim gre12n As String = ReadIniValue(bteWpnBte, "NAME", gre12m)
        Dim pri13n As String = ReadIniValue(bteWpnBte, "NAME", pri13m)
        Dim sec13n As String = ReadIniValue(bteWpnBte, "NAME", sec13m)
        Dim mel13n As String = ReadIniValue(bteWpnBte, "NAME", mel13m)
        Dim gre13n As String = ReadIniValue(bteWpnBte, "NAME", gre13m)
        Dim pri14n As String = ReadIniValue(bteWpnBte, "NAME", pri14m)
        Dim sec14n As String = ReadIniValue(bteWpnBte, "NAME", sec14m)
        Dim mel14n As String = ReadIniValue(bteWpnBte, "NAME", mel14m)
        Dim gre14n As String = ReadIniValue(bteWpnBte, "NAME", gre14m)
        Dim pri15n As String = ReadIniValue(bteWpnBte, "NAME", pri15m)
        Dim sec15n As String = ReadIniValue(bteWpnBte, "NAME", sec15m)
        Dim mel15n As String = ReadIniValue(bteWpnBte, "NAME", mel15m)
        Dim gre15n As String = ReadIniValue(bteWpnBte, "NAME", gre15m)

        pb_PriWpn11.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & pri11m & ".png")
        pb_PriWpn12.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & pri12m & ".png")
        pb_PriWpn13.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & pri13m & ".png")
        pb_PriWpn14.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & pri14m & ".png")
        pb_PriWpn15.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & pri15m & ".png")
        pb_SecWpn11.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & sec11m & ".png")
        pb_SecWpn12.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & sec12m & ".png")
        pb_SecWpn13.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & sec13m & ".png")
        pb_SecWpn14.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & sec14m & ".png")
        pb_SecWpn15.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & sec15m & ".png")
        pb_MelWpn11.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & mel11m & ".png")
        pb_MelWpn12.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & mel12m & ".png")
        pb_MelWpn13.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & mel13m & ".png")
        pb_MelWpn14.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & mel14m & ".png")
        pb_MelWpn15.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & mel15m & ".png")
        pb_GreWpn11.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & gre11m & ".png")
        pb_GreWpn12.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & gre12m & ".png")
        pb_GreWpn13.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & gre13m & ".png")
        pb_GreWpn14.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & gre14m & ".png")
        pb_GreWpn15.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & gre15m & ".png")
        lbl_PriWpn11.Text = pri11n
        lbl_PriWpn12.Text = pri12n
        lbl_PriWpn13.Text = pri13n
        lbl_PriWpn14.Text = pri14n
        lbl_PriWpn15.Text = pri15n
        lbl_SecWpn11.Text = sec11n
        lbl_SecWpn12.Text = sec12n
        lbl_SecWpn13.Text = sec13n
        lbl_SecWpn14.Text = sec14n
        lbl_SecWpn15.Text = sec15n
        lbl_MelWpn11.Text = mel11n
        lbl_MelWpn12.Text = mel12n
        lbl_MelWpn13.Text = mel13n
        lbl_MelWpn14.Text = mel14n
        lbl_MelWpn15.Text = mel15n
        lbl_GreWpn11.Text = gre11n
        lbl_GreWpn12.Text = gre12n
        lbl_GreWpn13.Text = gre13n
        lbl_GreWpn14.Text = gre14n
        lbl_GreWpn15.Text = gre15n
    End Sub
#End Region

    Public Sub refreshCtrls()
        pb_Damage.Width = 0
        pb_HitRate.Width = 0
        pb_Reaction.Width = 0
        pb_FiringSpeed.Width = 0
        pb_Weight.Width = 0
    End Sub

#Region "Barracks Buttons & Tab Controls"
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If SuperTabControl1.SelectedTab Is SuperTabItem1 Then
            WriteIniValue(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_precachewpn.ini", "My Weapons", "RIFLES", selModel.ToString)
            Dim myPri As String = My.Application.Info.DirectoryPath & "\launcher\vault\pri_mywpn.ini"
            Dim SW As New System.IO.StreamWriter(myPri)
            For Each myPriItem As ListViewItem In lv_SelPrimary.Items
                SW.Write("[name]" & myPriItem.Text & "[model]" & myPriItem.SubItems(1).Text & Environment.NewLine)
            Next
            SW.Close()
            wpnList11.Controls.Clear()
            readSelectedPrimary()
            SuperTabControl2.SelectedTab = SuperTabItem7
            SuperTabControl3.SelectedTab = SuperTabItem8
        ElseIf SuperTabControl1.SelectedTab Is SuperTabItem2 Then
            WriteIniValue(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_precachewpn.ini", "My Weapons", "PISTOLS", selModel.ToString)
            Dim mySec As String = My.Application.Info.DirectoryPath & "\launcher\vault\sec_mywpn.ini"
            Dim SW As New System.IO.StreamWriter(mySec)
            For Each mySecItem As ListViewItem In lv_SelSecondary.Items
                SW.Write("[name]" & mySecItem.Text & "[model]" & mySecItem.SubItems(1).Text & Environment.NewLine)
            Next
            SW.Close()
            wpnList12.Controls.Clear()
            readSelectedSecondary()
            SuperTabControl2.SelectedTab = SuperTabItem7
            SuperTabControl3.SelectedTab = SuperTabItem10
        ElseIf SuperTabControl1.SelectedTab Is SuperTabItem3 Then
            WriteIniValue(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_precachewpn.ini", "My Weapons", "KNIFES", selModel.ToString)
            Dim myMel As String = My.Application.Info.DirectoryPath & "\launcher\vault\mel_mywpn.ini"
            Dim SW As New System.IO.StreamWriter(myMel)
            For Each myMelItem As ListViewItem In lv_SelMelee.Items
                SW.Write("[name]" & myMelItem.Text & "[model]" & myMelItem.SubItems(1).Text & Environment.NewLine)
            Next
            SW.Close()
            wpnList13.Controls.Clear()
            readSelectedMelee()
            SuperTabControl2.SelectedTab = SuperTabItem7
            SuperTabControl3.SelectedTab = SuperTabItem12
        ElseIf SuperTabControl1.SelectedTab Is SuperTabItem4 Then
            WriteIniValue(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_precachewpn.ini", "My Weapons", "HEGRENADES", selModel.ToString)
            Dim myGre As String = My.Application.Info.DirectoryPath & "\launcher\vault\gre_mywpn.ini"
            Dim SW As New System.IO.StreamWriter(myGre)
            For Each myGreItem As ListViewItem In lv_SelGrenades.Items
                SW.Write("[name]" & myGreItem.Text & "[model]" & myGreItem.SubItems(1).Text & Environment.NewLine)
            Next
            SW.Write("[name]HE Grenade[model]hegrenade" & Environment.NewLine)
            SW.Close()
            wpnList14.Controls.Clear()
            readSelectedGrenade()
            SuperTabControl2.SelectedTab = SuperTabItem7
            SuperTabControl3.SelectedTab = SuperTabItem11
        ElseIf SuperTabControl1.SelectedTab Is SuperTabItem9 Then
            Try
                System.IO.File.Delete(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_player.ini")
                System.IO.File.Create(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_player.ini").Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Dim myPlayer As String = My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_player.ini"
            Dim myPlayer2 As String = My.Application.Info.DirectoryPath & "\launcher\vault\myplayer.ini"
            Dim SW As New System.IO.StreamWriter(myPlayer)
            Dim SW2 As New System.IO.StreamWriter(myPlayer2)
            SW.Write("SET_MODEL_INDEX = 1" & Environment.NewLine)

            For Each myPlayerItem As ListViewItem In lv_MyPlayer.Items
                SW.WriteLine("[name]" & myPlayerItem.Text & "[model]" & myPlayerItem.SubItems(1).Text & "[team]" & myPlayerItem.SubItems(2).Text & _
                          "[sex]" & myPlayerItem.SubItems(3).Text & "[hand]" & myPlayerItem.SubItems(4).Text & "[radio]" & myPlayerItem.SubItems(5).Text & _
                          "[tattoo]" & myPlayerItem.SubItems(6).Text & "[emotion]" & myPlayerItem.SubItems(7).Text)
            Next
            SW.Close()

            For Each myPlayerItem As ListViewItem In lv_MyPlayer.Items
                SW2.Write("[name]" & myPlayerItem.Text & "[model]" & myPlayerItem.SubItems(1).Text & "[team]" & myPlayerItem.SubItems(2).Text & _
                              "[sex]" & myPlayerItem.SubItems(3).Text & "[hand]" & myPlayerItem.SubItems(4).Text & "[radio]" & myPlayerItem.SubItems(5).Text & _
                              "[tattoo]" & myPlayerItem.SubItems(6).Text & "[emotion]" & myPlayerItem.SubItems(6).Text & Environment.NewLine)
            Next
            SW2.Close()
            classList11.Controls.Clear()
            readSelectedClass()
            SuperTabControl2.SelectedTab = SuperTabItem7
            SuperTabControl3.SelectedTab = SuperTabItem13
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        If selModel = "" Then
            Exit Sub
        Else
            If SuperTabControl1.SelectedTab Is SuperTabItem1 Then
                txt_SelName.Text = ""
                selModel = ""
                lbl_SelWpn.Text = "0"
                lv_SelPrimary.Items.Clear()
                lbl_SelWpn.ForeColor = Color.White
            ElseIf SuperTabControl1.SelectedTab Is SuperTabItem2 Then
                txt_SelName.Text = ""
                selModel = ""
                lbl_SelWpn.Text = "0"
                lv_SelSecondary.Items.Clear()
                lbl_SelWpn.ForeColor = Color.White
            ElseIf SuperTabControl1.SelectedTab Is SuperTabItem3 Then
                txt_SelName.Text = ""
                selModel = ""
                lbl_SelWpn.Text = "0"
                lv_SelMelee.Items.Clear()
                lbl_SelWpn.ForeColor = Color.White
            ElseIf SuperTabControl1.SelectedTab Is SuperTabItem4 Then
                txt_SelName.Text = ""
                selModel = ""
                lbl_SelWpn.Text = "0"
                lv_SelGrenades.Items.Clear()
                lbl_SelWpn.ForeColor = Color.White
            ElseIf SuperTabControl1.SelectedTab Is SuperTabItem9 Then
                txt_SelName.Text = ""
                selModel = ""
                lbl_SelWpn.Text = "0"
                lv_SelGrenades.Items.Clear()
                lbl_SelWpn.ForeColor = Color.White
            End If
            'wpnList1.Controls.Clear()
            'wpnList2.Controls.Clear()
            'wpnList3.Controls.Clear()
            'wpnList4.Controls.Clear()
            'classList.Controls.Clear()
            'wpnList11.Controls.Clear()
            'wpnList12.Controls.Clear()
            'wpnList13.Controls.Clear()
            'wpnList14.Controls.Clear()
            'classList11.Controls.Clear()
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTab Is SuperTabItem1 Then
            txt_SelName.Text = ""
            selModel = ""
            lbl_SelWpn.Text = "0"
            lv_SelPrimary.Items.Clear()
            lbl_SelWpn.ForeColor = Color.White
            lbl_Note.Text = "Please Choose 30 of your favorite Primary Weapon."
        ElseIf SuperTabControl1.SelectedTab Is SuperTabItem2 Then
            txt_SelName.Text = ""
            selModel = ""
            lbl_SelWpn.Text = "0"
            lv_SelSecondary.Items.Clear()
            lbl_SelWpn.ForeColor = Color.White
            lbl_Note.Text = "Please Choose 10 of your favorite Secondary Weapon."
        ElseIf SuperTabControl1.SelectedTab Is SuperTabItem3 Then
            txt_SelName.Text = ""
            selModel = ""
            lbl_SelWpn.Text = "0"
            lv_SelMelee.Items.Clear()
            lbl_SelWpn.ForeColor = Color.White
            lbl_Note.Text = "Please Choose 5 of your favorite Melee Weapon."
        ElseIf SuperTabControl1.SelectedTab Is SuperTabItem4 Then
            txt_SelName.Text = ""
            selModel = ""
            lbl_SelWpn.Text = "0"
            lv_SelGrenades.Items.Clear()
            lbl_SelWpn.ForeColor = Color.White
            lbl_Note.Text = "Please Choose 5 of your favorite Grenade."
        ElseIf SuperTabControl1.SelectedTab Is SuperTabItem9 Then
            txt_SelName.Text = ""
            selModel = ""
            lbl_SelWpn.Text = "0"
            lv_MyPlayer.Items.Clear()
            lbl_SelWpn.ForeColor = Color.White
            lbl_Note.Text = "Please Choose 20 of your favorite CT && Terrorist Class."
        End If
    End Sub

    Private Sub SuperTabControl3_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl3.SelectedTabChanged
        txt_SelName.Text = ""
        selModel = ""
        lbl_SelWpn.Text = "0"
        lv_SelPrimary.Items.Clear()
        lv_SelSecondary.Items.Clear()
        lv_SelMelee.Items.Clear()
        lv_SelGrenades.Items.Clear()

        lbl_SelWpn.ForeColor = Color.White
        lbl_Note.Text = " "
    End Sub

    Private Sub lblEnd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblEnd.LinkClicked
        frmMenu.Show()
        Me.Close()
    End Sub
#End Region

#Region "Save Fast Buy & Equipment Set"
    Private Sub btnSaveEq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveEq.Click
        WriteIniValue2(mHook, "TeamSuit1", "Primary", pri1m)
        WriteIniValue2(mHook, "TeamSuit2", "Primary", pri2m)
        WriteIniValue2(mHook, "TeamSuit3", "Primary", pri3m)
        WriteIniValue2(mHook, "TeamSuit1", "Secondary", sec1m)
        WriteIniValue2(mHook, "TeamSuit2", "Secondary", sec2m)
        WriteIniValue2(mHook, "TeamSuit3", "Secondary", sec3m)
        WriteIniValue2(mHook, "TeamSuit1", "Knife", mel1m)
        WriteIniValue2(mHook, "TeamSuit2", "Knife", mel2m)
        WriteIniValue2(mHook, "TeamSuit3", "Knife", mel3m)
        WriteIniValue2(mHook, "TeamSuit1", "Grenade", gre1m)
        WriteIniValue2(mHook, "TeamSuit2", "Grenade", gre2m)
        WriteIniValue2(mHook, "TeamSuit3", "Grenade", gre3m)
        SuperTabControl4.SelectedTab = SuperTabItem15
    End Sub

    Private Sub btnSaveFB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFB.Click
        WriteIniValue2(mHook2, "QuickBuy1", "Primary", pri11m)
        WriteIniValue2(mHook2, "QuickBuy2", "Primary", pri12m)
        WriteIniValue2(mHook2, "QuickBuy3", "Primary", pri13m)
        WriteIniValue2(mHook2, "QuickBuy4", "Primary", pri14m)
        WriteIniValue2(mHook2, "QuickBuy5", "Primary", pri15m)
        WriteIniValue2(mHook2, "QuickBuy1", "Secondary", sec11m)
        WriteIniValue2(mHook2, "QuickBuy2", "Secondary", sec12m)
        WriteIniValue2(mHook2, "QuickBuy3", "Secondary", sec13m)
        WriteIniValue2(mHook2, "QuickBuy4", "Secondary", sec14m)
        WriteIniValue2(mHook2, "QuickBuy5", "Secondary", sec15m)
        WriteIniValue2(mHook2, "QuickBuy1", "Knife", mel11m)
        WriteIniValue2(mHook2, "QuickBuy2", "Knife", mel12m)
        WriteIniValue2(mHook2, "QuickBuy3", "Knife", mel13m)
        WriteIniValue2(mHook2, "QuickBuy4", "Knife", mel14m)
        WriteIniValue2(mHook2, "QuickBuy5", "Knife", mel15m)
        WriteIniValue2(mHook2, "QuickBuy1", "Grenade", gre11m)
        WriteIniValue2(mHook2, "QuickBuy2", "Grenade", gre12m)
        WriteIniValue2(mHook2, "QuickBuy3", "Grenade", gre13m)
        WriteIniValue2(mHook2, "QuickBuy4", "Grenade", gre14m)
        WriteIniValue2(mHook2, "QuickBuy5", "Grenade", gre15m)
        SuperTabControl4.SelectedTab = SuperTabItem15
    End Sub
#End Region

#Region "Fast Buy & Equipment Set Picture Box Click Event"
    Private Sub pb_PriWpn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_PriWpn1.Click
        fromWhere = "pri1e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem8
        wpnList11.Controls.Clear()
        readSelectedPrimary2()
    End Sub

    Private Sub pb_PriWpn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_PriWpn2.Click
        fromWhere = "pri2e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem8
        wpnList11.Controls.Clear()
        readSelectedPrimary2()
    End Sub

    Private Sub pb_PriWpn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_PriWpn3.Click
        fromWhere = "pri3e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem8
        wpnList11.Controls.Clear()
        readSelectedPrimary2()
    End Sub

    Private Sub pb_SecWpn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_SecWpn1.Click
        fromWhere = "sec1e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem10
        wpnList12.Controls.Clear()
        readSelectedSecondary2()
    End Sub

    Private Sub pb_SecWpn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_SecWpn2.Click
        fromWhere = "sec2e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem10
        wpnList12.Controls.Clear()
        readSelectedSecondary2()
    End Sub

    Private Sub pb_SecWpn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_SecWpn3.Click
        fromWhere = "sec3e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem10
        wpnList12.Controls.Clear()
        readSelectedSecondary2()
    End Sub

    Private Sub pb_MelWpn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_MelWpn1.Click
        fromWhere = "mel1e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem12
        wpnList13.Controls.Clear()
        readSelectedMelee2()
    End Sub

    Private Sub pb_MelWpn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_MelWpn2.Click
        fromWhere = "mel2e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem12
        wpnList13.Controls.Clear()
        readSelectedMelee2()
    End Sub

    Private Sub pb_MelWpn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_MelWpn3.Click
        fromWhere = "mel3e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem12
        wpnList13.Controls.Clear()
        readSelectedMelee2()
    End Sub

    Private Sub pb_GreWpn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_GreWpn1.Click
        fromWhere = "gre1e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem11
        wpnList14.Controls.Clear()
        readSelectedGrenade2()
    End Sub

    Private Sub pb_GreWpn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_GreWpn2.Click
        fromWhere = "gre2e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem11
        wpnList14.Controls.Clear()
        readSelectedGrenade2()
    End Sub

    Private Sub pb_GreWpn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_GreWpn3.Click
        fromWhere = "gre3e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem11
        wpnList14.Controls.Clear()
        readSelectedGrenade2()
    End Sub

    Private Sub pb_PriWpn11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_PriWpn11.Click
        fromWhere = "pri11e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem8
        wpnList11.Controls.Clear()
        readSelectedPrimary2()
    End Sub

    Private Sub pb_PriWpn12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_PriWpn12.Click
        fromWhere = "pri12e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem8
        wpnList11.Controls.Clear()
        readSelectedPrimary2()
    End Sub

    Private Sub pb_PriWpn13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_PriWpn13.Click
        fromWhere = "pri13e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem8
        wpnList11.Controls.Clear()
        readSelectedPrimary2()
    End Sub

    Private Sub pb_PriWpn14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_PriWpn14.Click
        fromWhere = "pri14e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem8
        wpnList11.Controls.Clear()
        readSelectedPrimary2()
    End Sub

    Private Sub pb_PriWpn15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_PriWpn15.Click
        fromWhere = "pri15e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem8
        wpnList11.Controls.Clear()
        readSelectedPrimary2()
    End Sub

    Private Sub pb_SecWpn11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_SecWpn11.Click
        fromWhere = "sec11e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem10
        wpnList12.Controls.Clear()
        readSelectedSecondary2()
    End Sub

    Private Sub pb_SecWpn12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_SecWpn12.Click
        fromWhere = "sec12e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem10
        wpnList12.Controls.Clear()
        readSelectedSecondary2()
    End Sub

    Private Sub pb_SecWpn13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_SecWpn13.Click
        fromWhere = "sec13e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem10
        wpnList12.Controls.Clear()
        readSelectedSecondary2()
    End Sub

    Private Sub pb_SecWpn14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_SecWpn14.Click
        fromWhere = "sec14e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem10
        wpnList12.Controls.Clear()
        readSelectedSecondary2()
    End Sub

    Private Sub pb_SecWpn15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_SecWpn15.Click
        fromWhere = "sec15e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem10
        wpnList12.Controls.Clear()
        readSelectedSecondary2()
    End Sub

    Private Sub pb_MelWpn11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_MelWpn11.Click
        fromWhere = "mel11e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem12
        wpnList13.Controls.Clear()
        readSelectedMelee2()
    End Sub

    Private Sub pb_MelWpn12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_MelWpn12.Click
        fromWhere = "mel12e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem12
        wpnList13.Controls.Clear()
        readSelectedMelee2()
    End Sub

    Private Sub pb_MelWpn13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_MelWpn13.Click
        fromWhere = "mel13e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem12
        wpnList13.Controls.Clear()
        readSelectedMelee2()
    End Sub

    Private Sub pb_MelWpn14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_MelWpn14.Click
        fromWhere = "mel14e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem12
        wpnList13.Controls.Clear()
        readSelectedMelee2()
    End Sub

    Private Sub pb_MelWpn15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_MelWpn15.Click
        fromWhere = "mel15e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem12
        wpnList13.Controls.Clear()
        readSelectedMelee2()
    End Sub

    Private Sub pb_GreWpn11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_GreWpn11.Click
        fromWhere = "gre11e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem11
        wpnList14.Controls.Clear()
        readSelectedGrenade2()
    End Sub

    Private Sub pb_GreWpn12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_GreWpn12.Click
        fromWhere = "gre12e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem11
        wpnList14.Controls.Clear()
        readSelectedGrenade2()
    End Sub

    Private Sub pb_GreWpn13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_GreWpn13.Click
        fromWhere = "gre13e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem11
        wpnList14.Controls.Clear()
        readSelectedGrenade2()
    End Sub

    Private Sub pb_GreWpn14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_GreWpn14.Click
        fromWhere = "gre14e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem11
        wpnList14.Controls.Clear()
        readSelectedGrenade2()
    End Sub

    Private Sub pb_GreWpn15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_GreWpn15.Click
        fromWhere = "gre15e"
        SuperTabControl2.SelectedTab = SuperTabItem7
        SuperTabControl3.SelectedTab = SuperTabItem11
        wpnList14.Controls.Clear()
        readSelectedGrenade2()
    End Sub
#End Region

    Private Sub bgPrimary_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgPrimary.DoWork
        readPrimary()
    End Sub

    Private Sub bgPrimary_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgPrimary.ProgressChanged
        bgCP.Value = e.ProgressPercentage
        lblLoadText.Text = "Reading Primary Weapons...(" & bgCP.Value & "%)"
    End Sub
End Class