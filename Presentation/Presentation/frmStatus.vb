
Public Class frmStatus
    Public Overloads Sub Show(ByVal message As String)
        lblStatus.Text = message
        Me.Show()

        Application.DoEvents()
        Threading.Thread.Sleep(1000)
    End Sub

    Public Overloads Sub ShowDialog(ByVal message As String)
        lblStatus.Text = message
        Me.Visible = False
        Me.ShowDialog()

        'System.Threading.Thread.CurrentThread.Sleep(10000)
        Application.DoEvents()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class