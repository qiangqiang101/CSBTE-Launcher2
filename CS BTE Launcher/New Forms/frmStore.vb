Public Class frmStore

#Region "Declare"
    'Store
    Private btePrimary As String = My.Application.Info.DirectoryPath & "\launcher\vault\pri_wpn_shop.ini"
    Private bteSecondary As String = My.Application.Info.DirectoryPath & "\launcher\vault\sec_wpn_shop.ini"
    Private bteMelee As String = My.Application.Info.DirectoryPath & "\launcher\vault\mel_wpn_shop.ini"
    Private bteGrenade As String = My.Application.Info.DirectoryPath & "\launcher\vault\gre_wpn_shop.ini"
    Private btePlayer As String = My.Application.Info.DirectoryPath & "\launcher\vault\player_shop.ini"
    Private parameters As String() = {"[name]", "[model]", "[point]", "[cash]", "[buy]"}
    Private parameters2 As String() = {"[name]", "[model]", "[team]", "[sex]", "[hand]", "[radio]", "[tattoo]", "[emotion]", "[point]", "[cash]", "[buy]"}
    Private items As New ListViewItem()
    Private bteSave As String = My.Application.Info.DirectoryPath & "\launcher\vault\bte_save.ini"
#End Region


    Public Sub refreshCtrls()
        pb_Damage.Width = 0
        pb_HitRate.Width = 0
        pb_Reaction.Width = 0
        pb_FiringSpeed.Width = 0
        pb_Weight.Width = 0
    End Sub


#Region "Read Weapon & Class List"
    Public Sub readPrimary()
        Dim bteFormat As New BTEFormatReader(btePrimary, parameters)
        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucBuyWpn(Qty) As ucBuyWeapon

        For i As Integer = ucBuyWpn.GetLowerBound(0) To ucBuyWpn.GetUpperBound(0)
            ucBuyWpn(i) = New ucBuyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList1.Controls.AddRange(ucBuyWpn)
            With ucBuyWpn(i)
                .Name = "ucBuyWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .model = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .model & ".png")
                .point = bteFormat(i)("point")
                .cash = bteFormat(i)("cash")
                .buy = bteFormat(i)("buy")
                If .point = "0" Then
                    .lbl_Use.Text = .cash.ToString & "Cash"
                ElseIf .cash = "0" Then
                    .lbl_Use.Text = .point.ToString & "Point"
                Else
                    .lbl_Use.Text = "FREE"
                End If
                If .buy = "1" Then
                    .btn_Equip.Visible = False
                ElseIf .buy = "0" Then
                    .btn_Equip.Visible = True
                End If
            End With
        Next
    End Sub

    Public Sub readSecondary()
        Dim bteFormat As New BTEFormatReader(bteSecondary, parameters)
        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucBuyWpn(Qty) As ucBuyWeapon

        For i As Integer = ucBuyWpn.GetLowerBound(0) To ucBuyWpn.GetUpperBound(0)
            ucBuyWpn(i) = New ucBuyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList2.Controls.AddRange(ucBuyWpn)
            With ucBuyWpn(i)
                .Name = "ucBuyWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .model = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .model & ".png")
                .point = bteFormat(i)("point")
                .cash = bteFormat(i)("cash")
                .buy = bteFormat(i)("buy")
                If .point = "0" Then
                    .lbl_Use.Text = .cash.ToString & "Cash"
                ElseIf .cash = "0" Then
                    .lbl_Use.Text = .point.ToString & "Point"
                Else
                    .lbl_Use.Text = "FREE"
                End If
                If .buy = "1" Then
                    .btn_Equip.Visible = False
                ElseIf .buy = "0" Then
                    .btn_Equip.Visible = True
                End If
            End With
        Next
    End Sub

    Public Sub readMelee()
        Dim bteFormat As New BTEFormatReader(bteMelee, parameters)
        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucBuyWpn(Qty) As ucBuyWeapon

        For i As Integer = ucBuyWpn.GetLowerBound(0) To ucBuyWpn.GetUpperBound(0)
            ucBuyWpn(i) = New ucBuyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList3.Controls.AddRange(ucBuyWpn)
            With ucBuyWpn(i)
                .Name = "ucBuyWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .model = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .model & ".png")
                .point = bteFormat(i)("point")
                .cash = bteFormat(i)("cash")
                .buy = bteFormat(i)("buy")
                If .point = "0" Then
                    .lbl_Use.Text = .cash.ToString & "Cash"
                ElseIf .cash = "0" Then
                    .lbl_Use.Text = .point.ToString & "Point"
                Else
                    .lbl_Use.Text = "FREE"
                End If
                If .buy = "1" Then
                    .btn_Equip.Visible = False
                ElseIf .buy = "0" Then
                    .btn_Equip.Visible = True
                End If
            End With
        Next
    End Sub

    Public Sub readGrenade()
        Dim bteFormat As New BTEFormatReader(bteGrenade, parameters)
        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucBuyWpn(Qty) As ucBuyWeapon

        For i As Integer = ucBuyWpn.GetLowerBound(0) To ucBuyWpn.GetUpperBound(0)
            ucBuyWpn(i) = New ucBuyWeapon
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            wpnList4.Controls.AddRange(ucBuyWpn)
            With ucBuyWpn(i)
                .Name = "ucBuyWeapon" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .model = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & .model & ".png")
                .point = bteFormat(i)("point")
                .cash = bteFormat(i)("cash")
                .buy = bteFormat(i)("buy")
                If .point = "0" Then
                    .lbl_Use.Text = .cash.ToString & "Cash"
                ElseIf .cash = "0" Then
                    .lbl_Use.Text = .point.ToString & "Point"
                Else
                    .lbl_Use.Text = "FREE"
                End If
                If .buy = "1" Then
                    .btn_Equip.Visible = False
                ElseIf .buy = "0" Then
                    .btn_Equip.Visible = True
                End If
            End With
        Next
    End Sub

    Public Sub readClass()
        Dim bteFormat As New BTEFormatReader(btePlayer, parameters2)

        Dim Qty As Integer = bteFormat.Count - 1
        Dim ucBuyClass(Qty) As ucBuyClass

        For i As Integer = ucBuyClass.GetLowerBound(0) To ucBuyClass.GetUpperBound(0)
            ucBuyClass(i) = New ucBuyClass
        Next

        For i As Integer = 0 To bteFormat.Count - 1
            classList.Controls.AddRange(ucBuyClass)
            With ucBuyClass(i)
                .Name = "ucClass" + i.ToString
                .lbl_Name.Text = bteFormat(i)("name")
                .model = bteFormat(i)("model")
                '.lbl_Use.Text = bteFormat(i)("model")
                .PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\plyimg\" & .model & ".png")
                .sex = bteFormat(i)("sex")
                .hand = bteFormat(i)("hand")
                .team = bteFormat(i)("team")
                .radio = bteFormat(i)("radio")
                .tattoo = bteFormat(i)("tattoo")
                .emotion = bteFormat(i)("emotion")
                .PictureBox2.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\plyimg\" & .team & ".png")
                .point = bteFormat(i)("point")
                .cash = bteFormat(i)("cash")
                .buy = bteFormat(i)("buy")
                If .point = "0" Then
                    .lbl_Use.Text = .cash.ToString & "Cash"
                ElseIf .cash = "0" Then
                    .lbl_Use.Text = .point.ToString & "Point"
                Else
                    .lbl_Use.Text = "FREE"
                End If
                If .buy = "1" Then
                    .btn_Equip.Visible = False
                ElseIf .buy = "0" Then
                    .btn_Equip.Visible = True
                End If
            End With
        Next
    End Sub
#End Region

    Private Sub frmStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        readPrimary()
        readSecondary()
        readMelee()
        readGrenade()
        readClass()
        txtPoint.Text = My.Settings.User_Points
        txtCash.Text = My.Settings.User_Cash
    End Sub

    Private Sub lblEnd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblEnd.LinkClicked
        frmMenu.Show()
        Me.Close()
    End Sub
End Class