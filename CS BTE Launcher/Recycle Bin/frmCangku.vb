Imports System.Runtime.InteropServices

Public Class frmCangku

    'Barrack
    Private btePrimary As String = My.Application.Info.DirectoryPath & "\launcher\pri_wpn.ini"
    Private bteSecondary As String = My.Application.Info.DirectoryPath & "\launcher\sec_wpn.ini"
    Private bteMelee As String = My.Application.Info.DirectoryPath & "\launcher\mel_wpn.ini"
    Private bteGrenade As String = My.Application.Info.DirectoryPath & "\launcher\gre_wpn.ini"
    Private bteMyPrimary As String = My.Application.Info.DirectoryPath & "\launcher\pri_mywpn.ini"
    Private bteMySecondary As String = My.Application.Info.DirectoryPath & "\launcher\sec_mywpn.ini"
    Private bteMyMelee As String = My.Application.Info.DirectoryPath & "\launcher\mel_mywpn.ini"
    Private bteMyGrenade As String = My.Application.Info.DirectoryPath & "\launcher\gre_mywpn.ini"
    Private parameters As String() = {"[name]", "[model]"}
    Private items As New ListViewItem()
    Public selModel As String = ""

    'Equipment Set
    Public mHook As String = My.Application.Info.DirectoryPath & "\metahook\teamsuit.ini"
    Public launcher As String = My.Application.Info.DirectoryPath & "\launcher\bte_wpn.ini"
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

#Region "Read Weapon List"
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
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
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & .lbl_Use.Text & ".png")
                .btn_Equip.Visible = True
            End With
        Next
    End Sub
#End Region

    Private Sub btn_Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Back.Click
        Me.Hide()
    End Sub

    Private Sub frmCangku_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        readPrimary()
        readSecondary()
        readMelee()
        readGrenade()

        readSelectedPrimary()
        readSelectedSecondary()
        readSelectedMelee()
        readSelectedGrenade()

        readEquipmentSet()
    End Sub

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

        pb_PriWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & pri1m & ".png")
        pb_PriWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & pri2m & ".png")
        pb_PriWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & pri3m & ".png")
        pb_SecWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & sec1m & ".png")
        pb_SecWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & sec2m & ".png")
        pb_SecWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & sec3m & ".png")
        pb_MelWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & mel1m & ".png")
        pb_MelWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & mel2m & ".png")
        pb_MelWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & mel3m & ".png")
        pb_GreWpn1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & gre1m & ".png")
        pb_GreWpn2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & gre2m & ".png")
        pb_GreWpn3.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\wpnimg\" & gre3m & ".png")
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

    Public Sub refreshCtrls()
        pb_Damage.Value = 0
        pb_HitRate.Value = 0
        pb_Reaction.Value = 0
        pb_FiringSpeed.Value = 0
        pb_Weight.Value = 0
    End Sub

    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
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
        End If
    End Sub

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        If SuperTabControl1.SelectedTab Is SuperTabItem1 Then
            WriteIniValue(My.Application.Info.DirectoryPath & "\cstrike\addons\amxmodx\configs\bte_precachewpn.ini", "My Weapons", "RIFLES", selModel.ToString)
            Dim myPri As String = My.Application.Info.DirectoryPath & "\launcher\pri_mywpn.ini"
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
            Dim mySec As String = My.Application.Info.DirectoryPath & "\launcher\sec_mywpn.ini"
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
            Dim myMel As String = My.Application.Info.DirectoryPath & "\launcher\mel_mywpn.ini"
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
            Dim myGre As String = My.Application.Info.DirectoryPath & "\launcher\gre_mywpn.ini"
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
        End If
    End Sub

    Private Sub btn_QuickBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_QuickBuy.Click
        frmQuickBuy.Show()
        Me.Hide()
    End Sub

    Private Sub btn_TeamSuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaveEquipment.Click
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
End Class