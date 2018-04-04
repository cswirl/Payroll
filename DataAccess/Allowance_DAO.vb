Imports System.Data
Imports Bridge
Imports MySql.Data.MySqlClient
Imports CrossCutting
Imports System.Text

Public Class Allowance_DAO
    Inherits DataAccessBase

    Public Function add(ByVal allowance As IAllowance, _
                                  Optional ByVal unprocessed As Boolean = True) As UInteger
        Dim ret_ID As UInteger = 0
        Dim SP As String
        If unprocessed Then
            SP = "usp_EmpAllowance_Unprocessed_add"
        Else
            SP = ""
        End If

        Try
            Dim cmd As New MySqlCommand(SP, conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim primaryKey As MySqlParameter = cmd.Parameters.Add("out_allowanceNum", MySqlDbType.UInt32)
            primaryKey.Direction = ParameterDirection.Output

            Dim empNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            empNum.Value = allowance.empNum
            Dim allowTypeCode As MySqlParameter = cmd.Parameters.Add("in_allowTypeCode", MySqlDbType.UInt16)
            allowTypeCode.Value = allowance.allowTypeCode
            Dim specify As MySqlParameter = cmd.Parameters.Add("in_specify", MySqlDbType.VarChar)
            specify.Value = allowance.specify
            Dim amount As MySqlParameter = cmd.Parameters.Add("in_amount", MySqlDbType.Decimal)
            amount.Value = allowance.amount
            Dim remark As MySqlParameter = cmd.Parameters.Add("in_remark", MySqlDbType.VarChar)
            remark.Value = allowance.remark
            Dim taxable As MySqlParameter = cmd.Parameters.AddWithValue("in_taxable", allowance.taxable)

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()


            openConnection()
            Dim i As Integer = cmd.ExecuteNonQuery()
            closeConnection()

            ret_ID = primaryKey.Value
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
                        MySQLErrorNumToString(myex.Number, "Adding new allowance failed!"), _
                        DataAccessExceptionCode.Allowance_add)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Adding new allowance failed!", DataAccessExceptionCode.Allowance_add)
        Finally
            closeConnection()

        End Try

        Return ret_ID
    End Function

    Public Function delete(ByVal allowanceNum As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_EmpAllowance_Unprocessed_delete", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_allowanceNum", MySqlDbType.UInt32)
            pKey.Value = allowanceNum

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "An error occur while deleting an allowance."), _
            DataAccessExceptionCode.Allowance_delete)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while deleting an allowance.", DataAccessExceptionCode.Allowance_delete)
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    Public Overloads Function retrieveAll(Optional ByVal unprocessed As _
                                                    Boolean = True) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT a.allowanceNum, a.empNum, c.name, a.amount, a.taxable, ")
            .Append("a.dateCreated, u.userName as lastModifiedBy ")
            .Append(String.Format("FROM {0} a ", getTableName(unprocessed)))
            .Append(" LEFT JOIN tblAllowanceType c ")
            .Append("ON c.allowTypeCode = a.allowTypeCode ")
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = a.lastModifiedBy")
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving allowance failed!", DataAccessExceptionCode.Allowance_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving allowance failed!", DataAccessExceptionCode.Allowance_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Overloads Function retrieveAllForPayroll(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT a.allowanceNum, a.empNum, c.name, a.amount, a.taxable ")
            .Append("FROM tblEmpAllowance_unprocessed a ")
            .Append("LEFT JOIN tblAllowanceType c ")
            .Append("ON c.allowTypeCode = a.allowTypeCode ")
            .Append("WHERE a.empNum = ?empNum")
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving allowance failed!", DataAccessExceptionCode.Allowance_getAllForPayroll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving allowance failed!", DataAccessExceptionCode.Allowance_getAllForPayroll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveProcessedByPayrollNum(ByVal payrollNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT a.allowanceNum, a.empNum, c.name, a.amount, a.taxable ")
            .Append("FROM tblEmpAllowance_processed a ")
            .Append("LEFT JOIN tblAllowanceType c ")
            .Append("ON c.allowTypeCode = a.allowTypeCode ")
            .Append("WHERE a.payrollNum = ?payrollNum")
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim param As MySqlParameter = cmd.Parameters.Add("?payrollNum", MySqlDbType.UInt32)
            param.Value = payrollNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving allowance failed!", DataAccessExceptionCode.Allowance_getProcessedByPayrollNum)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving allowance failed!", DataAccessExceptionCode.Allowance_getProcessedByPayrollNum)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Private Function getTableName(ByVal unprocessed As Boolean) As String
        If unprocessed Then
            Return "tblEmpAllowance_unprocessed"
        Else
            Return "tblEmpAllowance_Processed"
        End If
    End Function

    Public Overloads Function getTotalForEmployee(ByVal employeeNumber As UInteger, _
                                                  ByVal taxable As Boolean) As Double
        Dim total As Double = 0.0
        Dim isTaxable As UInt16 = IIf(taxable, 1, 0)

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT SUM(amount) ")
            .Append("FROM  tblEmpAllowance_Unprocessed ")
            .Append(String.Format("WHERE empNum = ?empNum AND taxable = {0}", isTaxable))
        End With
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            openConnection()
            total = CDbl(DBNullToNumeric(cmd.ExecuteScalar))
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving allowance total failed!", DataAccessExceptionCode.Project_getAllowanceTotalForEmployee)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving allowance total failed!", DataAccessExceptionCode.Project_getAllowanceTotalForEmployee)
        Finally
            closeConnection()
        End Try

        Return total
    End Function

    Public Overloads Function getTotalForEmployee(ByVal employeeNumber As UInteger) As Double
        Dim total As Double = 0.0

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT SUM(amount) ")
            .Append("FROM  tblEmpAllowance_Unprocessed ")
            .Append("WHERE empNum = ?empNum")
        End With
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            openConnection()
            total = CDbl(DBNullToNumeric(cmd.ExecuteScalar))
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving allowance total failed!", DataAccessExceptionCode.Project_getAllowanceTotalForEmployee)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving allowance total failed!", DataAccessExceptionCode.Project_getAllowanceTotalForEmployee)
        Finally
            closeConnection()
        End Try

        Return total
    End Function

    Public Overloads Function getTotalForReversal(ByVal payrollNumber As UInteger, _
                                                  ByVal taxable As Boolean) As Double
        Dim total As Double = 0.0
        Dim isTaxable As UInt16 = IIf(taxable, 1, 0)

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT SUM(amount) ")
            .Append("FROM  tblEmpAllowance_processed ")
            .Append(String.Format("WHERE payrollNum = ?payrollNumber AND taxable = {0}", isTaxable))
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim _payrollNumber As MySqlParameter = cmd.Parameters.Add("?payrollNumber", MySqlDbType.UInt32)
            _payrollNumber.Value = payrollNumber

            openConnection()
            total = CDbl(DBNullToNumeric(cmd.ExecuteScalar))
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving allowance total failed!", DataAccessExceptionCode.Project_getAllowanceTotalForReversal)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving allowance total failed!", DataAccessExceptionCode.Project_getAllowanceTotalForReversal)
        Finally
            closeConnection()
        End Try

        Return total
    End Function
End Class