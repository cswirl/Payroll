Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrossCutting

Public Class WTax_DAO

    Private conn As MySqlConnection

    Public Function retrieveBaseBracket_Over(ByRef adapter As MySqlDataAdapter) As DataSet
        Dim ds As New DataSet
        adapter = New MySqlDataAdapter
        Try
            If conn Is Nothing Then conn = New MySqlConnection(getConnectionString_Deductables)
            'Fill Base Bracket Over
            Dim cmd As New MySqlCommand("SELECT * FROM tblBaseBracket_Over", conn)

            adapter.SelectCommand = cmd
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            adapter.Fill(ds, MyTables_ToString(MyTables.BaseBracketOver))

            Dim cmdBuilder As New MySqlCommandBuilder(adapter)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving Base Bracket Over failed!", DataAccessExceptionCode.WTax_getBaseBracket_over
                                          )
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving Base Bracket Over failed!", DataAccessExceptionCode.WTax_getBaseBracket_over)
        End Try

        Return ds
    End Function

    Public Function retrieveBaseBracket(ByRef adapter As MySqlDataAdapter, ByVal payMethod As PayMethods) As DataSet
        Dim ds As New DataSet
        adapter = New MySqlDataAdapter
        Try
            If conn Is Nothing Then conn = New MySqlConnection(getConnectionString_Deductables)
            Dim cmd As New MySqlCommand("SELECT * FROM tblBaseBracket WHERE payMethod = ?payMethod ORDER BY baseCode", conn)

            adapter.SelectCommand = cmd
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

            'BEWARE OF TYPE ENUM
            Dim paramPayMethod As MySqlParameter = cmd.Parameters.Add("?payMethod", MySqlDbType.Enum)
            paramPayMethod.Value = Paymethod_ToString(payMethod)

            'Fill Base Bracket
            adapter.Fill(ds, MyTables_ToString(MyTables.BaseBracket))

            Dim cmdBuilder As New MySqlCommandBuilder(adapter)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving Base Bracket failed!", DataAccessExceptionCode.WTax_getBaseBracket)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving Base Bracket failed!", DataAccessExceptionCode.WTax_getBaseBracket)
        End Try

        Return ds
    End Function

    Public Function retrieveTaxBracket(ByRef adapter As MySqlDataAdapter, ByVal payMethod As PayMethods) As DataSet
        Dim ds As New DataSet
        adapter = New MySqlDataAdapter
        Try
            If conn Is Nothing Then conn = New MySqlConnection(getConnectionString_Deductables)
            'Fill Base Bracket Over
            Dim cmd As New MySqlCommand("SELECT * FROM tblTaxBracket WHERE payMethod = ?payMethod ORDER BY statusCode, baseCode", conn)

            adapter.SelectCommand = cmd
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            
            Dim paramPayMethod As MySqlParameter = cmd.Parameters.Add("?payMethod", MySqlDbType.Enum)
            paramPayMethod.Value = Paymethod_ToString(payMethod)
            adapter.Fill(ds, MyTables_ToString(MyTables.TaxBracket))

            Dim cmdBuilder As New MySqlCommandBuilder(adapter)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving Tax Bracket failed!", DataAccessExceptionCode.WTax_getTaxBracket)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving Tax Bracket failed!", DataAccessExceptionCode.WTax_getTaxBracket)
        End Try

        Return ds
    End Function

    Public Function find_TaxVariables(ByVal statusCode As UInt16, ByVal payMethod As String, _
                                      ByVal taxableIncome As Double) As DataRowView
        Dim drv As DataRowView = Nothing
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            If conn Is Nothing Then conn = New MySqlConnection(getConnectionString_Deductables)
            Dim cmd As New MySqlCommand("usp_WTAX_findWTaxVariables", conn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim _statusCode As MySqlParameter = cmd.Parameters.Add("in_statusCode", MySqlDbType.UInt16)
            _statusCode.Value = statusCode

            Dim _payMethod As MySqlParameter = cmd.Parameters.Add("in_payMethod", MySqlDbType.VarChar)
            _payMethod.Value = payMethod

            Dim _taxableIncome As MySqlParameter = cmd.Parameters.Add("in_taxableIncome", MySqlDbType.Decimal)
            _taxableIncome.Value = taxableIncome

            adapter.SelectCommand = cmd
            adapter.Fill(dTable)

            If dTable.Rows.Count = 1 Then
                drv = dTable.DefaultView.Item(0)
            Else
                Return Nothing
            End If
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Finding WTax variables failed!", DataAccessExceptionCode.WTax_find_TaxVariables)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Finding WTax variables failed!", DataAccessExceptionCode.WTax_find_TaxVariables)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try
        Return drv
    End Function


    Enum MyTables
        BaseBracketOver
        TaxBracket
        BaseBracket
    End Enum

    Public Shared Function MyTables_ToString(ByVal myTable As MyTables) As String
        Select Case myTable
            Case MyTables.BaseBracketOver
                Return "BaseBracketOver"
            Case MyTables.TaxBracket
                Return "TaxBracket"
            Case MyTables.BaseBracket
                Return "BaseBracket"
            Case Else
                Throw New BusinessException("Invalid Pay Method.")
        End Select
    End Function

    Enum PayMethods
        Daily
        Weekly
        Semi
        Monthly
    End Enum

    Public Shared Function Paymethod_ToString(ByVal payMethod As PayMethods) As String
        Select Case payMethod
            Case PayMethods.Daily
                Return "Daily"
            Case PayMethods.Weekly
                Return "Weekly"
            Case PayMethods.Semi
                Return "Semi"
            Case PayMethods.Monthly
                Return "Monthly"
            Case Else
                Throw New BusinessException("Invalid Pay Method.")
        End Select
    End Function
End Class