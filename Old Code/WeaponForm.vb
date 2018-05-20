
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports CSBTE.Core
Imports CSBTE.FileStream
Imports System.IO
Namespace Launcher
	Public Partial Class WeaponForm
		Inherits Form
		'Variables
		Private dp As New DataParser(Core.amxmodxConfigs + "bte_wpn.ini", New String() {"[type]", "[menu]", "[model]", "[p_sub]", "[p_body]", "[w_sub]", _
			"[w_body]", "[p_sequence]", "[sequence]", "[cswpn]", "[damage]", "[speed]", _
			"[zoomspeed]", "[zoom]", "[clip]", "[ammo]", "[maxammo]", "[ammocost]", _
			"[recoil]", "[spread]", "[gravity]", "[knockback]", "[knockbackh]", "[stop_speed]", _
			"[stop_time]", "[reload]", "[deploy]", "[cost]", "[sound]", "[team]", _
			"[buy]", "[shake]", "[dmgzb]", "[dmgzs]", "[dmghms]", "[special]", _
			"[enhance]"})
		Private kvLang As KeyValue = KeyValue.LoadAsText(Core.resourcePath + "csbte_english.txt")
		Private lang As KeyValue
		Private iniWPN As New GetProfileString(Core.amxmodxConfigs + "bte_precachewpn.ini")
		Private reg As New Register()
		Private button As Color() = {Color.FromArgb(64, 64, 64), Color.BlueViolet}
		Private primary_list As New List(Of String)()
		Private secondary_list As New List(Of String)()
		Private melee_list As New List(Of String)()
		Private grenade_list As New List(Of String)()
		Private wpnListPrimary As New List(Of WeaponPanel)()
		Private wpnListSecondary As New List(Of WeaponPanel)()
		Private wpnListMelee As New List(Of WeaponPanel)()
		Private wpnListGrenade As New List(Of WeaponPanel)()
		Private index As Integer = 0
		Private index2 As Integer = 0
		Private pageCount As Integer = 0
		Private MaxPages As Integer = 0
		Private ItemsPerList As Integer = 12
		Private TotalItems As Integer = 0

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub WeaponForm_Load(sender As Object, e As EventArgs)
			LoadLanguage()
			Listage()
			SetInfo()
			[Next]()
			Previous()

		End Sub

		'Init Language
		Private Sub LoadLanguage()
			Dim language As String = reg.GetKeyValue(Register.RegHKey.CURRENT_USER, "Software\Valve\Steam\", "Language", True).ToString()
			lang = KeyValue.LoadAsText("launcher\lang_english.txt")
			If language <> "english" Then
				If Not File.Exists((Convert.ToString("launcher\lang_") & language) + ".txt") Then
					lang = KeyValue.LoadAsText("launcher\lang_english.txt")
				Else
					lang = KeyValue.LoadAsText((Convert.ToString("launcher\lang_") & language) + ".txt")
				End If
			End If
			' lang = 
			Me.Text = lang("Tokens")("WINDOW_WEAPON").Value
			Me.formSkin1.Text = Me.Text
			Me.tab_primary.Text = lang("Tokens")("TAB_PRIMARY").Value
			Me.tab_secondary.Text = lang("Tokens")("TAB_SECONDARY").Value
			Me.tab_melee.Text = lang("Tokens")("TAB_MELEE").Value
			Me.tab_grenade.Text = lang("Tokens")("TAB_GRENADE").Value
			Me.btn_prev.Text = lang("Tokens")("BUTTON_PREV").Value
			Me.btn_next.Text = lang("Tokens")("BUTTON_NEXT").Value
			Me.lbl_info.Text = replace(lang("Tokens")("LABEL_PAGE").Value)
			Me.btn_save.Text = lang("Tokens")("BUTTON_SAVE").Value
		End Sub


		'Tab 
		Private Sub flatTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs)
			index = 0
			index2 = 0
			pageCount = 0
			MaxPages = 0
			TotalItems = 0
			SetInfo()
			[Next]()
			Previous()

		End Sub


		Private Sub [Next]()
			While index2 < wpnListPrimary.Count
				index = index2
				index2 += ItemsPerList
				SetItemsOnList(index, index2)
				pageCount += 1
				UpdateInfo()
				Exit While
			End While

		End Sub
		Private Sub Previous()
			While index2 <> ItemsPerList
				index = index - ItemsPerList
				index2 -= ItemsPerList
				SetItemsOnList(index, index2)
				pageCount -= 1
				UpdateInfo()
				Exit While
			End While
		End Sub

		Private Function SelectedTab(tab As TabPage) As Boolean
			If flatTabControl1.SelectedTab = tab Then
				Return True
			Else
				Return False
			End If
		End Function
		'Functions
		Private Function replace(value As String) As String
			Dim final As String = value.Replace("%currentpage%", pageCount.ToString())
			final = final.Replace("%maxpage%", MaxPages.ToString())
			Return final
		End Function
		'Weapon listage on list
		Private Sub Listage()
			wpnList1.[Select]()

			For i As Integer = 0 To dp.Count - 1
				Dim wpnModel As String = dp(i)("[model]")
				Dim wpnName As String = kvLang("Tokens")(String.Format("CSBTE_{0}", wpnModel)).Value
				If wpnName = "" OrElse wpnName Is Nothing Then
					wpnName = "CSBTE_" + wpnModel.ToUpper()
				End If
				Dim wpnMenu As String = dp(i)("[menu]")
				Dim psub As String = dp(i)("[p_sub]")

				If wpnModel = "svdex" Then
					Exit For
				End If
				If wpnModel <> "" Then
					If wpnMenu = "1" OrElse wpnMenu = "2" OrElse wpnMenu = "3" OrElse wpnMenu = "4" OrElse wpnMenu = "5" AndAlso psub <> "p_Grenade_1" Then
						Dim wp As New WeaponPanel()
						wp.WeaponName = wpnName
						wp.WeaponModel = wpnModel

						wpnListPrimary.Add(wp)
					ElseIf wpnMenu = "0" Then
						Dim wp As New WeaponPanel()
						wp.WeaponName = wpnName
						wp.WeaponModel = wpnModel
						wpnListSecondary.Add(wp)
					ElseIf wpnMenu = "6" Then
						Dim wp As New WeaponPanel()
						wp.WeaponName = wpnName
						wp.WeaponModel = wpnModel
						wpnListMelee.Add(wp)
					ElseIf wpnMenu = "5" AndAlso psub = "p_Grenade_1" Then
						Dim wp As New WeaponPanel()
						wp.WeaponName = wpnName
						wp.WeaponModel = wpnModel
						wpnListGrenade.Add(wp)
					End If

				End If
			Next
		End Sub
		'Update Info
		Private Sub SetInfo()
			If flatTabControl1.SelectedTab = tab_primary Then
				TotalItems = wpnListPrimary.Count
				MaxPages = (TotalItems \ ItemsPerList)
				If TotalItems Mod ItemsPerList <> 0 Then
					MaxPages += 1
				End If
				UpdateInfo()
			ElseIf flatTabControl1.SelectedTab = tab_secondary Then
				TotalItems = wpnListSecondary.Count
				MaxPages = (TotalItems \ ItemsPerList)
				If TotalItems Mod ItemsPerList <> 0 Then
					MaxPages += 1
				End If
				UpdateInfo()
			ElseIf flatTabControl1.SelectedTab = tab_melee Then
				TotalItems = wpnListMelee.Count
				MaxPages = (TotalItems \ ItemsPerList)
				If TotalItems Mod ItemsPerList <> 0 Then
					MaxPages += 1
				End If
				UpdateInfo()
			ElseIf flatTabControl1.SelectedTab = tab_grenade Then
				TotalItems = wpnListGrenade.Count
				MaxPages = (TotalItems \ ItemsPerList)
				If TotalItems Mod ItemsPerList <> 0 Then
					MaxPages += 1
				End If
				UpdateInfo()
			End If
		End Sub
		Private Sub UpdateInfo()
			Me.lbl_info.Text = replace(lang("Tokens")("LABEL_PAGE").Value)
		End Sub
		Private Sub SetItemsOnList(index As Integer, max As Integer)

			Try
				If SelectedTab(tab_primary) Then
					wpnList1.Controls.Clear()
					For i As Integer = index To max - 1
						wpnListPrimary(i).chk_weapon.CheckedChanged += New OwlGui.FlatUI.FlatCheckBox.CheckedChangedEventHandler(AddressOf chk_weapon_primary_CheckedChanged)
						wpnList1.Controls.Add(wpnListPrimary(i))
					Next
				ElseIf SelectedTab(tab_secondary) Then
					wpnList2.Controls.Clear()
					For i As Integer = index To max - 1
						wpnList2.Controls.Add(wpnListSecondary(i))
						wpnListSecondary(i).chk_weapon.CheckedChanged += New OwlGui.FlatUI.FlatCheckBox.CheckedChangedEventHandler(AddressOf chk_weapon_secondary_CheckedChanged)
					Next
				ElseIf SelectedTab(tab_melee) Then
					wpnList3.Controls.Clear()
					For i As Integer = index To max - 1
						wpnList3.Controls.Add(wpnListMelee(i))
						wpnListMelee(i).chk_weapon.CheckedChanged += New OwlGui.FlatUI.FlatCheckBox.CheckedChangedEventHandler(AddressOf chk_weapon_melee_CheckedChanged)
					Next
				ElseIf SelectedTab(tab_grenade) Then
					wpnList4.Controls.Clear()
					For i As Integer = index To max - 1
						wpnList4.Controls.Add(wpnListGrenade(i))
						wpnListGrenade(i).chk_weapon.CheckedChanged += New OwlGui.FlatUI.FlatCheckBox.CheckedChangedEventHandler(AddressOf chk_weapon_grenade_CheckedChanged)
					Next
				End If

			Catch
			End Try

		End Sub

		'Weapon Check Event
		Private Sub chk_weapon_primary_CheckedChanged(sender As Object)
			Dim check = DirectCast(sender, OwlGui.FlatUI.FlatCheckBox)
			If check.Checked Then
				'primary_list.Append(check.Name + ",");
				primary_list.Add(check.Name + ",")
			Else
				'primary_list.Replace(check.Name + ",", "");
				primary_list.Remove(check.Name + ",")
			End If

		End Sub
		Private Sub chk_weapon_secondary_CheckedChanged(sender As Object)
			Dim check = DirectCast(sender, OwlGui.FlatUI.FlatCheckBox)
			If check.Checked Then
				'secondary_list.Append(check.Name + ",");
				secondary_list.Add(check.Name + ",")
			Else
				'secondary_list.Replace(check.Name + ",", "");
				secondary_list.Remove(check.Name + ",")
			End If

		End Sub
		Private Sub chk_weapon_melee_CheckedChanged(sender As Object)
			Dim check = DirectCast(sender, OwlGui.FlatUI.FlatCheckBox)
			If check.Checked Then
				'melee_list.Append(check.Name + ",");
				melee_list.Add(check.Name + ",")
			Else
				'melee_list.Replace(check.Name + ",", "");
				melee_list.Remove(check.Name + ",")
			End If

		End Sub
		Private Sub chk_weapon_grenade_CheckedChanged(sender As Object)
			Dim check = DirectCast(sender, OwlGui.FlatUI.FlatCheckBox)
			If check.Checked Then
				'grenade_list.Append(check.Name + ",");
				grenade_list.Add(check.Name + ",")
			Else
				'grenade_list.Replace(check.Name + ",", "");
				grenade_list.Remove(check.Name + ",")
			End If

		End Sub


		'Buttons
		Private Sub btn_next_Click(sender As Object, e As EventArgs)
			[Next]()
		End Sub

		Private Sub btn_prev_Click(sender As Object, e As EventArgs)
			Previous()
		End Sub

		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			Close()
		End Sub

		Private Sub UpdateButton(button As Control)
			button.Visible = False
			button.Visible = True
		End Sub

		Private Sub timer1_Tick(sender As Object, e As EventArgs)
			If pageCount = 1 Then
				btn_prev.Enabled = False
				btn_prev.BaseColor = button(0)
				UpdateButton(btn_prev)
			Else
				btn_prev.Enabled = True
				btn_prev.BaseColor = button(1)
				UpdateButton(btn_prev)
			End If
			If pageCount = MaxPages Then
				btn_next.Enabled = False
				btn_next.BaseColor = button(0)
				UpdateButton(btn_next)
			Else
				btn_next.Enabled = True
				btn_next.BaseColor = button(1)
				UpdateButton(btn_next)
			End If
		End Sub

		Private Sub btn_save_Click(sender As Object, e As EventArgs)
			Try
				'String Builders
				Dim sb_primary As New StringBuilder()
				For p As Integer = 0 To primary_list.Count - 1
					sb_primary.Append(primary_list(p))
				Next
				Dim sb_secondary As New StringBuilder()
				For s As Integer = 0 To secondary_list.Count - 1
					sb_secondary.Append(secondary_list(s))
				Next
				Dim sb_melee As New StringBuilder()
				For m As Integer = 0 To melee_list.Count - 1
					sb_melee.Append(melee_list(m))
				Next
				Dim sb_grenade As New StringBuilder()
				For g As Integer = 0 To grenade_list.Count - 1
					sb_grenade.Append(grenade_list(g))
				Next
				'Write
				If sb_primary.ToString() <> String.Empty Then
					iniWPN.WriteValue("My Weapons", "RIFLES", sb_primary.ToString())
				End If
				If sb_secondary.ToString() <> String.Empty Then
					iniWPN.WriteValue("My Weapons", "PISTOLS", sb_secondary.ToString())
				End If
				If sb_melee.ToString() <> String.Empty Then
					iniWPN.WriteValue("My Weapons", "HEGRENADES", sb_grenade.ToString())
				End If
				If sb_grenade.ToString() <> String.Empty Then
					iniWPN.WriteValue("My Weapons", "KNIFES", sb_melee.ToString())
				End If
				MessageBox.Show(String.Format("Primary Weapons: {0}" & vbLf & "Secondary Weapons: {1}" & vbLf & "Melee: {2}" & vbLf & "Grenades: {3}", sb_primary.ToString(), sb_secondary.ToString(), sb_melee.ToString(), sb_grenade.ToString()))
				Me.Close()
			Catch ex As Exception
				Core.LogToFile(ex.Message)
			End Try


		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
