Imports CrossCutting
Imports BusinessLogic
Imports BusinessLogic.BusinessEntity
Imports DataAccess

Public Class frmEmployee

    Private g_emp As New Employee
    Private g_newEmp As New Employee

    Public Event evPerformedDBOperation(ByVal dbOperation As DB_Operation)
    Public Event evEmployeeStatus_Changed(ByVal status As String)

    Private tabPageDisabler As New Panel
    Private lblTabPageDisabler As New Label
    Private lblEmpNumFormat As New Label

    Private WithEvents payroll As frmCreatePayroll  'Deprecated
    ''NOTE: Once the frmCreatePayroll_Nav closes, and a payroll transaction/s is created. The frmEmployee
    ' will automatically refresh its datasource from the database. A disposing of the current and creating a new one 
    ' through FormMain is the most cleanest and efficient.

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblTitle.Text = "Employee Master File"
        Me.Text = "Employee"
        initializeControls()

        initializeMyWizard("Personal Info", "Salary")
        KeyPreview = True

    End Sub

    Private Sub frmEmployee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        functionKey_Press(NavUCMain, e)
    End Sub

    Private Sub frmEmployee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'INITIALIZE MENU AND NAVIGATION
            'NavUCMain and MenuUCMain cannot put into constructor coz myManager is not yet set at that moment
            With NavUCMain
                .formManager = Me.myManager
                .myOwner = Me
            End With
            MenuUCMain.myMainForm = Me.myManager

            'Wizard
            With SplitContainerMain.Panel2.Controls
                .Add(myBtnWizardForward)
                .Add(myBtnWizardBack)
                .Add(myBtnWizardCancel)
            End With

            'These establishes a connection to the database right away
            EmpProjectUC1.initialize_Me()
            AllowanceUC1.initialize_Me(AllowanceUC.Tables.Allowance)
            OtherDeductionUC1.initialize_Me(OtherDeductionUC.Tables.Deduction)
            BonusUC1.initialize_Me(BonusUC.Tables.Bonus)
            initializeMyComponent()
            Emp_QuickSearchUC1.initialize_Me(bindSource)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            writeStatus("An error occur while loading Employee Form")
        End Try
    End Sub

    Private Sub writeStatus(ByVal msg As String) Handles BonusUC1.evStatusMessage, AllowanceUC1.evStatusMessage, _
        OtherDeductionUC1.evStatusMessage, Emp_QuickSearchUC1.evStatusMessage, EmpProjectUC1.evStatusMessage
        StatusStripUC1.writeStatus(msg)
    End Sub

    'Get the Employee's personal info needed to insert and update a record
    Private Sub getPersonalInfo()
        If g_emp Is Nothing Then g_emp = New Employee
        Try
            ''Personal Info
            With g_emp
                If getMyState = FormState.Modifying Then
                    .empNum = CUInt(CType(bindSource.Current, DataRowView)("empNum"))
                End If
                .firstName = txtFN.Text
                .lastName = txtLN.Text
                .middleName = txtMN.Text
                .gender = CStr(cbxGender.SelectedItem)
                .birthDate = dtpBirthDate.Value
                .civilStat = CStr(cbxCivilStatus.SelectedItem)
                .address = txtAddress.Text
                .city = txtCity.Text
                .contactNum = txtContact.Text
                .email = txtEmail.Text
                .SSS_Num = txtSSS_num.Text
                .TIN_Num = txtTIN_num.Text
                .philHealth_Num = txtPhilHealth_num.Text
                .PAGIBIG_Num = txtPAGIBIG_num.Text
                .PRC_Num = txtPRC_num.Text
                '.photo = 
                .status = CStr(cbxStatus.SelectedItem)
                .dateHired = dtpDateHired.Value
            End With
        Catch icex As InvalidCastException
            Throw New MyApplicationException(MyMessageBox.INVALID_DATA_TYPE)
        Catch ofex As OverflowException
            Throw New MyApplicationException(MyMessageBox.outOfRange(0))
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Get the Employee's salary info needed to insert and update a record
    Private Sub getSalaryInfo()
        If g_emp Is Nothing Then g_emp = New Employee
        Try
            With g_emp
                If getMyState = FormState.Modifying Then
                    .empNum = CUInt(CType(bindSource.Current, DataRowView)("empNum"))
                End If
                .payMethod = CStr(cbxPayMethod.SelectedItem)
                .basicRate = CDbl(txtBasicRate.Text)
                .numOfDependents = CShort(txtNumOfDependents.Text)
                .regOt_rate = CSng(txtRegOT_rate.Text)
                .sunOt_rate = CSng(txtSunOT_rate.Text)
                .holOt_rate = CSng(txtHolOT_rate.Text)
                .personalLoan = CDbl(DBNullToNumeric(txtPersonalLoan.Text))
                .SSS_Loan = CDbl(DBNullToNumeric(txtSSS_Loan.Text))
                .WTax_isDeduct = checkWTax.Checked
                .SSS_isDeduct = checkSSS.Checked
                .philHealth_isDeduct = checkPhilHealth.Checked
                .PAGIBIG_isDeduct = checkPAGIBIG.Checked
            End With
        Catch icex As InvalidCastException
            Throw New MyApplicationException(MyMessageBox.INVALID_DATA_TYPE)
        Catch ofex As OverflowException
            Throw New MyApplicationException(MyMessageBox.outOfRange(0))
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            MyMessageBox.error_generalInput()
            Throw ex
        End Try
    End Sub

    Private Sub myDB_OperationPerformed(ByVal operationPerformed As DB_Operation) _
    Handles Me.evPerformedDBOperation
        Select Case operationPerformed
            Case DB_Operation.Create
                addingSuccess()
            Case DB_Operation.Update
                modifyingSuccess()
        End Select
        'Release the g_emp current object to reuse by another operation
        g_emp = Nothing

        'Triggers the method inherited from the abstract StateOriented
        DB_OperationPerformed(operationPerformed)

        representPrimeInfo()
    End Sub

    Private Sub FormatEmpNum()
        Try
            Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
            Dim e As New Employee
            e.empNum = CUInt(drv("empNum"))
            e.dateHired = CDate(drv("dateHired"))
            lblEmpNumFormat.Text = e.getFormattedEmpNum
        Catch ex As Exception
            'log
            Bugs_DAO.log(ex)
        End Try

    End Sub

#Region "Set Display"
    Private Sub frmEmployee_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        initializeMyHeader()
        '
        initializeMyWizardButtons(SplitContainerMain.Panel2, 30, 30, 0, _
                                  StatusStripMain.Height + BindingNavigatorMain.Height)
        initializeEmpHead()
        initializeTabPageDisabler()
    End Sub

    Private Sub initializeTabPageDisabler()
        SplitContainerMain.Panel2.Controls.Add(tabPageDisabler)
        With tabPageDisabler
            .Width = TabControlMain.Width
            .Height = 25
            .Location = TabControlMain.Location
            .BackColor = Color.RoyalBlue
            .BringToFront()
            .Controls.Add(lblTabPageDisabler)
            .Hide()
        End With

        With lblTabPageDisabler
            .Font = New Font(New System.Drawing.FontFamily("Tahoma"), 13, FontStyle.Bold)
            .ForeColor = Color.White
            .AutoSize = True
        End With

        AddHandler TabControlMain.SelectedIndexChanged, AddressOf lblTabPageDisabler_changeText
    End Sub

    Private Sub showTabPageDisabler(ByVal title As String)
        With tabPageDisabler
            .Show()
        End With
        setTabPageDisabler_Label(title)

    End Sub

    Private Sub lblTabPageDisabler_changeText()
        lblTabPageDisabler.Text = TabControlMain.SelectedTab.Tag.ToString()
    End Sub

    Private Sub setTabPageDisabler_Label(ByVal title As String)
        Try
            If Not lblTabPageDisabler Is Nothing AndAlso Not lblTabPageDisabler.Parent Is Nothing Then
                With lblTabPageDisabler
                    .Text = title
                    Dim parentHorizontalCenter As Integer = lblTabPageDisabler.Parent.Width / 2
                    Dim xLocation As Integer = parentHorizontalCenter - (lblTabPageDisabler.Width / 2)

                    Dim parentVerticalCenter As Integer = lblTabPageDisabler.Parent.Height / 2
                    Dim yLocation As Integer = parentVerticalCenter - (lblTabPageDisabler.Height / 2)
                    .Location = New Point(xLocation, yLocation)
                End With
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub hideTabPageDisabler()
        With tabPageDisabler
            .Hide()
        End With
    End Sub


    Public Sub initializeMyHeader()
        displayCompanyName(lblCompanyName)
        displayCurrentUser(lblUser)
    End Sub

    Private Sub initializeEmpHead()
        'Re-Organize Parenting
        SplitContainer1.Panel1.Controls.Remove(PanelEmpHead)
        SplitContainerMain.Panel2.Controls.Add(PanelEmpHead)

        'Set Location of PanelEmpHead
        Dim xLoc As Integer = TabControlMain.Location.X + TabControlMain.TabPages(0).Location.X + SplitContainer1.Location.X
        Dim yLoc As Integer = TabControlMain.Location.Y + TabControlMain.TabPages(0).Location.Y + SplitContainer1.Location.Y
        With PanelEmpHead
            .Location = New Point(xLoc, yLoc)
            .Height = SplitContainer1.Panel1.Height
            .Width = SplitContainer1.Panel1.Width
            .BackColor = TabPagePersonal.BackColor
            .BringToFront()
        End With

    End Sub

    'THIS SUB CAN USE TO UPDATE ALL FORMS BY USING SINGLE EVENT ON THE FormManager
    Public Sub setMyCurrentUser()
        displayCurrentUser(lblUser)
        AdminControlsHandler()
    End Sub

    'Controls for admin can be shown thru this method
    Private Sub AdminControlsHandler()
        'if the user is not an administrative type, hide this button
        If isAdmin(CurrentUser) Then
            'TURN THE CONTROLS FOR ADMIN USE TO VISIBLE / ENABLE
        Else
            'TURN THE CONTROLS FOR ADMIN USE TO INVISIBLE / DISABLE
        End If
    End Sub
#End Region

#Region "Wizard"
    'Wizard
    Private Sub wizardPosition_changed(ByVal index As Integer) Handles MyBase.evWizardStep_changed
        TabControlMain.SelectedIndex = index
        writeStatus(String.Format("Please Fill-up employee `{0}` correctly", getCurrentStepToString))
    End Sub

    Protected Overrides Sub initializeMyWizard(ByVal ParamArray steps() As String)
        addSteps(steps)
    End Sub

    Protected Overrides Function canStepForward() As Boolean
        Dim em As New EmployeeManager
        Dim err_msg As String = "An error had occured while fetching data. Please try again."
        Try
            Select Case getCurrentStep()
                Case 1
                    getPersonalInfo()
                    em.personalInfo_validateData(g_emp)
                    em.personalInfo_checkRequiredData(g_emp)
            End Select
        Catch appex As MyApplicationException
            writeStatus(err_msg)
            MyMessageBox.error_customMessage(err_msg)
            Return False
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
            Return False
        Catch ex As Exception
            writeStatus(err_msg)
            MyMessageBox.error_customMessage(err_msg)
            Return False
        End Try

        Return True
    End Function
#End Region

#Region "State Oriented"
    'StateOriented
    Protected Overrides Sub initializeMyComponent()
        Try
            addControlToConceal(cbxGender, cbxCivilStatus, cbxStatus, cbxPayMethod, _
                                 dtpBirthDate, dtpDateHired)
            'SET BUTTONS For State
            myBtnAdd = tsbtnAdd
            myBtnModify = tsbtnEdit

            'DATA SOURCE AND BINDINGS
            Dim em As New BusinessLogic.EmployeeManager
            dtPrimeDS = em.retrieveAll

            bindSource = New BindingSource()
            With bindSource
                .AllowNew = True
                .DataSource = dtPrimeDS
            End With

            BindingNavigatorMain.BindingSource = bindSource

            idleState()
        Catch daex As DataAccessException
            Throw daex
        End Try
    End Sub

    Protected Overrides Sub initializeControls()
        With cbxGender
            .Items.Add("Male")
            .Items.Add("Female")
            .SelectedIndex = 0
        End With

        With cbxCivilStatus
            .Items.Add("Single")
            .Items.Add("Married")
            .Items.Add("Separated")
            .Items.Add("Widow")
            .Items.Add("Widower")
            .SelectedIndex = 0
        End With

        With cbxStatus
            .Items.Add("Active")
            .Items.Add("Inactive")
            .SelectedIndex = 0
        End With

        With cbxPayMethod
            '.Items.Add("Daily")
            .Items.Add("Weekly")
            .Items.Add("Semi")
            '.Items.Add("Monthly")
            .SelectedIndex = 0
        End With

        gbxEmpNum.Controls.Add(lblEmpNumFormat)
        With lblEmpNumFormat
            .Top = txtEmpNum.Location.Y + 2
            .Left = txtEmpNum.Location.X + 2 ' cBox.Parent.Left + 2
            .Width = txtEmpNum.Width - 4
            .Height = txtEmpNum.Height - 4
            .Font = New Font(New FontFamily("Tahoma"), txtEmpNum.Font.Size, FontStyle.Bold)
            .ForeColor = Color.Blue
            .BackColor = Color.White
            .TextAlign = ContentAlignment.MiddleRight
            .BringToFront()
        End With
    End Sub

    Protected Overrides Sub bindMyControls()
        Try
            If Not bindSource Is Nothing Then
                txtEmpNum.DataBindings.Add("text", bindSource, "empNum")
                txtFN.DataBindings.Add("text", bindSource, "firstName")
                txtLN.DataBindings.Add("text", bindSource, "lastName")
                txtMN.DataBindings.Add("text", bindSource, "middleName")
                txtAddress.DataBindings.Add("text", bindSource, "address")
                txtCity.DataBindings.Add("text", bindSource, "city")
                txtContact.DataBindings.Add("text", bindSource, "contactNum")
                txtEmail.DataBindings.Add("text", bindSource, "email")
                txtSSS_num.DataBindings.Add("text", bindSource, "SSS_num")
                txtTIN_num.DataBindings.Add("text", bindSource, "TIN_num")
                txtPhilHealth_num.DataBindings.Add("text", bindSource, "philHealth_num")
                txtPAGIBIG_num.DataBindings.Add("text", bindSource, "PAGIBIG_num")
                txtPRC_num.DataBindings.Add("text", bindSource, "PRC_num")
                txtNumOfDependents.DataBindings.Add("text", bindSource, "numOfDependent")
                txtBasicRate.DataBindings.Add("text", bindSource, "basicRate")
                txtRegOT_rate.DataBindings.Add("text", bindSource, "regOT_rate")
                txtSunOT_rate.DataBindings.Add("text", bindSource, "sunOT_rate")
                txtHolOT_rate.DataBindings.Add("text", bindSource, "holOT_rate")
                txtPersonalLoan.DataBindings.Add("text", bindSource, "personalLoan")
                txtSSS_Loan.DataBindings.Add("text", bindSource, "SSS_Loan")

                'CANNOT REPRESENT DATA - another conversion is use when representing.
                cbxGender.DataBindings.Add("valueMember", bindSource, "gender")
                cbxCivilStatus.DataBindings.Add("valueMember", bindSource, "civilStatus")
                cbxStatus.DataBindings.Add("valueMember", bindSource, "status")
                cbxPayMethod.DataBindings.Add("valueMember", bindSource, "payMethod")

                dtpBirthDate.DataBindings.Add("text", bindSource, "birthDate")
                dtpDateHired.DataBindings.Add("text", bindSource, "dateHired")

                checkWTax.DataBindings.Add("checked", bindSource, "WTax_isDeduct")
                checkSSS.DataBindings.Add("checked", bindSource, "SSS_isDeduct")
                checkPhilHealth.DataBindings.Add("checked", bindSource, "philHealth_isDeduct")
                checkPAGIBIG.DataBindings.Add("checked", bindSource, "PAGIBIG_isDeduct")

                'Register the bounded controls to centralize their read-only and edit mode states
                addBoundedControl(txtEmpNum, txtFN, txtLN, txtMN, txtAddress, txtCity, txtContact, _
                                  txtEmail, txtSSS_num, txtTIN_num, txtPhilHealth_num, txtPAGIBIG_num, _
                                  txtPRC_num, txtNumOfDependents, txtBasicRate, txtRegOT_rate, _
                                  txtSunOT_rate, txtHolOT_rate, txtPersonalLoan, txtSSS_Loan, cbxGender, cbxCivilStatus, _
                                  cbxStatus, cbxPayMethod, dtpBirthDate, dtpDateHired, checkWTax, checkSSS, _
                                  checkPhilHealth, checkPAGIBIG)
                isPrimeBound = True
                positionChanged()
            End If
        Catch ex As Exception
            'DISABLE SOME OF THE CONTROLS TO SUPPRESS ERRORS
            Throw New MyApplicationException("An error occured while binding the data to the data source.")
            Bugs_DAO.log(ex)
        End Try

    End Sub

    'Used by 3 states (specially adding and modifying states)
    Protected Overrides Sub boundedControls_readOnly(ByVal bool As Boolean)
        txtFN.ReadOnly = bool
        txtLN.ReadOnly = bool
        txtMN.ReadOnly = bool
        txtAddress.ReadOnly = bool
        txtCity.ReadOnly = bool
        txtContact.ReadOnly = bool
        txtEmail.ReadOnly = bool
        txtSSS_num.ReadOnly = bool
        txtTIN_num.ReadOnly = bool
        txtPhilHealth_num.ReadOnly = bool
        txtPAGIBIG_num.ReadOnly = bool
        txtPRC_num.ReadOnly = bool
        txtNumOfDependents.ReadOnly = bool
        txtBasicRate.ReadOnly = bool
        txtRegOT_rate.ReadOnly = bool
        txtSunOT_rate.ReadOnly = bool
        txtHolOT_rate.ReadOnly = bool
        txtPersonalLoan.ReadOnly = bool
        txtSSS_Loan.ReadOnly = bool
        cbxGender.Enabled = IIf(bool, False, True)
        cbxCivilStatus.Enabled = IIf(bool, False, True)
        cbxStatus.Enabled = IIf(bool, False, True)
        cbxPayMethod.Enabled = IIf(bool, False, True)
        dtpBirthDate.Enabled = IIf(bool, False, True)

        checkWTax.Enabled = IIf(bool, False, True)
        checkSSS.Enabled = IIf(bool, False, True)
        checkPhilHealth.Enabled = IIf(bool, False, True)
        checkPAGIBIG.Enabled = IIf(bool, False, True)

        If getMyState = FormState.Modifying Then
            dtpDateHired.Enabled = False
        Else
            dtpDateHired.Enabled = IIf(bool, False, True)
        End If

    End Sub

    Protected Overrides Sub addingState_DefaultControls()
        Try
            ''Personal Info
            lblEmpNumFormat.Text = "[Auto]"
            txtFN.Clear()
            txtLN.Clear()
            txtMN.Clear()
            txtAddress.Clear()
            txtCity.Clear()
            txtContact.Clear()
            txtEmail.Clear()
            txtSSS_num.Clear()
            txtTIN_num.Clear()
            txtPhilHealth_num.Clear()
            txtPAGIBIG_num.Clear()
            txtPRC_num.Clear()

            'Salary Info
            txtNumOfDependents.Text = "0"
            cbxGender.SelectedIndex = 0
            cbxCivilStatus.SelectedIndex = 0
            cbxStatus.SelectedIndex = 0
            cbxPayMethod.SelectedIndex = 0
            txtBasicRate.Text = "0.00"
            txtRegOT_rate.Text = "1.25"
            txtSunOT_rate.Text = "1.5"
            txtHolOT_rate.Text = "2"
            txtPersonalLoan.Text = "0"
            txtSSS_Loan.Text = "0"
            dtpBirthDate.Value = Now()
            dtpDateHired.Value = Now()

            checkWTax.Checked = False
            checkSSS.Checked = False
            checkPhilHealth.Checked = False
            checkPAGIBIG.Checked = False

            TabControlMain.SelectedIndex = 0
            Application.DoEvents()
            txtLN.Focus()
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try

    End Sub

    'Represent current user information
    Protected Overrides Sub representPrimeInfo()
        Try
            If bindSource.Current Is Nothing Then
                writeStatus("No record found.")
                Return
            End If
            cbxGender.SelectedItem = cbxGender.ValueMember
            cbxCivilStatus.SelectedItem = cbxCivilStatus.ValueMember
            cbxStatus.SelectedItem = cbxStatus.ValueMember
            cbxPayMethod.SelectedItem = cbxPayMethod.ValueMember

            controlConcealer()
            FormatEmpNum()
        Catch appex As MyApplicationException
            writeStatus(appex.Message)
        End Try

    End Sub

    Protected Overrides Sub positionChanged() Handles bindSource.PositionChanged, bindSource.ListChanged
        If isPrimeBound Then
            representPrimeInfo()
            Dim boundSource_PKey As UInteger = getBoundSource_PKey()
            EmpProjectUC1.filterByEmployee(boundSource_PKey, String.Format("PROJECTS OF: {0} {1}", _
                                                                           _txtFN.Text, txtLN.Text), _
                                                                       cbxPayMethod.SelectedItem.ToString)
            AllowanceUC1.filterByEmployee(boundSource_PKey)
            OtherDeductionUC1.filterByEmployee(boundSource_PKey)
            BonusUC1.filterByEmployee(boundSource_PKey)
            'Enable/Disable some of the controls
            If bindSource.Current Is Nothing Then
                EmpProjectUC1.Enabled = False
                TabCtrlMisc.Enabled = False
            Else
                EmpProjectUC1.Enabled = True
                TabCtrlMisc.Enabled = True
            End If
            writeStatus("Ready")
        End If

    End Sub

    'NOTE: The arrangement of methods in state subs are important
    Protected Overrides Sub idleState()
        writeStatus("Ready")
        If Not isPrimeBound Then bindMyControls()
        'Set controls
        boundedControls_readOnly(True)
        commandButtonsVisible(False)
        hideTabPageDisabler()
        'ENABLE SOME OF THE CONTROLS
        BindingNavigatorMain.Enabled = True
        Emp_QuickSearchUC1.Enabled = True
    End Sub

    Protected Overrides Sub addingState()
        writeStatus("Adding new employee.")
        'Unbound controls
        If isPrimeBound Then unboundMyControls()
        'Set controls
        boundedControls_readOnly(False)
        commandButtonsVisible(True)
        addingState_DefaultControls()
        showTabPageDisabler(TabControlMain.SelectedTab.Tag.ToString())
        'DISALBE SOME OF THE CONTROLS
        BindingNavigatorMain.Enabled = False
        Emp_QuickSearchUC1.Enabled = False
    End Sub

    Protected Overrides Sub modifyingState()
        writeStatus("Modifying an employee record.")
        'Unbound controls
        If isPrimeBound Then unboundMyControls()
        'Set controls
        boundedControls_readOnly(False)
        commandButtonsVisible(True)
        showTabPageDisabler(TabControlMain.SelectedTab.Tag.ToString())
        'DISALBE SOME OF THE CONTROLS
        BindingNavigatorMain.Enabled = False
        Emp_QuickSearchUC1.Enabled = False
        AdminControlsHandler()
    End Sub

    Protected Overrides Sub addNewPrime()
        Try
            'Get the Salary info to complete the data to be inserted
            getSalaryInfo()

            Dim em As New EmployeeManager
            g_newEmp = em.add(g_emp)

            Dim msg As String = String.Format("'{0} {1}' was added successfully.", g_newEmp.firstName, g_newEmp.lastName)
            RaiseEvent evPerformedDBOperation(DB_Operation.Create)

            writeStatus(msg)
            MyMessageBox.success_customMessage(msg)
        Catch appex As MyApplicationException
            writeStatus(appex.Message)
            MyMessageBox.error_customMessage(appex.Message)
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            writeStatus(AddErrorMsg())
            MyMessageBox.error_customMessage(AddErrorMsg())
        End Try

    End Sub

    Protected Overrides Sub updatePrime()
        Try
            Dim em As New EmployeeManager
            Select Case TabControlMain.SelectedIndex
                Case 0
                    getPersonalInfo()
                    em.updatePersonalInfo(g_emp)
                Case 1
                    getSalaryInfo()
                    em.updateSalaryInfo(g_emp)
            End Select

            RaiseEvent evPerformedDBOperation(DB_Operation.Update)
            Dim msg As String = "Updating employee successful."
            writeStatus(msg)
            MyMessageBox.success_customMessage(msg)
        Catch appex As MyApplicationException
            writeStatus(appex.Message)
            MyMessageBox.error_customMessage(appex.Message)
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            writeStatus(ModifyErrorMsg())
            MyMessageBox.error_customMessage(ModifyErrorMsg())
        End Try

    End Sub

    Protected Overrides Sub addingSuccess()
        'Add new user to the underlying data source
        Try
            Dim newRow = CType(bindSource.AddNew, DataRowView)
            With g_emp
                newRow("empNum") = .empNum
                ''Personal Info
                newRow("firstName") = .firstName
                newRow("lastName") = .lastName
                newRow("middleName") = .middleName
                newRow("gender") = .gender
                newRow("birthDate") = .birthDate
                newRow("address") = .address
                newRow("city") = .city
                newRow("contactNum") = .contactNum
                newRow("email") = .email
                newRow("SSS_num") = .SSS_Num
                newRow("TIN_num") = .TIN_Num
                newRow("philHealth_num") = .philHealth_Num
                newRow("PAGIBIG_num") = .PAGIBIG_Num
                newRow("PRC_num") = .PRC_Num
                'newRow("photo")
                newRow("status") = .status
                newRow("dateHired") = .dateHired

                ''Salary Info
                newRow("civilStatus") = .civilStat
                newRow("numOfDependent") = .numOfDependents

                newRow("payMethod") = .payMethod
                newRow("basicRate") = .basicRate
                newRow("regOT_rate") = .regOt_rate
                newRow("sunOT_rate") = .sunOt_rate
                newRow("holOT_rate") = .holOt_rate
                newRow("personalLoan") = .personalLoan
                newRow("SSS_Loan") = .SSS_Loan
                newRow("WTax_isDeduct") = .WTax_isDeduct
                newRow("SSS_isDeduct") = .SSS_isDeduct
                newRow("philHealth_isDeduct") = .philHealth_isDeduct
                newRow("PAGIBIG_isDeduct") = .PAGIBIG_isDeduct
            End With
            bindSource.EndEdit()

            Emp_QuickSearchUC1.refill_autoComplete()
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Protected Overrides Sub modifyingSuccess()
        'Update user from the underlying data source
        Try
            If bindSource.Current Is Nothing Then
                Return
            End If
            Dim currentRow = CType(bindSource.Current, DataRowView)
            currentRow.BeginEdit()
            With g_emp
                If TabControlMain.SelectedTab Is TabPagePersonal Then
                    currentRow("empNum") = .empNum
                    ''Personal Info
                    currentRow("firstName") = .firstName
                    currentRow("lastName") = .lastName
                    currentRow("middleName") = .middleName
                    currentRow("gender") = .gender
                    currentRow("birthDate") = .birthDate
                    currentRow("address") = .address
                    currentRow("city") = .city
                    currentRow("contactNum") = .contactNum
                    currentRow("email") = .email
                    currentRow("SSS_num") = .SSS_Num
                    currentRow("TIN_num") = .TIN_Num
                    currentRow("philHealth_num") = .philHealth_Num
                    currentRow("PAGIBIG_num") = .PAGIBIG_Num
                    currentRow("PRC_num") = .PRC_Num
                    'currentRow("photo")
                    currentRow("status") = .status
                    currentRow("dateHired") = .dateHired
                    currentRow("civilStatus") = .civilStat

                ElseIf TabControlMain.SelectedTab Is TabPageSalary Then
                    ''Salary Info
                    currentRow("numOfDependent") = .numOfDependents
                    currentRow("payMethod") = .payMethod
                    currentRow("basicRate") = .basicRate
                    currentRow("regOT_rate") = .regOt_rate
                    currentRow("sunOT_rate") = .sunOt_rate
                    currentRow("holOT_rate") = .holOt_rate
                    currentRow("personalLoan") = .personalLoan
                    currentRow("SSS_Loan") = .SSS_Loan
                    currentRow("WTax_isDeduct") = .WTax_isDeduct
                    currentRow("SSS_isDeduct") = .SSS_isDeduct
                    currentRow("philHealth_isDeduct") = .philHealth_isDeduct
                    currentRow("PAGIBIG_isDeduct") = .PAGIBIG_isDeduct
                End If
            End With
            currentRow.EndEdit()

            Emp_QuickSearchUC1.refill_autoComplete()
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Protected Overrides Function getBoundSource_PKey() As UInt32
        Try
            If Not bindSource.Current Is Nothing Then
                Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
                Return CUInt(DBNullToNumeric(drv("empNum")))
            End If
        Catch ex As Exception
            'Do Nothing
            DataAccess.Bugs_DAO.log(ex)
        End Try
        Return 0
    End Function
#End Region

    Private Sub TabControlMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlMain.SelectedIndexChanged
        If TabControlMain.SelectedTab Is TabPagePersonal Or _
        TabControlMain.SelectedTab Is TabPageSalary Then
            tsbtnEdit.Enabled = True
        Else
            tsbtnEdit.Enabled = False
        End If
    End Sub

    Private Sub Numeric_TextBox_KeyPress(ByVal sender As Object, ByVal e As  _
                                 System.Windows.Forms.KeyPressEventArgs) _
                                 Handles txtBasicRate.KeyPress, txtRegOT_rate.KeyPress, txtSunOT_rate.KeyPress, _
                                 txtHolOT_rate.KeyPress, txtPersonalLoan.KeyPress, txtSSS_Loan.KeyPress

        If (Char.IsDigit(e.KeyChar) = False AndAlso Char.IsControl(e.KeyChar) = _
            False) Then
            e.Handled = True
        End If

        If CType(sender, TextBox).Text.Contains(".") = False Then
            If e.KeyChar = CChar(".") Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub Num_TextBox_KeyPress(ByVal sender As Object, ByVal e As  _
                                 System.Windows.Forms.KeyPressEventArgs) _
                                 Handles txtNumOfDependents.KeyPress

        If (Char.IsDigit(e.KeyChar) = False AndAlso Char.IsControl(e.KeyChar) = _
            False) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tsbtnPayroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles tsbtnPayroll.Click
        payroll = New frmCreatePayroll(CType(bindSource.Current, DataRowView))
        payroll.ShowDialog()
    End Sub

    Private Sub projectState_changed(ByVal formState As FormState) Handles EmpProjectUC1.evStateChange
        Select Case formState
            Case CrossCutting_Mod.FormState.Idle
                Emp_QuickSearchUC1.Enabled = True
                BindingNavigatorMain.Enabled = True
                hideTabPageDisabler()
            Case CrossCutting_Mod.FormState.Adding
                Emp_QuickSearchUC1.Enabled = False
                BindingNavigatorMain.Enabled = False
                showTabPageDisabler("Adding a new Project")
            Case CrossCutting_Mod.FormState.Modifying
                Emp_QuickSearchUC1.Enabled = False
                BindingNavigatorMain.Enabled = False
                showTabPageDisabler("Modifying an existing Project")
        End Select
    End Sub
End Class