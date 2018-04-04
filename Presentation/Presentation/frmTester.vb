Public Class frmTester

    Private Sub frmTester_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CodedDomainUC1.initialize_Me(BusinessLogic.CodedDomainManager.Tables.Position)
    End Sub
End Class