Imports System.Data
Imports CrossCutting
Imports Bridge
Imports DataAccess
Imports BusinessLogic.BusinessEntity

Public Class OtherDeductionUtility

    Private deduct_DAO As OtherDeduction_DAO
    Private deduct As OtherDeduction

    Sub New()
        deduct_DAO = New OtherDeduction_DAO
    End Sub

    Public Function add(ByVal deduction As OtherDeduction) As UInteger
        deduct = deduction
        Dim i As UInteger = 0
        Try
            If deduct Is Nothing Then
                Throw New Exception("`deduction` needs to be instantiated.")
            End If
            insert_inspectData()
            i = deduct_DAO.add(deduction)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Finally
            deduct = Nothing
        End Try
        Return i
    End Function

    Public Function delete(ByVal ID As UInteger) As Integer
        Dim i As UInteger = 0
        Try
            i = deduct_DAO.delete(ID)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return i
    End Function

    Public Overloads Function retrieveAll(Optional ByVal settled As _
                                                    Boolean = False) As DataTable
        Dim dTable As DataTable
        Try
            dTable = deduct_DAO.retrieveAll(settled)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Public Function getTotalForEmployee(ByVal employeeNumber As UInteger) As Double
        Dim total As Double
        Try
            total = deduct_DAO.getTotalForEmployee(employeeNumber)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return total
    End Function

    Public Overloads Function retrieveAllForPayroll(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As DataTable
        Try
            dTable = deduct_DAO.retrieveAllForPayroll(employeeNumber)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Public Function retrieveSettledByPayrollNum(ByVal payrollNumber As UInteger) As DataTable
        Dim dTable As DataTable
        Try
            dTable = deduct_DAO.retrieveSettledByPayrollNum(payrollNumber)
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
        With deduct
            Try
                NON_ZERO(.empNum)
            Catch bex As BusinessException
                bex.overrideMessage("`Employee number` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.deductTypeCode)
            Catch bex As BusinessException
                bex.overrideMessage("`Deduction type` is required.")
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

    Public Function getTotalForReversal(ByVal payrollNumber As UInteger) As Double
        Dim total As Double
        Try
            total = deduct_DAO.getTotalForReversal(payrollNumber)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return total
    End Function
End Class