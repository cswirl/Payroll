Imports BusinessLogic
Imports CrossCutting
Imports BusinessLogic.BusinessEntity

Public Class frmPayrollReport
    Implements IManagerBased

    Private _myCaller As IManagerBased
    Private _myManager As MainForm

    Private WithEvents dateRange As frmReport_Period

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Header1.lblTitle.Text = "Payroll Report"
        Me.Text = "Payroll Report"
        KeyPreview = True
    End Sub

    Public Property myCaller() As IManagerBased Implements IManagerBased.myCaller
        Get
            Return _myCaller
        End Get
        Set(ByVal value As IManagerBased)
            _myCaller = value
        End Set
    End Property

    Public Property myManager() As MainForm Implements IManagerBased.myManager
        Get
            Return _myManager
        End Get
        Set(ByVal value As MainForm)
            _myManager = value
        End Set
    End Property

    Private Sub frmPayrollReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        functionKey_Press(NavUCMain, e)
    End Sub

    Private Sub frmPayrollReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'INITIALIZE MENU AND NAVIGATION
            'NavUCMain and MenuUCMain cannot put into constructor becoz myManager is not yet set at that moment
            With NavUCMain
                .formManager = Me.myManager
                .myOwner = Me
            End With
            MenuUCMain.myMainForm = Me.myManager

        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus("Error while loading Payroll Report Form")
        End Try
    End Sub

    Private Sub writeStatus(ByVal message As String)
        StatusStripUC1.writeStatus(message)
    End Sub

    'Display common functions for all Primary forms
#Region "Set Display"
    Private Sub AdminControlsHandler()
        'if the user is not an administrative type, hide this button
        If isAdmin(CurrentUser) Then
            '
        Else

        End If

    End Sub

    Private Sub frmPayrollReport_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Presentation_Mod.displayCompanyName(Header1.lblCompanyName)
        setMyCurrentUser()
    End Sub

    'THIS SUB CAN USE ON ALL FORMS TO UPDATE THEIR DATA BY USING SINGLE EVENT ON THE FormManager
    Public Sub setMyCurrentUser()
        displayCurrentUser(Header1.lblUser)
        AdminControlsHandler()
    End Sub

#End Region

    Private Sub btnPayrollSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayrollSheet.Click
        dateRange = New frmReport_Period("Payroll Sheet", ReportGenerator.Reports.PayrollSheet)
        dateRange.ShowDialog()
    End Sub

    Private Sub btnConsolePayrollReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsolePayrollReg.Click
        dateRange = New frmReport_Period("Consolidated Payroll Register", ReportGenerator.Reports.ConsolidatedPayrollRegister)
        dateRange.ShowDialog()
    End Sub

    Private Sub showReport(ByVal report As ReportGenerator.Reports) Handles dateRange.evPreview
        Dim reportForm As New frmReport(report)
        With reportForm
            .dateFrom = dateRange.dtpFrom.Value
            .dateTo = dateRange.dtpTo.Value
        End With
        reportForm.ShowDialog()
    End Sub
End Class