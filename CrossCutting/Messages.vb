Public Class Messages
    Public Shared Sub SuccessMessage(ByVal message As String)
        MsgBox(message, MsgBoxStyle.Information, "")
    End Sub

    Public Shared Sub WarningMessage(ByVal message As String)
        MsgBox(message, MsgBoxStyle.Exclamation, "")
    End Sub
End Class
