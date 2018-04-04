Imports System.Data
Imports CrossCutting
Imports Bridge
Imports DataAccess
Imports BusinessLogic.BusinessEntity

Public Class AllowanceUtility

    Private allow_DAO As Allowance_DAO
    Private empAllow As EmployeeAllowance

    Sub New()
        allow_DAO = New Allowance_DAO
    End Sub

    Public Function add(ByVal allowance As EmployeeAllowance, _
                                  Optional ByVal unprocessed As Boolean = True) As UInteger
        empAllow = allowance
        Dim i As UInteger = 0
        Try
            If empAllow Is Nothing Then
                Throw New Exception("`allowance` needs to be instantiated.")
            End If
            insert_inspectData()
            i = allow_DAO.add(allowance)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Finally
            empAllow = Nothing
        End Try
        Return i
    End Function

    Public Function delete(ByVal allowanceNum As UInteger) As Integer
        Dim i As UInteger = 0
        Try
            i = allow_DAO.delete(allowanceNum)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return i
    End Function

    Public Overloads Function retrieveAll(Optional ByVal unprocessed As _
                                                    Boolean = True) As DataTable
        Dim dTable As DataTable
        Try
            dTable = allow_DAO.retrieveAll(unprocessed)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Public Function retrieveProcessedByPayrollNum(ByVal payrollNumber As UInteger) As DataTable
        Dim dTable As DataTable
        Try
            dTable = allow_DAO.retrieveProcessedByPayrollNum(payrollNumber)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Protected Overridable Sub insert_inspectData()
        Try
            insert_validateData()
            insert_checkRequiredData()
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub

    Protected Sub insert_validateData()
    End Sub

    Protected Sub insert_checkRequiredData()
        With empAllow
            Try
                NON_ZERO(.empNum)
            Catch bex As BusinessException
                bex.overrideMessage("`Employee number` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.allowTypeCode)
            Catch bex As BusinessException
                bex.overrideMessage("`Allowance type` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.amount)
            Catch bex As BusinessException
                bex.overrideMessage("`Amount` is required.")
                Throw bex
            End Try
        End With
    End Sub

    Public Overloads Function retrieveAllForPayroll(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As DataTable
        Try
            dTable = allow_DAO.retrieveAllForPayroll(employeeNumber)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Public Overloads Function getTotalForEmployee(ByVal employeeNumber As UInteger, _
                                                  ByVal taxable As Boolean) As Double
        Dim total As Double
        Try
            total = allow_DAO.getTotalForEmployee(employeeNumber, taxable)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return total
    End Function

    Public Overloads Function getTotalForEmployee(ByVal employeeNumber As UInteger) As Double
        Dim total As Double
        Try
            total = allow_DAO.getTotalForEmployee(employeeNumber)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return total
    End Function

    Public Overloads Function getTotalForReversal(ByVal payrollNumber As UInteger, _
                                                  ByVal taxable As Boolean) As Double
        Dim total As Double
        Try
            total = allow_DAO.getTotalForReversal(payrollNumber, taxable)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return total
    End Function
End Class