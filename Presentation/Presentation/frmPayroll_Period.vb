Public Class frmPayroll_Period
    Public Event evCreatePayroll(ByVal dateFrom As Date, ByVal dateTo As Date)

    Sub New(ByVal dateFrom As Date, ByVal dateTo As Date)
        ' This call is required by the designer.
        InitializeComponent()

        dtpFrom.Value = dateFrom
        dtpTo.Value = dateTo
    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        CrossCutting.Validation.DateRange_autoCorrect(dtpFrom.Value, dtpTo.Value)
        If Not CrossCutting.Validation.isRangeValid(dtpFrom.Value, dtpTo.Value) Then
            MessageBox.Show("Date 'From' and 'To' not consistent.", "", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        RaiseEvent evCreatePayroll(dtpFrom.Value, dtpTo.Value)
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