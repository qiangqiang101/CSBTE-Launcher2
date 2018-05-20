Imports CSBTE.Core

Public Class ucWeaponPanel

    Public Property WeaponName() As String
        Get
            Return m_WeaponName
        End Get
        Set(ByVal value As String)
            m_WeaponName = Value
        End Set
    End Property

    Public Property WeaponModel() As String
        Get
            Return m_WeaponModel
        End Get
        Set(ByVal value As String)
            m_WeaponModel = Value
        End Set
    End Property

    Private m_WeaponName As String
    Private m_WeaponModel As String

    Private Sub ucWeaponPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chk_weapon.Name = WeaponModel
        lbl_Name.Text = WeaponName
        lbl_Use.Text = WeaponModel
        Try
            Dim img As Image = Image.FromFile(My.Application.Info.DirectoryPath & "\launcher\resource\wpnimg\" & WeaponModel & ".png")
            Dim bmp As New Bitmap(img)
            PictureBox1.Image = bmp
        Catch
        End Try
    End Sub
End Class
