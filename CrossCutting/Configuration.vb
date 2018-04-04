Public Class Configuration

    Private _companyName As String
    Private _server As String
    Private _port As UInt16
    Private _userName As String
    Private _password As String
    Private _database As String

    Public Property companyName() As String
        Get
            Return _companyName
        End Get
        Set(ByVal value As String)
            Try
                _companyName = stringChecker(value, 50)
            Catch sqliex As SQLInjectionException
                sqliex.overrideMessage("`Company Name`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Company Name`" & bex.Message)
                Throw bex
            End Try
        End Set
    End Property

    Public Property server() As String
        Get
            Return _server
        End Get
        Set(ByVal value As String)
            Try
                _server = stringChecker(value, 50).ToLower
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw a BusinessException
                'Logger.possibleSQLInjection(value, sqliex.StackTrace)
                sqliex.overrideMessage("`Server name`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Server name`" & bex.Message)
                Throw bex
            End Try
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
            Try
                _userName = stringChecker(value, 50)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw a BusinessException
                'Logger.possibleSQLInjection(value, sqliex.StackTrace)
                sqliex.overrideMessage("`User Name`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`User Name`" & bex.Message)
                Throw bex
            End Try

        End Set
    End Property

    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            Try
                _password = stringChecker(value, 50)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw a BusinessException
                'Logger.possibleSQLInjection(value, sqliex.StackTrace)
                sqliex.overrideMessage("`Password`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Password`" & bex.Message)
                Throw bex
            End Try
        End Set
    End Property

    Public Property database() As String
        Get
            Return _database
        End Get
        Set(ByVal value As String)
            Try
                _database = stringChecker(value, 50).ToLower
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw a BusinessException
                'Logger.possibleSQLInjection(value, sqliex.StackTrace)
                sqliex.overrideMessage("`Database`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Database`" & bex.Message)
                Throw bex
            End Try
        End Set
    End Property

    Public Sub canUseThisConfig()
        Try
            REQUIRED(server)
        Catch bex As BusinessException
            bex.overrideMessage("Server is required.")
            Throw bex
        End Try

        Try
            NON_ZERO(port)
        Catch bex As BusinessException
            bex.overrideMessage("Port is required.")
            Throw bex
        End Try

        Try
            REQUIRED(username)
        Catch bex As BusinessException
            bex.overrideMessage("Username is required.")
            Throw bex
        End Try

        Try
            REQUIRED(password)
        Catch bex As BusinessException
            bex.overrideMessage("Password is required.")
            Throw bex
        End Try

        Try
            REQUIRED(database)
        Catch bex As BusinessException
            bex.overrideMessage("Database is required.")
            Throw bex
        End Try

    End Sub

    Public Sub useConfiguration()
        Try
            canUseThisConfig()
            CrossCutting_Mod.setConfiguration(Me)
        Catch bex As BusinessException
            Throw bex
        End Try

    End Sub

End Class