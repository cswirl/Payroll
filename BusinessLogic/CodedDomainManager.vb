Imports System.Data
Imports CrossCutting
Imports Bridge
Imports DataAccess
Imports BusinessLogic.BusinessEntity

Public Class CodedDomainManager
    Inherits ManagerBase

    Private cd_DAO As CodedDomain_DAO
    Private cd_courier As CodedDomain

    Public retrieveAll_dataAdapter As MySql.Data.MySqlClient.MySqlDataAdapter
    Private cmdBuilder As MySql.Data.MySqlClient.MySqlCommandBuilder

    Sub New()
        cd_DAO = New CodedDomain_DAO
    End Sub


    'Returns the primary key of newly added coded-domain
    Public Function add(ByVal name As String, ByVal tableName As Tables) As UInt16
        cd_courier = New CodedDomain
        cd_courier.name = name
        Dim returnKey As UInt16 = 0
        Try
            insert_inspectData()
            returnKey = cd_DAO.add(name, getTablePhysicalName(tableName))
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw ex
        Finally
            'Release the object after use
            cd_courier = Nothing
        End Try
        Return returnKey
    End Function

    Public Overloads Sub retrieveAll(ByVal tableName As Tables, ByRef ds As DataSet) ' As DataTable
        'Dim dTable As DataTable
        Try
            'dTable = 
            cd_DAO.retrieveAll(getTablePhysicalName(tableName), retrieveAll_dataAdapter, ds, cmdBuilder)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        'Return dTable
    End Sub

    Public Overloads Function retrieveAll(ByVal tableName As Tables) As DataTable
        Dim dTable As DataTable
        Try
            dTable = cd_DAO.retrieveAll(getTablePhysicalName(tableName))
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Public Function retrieveEnabled(ByVal tableName As Tables) As DataTable
        Dim dTable As DataTable
        Try
            dTable = cd_DAO.retrieveEnabled(getTablePhysicalName(tableName))
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    Public Function retrieveByName(ByVal name As String, ByVal tableName As Tables) As DataTable
        Dim dTable As New DataTable


        Return dTable
    End Function

    Public Function update(ByVal codedDomainList As  _
                           System.Collections.Generic.List(Of CodedDomain), _
                           ByVal tableName As Tables) As Integer
        Dim i As Integer = 0
        Try
            cd_courier = New CodedDomain
            For Each cd As CodedDomain In codedDomainList
                cd_courier.name = cd.name
                update_inspectData()
                i = cd_DAO.update(cd, getTablePhysicalName(tableName))
                ''Propose: if an error occur, can call a rollback transaction thru cd_DAO
                'If i < 1 Then Throw _
                'New DataAccessException(String.Format _
                '("An error occur while upating `{0}`", cd.name))

            Next
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        Finally
            'Release the object after use
            cd_courier = Nothing
        End Try
        Return i
    End Function

    'Not used
    Public Function enable(ByVal primaryKey As UShort, ByVal enableThis As Boolean, _
                           ByVal tableName As Tables) As Integer
        Return 0
    End Function

    Public Function delete(ByVal primaryKey As UShort, _
                           ByVal tableName As Tables) As Integer
        Dim i As Integer = 0
        Try
            i = cd_DAO.delete(primaryKey, getTablePhysicalName(tableName))
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
        Return i
    End Function

    Public Enum Tables
        UserType
        Project
        Position
        Division
        BonusType
        DeductionType
        AllowanceType
    End Enum

    Private Function getTablePhysicalName(ByVal tableName As Tables) As String
        Select Case tableName
            Case Tables.UserType
                Return "tblUserType"
            Case Tables.Project
                Return "tblProject"
            Case Tables.Division
                Return "tblDivision"
            Case Tables.Position
                Return "tblPosition"
            Case Tables.BonusType
                Return "tblBonusType"
            Case Tables.DeductionType
                Return "tblDeductionType"
            Case Tables.AllowanceType
                Return "tblAllowanceType"
            Case Else
                Throw New BusinessException("Invalid Selection")
        End Select
    End Function

    Public Shared Function TableNameToString(ByVal table As CodedDomainManager.Tables) As String
        Select Case table
            Case CodedDomainManager.Tables.UserType
                Return "User Type"
            Case CodedDomainManager.Tables.Project
                Return "Project"
            Case CodedDomainManager.Tables.Division
                Return "Division"
            Case CodedDomainManager.Tables.Position
                Return "Position"
            Case CodedDomainManager.Tables.BonusType
                Return "Bonus Type"
            Case CodedDomainManager.Tables.DeductionType
                Return "Deduction Type"
            Case CodedDomainManager.Tables.AllowanceType
                Return "Allowance Type"
            Case Else
                Throw New BusinessException("Invalid Selection")
        End Select
    End Function

    Public Shared Function getPrimaryKeyIdentifier(ByVal table As CodedDomainManager.Tables) As String
        Select Case table
            Case CodedDomainManager.Tables.UserType
                Return "userTypeCode"
            Case CodedDomainManager.Tables.Project
                Return "proj_ID"
            Case CodedDomainManager.Tables.Division
                Return "div_ID"
            Case CodedDomainManager.Tables.Position
                Return "position_ID"
            Case CodedDomainManager.Tables.BonusType
                Return "bonusTypeCode"
            Case CodedDomainManager.Tables.DeductionType
                Return "deductTypeCode"
            Case CodedDomainManager.Tables.AllowanceType
                Return "allowTypeCode"
            Case Else
                Throw New BusinessException("Invalid Selection")
        End Select
    End Function

    Private Sub validateName(ByVal name As String)
        Try
            stringChecker(name, 30)
        Catch sqliex As SQLInjectionException
            'Log the suspected 'value' and throw an BusinessException
            Logger.possibleSQLInjection(name, sqliex.StackTrace)
            sqliex.overrideMessage("`name`" & sqliex.Message)
            Throw sqliex
        Catch bex As BusinessException
            bex.overrideMessage("`name`" & bex.Message)
            Throw bex
        End Try
    End Sub

#Region "Manager Base"
    Protected Overrides Sub insert_checkRequiredData()
        Try
            REQUIRED(cd_courier.name)
        Catch bex As BusinessException
            bex.overrideMessage("A 'name' is required.")
            Throw bex
        End Try
    End Sub

    Protected Overrides Sub insert_validateData()
        With cd_courier
            Try
                validateName(cd_courier.name)
            Catch bex As BusinessException
                Throw bex
            End Try
        End With
    End Sub

    Protected Overrides Sub update_checkRequiredData()
        'Check for required data
        Try
            REQUIRED(cd_courier.name)
        Catch bex As BusinessException
            bex.overrideMessage("A 'name' is required.")
            Throw bex
        End Try

    End Sub

    Protected Overrides Sub update_validateData()
        Try
            validateName(cd_courier.name)
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub
#End Region
End Class