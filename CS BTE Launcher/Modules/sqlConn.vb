Public Class sqlConn

#Region "Class Members"
    Friend WithEvents OLEConn As New System.Data.OleDb.OleDbConnection()
    Friend WithEvents OLEComm As New System.Data.OleDb.OleDbCommand()

    Private sqlString As String
    Private err As System.Exception

    Public Shared dataReturned As New ArrayList()
#End Region

#Region "class properties"

    Public Property db() As String
        Get
            db = Application.StartupPath & "\launcher\vault\Database.mdb"
        End Get
        Set(ByVal Value As String)
            Value = db
        End Set
    End Property

    Public Property xOLE() As String
        Get
            xOLE = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
        End Get
        Set(ByVal Value As String)
            Value = xOLE
        End Set
    End Property

#End Region

#Region "class methods"

    Sub New()
    End Sub

    Function connectMe(ByVal sqlString) As Boolean
        Try
            OLEConn.ConnectionString = xOLE & db
            OLEConn.Open()
            OLEComm.CommandText = sqlString
            Return True
        Catch err As System.Exception
            MsgBox(err.Message)
            Return False
        End Try
    End Function

    Function getUser() As ArrayList
        Try

            OLEComm.Connection = OLEConn

            getUser = New ArrayList()

            Dim d As OleDb.OleDbDataReader = OLEComm.ExecuteReader()
            Do While d.Read
                getUser.Add(d("UsrName".ToString))
            Loop

            'Returns array collection
            dataReturned = getUser

            Try
                OLEConn.Close()
            Catch err As System.Exception
                MsgBox(err.Message)
            End Try
        Catch err As System.Exception
            MsgBox(err.Message)
        End Try
    End Function
#End Region
End Class
