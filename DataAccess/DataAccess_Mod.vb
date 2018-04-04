Imports CrossCutting
Imports MySql.Data.MySqlClient
Imports Bridge
Imports System.Data

Public Module DataAccess_Mod

    Private server As String = "localhost;"
    Private userName As String = "root;"
    Private password As String = "base10logis1;"
    Private database As String = "payroll"

    Friend Const COMMA As String = ", "
    Friend Const S_QUOTE As String = "'"        'Single Quote
    Friend Const CLOSING_P As String = ")"      'Closing Parenthesis

    Sub Main()

    End Sub

    Public Function FormatDateToMqSQL(ByVal _date As Date) As String
        Dim year, mo, day As String
        year = _date.Year
        mo = _date.Month.ToString("00")
        day = _date.Day.ToString("00")
        Dim strDate As String = year & "-" & mo & "-" & day
        strDate = "'" & strDate & "'"
        Return strDate
    End Function

    'TODO: isUnique - in the table
    Public Function isUnique(ByVal value As String, ByVal fieldName As String, ByVal tableName As String) As Boolean

        Return True
    End Function


    Public Function MySQLErrorNumToString(ByVal errorNumber As Integer, ByVal defMsg As String) As String
        'NOTE: a range can be use. i.e. Case 1 To 5
        Select Case errorNumber
            Case 1042
                Return "Cannot connect to the database."
            Case 1062
                Return "Cannot enter Duplicate data"
            Case 1451
                Return "Deletion Failed. This record is referenced on other table/s."
            Case Else
                Return defMsg
        End Select
    End Function

    Public Sub TestConnection()
        Try
            Using conn As New MySqlConnection(getConnectionString)
                conn.Open()
                conn.Close()
            End Using
        Catch myex As MySqlException
            Throw New DataAccessException("Cannot connect to the Database.")
        Catch ex As Exception
            Throw New DataAccessException("Cannot connect to the Database.")
        End Try
    End Sub

    Public Function customSelect(ByVal SQL As String) As DataTable
        Dim dTable As New DataTable

        Dim adapter As New MySqlDataAdapter
        Try
            Using conn As New MySqlConnection
                Dim cmd As New MySqlCommand(SQL, conn)
                adapter.SelectCommand = cmd
                adapter.Fill(dTable)
            End Using
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Dim daex As New DataAccessException("Retrieving data failed!", DataAccessExceptionCode.GeneralError)
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Dim daex As New DataAccessException("Retrieving data failed!", DataAccessExceptionCode.GeneralError)
            Throw daex
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function


End Module