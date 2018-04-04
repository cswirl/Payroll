Imports Bridge
Imports BusinessLogic.BusinessEntity
Imports System.Data
Imports DataAccess
Imports CrossCutting

Public Class EmployeeManager
    Inherits ManagerBase

    Private empDAO As Employee_DAO
    Private empData_Courier As Employee

    Private infoRegionToInspect As New EmployeeInformationRegion

    Sub New()
        empDAO = New Employee_DAO
    End Sub

    ''' Returns the newly added employee including the primary keys
    Public Function add(ByVal employee As IEmployee) As Bridge.IEmployee
        empData_Courier = employee
        Dim emp As Employee
        Try
            If empData_Courier Is Nothing Then
                Throw New Exception("`Employee` needs to be instantiated.")
            End If
            'Set what region the infoRegionToInspect() method will inspect
            infoRegionToInspect = EmployeeInformationRegion.AllInfo
            insert_inspectData()
            emp = empDAO.add(employee)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw ex
        Finally
            'Release the object after use
            empData_Courier = Nothing
        End Try

        Return emp
    End Function

    Public Function updatePersonalInfo(ByVal employee As IEmployee) As Integer
        empData_Courier = employee
        Dim i As Integer = 0
        Try
            If empData_Courier Is Nothing Then
                Throw New Exception("`Employee` is not initialized.")
            End If
            infoRegionToInspect = EmployeeInformationRegion.PersonalInfo
            update_inspectData()

            i = empDAO.updatePersonalInfo(employee)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw ex
        Finally
            'Release the object after use
            empData_Courier = Nothing
        End Try

        Return i
    End Function

    Public Function updateSalaryInfo(ByVal employee As IEmployee) As Integer
        empData_Courier = employee
        Dim i As Integer = 0
        Try
            If empData_Courier Is Nothing Then
                Throw New Exception("`Employee` is not initialized.")
            End If
            infoRegionToInspect = EmployeeInformationRegion.SalaryInfo
            update_inspectData()

            i = empDAO.updateSalaryInfo(employee)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw ex
        Finally
            'Release the object after use
            empData_Courier = Nothing
        End Try

        Return i
    End Function

    Public Function updatePersonalLoan(ByVal employeeNumber As UInteger, ByVal newValue As Double) As Integer
        Dim i As Integer = 0
        Try
            If employeeNumber < 1 Then
                Throw New Exception("Invalid employee number.")
            End If
            i = empDAO.updatePersonalLoan(employeeNumber, newValue)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw ex
        End Try

        Return i
    End Function

    Public Function retrieveAll() As DataTable
        Dim dTable As New DataTable
        Try
            dTable = empDAO.retrieveAll
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function retrieveUnlockedEmployee() As DataTable
        Dim dTable As New DataTable
        Try
            dTable = empDAO.retrieveUnlockedEmployee
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function getList() As EmployeeList
        Dim empList As New EmployeeList

        Return empList
    End Function

    ''TODO: retrieveByEmpNum
    Public Overloads Function retrieveByEmpNum(ByVal employeeNumber As String) As IEmployee
        Dim strEmpNum As String
        Try
            strEmpNum = stringChecker(employeeNumber, 0)
        Catch sqliex As SQLInjectionException
            'Log the suspected 'value' and throw as an BusinessException
            Logger.possibleSQLInjection(employeeNumber, sqliex.StackTrace)
            sqliex.overrideMessage("`Employee Number`" & sqliex.Message)
            Throw sqliex
        Catch bex As BusinessException
            bex.overrideMessage("`Employee Number`" & bex.Message)
            Throw bex
        End Try

        Dim emplist As EmployeeList = getList()
        For Each emp As Employee In emplist
            If emp.getFormattedEmpNum.Equals(employeeNumber) Then
                Return emp
            End If
        Next

        Return Nothing
    End Function

    Public Overloads Function retrieveByEmpNum(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As DataTable
        Try
            dTable = empDAO.retrieveByEmpNum(employeeNumber)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
        Return dTable
    End Function

    ''This function can be remove
    'Public Function changeStatus(ByVal employeeNumber As UInteger, ByVal status As String) As Integer
    '    Dim i As Integer = 0
    '    Try
    '        i = empDAO.changeStatus(employeeNumber, status)
    '    Catch daex As DataAccessException
    '        Throw daex
    '    End Try

    '    Return i
    'End Function

#Region "Manager Base"
    Protected Overrides Sub insert_checkRequiredData()
        Try
            personalInfo_checkRequiredData(empData_Courier)
            salaryInfo_checkRequiredData(empData_Courier)
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub

    Protected Overrides Sub insert_validateData()
        Try
            personalInfo_validateData(empData_Courier)
            salaryInfo_validateData(empData_Courier)
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub

    '
    Protected Overrides Sub update_checkRequiredData()
        Try
            Select Case infoRegionToInspect
                Case EmployeeInformationRegion.PersonalInfo
                    personalInfo_checkRequiredData(empData_Courier)
                Case EmployeeInformationRegion.SalaryInfo
                    salaryInfo_checkRequiredData(empData_Courier)
                Case EmployeeInformationRegion.AllInfo
                    personalInfo_checkRequiredData(empData_Courier)
                    salaryInfo_checkRequiredData(empData_Courier)
            End Select
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub

    Protected Overrides Sub update_validateData()
        Try
            Select Case infoRegionToInspect
                Case EmployeeInformationRegion.PersonalInfo
                    personalInfo_validateData(empData_Courier)
                Case EmployeeInformationRegion.SalaryInfo
                    salaryInfo_validateData(empData_Courier)
                Case EmployeeInformationRegion.AllInfo
                    personalInfo_validateData(empData_Courier)
                    salaryInfo_validateData(empData_Courier)
            End Select
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub

#End Region

    '''Employee Manager Preference
    ''Used by instance of this class and can also by Other class who used an instance of this
    ''Personal Information Requirements
    Public Overridable Sub personalInfo_checkRequiredData(ByVal employee As IEmployee)
        With employee
            Try
                REQUIRED(.lastName)
            Catch bex As BusinessException
                bex.overrideMessage("`Last name` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.firstName)
            Catch bex As BusinessException
                bex.overrideMessage("`First name` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.gender)
            Catch bex As BusinessException
                bex.overrideMessage("`Gender` is required.")
                Throw bex
            End Try

            'Try
            '    REQUIRED(.address)
            'Catch bex As BusinessException
            '    bex.overrideMessage("`Address` is required.")
            '    Throw bex
            'End Try

            'Try
            '    REQUIRED(.city)
            'Catch bex As BusinessException
            '    bex.overrideMessage("`City` is required.")
            '    Throw bex
            'End Try

            Try
                REQUIRED(.civilStat)
            Catch bex As BusinessException
                bex.overrideMessage("`Civil Status` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.birthDate)
            Catch bex As BusinessException
                bex.overrideMessage("`Birthdate` is required.")
                Throw bex
            End Try

            'Try
            '    REQUIRED(.contactNum)
            'Catch bex As BusinessException
            '    bex.overrideMessage("`Contact number` is required.")
            '    Throw bex
            'End Try

            'Try
            '    REQUIRED(.email)
            'Catch bex As BusinessException
            '    bex.overrideMessage("`Email` is required.")
            '    Throw bex
            'End Try

            'Try
            '    REQUIRED(.SSS_Num)
            'Catch bex As BusinessException
            '    bex.overrideMessage("??? is required.")
            '    Throw bex
            'End Try

            'Try
            '    REQUIRED(.TIN_Num)
            'Catch bex As BusinessException
            '    bex.overrideMessage("??? is required.")
            '    Throw bex
            'End Try

            'Try
            '    REQUIRED(.philHealth_Num)
            'Catch bex As BusinessException
            '    bex.overrideMessage("??? is required.")
            '    Throw bex
            'End Try

            'Try
            '    REQUIRED(.PAGIBIG_Num)
            'Catch bex As BusinessException
            '    bex.overrideMessage("??? is required.")
            '    Throw bex
            'End Try

            'Try
            '    REQUIRED(.PRC_Num)
            'Catch bex As BusinessException
            '    bex.overrideMessage("??? is required.")
            '    Throw bex
            'End Try

            Try
                REQUIRED(.dateHired)
            Catch bex As BusinessException
                bex.overrideMessage("Date Hired is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.status)
            Catch bex As BusinessException
                bex.overrideMessage("`Status` is required.")
                Throw bex
            End Try

        End With
    End Sub

    Public Overridable Sub personalInfo_validateData(ByVal employee As IEmployee)
        With employee
            Try
                stringChecker(.lastName, 40)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.lastName, sqliex.StackTrace)
                sqliex.overrideMessage("`Last name`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Last name`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.firstName, 40)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.firstName, sqliex.StackTrace)
                sqliex.overrideMessage("`First name`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`First name`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.gender, 10)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.gender, sqliex.StackTrace)
                sqliex.overrideMessage("`Gender`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Gender`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.address, 80)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.address, sqliex.StackTrace)
                sqliex.overrideMessage("`Address`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Address`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.city, 20)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.firstName, sqliex.StackTrace)
                sqliex.overrideMessage("`City`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`City`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.civilStat, 30)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.civilStat, sqliex.StackTrace)
                sqliex.overrideMessage("`Civil Status`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Civil Status`" & bex.Message)
                Throw bex
            End Try

            'Try
            '    REQUIRED(.birthDate)
            'Catch bex As BusinessException
            '    bex.overrideMessage("`Birthdate` is required.")
            '    Throw bex
            'End Try

            Try
                stringChecker(.contactNum, 30)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.contactNum, sqliex.StackTrace)
                sqliex.overrideMessage("`Contact Number`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Contact Number`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.email, 50)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.email, sqliex.StackTrace)
                sqliex.overrideMessage("`Email`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Email`" & bex.Message)
                Throw bex
            End Try


            Try
                stringChecker(.status, 30)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.status, sqliex.StackTrace)
                sqliex.overrideMessage("`Status`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Status`" & bex.Message)
                Throw bex
            End Try


            ''Affiliation
            Try
                stringChecker(.TIN_Num, 20)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.TIN_Num, sqliex.StackTrace)
                sqliex.overrideMessage("`TIN Number`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`TIN Number`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.SSS_Num, 20)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.SSS_Num, sqliex.StackTrace)
                sqliex.overrideMessage("`SSS Number`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`SSS Number`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.PRC_Num, 20)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.PRC_Num, sqliex.StackTrace)
                sqliex.overrideMessage("`PRC Number`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`PRC Number`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.philHealth_Num, 20)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.philHealth_Num, sqliex.StackTrace)
                sqliex.overrideMessage("`PhilHealth Number`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`PhilHealth Number`" & bex.Message)
                Throw bex
            End Try

            Try
                stringChecker(.PAGIBIG_Num, 20)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.PAGIBIG_Num, sqliex.StackTrace)
                sqliex.overrideMessage("`PAGIBIG Number`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`PAGIBIG Number`" & bex.Message)
                Throw bex
            End Try

        End With
    End Sub

    ''Salary Information Requirements
    Public Overridable Sub salaryInfo_checkRequiredData(ByVal employee As IEmployee)
        With employee
            Try
                NON_ZERO(.regOt_rate)
            Catch bex As BusinessException
                bex.overrideMessage("`regOT rate` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.sunOt_rate)
            Catch bex As BusinessException
                bex.overrideMessage("`sunOT rate` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.holOt_rate)
            Catch bex As BusinessException
                bex.overrideMessage("`holOt rate` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.payMethod)
            Catch bex As BusinessException
                bex.overrideMessage("`Pay Method` is required.")
                Throw bex
            End Try
        End With
    End Sub

    Public Overridable Sub salaryInfo_validateData(ByVal employee As IEmployee)
        With employee
            Try
                stringChecker(.payMethod, 20)
            Catch sqliex As SQLInjectionException
                'Log the suspected 'value' and throw an BusinessException
                Logger.possibleSQLInjection(.payMethod, sqliex.StackTrace)
                sqliex.overrideMessage("`Pay Method`" & sqliex.Message)
                Throw sqliex
            Catch bex As BusinessException
                bex.overrideMessage("`Pay Method`" & bex.Message)
                Throw bex
            End Try
        End With
    End Sub

    'Use to distinguish what employee information to inspect before passing data on the data access layer
    Private Enum EmployeeInformationRegion
        PersonalInfo
        SalaryInfo
        AllInfo
    End Enum

End Class