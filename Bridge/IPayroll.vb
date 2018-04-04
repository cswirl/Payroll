
Public Interface IPayroll

    Property payrollNum() As UInteger

    Property empNum() As UInteger

    Property payFrom() As Date

    Property payTo() As Date


    Property basicRate() As Double

    Property regOT_rate() As Single

    Property sunOT_rate() As Single

    Property holOT_rate() As Single


    Property wTax() As Double

    Property SSS() As Double

    Property philHealth() As Double

    Property PAGIBIG() As Double

    Property SSS_Loan() As Double

    Property dateCreated() As Date

    Property personalLoan() As Double

    Property isReversed() As Boolean

    Property reversedDate() As Date

    Property reversedBy() As UInteger

    Property civilStat As String

    Property numofDependent As UShort

    Property tp_status As String

    Property grossPay As Double

    Property netPay As Double

    Property payMethod As String

    Property createdBy() As UInteger

End Interface