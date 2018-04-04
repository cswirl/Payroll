Imports System.Data
Imports Bridge
Imports MySql.Data.MySqlClient
Imports CrossCutting
Imports System.Text

Public Class Bonus_DAO
    Inherits DataAccessBase

    Public Function add(ByVal bonus As IBonus) As UInteger
        Dim ret_ID As UInteger = 0
        Try
            Dim cmd As New MySqlCommand("usp_Bonus_add", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim primaryKey As MySqlParameter = cmd.Parameters.Add("out_ID", MySqlDbType.UInt32)
            primaryKey.Direction = ParameterDirection.Output

            Dim empNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            empNum.Value = bonus.empNum
            Dim bonusTypeCode As MySqlParameter = cmd.Parameters.Add("in_bonusTypeCode", MySqlDbType.UInt16)
            bonusTypeCode.Value = bonus.bonusTypeCode
            Dim specify As MySqlParameter = cmd.Parameters.Add("in_specify", MySqlDbType.VarChar)
            specify.Value = bonus.specify
            Dim amount As MySqlParameter = cmd.Parameters.Add("in_amount", MySqlDbType.Decimal)
            amount.Value = bonus.amount
            Dim remark As MySqlParameter = cmd.Parameters.Add("in_remark", MySqlDbType.VarChar)
            remark.Value = bonus.remark
           
            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()


            openConnection()
            Dim i As Integer = cmd.ExecuteNonQuery()
            closeConnection()

            ret_ID = primaryKey.Value
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
                        MySQLErrorNumToString(myex.Number, "Adding new bonus failed!"), _
                        DataAccessExceptionCode.Bonus_add)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Adding new bonus failed!", DataAccessExceptionCode.Bonus_add)
        Finally
            closeConnection()
        End Try

        Return ret_ID
    End Function

    Public Function delete(ByVal ID As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Bonus_delete", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_ID", MySqlDbType.UInt32)
            pKey.Value = ID

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "An error occur while deleting a bonus."), _
            DataAccessExceptionCode.Bonus_delete)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while deleting a bonus.", DataAccessExceptionCode.Bonus_delete)
        Finally
            closeConnection()
        End Try

        Return i
    End Function

    'Not used
    Public Function settle(ByVal ID As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Bonus_settle", conn)
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
            MySQLErrorNumToString(myex.Number, "An error occur while settling a bonus."), _
            DataAccessExceptionCode.Bonus_settle)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while settling a bonus.", _
                                          DataAccessExceptionCode.Bonus_settle)
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
            .Append("SELECT b.ID, b.empNum, c.name, b.amount, ")
            .Append("b.dateCreated, u.username as lastModifiedBy ")
            .Append("FROM tblBonus b ")
            .Append("LEFT JOIN tblBonusType c ")
            .Append("ON c.bonusTypeCode = b.bonusTypeCode ")
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = b.lastModifiedBy ")
            .Append(String.Format("WHERE isSettled = {0}", isSettled))
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving bonus failed!", DataAccessExceptionCode.Bonus_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving bonus failed!", DataAccessExceptionCode.Bonus_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    'NOT USED
    Public Function getTotalForEmployee(ByVal employeeNumber As UInteger) As Double
        Dim total As Double = 0.0

        Dim isSettled As Int16 = 0
        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT SUM(amount) ")
            .Append("FROM tblBonus ")
            .Append(String.Format("WHERE empNum = ?empNum AND isSettled = {0}", isSettled))
        End With
        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            openConnection()
            total = CDbl(DBNullToNumeric(cmd.ExecuteScalar))
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving bonus total failed!", DataAccessExceptionCode.Deduction_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving bonus total failed!", DataAccessExceptionCode.Deduction_getAll)
        Finally
            closeConnection()
        End Try

        Return total
    End Function

    Public Overloads Function retrieveAllForPayroll(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim isSettled As Int16 = 0

        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT b.ID, b.empNum, c.name, b.amount ")
            .Append("FROM tblBonus b ")
            .Append("LEFT JOIN tblBonusType c ")
            .Append("ON c.bonusTypeCode = b.bonusTypeCode ")
            .Append(String.Format("WHERE b.empNum = ?empNum AND b.isSettled = {0}", isSettled))
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim empNum As MySqlParameter = cmd.Parameters.Add("?empNum", MySqlDbType.UInt32)
            empNum.Value = employeeNumber

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving bonus failed!", DataAccessExceptionCode.Bonus_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving bonus failed!", DataAccessExceptionCode.Bonus_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Overloads Function retrieveByPayrollNum(ByVal payrollNum As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim isSettled As Int16 = 1

        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT b.ID, b.empNum, c.name, b.amount ")
            .Append("FROM tblBonus b ")
            .Append("LEFT JOIN tblBonusType c ")
            .Append("ON c.bonusTypeCode = b.bonusTypeCode ")
            .Append(String.Format("WHERE b.payrollNum = ?payrollNum AND b.isSettled = {0}", isSettled))
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            Dim ipayrollNum As MySqlParameter = cmd.Parameters.Add("?payrollNum", MySqlDbType.UInt32)
            ipayrollNum.Value = payrollNum

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving bonus failed!", DataAccessExceptionCode.Bonus_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving bonus failed!", DataAccessExceptionCode.Bonus_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

End Class