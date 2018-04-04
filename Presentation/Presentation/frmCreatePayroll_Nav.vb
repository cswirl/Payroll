Imports CrossCutting
Imports BusinessLogic
Imports BusinessLogic.BusinessEntity
Imports DataAccess

Public Class frmCreatePayroll_Nav
    Private myState As PayrollState

    Private WithEvents empChooser As frmEmpChooser

    Private dtProject As DataTable
    Private dtBonus As DataTable
    Private dtAllowance As DataTable
    Private dtOtherDed As DataTable
    Private WithEvents bsProject As BindingSource

    Private emp As Employee
    Private payroll As Payroll
    Private project_Grouped As Project

    Private hadTransacted As Boolean = False

    Public Event evPayrollTransacts()
    Public Event evPersonalLoan_settled(ByVal newValue As Double)       'Deprecated
    Private Event evState_changed(ByVal state As PayrollState)

    Private _dateFrom As Date
    Private _dateTo As Date

    Private WithEvents payroll_period As frmPayroll_Period

    Sub New(ByVal dateFrom As Date, ByVal dateTo As Date)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Payroll_Period_changed(dateFrom, dateTo)

        bsProject = New BindingSource
        initializeMyComponent()
    End Sub

    Public Property dateFrom() As Date
        Get
            Return _dateFrom
        End Get
        Set(ByVal value As Date)
            _dateFrom = value
        End Set
    End Property

    Public Property dateTo() As Date
        Get
            Return _dateTo
        End Get
        Set(ByVal value As Date)
            _dateTo = value
        End Set
    End Property

    Private Enum PayrollState
        Idle
        Incomplete
        Complete
    End Enum

    Private Sub initializeMyComponent()
        Try
            initializeDataGridViews()
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
            getProjectsOfEmployee(0)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while initializing datasources to filter")
            Throw ex
        End Try
    End Sub

    Private Sub employeeSelected(ByVal drv As DataRowView) Handles empChooser.evEmployeeSelected
        Try
            'The order of invoking functions here is important
            setEmployeeInfo(drv)
            setBonus()
            setOtherDeduction()
            getProjectsOfEmployee(emp.empNum)
            setProjectSummary()
            setAllowance()
            setPayrollSummary()

            RaiseEvent evState_changed(PayrollState.Incomplete)
        Catch appex As MyApplicationException
            writeStatus(appex.Message)
        Catch bex As BusinessException
            writeStatus(bex.Message)
            Bugs_DAO.log(bex)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            Bugs_DAO.log(daex)
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub setEmployeeInfo(ByVal drv As DataRowView)
        Try
            emp = New Employee
            emp.empNum = CUInt(drv("empNum"))
            emp.firstName = CStr(drv("firstName"))
            emp.lastName = CStr(drv("lastName"))
            emp.dateHired = CDate(drv("dateHired"))
            emp.civilStat = CStr(drv("civilStatus"))
            emp.numOfDependents = CStr(drv("numOfDependent"))
            emp.payMethod = CStr(drv("payMethod"))
            emp.basicRate = CDbl(drv("basicRate"))
            emp.regOt_rate = CSng(drv("regOt_rate"))
            emp.sunOt_rate = CSng(drv("sunOt_rate"))
            emp.holOt_rate = CSng(drv("holOt_rate"))
            emp.personalLoan = CDbl(DBNullToNumeric(drv("personalLoan")))
            emp.SSS_Loan = CDbl(DBNullToNumeric(drv("SSS_Loan")))
            'Deduct or Not
            emp.WTax_isDeduct = CBool(DBNullToNumeric(drv("WTax_isDeduct")))
            emp.SSS_isDeduct = CBool(DBNullToNumeric(drv("SSS_isDeduct")))
            emp.philHealth_isDeduct = CBool(DBNullToNumeric(drv("philHealth_isDeduct")))
            emp.PAGIBIG_isDeduct = CBool(DBNullToNumeric(drv("PAGIBIG_isDeduct")))

            'Set Controls
            txtEmpNum.Text = emp.getFormattedEmpNum
            txtFullName.Text = emp.fullName
            txtRegOT_rate.Text = emp.regOt_rate.ToString("0.00")
            txtSunOT_rate.Text = emp.sunOt_rate.ToString("0.00")
            txtHolOT_rate.Text = emp.holOt_rate.ToString("0.00")
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting employee information")
            Throw ex
        End Try
    End Sub

    Private Sub setBonus()
        Try
            Dim bu As New BonusUtility
            dtBonus = bu.retrieveAllForPayroll(emp.empNum)
            dgvBonus.Columns("ID").Visible = False

            Dim recordCount As Integer = 0
            Dim bonus_total As Double = 0.0
            If dtBonus IsNot Nothing Then
                recordCount = DBNullToNumeric(dtBonus.Rows.Count)
                bonus_total = CDbl(DBNullToNumeric(dtBonus.Compute("SUM(amount)", "")))
            End If
            lblRecordCount_Bonus.Text = recordCount & " records found"
            lblBonus_total.Text = "Total = " & bonus_total.ToString("0.00")
            txtBonus_Total.Text = bonus_total.ToString("0.00")

            dgvBonus.DataSource = dtBonus
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting 'Bonus'.")
            Throw ex
        End Try

    End Sub

    Private Sub setAllowance()
        Try
            Dim au As New AllowanceUtility
            dtAllowance = au.retrieveAllForPayroll(emp.empNum)
            dgvAllowance.Columns("allowanceNum").Visible = False

            Dim recordCount As Integer = 0
            If dtAllowance IsNot Nothing Then
                recordCount = DBNullToNumeric(dtAllowance.Rows.Count)
            End If
            lblRecordCount_Allowance.Text = recordCount & " records found"

            'Allowance total
            Dim workdays As Integer = CDbl(DBNullToNumeric(dtProject.Compute("SUM(workdays)", "")))
            Dim nonTaxable_allowance As Double = 0.0
            nonTaxable_allowance = au.getTotalForEmployee(emp.empNum, False) * workdays

            Dim taxable_allowance As Double
            taxable_allowance = au.getTotalForEmployee(emp.empNum, True) * workdays

            'Get total
            Dim allowance_total As Double
            allowance_total = taxable_allowance + nonTaxable_allowance
            lblAllowance_total.Text = "Total = " & allowance_total.ToString("0.00")
            txtAllowance_total.Text = allowance_total.ToString("0.00")

            dgvAllowance.DataSource = dtAllowance
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting 'Allowance'.")
            Throw ex
        End Try

    End Sub

    Private Sub setOtherDeduction()
        Try
            Dim od As New OtherDeductionUtility
            dtOtherDed = od.retrieveAllForPayroll(emp.empNum)
            dgvOtherDeduction.Columns("ID").Visible = False

            Dim recordCount As Integer = 0
            Dim otherDed_total As Double = 0.0
            If dtOtherDed IsNot Nothing Then
                recordCount = DBNullToNumeric(dtOtherDed.Rows.Count)
                otherDed_total = CDbl(DBNullToNumeric(dtOtherDed.Compute("SUM(amount)", "")))
            End If
            lblRecordCount_OtherDed.Text = recordCount & " records found"
            'Other Deduction total
            lblOtherDeduction_total.Text = "Total = " & otherDed_total.ToString("0.00")
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

    Private Function getSSS_contribution(ByVal currentRate As Double) As Double
        Dim pm As New PayrollManager
        Dim sssDAO As New SSS_DAO
        Dim sss As Double = 0.0
        Dim err_msg As String = "Error while getting SSS contribution deductables."
        Try
            If emp.payMethod.Equals("Weekly") Then
                sss = pm.getContribution_for_Weekly(emp.empNum, dateFrom, _
                                                       Payroll_DAO.Weekly_Deduction.SSS, currentRate)
            ElseIf emp.payMethod.Equals("Semi") Then
                sss = sssDAO.find_Contribution(currentRate)
                If sss > 0 Then sss /= 2
            ElseIf emp.payMethod.Equals("Monthly") Then
                sss = sssDAO.find_Contribution(currentRate)
            Else
                Throw New MyApplicationException(err_msg)
            End If
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            writeStatus(err_msg)
            Throw ex
        End Try
        Return sss
    End Function

    Private Function getPhilHealth_contribution(ByVal currentRate As Double) As Double
        Dim pm As New PayrollManager
        Dim philHealthDAO As New PhilHealth_DAO
        Dim philHealth As Double = 0.0
        Dim err_msg As String = "Error while getting PhilHealth contribution deductables."
        Try
            If emp.payMethod.Equals("Weekly") Then
                philHealth = pm.getContribution_for_Weekly(emp.empNum, dateFrom, _
                                                            Payroll_DAO.Weekly_Deduction.PhilHealth, currentRate)
            ElseIf emp.payMethod.Equals("Semi") Then
                philHealth = philHealthDAO.find_Contribution(currentRate)
                If philHealth > 0 Then philHealth /= 2
            ElseIf emp.payMethod.Equals("Monthly") Then
                philHealth = philHealthDAO.find_Contribution(currentRate)
            Else
                Throw New MyApplicationException(err_msg)
            End If
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            writeStatus(err_msg)
            Throw ex
        End Try
        Return philHealth
    End Function

    'Set SSS, Phil Health, PAGIBIG, WTax - in order
    Private Sub setDeductables()
        Try
            Dim pm As New PayrollManager
            Dim workdays_SUM As Integer = CInt(DBNullToNumeric(txtWorkdays.Text))
            Dim currentRate As Double = _
                PayrollManager.getWorkdays_total(emp.payMethod, emp.basicRate, workdays_SUM)

            'TENTATIVE
            'Find Contribution
            Dim sss, philHealth, PAGIBIG, WTax As Double

            'Find SSS Contribution
            If emp.SSS_isDeduct Then
                sss = getSSS_contribution(currentRate)
            Else
                sss = 0.0
            End If

            'Find Phil Health Contribution
            If emp.philHealth_isDeduct Then
                philHealth = getPhilHealth_contribution(currentRate)
            Else
                philHealth = 0.0
            End If

            'Find PAGIBIG Contribution
            If emp.PAGIBIG_isDeduct Then
                PAGIBIG = PayrollManager.computePAGIBIG_contribution(currentRate)
            Else
                PAGIBIG = 0.0
            End If

            'Check if SSS and PhilHealth value is somewhat acceptable
            If sss < 0 Then Throw New BusinessException("Data inconsistency had been detected. The SSS Table may be misconfigured.")
            If philHealth < 0 Then Throw New BusinessException("Data inconsistency had been detected. The PhilHealth Table may be misconfigured.")

            txtSSS.Text = sss.ToString("0.00")
            txtPhilHealth.Text = philHealth.ToString("0.00")
            txtPAGIBIG.Text = PAGIBIG.ToString("0.00")
            txtPersonalLoan.Text = emp.personalLoan.ToString("0.00")
            txtSSS_Loan.Text = emp.SSS_Loan.ToString("0.00")

            'The WTax  should be the last to compute
            If emp.WTax_isDeduct Then
                WTax = getWTax()
            Else
                WTax = 0.0
            End If
            If WTax < 0 Then Throw New BusinessException( _
                String.Format("Data inconsistency had been detected. The WTax Table for '{0}' may be misconfigured."), emp.payMethod)
            txtWtax.Text = WTax.ToString("0.00")
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            writeStatus("Error while setting deductables.")
            Throw ex
        End Try
    End Sub

    Private Function getTaxableIncome() As Double
        'Taxable Income = Gross Income - [DEDUCTABLES](SSS, PHilHealt, PAGIBIG) - NonTaxable allowance Total - Other Deduction Total
        Dim taxableIncome As Double
        Try
            'Deductables
            Dim sss As Double = CDbl(DBNullToNumeric(txtSSS.Text))
            Dim philHealth As Double = CDbl(DBNullToNumeric(txtPhilHealth.Text))
            Dim PAGIBIG As Double = CDbl(DBNullToNumeric(txtPAGIBIG.Text))
            'Non-Tax Allowance
            Dim au As New AllowanceUtility
            Dim workdays As Integer = CDbl(DBNullToNumeric(dtProject.Compute("SUM(workdays)", "")))
            Dim nonTaxable_allowance As Double = au.getTotalForEmployee(emp.empNum, False) * workdays

            Dim otherDed As Double = CDbl(DBNullToNumeric(txtOtherDed_total.Text))

            Dim less As Double = sss + philHealth + PAGIBIG + nonTaxable_allowance + otherDed
            taxableIncome = CDbl(DBNullToNumeric(txtGross.Text)) - less
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            writeStatus("Error while getting taxable income.")
            Throw ex
        End Try
        Return taxableIncome
    End Function

    Private Function getWTax() As Double
        Dim WTax As Double = 0.0
        Try
            Dim statusCode = PayrollManager.getTaxPayerStatus_pKey(emp.civilStat, emp.numOfDependents)
            Dim wtaxUtil As New WTax_Util
            WTax = wtaxUtil.generateWTax(statusCode, emp.payMethod, getTaxableIncome())
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while getting WTax.")
            Throw ex
        End Try
        Return WTax
    End Function

    Private Sub setPayrollSummary()
        Try
            setGross()
            setDeductables()
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
        Try
            txtIncome_Total_2.Text = txtIncome_Total.Text
            Dim income_total As Double = CDbl(DBNullToNumeric(txtIncome_Total.Text))
            Dim allowance_total As Double = CDbl(DBNullToNumeric(txtAllowance_total.Text))
            Dim gross As Double = income_total + allowance_total

            txtGross.Text = gross.ToString("0.00")
            txtGross_2.Text = gross.ToString("0.00")
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting Gross income.")
            Throw ex
        End Try

    End Sub

    Private Sub setTotalDeduction()
        Try
            Dim totalDeduction As Double

            Dim otherDed As Double = CDbl(DBNullToNumeric(txtOtherDed_total.Text))
            Dim wtax As Double = CDbl(DBNullToNumeric(txtWtax.Text))
            Dim sss As Double = CDbl(DBNullToNumeric(txtSSS.Text))
            Dim philHealth As Double = CDbl(DBNullToNumeric(txtPhilHealth.Text))
            Dim PAGIBIG As Double = CDbl(DBNullToNumeric(txtPAGIBIG.Text))
            Dim sss_loan As Double = CDbl(DBNullToNumeric(txtSSS_Loan.Text))
            Dim personalLoan As Double = CDbl(DBNullToNumeric(txtPersonalLoan.Text))

            totalDeduction = otherDed + wtax + sss + philHealth + PAGIBIG + sss_loan + personalLoan
            txtDeduction_total.Text = totalDeduction.ToString("0.00")
            txtDeduction_total_2.Text = txtDeduction_total.Text
        Catch ex As Exception
            writeStatus("Error while setting Total Deduction.")
            Throw ex
        End Try
    End Sub

    Private Sub setNetIncome()
        Try
            Dim gross As Double = CDbl(DBNullToNumeric(txtGross_2.Text))
            Dim deductions As Double = CDbl(DBNullToNumeric(txtDeduction_total_2.Text))
            Dim bonus_total As Double = CDbl(DBNullToNumeric(txtBonus_Total.Text))

            Dim net As Double = (gross - deductions) + bonus_total
            txtNetPay.Text = net.ToString("0.00")
        Catch ex As Exception
            writeStatus("Error while setting Net income.")
            Throw ex
        End Try
    End Sub

    Private Sub getProjectsOfEmployee(ByVal employeeNumber As UInteger)
        Dim pm As New ProjectManager
        Try
            dtProject = pm.retrieveByEmpNum_denor_withKeys(employeeNumber)
            bsProject.DataSource = dtProject
            dgvProject.DataSource = bsProject
            lblRecordCount_Project.Text = bsProject.Count & " records found"
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub setProjectSummary()
        Try
            Dim workdays_tot, regOT_tot, sunOT_tot, holOT_tot As Double

            'Get Workdays and OTs Summation
            Dim workDays As Integer = CInt(DBNullToNumeric(dtProject.Compute("SUM(workdays)", "")))
            Dim regOT_hrs As Integer = CInt(DBNullToNumeric(dtProject.Compute("SUM(regOT_hrs)", "")))
            Dim sunOT_hrs As Integer = CInt(DBNullToNumeric(dtProject.Compute("SUM(sunOT_hrs)", "")))
            Dim holOT_hrs As Integer = CInt(DBNullToNumeric(dtProject.Compute("SUM(holOT_hrs)", "")))

            Dim hourly_rate As Double = PayrollManager.getBasicRatePerHour(emp.payMethod, emp.basicRate)

            regOT_tot = CDbl((hourly_rate * emp.regOt_rate) * regOT_hrs)
            sunOT_tot = CDbl((hourly_rate * emp.sunOt_rate) * sunOT_hrs)
            holOT_tot = CDbl((hourly_rate * emp.holOt_rate) * holOT_hrs)

            txtWorkdays.Text = workDays
            txtRegOT_hrs.Text = regOT_hrs
            txtSunOT_hrs.Text = sunOT_hrs
            txtHolOT_hrs.Text = holOT_hrs
            'Daily rate
            txtDailyRate.Text = PayrollManager.getDailyRate(emp.payMethod, emp.basicRate).ToString("0.00")
            'Hourly rate
            Dim strHourly_rate As String = hourly_rate.ToString("0.00")
            txtOT_rph_1.Text = strHourly_rate
            txtOT_rph_2.Text = strHourly_rate
            txtOT_rph_3.Text = strHourly_rate

            'Set workdays total
            'For Semi wage earners, getWorkdays_total will convert the employee's Basic rate to its 
            ' Daily rate equivalent
            workdays_tot = PayrollManager.getWorkdays_total(emp.payMethod, emp.basicRate, workDays)

            txtWorkdays_total.Text = workdays_tot.ToString("0.00")
            txtRegOT_total.Text = regOT_tot.ToString("0.00")
            txtSunOT_total.Text = sunOT_tot.ToString("0.00")
            txtHolOT_total.Text = holOT_tot.ToString("0.00")

            Dim grandTotal As Double = workdays_tot + _
            regOT_tot + sunOT_tot + holOT_tot
            txtIncome_Total.Text = grandTotal.ToString("0.00")
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("An error occur while setting Project Summary. Please report to the administrator.")
            Throw ex
        End Try
    End Sub

    'Deprecated
    Private Sub setWorkdaysAndOTs_Total()
        Try
            If bsProject.DataSource IsNot Nothing Then
                Dim workdays_tot, regOT_tot, sunOT_tot, holOT_tot As Double

                'Get Workdays and OTs Summation
                Dim workDays As Integer = CInt(DBNullToNumeric(dtProject.Compute("SUM(workdays)", "")))
                Dim regOT_hrs As Integer = CInt(DBNullToNumeric(dtProject.Compute("SUM(regOT_hrs)", "")))
                Dim sunOT_hrs As Integer = CInt(DBNullToNumeric(dtProject.Compute("SUM(sunOT_hrs)", "")))
                Dim holOT_hrs As Integer = CInt(DBNullToNumeric(dtProject.Compute("SUM(holOT_hrs)", "")))

                'Set workdays
                workdays_tot = PayrollManager.getWorkdays_total(emp.payMethod, emp.basicRate, workDays)
                Dim basicRate_perHour As Double = PayrollManager.getBasicRatePerHour(emp.payMethod, emp.basicRate)

                'Use of workdays is for Daily earners only?
                regOT_tot = CDbl((basicRate_perHour * emp.regOt_rate) * regOT_hrs)
                sunOT_tot = CDbl((basicRate_perHour * emp.sunOt_rate) * sunOT_hrs)
                holOT_tot = CDbl((basicRate_perHour * emp.holOt_rate) * holOT_hrs)

                txtWorkdays_total.Text = workdays_tot.ToString("0.00")
                txtRegOT_total.Text = regOT_tot.ToString("0.00")
                txtSunOT_total.Text = sunOT_tot.ToString("0.00")
                txtHolOT_total.Text = holOT_tot.ToString("0.00")

                Dim workdaysAndOTs As Double = workdays_tot + _
                regOT_tot + sunOT_tot + holOT_tot
                txtIncome_Total.Text = workdaysAndOTs.ToString("0.00")
            Else
                'if no project is returned, do this
                txtWorkdays_total.Text = "0.00"
                txtRegOT_total.Text = "0.00"
                txtSunOT_total.Text = "0.00"
                txtHolOT_total.Text = "0.00"
                txtIncome_Total.Text = "0.00"
            End If
        Catch icex As InvalidCastException
            MyMessageBox.invalidDataType()
        Catch ofex As OverflowException
            'MyMessageBox.outOfRange()
            MyMessageBox.error_customMessage("An Overflow occured. Please verify your input.")
        Catch appex As MyApplicationException
            MyMessageBox.error_customMessage(appex.Message)
        Catch bex As BusinessException
            MyMessageBox.error_customMessage(bex.Message)
        Catch ex As Exception
            MyMessageBox.error_generalInput()
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Select Case myState
            Case PayrollState.Idle
                Me.Close()
            Case PayrollState.Incomplete
                clearResources()
                RaiseEvent evState_changed(PayrollState.Idle)
            Case PayrollState.Complete
                Me.Close()
        End Select
    End Sub

    Private Sub writeStatus(ByVal message As String)
        tslblMessage.Text = message
    End Sub

    Private Sub btnFindEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        empChooser = New frmEmpChooser
        empChooser.ShowDialog()
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
            .ReadOnly = False
            .MultiSelect = False
            .Font = New Font(New FontFamily("tahoma"), 9, FontStyle.Regular)
            .Columns.Clear()

            Dim Column_project As New DataGridViewTextBoxColumn()
            With Column_project
                .DataPropertyName = "project"
                .Name = "project"
                .HeaderText = "Project"
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 125
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(Column_project)

            Dim Column_position As New DataGridViewTextBoxColumn
            With Column_position
                .DataPropertyName = "position"
                .Name = "position"
                .HeaderText = "Position"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 125
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(Column_position)

            Dim Column_division As New DataGridViewTextBoxColumn()
            With Column_division
                .DataPropertyName = "division"
                .Name = "division"
                .HeaderText = "Division"
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 125
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(Column_division)

            Dim Column_workdays As New DataGridViewTextBoxColumn
            With Column_workdays
                .DataPropertyName = "workDays"
                .Name = "workDays"
                .HeaderText = "Workdays"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(Column_workdays)

            Dim Column_regOT_hrs As New DataGridViewTextBoxColumn
            With Column_regOT_hrs
                .DataPropertyName = "regOT_hrs"
                .Name = "regOT_hrs"
                .HeaderText = "RegOT Hrs"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 50
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(Column_regOT_hrs)

            Dim Column_sunOT_hrs As New DataGridViewTextBoxColumn
            With Column_sunOT_hrs
                .DataPropertyName = "sunOT_hrs"
                .Name = "sunOT_hrs"
                .HeaderText = "SunOT Hrs"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 50
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(Column_sunOT_hrs)

            Dim Column_holOT_hrs As New DataGridViewTextBoxColumn
            With Column_holOT_hrs
                .DataPropertyName = "holOT_hrs"
                .Name = "holOT_hrs"
                .HeaderText = "HolOT Hrs"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 50
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(Column_holOT_hrs)

            Dim Column_isHead As New DataGridViewCheckBoxColumn
            With Column_isHead
                .DataPropertyName = "isHead"
                .Name = "isHead"
                .HeaderText = "Head"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .FlatStyle = FlatStyle.Standard
                .CellTemplate = New DataGridViewCheckBoxCell()
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 50
                .Visible = True
            End With
            .Columns.Add(Column_isHead)

            'INVISIBLES
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

            Dim Column_empNum As New DataGridViewCheckBoxColumn
            With Column_empNum
                .DataPropertyName = "empNum"
                .Name = "empNum"
                .HeaderText = "Emp"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .Visible = False
            End With
            .Columns.Add(Column_empNum)

            Dim Column_proj_ID As New DataGridViewTextBoxColumn
            With Column_proj_ID
                .DataPropertyName = "proj_ID"
                .Name = "proj_ID"
                .HeaderText = "Proj ID"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(Column_proj_ID)

            Dim Column_position_ID As New DataGridViewTextBoxColumn
            With Column_position_ID
                .DataPropertyName = "position_ID"
                .Name = "position_ID"
                .HeaderText = "Position ID"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(Column_position_ID)

            Dim Column_div_ID As New DataGridViewTextBoxColumn
            With Column_div_ID
                .DataPropertyName = "div_ID"
                .Name = "div_ID"
                .HeaderText = "Div ID"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(Column_div_ID)

            Dim Column_dateCreated As New DataGridViewCheckBoxColumn
            With Column_dateCreated
                .DataPropertyName = "dateCreated"
                .Name = "dateCreated"
                .HeaderText = "Created"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .Visible = False
            End With
            .Columns.Add(Column_dateCreated)

            Dim Column_lastModified As New DataGridViewCheckBoxColumn
            With Column_lastModified
                .DataPropertyName = "lastModified"
                .Name = "lastModified"
                .HeaderText = "Last Modified"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .Visible = False
            End With
            .Columns.Add(Column_lastModified)

            Dim Column_lastModifiedBy As New DataGridViewCheckBoxColumn
            With Column_lastModifiedBy
                .DataPropertyName = "lastModifiedBy"
                .Name = "lastModifiedBy"
                .HeaderText = "Last Modified By"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
                .Visible = False
            End With
            .Columns.Add(Column_lastModifiedBy)
        End With
    End Sub

    Private Sub dgvAllowance_Format()
        With dgvAllowance
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionForeColor = Color.Blue
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
            .DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionForeColor = Color.Blue
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
            .DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionForeColor = Color.Blue
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

    Private Sub getPayroll()
        payroll = New Payroll
        With payroll
            .payFrom = dateFrom
            .payTo = dateTo
            .empNum = emp.empNum
            .civilStat = emp.civilStat
            .numofDependent = emp.numOfDependents
            .tp_status = PayrollManager.getTaxPayerStatus(emp.civilStat, emp.numOfDependents)
            .payMethod = emp.payMethod
            .basicRate = emp.basicRate
            .regOT_rate = emp.regOt_rate
            .sunOT_rate = emp.sunOt_rate
            .holOT_rate = emp.holOt_rate
            ''
            .wTax = CDbl(DBNullToNumeric(txtWtax.Text))
            .SSS = CDbl(DBNullToNumeric(txtSSS.Text))
            .philHealth = CDbl(DBNullToNumeric(txtPhilHealth.Text))
            .PAGIBIG = CDbl(DBNullToNumeric(txtPAGIBIG.Text))
            .SSS_Loan = CDbl(DBNullToNumeric(txtSSS_Loan.Text))
            .personalLoan = CDbl(DBNullToNumeric(txtPersonalLoan.Text))
            .grossPay = CDbl(DBNullToNumeric(txtGross_2.Text))
            .netPay = CDbl(DBNullToNumeric(txtNetPay.Text))
        End With
    End Sub

    Private Function getProject_IDs() As UInteger()
        Dim proj_IDs(0) As UInteger
        Dim counter As Integer = 0
        If dtProject IsNot Nothing AndAlso dtProject.Rows IsNot Nothing Then
            Dim projectCount As Integer = dtProject.Rows.Count
            ReDim proj_IDs(projectCount)
            For Each drv As DataRowView In dtProject.DefaultView
                If DBNullToNumeric(drv("project_ID")) > 0 Then
                    proj_IDs(counter) = CUInt(drv("project_ID"))
                    counter += 1
                End If
            Next
        End If

        Return proj_IDs
    End Function

    Private Sub save()
        Dim msg As String = ""
        Try
            If dateFrom >= dateTo Then
                Throw New MyApplicationException("The date 'From' and 'To' is not consistent.")
            End If
            If dtProject.Rows.Count < 1 Or CDbl(DBNullToNumeric(txtNetPay.Text)) <= 0 Then
                Throw New MyApplicationException("There is no data to be processed.")
            End If
            If CDbl(DBNullToNumeric(txtGross_2.Text) < 1) Then
                Throw New MyApplicationException("There is no data to be processed.")
            End If
            If Not myState = PayrollState.Incomplete Then
                Throw New MyApplicationException("Fatal Error. Please report to the administrator")
            End If

            'Get the payroll information to be inserted on the database
            getPayroll()
            Dim pm As New PayrollManager
            payroll.payrollNum = pm.add(payroll, getProject_IDs)

            'Display Success Message
            msg = "New payroll record: " & payroll.payrollNum & " is created successfully for " & emp.fullName
            writeStatus(msg)
            MyMessageBox.success_customMessage(msg)

            'Events
            RaiseEvent evPayrollTransacts()
            RaiseEvent evState_changed(PayrollState.Complete)
        Catch myappex As MyApplicationException
            writeStatus(myappex.Message)
            MyMessageBox.error_customMessage(myappex.Message)
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            msg = "An error occur while creating payroll."
            writeStatus(msg)
            MyMessageBox.error_customMessage(msg)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Select Case myState
            Case PayrollState.Idle
                MsgBox("Please select an employee.", MsgBoxStyle.OkOnly, "")
                writeStatus("Please select an employee.")
            Case PayrollState.Incomplete
                save()
            Case PayrollState.Complete
                newPayroll()
        End Select
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As  _
                                 System.Windows.Forms.KeyPressEventArgs) _
                                 Handles txtPersonalLoan.KeyPress, txtSSS_Loan.KeyPress, txtWtax.KeyPress, _
                                  txtPAGIBIG.KeyPress, txtPhilHealth.KeyPress

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

    Private Sub TEXTBOX_DEDUCTION_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles txtPersonalLoan.Validating, txtSSS_Loan.Validating, txtWtax.Validating, _
                                  txtPAGIBIG.Validating, txtPhilHealth.Validating
        If emp Is Nothing Then Return
        ''FOR PERSONAL LOAN
        Dim msg As String = ""
        If sender Is txtPersonalLoan AndAlso CDbl(DBNullToNumeric(txtPersonalLoan.Text)) > emp.personalLoan Then
            Dim name As String = emp.firstName & " " & emp.lastName
            msg = String.Format("{0}'s current Personal Loan is only {1}", name, emp.personalLoan)
            MyMessageBox.informativeMessage(msg)
            writeStatus(msg)
            txtPersonalLoan.Text = CStr(emp.personalLoan)
            txtPersonalLoan.Focus()
            txtPersonalLoan.SelectAll()
            Return
        End If
        ''FOR SSS LOAN
        If sender Is txtSSS_Loan AndAlso CDbl(DBNullToNumeric(txtSSS_Loan.Text)) > emp.SSS_Loan Then
            Dim name As String = emp.firstName & " " & emp.lastName
            msg = String.Format("{0}'s current SSS Loan is only {1}", name, emp.SSS_Loan)
            MyMessageBox.informativeMessage(msg)
            writeStatus(msg)
            txtSSS_Loan.Text = CStr(emp.SSS_Loan)
            txtSSS_Loan.Focus()
            txtSSS_Loan.SelectAll()
            Return
        End If
        setTotalDeduction()
        setNetIncome()
    End Sub

    Private Sub state_changed(ByVal state As PayrollState) Handles Me.evState_changed
        Select Case state
            Case PayrollState.Idle
                idle()
            Case PayrollState.Incomplete
                incomplete()
            Case PayrollState.Complete
                complete()
        End Select
    End Sub

    Private Sub idle()
        myState = PayrollState.Idle
        writeStatus("Please select an employee.")
        btnSave.Text = "&SAVE"
    End Sub

    Private Sub incomplete()
        myState = PayrollState.Incomplete
        writeStatus("Ready to save payroll.")
        btnSave.Text = "&SAVE"
    End Sub

    Private Sub complete()
        myState = PayrollState.Complete
        hadTransacted = True
        btnSave.Text = "&NEW"
    End Sub

    Private Sub newPayroll()
        clearResources()
        RaiseEvent evState_changed(PayrollState.Idle)
    End Sub

    Private Sub clearResources()
        clearEmployeeInfo()
        payroll = Nothing
        clearProjectSummary()
        clearBonus()
        clearOtherDeduction()
        getProjectsOfEmployee(0)
        clearAllowance()
        clearPayrollSummary()
    End Sub

    Private Sub clearEmployeeInfo()
        emp = Nothing
        txtEmpNum.Clear()
        txtFullName.Clear()
    End Sub

    Private Sub clearProjectSummary()
        txtWorkdays.Text = "0"
        txtRegOT_hrs.Text = "0"
        txtSunOT_hrs.Text = "0"
        txtHolOT_hrs.Text = "0"
        '
        txtDailyRate.Text = "0.00"
        txtRegOT_rate.Text = "0.00"
        txtSunOT_rate.Text = "0.00"
        txtHolOT_rate.Text = "0.00"
        '
        txtOT_rph_1.Text = "0.00"
        txtOT_rph_2.Text = "0.00"
        txtOT_rph_3.Text = "0.00"
        '
        txtWorkdays_total.Text = "0.00"
        txtRegOT_total.Text = "0.00"
        txtSunOT_total.Text = "0.00"
        txtHolOT_total.Text = "0.00"
        txtIncome_Total.Text = "0.00"
    End Sub

    Private Sub clearBonus()
        Try
            lblRecordCount_Bonus.Text = "0 records found"
            lblBonus_total.Text = "Total = 0"
            txtBonus_Total.Text = "0.00"
            dtBonus.Clear()
        Catch ex As Exception
            writeStatus("Error while clearing bonus.")
            Throw ex
        End Try
    End Sub

    Private Sub clearAllowance()
        Try
            lblRecordCount_Allowance.Text = "0 records found"
            lblAllowance_total.Text = "Total = 0"
            txtAllowance_total.Text = "0.00"
            dtAllowance.Clear()
        Catch ex As Exception
            writeStatus("Error while clearing allowance.")
            Throw ex
        End Try
    End Sub

    Private Sub clearOtherDeduction()
        Try
            lblRecordCount_OtherDed.Text = "0 records found"
            lblOtherDeduction_total.Text = "Total = 0"
            txtOtherDed_total.Text = "0.00"
            dtOtherDed.Clear()
        Catch ex As Exception
            writeStatus("Error while clearing other deduction.")
            Throw ex
        End Try
    End Sub

    Private Sub clearPayrollSummary()
        Try
            clearGross()
            clearDeductables()
            clearTotalDeduction()
            clearNetIncome()
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while clearing Payroll Summary.")
            Throw ex
        End Try
    End Sub

    Private Sub clearGross()
        Try
            Dim taxable_allowance As Double = 0.0
            project_Grouped = Nothing
            Dim income As Double = 0
            Dim gross As Double = income + taxable_allowance

            txtIncome_Total_2.Text = income.ToString("0.00")
            txtAllowance_total.Text = taxable_allowance.ToString("0.00")
            txtGross.Text = gross.ToString("0.00")
            txtGross_2.Text = gross.ToString("0.00")
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while clearing Gross income.")
            Throw ex
        End Try
    End Sub

    Private Sub clearDeductables()
        Try
            txtPersonalLoan.Clear()
            txtSSS_Loan.Clear()

            Dim sss As Double = 0.0
            Dim philHealth As Double = 0.0
            Dim pagibig As Double = 0.0

            txtSSS.Text = sss.ToString("0.00")
            txtPhilHealth.Text = philHealth.ToString("0.00")
            txtPAGIBIG.Text = pagibig.ToString("0.00")
            'Clear WTax
            clearWTax()
        Catch e As DivideByZeroException
            'Do Nothing
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            writeStatus("Error while setting deductables.")
            Throw ex
        End Try
    End Sub

    Private Function clearWTax() As Double
        Try
            Dim wTax As Double = 0.0
            txtWtax.Text = wTax.ToString("0.00")
        Catch ex As Exception
            writeStatus("Error while clearing WTax.")
            Throw ex
        End Try
    End Function

    Private Sub clearTotalDeduction()
        Try
            Dim totalDeduction As Double = 0.0
            txtDeduction_total.Text = totalDeduction.ToString("0.00")
            txtDeduction_total_2.Text = txtDeduction_total.Text
        Catch ex As Exception
            writeStatus("Error while clearing Total Deduction.")
            Throw ex
        End Try
    End Sub

    Private Sub clearNetIncome()
        Try
            Dim net As Double = 0.0
            txtNetPay.Text = net.ToString("0.00")
        Catch ex As Exception
            writeStatus("Error clearing setting Net income.")
            Throw ex
        End Try
    End Sub

    Private Sub frmCreatePayroll_Nav_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.TopMost = False
    End Sub

    Private Sub frmCreatePayroll_Nav_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TopMost = False
    End Sub

    Private Sub txtTo_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTo.MouseClick, txtFrom.MouseClick
        payroll_period = New frmPayroll_Period(dateFrom, dateTo)
        payroll_period.ShowDialog()
    End Sub

    Private Sub Payroll_Period_changed(ByVal dateFrom As Date, ByVal dateTo As Date) Handles payroll_period.evCreatePayroll
        _dateFrom = dateFrom
        _dateTo = dateTo
        txtFrom.Text = dateFrom.ToString("ddd - MMMM dd, yyyy")
        txtTo.Text = dateTo.ToString("ddd - MMMM dd, yyyy")
        txtSSS_Loan.Focus()
    End Sub

End Class