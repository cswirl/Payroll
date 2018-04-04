Imports System.Data
Imports Bridge
Imports MySql.Data.MySqlClient
Imports CrossCutting
Imports System.Text

Public Class OtherDeduction_DAO
    Inherits DataAccessBase

    Public Function add(ByVal deduction As IOtherDeduction) As UInteger
        Dim ret_ID As UInteger = 0
        Try
            Dim cmd As New MySqlCommand("usp_OtherDeduction_add", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim primaryKey As MySqlParameter = cmd.Parameters.Add("out_ID", MySqlDbType.UInt32)
            primaryKey.Direction = ParameterDirection.Output

            Dim empNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            empNum.Value = deduction.empNum
            Dim bonusTypeCode As MySqlParameter = cmd.Parameters.Add("in_deductTypeCode", MySqlDbType.UInt16)
            bonusTypeCode.Value = deduction.deductTypeCode
            Dim specify As MySqlParameter = cmd.Parameters.Add("in_specify", MySqlDbType.VarChar)
            specify.Value = deduction.specify
            Dim amount As MySqlParameter = cmd.Parameters.Add("in_amount", MySqlDbType.Decimal)
            amount.Value = deduction.amount
            Dim remark As MySqlParameter = cmd.Parameters.Add("in_remark", MySqlDbType.VarChar)
            remark.Value = deduction.remark
           
            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()


            openConnection()
            Dim i As Integer = cmd.ExecuteNonQuery()
            closeConnection()

            ret_ID = primaryKey.Value
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
                        MySQLErrorNumToString(myex.Number, "Adding new deduction failed!"), _
                        DataAccessExceptionCode.Deduction_add)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Adding new deduction failed!", _
                                          DataAccessExceptionCode.Deduction_add)
        Finally
            closeConnection()

        End Try

        Return ret_ID
    End Function

    Public Function delete(ByVal ID As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_OtherDeduction_delete", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_ID", MySqlDbType.UInt32)
            pKey.Value = ID

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "An error occur while deleting a deduction."), _
            DataAccessExceptionCode.Deduction_delete)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while deleting a deduction.", _
                                          DataAccessExceptionCode.Deduction_delete)
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    Public Function settle(ByVal ID As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_OtherDeduction_settle", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_ID", MySqlDbType.UInt32)
            pKey.Value = ID

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_settledBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "An error occur while settling other deduction."), _
            DataAccessExceptionCode.Deduction_settle)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while settling other deduction.", _
                                          DataAccessExceptionCode.Deduction_settle)
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    Public Overloads Function retrieveAll(Optional ByVal settled As _
                                                    Boolean = False) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim isSettled As Int16 = IIf(settled, 1, 0)
        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT o.ID, o.empNum, c.name, o.amount, ")
            .Append("o.dateCreated, u.userName as lastModifiedBy ")
            .Append("FROM tblOtherDeduction o ")
            .Append("LEFT JOIN tblDeductionType c ")
            .Append("ON c.deductTypeCode = o.deductTypeCode ")
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = o.lastModifiedBy ")
            .Append(String.Format("WHERE isSettled = {0}", isSettled))
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving other deduction failed!", DataAccessExceptionCode.Deduction_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving other deduction failed!", DataAccessExceptionCode.Deduction_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveAllForPayroll(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim isSettled As Int16 = 0
        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT o.ID, o.empNum, c.name, o.amount ")
            .Append("FROM tblOtherDeduction o ")
            .Append("LEFT JOIN tblDeductionType c ")
            .Append("ON c.deductTypeCode = o.deductTypeCode ")
            .Append(String.Format("WHERE o.empNum = ?empNum AND isSettled = {0}", isSettled))
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving other deduction failed!", DataAccessExceptionCode.Deduction_getAllForPayroll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving other deduction failed!", DataAccessExceptionCode.Deduction_getAllForPayroll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveSettledByPayrollNum(ByVal payrollNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT o.ID, o.empNum, c.name, o.amount ")
            .Append("FROM tblOtherDeduction o ")
            .Append("LEFT JOIN tblDeductionType c ")
            .Append("ON c.deductTypeCode = o.deductTypeCode ")
            .Append("WHERE isSettled = 1 AND o.payrollNum = ?payrollNum")
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim param As MySqlParameter = cmd.Parameters.Add("?payrollNum", MySqlDbType.UInt32)
            param.Value = payrollNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving allowance failed!", DataAccessExceptionCode.Deduction_getSettledByPayrollNum)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving allowance failed!", DataAccessExceptionCode.Deduction_getSettledByPayrollNum)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function getTotalForEmployee(ByVal employeeNumber As UInteger) As Double
        Dim total As Double = 0.0
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim isSettled As Int16 = 0
        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT SUM(amount) ")
            .Append("FROM tblOtherDeduction ")
            .Append(String.Format("WHERE empNum = ?empNum AND isSettled = {0}", isSettled))
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            total = CDbl(DBNullToNumeric(cmd.ExecuteScalar))
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving other deduction failed!", DataAccessExceptionCode.Deduction_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving other deduction failed!", DataAccessExceptionCode.Deduction_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return total
    End Function

    Public Function getTotalForReversal(ByVal payrollNumber As UInteger) As Double
        Dim total As Double = 0.0

        Dim isSettled As Int16 = 1
        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT SUM(o.amount) ")
            .Append("FROM  tblOtherDeduction o ")
            .Append(String.Format("WHERE payrollNum = ?payrollNumber AND isSettled = {0}", isSettled))
        End With
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?payrollNumber", MySqlDbType.UInt32)
            empNum.Value = payrollNumber

            openConnection()
            total = CDbl(DBNullToNumeric(cmd.ExecuteScalar))
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving other deduction total failed!", DataAccessExceptionCode.Project_getOtherDeductTotalForReversal)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving other deduction total failed!", DataAccessExceptionCode.Project_getOtherDeductTotalForReversal)
        Finally
            closeConnection()
        End Try

        Return total
    End Function
End Class