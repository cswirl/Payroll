Public Class StatusStripUC
    Private WithEvents timer As New Timer

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        With timer
            .Interval = 60000
            .Start()
        End With
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer.Tick
        lblClock.Text = Now.ToString("dddd, dd MMMM yyyy HH:mm tt")
    End Sub

    Public Sub writeStatus(ByVal message As String)
        tslblMessage.Text = message
    End Sub

    Private Sub StatusStripUC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblClock.Text = Now.ToString("dddd, dd MMMM yyyy HH:mm tt")
    End Sub
End Class