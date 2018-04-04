Option Strict On
Imports System.Data
Imports CrossCutting
Imports DataAccess
Imports BusinessLogic.BusinessEntity
Imports System.Security.Cryptography

Public Class LoginManager
    Dim dtUser As DataTable

    Public Sub authenticate(ByVal username As String, ByVal password As String)
        Static count As Integer = 0
        Dim um As New UserManager
        Try
            validate(username, password)
            ' username and password is required
            canAuthenticate(username, password)

            Try

                dtUser = um.retrieveActive
            Catch daex As DataAccessException
                daex.overrideMessage(MyMessageBox.OperationErrorMessage(daex.code))
                Throw daex
            End Try

            'FIND FOR A MATCH
            Dim IsFound As Boolean
            Dim index As Integer

            For a = 0 To dtUser.Rows.Count - 1
                If DBNullToString(dtUser.Rows(a)("userName")) = username _
                    AndAlso DBNullToString(dtUser.Rows(a)("userPassword")) =
                    um.GenerateSaltedPassword(CUInt(DBNullToNumeric(dtUser.Rows(index)("User_ID"))), password) Then
                    IsFound = True
                    index = a
                    Exit For
                End If
            Next

            If IsFound Then
                count = 0
                Dim user As New User
                user.user_ID = CUInt(DBNullToNumeric(dtUser.Rows(index)("User_ID")))
                user.userName = DBNullToString(dtUser.Rows(index)("UserName"))
                user.userTypeCode =
                CType(DBNullToNumeric(dtUser.Rows(index)("UserTypeCode")), UInt16)
                setCurrentUser(user)

            Else
                count = count + 1
                If count >= 3 Then
                    Logger.thirdLoginAttempt(username, password)
                    MsgBox("Login attempted 3 times." & vbCrLf &
                           "This application will close.", MsgBoxStyle.Critical, "STOP!!!")
                    Dim msg As String = ""
                    Dim bex As New BusinessException("needToClose")
                    bex.code = BusinessRulesViolationCode.ThirdLoginAttempt
                    Throw bex
                End If
                Throw New BusinessException("Username and Password did not match. " &
                                            "Login attempt " & count)

            End If

        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New BusinessException("Login Failed.")
        End Try


    End Sub

    Private Function SHA1(ByVal strToHash As String) As String
        Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function


    Private Sub canAuthenticate(ByVal username As String, ByVal password As String)
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

    End Sub

    Private Sub validate(ByVal username As String, ByVal password As String)
        Try
            Dim um As New UserManager
            um.validateUsername(username)
            um.validatePassword(password)
            username = username
            password = password
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub

    Public Sub logoutUser()
        logoutCurrentUser()
    End Sub

    Public Function isAuthorized(ByVal username As String, ByVal password As String) As Boolean
        Try
            canAuthenticate(username, password)

            Dim um As New UserManager
            dtUser = um.retrieveAdministrators

            'FIND FOR A MATCH
            Dim IsFound As Boolean = False
            Dim index As Integer

            For a = 0 To dtUser.Rows.Count - 1
                If DBNullToString(dtUser.Rows(a)("userName")) = username _
                    AndAlso DBNullToString(dtUser.Rows(a)("userPassword")) = _
                    password Then
                    IsFound = True
                    index = a
                    Exit For
                End If
            Next

            If IsFound Then
                Return True
            End If

        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New BusinessException("Authorization Failed.")
        End Try

        Return False
    End Function
End Class