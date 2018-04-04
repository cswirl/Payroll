Imports CrossCutting
Imports DataAccess
Imports Bridge

Public Class Logger

    Public Shared Sub thirdLoginAttempt(ByVal username As String, ByVal password As String)
        Dim message As String = "Third Login attempt " & vbCrLf & vbCrLf & _
        "Username : " & username & vbCrLf & _
        "Password : " & password
        Log_DAO.log(message, getCurrentUser_UserID, BusinessRulesViolationCode.ThirdLoginAttempt)
    End Sub

    Public Shared Sub possibleSQLInjection(ByVal value As String, ByVal stackTrace As String)
        Dim message As String = "Possible SQL Injection : " & value
        Log_DAO.log(message, stackTrace, getCurrentUser_UserID(), BusinessRulesViolationCode.PossibleSQLInjection)
    End Sub

    Public Sub unauthorizedPayrollReversal()
        Dim message As String = "Unauthorized Payroll Reversal."
        Log_DAO.log(message, getCurrentUser_UserID(), BusinessRulesViolationCode.UnauthorizedPayrollReversal)
    End Sub
End Class