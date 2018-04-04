'not used
Public Class CurrentConfig
    Private _server As String
    Private _port As UInt16
    Private _userName As String
    Private _password As String
    Private _database As String

    Public Property server() As String
        Get
            Return _server
        End Get
        Set(ByVal value As String)
            _server = value
        End Set
    End Property

    Public Property port() As UShort
        Get
            Return _port
        End Get
        Set(ByVal value As UShort)
            _port = value
        End Set
    End Property

    Public Property username() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property

    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Public Property database() As String
        Get
            Return _database
        End Get
        Set(ByVal value As String)
            _database = value
        End Set
    End Property

    Public Sub useConfiguration()
        'Bridge.setConfiguration(Me)
    End Sub
End Class