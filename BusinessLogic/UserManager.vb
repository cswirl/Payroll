Imports BusinessLogic.BusinessEntity
Imports CrossCutting
Imports DataAccess
Imports System.Data
Imports Bridge

Public Class UserManager
    Inherits ManagerBase

    Friend WithEvents userDAO As User_DAO
    Private userData_Courier As User

    Sub New()
        userDAO = New User_DAO
    End Sub

    ''' <summary>
    ''' Return the newly added User ID.
    ''' </summary>
    Public Function add(ByVal user As Bridge.IUser) As UInteger
        userData_Courier = user
        Dim user_ID As UInteger = 0
        Try
            If Me.userData_Courier Is Nothing Then
                Throw New Exception("`User instance` is not initialized.")
            End If

            insert_inspectData()
            user_ID = userDAO.add(user)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw ex
        Finally
            'Release the object after use
            userData_Courier = Nothing
        End Try

        Return user_ID
    End Function

    Friend Sub validateUsername(ByVal username As String)
        Try
            stringChecker(username, User.USERNAME_MAX_LEN)

        Catch sqliex As SQLInjectionException
            'Log the suspected 'value' and throw an BusinessException
            Logger.possibleSQLInjection(username, sqliex.StackTrace)
            sqliex.overrideMessage("`Username`" & sqliex.Message)
            Throw sqliex
        Catch bex As BusinessException
            bex.overrideMessage("`Username`" & bex.Message)
            Throw bex
        End Try
    End Sub

    Friend Sub validatePassword(ByVal password As String)
        Try
            stringChecker(password, User.PASSWORD_MAX_LEN)
        Catch sqliex As SQLInjectionException
            'Log the suspected 'value' and throw an BusinessException
            Logger.possibleSQLInjection(password, sqliex.StackTrace)
            sqliex.overrideMessage("`Password`" & sqliex.Message)
            Throw sqliex
        Catch bex As BusinessException
            bex.overrideMessage("`Password`" & bex.Message)
            Throw bex
        End Try
    End Sub

    Public Function update(ByVal user As Bridge.IUser) As Integer
        userData_Courier = user
        Dim i As Integer = 0
        Try
            If user.user_ID = 1 And user.userTypeCode = 2 Then
                Throw New BusinessException("Cannot modify `User type` of the default account.")
            ElseIf user.user_ID < 1 Then
                Throw New BusinessException("Invalid user.")
            End If
            'If user.user_ID = getCurrentUser_UserID() Then Throw New BusinessException("Cannot modify logged-in user.")

            If Me.userData_Courier Is Nothing Then
                Throw New Exception("`User instance` is not initialized.")
            End If
            update_inspectData()
            userDAO.update(user)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Finally
            userData_Courier = Nothing
        End Try

        Return i
    End Function

    Public Function retrieveAll() As DataTable
        Dim dTable As New DataTable
        Try
            dTable = userDAO.retrieveAll()
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function retrieveActive() As DataTable
        Dim dTable As New DataTable
        Try
            dTable = userDAO.retrieveActive()
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function retrieveAdministrators() As DataTable
        Dim dTable As New DataTable
        Try
            dTable = userDAO.retrieveAdministrators()
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function retrieveByUserID(ByVal userID As UInteger) As Bridge.IUser
        Dim user As New User
        Dim dTable As DataTable
        Try
            dTable = userDAO.retrieveByUserID(userID)
            If dTable Is Nothing AndAlso dTable.Rows.Count < 1 Then
                Throw New DataAccessException("No user found. Please verify the User ID.")
            End If

            'Exatract data here
            With user
                .userName = DBNullToString(dTable.Rows(0)("userName")).ToString
                .active = CBool(DBNullToNumeric(dTable.Rows(0)("active")))
            End With

        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New Exception("An error occured while retrieving a user.")
        End Try

        Return user
    End Function

    Public Function retrieveByUsername(ByVal username As String) As DataTable
        Dim dTable As DataTable
        Dim user As New User
        Try
            validateUsername(username)
            dTable = userDAO.retrieveByUsername(username)

            If dTable Is Nothing AndAlso dTable.Rows.Count < 1 Then
                Throw New DataAccessException("No user found. Please verify the User Name.")
            End If

            With user
                .userName = DBNullToString(dTable.Rows(0)("userName"))
            End With

        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New Exception("An error occured while retrieving a user.")
        End Try

        Return dTable
    End Function

    Public Function activate(ByVal user_ID As UInteger, ByVal activateThis As Boolean) As Integer
        Dim i As Integer = 0
        Try
            If user_ID < 1 Then Throw New BusinessException("Invalid user.")
            'Check permission
            If Not isAdmin(getCurrentUser) Then Throw New BusinessException("Permission denied. Please call an administrator.")
            If Not activateThis Then
                'For Default account
                If user_ID = 1 Then
                    Throw New BusinessException("Cannot deactivate the default account.")
                End If
                'For Logged-in User
                If user_ID = getCurrentUser_UserID() Then Throw New BusinessException("Cannot deactivate logged-in user.")
            End If
            i = userDAO.activate(user_ID, activateThis)
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return i
    End Function

    Public Function changePassword(ByVal user_ID As UInteger, ByVal newPassword As String) As String
        Dim hashed_pwd As String
        Try
            If Not IsAuthorized(user_ID) Then Throw New BusinessException("You are not Authorized to change password on this account.")
            validatePassword(newPassword)
            hashed_pwd = userDAO.changePassword(user_ID, newPassword)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return hashed_pwd
    End Function

    Public Function delete(ByVal user_ID As UInteger) As Integer
        Dim i As Integer = 0
        Try
            If user_ID = 1 Then
                Throw New BusinessException("Cannot delete the default account.")
            ElseIf user_ID < 1 Then
                Throw New BusinessException("Invalid user.")
            End If
            If user_ID = getCurrentUser_UserID() Then Throw New BusinessException("Cannot delete logged-in user.")

            i = userDAO.delete(user_ID)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

        Return i
    End Function

    Public Function GenerateSaltedPassword(ByVal user_ID As UInteger, password As String) As String
        Return userDAO.GenerateSaltedPassword(user_ID, password)


    End Function

    Public Function IsAuthorized(user_id As UInteger) As Boolean
        If isAdmin(getCurrentUser) Or user_id = getCurrentUser_UserID() Then Return True

        Return False
    End Function

#Region "Manager Base"
    Protected Overrides Sub insert_validateData()
        With userData_Courier
            Try
                validateUsername(.userName)
                validatePassword(.userPassword)
            Catch bex As BusinessException
                Throw bex
            End Try
        End With

    End Sub

    Protected Overrides Sub insert_checkRequiredData()
        With userData_Courier
            'TODO: CHECK FOR UNIQUENESS - or leverage the MySQL UNIQUE KEY VALIDATION 
            Try
                REQUIRED(.userName)
            Catch bex As BusinessException
                bex.overrideMessage("Username is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.userPassword)
            Catch bex As BusinessException
                bex.overrideMessage("Password is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.userTypeCode)
            Catch bex As BusinessException
                bex.overrideMessage("User Type is required.")
                Throw bex
            End Try

        End With
    End Sub

    Protected Overrides Sub update_validateData()
        Try
            validateUsername(userData_Courier.userName)
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub

    Protected Overrides Sub update_checkRequiredData()
        'Check for required data
        Try
            REQUIRED(userData_Courier.userName)
        Catch bex As BusinessException
            bex.overrideMessage("Username is required.")
            Throw bex
        End Try

        Try
            NON_ZERO(userData_Courier.userTypeCode)
        Catch bex As BusinessException
            bex.overrideMessage("User Type is required.")
            Throw bex
        End Try
    End Sub
#End Region

End Class