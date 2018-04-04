Imports System.Data
Imports CrossCutting
Imports DataAccess

Public Class WTax_Util

    Public Function generateWTax(ByVal statusCode As UInt16,
                                 ByVal payMethod As String, _
                                 ByVal taxableIncome As Double) As Double
        Dim wtax As Double
        Dim over As Double
        Dim baseBracket As Double
        Dim taxBracket As Double

        Try
            Dim wtaxDAO As New WTax_DAO
            Dim drv As DataRowView = wtaxDAO.find_TaxVariables(statusCode, payMethod, taxableIncome)
            If drv Is Nothing Then Return 0
            'Extract Variables
            over = CDbl(drv("over"))
            baseBracket = CDbl(DBNullToNumeric(drv("baseBracket")))
            taxBracket = CDbl(DBNullToNumeric(drv("exemption")))
            wtax = ((taxableIncome - taxBracket) * over) + baseBracket
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

        Return wtax
    End Function
End Class