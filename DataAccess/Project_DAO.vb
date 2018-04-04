Imports System.Data
Imports Bridge
Imports MySql.Data.MySqlClient
Imports CrossCutting

Public Class Project_DAO
    Inherits DataAccessBase

    Public Function add(ByVal project As IProject) As UInteger
        Dim ret_ID As UInteger = 0
        Try
            Dim cmd As New MySqlCommand("usp_Project_Unprocessed_add", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim primaryKey As MySqlParameter = cmd.Parameters.Add("out_project_ID", MySqlDbType.UInt32)
            primaryKey.Direction = ParameterDirection.Output

            Dim empNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            empNum.Value = project.empNum
            Dim proj_ID As MySqlParameter = cmd.Parameters.Add("in_proj_ID", MySqlDbType.UInt16)
            proj_ID.Value = project.proj_ID
            Dim position_ID As MySqlParameter = cmd.Parameters.Add("in_position_ID", MySqlDbType.UInt16)
            position_ID.Value = project.position_ID
            Dim div_ID As MySqlParameter = cmd.Parameters.Add("in_div_ID", MySqlDbType.UInt16)
            div_ID.Value = project.div_ID
            Dim workdays As MySqlParameter = cmd.Parameters.Add("in_workdays", MySqlDbType.UInt32)
            workdays.Value = project.workDays
            Dim regOT_hrs As MySqlParameter = cmd.Parameters.Add("in_regOT_hrs", MySqlDbType.Decimal)
            regOT_hrs.Value = project.regOT_hrs
            Dim sunOT_hrs As MySqlParameter = cmd.Parameters.Add("in_sunOT_hrs", MySqlDbType.Decimal)
            sunOT_hrs.Value = project.sunOT_hrs
            Dim holOT_hrs As MySqlParameter = cmd.Parameters.Add("in_holOT_hrs", MySqlDbType.Decimal)
            holOT_hrs.Value = project.holOT_hrs

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            Dim i As Integer = cmd.ExecuteNonQuery()
            closeConnection()

            ret_ID = primaryKey.Value
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
                        MySQLErrorNumToString(myex.Number, "Adding new project failed!"), _
                        DataAccessExceptionCode.Project_add)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Adding new project failed!", _
                                          DataAccessExceptionCode.Project_add)
        Finally
            closeConnection()

        End Try

        Return ret_ID
    End Function

    Public Function retrieveAll() As DataTable
        Dim dTable As New DataTable

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT p.project_ID, p.empNum, p.proj_ID, p.position_ID, p.div_ID, ")
            .Append("p.workDays, p.regOT_hrs, p.sunOT_hrs, p.holOT_hrs, ")
            .Append("p.dateCreated, p.lastModified, u.userName as lastModifiedBy, p.isHead ")
            .Append("FROM tblproject_unprocessed p ")
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = p.lastModifiedBy")
        End With

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getAll)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getAll)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    'Use for employee project User control
    Public Function retrieve_for_projectUC() As DataTable
        Dim dTable As New DataTable

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT p.project_ID, p.empNum, p.proj_ID, p.position_ID, p.div_ID, ")
            .Append("p.workDays, p.regOT_hrs, p.sunOT_hrs, p.holOT_hrs, ")
            .Append("p.dateCreated, p.lastModified, u.userName as lastModifiedBy, p.isHead, ")
            .Append("pn.name AS project, s.name AS position, d.name AS division ")
            .Append("FROM tblproject_unprocessed p ")
            .Append("LEFT JOIN tblProject pn ")
            .Append("ON pn.proj_ID = p.proj_ID ")
            .Append("LEFT JOIN tblPosition s ")
            .Append("ON s.position_ID = p.position_ID ")
            .Append("LEFT JOIN tblDivision d ")
            .Append("ON d.div_ID = p.div_ID ")
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = p.lastModifiedBy")
        End With

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getAll)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getAll)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    'Use for employee projects in denormalized manner with keys
    Public Function retrieveByEmpNum_denor_withKeys(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT p.project_ID, p.empNum, p.proj_ID, p.position_ID, p.div_ID, ")
            .Append("p.workDays, p.regOT_hrs, p.sunOT_hrs, p.holOT_hrs, ")
            .Append("p.dateCreated, p.lastModified, u.userName as lastModifiedBy, p.isHead, ")
            .Append("pn.name AS project, s.name AS position, d.name AS division ")
            .Append("FROM tblproject_unprocessed p ")
            .Append("LEFT JOIN tblProject pn ")
            .Append("ON pn.proj_ID = p.proj_ID ")
            .Append("LEFT JOIN tblPosition s ")
            .Append("ON s.position_ID = p.position_ID ")
            .Append("LEFT JOIN tblDivision d ")
            .Append("ON d.div_ID = p.div_ID ")
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = p.lastModifiedBy ")
            .Append("WHERE p.empNum = ?empNum")
        End With

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getAll)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getAll)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveByEmpNum(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT p.project_ID, pn.name, s.name as position, d.name as division, ")
            .Append("p.workDays, p.regOT_hrs, p.sunOT_hrs, p.holOT_hrs, ")
            .Append("p.dateCreated, p.lastModified, u.userName as lastModifiedBy, p.isHead  ")
            .Append("FROM tblproject_unprocessed p ")
            .Append("LEFT JOIN tblProject pn ")
            .Append("ON pn.proj_ID = p.proj_ID ")
            .Append("LEFT JOIN tblPosition s ")
            .Append("ON s.position_ID = p.position_ID ")
            .Append("LEFT JOIN tblDivision d ")
            .Append("ON d.div_ID = p.div_ID ")
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = p.lastModifiedBy ")
            .Append("WHERE p.empNum = ?empNum")
        End With

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getByEmpNum)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getByEmpNum)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveForPayroll(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT p.project_ID, pn.name, s.name as position, d.name as division, ")
            .Append("p.workDays, p.regOT_hrs, p.sunOT_hrs, p.holOT_hrs, p.isHead ")
            .Append("FROM tblproject_unprocessed p ")
            .Append("LEFT JOIN tblProject pn ")
            .Append("ON pn.proj_ID = p.proj_ID ")
            .Append("LEFT JOIN tblPosition s ")
            .Append("ON s.position_ID = p.position_ID ")
            .Append("LEFT JOIN tblDivision d ")
            .Append("ON d.div_ID = p.div_ID ")
            .Append("WHERE p.empNum = ?empNum")
        End With

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getAll)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getAll)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveForReversal(ByVal payrollNum As UInteger) As DataTable
        Dim dTable As New DataTable

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT p.project_ID, pn.name, s.name as position, d.name as division, ")
            .Append("p.workDays, p.regOT_hrs, p.sunOT_hrs, p.holOT_hrs, ")
            .Append("p.dateCreated, p.lastModified, u.userName as lastModifiedBy, p.isHead  ")
            .Append("FROM tblproject_processed p ")
            .Append("LEFT JOIN tblProject pn ")
            .Append("ON pn.proj_ID = p.proj_ID ")
            .Append("LEFT JOIN tblPosition s ")
            .Append("ON s.position_ID = p.position_ID ")
            .Append("LEFT JOIN tblDivision d ")
            .Append("ON d.div_ID = p.div_ID ")
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = p.lastModifiedBy ")
            .Append("WHERE p.payrollNum = ?payrollNum")
        End With

        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?payrollNum", MySqlDbType.UInt32)
            empNum.Value = payrollNum

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getByPayrollNum)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving projects failed!", _
                                                DataAccessExceptionCode.Project_getByPayrollNum)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function delete(ByVal project_ID As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Project_Unprocessed_delete", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_project_ID", MySqlDbType.UInt32)
            pKey.Value = project_ID

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "An error occur while deleting a project!"), _
            DataAccessExceptionCode.Project_delete)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while deleting a project!!", _
                                          DataAccessExceptionCode.Project_delete)
        Finally
            closeConnection()
        End Try

        Return i
    End Function

    'Use for payroll transaction
    Public Function getWorkdaysAndOTs(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        'Dim sql As String = "SELECT SUM(p.workDays) * e.basicRate AS workdays_total, ((e.basicRate / 8) * e.regOT_rate) * SUM(p.regOT_hrs) AS regOT_total, ((e.basicRate / 8) * e.sunOT_rate) * SUM(p.sunOT_hrs) AS sunOT_total, ((e.basicRate / 8) * e.holOT_rate) * SUM(p.holOT_hrs) AS holOT_total FROM tblProject_Unprocessed p JOIN tblEmployee e ON e.empNum = p.empNum WHERE p.empNum = in_empNum"
        Try
            Dim cmd As New MySqlCommand("usp_Project_Unprocessed_getWorkdaysAndOTs_total", conn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim empNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving Workdays and OTs failed!", _
                                                DataAccessExceptionCode.Project_getWorkdaysAndOTs)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving Workdays and OTs failed!", _
                                                DataAccessExceptionCode.Project_getWorkdaysAndOTs)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function getWorkdaysAndOTsForReversal(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        'Dim sql As String = "SELECT SUM(p.workDays) * e.basicRate AS workdays_total, ((e.basicRate / 8) * e.regOT_rate) * SUM(p.regOT_hrs) AS regOT_total, ((e.basicRate / 8) * e.sunOT_rate) * SUM(p.sunOT_hrs) AS sunOT_total, ((e.basicRate / 8) * e.holOT_rate) * SUM(p.holOT_hrs) AS holOT_total FROM tblProject_Unprocessed p JOIN tblEmployee e ON e.empNum = p.empNum WHERE p.empNum = in_empNum"
        Try
            Dim cmd As New MySqlCommand("usp_Project_Unprocessed_getWorkdaysAndOTsForReversal_total", conn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim empNum As MySqlParameter = cmd.Parameters.Add("in_payrollNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving Workdays and OTs failed!", _
                                                DataAccessExceptionCode.Project_getWorkdaysAndOTs)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving Workdays and OTs failed!", _
                                                DataAccessExceptionCode.Project_getWorkdaysAndOTs)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function update(ByVal project As IProject) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Project_Unprocessed_update", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim project_ID As MySqlParameter = cmd.Parameters.Add("in_project_ID", MySqlDbType.UInt32)
            project_ID.Value = project.project_ID
            Dim proj_ID As MySqlParameter = cmd.Parameters.Add("in_proj_ID", MySqlDbType.UInt16)
            proj_ID.Value = project.proj_ID
            Dim position_ID As MySqlParameter = cmd.Parameters.Add("in_position_ID", MySqlDbType.UInt16)
            position_ID.Value = project.position_ID
            Dim div_ID As MySqlParameter = cmd.Parameters.Add("in_div_ID", MySqlDbType.UInt16)
            div_ID.Value = project.div_ID
            Dim workdays As MySqlParameter = cmd.Parameters.Add("in_workdays", MySqlDbType.Int32)
            workdays.Value = project.workDays
            Dim regOT_hrs As MySqlParameter = cmd.Parameters.Add("in_regOT_hrs", MySqlDbType.Decimal)
            regOT_hrs.Value = project.regOT_hrs
            Dim sunOT_hrs As MySqlParameter = cmd.Parameters.Add("in_sunOT_hrs", MySqlDbType.Decimal)
            sunOT_hrs.Value = project.sunOT_hrs
            Dim holOT_hrs As MySqlParameter = cmd.Parameters.Add("in_holOT_hrs", MySqlDbType.Decimal)
            holOT_hrs.Value = project.holOT_hrs

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "Updating project failed!"))
            daex.code = DataAccessExceptionCode.Project_update
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Updating project failed!")
            daex.code = DataAccessExceptionCode.Project_update
            Throw daex
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    'The [key] can be a payroll number or a project ID
    Public Function getEmpNum(ByVal key As UInteger, Optional ByVal processed As Boolean = True) As UInteger
        Dim empNum As UInteger = 0

        Dim tableName As String = IIf(processed, "tblProject_processed", "tblProject_Unprocessed")
        Dim SQL As String

        If processed Then
            SQL = String.Format("SELECT empNum FROM {0} WHERE payrollNum = ?key", tableName)
        Else
            SQL = String.Format("SELECT empNum FROM {0} WHERE project_ID = ?key", tableName)
        End If

        Try
            Dim cmd As New MySqlCommand(SQL, conn)
            Dim ikey As MySqlParameter = cmd.Parameters.Add("?key", MySqlDbType.UInt32)
            ikey.Value = key

            openConnection()
            empNum = CUInt(DBNullToNumeric(cmd.ExecuteScalar))
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving Employee Number failed!", DataAccessExceptionCode.Project_getEmpNum)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving Employee Number failed!", DataAccessExceptionCode.Project_getEmpNum)
        Finally
            closeConnection()
        End Try

        Return empNum
    End Function

    Public Function flag_head(ByVal project_ID As UInteger, ByVal empNum As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Project_flag_head", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_project_ID", MySqlDbType.UInt32)
            pKey.Value = project_ID

            Dim param As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            param.Value = empNum

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("?lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "Flagging head project failed!"), _
            DataAccessExceptionCode.Project_flag_head)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Flagging head project failed!", DataAccessExceptionCode.Project_flag_head)
        Finally
            closeConnection()

        End Try

        Return i
    End Function
End Class