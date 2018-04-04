Imports System.Data
Imports System.Text
Imports System.Runtime.Serialization
Imports System.IO
Imports MySql.Data.MySqlClient
Imports CrossCutting

Public Class Log_DAO

    Public Shared didPrevOpen As Boolean = False

    Public Overloads Shared Sub log(ByVal message As String, ByVal stackTrace As String, _
                                    ByVal user_ID As UInteger, Optional ByVal code As Integer = 0)

        Dim SQL As New StringBuilder
        With SQL
            .Append("INSERT INTO tblLog ")
            .Append("(code, message, stackTrace, user_ID, dateCreated) ")
            .Append("VALUES(?code, ?message, ?stackTrace, ?user_ID, NOW())")
        End With
        Try
            Using conn As New MySqlConnection(getConnectionString)
                Dim cmd As New MySqlCommand(SQL.ToString, conn)
                'PARAMs
                Dim pcode As MySqlParameter = cmd.Parameters.Add("?code", MySqlDbType.UInt24)
                pcode.Value = code
                Dim pmessage As MySqlParameter = cmd.Parameters.Add("?message", MySqlDbType.MediumText)
                pmessage.Value = message
                Dim pstackTrace As MySqlParameter = cmd.Parameters.Add("?stackTrace", MySqlDbType.LongText)
                pstackTrace.Value = stackTrace
                Dim puser_id As MySqlParameter = cmd.Parameters.Add("?user_id", MySqlDbType.UInt32)
                puser_id.Value = getCurrentUser_UserID()

                conn.Open()
                Dim i As Integer = cmd.ExecuteNonQuery()
            End Using
        Catch myex As MySqlException
            logToTextFile(myex, myex.Number)
        Catch ex As Exception
            logToTextFile(ex)
        End Try
    End Sub

    Public Overloads Shared Sub log(ByVal message As String, ByVal user_ID As UInteger, _
                                    Optional ByVal code As Integer = 0)
        Dim SQL As New StringBuilder
        With SQL
            .Append("INSERT INTO tblLog ")
            .Append("(code, message, stackTrace, user_ID, dateCreated) ")
            .Append("VALUES(?code, ?message, ?stackTrace, ?user_ID, NOW())")
        End With
        Try
            Using conn As New MySqlConnection(getConnectionString)
                Dim cmd As New MySqlCommand(SQL.ToString, conn)
                'PARAMs
                Dim pcode As MySqlParameter = cmd.Parameters.Add("?code", MySqlDbType.UInt24)
                pcode.Value = code
                Dim pmessage As MySqlParameter = cmd.Parameters.Add("?message", MySqlDbType.MediumText)
                pmessage.Value = message
                Dim pstackTrace As MySqlParameter = cmd.Parameters.Add("?stackTrace", MySqlDbType.LongText)
                pstackTrace.Value = ""
                Dim puser_id As MySqlParameter = cmd.Parameters.Add("?user_id", MySqlDbType.UInt32)
                puser_id.Value = getCurrentUser_UserID()

                conn.Open()
                Dim i As Integer = cmd.ExecuteNonQuery()
            End Using
        Catch myex As MySqlException
            logToTextFile(myex, myex.Number)
        Catch ex As Exception
            logToTextFile(ex)
        End Try
    End Sub

    Public Shared Function getAll() As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter
        Try
            Using conn As New MySqlConnection(getConnectionString)
                Dim cmd As New MySqlCommand("SELECT * FROM tblLog", conn)
                'cmd.CommandType = CommandType.StoredProcedure

                adapter.SelectCommand = cmd
                adapter.Fill(dTable)
            End Using
        Catch myex As MySqlException
            logToTextFile(myex, myex.Number)
        Catch ex As Exception
            logToTextFile(ex)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Shared Function getByDate(ByVal dateFrom As Date, ByVal dateTo As Date) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim SQL As New StringBuilder
        With SQL
            .Append("SELECT * FROM tblLog ")
            .Append("WHERE dateCreated BETWEEN ?dateFrom AND ?dateTo")
        End With

        Try
            Using conn As New MySqlConnection(getConnectionString)
                Dim cmd As New MySqlCommand(SQL.ToString, conn)
                Dim pdateFrom As MySqlParameter = cmd.Parameters.Add("?dateFrom", MySqlDbType.Date)
                pdateFrom.Value = dateFrom
                Dim pdateTo As MySqlParameter = cmd.Parameters.Add("?dateTo", MySqlDbType.Date)
                pdateTo.Value = dateTo

                adapter.SelectCommand = cmd
                adapter.Fill(dTable)
            End Using
        Catch myex As MySqlException
            logToTextFile(myex, myex.Number)
        Catch ex As Exception
            logToTextFile(ex)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Private Shared Sub logToTextFile(ByVal except As Exception, Optional ByVal errorCode As Integer = 0)
        Try
            Dim path As String = Directory.GetCurrentDirectory & _
               "\Payroll_Log.txt"

            Dim objWriter As New StreamWriter(path, True)
            If didPrevOpen Then
                objWriter.WriteLine(" - - - ")
                objWriter.WriteLine("   " & _
                                    DateAndTime.Now.ToShortTimeString)
                objWriter.WriteLine(" > > > > " & except.Message)

            Else
                objWriter.WriteLine(" ")
                objWriter.WriteLine(" ")
                objWriter.WriteLine(DateAndTime.Now.ToString)
                objWriter.WriteLine(" > > > > " & except.Message)
                didPrevOpen = True
            End If
            objWriter.Close()
        Catch ex As Exception
            'do
        End Try
    End Sub
End Class