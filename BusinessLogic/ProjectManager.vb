Imports System.Data
Imports CrossCutting
Imports Bridge
Imports DataAccess
Imports BusinessLogic.BusinessEntity

Public Class ProjectManager
    Inherits ManagerBase

    Private proj_DAO As Project_DAO
    Private project As Project

    Sub New()
        proj_DAO = New Project_DAO
    End Sub

    Public Function add(ByVal project As Bridge.IProject) As UInteger
        Me.project = project
        Dim i As UInteger = 0
        Try
            If Me.project Is Nothing Then
                Throw New Exception("`project` needs to be instantiated.")
            End If
            insert_inspectData()
            i = proj_DAO.add(project)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Finally
            Me.project = Nothing
        End Try
        Return i
    End Function

    Public Function retrieveAll() As DataTable
        Dim dTable As New DataTable
        Try
            dTable = proj_DAO.retrieveAll()
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    'Use for employee project User control
    Public Function retrieve_for_projectUC() As DataTable
        Dim dTable As New DataTable
        Try
            dTable = proj_DAO.retrieve_for_projectUC()
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function retrieveByEmpNum(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Try
            dTable = proj_DAO.retrieveByEmpNum(employeeNumber)
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function retrieveForReversal(ByVal payrollNum As UInteger) As DataTable
        Dim dTable As New DataTable
        Try
            dTable = proj_DAO.retrieveForReversal(payrollNum)
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function retrieveByEmpNum_denor_withKeys(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Try
            dTable = proj_DAO.retrieveByEmpNum_denor_withKeys(employeeNumber)
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function retrieveForPayroll(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Try
            dTable = proj_DAO.retrieveForPayroll(employeeNumber)
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function getWorkdaysAndOTs(ByVal employeeNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Try
            dTable = proj_DAO.getWorkdaysAndOTs(employeeNumber)
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function getWorkdaysAndOTsForReversal(ByVal payrollNumber As UInteger) As DataTable
        Dim dTable As New DataTable
        Try
            dTable = proj_DAO.getWorkdaysAndOTsForReversal(payrollNumber)
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return dTable
    End Function

    Public Function update(ByVal project As Bridge.IProject) As Integer
        Me.project = project
        Dim i As Integer = 0
        Try
            If Me.project Is Nothing Then
                Throw New Exception("`project instance` is not initialized.")
            End If
            update_inspectData()
            i = proj_DAO.update(project)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Finally
            Me.project = Nothing
        End Try

        Return i
    End Function

    Public Function delete(ByVal project_ID As UInteger) As Integer
        Dim i As Integer = 0
        Try
            If project_ID < 1 Then
                Throw New BusinessException("Invalid project ID.")
            End If

            i = proj_DAO.delete(project_ID)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

        Return i
    End Function

    Public Function getEmpNum(ByVal key As UInteger, Optional ByVal processed As Boolean = True) As UInteger
        Dim empNum As UInteger = 0
        Try
            empNum = proj_DAO.getEmpNum(key)
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return empNum
    End Function

    Protected Overrides Sub insert_checkRequiredData()
        With project
            Try
                NON_ZERO(.empNum)
            Catch bex As BusinessException
                bex.overrideMessage("Project must be place on an Employee.")
                Throw bex
            End Try

            Try
                NON_ZERO(.proj_ID)
            Catch bex As BusinessException
                bex.overrideMessage("`Project name` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.position_ID)
            Catch bex As BusinessException
                bex.overrideMessage("`Position` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.div_ID)
            Catch bex As BusinessException
                bex.overrideMessage("`Division` is required.")
                Throw bex
            End Try
        End With
    End Sub

    Protected Overrides Sub insert_validateData()
    End Sub

    Protected Overrides Sub update_checkRequiredData()
        With project
            Try
                NON_ZERO(.proj_ID)
            Catch bex As BusinessException
                bex.overrideMessage("`Project name` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.position_ID)
            Catch bex As BusinessException
                bex.overrideMessage("`Position` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.div_ID)
            Catch bex As BusinessException
                bex.overrideMessage("`Division` is required.")
                Throw bex
            End Try
        End With
    End Sub

    Protected Overrides Sub update_validateData()

    End Sub

    Public Function flag_head(ByVal project_ID As UInteger, ByVal empNum As UInteger) As Integer
        Dim i As Integer
        Try
            i = proj_DAO.flag_head(project_ID, empNum)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
        Return i
    End Function
End Class