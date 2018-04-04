Imports MySql.Data.MySqlClient
Imports System.Data
Imports CrossCutting

Public Class DataAccessBase
    Protected exLog As ExceptionLog_DAO
    Protected conn As MySqlConnection

    Sub New()
        conn = New MySqlConnection(getConnectionString())
        exLog = New ExceptionLog_DAO
    End Sub


    'OPEN CONNECTION TO THE DATABASE
    Protected Sub openConnection()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    'CLOSE CONNECTION TO THE DATABASE
    Protected Sub closeConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub
End Class