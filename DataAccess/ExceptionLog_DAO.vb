Imports System.Data
Imports System.Text
Imports System.Runtime.Serialization
Imports System.IO
Imports MySql.Data.MySqlClient
Imports CrossCutting

Public Class ExceptionLog_DAO

    Public Shared didPrevOpen As Boolean = False

    'A non-zero error code for 
    Public Shared Sub log(ByVal exception As Exception, Optional ByVal errorNum As Integer = 0)
        Dim SQL As New StringBuilder
        With SQL
            .Append("INSERT INTO tblExceptionLog ")
            .Append("(errorCode, errorSource, classDefiningMember, memberName,")
            .Append("memberType, message, stackTrace, user_ID, dateCreated) ")
            .Append("VALUES(?errorCode, ?errorSource, ?classDefiningMember, ?memberName,")
            .Append("?memberType, ?message, ?stackTrace, ?user_ID, NOW())")
        End With

        Try
            Using conn As New MySqlConnection(getConnectionString)
                Dim cmd As New MySqlCommand(SQL.ToString, conn)
                'PARAMs
                Dim errorCode As MySqlParameter = cmd.Parameters.Add("?errorCode", MySqlDbType.UInt24)
                errorCode.Value = errorNum
                Dim errSource As MySqlParameter = cmd.Parameters.Add("?errorSource", MySqlDbType.VarChar)
                errSource.Value = exception.Source
                Dim classDefiningMember As MySqlParameter = cmd.Parameters.Add("?classDefiningMember", MySqlDbType.VarChar)
                classDefiningMember.Value = exception.TargetSite.DeclaringType.FullName       'FullName INSTEAD OF toStriing()
                Dim memberName As MySqlParameter = cmd.Parameters.Add("?memberName", MySqlDbType.VarChar)
                memberName.Value = exception.TargetSite.Name
                Dim memberType As MySqlParameter = cmd.Parameters.Add("?memberType", MySqlDbType.VarChar)
                memberType.Value = String.Format("{0}", exception.TargetSite.MemberType)
                Dim message As MySqlParameter = cmd.Parameters.Add("?message", MySqlDbType.MediumText)
                message.Value = exception.Message.Replace("'", "#")
                Dim stackTrace As MySqlParameter = cmd.Parameters.Add("?stackTrace", MySqlDbType.LongText)
                stackTrace.Value = exception.StackTrace.Replace("'", "#")
                Dim user_ID As MySqlParameter = cmd.Parameters.Add("?user_ID", MySqlDbType.UInt32)
                user_ID.Value = getCurrentUser_UserID()

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
                Dim cmd As New MySqlCommand("SELECT * FROM tblExceptionLog", conn)

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
            .Append("SELECT * FROM tblExceptionLog ")
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
        Dim objWriter As StreamWriter = Nothing
        Try
            Dim path As String = Directory.GetCurrentDirectory & _
               "\Payroll_ExceptionLog.txt"

            objWriter = New StreamWriter(path, True)
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
        Catch ex As Exception
            'do
        Finally
            If objWriter IsNot Nothing Then objWriter.Close()
        End Try
    End Sub
End Class