Imports BusinessLogic.BusinessEntity
Imports CrossCutting
Imports DataAccess
Imports System.Data
Imports Bridge

Public Class ReportGenerator

    Friend WithEvents repGen_DAO As ReportGenerator_DAO

    Sub New()
        repGen_DAO = New ReportGenerator_DAO
    End Sub

    Public Enum Reports
        ConsolidatedPayrollRegister
        PayrollSheet
        SSS_Monthly_and_Weekly_Contri
        SSS_Monthly_and_Weekly_Contri_Sched
        NHIP_Monthly_Premium_Contri_Sched_2007
        Revised_WTax_Tables
        Thirteenth_MonthPay_Journal
    End Enum

    Public Enum PayMethod
        Daily
        Monthly
        All
    End Enum

    Public Shared Function getFilename(ByVal report As Reports) As String
        Select Case report
            Case Reports.ConsolidatedPayrollRegister
                Return "ConsolidatedPayrollRegister.rpt"
            Case Reports.PayrollSheet
                Return "PayrollSheet_Weekly.rpt"
            Case Reports.SSS_Monthly_and_Weekly_Contri
                Return ""
            Case Reports.SSS_Monthly_and_Weekly_Contri_Sched
                Return ""
            Case Reports.NHIP_Monthly_Premium_Contri_Sched_2007
                Return ""
            Case Reports.Revised_WTax_Tables
                Return ""
            Case Reports.Thirteenth_MonthPay_Journal
                Return ""
            Case Else
                Throw New MyApplicationException("Unknown payroll report.")
        End Select
    End Function

    Public Function getData(ByVal report As Reports, _
                            Optional ByVal payMethod As PayMethod = PayMethod.All) As DataSet
        Dim data As DataSet = Nothing
        Select Case report
            Case Reports.ConsolidatedPayrollRegister
                data = ConsolidatePayrollReg()
            Case Reports.PayrollSheet
                data = PayrollSheet()
            Case Reports.SSS_Monthly_and_Weekly_Contri

            Case Reports.SSS_Monthly_and_Weekly_Contri_Sched

            Case Reports.NHIP_Monthly_Premium_Contri_Sched_2007

            Case Reports.Revised_WTax_Tables

            Case Reports.Thirteenth_MonthPay_Journal

            Case Else
                Throw New MyApplicationException("Unknown payroll report.")
        End Select
        Return data
    End Function


    'BELOW ARE FOR TESTING
    Public Function Daily() As DataSet
        Dim ds As DataSet = Nothing
        Try
            ds = repGen_DAO.Daily
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Function PayrollSheet() As DataSet
        Dim ds As DataSet
        Try
            ds = repGen_DAO.PayrollSheet
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Function ConsolidatePayrollReg() As DataSet
        Dim ds As DataSet
        Try
            ds = repGen_DAO.ConsolidatePayrollReg
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Sub weekly()

    End Sub

    Public Sub semi()

    End Sub

    Public Sub monthly()

    End Sub
End Class