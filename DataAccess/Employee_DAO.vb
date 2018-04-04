Imports MySql.Data.MySqlClient
Imports System.Data
Imports CrossCutting
Imports Bridge

Public Class Employee_DAO
    Inherits DataAccessBase

    ''' Returns the newly added employee number
    Public Function add(ByVal employee As IEmployee) As IEmployee
        Dim ret_ID As UInteger = 0
        Try
            Dim cmd As New MySqlCommand("usp_Employee_add", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim primaryKey As MySqlParameter = cmd.Parameters.Add("out_empNum", MySqlDbType.UInt32)
            primaryKey.Direction = ParameterDirection.Output
            Dim empNum_formatted As MySqlParameter = cmd.Parameters.Add("out_empNum_formatted", MySqlDbType.VarChar)
            empNum_formatted.Direction = ParameterDirection.Output

            'Personal
            Dim fn As MySqlParameter = cmd.Parameters.Add("in_firstName", MySqlDbType.VarChar)
            fn.Value = employee.firstName
            Dim ln As MySqlParameter = cmd.Parameters.Add("in_lastName", MySqlDbType.VarChar)
            ln.Value = employee.lastName
            Dim mn As MySqlParameter = cmd.Parameters.Add("in_middleName", MySqlDbType.VarChar)
            mn.Value = employee.middleName
            Dim gender As MySqlParameter = cmd.Parameters.Add("in_gender", MySqlDbType.VarChar)
            gender.Value = employee.gender
            Dim birthDate As MySqlParameter = cmd.Parameters.Add("in_birthDate", MySqlDbType.Date)
            birthDate.Value = employee.birthDate
            Dim civilStatus As MySqlParameter = cmd.Parameters.Add("in_civilStatus", MySqlDbType.VarChar)
            civilStatus.Value = employee.civilStat
            Dim address As MySqlParameter = cmd.Parameters.Add("in_address", MySqlDbType.VarChar)
            address.Value = employee.address
            Dim city As MySqlParameter = cmd.Parameters.Add("in_city", MySqlDbType.VarChar)
            city.Value = employee.city
            Dim contactNum As MySqlParameter = cmd.Parameters.Add("in_contactNum", MySqlDbType.VarChar)
            contactNum.Value = employee.contactNum
            Dim email As MySqlParameter = cmd.Parameters.Add("in_email", MySqlDbType.VarChar)
            email.Value = employee.email
            Dim SSS_num As MySqlParameter = cmd.Parameters.Add("in_SSS_num", MySqlDbType.VarChar)
            SSS_num.Value = employee.SSS_Num
            Dim TIN_num As MySqlParameter = cmd.Parameters.Add("in_TIN_num", MySqlDbType.VarChar)
            TIN_num.Value = employee.TIN_Num
            Dim philHealth_num As MySqlParameter = cmd.Parameters.Add("in_philHealth_num", MySqlDbType.VarChar)
            philHealth_num.Value = employee.philHealth_Num
            Dim PAGIBIG_num As MySqlParameter = cmd.Parameters.Add("in_PAGIBIG_num", MySqlDbType.VarChar)
            PAGIBIG_num.Value = employee.PAGIBIG_Num
            Dim PRC_num As MySqlParameter = cmd.Parameters.Add("in_PRC_num", MySqlDbType.VarChar)
            PRC_num.Value = employee.PRC_Num
            Dim status As MySqlParameter = cmd.Parameters.Add("in_status", MySqlDbType.VarChar)
            status.Value = employee.status
            Dim dateHired As MySqlParameter = cmd.Parameters.Add("in_dateHired", MySqlDbType.Date)
            dateHired.Value = employee.dateHired

            'Salary and others
            Dim numOfDependent As MySqlParameter = cmd.Parameters.Add("in_numOfDependent", MySqlDbType.UInt16)
            numOfDependent.Value = employee.numOfDependents
            Dim payMethod As MySqlParameter = cmd.Parameters.Add("in_payMethod", MySqlDbType.VarChar)
            payMethod.Value = employee.payMethod
            Dim basicRate As MySqlParameter = cmd.Parameters.Add("in_basicRate", MySqlDbType.Double)
            basicRate.Value = employee.basicRate
            Dim regOT_rate As MySqlParameter = cmd.Parameters.Add("in_regOT_rate", MySqlDbType.Decimal)
            regOT_rate.Value = employee.regOt_rate
            Dim sunOT_rate As MySqlParameter = cmd.Parameters.Add("in_sunOT_rate", MySqlDbType.Decimal)
            sunOT_rate.Value = employee.sunOt_rate
            Dim holOT_rate As MySqlParameter = cmd.Parameters.Add("in_holOT_rate", MySqlDbType.Decimal)
            holOT_rate.Value = employee.holOt_rate
            Dim personalLoan As MySqlParameter = cmd.Parameters.Add("in_personalLoan", MySqlDbType.Double)
            personalLoan.Value = employee.personalLoan
            Dim SSS_Loan As MySqlParameter = cmd.Parameters.Add("in_SSS_Loan", MySqlDbType.Double)
            SSS_Loan.Value = employee.SSS_Loan
            Dim Wtax_isDeduct As MySqlParameter = cmd.Parameters.AddWithValue("in_Wtax_isDeduct", employee.WTax_isDeduct)
            Dim SSS_isDeduct As MySqlParameter = cmd.Parameters.AddWithValue("in_SSS_isDeduct", employee.SSS_isDeduct)
            Dim philHealth_isDeduct As MySqlParameter = cmd.Parameters.AddWithValue("in_philHealth_isDeduct", employee.philHealth_isDeduct)
            Dim PAGIBIG_isDeduct As MySqlParameter = cmd.Parameters.AddWithValue("in_PAGIBIG_isDeduct", employee.PAGIBIG_isDeduct)

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            Dim i As Integer = cmd.ExecuteNonQuery()
            closeConnection()

            ret_ID = primaryKey.Value
            employee.empNum = ret_ID
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
                        MySQLErrorNumToString(myex.Number, "Adding new employee failed!"), _
                        DataAccessExceptionCode.Employee_add)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Adding new employee failed!", DataAccessExceptionCode.Employee_add)
        Finally
            closeConnection()

        End Try

        Return employee
    End Function

    Public Function updatePersonalInfo(ByVal employee As IEmployee) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Employee_updatePersonal_Info", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            pKey.Value = employee.empNum

            Dim fn As MySqlParameter = cmd.Parameters.Add("in_firstName", MySqlDbType.VarChar)
            fn.Value = employee.firstName
            Dim ln As MySqlParameter = cmd.Parameters.Add("in_lastName", MySqlDbType.VarChar)
            ln.Value = employee.lastName
            Dim mn As MySqlParameter = cmd.Parameters.Add("in_middleName", MySqlDbType.VarChar)
            mn.Value = employee.middleName
            Dim gender As MySqlParameter = cmd.Parameters.Add("in_gender", MySqlDbType.VarChar)
            gender.Value = employee.gender
            Dim birthDate As MySqlParameter = cmd.Parameters.Add("in_birthDate", MySqlDbType.Date)
            birthDate.Value = employee.birthDate
            Dim civilStatus As MySqlParameter = cmd.Parameters.Add("in_civilStatus", MySqlDbType.VarChar)
            civilStatus.Value = employee.civilStat
            Dim address As MySqlParameter = cmd.Parameters.Add("in_address", MySqlDbType.VarChar)
            address.Value = employee.address
            Dim city As MySqlParameter = cmd.Parameters.Add("in_city", MySqlDbType.VarChar)
            city.Value = employee.city
            Dim contactNum As MySqlParameter = cmd.Parameters.Add("in_contactNum", MySqlDbType.VarChar)
            contactNum.Value = employee.contactNum
            Dim email As MySqlParameter = cmd.Parameters.Add("in_email", MySqlDbType.VarChar)
            email.Value = employee.email
            Dim SSS_num As MySqlParameter = cmd.Parameters.Add("in_SSS_num", MySqlDbType.VarChar)
            SSS_num.Value = employee.SSS_Num
            Dim TIN_num As MySqlParameter = cmd.Parameters.Add("in_TIN_num", MySqlDbType.VarChar)
            TIN_num.Value = employee.TIN_Num
            Dim philHealth_num As MySqlParameter = cmd.Parameters.Add("in_philHealth_num", MySqlDbType.VarChar)
            philHealth_num.Value = employee.philHealth_Num
            Dim PAGIBIG_num As MySqlParameter = cmd.Parameters.Add("in_PAGIBIG_num", MySqlDbType.VarChar)
            PAGIBIG_num.Value = employee.PAGIBIG_Num
            Dim PRC_num As MySqlParameter = cmd.Parameters.Add("in_PRC_num", MySqlDbType.VarChar)
            PRC_num.Value = employee.PRC_Num
            Dim status As MySqlParameter = cmd.Parameters.Add("in_status", MySqlDbType.VarChar)
            status.Value = employee.status
            Dim dateHired As MySqlParameter = cmd.Parameters.Add("in_dateHired", MySqlDbType.Date)
            dateHired.Value = employee.dateHired

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, String.Format("Updating employee '{0} {1}' personal information failed!", _
                                                             employee.firstName, employee.lastName)), _
            DataAccessExceptionCode.Employee_updatePersonalInfo)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException(String.Format("Updating employee '{0} {1}' personal information failed!", _
                                                             employee.firstName, employee.lastName), _
            DataAccessExceptionCode.Employee_updatePersonalInfo)
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    Public Function updateSalaryInfo(ByVal employee As IEmployee) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Employee_updateSalaryInfo", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            pKey.Value = employee.empNum

            Dim numOfDependent As MySqlParameter = cmd.Parameters.Add("in_numOfDependent", MySqlDbType.UInt16)
            numOfDependent.Value = employee.numOfDependents
            Dim payMethod As MySqlParameter = cmd.Parameters.Add("in_payMethod", MySqlDbType.VarChar)
            payMethod.Value = employee.payMethod
            Dim basicRate As MySqlParameter = cmd.Parameters.Add("in_basicRate", MySqlDbType.Double)
            basicRate.Value = employee.basicRate
            Dim regOT_rate As MySqlParameter = cmd.Parameters.Add("in_regOT_rate", MySqlDbType.Decimal)
            regOT_rate.Value = employee.regOt_rate
            Dim sunOT_rate As MySqlParameter = cmd.Parameters.Add("in_sunOT_rate", MySqlDbType.Decimal)
            sunOT_rate.Value = employee.sunOt_rate
            Dim holOT_rate As MySqlParameter = cmd.Parameters.Add("in_holOT_rate", MySqlDbType.Decimal)
            holOT_rate.Value = employee.holOt_rate
            Dim personalLoan As MySqlParameter = cmd.Parameters.Add("in_personalLoan", MySqlDbType.Double)
            personalLoan.Value = employee.personalLoan
            Dim SSS_Loan As MySqlParameter = cmd.Parameters.Add("in_SSS_Loan", MySqlDbType.Double)
            SSS_Loan.Value = employee.SSS_Loan
            Dim Wtax_isDeduct As MySqlParameter = cmd.Parameters.AddWithValue("in_Wtax_isDeduct", employee.WTax_isDeduct)
            Dim SSS_isDeduct As MySqlParameter = cmd.Parameters.AddWithValue("in_SSS_isDeduct", employee.SSS_isDeduct)
            Dim philHealth_isDeduct As MySqlParameter = cmd.Parameters.AddWithValue("in_philHealth_isDeduct", employee.philHealth_isDeduct)
            Dim PAGIBIG_isDeduct As MySqlParameter = cmd.Parameters.AddWithValue("in_PAGIBIG_isDeduct", employee.PAGIBIG_isDeduct)

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("in_lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, String.Format("Updating employee '{0} {1}' salary and other information failed!", _
                                                             employee.firstName, employee.lastName)), _
            DataAccessExceptionCode.Employee_updatePersonalInfo)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException(String.Format("Updating employee '{0} {1}' salary and other information failed!", _
                                                             employee.firstName, employee.lastName), _
            DataAccessExceptionCode.Employee_updatePersonalInfo)
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    Public Function updatePersonalLoan(ByVal employeeNumber As UInteger, ByVal newValue As Double) As Integer
        Dim i As Integer = 0
        Try
            Dim cmd As New MySqlCommand("usp_Employee_updatePersonalLoan", conn)
            cmd.CommandType = CommandType.StoredProcedure
            'PARAMs
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            pKey.Value = employeeNumber

            Dim param As MySqlParameter = cmd.Parameters.Add("in_newValue", MySqlDbType.Decimal)
            param.Value = newValue

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "An error occur while updating personal loan."), _
            DataAccessExceptionCode.Employee_updatePersonalLoan)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while updating personal loan.", DataAccessExceptionCode.Employee_updatePersonalLoan)
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    Public Function retrieveAll() As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("SELECT * FROM tblEmployee", conn)

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving employee records failed!", _
                                          DataAccessExceptionCode.Employee_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving employee records failed!", _
                                          DataAccessExceptionCode.Employee_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    'Unlocked employees are those who are not in the 7 days locked-in period of payroll.
    'Locked-in mechanism is implemented logically on SQL query
    Public Function retrieveUnlockedEmployee() As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_Employee_getUnlocked", conn)
            cmd.CommandType = CommandType.StoredProcedure

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving employee records failed!", _
                                          DataAccessExceptionCode.Employee_getUnlockedEmployee)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving employee records failed!", _
                                          DataAccessExceptionCode.Employee_getUnlockedEmployee)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrievePersonalInfo() As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT ")
        End With

        Try
            Dim cmd As New MySqlCommand("SELECT * FROM tblEmployee", conn)

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving employee records failed!", _
                                          DataAccessExceptionCode.Employee_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving employee records failed!", _
                                          DataAccessExceptionCode.Employee_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function


    Public Function retrieveByEmpNum(ByVal employeeID As UInteger) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            Dim cmd As New MySqlCommand("usp_Employee_getByEmpNum", conn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim pKey As MySqlParameter = cmd.Parameters.Add("in_empNum", MySqlDbType.UInt32)
            pKey.Value = employeeID

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving employee failed!", DataAccessExceptionCode.Employee_getByEmpNum)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving employee failed!", DataAccessExceptionCode.Employee_getByEmpNum)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function


    ''These two function below maybe of no use
    'Public Function retrieveByLN(ByVal lastName As String) As DataTable

    'End Function

    'Public Function changeStatus(ByVal employeeNumber As UInteger, ByVal status As String) As Integer

    'End Function

End Class