Imports System.Windows.Forms
' These Messages is to be displayed to the user.
Public Class MyMessageBox

#Region "Error Message"
    'Error messages
    Public Const INVALID_INPUT As String = "Invalid input data"
    Public Const INVALID_DATA_TYPE = "Invalid data type"

    Public Shared Sub error_generalInput()
        MessageBox.Show(INVALID_INPUT, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Shared Sub invalidDataType()
        MessageBox.Show(INVALID_DATA_TYPE, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Shared Sub error_customMessage(ByVal message As String)
        MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Shared Function outOfRange(ByVal maxValue As UInteger, _
                                           Optional ByVal name As String = "") As String
        Return name & " cannot exceeds max value of " & maxValue
    End Function

    Public Shared Function BusinessRulesMessage(ByVal code As BusinessRulesViolationCode) As String
        Select Case code
            Case BusinessRulesViolationCode.ThirdLoginAttempt
                Return String.Format("Error : {0} - Please contact the Administrator.", _
                                     CType(code, Integer))
            Case BusinessRulesViolationCode.PossibleSQLInjection
                Return String.Format("Error : {0} - Please contact the Administrator.", _
                                     CType(code, Integer))

            Case BusinessRulesViolationCode.UnauthorizedPayrollReversal
                Return String.Format("Error : {0} - Please contact the Administrator.", _
                                     CType(code, Integer))

            Case Else
                Return "Unknow Error"
        End Select
    End Function


    Public Shared Function OperationErrorMessage(ByVal code As DataAccessExceptionCode) As String
        'Select Case code
        '    Case DataAccessExceptionCode.GeneralError
        '        Return ""

        '    Case DataAccessExceptionCode.User_retrieveAll
        '        Return String.Format("Error : {0} - Please contact the Administrator.", _
        '                             CType(code, Integer))

        '    Case Else
        '        Return "Unknow Error"
        'End Select
        Return String.Format("Error : {0} - Please contact the Administrator.", _
                                     CType(code, Integer))
    End Function
#End Region

#Region "Success Message"
    Public Shared Sub success_customMessage(ByVal message As String)
        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region

    ' Other Message
    Public Shared Sub informativeMessage(ByVal message As String)
        MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Sub warningMessage(ByVal message As String)
        MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Shared Function questionMessage(ByVal message As String) As Boolean
        If MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Return True
        End If
        Return False
    End Function
End Class