Public Class NavUC

    Friend WithEvents _mainForm As New MainForm
    Friend WithEvents _myOwner As New Form
    Private WithEvents payroll_period As frmPayroll_Period

    Public Property myOwner() As Form
        Get
            Return _myOwner
        End Get
        Set(ByVal value As Form)
            _myOwner = value
        End Set
    End Property

    Public Property formManager() As MainForm
        Get
            Return _mainForm
        End Get
        Set(ByVal value As MainForm)
            _mainForm = value
        End Set
    End Property

    Private Sub disableParentButton() Handles _myOwner.Shown
        'ParentForm is not the solution
        If Me.myOwner.Name.Equals(frmHome.Name) Then
            tsbtnHome.Enabled = False
            'changeParentButtonLook(tsbtnHome)

        ElseIf Me.myOwner.Name.Equals(frmEmployee.Name) Then
            changeParentButtonLook(tsbtnEmployeeMF)

        ElseIf Me.myOwner.Name.Equals(frmUser.Name) Then
            changeParentButtonLook(tsbtnUserMF)

        ElseIf Me.myOwner.Name.Equals(frmTables.Name) Then
            changeParentButtonLook(tsbtnTables)

        ElseIf Me.myOwner.Name.Equals(frmDeductables.Name) Then
            changeParentButtonLook(tsbtnDeductables)

        ElseIf Me.myOwner.Name.Equals(frmPayrollReport.Name) Then
            changeParentButtonLook(tsbtnPayrollRep)

        End If
    End Sub

    Private Sub changeParentButtonLook(ByRef button As System.Windows.Forms.ToolStripButton)
        With button
            .Enabled = False
            .BackColor = Color.Ivory
        End With
    End Sub

    Private Sub NavUC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        disableParentButton()
    End Sub


    Private Sub tsbtnFindUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnUserMF.Click
        formManager.showUserForm()
        hideMyOwner()
    End Sub

    Private Sub tsbtnFindEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEmployeeMF.Click
        formManager.showEmployeeForm()
        hideMyOwner()
    End Sub

    Private Sub tsbtnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnHome.Click
        formManager.showHomeForm()
        hideMyOwner()
    End Sub

    Private Sub hideMyOwner()
        With myOwner
            .Hide()
        End With
    End Sub

    Private Sub tsbtnTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnTables.Click
        formManager.showTablesForm()
        hideMyOwner()
    End Sub

    Private Sub tsbtnRepPayroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPayrollRep.Click
        'Dim report As New frmReport(BusinessLogic.ReportGenerator.Reports.Daily)
        'report.ShowDialog()
        formManager.showPayrollRepForm()
        hideMyOwner()
    End Sub

    Private Sub tsbtnPayroll_Rev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPayroll_Rev.Click
        'Using payroll_rev As New frmPayrollRev
        '    payroll_rev.ShowDialog()
        'End Using
        MsgBox("Under Construction", MsgBoxStyle.OkOnly, "")
    End Sub

    Private Sub tsbtnCreatePayroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCreatePayroll.Click
        If formManager.createPayroll_Nav Is Nothing OrElse formManager.createPayroll_Nav.IsDisposed Then
            payroll_period = New frmPayroll_Period
            payroll_period.ShowDialog()
        Else
            'This statement will just make the live object of createPayroll_Nav visible, Now is just a fake value, 
            formManager.showCreatePayroll_Nav(Now, Now)
        End If
    End Sub

    Private Sub createPayroll(ByVal dateFrom As Date, ByVal dateTo As Date) Handles payroll_period.evCreatePayroll
        formManager.showCreatePayroll_Nav(dateFrom, dateTo)
    End Sub

    Private Sub tsbtnDeductables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDeductables.Click
        formManager.showDeductablesForm()
        hideMyOwner()
    End Sub
End Class