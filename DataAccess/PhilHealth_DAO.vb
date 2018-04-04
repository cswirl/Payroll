Imports System.Data
Imports MySql.Data.MySqlClient
Imports CrossCutting

Public Class PhilHealth_DAO
    Private conn As MySqlConnection

    Public Function retrieveAll(ByRef adapter As MySqlDataAdapter) As DataSet
        Dim ds As New DataSet
        adapter = New MySqlDataAdapter
        Try
            If conn Is Nothing Then conn = New MySqlConnection(getConnectionString_Deductables)
            'Fill Base Bracket Over
            Dim cmd As New MySqlCommand("SELECT ID, rangeFrom, rangeTo, sal_base, ees, ers, (ees + ers) AS tmc FROM tblPhilHealth ORDER BY rangeFrom", conn)

            adapter.SelectCommand = cmd
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            adapter.Fill(ds, "tblPhilHealth")

            Dim cmdBuilder As New MySqlCommandBuilder(adapter)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving `PhilHealth` failed!", DataAccessExceptionCode.PhilHealth_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving `PhilHealth` failed!", DataAccessExceptionCode.PhilHealth_getAll)
        End Try

        Return ds
    End Function

    Public Function find_Contribution(ByVal basicPay As Double) As Double
        Dim contrib As Double = 0
        Try
            Using conn As New MySqlConnection(getConnectionString_Deductables)
                Dim cmd As New MySqlCommand("usp_PhilHealth_findContribution", conn)
                cmd.CommandType = CommandType.StoredProcedure
                Dim _basicPay As MySqlParameter = cmd.Parameters.Add("in_basicPay", MySqlDbType.Decimal)
                _basicPay.Value = basicPay

                conn.Open()
                contrib = CDbl(DBNullToNumeric(cmd.ExecuteScalar))

            End Using
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Finding PhilHealth contribution failed!", DataAccessExceptionCode.PhilHealth_find_Contribution)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Finding PhilHealth contribution failed!", DataAccessExceptionCode.PhilHealth_find_Contribution)
        End Try
        Return contrib
    End Function

    Public Function getRangeFrom_minimum() As Double
        Dim contrib As Double = 0
        Try
            Using conn As New MySqlConnection(getConnectionString_Deductables)
                Dim cmd As New MySqlCommand("SELECT MIN(rangeFrom) FROM tblPhilHealth", conn)

                conn.Open()
                contrib = CDbl(DBNullToNumeric(cmd.ExecuteScalar))
            End Using
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Getting minimum 'range from' failed!", DataAccessExceptionCode.PhilHealth_getRangeFrom_minimum)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Getting minimum 'range from' failed!", DataAccessExceptionCode.PhilHealth_getRangeFrom_minimum)
        End Try
        Return contrib
    End Function
End Class