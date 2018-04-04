Imports System.Data
Imports CrossCutting
Imports Bridge
Imports DataAccess
Imports BusinessLogic.BusinessEntity

Public Class BonusUtility
    Inherits ManagerBase

    Private bonus_DAO As Bonus_DAO
    Private bonus As Bonus

    Sub New()
        bonus_DAO = New Bonus_DAO
    End Sub

    Public Function add(ByVal bonus As Bonus) As UInteger
        Me.bonus = bonus
        Dim i As UInteger = 0
        Try
            If Me.bonus Is Nothing Then
                Throw New Exception("`bonus` needs to be instantiated.")
            End If
            insert_inspectData()
            i = bonus_DAO.add(bonus)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Finally
            Me.bonus = Nothing
        End Try
        Return i
    End Function

    Public Function delete(ByVal ID As UInteger) As Integer
        Dim i As UInteger = 0
        Try
            Dim bonus_DAO As New Bonus_DAO
            i = bonus_DAO.delete(ID)
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
            Dim bonus_DAO As New Bonus_DAO
            dTable = bonus_DAO.retrieveAll(settled)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Public Function getBonusTotalForEmployee(ByVal employeeNumber As UInteger) As Double
        Dim total As Double
        Try
            Dim bonus_DAO As New Bonus_DAO
            total = bonus_DAO.getTotalForEmployee(employeeNumber)
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
            Dim bonus_DAO As New Bonus_DAO
            dTable = bonus_DAO.retrieveAllForPayroll(employeeNumber)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Public Overloads Function retrieveByPayrollNum(ByVal payrollNum As UInteger) As DataTable
        Dim dTable As DataTable
        Try
            Dim bonus_DAO As New Bonus_DAO
            dTable = bonus_DAO.retrieveByPayrollNum(payrollNum)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function


    Protected Overrides Sub insert_checkRequiredData()
        With bonus
            Try
                NON_ZERO(.empNum)
            Catch bex As BusinessException
                bex.overrideMessage("`Employee Number` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.bonusTypeCode)
            Catch bex As BusinessException
                bex.overrideMessage("`Bonus type` is required.")
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

    Protected Overrides Sub insert_validateData()

    End Sub

    Protected Overrides Sub update_checkRequiredData()

    End Sub

    Protected Overrides Sub update_validateData()

    End Sub
End Class
