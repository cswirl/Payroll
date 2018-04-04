
Public Interface IEmployee

    Property empNum() As UInteger

    ''PERSONAL INFO

    Property firstName() As String

    Property lastName() As String

    Property middleName() As String

    Property gender() As String

    Property birthDate() As Date

    Property address() As String

    Property city() As String

    Property contactNum() As String

    Property email() As String

    Property SSS_Num() As String

    Property TIN_Num() As String

    Property philHealth_Num() As String

    Property PAGIBIG_Num() As String

    Property PRC_Num() As String

    ''' <summary>
    ''' Array of bytes. How the max length?
    ''' </summary>
    Property photo() As Byte()

    Property status() As String

    Property dateHired() As Date


    ''SALARY INFO

    Property civilStat() As String

    Property numOfDependents() As UShort

    Property payMethod() As String

    Property basicRate() As Double


    Property regOt_rate() As Single

    Property sunOt_rate() As Single

    Property holOt_rate() As Single

    Property WTax_isDeduct() As Boolean

    Property SSS_isDeduct() As Boolean

    Property philHealth_isDeduct() As Boolean

    Property PAGIBIG_isDeduct() As Boolean


    Property dateCreated() As Date

    Property lastModified() As Date

    Property lastModifiedBy() As UInteger

    Property personalLoan() As Double

    Property SSS_Loan() As Double


    Function getFormattedEmpNum() As String
End Interface