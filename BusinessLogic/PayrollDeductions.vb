Public Class PayrollDeductions
    Private myPayMethod As PayMethod

    Sub New(ByVal payMethod As PayMethod)
        myPayMethod = payMethod
    End Sub

    Public Enum PayMethod
        Daily
        Monthly
    End Enum

    'WTAX
    Public Shared Function getWTax(ByVal monthlyBasicPay As Double, ByVal taxPayerStat As String, _
                                   ByVal numberOfDependents As UShort) As Double

    End Function

    'SSS
    Public Shared Function getSSS() As Double

    End Function

    'PHILHEALTH
    Public Shared Function getPhilHealth() As Double

    End Function

    'PAGIBIG
    Public Shared Function getPAGIBIG() As Double

    End Function

End Class