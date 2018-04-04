Imports MySql.Data.MySqlClient
Imports System.Data
Imports CrossCutting
Imports Bridge

Public Class Payroll_DAO
    Inherits DataAccessBase

    ''' Return the newly added Payroll Number.
    Public Function add(ByVal payroll As IPayroll, ByVal project_IDs() As UInteger) As UInteger
        Dim ipayrollNum As UInteger = 0

        Dim transaction As MySqlTransaction = Nothing
        Try
            'BeginTransaction needs an open connection
            openConnection()
            transaction = conn.BeginTransaction
            ''Add the Payroll
            Dim cmd As New MySqlCommand("usp_Payroll_add", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Transaction = transaction
            'PARAMs
            Dim payrollNum As MySqlParameter = cmd.Parameters.Add("out_payrollNum", MySqlDbType.UInt32)
            payrollNum.Direction = ParameterDirection.Output
            Dim p_empNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            Dim payFrom As MySqlParameter = cmd.Parameters.Add("in_payFrom", MySqlDbType.Date)
            Dim payTo As MySqlParameter = cmd.Parameters.Add("in_payTo", MySqlDbType.Date)
            Dim basicRate As MySqlParameter = cmd.Parameters.Add("in_basicRate", MySqlDbType.Decimal)
            Dim regOT_rate As MySqlParameter = cmd.Parameters.Add("in_regOT_rate", MySqlDbType.Decimal)
            Dim sunOT_rate As MySqlParameter = cmd.Parameters.Add("in_sunOT_rate", MySqlDbType.Decimal)
            Dim holOT_rate As MySqlParameter = cmd.Parameters.Add("in_holOT_rate", MySqlDbType.Decimal)
            Dim wTax As MySqlParameter = cmd.Parameters.Add("in_wTax", MySqlDbType.Decimal)
            Dim SSS As MySqlParameter = cmd.Parameters.Add("in_SSS", MySqlDbType.Decimal)
            Dim philHealth As MySqlParameter = cmd.Parameters.Add("in_philHealth", MySqlDbType.Decimal)
            Dim PAGIBIG As MySqlParameter = cmd.Parameters.Add("in_PAGIBIG", MySqlDbType.Decimal)
            Dim SSS_Loan As MySqlParameter = cmd.Parameters.Add("in_SSS_Loan", MySqlDbType.Decimal)
            Dim personalLoan As MySqlParameter = cmd.Parameters.Add("in_personalLoan", MySqlDbType.Decimal)
            Dim createdBy As MySqlParameter = cmd.Parameters.Add("in_createdBy", MySqlDbType.UInt32)

            Dim civilStat As MySqlParameter = cmd.Parameters.Add("in_civilStat", MySqlDbType.VarChar)
            Dim numOfDependent As MySqlParameter = cmd.Parameters.Add("in_numOfDependent", MySqlDbType.UInt16)
            Dim tp_status As MySqlParameter = cmd.Parameters.Add("in_tp_status", MySqlDbType.VarChar)
            Dim payMethod As MySqlParameter = cmd.Parameters.Add("in_payMethod", MySqlDbType.VarChar)
            Dim grossPay As MySqlParameter = cmd.Parameters.Add("in_grossPay", MySqlDbType.Decimal)
            Dim netPay As MySqlParameter = cmd.Parameters.Add("in_netPay", MySqlDbType.Decimal)

            With payroll
                p_empNum.Value = .empNum
                payFrom.Value = .payFrom
                payTo.Value = .payTo
                basicRate.Value = .basicRate
                regOT_rate.Value = .regOT_rate
                sunOT_rate.Value = .sunOT_rate
                holOT_rate.Value = .holOT_rate
                wTax.Value = .wTax
                SSS.Value = .SSS
                philHealth.Value = .philHealth
                PAGIBIG.Value = .PAGIBIG
                SSS_Loan.Value = .SSS_Loan
                personalLoan.Value = .personalLoan
                createdBy.Value = getCurrentUser_UserID()

                civilStat.Value = .civilStat
                numOfDependent.Value = .numofDependent
                tp_status.Value = .tp_status
                payMethod.Value = .payMethod
                grossPay.Value = .grossPay
                netPay.Value = .netPay
            End With

            'Insert Payroll
            Dim i As Integer = cmd.ExecuteNonQuery()
            ipayrollNum = payrollNum.Value
            ''PARAMETERS CLEAR
            cmd.Parameters.Clear()

            'Use by Processed Projec
            payrollNum = cmd.Parameters.Add("in_payrollNum", MySqlDbType.UInt32)
            payrollNum.Value = ipayrollNum

            'Process the projects
            cmd.CommandText = "usp_Project_processed"
            Dim project_ID As MySqlParameter = cmd.Parameters.Add("in_project_ID", MySqlDbType.UInt32)
            For i = 0 To project_IDs.Length - 1
                project_ID.Value = project_IDs(i)
                cmd.ExecuteNonQuery()
            Next
            ''PARAMETERS CLEAR
            cmd.Parameters.Clear()

            ''Used by  Processed Allowance, OtherDeduction, Bonus
            Dim iempNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            iempNum.Value = payroll.empNum
            payrollNum = cmd.Parameters.Add("in_payrollNum", MySqlDbType.UInt32)
            payrollNum.Value = ipayrollNum

            ''Processed Allowance
            cmd.CommandText = "usp_EmpAllowance_processed"
            cmd.ExecuteNonQuery()

            'Used in Bonus and OtherDeduction
            Dim settledBy As MySqlParameter = cmd.Parameters.Add("in_settledBy", MySqlDbType.UInt32)
            settledBy.Value = getCurrentUser_UserID()

            ''Settle Other Deduction
            cmd.CommandText = "usp_OtherDeduction_settle"
            cmd.ExecuteNonQuery()

            ''Settle Bonus
            cmd.CommandText = "usp_Bonus_settle"
            cmd.ExecuteNonQuery()

            ''PARAMETERS CLEAR
            cmd.Parameters.Clear()

            'UPDATE THE PERSONAL AND SSS LOAN IF SETTLED 
            iempNum = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            iempNum.Value = payroll.empNum
            Dim _value As MySqlParameter = cmd.Parameters.Add("in_value", MySqlDbType.Decimal)
            If payroll.personalLoan > 0 Then
                'Update the employee personal loan
                _value.Value = payroll.personalLoan
                cmd.CommandText = "usp_Employee_settle_personalLoan"
                cmd.ExecuteNonQuery()
            End If

            If payroll.SSS_Loan > 0 Then
                'Update the employee SSS loan
                _value.Value = payroll.SSS_Loan
                cmd.CommandText = "usp_Employee_settle_SSS_loan"
                cmd.ExecuteNonQuery()
            End If

            transaction.Commit()
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Try
                If transaction IsNot Nothing Then transaction.Rollback()
            Catch rollbackException As MySqlException
                ExceptionLog_DAO.log(rollbackException)
            End Try
            Dim daex As New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "Adding new Payroll Transaction failed!"), _
            DataAccessExceptionCode.Payroll_add)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Adding new Payroll Transaction failed!", _
            DataAccessExceptionCode.Payroll_add)
            Throw daex
        Finally
            closeConnection()

        End Try

        Return ipayrollNum
    End Function

    Public Function reverse(ByVal payrollNum As UInteger) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Payroll_reverse", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_payrollNum", MySqlDbType.UInt32)
            pKey.Value = payrollNum

            Dim reversedBy As MySqlParameter = cmd.Parameters.Add("in_reversedBy", MySqlDbType.UInt32)
            reversedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "Reversing Payroll Number : " & payrollNum & " failed!"), _
            DataAccessExceptionCode.Payroll_reverse)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Reversing Payroll Number : " & payrollNum & " failed!", DataAccessExceptionCode.Payroll_reverse)
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    Public Overloads Function retrieveByPayrollNum(ByVal payrollNum As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim SQL As String = "SELECT * FROM tblPayroll WHERE payrollNum = ?payrollNum"
        Try
            Dim cmd As New MySqlCommand(SQL, conn)
            Dim param As MySqlParameter = cmd.Parameters.Add("?payrollNum", MySqlDbType.UInt32)
            param.Value = payrollNum

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving payroll failed!", DataAccessExceptionCode.Payroll_getByPayrollNum)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving payroll failed!", DataAccessExceptionCode.Payroll_getByPayrollNum)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Overloads Function retrieveByPayrollNum(ByVal payrollNum As UInteger, ByVal isReversed As Boolean) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim rev As String = IIf(isReversed, "isReversed <> 0", "isReversed = 0")

        Dim SQL As String = "SELECT * FROM tblPayroll WHERE payrollNum = ?payrollNum AND " & rev
        Try
            Dim cmd As New MySqlCommand(SQL, conn)
            Dim param As MySqlParameter = cmd.Parameters.Add("?payrollNum", MySqlDbType.UInt32)
            param.Value = payrollNum

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving payroll failed!", DataAccessExceptionCode.Payroll_getByPayrollNum)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving payroll failed!", DataAccessExceptionCode.Payroll_getByPayrollNum)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    'OTHER FUNCTIONS
#Region "Other Functions"
    Public Function TrackSSSContribution(ByVal empNum As UInteger, ByVal _from As Date, ByVal _to As Date) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_Payroll_trackSSSContribution", conn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim in_empNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            in_empNum.Value = empNum
            Dim in_from As MySqlParameter = cmd.Parameters.Add("in_from", MySqlDbType.Date)
            in_from.Value = _from
            Dim in_to As MySqlParameter = cmd.Parameters.Add("in_to", MySqlDbType.Date)
            in_to.Value = _to

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Tracking SSS contribution failed!", DataAccessExceptionCode.Payroll_trackSSSContribution)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Tracking SSS contribution failed!", DataAccessExceptionCode.Payroll_trackSSSContribution)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function TrackPhilHealthContribution(ByVal empNum As UInteger, ByVal _from As Date, ByVal _to As Date) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_Payroll_trackPhilHealthContribution", conn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim in_empNum As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            in_empNum.Value = empNum
            Dim in_from As MySqlParameter = cmd.Parameters.Add("in_from", MySqlDbType.Date)
            in_from.Value = _from
            Dim in_to As MySqlParameter = cmd.Parameters.Add("in_to", MySqlDbType.Date)
            in_to.Value = _to

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Tracking PhilHealth contribution failed!", DataAccessExceptionCode.Payroll_trackPhilHealthContribution)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Tracking PhilHealth contribution failed!", DataAccessExceptionCode.Payroll_trackPhilHealthContribution)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Enum Weekly_Deduction
        SSS
        PhilHealth
    End Enum

#End Region

End Class