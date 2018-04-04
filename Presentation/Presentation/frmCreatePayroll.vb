Imports CrossCutting
Imports BusinessLogic
Imports BusinessLogic.BusinessEntity
Imports DataAccess

Public Class frmCreatePayroll
    Public Event evPayrollTransacts()
    Public Event evPersonalLoan_settled(ByVal newValue As Double)

    Private WithEvents empChooser As frmEmpChooser

    Private dtProject As DataTable
    Private dtBonus As DataTable
    Private dvAllowance As DataView
    Private dvOtherDed As DataView
    Private WithEvents bsProject As BindingSource

    Private emp As Employee
    Private payroll As Payroll

    Sub New(ByVal drv As DataRowView)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bsProject = New BindingSource
        initializeMyComponent()

        'Set Employee
        employeeSelected(drv)
    End Sub

    Private Sub initializeMyComponent()
        Try
            initializeDataGridViews()
            initializeDataSourcesToFilter()
            bindMyControls()
            filterDataSources()
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
            getProjectsOfEmployee(0)

            Dim au As New AllowanceUtility
            'dvAllowance = au.retrieveAllForPayroll.DefaultView
            dgvAllowance.DataSource = dvAllowance

            Dim odu As New OtherDeductionUtility
            'dvOtherDed = odu.retrieveAllForPayroll.DefaultView
            dgvOtherDeduction.DataSource = dvOtherDed
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

    Private Sub filterDataSources()
        Try
            Dim proj_ID As UInteger = 0
            If bsProject.Current IsNot Nothing Then
                proj_ID = CUInt(CType(bsProject.Current, DataRowView)("project_ID"))
            End If

            If dvAllowance IsNot Nothing Then
                dvAllowance.RowFilter = "project_ID = " & proj_ID
                lblRecordCount_Allowance.Text = dvAllowance.Count & " records found"
            End If
            dgvAllowance.Columns("pKey").Visible = False

            If dvOtherDed IsNot Nothing Then
                dvOtherDed.RowFilter = "project_ID = " & proj_ID
                lblRecordCount_Deduction.Text = dvOtherDed.Count & " records found"
            End If
            dgvOtherDeduction.Columns("ID").Visible = False

        Catch ex As Exception
            writeStatus("Error while filtering data sources")
            Throw ex
        End Try
    End Sub

    Private Sub employeeSelected(ByVal drv As DataRowView) 'Handles empChooser.evEmployeeSelected
        Try
            setEmployeeInfo(drv)
            setBonus_Total()
            getProjectsOfEmployee(emp.empNum)
            setPayrollSummary()
            filterDataSources()

            writeStatus("Ready to save payroll.")
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub setEmployeeInfo(ByVal drv As DataRowView)
        Try
            emp = New Employee
            emp.empNum = CUInt(drv("empNum"))
            emp.dateHired = CDate(drv("dateHired"))
            emp.civilStat = CStr(drv("civilStatus"))
            emp.numOfDependents = CStr(drv("numOfDependent"))
            emp.payMethod = CStr(drv("payMethod"))
            emp.basicRate = CDbl(drv("basicRate"))
            emp.regOt_rate = CSng(drv("regOt_rate"))
            emp.sunOt_rate = CSng(drv("sunOt_rate"))
            emp.holOt_rate = CSng(drv("holOt_rate"))
            emp.personalLoan = CDbl(DBNullToNumeric(drv("personalLoan")))

            txtEmpNum.Text = emp.getFormattedEmpNum
            txtFullName.Text = String.Format("{0} {1}", CStr(drv("firstName")), CStr(drv("lastName")))
            txtPersonalLoan.Text = emp.personalLoan.ToString
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting employee information")
            Throw ex
        End Try
    End Sub

    Private Sub setBonus_Total()
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
            txtBonus_Total.Text = bonus_total.ToString("0.00")

            If dgvBonus.DataSource Is Nothing Then dgvBonus.DataSource = dtBonus
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while setting bonus total.")
            Throw ex
        End Try

    End Sub

    Private Sub setDeductables()
        txtPersonalLoan.Text = CStr(emp.personalLoan)
    End Sub

    Private Sub setPayrollSummary()

        Dim allow_total As Double

        Dim otherDed_total As Double
        Try
            Dim pm As New ProjectManager
            'Allowance total
            'allow_total = pm.getAllowanceTotalForEmployee(emp.empNum, False)
            txtAllowTotal_nonTax.Text = allow_total.ToString("0.00")

            'Other Deduction Total
            'otherDed_total = pm.getOtherDeductTotalForEmployee(emp.empNum)
            txtOtherDed_total.Text = otherDed_total.ToString("0.00")

            ''
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
        Dim taxable_allowance As Double

        Dim pm As New ProjectManager
        dtWorkAndOTs = pm.getWorkdaysAndOTs(emp.empNum)
        'taxable_allowance = pm.getAllowanceTotalForEmployee(emp.empNum, True)
        'Get Workdays and OTs total hours
        Dim workDays As Integer = CInt(DBNullToNumeric(dtWorkAndOTs.Rows(0)("workDays")))
        Dim regOT_hrs As Integer = CInt(DBNullToNumeric(dtWorkAndOTs.Rows(0)("regOT_hrs")))
        Dim sunOT_hrs As Integer = CInt(DBNullToNumeric(dtWorkAndOTs.Rows(0)("sunOT_hrs")))
        Dim holOT_hrs As Integer = CInt(DBNullToNumeric(dtWorkAndOTs.Rows(0)("holOT_hrs")))

        'Set totals
        Dim ratePerHour As Double = PayrollManager.getBasicRatePerHour(emp.payMethod, emp.basicRate)

        workdays_tot = PayrollManager.getWorkdays_total(emp.payMethod, emp.basicRate, workDays)
        regOT_tot = CDbl((ratePerHour * emp.regOt_rate) * regOT_hrs)
        sunOT_tot = CDbl((ratePerHour * emp.sunOt_rate) * sunOT_hrs)
        holOT_tot = CDbl((ratePerHour * emp.holOt_rate) * holOT_hrs)

        'What about the allowances?
        Dim income As Double = workdays_tot + regOT_tot + sunOT_tot + holOT_tot
        Dim gross As Double = income + taxable_allowance
        txtTotalIncome.Text = income.ToString("0.00")
        txtAllowTotal_taxable.Text = taxable_allowance.ToString("0.00")
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

    Private Sub getProjectsOfEmployee(ByVal employeeNumber As UInteger)
        Dim pm As New ProjectManager
        Try

            dtProject = pm.retrieveForPayroll(employeeNumber)
            bsProject.DataSource = dtProject
            dgvProject.DataSource = bsProject
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

    Private Sub bsProject_positionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsProject.PositionChanged, bsProject.DataSourceChanged
        If emp IsNot Nothing Then
            getWorkdaysAndOTsPerProject()
            filterDataSources()
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
                workdays_tot = PayrollManager.getWorkdays_total(emp.payMethod, emp.basicRate, workDays)

                Dim ratePerHour As Double = PayrollManager.getBasicRatePerHour(emp.payMethod, emp.basicRate)

                'Use of workdays is for Daily earners only?
                regOT_tot = CDbl((ratePerHour * emp.regOt_rate) * regOT_hrs)
                sunOT_tot = CDbl((ratePerHour * emp.sunOt_rate) * sunOT_hrs)
                holOT_tot = CDbl((ratePerHour * emp.holOt_rate) * holOT_hrs)

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
            MyMessageBox.error_customMessage("An Overflow occured.")
        Catch appex As MyApplicationException
            MyMessageBox.error_customMessage(appex.Message)
        Catch bex As BusinessException
            MyMessageBox.error_customMessage(bex.Message)
        Catch ex As Exception
            MyMessageBox.error_generalInput()
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        'Me.Dispose()
    End Sub

    Private Sub writeStatus(ByVal message As String)
        tslblMessage.Text = message
    End Sub

    'NOT USED
    Private Sub btnFindEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        empChooser = New frmEmpChooser
        empChooser.ShowDialog()
    End Sub

#Region "DataGridViews Format"
    Private Sub dgvProject_Format()
        With dgvProject
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.RowTemplate.Height = 
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

            Dim ColumnDivision As New DataGridViewTextBoxColumn()
            With ColumnDivision
                .DataPropertyName = "division"
                .Name = "division"
                .HeaderText = "Division"
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 125
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
                .Width = 125
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
                .DataPropertyName = "pKey"
                .Name = "pKey"
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
                .DataPropertyName = "project_ID"
                .Name = "project_ID"
                .HeaderText = "Project ID"
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

            Dim ColumnProjectID As New DataGridViewTextBoxColumn
            With ColumnProjectID
                .DataPropertyName = "project_ID"
                .Name = "project_ID"
                .HeaderText = "Project ID"
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

    Private Sub frmPayroll_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub getPayroll()
        payroll = New Payroll
        With payroll
            .payFrom = dtpFrom.Value
            .payTo = dtpTo.Value
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
            .grossPay = CDbl(DBNullToNumeric(txtGross_total.Text))
            .netPay = CDbl(DBNullToNumeric(txtNetIncome.Text))
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
        Try
            If dtProject.Rows.Count < 1 Or CDbl(DBNullToNumeric(txtNetIncome.Text)) <= 0 Then
                writeStatus("There is no data to be processed.")
                Return
            End If

            If CDbl(DBNullToNumeric(txtGross_total.Text) < 1) Then
                writeStatus("There is no data to be processed.")
                Return
            End If

            If CDbl(txtPersonalLoan.Text) > emp.personalLoan Then
                MsgBox("Employee's Personal Loan is only " & emp.personalLoan, MsgBoxStyle.OkOnly, "Error")
                writeStatus("Employee's Personal Loan is only " & emp.personalLoan)
                txtPersonalLoan.Focus()
                Return
            End If

            getPayroll()
            Dim pm As New PayrollManager
            payroll.payrollNum = pm.add(payroll, getProject_IDs)

            addPayrollSuccess()
            writeStatus("New payroll record: " & payroll.payrollNum & " is created successfully.")
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            writeStatus("An error occur while creating payroll.")
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save()
    End Sub

    Private Sub addPayrollSuccess()
        If CDbl(DBNullToNumeric(txtPersonalLoan.Text)) > 0 Then
            'UPDATE PERSONAL LOAN 
            Dim newVal As Double = emp.personalLoan - CDbl(txtPersonalLoan.Text)
            RaiseEvent evPersonalLoan_settled(newVal)
        End If
        'UPDATE THE PROJECT INFO AND BONUS
        RaiseEvent evPayrollTransacts()
        btnSave.Enabled = False
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As  _
                                 System.Windows.Forms.KeyPressEventArgs) _
                                 Handles txtPersonalLoan.KeyPress, txtSSS_Loan.KeyPress, txtWtax.KeyPress, _
                                 txtSSS.KeyPress, txtPAGIBIG.KeyPress, txtPhilHealth.KeyPress

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
                                 txtSSS.Validating, txtPAGIBIG.Validating, txtPhilHealth.Validating
        If emp Is Nothing Then Return
        If sender Is txtPersonalLoan AndAlso CDbl(DBNullToNumeric(txtPersonalLoan.Text)) > emp.personalLoan Then
            MsgBox("Employee's Personal Loan is only " & emp.personalLoan, MsgBoxStyle.OkOnly, "Error")
            writeStatus("Employee's Personal Loan is only " & emp.personalLoan)
            txtPersonalLoan.Text = CStr(emp.personalLoan)
            txtPersonalLoan.Focus()
            txtPersonalLoan.SelectAll()
            Return
        End If
        setTotalDeduction()
        setNetIncome()
    End Sub

End Class