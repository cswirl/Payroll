Imports System.Data
Imports Bridge
Imports MySql.Data.MySqlClient
Imports CrossCutting
Imports System.Text


Public Class CodedDomain_DAO
    Inherits DataAccessBase

    Sub New()
        If conn Is Nothing Then conn = New MySqlConnection(getConnectionString)
    End Sub

    'Returns the primary key of newly added coded-domain
    Public Function add(ByVal name As String, ByVal tableName As String) As UInt16
        Dim ret_ID As UInt16

        Dim SQL As New StringBuilder
        With SQL
            .Append(String.Format("INSERT INTO {0} ", tableName))
            .Append("(name, dateCreated, lastModifiedBy) ")
            .Append("VALUES (?name, Now(), ?lastModifiedBy)")
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            'PARAMs
            Dim _name As MySqlParameter = cmd.Parameters.Add("?name", MySqlDbType.VarChar)
            _name.Value = name

            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("?lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            Dim i As Integer = cmd.ExecuteNonQuery()
            cmd.CommandText = "SELECT LAST_INSERT_ID()"
            ret_ID = cmd.ExecuteScalar
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
                        MySQLErrorNumToString(myex.Number, "Adding '" & name & "' failed!"), _
                        DataAccessExceptionCode.CodedDomain_add)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Adding '" & name & "' failed!", _
                        DataAccessExceptionCode.CodedDomain_add)
        Finally
            closeConnection()

        End Try

        Return ret_ID
    End Function

    'For Tables Organizer
    Public Overloads Sub retrieveAll(ByVal tableName As String, ByRef adapter As MySqlDataAdapter, ByRef ds As DataSet, _
                           ByRef cmdBuilder As MySqlCommandBuilder)   'As DataTable
        'Dim dTable As New DataTable(tableName)
        'Dim adapter As New MySqlDataAdapter
        Dim _select As String = _
        String.Format("SELECT c.{0}, c.name, c.enable, c.dateCreated, " & _
                      "c.lastModified, u.username as lastModifiedBy  FROM {1} c ", _
                      getPrimaryKeyIdentifier(tableName), tableName)
        Dim SQL As New StringBuilder
        With SQL
            .Append(_select)
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = c.lastModifiedBy ")
        End With

        Try
            Dim conn As New MySqlConnection(getConnectionString)

            adapter = New MySqlDataAdapter()
            adapter.SelectCommand = New MySqlCommand(SQL.ToString, conn)
            cmdBuilder = New MySqlCommandBuilder(adapter)
            'Dim cmdBuilder As New MySqlCommandBuilder(adapter)
            If ds Is Nothing Then ds = New DataSet
            adapter.Fill(ds, tableName)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException(retrieveFailureMsg(tableName), _
                        DataAccessExceptionCode.CodedDomain_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException(retrieveFailureMsg(tableName), _
                        DataAccessExceptionCode.CodedDomain_getAll)
        Finally
            'If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        'Return dTable
    End Sub

    Public Overloads Function retrieveAll(ByVal tableName As String) As DataTable
        Dim dTable As New DataTable(tableName)
        Dim adapter As New MySqlDataAdapter
        Dim _select As String = _
        String.Format("SELECT c.{0}, c.name, c.enable, c.dateCreated, " & _
                      "c.lastModified, u.username as lastModifiedBy  FROM {1} c ", _
                      getPrimaryKeyIdentifier(tableName), tableName)
        Dim SQL As New StringBuilder
        With SQL
            .Append(_select)
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = c.lastModifiedBy ")
        End With

        Try
            Dim conn As New MySqlConnection(getConnectionString)

            adapter = New MySqlDataAdapter()
            adapter.SelectCommand = New MySqlCommand(SQL.ToString, conn)
           
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException(retrieveFailureMsg(tableName), _
                        DataAccessExceptionCode.CodedDomain_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException(retrieveFailureMsg(tableName), _
                        DataAccessExceptionCode.CodedDomain_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveEnabled(ByVal tableName As String) As DataTable
        Dim dTable As New DataTable(tableName)
        Dim adapter As New MySqlDataAdapter
        Dim _select As String = _
        String.Format("SELECT c.{0}, c.name, c.enable, c.dateCreated, " & _
                      "c.lastModified, u.username as lastModifiedBy  FROM {1} c ", _
                      getPrimaryKeyIdentifier(tableName), tableName)
        Dim SQL As New StringBuilder
        With SQL
            .Append(_select)
            .Append("LEFT JOIN tblUser u ")
            .Append("ON u.user_ID = c.lastModifiedBy ")
            .Append("WHERE c.enable = 1")
        End With

        Try
            Dim conn As New MySqlConnection(getConnectionString)

            adapter = New MySqlDataAdapter()
            adapter.SelectCommand = New MySqlCommand(SQL.ToString, conn)
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException(retrieveFailureMsg(tableName), _
                        DataAccessExceptionCode.CodedDomain_getAll)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException(retrieveFailureMsg(tableName), _
                        DataAccessExceptionCode.CodedDomain_getAll)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function retrieveByName(ByVal name As String, ByVal tableName As String) As DataTable
        Dim dTable As New DataTable
        Dim adapter As New MySqlDataAdapter

        Dim SQL As New StringBuilder
        With SQL
            .Append(String.Format("SELECT * FROM {0} ", tableName))
            .Append("WHERE name LIKE CONCAT(?name, '%')")
        End With

        Try
            Dim cmd As New MySqlCommand(SQL.ToString, conn)

            Dim param As MySqlParameter = cmd.Parameters.Add("?name", MySqlDbType.VarChar)
            param.Value = name
            adapter.SelectCommand = cmd
            adapter.Fill(dTable)
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException("Retrieving '" & name & "' failed.", _
                        DataAccessExceptionCode.CodedDomain_getByName)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Retrieving '" & name & "' failed.", _
                        DataAccessExceptionCode.CodedDomain_getByName)
        Finally
            If Not adapter Is Nothing Then adapter.Dispose()
        End Try

        Return dTable
    End Function

    Public Function update(ByVal codedDomain As ICodedDomain, _
                           ByVal tableName As String) As Integer
        Dim i As Integer = 0

        Try
            Dim SQL As New StringBuilder
            With SQL
                .Append(String.Format("UPDATE {0} SET ", tableName))
                .Append("name = ?name, enable = ?enable, ")
                .Append("lastModifiedBy = ?lastModifiedBy ")
                .Append("WHERE ")
                .Append(getPrimaryKeyIdentifier(tableName))
                .Append(" = ?ID")
            End With
            Using conn As New MySqlConnection(getConnectionString)
                Dim cmd As New MySqlCommand(SQL.ToString, conn)
                'PARAMs
                Dim _primaryKey As MySqlParameter = cmd.Parameters.Add("?ID", MySqlDbType.UInt16)
                _primaryKey.Value = codedDomain.primaryKey
                Dim _name As MySqlParameter = cmd.Parameters.Add("?name", MySqlDbType.VarChar)
                _name.Value = codedDomain.name
                Dim _enable As MySqlParameter = cmd.Parameters.AddWithValue("?enable", codedDomain.enable)
                Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("?lastModifiedBy", MySqlDbType.UInt32)
                lastModifiedBy.Value = getCurrentUser_UserID()

                conn.Open()
                i = cmd.ExecuteNonQuery()
            End Using
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "Updating '" & codedDomain.name & "' failed!"), _
            DataAccessExceptionCode.CodedDomain_update)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Updating '" & codedDomain.name & "' failed!", _
                                          DataAccessExceptionCode.CodedDomain_update)
        Finally
            'closeConnection()

        End Try

        Return i
    End Function

    'Not used
    Public Function enable(ByVal codedDomain As ICodedDomain, _
                           ByVal tableName As String) As Integer
        Dim i As Integer = 0

        Try
            Dim SQL As New StringBuilder
            With SQL
                .Append(String.Format("UPDATE {0} SET ", tableName))
                .Append("enable = ?enable,")
                .Append("lastModifiedBy = ?lastModifiedBy ")
                .Append("WHERE ")
                .Append(getPrimaryKeyIdentifier(tableName))
                .Append(" = ?ID")
            End With

            Dim cmd As New MySqlCommand(SQL.ToString, conn)
            'PARAMs
            Dim _primaryKey As MySqlParameter = cmd.Parameters.Add("?ID", MySqlDbType.UInt16)
            _primaryKey.Value = codedDomain.primaryKey
            Dim _enable As MySqlParameter = cmd.Parameters.AddWithValue("?enable", codedDomain.enable)
            Dim lastModifiedBy As MySqlParameter = cmd.Parameters.Add("?lastModifiedBy", MySqlDbType.UInt32)
            lastModifiedBy.Value = getCurrentUser_UserID()

            openConnection()
            i = cmd.ExecuteNonQuery()

        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "Modifying '" & codedDomain.name & "' failed!"), _
            DataAccessExceptionCode.CodedDomain_enable)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("Modifying '" & codedDomain.name & "' failed!", _
                                          DataAccessExceptionCode.CodedDomain_enable)
        Finally
            closeConnection()

        End Try

        Return i
    End Function

    'This is tentative. If the referential integrity works fine then this will be implemented permanently
    Public Function delete(ByVal primaryKey As UShort, ByVal tableName As String)
        Dim i As Integer = 0
        Dim SQL As String = String.Format("DELETE FROM {0} WHERE {1} = ?pKey", tableName, _
                                          getPrimaryKeyIdentifier(tableName))
        Try
            Using conn As New MySqlConnection(getConnectionString)
                Dim cmd As New MySqlCommand(SQL, conn)
                'PARAMs
                Dim pKey As MySqlParameter = cmd.Parameters.Add("?pKey", MySqlDbType.UInt16)
                pKey.Value = primaryKey

                conn.Open()
                i = cmd.ExecuteNonQuery()
            End Using
        Catch myex As MySqlException
            ExceptionLog_DAO.log(myex, myex.Number)
            Throw New DataAccessException( _
            MySQLErrorNumToString(myex.Number, "An error occur while deleting a record."), _
            DataAccessExceptionCode.CodedDomain_delete)
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw New DataAccessException("An error occur while deleting a record.", _
                                          DataAccessExceptionCode.CodedDomain_delete)
        End Try

        Return i
    End Function

    Public Shared Function TableNameToString(ByVal tableName As String) As String
        If tableName.Equals("tblUserType") Then
            Return "User Type"
        ElseIf tableName.Equals("tblProject") Then
            Return "Project"
        ElseIf tableName.Equals("tblDivision") Then
            Return "Division"
        ElseIf tableName.Equals("tblPosition") Then
            Return "Position"
        ElseIf tableName.Equals("tblBonusType") Then
            Return "Bonus Type"
        ElseIf tableName.Equals("tblDeductionType") Then
            Return "Deduction Type"
        ElseIf tableName.Equals("tblAllowanceType") Then
            Return "Allowance Type"
        Else
            Return "Unknown Table"
        End If
    End Function

    Public Shared Function getPrimaryKeyIdentifier(ByVal tableName As String) As String
        If tableName.Equals("tblUserType") Then
            Return "userTypeCode"
        ElseIf tableName.Equals("tblProject") Then
            Return "proj_ID"
        ElseIf tableName.Equals("tblDivision") Then
            Return "div_ID"
        ElseIf tableName.Equals("tblPosition") Then
            Return "position_ID"
        ElseIf tableName.Equals("tblBonusType") Then
            Return "bonusTypeCode"
        ElseIf tableName.Equals("tblDeductionType") Then
            Return "deductTypeCode"
        ElseIf tableName.Equals("tblAllowanceType") Then
            Return "allowTypeCode"
        Else
            Throw New Exception("Invalid Table name")
        End If
    End Function

    

    Private Function retrieveFailureMsg(ByVal tableName As String) As String
        Return "Retrieving '" & TableNameToString(tableName) _
                                          & "' failed!"
    End Function

End Class