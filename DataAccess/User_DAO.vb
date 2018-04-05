Imports MySql.Data.MySqlClient
Imports System.Data
Imports CrossCutting
Imports Bridge

Public Class User_DAO
    Inherits DataAccessBase

    ''' Return the newly added User ID.
    Public Function add(ByVal user As Bridge.IUser) As UInteger
        Dim user_ID As UInteger

        Try
            Dim cmd As New MySqlCommand("usp_User_add", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim out_userID As MySqlParameter = cmd.Parameters.Add("out_user_ID", MySqlDbType.UInt32)
            out_userID.Direction = ParameterDirection.Output
            Dim out_hashed_pwd As MySqlParameter = cmd.Parameters.Add("out_hashed_password", MySqlDbType.VarChar)
            out_hashed_pwd.Direction = ParameterDirection.Output

            Dim userName As MySqlParameter = cmd.Parameters.Add("in_userName", MySqlDbType.VarChar)
            Dim userPassword As MySqlParameter = cmd.Parameters.Add("in_userPassword", MySqlDbType.VarChar)
            Dim userTypeCode As MySqlParameter = cmd.Parameters.Add("in_userTypeCode", MySqlDbType.UInt32)
            Dim active As MySqlParameter = cmd.Parameters.AddWithValue("in_active", True)    ' user.active)
            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)

            userName.Value = user.userName
            userPassword.Value = user.userPassword
            userTypeCode.Value = user.userTypeCode
            'active.Value = CByte(user.active)  - Not working
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            Dim i As Integer = cmd.ExecuteNonQuery()
            user_ID = out_userID.Value
            user.userPassword = out_hashed_pwd.Value
        Catch myex As MySqlException
            'Exceptions not neccessary to Log can be filtered in ExceptionLog_DAO, i.e. DUPICATE DATA ENTRY
            ExceptionLog_DAO.log(myex, myex.Number)
            '
            'MySQLErrorNumToString() is used in CrUD statements
            'Using MySQLErrorNumToString() function, can return a specific error message to the user, i.e. DUPLICATE DATA ENTRY
            '
            Dim daex As New DataAccessException(
            MySQLErrorNumToString(myex.Number, "Adding new user '" & user.userName &
                                  "' failed!"), DataAccessExceptionCode.User_add)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Adding new user '" & user.userName &
                                                "' failed!", DataAccessExceptionCode.User_add)
            Throw daex
        Finally
            closeConnection()

        End Try

        Return user_ID
    End Function

    'ZERO IS RETURNED FOR FAILED UPDATE
    Public Function update(ByVal user As Bridge.IUser) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_User_update", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim userID As MySqlParameter = cmd.Parameters.Add("in_user_ID", MySqlDbType.UInt32)
            userID.Value = user.user_ID
            Dim userName As MySqlParameter = cmd.Parameters.Add("in_userName", MySqlDbType.VarChar)
            userName.Value = user.userName
            Dim userTypeCode As MySqlParameter = cmd.Parameters.Add("in_userTypeCode", MySqlDbType.UInt32)
            userTypeCode.Value = user.userTypeCode
            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException(
            MySQLErrorNumToString(myex.Number, "Updating '" & user.userName & "' failed!"))
            daex.code = DataAccessExceptionCode.User_update
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Updating '" & user.userName & "' failed!")
            daex.code = DataAccessExceptionCode.User_update
            Throw daex
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    Public Function retrieveByUserID(ByVal user_ID As UInteger) As DataTable

        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_User_getByUser_ID", conn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim userid As MySqlParameter = cmd.Parameters.Add("in_user_ID", MySqlDbType.UInt32)
            userid.Value = user_ID

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving user failed!")
            daex.code = DataAccessExceptionCode.User_retrieveByID
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving user failed!")
            daex.code = DataAccessExceptionCode.User_retrieveByID
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()

        End Try

        Return dTable

    End Function


    Public Function retrieveByUsername(ByVal username As String) As System.Data.DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_User_getByUserName", conn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim _userName As MySqlParameter = cmd.Parameters.Add("in_userName", MySqlDbType.VarChar)
            _userName.Value = username

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving user failed!",
                                                DataAccessExceptionCode.User_retrieveByName)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving user failed!",
                                                DataAccessExceptionCode.User_retrieveByName)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    'argBoolean VALUE OF FALSE WILL DEACTIVATE A USER
    'ZERO IS RETURNED FOR FAILED ACTIVATION/DEACTIVATION
    Public Function activate(ByVal user_ID As UInteger, ByVal argBoolean As Boolean) As Integer
        Dim i As Integer
        Try
            Dim cmd As New MySqlCommand("usp_User_activate", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim userid As MySqlParameter = cmd.Parameters.Add("in_user_ID", MySqlDbType.UInt32)
            userid.Value = user_ID
            Dim _bool As MySqlParameter = cmd.Parameters.AddWithValue("in_Boolean", argBoolean)
            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            'MySQLErrorNumToString() has no useful work here
            Dim daex As New DataAccessException(
            MySQLErrorNumToString(myex.Number,
                                  IIf(argBoolean = True, "Activating", "Deactivating") & " user failed!"),
                                                    DataAccessExceptionCode.User_activate)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException(IIf(argBoolean = True, "Activating", "Deactivating") &
                                                " user failed!", DataAccessExceptionCode.User_activate)
            Throw daex
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    ''TENTATIVE
    'Public Function deactivate(ByVal user_ID As UInteger) As Integer
    '    Return 0
    'End Function

    Public Function retrieveAll() As DataTable
        Dim dTable As New DataTable

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_User_getAll", conn)
            cmd.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving users failed!",
                                                DataAccessExceptionCode.User_retrieveAll)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving users failed!",
                                                DataAccessExceptionCode.User_retrieveAll)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveActive() As DataTable
        Dim dTable As New DataTable

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_User_getActive", conn)
            cmd.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving users failed!",
                                                DataAccessExceptionCode.User_retrieveAll)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving users failed!",
                                                DataAccessExceptionCode.User_retrieveAll)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveAdministrators() As DataTable
        Dim dTable As New DataTable

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_User_getAdmin", conn)
            cmd.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving users failed!",
                                                DataAccessExceptionCode.User_retrieveAll)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving users failed!",
                                                DataAccessExceptionCode.User_retrieveAll)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    'ZERO IS RETURNED FOR FAILED CHANGING PASSWORD
    Public Function changePassword(ByVal user_ID As UInteger, ByVal newPassword As String) As String
        Dim i As Integer
        Dim hashed_pwd As String
        Try
            Dim cmd As New MySqlCommand("usp_User_changePassword", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim out_hashed_pwd As MySqlParameter = cmd.Parameters.Add("out_hashed_password", MySqlDbType.VarChar)
            out_hashed_pwd.Direction = ParameterDirection.Output
            Dim userid As MySqlParameter = cmd.Parameters.Add("in_user_ID", MySqlDbType.UInt32)
            userid.Value = user_ID
            Dim password As MySqlParameter = cmd.Parameters.Add("in_userPassword", MySqlDbType.VarChar)
            password.Value = newPassword
            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

            hashed_pwd = out_hashed_pwd.Value
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException(MySQLErrorNumToString _
                                                (myex.Number, "Changing Password failed!"),
                                                DataAccessExceptionCode.User_changePassword)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Changing Password failed!",
                                                DataAccessExceptionCode.User_changePassword)
            Throw daex
        Finally
            closeConnection()

        End Try

        Return hashed_pwd
    End Function

    Public Function delete(ByVal user_ID As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_User_delete", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_user_ID", MySqlDbType.UInt32)
            pKey.Value = user_ID

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException(
            MySQLErrorNumToString(myex.Number, "An error occur while deleting a user!"),
            DataAccessExceptionCode.User_delete)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while deleting a user!!", DataAccessExceptionCode.User_delete)
        Finally
            closeConnection()
        End Try

        Return i
    End Function



    Public Function GenerateSaltedPassword(ByVal user_ID As UInteger, password As String) As String

        Dim saltedPassword As String
        Try
            Dim cmd As New MySqlCommand("usp_User_salt_password", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_user_ID", MySqlDbType.UInt32)
            pKey.Value = user_ID

            Dim pwd As MySqlParameter = cmd.Parameters.Add("in_userPassword", MySqlDbType.VarChar)
            pwd.Value = password

            Dim out_pwd As MySqlParameter = cmd.Parameters.Add("out_pwd", MySqlDbType.VarChar)
            out_pwd.Direction = ParameterDirection.Output

            openConnection()
            cmd.ExecuteNonQuery()
            saltedPassword = out_pwd.Value

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException(
            MySQLErrorNumToString(myex.Number, "An error occur while deleting a user!"),
            DataAccessExceptionCode.User_delete)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while deleting a user!!", DataAccessExceptionCode.User_delete)
        Finally
            closeConnection()
        End Try

        Return saltedPassword
    End Function

End Class