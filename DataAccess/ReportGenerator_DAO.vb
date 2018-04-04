Imports MySql.Data.MySqlClient
Imports System.Data
Imports CrossCutting
Imports Bridge

Public Class ReportGenerator_DAO
    Inherits DataAccessBase

    'TODO: Filter by Date
    Public Function Daily() As DataSet
        Dim myData As New DataSet
        'Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Try
            Dim cmd As New MySqlCommand("usp_Report_PayrollSheet_weekly", conn)
            cmd.CommandType = CommandType.StoredProcedure

            adapter.SelectCommand = cmd
            adapter.Fill(myData, "PayrollSheet")
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving `Payroll Sheet` failed!", DataAccessExceptionCode.RepGen_daily)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving `Payroll Sheet` failed!", DataAccessExceptionCode.RepGen_daily)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return myData
    End Function

    Public Function PayrollSheet() As DataSet
        Dim myData As New DataSet
        'Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Try
            Dim cmd As New MySqlCommand("usp_Report_PayrollSheet_weekly", conn)
            cmd.CommandType = CommandType.StoredProcedure

            adapter.SelectCommand = cmd
            adapter.Fill(myData, "PayrollSheet")
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving `Payroll Sheet` failed!", DataAccessExceptionCode.RepGen_daily)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving `Payroll Sheet` failed!", DataAccessExceptionCode.RepGen_daily)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return myData
    End Function

    Public Function ConsolidatePayrollReg() As DataSet
        Dim myData As New DataSet
        'Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Try
            Dim cmd As New MySqlCommand("usp_Report_ConsolidatedPayrollReg_weekly", conn)
            cmd.CommandType = CommandType.StoredProcedure

            adapter.SelectCommand = cmd
            adapter.Fill(myData, "ConsolidatedPayrollRegister")
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving `Consolidated Payroll Registert` failed!", DataAccessExceptionCode.RepGen_daily)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving `Consolidated Payroll Registert` failed!", DataAccessExceptionCode.RepGen_daily)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return myData
    End Function
End Class