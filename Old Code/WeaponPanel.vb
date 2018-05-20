
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Data
Imports System.Linq
Imports System.Text
Imports CSBTE.Core
Imports System.Windows.Forms

Namespace Launcher
	Public Partial Class WeaponPanel
		Inherits UserControl
		Private kvlang As KeyValue = KeyValue.LoadAsText("launcher\config.txt")
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property WeaponName() As String
			Get
				Return m_WeaponName
			End Get
			Set
				m_WeaponName = Value
			End Set
		End Property
		Private m_WeaponName As String
		Public Property WeaponModel() As String
			Get
				Return m_WeaponModel
			End Get
			Set
				m_WeaponModel = Value
			End Set
		End Property
		Private m_WeaponModel As String
		Private Sub WeaponPanel_Load(sender As Object, e As EventArgs)
			chk_weapon.Name = WeaponModel
			chk_weapon.Text = WeaponName
			Try
				Dim img As Image = Image.FromFile(String.Format("{0}\{1}.{2}", kvlang("WeaponImage")("path").Value, WeaponModel, kvlang("WeaponImage")("image/type").Value))
				Dim bmp As New Bitmap(img)
				pic_weapon.Image = bmp
			Catch
			End Try

		End Sub
		Private Sub chk_weapon_CheckedChanged(sender As Object)
		End Sub

		Private Sub pic_weapon_Click(sender As Object, e As EventArgs)
		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
