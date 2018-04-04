Imports BusinessLogic

Public Class frmReport_Period
    Private myReport As ReportGenerator.Reports
    Public Event evPreview(ByVal report As ReportGenerator.Reports)

    Sub New(ByVal title As String, ByVal report As ReportGenerator.Reports)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblTitle.Text = title
        myReport = report
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        CrossCutting.Validation.DateRange_autoCorrect(dtpFrom.Value, dtpTo.Value)
        If Not CrossCutting.Validation.isRangeValid(dtpFrom.Value, dtpTo.Value) Then
            MessageBox.Show("Date 'From' and 'To' not consistent.", "", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        RaiseEvent evPreview(myReport)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmDateRange_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            Me.Dispose()
        End If
    End Sub
End Class