Imports Bridge
Imports CrossCutting
Imports DataAccess

Namespace BusinessEntity

    '''CLASS: CODED-DOMAINS
#Region "Coded Domains"
    Public Class CodedDomain
        Implements ICodedDomain

        Private scd As New structCodedDomain

        Public Property dateCreated() As Date Implements Bridge.ICodedDomain.dateCreated
            Get
                Return scd.dateCreated
            End Get
            Set(ByVal value As Date)
                scd.dateCreated = value
            End Set
        End Property

        Public Property enable() As Boolean Implements Bridge.ICodedDomain.enable
            Get
                Return scd.enable
            End Get
            Set(ByVal value As Boolean)
                scd.enable = value
            End Set
        End Property

        Public Property lastModified() As Date Implements Bridge.ICodedDomain.lastModified
            Get
                Return scd.lastModified
            End Get
            Set(ByVal value As Date)
                scd.lastModified = value
            End Set
        End Property

        Public Property lastModifiedBy() As UInteger Implements Bridge.ICodedDomain.lastModifiedBy
            Get
                Return scd.lastModifiedBy
            End Get
            Set(ByVal value As UInteger)
                scd.lastModifiedBy = value
            End Set
        End Property

        Public Property name() As String Implements Bridge.ICodedDomain.name
            Get
                Return scd.name
            End Get
            Set(ByVal value As String)
                Try
                    scd.name = stringChecker(value, 30)
                Catch sqliex As SQLInjectionException
                    'Log the suspected 'value' and throw as an BusinessException
                    Logger.possibleSQLInjection(value, sqliex.StackTrace)
                    sqliex.overrideMessage("A `name` for a Coded-Domain" & sqliex.Message)
                    Throw sqliex
                Catch bex As BusinessException
                    bex.overrideMessage("A `name` for a Coded-Domain" & bex.Message)
                    Throw bex
                End Try
            End Set
        End Property

        Public Property primaryKey() As UInt16 Implements Bridge.ICodedDomain.primaryKey
            Get
                Return scd.primaryKey
            End Get
            Set(ByVal value As UInt16)
                scd.primaryKey = value
            End Set
        End Property
    End Class

    Structure structCodedDomain
        Dim primaryKey As UInt16
        Dim name As String
        Dim enable As Boolean
        Dim dateCreated As Date
        Dim lastModified As Date
        Dim lastModifiedBy As UInteger
    End Structure
#End Region

    '''CLASS: USER
#Region "User"
    Public Class User
        Implements IUser

        Private su As New structUser

        Public Const USERNAME_MAX_LEN As Integer = 30
        Public Const PASSWORD_MAX_LEN As Integer = 50


        Public Property active() As Boolean Implements Bridge.IUser.active
            Get
                Return su.active
            End Get
            Set(ByVal value As Boolean)
                su.active = value
            End Set
        End Property

        Public Property dateCreated() As Date Implements Bridge.IUser.dateCreated
            Get
                Return su.dateCreated
            End Get
            Set(ByVal value As Date)
                su.dateCreated = value
            End Set
        End Property

        Public Property empNum() As UInteger Implements Bridge.IUser.empNum
            Get
                Return su.empNum
            End Get
            Set(ByVal value As UInteger)
                su.empNum = value
            End Set
        End Property

        Public Property lastModified() As Date Implements Bridge.IUser.lastModified
            Get
                Return su.lastModified
            End Get
            Set(ByVal value As Date)
                su.lastModified = value
            End Set
        End Property

        Public Property lastModifiedBy() As UInteger Implements Bridge.IUser.lastModifiedBy
            Get
                Return su.lastModifiedBy
            End Get
            Set(ByVal value As UInteger)
                su.lastModifiedBy = value
            End Set
        End Property

        Public Property user_ID() As UInteger Implements Bridge.IUser.user_ID
            Get
                Return su.user_ID
            End Get
            Set(ByVal value As UInteger)
                su.user_ID = value
            End Set
        End Property

        Public Property userName() As String Implements Bridge.IUser.userName
            Get
                Return su.userName
            End Get
            Set(ByVal value As String)
                su.userName = value
            End Set
        End Property

        Public Property userPassword() As String Implements Bridge.IUser.userPassword
            Get
                Return su.userPassword
            End Get
            Set(ByVal value As String)
                su.userPassword = value

            End Set
        End Property

        Public Property userTypeCode() As UInt16 Implements Bridge.IUser.userTypeCode
            Get
                Return su.userTypeCode
            End Get
            Set(ByVal value As UInt16)
                su.userTypeCode = value
            End Set

        End Property
    End Class

    Structure structUser
        Dim user_ID As UInteger
        Dim empNum As UInteger
        Dim userName As String
        Dim userPassword As String
        Dim userTypeCode As UInt16
        Dim active As Boolean
        Dim dateCreated As Date
        Dim lastModified As Date
        Dim lastModifiedBy As UInteger
    End Structure
#End Region

    '''CLASS: UserList
    Public Class UserList
        Inherits System.Collections.Generic.List(Of BusinessEntity.User)
    End Class


    '''CLASS: EMPLOYEE
#Region "Employee"
    Public Class Employee
        Implements IEmployee

        'WARNING: The system will accept even if employee number has greater than 4 digits
        Const EMP_NUM_FORMAT_LENGTH As Integer = 4

        Private se As New structEmployee

        Public Property empNum() As UInteger Implements IEmployee.empNum
            Get
                Return se.empNum
            End Get
            Set(ByVal value As UInteger)
                se.empNum = value
            End Set
        End Property

        Public Property address() As String Implements Bridge.IEmployee.address
            Get
                Return se.address
            End Get
            Set(ByVal value As String)
                se.address = value
            End Set
        End Property

        Public Property basicRate() As Double Implements Bridge.IEmployee.basicRate
            Get
                Return se.basicRate
            End Get
            Set(ByVal value As Double)
                se.basicRate = value
            End Set
        End Property

        Public Property birthDate() As Date Implements Bridge.IEmployee.birthDate
            Get
                Return se.birthDate
            End Get
            Set(ByVal value As Date)
                se.birthDate = value
            End Set
        End Property

        Public Property city() As String Implements Bridge.IEmployee.city
            Get
                Return se.city
            End Get
            Set(ByVal value As String)
                se.city = value
            End Set
        End Property

        Public Property civilStat() As String Implements Bridge.IEmployee.civilStat
            Get
                Return se.civilStat
            End Get
            Set(ByVal value As String)
                se.civilStat = value
            End Set
        End Property

        Public Property contactNum() As String Implements Bridge.IEmployee.contactNum
            Get
                Return se.contactNum
            End Get
            Set(ByVal value As String)
                se.contactNum = value
            End Set
        End Property

        Public Property dateCreated() As Date Implements Bridge.IEmployee.dateCreated
            Get
                Return se.dateCreated
            End Get
            Set(ByVal value As Date)
                se.dateCreated = value
            End Set
        End Property

        Public Property dateHired() As Date Implements Bridge.IEmployee.dateHired
            Get
                Return se.dateHired
            End Get
            Set(ByVal value As Date)
                se.dateHired = value
            End Set
        End Property

        Public Property email() As String Implements Bridge.IEmployee.email
            Get
                Return se.email
            End Get
            Set(ByVal value As String)
                se.email = value
            End Set
        End Property

        Public Property firstName() As String Implements Bridge.IEmployee.firstName
            Get
                Return se.firstName
            End Get
            Set(ByVal value As String)
                se.firstName = value
            End Set
        End Property

        Public Property gender() As String Implements Bridge.IEmployee.gender
            Get
                Return se.gender
            End Get
            Set(ByVal value As String)
                se.gender = value
            End Set
        End Property

        Public Property lastModified() As Date Implements Bridge.IEmployee.lastModified
            Get
                Return se.lastModified
            End Get
            Set(ByVal value As Date)
                se.lastModified = value
            End Set
        End Property

        Public Property lastModifiedBy() As UInteger Implements Bridge.IEmployee.lastModifiedBy
            Get
                Return se.lastModifiedBy
            End Get
            Set(ByVal value As UInteger)
                se.lastModifiedBy = value
            End Set
        End Property

        Public Property lastName() As String Implements Bridge.IEmployee.lastName
            Get
                Return se.lastName
            End Get
            Set(ByVal value As String)
                se.lastName = value
            End Set
        End Property

        Public Property middleName() As String Implements Bridge.IEmployee.middleName
            Get
                Return se.middleName
            End Get
            Set(ByVal value As String)
                se.middleName = value
            End Set
        End Property

        Public Property numOfDependents() As UShort Implements Bridge.IEmployee.numOfDependents
            Get
                Return se.numOfDependents
            End Get
            Set(ByVal value As UShort)
                se.numOfDependents = value
            End Set
        End Property

        Public Property PAGIBIG_Num() As String Implements Bridge.IEmployee.PAGIBIG_Num
            Get
                Return se.PAGIBIG_num
            End Get
            Set(ByVal value As String)
                se.PAGIBIG_num = value
            End Set
        End Property

        Public Property payMethod() As String Implements Bridge.IEmployee.payMethod
            Get
                Return se.payMethod
            End Get
            Set(ByVal value As String)
                se.payMethod = value
            End Set
        End Property

        Public Property personalLoan() As Double Implements Bridge.IEmployee.personalLoan
            Get
                Return se.personalLoan
            End Get
            Set(ByVal value As Double)
                se.personalLoan = value
            End Set
        End Property

        Public Property SSS_Loan() As Double Implements Bridge.IEmployee.SSS_Loan
            Get
                Return se.SSS_Loan
            End Get
            Set(ByVal value As Double)
                se.SSS_Loan = value
            End Set
        End Property

        Public Property WTax_isDeduct() As Boolean Implements Bridge.IEmployee.WTax_isDeduct
            Get
                Return se.WTax_isDeduct
            End Get
            Set(ByVal value As Boolean)
                se.WTax_isDeduct = value
            End Set
        End Property

        Public Property SSS_isDeduct() As Boolean Implements Bridge.IEmployee.SSS_isDeduct
            Get
                Return se.SSS_isDeduct
            End Get
            Set(ByVal value As Boolean)
                se.SSS_isDeduct = value
            End Set
        End Property

        Public Property philHealth_isDeduct() As Boolean Implements Bridge.IEmployee.philHealth_isDeduct
            Get
                Return se.philHealth_isDeduct
            End Get
            Set(ByVal value As Boolean)
                se.philHealth_isDeduct = value
            End Set
        End Property

        Public Property PAGIBIG_isDeduct() As Boolean Implements Bridge.IEmployee.PAGIBIG_isDeduct
            Get
                Return se.PAGIBIG_isDeduct
            End Get
            Set(ByVal value As Boolean)
                se.PAGIBIG_isDeduct = value
            End Set
        End Property

        Public Property philHealth_Num() As String Implements Bridge.IEmployee.philHealth_Num
            Get
                Return se.philHealth_num
            End Get
            Set(ByVal value As String)
                se.philHealth_num = value
            End Set
        End Property

        Public Property photo() As Byte() Implements Bridge.IEmployee.photo
            Get
                Return se.photo
            End Get
            Set(ByVal value As Byte())
                se.photo = value
            End Set
        End Property

        Public Property PRC_Num() As String Implements Bridge.IEmployee.PRC_Num
            Get
                Return se.PRC_num
            End Get
            Set(ByVal value As String)
                se.PRC_num = value
            End Set
        End Property

        Public Property SSS_Num() As String Implements Bridge.IEmployee.SSS_Num
            Get
                Return se.SSS_num
            End Get
            Set(ByVal value As String)
                se.SSS_num = value
            End Set
        End Property

        Public Property status() As String Implements Bridge.IEmployee.status
            Get
                Return se.status
            End Get
            Set(ByVal value As String)
                se.status = value
            End Set
        End Property

        Public Property TIN_Num() As String Implements Bridge.IEmployee.TIN_Num
            Get
                Return se.TIN_num
            End Get
            Set(ByVal value As String)
                se.TIN_num = value
            End Set
        End Property

        Public Property holOt_rate() As Single Implements Bridge.IEmployee.holOt_rate
            Get
                Return se.holOT_rate
            End Get
            Set(ByVal value As Single)
                se.holOT_rate = value
            End Set
        End Property

        Public Property regOt_rate() As Single Implements Bridge.IEmployee.regOt_rate
            Get
                Return se.regOT_rate
            End Get
            Set(ByVal value As Single)
                se.regOT_rate = value
            End Set
        End Property

        Public Property sunOt_rate() As Single Implements Bridge.IEmployee.sunOt_rate
            Get
                Return se.sunOT_rate
            End Get
            Set(ByVal value As Single)
                se.sunOT_rate = value
            End Set
        End Property

        Public Function fullName() As String
            Return String.Format("{0} {1}", firstName, lastName)
        End Function

        Public Function getFormattedEmpNum() As String Implements Bridge.IEmployee.getFormattedEmpNum
            Dim empNum As String = addZeroPadding(Me.empNum, EMP_NUM_FORMAT_LENGTH)
            Dim hireDate As String = formatDateHired(Me.dateHired)

            Return hireDate & empNum
        End Function

        Private Function addZeroPadding(ByVal employeeNumber As UInteger, ByVal formatLength As Integer) As String
            If employeeNumber < 1 Then
                Throw New BusinessException("Employee Number cannot be zero(0) or less")
            End If

            Dim empNum As String = CStr(employeeNumber)
            Dim numOfPad As Integer = formatLength - empNum.Length

            'Exit function if employee number has the max length
            If numOfPad = 0 Then
                Return empNum
            ElseIf numOfPad < 0 Then
                Return empNum
                'Throw New BusinessException("Employee Number out-of-range")
            End If

            'Do the padding
            For i = 1 To numOfPad
                empNum = "0" & empNum
            Next i

            Return empNum
        End Function

        Private Function formatDateHired(ByVal dateHired As Date) As String
            Dim mm, dd, yy As String
            mm = dateHired.ToString("MM")
            dd = dateHired.ToString("dd")
            yy = dateHired.ToString("yy")

            Dim l_strDateHired As String = mm & dd & yy
            Return l_strDateHired
        End Function

    End Class

    Structure structEmployee
        Dim empNum As UInteger
        'Personal Info
        Dim firstName As String
        Dim lastName As String
        Dim middleName As String
        Dim gender As String
        Dim birthDate As Date
        Dim civilStat As String
        Dim address As String
        Dim city As String
        Dim contactNum As String
        Dim email As String
        Dim SSS_num As String
        Dim TIN_num As String
        Dim philHealth_num As String
        Dim PAGIBIG_num As String
        Dim PRC_num As String
        Dim photo As Byte()     'TENTATIVE
        Dim status As String
        Dim dateHired As Date

        'Salary info
        Dim numOfDependents As UShort
        Dim payMethod As String
        Dim basicRate As Double
        Dim regOT_rate As Single
        Dim sunOT_rate As Single
        Dim holOT_rate As Single
        Dim personalLoan As Double
        Dim SSS_Loan As Double
        Dim WTax_isDeduct As Boolean
        Dim SSS_isDeduct As Boolean
        Dim philHealth_isDeduct As Boolean
        Dim PAGIBIG_isDeduct As Boolean
        '
        Dim dateCreated As Date
        Dim lastModified As Date
        Dim lastModifiedBy As UInteger
    End Structure
#End Region

    '''CLASS: EmployeeList
    Public Class EmployeeList
        Inherits System.Collections.Generic.List(Of BusinessEntity.Employee)
    End Class


    '''CLASS: PAYROLL
#Region "Payroll"
    Public Class Payroll
        Implements IPayroll

        Private sp As New structPayroll

        Public Property basicRate() As Double Implements Bridge.IPayroll.basicRate
            Get
                Return sp.basicRate
            End Get
            Set(ByVal value As Double)
                sp.basicRate = value
            End Set
        End Property

        Public Property createdBy() As UInteger Implements Bridge.IPayroll.createdBy
            Get
                Return sp.createdBy
            End Get
            Set(ByVal value As UInteger)
                sp.createdBy = value
            End Set
        End Property

        Public Property dateCreated() As Date Implements Bridge.IPayroll.dateCreated
            Get
                Return sp.dateCreated
            End Get
            Set(ByVal value As Date)
                sp.dateCreated = value
            End Set
        End Property

        Public Property holOT_rate() As Single Implements Bridge.IPayroll.holOT_rate
            Get
                Return sp.holOT_rate
            End Get
            Set(ByVal value As Single)
                sp.holOT_rate = value
            End Set
        End Property

        Public Property isReversed() As Boolean Implements Bridge.IPayroll.isReversed
            Get
                Return sp.isReversed
            End Get
            Set(ByVal value As Boolean)
                sp.isReversed = value
            End Set
        End Property

        Public Property PAGIBIG() As Double Implements Bridge.IPayroll.PAGIBIG
            Get
                Return sp.PAGIBIG
            End Get
            Set(ByVal value As Double)
                sp.PAGIBIG = value
            End Set
        End Property

        Public Property payFrom() As Date Implements Bridge.IPayroll.payFrom
            Get
                Return sp.payFrom
            End Get
            Set(ByVal value As Date)
                sp.payFrom = value
            End Set
        End Property

        Public Property empNum() As UInteger Implements Bridge.IPayroll.empNum
            Get
                Return sp.empNum
            End Get
            Set(ByVal value As UInteger)
                sp.empNum = value
            End Set
        End Property

        Public Property payrollNum() As UInteger Implements Bridge.IPayroll.payrollNum
            Get
                Return sp.payrollNum
            End Get
            Set(ByVal value As UInteger)
                sp.payrollNum = value
            End Set
        End Property

        Public Property payTo() As Date Implements Bridge.IPayroll.payTo
            Get
                Return sp.payTo
            End Get
            Set(ByVal value As Date)
                sp.payTo = value
            End Set
        End Property

        Public Property personalLoan() As Double Implements Bridge.IPayroll.personalLoan
            Get
                Return sp.personalLoan
            End Get
            Set(ByVal value As Double)
                sp.personalLoan = value
            End Set
        End Property

        Public Property philHealth() As Double Implements Bridge.IPayroll.philHealth
            Get
                Return sp.philHealth
            End Get
            Set(ByVal value As Double)
                sp.philHealth = value
            End Set
        End Property

        Public Property regOT_rate() As Single Implements Bridge.IPayroll.regOT_rate
            Get
                Return sp.regOT_rate
            End Get
            Set(ByVal value As Single)
                sp.regOT_rate = value
            End Set
        End Property

        Public Property reversedBy() As UInteger Implements Bridge.IPayroll.reversedBy
            Get
                Return sp.reversedBy
            End Get
            Set(ByVal value As UInteger)
                sp.reversedBy = value
            End Set
        End Property

        Public Property reversedDate() As Date Implements Bridge.IPayroll.reversedDate
            Get
                Return sp.reversedDate
            End Get
            Set(ByVal value As Date)
                sp.reversedDate = value
            End Set
        End Property

        Public Property SSS() As Double Implements Bridge.IPayroll.SSS
            Get
                Return sp.SSS
            End Get
            Set(ByVal value As Double)
                sp.SSS = value
            End Set
        End Property

        Public Property SSS_Loan() As Double Implements Bridge.IPayroll.SSS_Loan
            Get
                Return sp.SSS_Loan
            End Get
            Set(ByVal value As Double)
                sp.SSS_Loan = value
            End Set
        End Property

        Public Property sunOT_rate() As Single Implements Bridge.IPayroll.sunOT_rate
            Get
                Return sp.sunOT_rate
            End Get
            Set(ByVal value As Single)
                sp.sunOT_rate = value
            End Set
        End Property

        Public Property wTax() As Double Implements Bridge.IPayroll.wTax
            Get
                Return sp.wTax
            End Get
            Set(ByVal value As Double)
                sp.wTax = value
            End Set
        End Property

        Public Property civilStat As String Implements Bridge.IPayroll.civilStat
            Get
                Return sp.civilStat
            End Get
            Set(ByVal value As String)
                sp.civilStat = value
            End Set
        End Property

        Public Property grossPay As Double Implements Bridge.IPayroll.grossPay
            Get
                Return sp.grossPay
            End Get
            Set(ByVal value As Double)
                sp.grossPay = value
            End Set
        End Property

        Public Property netPay As Double Implements Bridge.IPayroll.netPay
            Get
                Return sp.netPay
            End Get
            Set(ByVal value As Double)
                sp.netPay = value
            End Set
        End Property

        Public Property numofDependent As UShort Implements Bridge.IPayroll.numofDependent
            Get
                Return sp.numOfDependent
            End Get
            Set(ByVal value As UShort)
                sp.numOfDependent = value
            End Set
        End Property

        Public Property tp_status As String Implements Bridge.IPayroll.tp_status
            Get
                Return sp.tp_status
            End Get
            Set(ByVal value As String)
                sp.tp_status = value
            End Set
        End Property

        Public Property payMethod As String Implements Bridge.IPayroll.payMethod
            Get
                Return sp.payMethod
            End Get
            Set(ByVal value As String)
                sp.payMethod = value
            End Set
        End Property
    End Class

    Structure structPayroll
        Dim payrollNum As UInteger
        Dim empNum As UInteger
        Dim payFrom As Date
        Dim payTo As Date
        Dim civilStat As String
        Dim numOfDependent As UShort
        Dim tp_status As String
        Dim payMethod As String
        Dim basicRate As Double
        Dim regOT_rate As Single
        Dim sunOT_rate As Single
        Dim holOT_rate As Single
        Dim wTax As Double
        Dim SSS As Double
        Dim philHealth As Double
        Dim PAGIBIG As Double
        Dim SSS_Loan As Double
        Dim personalLoan As Double
        Dim grossPay As Double
        Dim netPay As Double
        Dim dateCreated As Date
        Dim createdBy As UInteger
        Dim isReversed As Boolean
        Dim reversedDate As Date
        Dim reversedBy As UInteger
    End Structure
#End Region


    '''CLASS: PROJECT
#Region "Project"
    Public Class Project
        Implements IProject

        Private sp As New structProject

        Public Property dateCreated() As Date Implements Bridge.IProject.dateCreated
            Get
                Return sp.dateCreated
            End Get
            Set(ByVal value As Date)
                sp.dateCreated = value
            End Set
        End Property

        Public Property div_ID() As UShort Implements Bridge.IProject.div_ID
            Get
                Return sp.div_ID
            End Get
            Set(ByVal value As UShort)
                sp.div_ID = value
            End Set
        End Property

        Public Property empNum() As UInteger Implements Bridge.IProject.empNum
            Get
                Return sp.empNum
            End Get
            Set(ByVal value As UInteger)
                sp.empNum = value
            End Set
        End Property

        Public Property holOT_hrs() As Integer Implements Bridge.IProject.holOT_hrs
            Get
                Return sp.holOT_hrs
            End Get
            Set(ByVal value As Integer)
                sp.holOT_hrs = value
            End Set
        End Property

        Public Property lastModified() As Date Implements Bridge.IProject.lastModified
            Get
                Return sp.lastModified
            End Get
            Set(ByVal value As Date)
                sp.lastModified = value
            End Set
        End Property

        Public Property lastModifiedBy() As UInteger Implements Bridge.IProject.lastModifiedBy
            Get
                Return sp.lastModifiedBy
            End Get
            Set(ByVal value As UInteger)
                sp.lastModifiedBy = value
            End Set
        End Property

        Public Property position_ID() As UShort Implements Bridge.IProject.position_ID
            Get
                Return sp.position_ID
            End Get
            Set(ByVal value As UShort)
                sp.position_ID = value
            End Set
        End Property

        Public Property project_ID() As UInteger Implements Bridge.IProject.project_ID
            Get
                Return sp.project_ID
            End Get
            Set(ByVal value As UInteger)
                sp.project_ID = value
            End Set
        End Property

        Public Property regOT_hrs() As Integer Implements Bridge.IProject.regOT_hrs
            Get
                Return sp.regOT_hrs
            End Get
            Set(ByVal value As Integer)
                sp.regOT_hrs = value
            End Set
        End Property

        Public Property sunOT_hrs() As Integer Implements Bridge.IProject.sunOT_hrs
            Get
                Return sp.sunOT_hrs
            End Get
            Set(ByVal value As Integer)
                sp.sunOT_hrs = value
            End Set
        End Property

        Public Property workDays() As Integer Implements Bridge.IProject.workDays
            Get
                Return sp.workdays
            End Get
            Set(ByVal value As Integer)
                sp.workdays = value
            End Set
        End Property

        Public Property proj_ID As UShort Implements Bridge.IProject.proj_ID
            Get
                Return sp.proj_ID
            End Get
            Set(ByVal value As UShort)
                sp.proj_ID = value
            End Set
        End Property

        Public Property proj_name As String
            Get
                Return sp.project_name
            End Get
            Set(ByVal value As String)
                sp.project_name = value
            End Set
        End Property

        Public Property position As String
            Get
                Return sp.position
            End Get
            Set(ByVal value As String)
                sp.position = value
            End Set
        End Property

        Public Property division As String
            Get
                Return sp.division
            End Get
            Set(ByVal value As String)
                sp.division = value
            End Set
        End Property

    End Class

    Structure structProject
        Dim project_ID As UInteger
        Dim empNum As UInteger
        Dim proj_ID As UShort
        Dim position_ID As UInt16
        Dim div_ID As UInt16
        Dim workdays As Integer
        Dim regOT_hrs As Single
        Dim sunOT_hrs As Single
        Dim holOT_hrs As Single
        Dim dateCreated As Date
        Dim lastModified As Date
        Dim lastModifiedBy As UInteger
        Dim project_name As String
        Dim position As String
        Dim division As String
    End Structure
#End Region

    '''CLASS: EMPLOYEE ALLOWANCE
#Region "Employee Allowance"
    Public Class EmployeeAllowance
        Implements IAllowance

        Private sea As New structEmpAllowance

        Public Property allowanceNum() As UInteger Implements Bridge.IAllowance.allowanceNum
            Get
                Return sea.allowanceNum
            End Get
            Set(ByVal value As UInteger)
                sea.allowanceNum = value
            End Set
        End Property

        Public Property allowTypeCode() As UShort Implements Bridge.IAllowance.allowTypeCode
            Get
                Return sea.allowTypeCode
            End Get
            Set(ByVal value As UShort)
                sea.allowTypeCode = value
            End Set
        End Property

        Public Property amount() As Double Implements Bridge.IAllowance.amount
            Get
                Return sea.amount
            End Get
            Set(ByVal value As Double)
                sea.amount = value
            End Set
        End Property

        Public Property dateCreated() As Date Implements Bridge.IAllowance.dateCreated
            Get
                Return sea.dateCreated
            End Get
            Set(ByVal value As Date)
                sea.dateCreated = value
            End Set
        End Property

        Public Property lastModified() As Date Implements Bridge.IAllowance.lastModified
            Get
                Return sea.lastModified
            End Get
            Set(ByVal value As Date)
                sea.lastModified = value
            End Set
        End Property

        Public Property lastModifiedBy() As UInteger Implements Bridge.IAllowance.lastModifiedBy
            Get
                Return sea.lastModifiedBy
            End Get
            Set(ByVal value As UInteger)
                sea.lastModifiedBy = value
            End Set
        End Property

        Public Property empNum() As UInteger Implements Bridge.IAllowance.empNum
            Get
                Return sea.empNum
            End Get
            Set(ByVal value As UInteger)
                sea.empNum = value
            End Set
        End Property

        Public Property remark() As String Implements Bridge.IAllowance.remark
            Get
                Return sea.remark
            End Get
            Set(ByVal value As String)
                sea.remark = value
            End Set
        End Property

        Public Property specify() As String Implements Bridge.IAllowance.specify
            Get
                Return sea.specify
            End Get
            Set(ByVal value As String)
                sea.specify = value
            End Set
        End Property

        Public Property taxable() As Boolean Implements Bridge.IAllowance.taxable
            Get
                Return sea.taxable
            End Get
            Set(ByVal value As Boolean)
                sea.taxable = value
            End Set
        End Property
    End Class

    Structure structEmpAllowance
        Dim allowanceNum As UInteger
        Dim empNum As UInteger
        Dim allowTypeCode As UInt16
        Dim specify As String
        Dim amount As Double
        Dim remark As String
        Dim taxable As Boolean
        Dim dateCreated As Date
        Dim lastModified As Date
        Dim lastModifiedBy As UInteger
    End Structure
#End Region


    '''CLASS: BONUS
#Region "Bonus"
    Public Class Bonus
        Implements IBonus

        Private sb As New structBonus

        Public Property amount() As Double Implements Bridge.IBonus.amount
            Get
                Return sb.amount
            End Get
            Set(ByVal value As Double)
                sb.amount = value
            End Set
        End Property

        Public Property bonusTypeCode() As UInt16 Implements Bridge.IBonus.bonusTypeCode
            Get
                Return sb.bonusTypeCode
            End Get
            Set(ByVal value As UInt16)
                sb.bonusTypeCode = value
            End Set
        End Property

        Public Property dateCreated() As Date Implements Bridge.IBonus.dateCreated
            Get
                Return sb.dateCreated
            End Get
            Set(ByVal value As Date)
                sb.dateCreated = value
            End Set
        End Property

        Public Property empNum() As UInteger Implements Bridge.IBonus.empNum
            Get
                Return sb.empNum
            End Get
            Set(ByVal value As UInteger)
                sb.empNum = value
            End Set
        End Property

        Public Property ID() As UInteger Implements Bridge.IBonus.ID
            Get
                Return sb.ID
            End Get
            Set(ByVal value As UInteger)
                sb.ID = value
            End Set
        End Property

        Public Property isSettled() As Boolean Implements Bridge.IBonus.isSettled
            Get
                Return sb.isSettled
            End Get
            Set(ByVal value As Boolean)
                sb.isSettled = value
            End Set
        End Property

        Public Property lastModified() As Date Implements Bridge.IBonus.lastModified
            Get
                Return sb.lastModified
            End Get
            Set(ByVal value As Date)
                sb.lastModified = value
            End Set
        End Property

        Public Property lastModifiedBy() As UInteger Implements Bridge.IBonus.lastModifiedBy
            Get
                Return sb.lastModifiedBy
            End Get
            Set(ByVal value As UInteger)
                sb.lastModifiedBy = value
            End Set
        End Property

        Public Property remark() As String Implements Bridge.IBonus.remark
            Get
                Return sb.remark
            End Get
            Set(ByVal value As String)
                sb.remark = value
            End Set
        End Property

        Public Property settledBy() As UInteger Implements Bridge.IBonus.settledBy
            Get
                Return sb.settledBy
            End Get
            Set(ByVal value As UInteger)
                sb.settledBy = value
            End Set
        End Property

        Public Property dateSettled() As Date Implements Bridge.IBonus.dateSettled
            Get
                Return sb.dateSettled
            End Get
            Set(ByVal value As Date)
                sb.dateSettled = value
            End Set
        End Property

        Public Property specify() As String Implements Bridge.IBonus.specify
            Get
                Return sb.specify
            End Get
            Set(ByVal value As String)
                sb.specify = value
            End Set
        End Property
    End Class

    Structure structBonus
        Dim ID As UInteger
        Dim empNum As UInteger
        Dim bonusTypeCode As UInt16
        Dim specify As String
        Dim amount As Double
        Dim remark As String
        Dim isSettled As Boolean
        Dim dateSettled As Date
        Dim settledBy As UInteger
        Dim dateCreated As Date
        Dim lastModified As Date
        Dim lastModifiedBy As UInteger
    End Structure
#End Region


    '''CLASS: OTHER DEDUCTION
#Region "Other Deduction"
    Public Class OtherDeduction
        Implements IOtherDeduction

        Private sod As New structOtherBonus

        Public Property amount() As Double Implements Bridge.IOtherDeduction.amount
            Get
                Return sod.amount
            End Get
            Set(ByVal value As Double)
                sod.amount = value
            End Set
        End Property

        Public Property dateCreated() As Date Implements Bridge.IOtherDeduction.dateCreated
            Get
                Return sod.dateCreated
            End Get
            Set(ByVal value As Date)
                sod.dateCreated = value
            End Set
        End Property

        Public Property ID() As UInteger Implements Bridge.IOtherDeduction.ID
            Get
                Return sod.ID
            End Get
            Set(ByVal value As UInteger)
                sod.ID = value
            End Set
        End Property

        Public Property isSettled() As Boolean Implements Bridge.IOtherDeduction.isSettled
            Get
                Return sod.isSettled
            End Get
            Set(ByVal value As Boolean)
                sod.isSettled = value
            End Set
        End Property

        Public Property lastModified() As Date Implements Bridge.IOtherDeduction.lastModified
            Get
                Return sod.lastModified
            End Get
            Set(ByVal value As Date)
                sod.lastModified = value
            End Set
        End Property

        Public Property lastModifiedBy() As UInteger Implements Bridge.IOtherDeduction.lastModifiedBy
            Get
                Return sod.lastModifiedBy
            End Get
            Set(ByVal value As UInteger)
                sod.lastModifiedBy = value
            End Set
        End Property

        Public Property specify() As String Implements Bridge.IOtherDeduction.specify
            Get
                Return sod.specify
            End Get
            Set(ByVal value As String)
                sod.specify = value
            End Set
        End Property

        Public Property remark() As String Implements Bridge.IOtherDeduction.remark
            Get
                Return sod.remark
            End Get
            Set(ByVal value As String)
                sod.remark = value
            End Set
        End Property

        Public Property settledBy() As UInteger Implements Bridge.IOtherDeduction.settledBy
            Get
                Return sod.settledBy
            End Get
            Set(ByVal value As UInteger)
                sod.settledBy = value
            End Set
        End Property

        Public Property dateSettled() As Date Implements Bridge.IOtherDeduction.dateSettled
            Get
                Return sod.dateSettled
            End Get
            Set(ByVal value As Date)
                sod.dateSettled = value
            End Set
        End Property

        Public Property deductTypeCode() As UShort Implements Bridge.IOtherDeduction.deductTypeCode
            Get
                Return sod.deductTypeCode
            End Get
            Set(ByVal value As UShort)
                sod.deductTypeCode = value
            End Set
        End Property

        Public Property empNum() As UInteger Implements Bridge.IOtherDeduction.empNum
            Get
                Return sod.empNum
            End Get
            Set(ByVal value As UInteger)
                sod.empNum = value
            End Set
        End Property
    End Class

    Structure structOtherBonus
        Dim ID As UInteger
        Dim empNum As UInteger
        Dim deductTypeCode As UInt16
        Dim specify As String
        Dim amount As Double
        Dim remark As String
        Dim isSettled As Boolean
        Dim dateSettled As Date
        Dim settledBy As UInteger
        Dim dateCreated As Date
        Dim lastModified As Date
        Dim lastModifiedBy As UInteger
    End Structure
#End Region

    '''CLASS: PAID PROJECT
#Region "Paid Project"
    Public Class PaidProject
        Implements IPaidProject

        Private spp As New structPaidProject

        Public Property createdBy() As UInteger Implements Bridge.IPaidProject.createdBy
            Get
                Return spp.createdBy
            End Get
            Set(ByVal value As UInteger)
                spp.createdBy = value
            End Set
        End Property

        Public Property dateCreated() As Date Implements Bridge.IPaidProject.dateCreated
            Get
                Return spp.dateCreated
            End Get
            Set(ByVal value As Date)
                spp.dateCreated = value
            End Set
        End Property

        Public Property paymentNum() As UInteger Implements Bridge.IPaidProject.paymentNum
            Get
                Return spp.paymentNum
            End Get
            Set(ByVal value As UInteger)
                spp.paymentNum = value
            End Set
        End Property

        Public Property payrollNum() As UInteger Implements Bridge.IPaidProject.payrollNum
            Get
                Return spp.payrollNum
            End Get
            Set(ByVal value As UInteger)
                spp.payrollNum = value
            End Set
        End Property

        Public Property project_ID() As UInteger Implements Bridge.IPaidProject.project_ID
            Get
                Return spp.project_ID
            End Get
            Set(ByVal value As UInteger)
                spp.project_ID = value
            End Set
        End Property
    End Class

    Structure structPaidProject
        Dim paymentNum As UInteger
        Dim payrollNum As UInteger
        Dim project_ID As UInteger
        Dim dateCreated As Date
        Dim createdBy As UInteger
    End Structure
#End Region

End Namespace