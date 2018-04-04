Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrossCutting

Public Class SSS_DAO

    Private conn As MySqlConnection

    Public Function retrieveAll(ByRef adapter As MySqlDataAdapter) As DataSet
        Dim ds As New DataSet
        adapter = New MySqlDataAdapter
        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("SELECT ID, rangeFrom, rangeTo, er_1, ee_1, (er_1 + ee_1) AS total_1, ")
            .Append("er_2, (er_1 + er_2) AS er_3, ee_1 AS ee_2, ((er_1 + er_2) + ee_1) AS total_2, (er_1 + ee_1) AS total_contri ")
            .Append("FROM tblSSS ORDER BY rangeFrom")
        End With
        Try
            If conn Is Nothing Then conn = New MySqlConnection(getConnectionString_Deductables)
            'Fill Base Bracket Over
            Dim cmd As New MySqlCommand(SQL.ToString, conn)

            adapter.SelectCommand = cmd
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            adapter.Fill(ds, "tblSSS")
            'ds.Tables(0).Columns("ID").AutoIncrement = True
            'ds.Tables(0).Columns("ID").AutoIncrementSeed = 1
            Dim cmdBuilder As New MySqlCommandBuilder(adapter)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving `SSS` failed!", DataAccessExceptionCode.SSS_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving `SSS` failed!", DataAccessExceptionCode.SSS_getAll)
        End Try

        Return ds
    End Function

    Public Function find_Contribution(ByVal basicPay As Double) As Double
        Dim contrib As Double = 0
        Try
            Using conn As New MySqlConnection(getConnectionString_Deductables)
                Dim cmd As New MySqlCommand("usp_SSS_findContribution", conn)
                cmd.CommandType = CommandType.StoredProcedure
                Dim _basicPay As MySqlParameter = cmd.Parameters.Add("in_basicPay", MySqlDbType.Decimal)
                _basicPay.Value = basicPay

                conn.Open()
                contrib = CDbl(DBNullToNumeric(cmd.ExecuteScalar))
            End Using
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Finding SSS contribution failed!", DataAccessExceptionCode.SSS_find_Contribution)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Finding SSS contribution failed!", DataAccessExceptionCode.SSS_find_Contribution)
        End Try
        Return contrib
    End Function
End Class