Imports BusinessLogic
Imports DataAccess

Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region "Auto-Generated"
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'MainForm
        '
        Me.ClientSize = New System.Drawing.Size(236, 102)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
#End Region

    'Private Shared WithEvents config As New frmConfiguration("")
    Friend WithEvents login As frmLogIn
    Friend WithEvents home As frmHome
    Friend WithEvents user As frmUser
    Friend WithEvents employee As frmEmployee
    Friend WithEvents tables As frmTables
    Friend WithEvents createPayroll As frmCreatePayroll     'Deprecated
    Friend WithEvents createPayroll_Nav As frmCreatePayroll_Nav
    Friend WithEvents payroll_reversal As frmPayrollRev_old
    Friend WithEvents deductables As frmDeductables
    Friend WithEvents payrollRep As frmPayrollReport
    Friend WithEvents shell As frmShell

    Friend WithEvents status As New frmStatus

    Private currentForm As Form     'Keeps track of the current form shown

    Private update_employee As Boolean = False      'Flag: True means employee form needs update

    ''Its kinda weird why this statement generates an error. Same on frmLogin - may be the modifier
    'Private home As New frmHome

    Sub New()
        'Make this form invisible
        InitializeComponent()
        Me.Opacity = 0.0
        Me.Hide()

    End Sub

    Public Sub initialize_MyForms()
        'home = New frmHome
        'user = New frmUser
        'employee = New frmEmployee
        'tables = New frmTables
        ' ''
        showLogin()
    End Sub

    'Show as volatile
    Public Sub showConfiguration(ByVal title As String,
                                 Optional ByVal msg As String = "Ready")
        Dim config As New frmConfiguration(title)
        With config
            .myManager = Me
            .tsslblMessage.Text = msg
            .ShowDialog()
        End With

    End Sub

    'Show as volatile
    Public Sub showCreatePayroll(ByVal drv As DataRowView)
        createPayroll = New frmCreatePayroll(drv)
        With createPayroll
            .ShowDialog()
        End With
    End Sub

    'Show as persistent
    Public Overloads Sub showCreatePayroll_Nav(ByVal dateFrom As Date, ByVal dateTo As Date)
        If createPayroll_Nav Is Nothing OrElse createPayroll_Nav.IsDisposed Then createPayroll_Nav = New frmCreatePayroll_Nav(dateFrom, dateTo)
        createPayroll_Nav.Show()
        createPayroll_Nav.TopMost = True
    End Sub

    Public Overloads Function showCreatePayroll_Nav() As Boolean
        If createPayroll_Nav Is Nothing OrElse createPayroll_Nav.IsDisposed Then Return False
        createPayroll_Nav.Show()
        createPayroll_Nav.TopMost = True
        Return True
    End Function

    'Show as volatile
    Public Sub showLogin()
        login = New frmLogIn
        With login
            .myOwner = Me
            .Show()
        End With

    End Sub

    ''PRIMARY FORMS
    Public Sub showHomeForm()
        If home Is Nothing OrElse home.IsDisposed Then home = New frmHome
        With home
            .myManager = Me
            .Show()
        End With
        currentForm = home
    End Sub

    Public Sub showUserForm()
        If user Is Nothing OrElse user.IsDisposed Then
            showStatus("Retrieving User records . . .")
            user = New frmUser
        End If

        With user
            .myManager = Me
            .Show()
        End With
        currentForm = user
    End Sub

    Public Sub showEmployeeForm()
        If employee Is Nothing OrElse employee.IsDisposed Then
            showStatus("Retrieving Employee records . . .")
            employee = New frmEmployee
        End If
        With employee
            .myManager = Me
            .Show()
        End With
        currentForm = employee
    End Sub

    Public Sub showTablesForm()
        'TODO: Must perform this to others to allow disposing primary form objects
        If tables Is Nothing Then
            showStatus("Retrieving Tables . . .")
            tables = New frmTables
        End If
        With tables
            .myManager = Me
            .Show()
        End With
        currentForm = tables
    End Sub

    Public Sub showDeductablesForm()
        'TODO: Must perform this to others to allow disposing primary form objects
        If deductables Is Nothing OrElse deductables.IsDisposed Then
            showStatus("Retrieving Deductables . . .")
            deductables = New frmDeductables
        End If
        With deductables
            .myManager = Me
            .Show()
        End With
        currentForm = deductables
    End Sub

    Public Sub showPayrollRepForm()
        'TODO: Must perform this to others to allow disposing primary form objects
        If payrollRep Is Nothing Then
            showStatus("Initializing Payroll Report . . .")
            payrollRep = New frmPayrollReport
        End If
        With payrollRep
            .myManager = Me
            .Show()
        End With
        currentForm = payrollRep
    End Sub

    Public Sub showShellForm()
        'TODO: Must perform this to others to allow disposing primary form objects
        If shell Is Nothing Then
            shell = New frmShell
        End If
        With shell
            .ShowDialog()
        End With
    End Sub

    Private Sub updateCurrentUserOnForms() Handles login.evCurrentUser_Changed
        'List Forms to update here. The form should have setMyCurrentUser() interface.
        Try
            If user IsNot Nothing Then user.setMyCurrentUser()
            If employee IsNot Nothing Then employee.setMyCurrentUser()
            If tables IsNot Nothing Then tables.setMyCurrentUser()
            If deductables IsNot Nothing Then deductables.setMyCurrentUser()
            If payrollRep IsNot Nothing Then payrollRep.setMyCurrentUser()
        Catch ex As Exception
            'Do Nothing

        End Try

    End Sub

    'Inform other forms that a coded domain data has been updated
    Private Sub Table_updated(ByVal table As CodedDomainManager.Tables) Handles tables.evTableUpdated
        Try
            Select Case table
                Case CodedDomainManager.Tables.Project
                    If employee IsNot Nothing Then employee.EmpProjectUC1.cbxProject_refresh()

                Case CodedDomainManager.Tables.Position
                    If employee IsNot Nothing Then employee.EmpProjectUC1.cbxPosition_refresh()

                Case CodedDomainManager.Tables.Division
                    If employee IsNot Nothing Then employee.EmpProjectUC1.cbxDivision_refresh()

                Case CodedDomainManager.Tables.AllowanceType
                    If employee IsNot Nothing Then
                        employee.AllowanceUC1.cbxDomain_Fill()
                        employee.AllowanceUC1.DataGrid_refresh()
                    End If

                Case CodedDomainManager.Tables.DeductionType
                    If employee IsNot Nothing Then
                        employee.OtherDeductionUC1.cbxDomain_Fill()
                        employee.OtherDeductionUC1.DataGrid_refresh()
                    End If

                Case CodedDomainManager.Tables.BonusType
                    If employee IsNot Nothing Then
                        employee.BonusUC1.cbxDomain_Fill()
                        employee.BonusUC1.DataGrid_refresh()
                    End If
                Case CodedDomainManager.Tables.UserType
                    'This may not be use
            End Select
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub FormManager_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not My.Settings.InitialConfiguration Then
            showConfiguration("Initial Database Configuration")

            ''FOR TESTING ONLY
            'Dim config As New CrossCutting.Configuration
            'With config
            '    .server = My.Settings.Server
            '    .port = CStr(My.Settings.Port)
            '    .username = My.Settings.Username
            '    .password = My.Settings.Password
            '    .database = My.Settings.Database
            'End With
            'CrossCutting.setConfiguration(config)

            'showHomeForm()
            ''showUserForm()
            'showEmployeeForm()
        Else
            'TODO: SET THE CONFIGURATION TO THE CROSS-CUTTING
            Dim config As New CrossCutting.Configuration
            With config
                .server = My.Settings.Server
                .port = My.Settings.Port
                .username = My.Settings.Username
                .password = My.Settings.Password
                .database = My.Settings.Database
            End With
            CrossCutting.setConfiguration(config)

            showLogin()
        End If
    End Sub

    Public Sub showStatus(ByVal message As String)
        If status Is Nothing OrElse status.IsDisposed Then status = New frmStatus
        status.Show(message)
    End Sub

    Public Sub hideStatus() Handles employee.Shown, user.Shown, tables.Shown, deductables.Shown,
        payrollRep.Shown
        If status IsNot Nothing OrElse Not status.IsDisposed AndAlso status.Visible Then status.Hide()
    End Sub

    Private Sub payroll_transacted() Handles createPayroll_Nav.evPayrollTransacts
        update_employee = True
    End Sub

    Private Sub createPayroll_Nav_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles createPayroll_Nav.FormClosed
        If update_employee Then
            employee_update()
            update_employee = False
        End If
    End Sub

    Public Sub update_currentForm()
        If TypeOf currentForm Is frmEmployee Then
            employee_update()
        ElseIf TypeOf currentForm Is frmUser Then
            user_update()
        ElseIf TypeOf currentForm Is frmTables Then
            tables_update()
        ElseIf TypeOf currentForm Is frmDeductables Then
            deductables_update()
        End If
    End Sub

    ''FORM RECORDS UPDATE METHODS
    'Disposes the Employee form and spawn a new one
    Public Sub employee_update()
        Try
            If currentForm IsNot Nothing AndAlso TypeOf currentForm Is frmEmployee Then
                showStatus("Updating Employee records . . .")
                With currentForm
                    .Close()
                    .Dispose()
                End With
                'Spawn the new employee
                employee = New frmEmployee
                With employee
                    .myManager = Me
                    .Show()
                    .Activate()
                End With
                currentForm = employee
            Else
                employee.Dispose()
                employee = Nothing
            End If
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    'Disposes the User form and spawn a new one
    Public Sub user_update()
        Try
            If currentForm IsNot Nothing AndAlso TypeOf currentForm Is frmUser Then
                showStatus("Updating User records . . .")
                With currentForm
                    .Close()
                    .Dispose()
                End With
                'Spawn the new user
                user = New frmUser
                With user
                    .myManager = Me
                    .Show()
                    .Activate()
                End With
                currentForm = user
            Else
                user.Dispose()
                user = Nothing
            End If
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    'Disposes the Tables form and spawn a new one
    Public Sub tables_update()
        Try
            If currentForm IsNot Nothing AndAlso TypeOf currentForm Is frmTables Then
                showStatus("Updating Tables . . .")
                With currentForm
                    .Close()
                    .Dispose()
                End With
                'Spawn the new tables
                tables = New frmTables
                With tables
                    .myManager = Me
                    .Show()
                    .Activate()
                End With
                currentForm = tables
            Else
                tables.Dispose()
                tables = Nothing
            End If
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    'Disposes the Deductable form and spawn a new one
    Public Sub deductables_update() Handles shell.evPayroll_Deductions_restored
        Try
            If currentForm IsNot Nothing AndAlso TypeOf currentForm Is frmDeductables Then
                showStatus("Updating Deduction Tables . . .")
                With currentForm
                    .Close()
                    .Dispose()
                End With
                'Spawn the new deductable
                deductables = New frmDeductables
                With deductables
                    .myManager = Me
                    .Show()
                    .Activate()
                End With
                currentForm = deductables
            Else
                deductables.Dispose()
                deductables = Nothing
            End If
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    ' ''DEPRECATED METHODS
    ''Refresh forms - update its data
    'Private Sub payroll_transacted() Handles createPayroll_Nav.evPayrollTransacts
    '    update_employee = True
    '    Try
    '        If employee IsNot Nothing Then
    '            'Dispose the old employee and Spawn a new one
    '            With employee
    '                .Close()
    '                .Dispose()
    '            End With
    '            employee = New frmEmployee
    '            employee.myManager = Me
    '        End If
    '    Catch ex As Exception
    '        Bugs_DAO.log(ex)
    '    End Try
    'End Sub

    ''Triggers after Payroll transaction are and the Form use to create a payroll (createPayroll_Nav) is closed
    'Private Sub createPayroll_Nav_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles createPayroll_Nav.FormClosed
    '    If currentForm IsNot Nothing Then
    '        'The only Primary form susceptible for disposing is employee
    '        'If thats the case, the currentForm should then reference to the newly created employee 
    '        ' which is created thru payroll_transacted() event handler
    '        If currentForm.IsDisposed Then
    '            currentForm = employee
    '            showStatus("Updating Employee records . . .")
    '        End If
    '        With currentForm
    '            .Show()
    '            .Activate()
    '        End With
    '    End If
    'End Sub

End Class