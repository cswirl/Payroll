Imports System.Runtime.Serialization
Imports Bridge

Public Module CrossCutting_Mod

    Public CurrentUser As IUser
    Private Config As New Configuration

    Sub Main()

    End Sub

    'DATABASE CONFIGURATION
    Public Sub setConfiguration(ByVal configuration As Configuration)
        Config = configuration
    End Sub

    Public Function getDB_name() As String
        Return Config.database
    End Function

    Public Function getDB_user() As String
        Return Config.username
    End Function

    Public Function getDB_password() As String
        Return Config.password
    End Function

    Public Function getConnectionString() As String
        Return String.Format("server={0}; user id={1}; password={2}; database={3}", _
                                       Config.server, Config.username, Config.password, Config.database.ToLower)
    End Function

    Public Function getConnectionString_Deductables() As String
        Return String.Format("server={0}; user id={1}; password={2}; database={3}", _
                                       Config.server, Config.username, Config.password, "Payroll_Deductions".ToLower)
    End Function

    Public Function getCompanyName() As String
        Return Config.companyName
    End Function

    Public Function getCurrentUser() As IUser
        Return CurrentUser
    End Function

    'CURRENT USER
    Public Sub setCurrentUser(ByVal user As IUser)
        CurrentUser = user
    End Sub

    Public Function getCurrentUser_UserID() As UInteger
        If CurrentUser Is Nothing Then
            Return 0
        End If

        Return CurrentUser.user_ID
    End Function

    Public Function getCurrentUser_Username() As String
        If CurrentUser Is Nothing Then
            Return "Unknown User"
        End If

        Return CurrentUser.userName
    End Function

    Public Sub logoutCurrentUser()
        'Release the referenced object
        CurrentUser = Nothing
    End Sub

    Public Enum BusinessRulesViolationCode
        GeneralException = 5000
        ThirdLoginAttempt = 5001
        PossibleSQLInjection = 5002 'MyApplicationException?
        UnauthorizedPayrollReversal = 5003

    End Enum

    'The generated code will came from ground zero of exception. At the Data Access
    'Offset is 1000
    Public Enum DataAccessExceptionCode
        GeneralError = 0
        'User 1000
        User_add = 1001
        User_retrieveAll = 1002
        User_retrieveByID = 1003
        User_retrieveByName = 1004
        User_update = 1005
        User_activate = 1006
        User_changePassword = 1007
        User_delete

        'Employee 1100
        Employee_add = 1101
        Employee_updatePersonalInfo
        Employee_updateSalaryInfo
        Employee_updatePersonalLoan
        Employee_getAll
        Employee_getUnlockedEmployee
        Employee_getByEmpNum
        Employee_delete

        'Payroll 1200
        Payroll_add
        Payroll_reverse
        Payroll_getByPayrollNum
        Payroll_trackSSSContribution
        Payroll_trackPhilHealthContribution

        'Project 1300
        Project_add
        Project_getAll
        Project_update
        Project_delete
        Project_getWorkdaysAndOTs
        Project_getEmpNum
        Project_getByEmpNum
        Project_getByPayrollNum
        Project_getAllowanceTotalForEmployee
        Project_getAllowanceTotalForReversal
        Project_getOtherDeductTotalForEmployee
        Project_getOtherDeductTotalForReversal
        Project_flag_head

        'Allowance 1400
        Allowance_add = 1401
        Allowance_delete
        Allowance_getAll
        Allowance_getAllForPayroll
        Allowance_getProcessedByPayrollNum


        'Bonus 1500
        Bonus_add = 1501
        Bonus_delete
        Bonus_settle
        Bonus_getAll

        'Deduction 1600 
        Deduction_add = 1601
        Deduction_delete
        Deduction_settle
        Deduction_getAll
        Deduction_getAllForPayroll
        Deduction_getSettledByPayrollNum

        'Paid Project 1700
        PaidProject_add = 1701

        'Coded Domain 1800
        CodedDomain_add = 1801
        CodedDomain_getAll
        CodedDomain_getByName
        CodedDomain_update
        CodedDomain_enable
        CodedDomain_delete

        'Report Generator 2000
        RepGen_daily = 2001
        repGen_monthly

        'WTax 2100
        WTax_getBaseBracket_over
        WTax_getBaseBracket
        WTax_getTaxBracket
        WTax_find_TaxVariables

        'SSS 2200
        SSS_getAll
        SSS_find_Contribution

        'PhilHealth
        PhilHealth_getAll
        PhilHealth_find_Contribution
        PhilHealth_getRangeFrom_minimum
    End Enum

    'FOR FORMS
    Public Enum FormState
        Idle
        Adding
        Modifying
    End Enum

    Public Enum DB_Operation
        Create
        Update
        Delete
    End Enum




    '''EXCEPTIONS
#Region "Exceptions"
    ''Business Exception
    Public Class BusinessException
        Inherits Exception
        Implements ISerializable

        Protected _code As Integer

        Protected isMsgOverridden As Boolean = False
        Protected _message As String

        Public Property code() As Integer
            Get
                Return _code
            End Get
            Set(ByVal value As Integer)
                _code = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
            ' Add implementation.
        End Sub

        Public Sub New(ByVal code As Integer)
            _code = code
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
            ' Add implementation.
        End Sub

        Public Sub New(ByVal message As String, ByVal code As Integer)
            MyBase.New(message)
            ' Add implementation.
            _code = code
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
            ' Add implementation.
        End Sub

        ' This constructor is needed for serialization.
        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
            ' Add implementation.
        End Sub

        Public Overrides ReadOnly Property Message() As String
            Get
                'If String.IsNullOrEmpty(MyBase.Message) Then
                '    Return MyMessageBox.BusinessRulesMessage( _
                '    CType(code, BusinessRulesViolationCode))
                'End If
                If isMsgOverridden Then
                    Return _message
                End If
                Return MyBase.Message
            End Get
        End Property

        Public Sub overrideMessage(ByVal message As String)
            _message = message
            isMsgOverridden = True
        End Sub

        Public Function getOriginalMessage() As String
            Return MyBase.Message
        End Function


    End Class


    'SQL Injection Exception
    Public Class SQLInjectionException
        Inherits BusinessException

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal code As Integer)
            MyBase.New(message)
            ' Add implementation.
            _code = code
        End Sub
    End Class


    ''Database Exception
    Public Class DataAccessException
        Inherits Exception
        Implements ISerializable

        Protected _code As DataAccessExceptionCode
        Protected isMsgOverridden As Boolean = False
        Protected _message As String

        Public Property code() As DataAccessExceptionCode
            Get
                Return _code
            End Get
            Set(ByVal value As DataAccessExceptionCode)
                _code = value
            End Set
        End Property

        Public Sub New(ByVal code As DataAccessExceptionCode)
            MyBase.New(MyMessageBox.OperationErrorMessage(code))
            _code = code
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal code As Integer)
            MyBase.New(message)
            ' Add implementation.
            _code = code
        End Sub

        Public Overrides ReadOnly Property Message() As String
            Get
                If isMsgOverridden Then
                    Return _message
                End If
                Return MyBase.Message
            End Get
        End Property

        Public Sub overrideMessage(ByVal message As String)
            _message = message
            isMsgOverridden = True
        End Sub

        Public Function getOriginalMessage() As String
            Return MyBase.Message
        End Function

    End Class


    ''Application Exception
    Public Class MyApplicationException
        Inherits Exception
        Implements ISerializable

        Protected _code As Integer
        Protected isMsgOverridden As Boolean = False
        Protected _message As String

        Public Property code() As Integer
            Get
                Return _code
            End Get
            Set(ByVal value As Integer)
                _code = value
            End Set
        End Property

        Sub New()
            MyBase.new()
        End Sub

        Public Sub New(ByVal code As Integer)
            MyBase.New(MyMessageBox.OperationErrorMessage(code))
            _code = code
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal code As Integer)
            MyBase.New(message)
            ' Add implementation.
            _code = code
        End Sub

        Public Overrides ReadOnly Property Message() As String
            Get
                If isMsgOverridden Then
                    Return _message
                End If
                Return MyBase.Message
            End Get
        End Property

        Public Sub overrideMessage(ByVal message As String)
            _message = message
            isMsgOverridden = True
        End Sub

        Public Function getOriginalMessage() As String
            Return MyBase.Message
        End Function

    End Class
#End Region
End Module