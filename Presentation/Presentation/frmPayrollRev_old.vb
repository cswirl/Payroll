Imports CrossCutting
Imports BusinessLogic
Imports BusinessLogic.BusinessEntity
Imports DataAccess

Public Class frmPayrollRev_old
    Public Event evPayrollReversed()
    Public Event evState_changed(ByVal myState As MyState)

    Private dtProject As DataTable
    Private dtBonus As DataTable
    Private dtAllowance As DataTable
    Private dtOtherDed As DataTable
    Private WithEvents bsProject As New BindingSource

    Private emp As Employee
    Private payroll As Payroll

    Private _myState As New MyState

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bsProject = New BindingSource
        initializeMyComponent()
    End Sub

    Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExit.Click
        Me.Close()
    End Sub

    Private Sub tstxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tstxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            tsBtnGo.PerformClick()
        End If
    End Sub

    Private Sub tstxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtSearch.KeyPress
        If (Char.IsDigit(e.KeyChar) = False AndAlso Char.IsControl(e.KeyChar) = _
            False) Then
            e.Handled = True
        End If
    End Sub

    Private Sub initializeMyComponent()
        Try
            initializeDataGridViews()
            initializeDataSourcesToFilter()
            bindMyControls()
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub initializeDataGridViews()
        dgvProject_Format()
        dgvAllowance_Format()
        dgvBonus_Format()
        dgvDeduction_Format()
    End Sub

    Private Sub initializeDataSourcesToFilter()
        Try
            'Initialize the bsProject
            getProjects(0)
            'getDataSources()
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while initializing datasources to filter")
            Throw ex
        End Try
    End Sub

    Private Sub bindMyControls()
        Try
            If Not bsProject Is Nothing And bsProject.DataSource IsNot Nothing Then
                txtWorkdays.DataBindings.Add("text", bsProject, "workDays")
                txtRegOT_hrs.DataBindings.Add("text", bsProject, "regOT_hrs")
                txtSunOT_hrs.DataBindings.Add("text", bsProject, "sunOT_hrs")
                txtHolOT_hrs.DataBindings.Add("text", bsProject, "holOT_hrs")
            End If
        Catch ex As Exception
            'DISABLE SOME OF THE CONTROLS TO SUPPRESS ERRORS
            writeStatus("An error occured while binding the data to the data source.")
        End Try
    End Sub

    'Private Sub filterDataSources()
    '    Try
    '        Dim proj_ID As UInteger = 0
    '        If bsProject.Current IsNot Nothing Then
    '            proj_ID = CUInt(CType(bsProject.Current, DataRowView)("project_ID"))
    '        End If

    '        If dtAllowance IsNot Nothing Then
    '            dtAllowance.RowFilter = "project_ID = " & proj_ID
    '            lblRecordCount_Allowance.Text = dtAllowance.Count & " records found"
    '        End If
    '        dgvAllowance.Columns("pKey").Visible = False

    '        If dtOtherDed IsNot Nothing Then
    '            dtOtherDed.RowFilter = "project_ID = " & proj_ID
    '            lblRecordCount_Deduction.Text = dtOtherDed.Count & " records found"
    '        End If
    '        dgvOtherDeduction.Columns("ID").Visible = False

    '    Catch ex As Exception
    '        writeStatus("Error while filtering data sources")
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub findPayroll(ByVal payrollNumber As UInteger) 'Handles empChooser.evEmployeeSelected
        Try
            setPayroll(payrollNumber)
            If payroll Is Nothing OrElse payroll.payrollNum < 1 Then
                preparing_State()
                writeStatus("No match found for Payroll Number : " & payrollNumber)
                Return
            End If
            setEmployeeInfo(payrollNumber)
            setBonus(payrollNumber)
            setOtherDeduction(payrollNumber)
            getProjects(payrollNumber)
            setAllowance(payrollNumber)
            'filterDataSources()
            setPayrollSummary()

            writeStatus("Ready to reverse payroll.")
            ready_To_Reverse_State()
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub fillTextBoxes()
        With payroll
            txtFrom.Text = .payFrom
            txtTo.Text = .payTo
            ''
            txtWtax.Text = .wTax().ToString("0.00")
            txtSSS.Text = .SSS.ToString("0.00")
            txtPhilHealth.Text = .philHealth.ToString("0.00")
            txtPAGIBIG.Text = .PAGIBIG().ToString("0.00")
            txtSSS_Loan.Text = .SSS_Loan.ToString("0.00")
            txtPersonalLoan.Text = .personalLoan.ToString("0.00")
            txtGross_total.Text = .grossPay().ToString("0.00")
            txtNetIncome.Text = .netPay.ToString("0.00")
            ''
            If .payrollNum > 0 Then
                txtPayrollNum.Text = .payrollNum
            Else
                txtPayrollNum.Clear()
            End If
        End With
    End Sub

    Private Sub setPayroll(ByVal payrollNumber As UInteger)
        Dim pam As New PayrollManager
        Dim dtPayroll As DataTable
        Try
            dtPayroll = pam.retrieveByPayrollNum(payrollNumber, False)
            payroll = New Payroll
            If dtPayroll.Rows.Count < 1 Then
                payroll.payrollNum = 0
                Return
            End If
            Dim drv As DataRowView = dtPayroll.DefaultView.Item(0)

            With payroll
                .payrollNum = CUInt(DBNullToNumeric(drv("payrollNum")))
                .payFrom = CDate(DBNullToString(drv("payFrom")))
                .payTo = CDate(DBNullToString(drv("payTo")))
                .civilStat = DBNullToString(drv("civilStat"))
                .numofDependent = CShort(DBNullToNumeric(drv("numOfDependent")))
                .tp_status = DBNullToString(drv("tp_status"))
                .payMethod = DBNullToString(drv("payMethod"))
                .basicRate = CDbl(DBNullToNumeric(drv("basicRate")))
                .regOT_rate = CSng(DBNullToNumeric(drv("regOT_rate")))
                .sunOT_rate = CSng(DBNullToNumeric(drv("sunOT_rate")))
                .holOT_rate = CSng(DBNullToNumeric(drv("holOT_rate")))
                ''
                .wTax = CDbl(DBNullToNumeric(drv("wTax")))
                .SSS = CDbl(DBNullToNumeric(drv("SSS")))
                .philHealth = CDbl(DBNullToNumeric(drv("philHealth")))
                .PAGIBIG = CDbl(DBNullToNumeric(drv("PAGIBIG")))
                .SSS_Loan = CDbl(DBNullToNumeric(drv("SSS_Loan")))
                .personalLoan = CDbl(DBNullToNumeric(drv("personalLoan")))
                .grossPay = CDbl(DBNullToNumeric(drv("grossPay")))
                .netPay = CDbl(DBNullToNumeric(drv("netPay")))
                .createdBy = CUInt(DBNullToNumeric(drv("createdBy")))
            End With

            fillTextBoxes()
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting payroll information")
            Throw ex
        End Try
    End Sub

    Private Sub setEmployeeInfo(ByVal payrollNum As UInteger)
        Dim pam As New PayrollManager
        Dim em As New EmployeeManager
        Dim dtEmployee As DataTable
        Try
            dtEmployee = em.retrieveByEmpNum(pam.getEmpNum(payrollNum))
            Dim drv As DataRowView = dtEmployee.DefaultView.Item(0)

            emp = New Employee
            emp.empNum = CUInt(DBNullToNumeric(drv("empNum")))
            emp.dateHired = CDate(DBNullToString(drv("dateHired")))

            If emp.empNum > 0 Then
                txtEmpNum.Text = emp.getFormattedEmpNum
                txtFullName.Text = String.Format("{0} {1}", CStr(drv("firstName")), CStr(drv("lastName")))
            Else
                txtEmpNum.Clear()
                txtFullName.Clear()
            End If

        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting employee information")
            Throw ex
        End Try
    End Sub

    Private Sub setBonus(ByVal payrollNum As UInteger)
        Try
            Dim bu As New BonusUtility
            dtBonus = bu.retrieveByPayrollNum(payrollNum)
            dgvBonus.Columns("ID").Visible = False

            Dim recordCount As Integer = 0
            Dim bonus_total As Double = 0.0
            If dtBonus IsNot Nothing Then
                recordCount = DBNullToNumeric(dtBonus.Rows.Count)
                bonus_total = CDbl(DBNullToNumeric(dtBonus.Compute("SUM(amount)", "")))
            End If
            lblRecordCount_Bonus.Text = recordCount & " records found"
            txtBonus_Total.Text = bonus_total.ToString("0.00")

            dgvBonus.DataSource = dtBonus
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting bonus total.")
            Throw ex
        End Try
    End Sub

    Private Sub setAllowance(ByVal payrollNum As UInteger)
        Try
            Dim au As New AllowanceUtility
            dtAllowance = au.retrieveProcessedByPayrollNum(payrollNum)
            dgvAllowance.Columns("allowanceNum").Visible = False

            Dim recordCount As Integer = 0
            If dtAllowance IsNot Nothing Then
                recordCount = DBNullToNumeric(dtAllowance.Rows.Count)
            End If
            lblRecordCount_Allowance.Text = recordCount & " records found"

            'Allowance total
            Dim workdays As Integer = CDbl(DBNullToNumeric(dtProject.Compute("SUM(workdays)", "")))
            Dim nonTax_allowance As Double = 0.0
            nonTax_allowance = au.getTotalForReversal(payrollNum, False) * workdays
            txtAllowTotal_nonTax.Text = nonTax_allowance.ToString("0.00")

            Dim taxable_allowance As Double
            taxable_allowance = au.getTotalForReversal(payrollNum, True) * workdays
            txtAllowTotal_taxable.Text = taxable_allowance.ToString("0.00")

            dgvAllowance.DataSource = dtAllowance
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting allowance.")
            Throw ex
        End Try
    End Sub

    Private Sub setOtherDeduction(ByVal payrollNumber As UInteger)
        Try
            Dim od As New OtherDeductionUtility
            dtOtherDed = od.retrieveSettledByPayrollNum(payrollNumber)
            dgvOtherDeduction.Columns("ID").Visible = False

            Dim recordCount As Integer = 0
            Dim otherDed_total As Double = 0.0
            If dtOtherDed IsNot Nothing Then
                recordCount = DBNullToNumeric(dtOtherDed.Rows.Count)
                otherDed_total = CDbl(DBNullToNumeric(dtOtherDed.Compute("SUM(amount)", "")))
            End If
            lblRecordCount_OtherDed.Text = recordCount & " records found"
            'Other Deduction total
            txtOtherDed_total.Text = otherDed_total.ToString("0.00")

            dgvOtherDeduction.DataSource = dtOtherDed
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting 'Other Deduction'.")
            Throw ex
        End Try
    End Sub

    Private Sub getProjects(ByVal payrollNum As UInteger)
        Dim pm As New ProjectManager
        Try
            If bsProject Is Nothing Then bsProject = New BindingSource
            dtProject = pm.retrieveForReversal(payrollNum)
            bsProject.DataSource = dtProject
            dgvProject.DataSource = bsProject
            dgvProject_Format()
            dgvProject.Columns("project_ID").Visible = False
            lblRecordCount_Project.Text = bsProject.Count & " records found"
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub setPayrollSummary()
        Try
            setGross()
            setTotalDeduction()
            setNetIncome()
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting Payroll Summary.")
            Throw ex
        End Try
    End Sub

    Private Sub setGross()
        Dim dtWorkAndOTs As DataTable
        Dim workdays_tot, regOT_tot, sunOT_tot, holOT_tot As Double

        Dim pm As New ProjectManager
        Dim au As New AllowanceUtility
        dtWorkAndOTs = pm.getWorkdaysAndOTsForReversal(payroll.payrollNum)
        'Get Workdays and OTs total hours
        Dim workDays As Integer = CInt(DBNullToNumeric(dtWorkAndOTs.Rows(0)("workDays")))
        Dim regOT_hrs As Integer = CInt(DBNullToNumeric(dtWorkAndOTs.Rows(0)("regOT_hrs")))
        Dim sunOT_hrs As Integer = CInt(DBNullToNumeric(dtWorkAndOTs.Rows(0)("sunOT_hrs")))
        Dim holOT_hrs As Integer = CInt(DBNullToNumeric(dtWorkAndOTs.Rows(0)("holOT_hrs")))

        'Set totals
        Dim ratePerHour As Double = PayrollManager.getBasicRatePerHour(payroll.payMethod, payroll.basicRate)

        workdays_tot = PayrollManager.getWorkdays_total(payroll.payMethod, payroll.basicRate, workDays)
        regOT_tot = CDbl((ratePerHour * payroll.regOT_rate) * regOT_hrs)
        sunOT_tot = CDbl((ratePerHour * payroll.sunOT_rate) * sunOT_hrs)
        holOT_tot = CDbl((ratePerHour * payroll.holOT_rate) * holOT_hrs)

        'What about the allowances?
        Dim income As Double = workdays_tot + regOT_tot + sunOT_tot + holOT_tot
        Dim gross As Double = income + CDbl(DBNullToNumeric(txtAllowTotal_taxable.Text))
        txtTotalIncome.Text = income.ToString("0.00")
        txtGross.Text = gross.ToString("0.00")
        txtGross_total.Text = gross.ToString("0.00")
    End Sub

    Private Sub setTotalDeduction()
        Dim totalDeduction As Double

        Dim otherDed As Double = CDbl(DBNullToNumeric(txtOtherDed_total.Text))
        Dim wtax As Double = CDbl(DBNullToNumeric(txtWtax.Text))
        Dim sss As Double = CDbl(DBNullToNumeric(txtSSS.Text))
        Dim philHealth As Double = CDbl(DBNullToNumeric(txtPhilHealth.Text))
        Dim PAGIBIG As Double = CDbl(DBNullToNumeric(txtPAGIBIG.Text))
        Dim sss_loan As Double = CDbl(DBNullToNumeric(txtSSS_Loan.Text))
        Dim personalLoan As Double = CDbl(DBNullToNumeric(txtPersonalLoan.Text))

        totalDeduction = otherDed + wtax + sss + philHealth + PAGIBIG + sss_loan + personalLoan
        txtTotalDeduction.Text = totalDeduction.ToString("0.00")
        txtDeduction_total.Text = txtTotalDeduction.Text
    End Sub

    Private Sub setNetIncome()
        Dim gross As Double = CDbl(DBNullToNumeric(txtGross_total.Text))
        Dim deductions As Double = CDbl(DBNullToNumeric(txtDeduction_total.Text))
        Dim allow_total As Double = CDbl(DBNullToNumeric(txtAllowTotal_nonTax.Text))
        Dim bonus_total As Double = CDbl(DBNullToNumeric(txtBonus_Total.Text))

        Dim net As Double = (gross - deductions) + allow_total + bonus_total
        txtNetIncome.Text = net.ToString("0.00")
    End Sub

    Private Sub bsProject_positionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsProject.PositionChanged, bsProject.DataSourceChanged
        If payroll IsNot Nothing Then
            getWorkdaysAndOTsPerProject()
        End If
    End Sub

    Private Sub getWorkdaysAndOTsPerProject()
        Try
            If bsProject.Current IsNot Nothing Then
                Dim workdays_tot, regOT_tot, sunOT_tot, holOT_tot As Double

                'Get Workdays and OTs total
                Dim drv As DataRowView = CType(bsProject.Current, DataRowView)
                Dim workDays As Integer = CInt(drv("workDays"))
                Dim regOT_hrs As Integer = CInt(drv("regOT_hrs"))
                Dim sunOT_hrs As Integer = CInt(drv("sunOT_hrs"))
                Dim holOT_hrs As Integer = CInt(drv("holOT_hrs"))

                'Set workdays
                workdays_tot = PayrollManager.getWorkdays_total(payroll.payMethod, payroll.basicRate, workDays)

                Dim ratePerHour As Double = PayrollManager.getBasicRatePerHour(payroll.payMethod, payroll.basicRate)

                'Use of workdays is for Daily earners only?
                regOT_tot = CDbl((ratePerHour * payroll.regOT_rate) * regOT_hrs)
                sunOT_tot = CDbl((ratePerHour * payroll.sunOT_rate) * sunOT_hrs)
                holOT_tot = CDbl((ratePerHour * payroll.holOT_rate) * holOT_hrs)

                txtWorkdays_total.Text = workdays_tot.ToString("0.00")
                txtRegOT_total.Text = regOT_tot.ToString("0.00")
                txtSunOT_total.Text = sunOT_tot.ToString("0.00")
                txtHolOT_total.Text = holOT_tot.ToString("0.00")

                Dim workdaysAndOTs As Double = workdays_tot + _
                regOT_tot + sunOT_tot + holOT_tot
                txtWorkdaysAndOTs_Tot.Text = workdaysAndOTs.ToString("0.00")
            Else
                'if no project is returned, do this
                txtWorkdays_total.Text = "0.00"
                txtRegOT_total.Text = "0.00"
                txtSunOT_total.Text = "0.00"
                txtHolOT_total.Text = "0.00"
                txtWorkdaysAndOTs_Tot.Text = "0.00"
            End If
        Catch icex As InvalidCastException
            MyMessageBox.invalidDataType()
        Catch ofex As OverflowException
            MyMessageBox.error_customMessage("An Overflow occured. Please verify your input.")
        Catch appex As MyApplicationException
            MyMessageBox.error_customMessage(appex.Message)
        Catch bex As BusinessException
            MyMessageBox.error_customMessage(bex.Message)
        Catch ex As Exception
            MyMessageBox.error_generalInput()
        End Try
    End Sub

    Private Sub reverse()
        Try
            Select Case _myState
                Case MyState.Preparing
                    MsgBox("Payroll Reversal cannot proceed without valid payroll number.", MsgBoxStyle.OkOnly, "")
                    writeStatus("Payroll Reversal cannot proceed without valid payroll number.")
                Case MyState.Ready_To_Reverse
                    If reversalConfirmed() Then
                        Dim pam As New PayrollManager
                        payroll.payrollNum = pam.reverse(payroll.payrollNum)
                        writeStatus("Payroll Reversal is done successfully.")
                        Messages.SuccessMessage("Payroll Reversal is done successfully.")
                        reversal_Completed_State()
                    End If
                Case MyState.Reversal_Completed
                    preparing_State()
                    tstxtSearch.Enabled = True
                    tsBtnGo.Enabled = True
                    tstxtSearch.Clear()
                    tstxtSearch.Focus()
            End Select
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            writeStatus("An error occur while reversing a payroll.")
            MyMessageBox.error_customMessage("An error occur while reversing a payroll.")
        End Try
    End Sub

    Private Sub writeStatus(ByVal message As String)
        tslblMessage.Text = message
    End Sub

#Region "DataGridViews Format"
    Private Sub dgvProject_Format()
        With dgvProject
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionForeColor = Color.Blue
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .MultiSelect = False
            .Font = New Font(New FontFamily("tahoma"), 9, FontStyle.Regular)
            .Columns.Clear()
            Dim ColumnProject_ID As New DataGridViewTextBoxColumn
            With ColumnProject_ID
                .DataPropertyName = "project_ID"
                .Name = "project_ID"
                .HeaderText = "Project ID"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 100
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnProject_ID)

            Dim ColumnName As New DataGridViewTextBoxColumn()
            With ColumnName
                .DataPropertyName = "name"
                .Name = "name"
                .HeaderText = "Project"
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 175
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnName)

            Dim ColumnDivision As New DataGridViewTextBoxColumn()
            With ColumnDivision
                .DataPropertyName = "division"
                .Name = "division"
                .HeaderText = "Division"
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 175
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnDivision)

            Dim ColumnPosition As New DataGridViewTextBoxColumn
            With ColumnPosition
                .DataPropertyName = "position"
                .Name = "position"
                .HeaderText = "Position"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 175
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnPosition)

            Dim ColumnWorkdays As New DataGridViewTextBoxColumn
            With ColumnWorkdays
                .DataPropertyName = "workDays"
                .Name = "workDays"
                .HeaderText = "Workdays"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 75
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnWorkdays)

            Dim ColumnRegOT_hrs As New DataGridViewTextBoxColumn
            With ColumnRegOT_hrs
                .DataPropertyName = "regOT_hrs"
                .Name = "regOT_hrs"
                .HeaderText = "RegOT Hrs"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 75
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnRegOT_hrs)

            Dim ColumnSunOT_hrs As New DataGridViewTextBoxColumn
            With ColumnSunOT_hrs
                .DataPropertyName = "sunOT_hrs"
                .Name = "sunOT_hrs"
                .HeaderText = "SunOT Hrs"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 75
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnSunOT_hrs)

            Dim ColumnHolOT_hrs As New DataGridViewTextBoxColumn
            With ColumnHolOT_hrs
                .DataPropertyName = "holOT_hrs"
                .Name = "holOT_hrs"
                .HeaderText = "HolOT Hrs"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 75
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnHolOT_hrs)

        End With
    End Sub

    Private Sub dgvAllowance_Format()
        With dgvAllowance
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .ReadOnly = True
            .MultiSelect = False
            .Font = New Font(New FontFamily("tahoma"), 9, FontStyle.Regular)
            .Columns.Clear()
            Dim ColumnID As New DataGridViewTextBoxColumn
            With ColumnID
                .DataPropertyName = "allowanceNum"
                .Name = "allowanceNum"
                .HeaderText = "Seq #"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 60
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnID)

            Dim ColumnEmpNum As New DataGridViewTextBoxColumn
            With ColumnEmpNum
                .DataPropertyName = "empNum"
                .Name = "empNum"
                .HeaderText = "empNum"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 60
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnEmpNum)

            Dim ColumnName As New DataGridViewTextBoxColumn
            With ColumnName
                .DataPropertyName = "name"
                .Name = "name"
                .HeaderText = "Allowance"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 120
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnName)

            Dim ColumnAmount As New DataGridViewTextBoxColumn
            With ColumnAmount
                .DataPropertyName = "amount"
                .Name = "amount"
                .HeaderText = "Amount"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 80
                .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnAmount)

            Dim ColumnTaxable As New DataGridViewCheckBoxColumn()
            With ColumnTaxable
                .DataPropertyName = "taxable"
                .Name = "taxable"
                .HeaderText = "Taxable"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .FlatStyle = FlatStyle.Standard
                .CellTemplate = New DataGridViewCheckBoxCell()
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 60
            End With
            .Columns.Add(ColumnTaxable)
        End With
    End Sub

    Private Sub dgvDeduction_Format()
        With dgvOtherDeduction
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .ReadOnly = True
            .MultiSelect = False
            .Font = New Font(New FontFamily("tahoma"), 9, FontStyle.Regular)
            .Columns.Clear()
            Dim ColumnID As New DataGridViewTextBoxColumn
            With ColumnID
                .DataPropertyName = "ID"
                .Name = "ID"
                .HeaderText = "Seq #"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 60
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnID)

            Dim ColumnEmpNum As New DataGridViewTextBoxColumn
            With ColumnEmpNum
                .DataPropertyName = "empNum"
                .Name = "empNum"
                .HeaderText = "empNum"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 60
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnEmpNum)

            Dim ColumnName As New DataGridViewTextBoxColumn
            With ColumnName
                .DataPropertyName = "name"
                .Name = "name"
                .HeaderText = "Deduction"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 150
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnName)

            Dim ColumnAmount As New DataGridViewTextBoxColumn
            With ColumnAmount
                .DataPropertyName = "amount"
                .Name = "amount"
                .HeaderText = "Amount"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 110
                .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnAmount)
        End With
    End Sub

    Private Sub dgvBonus_Format()
        With dgvBonus
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .ReadOnly = True
            .MultiSelect = False
            .Font = New Font(New FontFamily("tahoma"), 9, FontStyle.Regular)
            .Columns.Clear()
            Dim ColumnID As New DataGridViewTextBoxColumn
            With ColumnID
                .DataPropertyName = "ID"
                .Name = "ID"
                .HeaderText = "Seq #"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 60
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnID)

            Dim ColumnProjectID As New DataGridViewTextBoxColumn
            With ColumnProjectID
                .DataPropertyName = "empNum"
                .Name = "empNum"
                .HeaderText = "Employee Number"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 60
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnProjectID)

            Dim ColumnName As New DataGridViewTextBoxColumn
            With ColumnName
                .DataPropertyName = "name"
                .Name = "name"
                .HeaderText = "Bonus"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 150
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnName)

            Dim ColumnAmount As New DataGridViewTextBoxColumn
            With ColumnAmount
                .DataPropertyName = "amount"
                .Name = "amount"
                .HeaderText = "Amount"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 110
                .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnAmount)
        End With
    End Sub
#End Region

    Private Sub tsBtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnGo.Click
        Try
            'NUM and STR
            findPayroll(CUInt(DBNullToNumeric(tstxtSearch.Text)))
        Catch icex As InvalidCastException
            MyMessageBox.invalidDataType()
        Catch ofex As OverflowException
            MyMessageBox.outOfRange(UInteger.MaxValue)
        Catch bex As BusinessException
            MyMessageBox.error_customMessage(bex.Message)
        Catch ex As Exception
            MyMessageBox.error_generalInput()
        End Try
    End Sub

    Private Sub setControlsToDefault()
        ''DataSources
        If dtProject IsNot Nothing Then dtProject.Clear()
        If dtBonus IsNot Nothing Then dtBonus.Clear()
        If dtAllowance IsNot Nothing Then dtAllowance.Clear()
        If dtOtherDed IsNot Nothing Then dtOtherDed.Clear()
        ''Textboxes
        txtPayrollNum.Clear()
        txtFrom.Clear()
        txtTo.Clear()
        txtEmpNum.Clear()
        txtFullName.Clear()
        txtWorkdays_total.Clear()
        txtRegOT_total.Clear()
        txtSunOT_total.Clear()
        txtHolOT_total.Clear()
        txtWorkdaysAndOTs_Tot.Clear()
        ''
        txtTotalIncome.Clear()
        txtAllowTotal_taxable.Clear()
        txtGross.Clear()
        ''
        txtOtherDed_total.Clear()
        txtWtax.Clear()
        txtSSS.Clear()
        txtPhilHealth.Clear()
        txtPAGIBIG.Clear()
        txtSSS_Loan.Clear()
        txtPersonalLoan.Clear()
        txtTotalDeduction.Clear()
        ''
        txtGross_total.Clear()
        txtDeduction_total.Clear()
        txtAllowTotal_nonTax.Clear()
        txtBonus_Total.Clear()
        txtNetIncome.Clear()
        ''Labels
        lblRecordCount_Project.Text = "0 records found"
        lblRecordCount_Bonus.Text = "0 records found"
    End Sub

    Private Sub stateHandler(ByVal myState As MyState) Handles Me.evState_changed
        Select Case myState
            Case MyState.Preparing
                preparing_State()
            Case MyState.Ready_To_Reverse
                ready_To_Reverse_State()
            Case MyState.Reversal_Completed
                reversal_Completed_State()
        End Select
    End Sub

    Private Sub preparing_State()
        _myState = MyState.Preparing
        writeStatus("Enter Payroll Number to reverse.")
        tsbtnReverse.Text = "&REVERSE PAYROLL"
        setControlsToDefault()
    End Sub

    Private Sub ready_To_Reverse_State()
        _myState = MyState.Ready_To_Reverse
        tsbtnReverse.Text = "&REVERSE PAYROLL"
    End Sub

    Private Sub reversal_Completed_State()
        _myState = MyState.Reversal_Completed
        tstxtSearch.Enabled = False
        tsBtnGo.Enabled = False
        tsbtnReverse.Text = "              &NEW              "
        payroll = Nothing
        RaiseEvent evPayrollReversed()
    End Sub

    Enum MyState
        Preparing
        Ready_To_Reverse
        Reversal_Completed
    End Enum

    Private Sub tsbtnReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnReverse.Click
        reverse()
    End Sub

    Private Function reversalConfirmed() As Boolean
        Dim res As DialogResult = _
        MessageBox.Show("Are you sure you want to reverse this payroll transaction?", _
                        "Reversal Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub frmPayrollRev_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            Me.Dispose()
        End If
    End Sub
End Class