Imports BusinessLogic
Imports CrossCutting
Imports BusinessLogic.BusinessEntity
Imports DataAccess

Public Class EmpProjectUC
    ''Events
    Public Event evPerformedDBOperation(ByVal dbOperation As DB_Operation)
    Public Event evStatusMessage(ByVal message As String)

    Private g_project As New Project

    Private dtProject As New DataTable
    Private dtPosition As New DataTable
    Private dtDivision As New DataTable

    Private tabPageDisabler As New Panel
    Private lblTabPageDisabler As New Label
    '
    Private _empNum As UInteger

    Const WEEKLY_MAX_WORKDAYS As Integer = 7
    Private isAuthorized As Boolean = False
    Private WithEvents authorization As frmAuthorization
    Private emp_payMethod As String

    Public Property empNum() As UInteger
        Get
            Return _empNum
        End Get
        Set(ByVal value As UInteger)
            _empNum = value
        End Set
    End Property

    'This is equivalent to a load event of its parent
    'This should be place on parent form load event
    Public Sub initialize_Me()
        initializeMyComponent()
        dgvProject_Format()     'dgvProject_Format should be called after fetching the data from the database
        initMyComboBox()
        initializeTabPageDisabler()
    End Sub

    Private Sub initMyComboBox()
        Try
            cbxProject_Fill()
            cbxPosition_Fill()
            cbxDivision_Fill()
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub cbxProject_refresh()
        cbxProject_Fill()
        representPrimeInfo()
    End Sub

    Public Sub cbxPosition_refresh()
        cbxPosition_Fill()
        representPrimeInfo()
    End Sub

    Public Sub cbxDivision_refresh()
        cbxDivision_Fill()
        representPrimeInfo()
    End Sub

    Private Sub cbxProject_Fill()
        Try
            Dim cm As New CodedDomainManager
            dtProject = cm.retrieveEnabled(CodedDomainManager.Tables.Project)
            With cbxProject
                .DataSource = dtProject
                .DisplayMember = "name"
                .ValueMember = "proj_ID"
                .Invalidate()
            End With
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cbxPosition_Fill()
        Try
            Dim cm As New CodedDomainManager
            dtPosition = cm.retrieveEnabled(CodedDomainManager.Tables.Position)
            With cbxPosition
                .DataSource = dtPosition
                .DisplayMember = "name"
                .ValueMember = "position_ID"
                .Invalidate()
            End With
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cbxDivision_Fill()
        Try
            Dim cm As New CodedDomainManager
            dtDivision = cm.retrieveEnabled(CodedDomainManager.Tables.Division)
            With cbxDivision
                .DataSource = dtDivision
                .DisplayMember = "name"
                .ValueMember = "div_ID"
                .Invalidate()
            End With
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub deleteSuccess()
        Try
            bindSource.RemoveCurrent()
            bindSource.EndEdit()
            setSummary()
            setRecordCount()
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub myDB_OperationPerformed(ByVal operationPerformed As DB_Operation) _
    Handles Me.evPerformedDBOperation
        Select Case operationPerformed
            Case DB_Operation.Create
                'addingSuccess()
            Case DB_Operation.Update
                modifyingSuccess()
            Case DB_Operation.Delete
                deleteSuccess()
        End Select
        'Release the g_user current object to reuse by another operation
        g_project = Nothing

        'Triggers the method inherited from the abstract StateOriented
        DB_OperationPerformed(operationPerformed)
        representPrimeInfo()
    End Sub

    Private Sub writeStatus(ByVal message As String)
        RaiseEvent evStatusMessage(message)
    End Sub

    'Gets the data needed to insert and update a record
    Private Sub getProject()
        If g_project Is Nothing Then g_project = New Project
        Try
            'NUM and STR
            With g_project
                Select Case getMyState
                    Case FormState.Adding
                        .empNum = empNum
                    Case FormState.Modifying
                        .project_ID = getBoundSource_PKey()
                End Select
                .proj_ID = CShort(DBNullToNumeric(cbxProject.SelectedValue))
                .position_ID = CShort(DBNullToNumeric(cbxPosition.SelectedValue))
                .div_ID = CShort(DBNullToNumeric(cbxDivision.SelectedValue))
                .workDays = CInt(txtWorkdays.Text)
                .regOT_hrs = CSng(txtRegOT_hrs.Text)
                .sunOT_hrs = CSng(txtSunOT_hrs.Text)
                .holOT_hrs = CSng(txtHolOT_hrs.Text)
                '
                .proj_name = DBNullToString(CType(cbxProject.SelectedItem, DataRowView)("name"))
                .position = DBNullToString(CType(cbxPosition.SelectedItem, DataRowView)("name"))
                .division = DBNullToString(CType(cbxDivision.SelectedItem, DataRowView)("name"))
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

    'This should be called whenever the user will see its data
    Public Sub filterByEmployee(ByVal employeeNumber As UInteger, ByVal employee_name As String, _
                                ByVal payMethod As String)
        Try
            lblEmployeeName.Text = employee_name
            emp_payMethod = payMethod
            If Not dvPrimeDS Is Nothing Then
                ''clear radio buttons
                'radio_in_grid.clearRadios()
                empNum = employeeNumber
                dvPrimeDS.RowFilter = "empNum = " & empNum

                disableOrEnable()
                representPrimeInfo()
                setRecordCount()

                TabControlProject.SelectedIndex = 0
                If bindSource.Count > 1 Then bindSource.Position = 0

                setSummary()
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub setRecordCount()
        lblRecordCount.Text = bindSource.Count & " record/s found"
    End Sub

#Region "Set Display"
    Private Sub initializeTabPageDisabler()
        Me.Controls.Add(tabPageDisabler)
        With tabPageDisabler
            .Width = TabControlProject.Width
            .Height = 25
            .Location = TabControlProject.Location
            .BackColor = Color.RoyalBlue
            .BringToFront()
            .Controls.Add(lblTabPageDisabler)
            .Hide()
        End With

        With lblTabPageDisabler
            .Font = New Font(New System.Drawing.FontFamily("Tahoma"), 11, FontStyle.Bold)
            .ForeColor = Color.White
            .AutoSize = True
        End With

        AddHandler TabControlProject.SelectedIndexChanged, AddressOf setTabPageDisabler_Label
    End Sub

    Private Sub showTabPageDisabler()
        With tabPageDisabler
            .Show()
        End With
        setTabPageDisabler_Label()
    End Sub

    Private Sub setTabPageDisabler_Label()
        Try
            If Not lblTabPageDisabler Is Nothing AndAlso Not lblTabPageDisabler.Parent Is Nothing Then
                With lblTabPageDisabler
                    .Text = IIf(getMyState = FormState.Adding, "New Project", "Modify Project")
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

    Private Sub disableOrEnable()
        If bindSource.Count = 0 Then
            tsbtnEdit.Enabled = False
            tsbtnDelete.Enabled = False
            TabControlProject.Enabled = False
        Else
            tsbtnEdit.Enabled = True
            tsbtnDelete.Enabled = True
            TabControlProject.Enabled = True
        End If
    End Sub

#End Region

#Region "State Oriented"
    Protected Overrides Sub initializeMyComponent()
        Try
            addControlToConceal(cbxDivision, cbxPosition, cbxProject)
            'SET BUTTONS For State
            myBtnAdd = tsbtnAdd
            myBtnModify = tsbtnEdit
            myBtnSave = btnSave
            myBtnCancel = btnCancel

            'DATA SOURCE AND BINDINGS
            Dim pm As New ProjectManager
            dvPrimeDS = pm.retrieve_for_projectUC.DefaultView
            With dvPrimeDS
                .AllowNew = True
                .AllowEdit = True
                .AllowDelete = True
            End With

            bindSource = New BindingSource()
            With bindSource
                .AllowNew = True
                .DataSource = dvPrimeDS
            End With

            bindNavProject.BindingSource = bindSource
            dgvProject.DataSource = bindSource

            idleState()
            bindMyControls()
        Catch daex As DataAccessException
            Throw daex
        End Try
    End Sub

    Protected Overrides Sub bindMyControls()
        Try
            If Not bindSource Is Nothing Then
                Dim dateCreatedBinding As New Binding("text", bindSource, "dateCreated")
                txtDateCreated_readOnly.DataBindings.Add(dateCreatedBinding)
                AddHandler dateCreatedBinding.Format, AddressOf DBdateTextbox
                AddHandler dateCreatedBinding.Parse, AddressOf TextBoxDBdate
                txtLastModified_readOnly.DataBindings.Add("text", bindSource, "lastModified")
                txtLastModifiedBy_readOnly.DataBindings.Add("text", bindSource, "lastModifiedBy")

                isPrimeBound = True
                positionChanged()
            End If
        Catch ex As Exception
            'DISABLE SOME OF THE CONTROLS TO SUPPRESS ERRORS
            Bugs_DAO.log(ex)
            Throw New MyApplicationException("An error occured while binding the data to the data source.")
        End Try

    End Sub

    Private Sub DBdateTextbox(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If cevent.Value Is DBNull.Value Then
            cevent.Value = ""
        Else
            Dim datum As Date
            datum = CDate(cevent.Value)
            cevent.Value = datum.ToString("d")
        End If
    End Sub

    Private Sub TextBoxDBdate(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If cevent.Value.ToString = "" Then
            cevent.Value = DBNull.Value
        End If
    End Sub

    Protected Overrides Sub addingState_DefaultControls()
        Try
            TabControlProject.Enabled = True
            If cbxProject.Items.Count > 0 Then cbxProject.SelectedIndex = 0
            If cbxPosition.Items.Count > 0 Then cbxPosition.SelectedIndex = 0
            If cbxDivision.Items.Count > 0 Then cbxDivision.SelectedIndex = 0
            txtWorkdays.Text = "0"
            txtRegOT_hrs.Text = "0"
            txtSunOT_hrs.Text = "0"
            txtHolOT_hrs.Text = "0"
            txtDateCreated.Clear()
            txtLastModified.Clear()
            txtLastModifiedBy.Clear()
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub modifyingState_prepare_values()
        representPrimeInfo()
        Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
        txtDateCreated.Text = CType(drv("dateCreated"), Date).ToShortDateString
        txtLastModified.Text = CType(drv("lastModified"), Date).ToShortDateString
        txtLastModifiedBy.Text = CStr(DBNullToString((drv("lastModifiedBy"))))

        txtWorkdays.Text = CStr(DBNullToNumeric(drv("workdays")))
        txtRegOT_hrs.Text = CStr(DBNullToNumeric(drv("regOT_hrs")))
        txtSunOT_hrs.Text = CStr(DBNullToNumeric(drv("sunOT_hrs")))
        txtHolOT_hrs.Text = CStr(DBNullToNumeric(drv("holOT_hrs")))
    End Sub

    'Represent current project information
    Protected Overrides Sub representPrimeInfo()
        Try
            representProject()
            representPosition()
            representDivision()
        Catch appex As MyApplicationException
            Bugs_DAO.log(appex)
        End Try

    End Sub

    Private Sub representProject()
        Try
            Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
            For Each dr As DataRowView In dtProject.DefaultView
                If CShort(dr("proj_ID")) = CShort(drv("proj_ID")) Then
                    cbxProject.SelectedItem = dr
                End If
            Next
        Catch ex As Exception
            Bugs_DAO.log(ex)
            'Do Nothing
        End Try

    End Sub

    Private Sub representPosition()
        Try
            Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
            For Each dr As DataRowView In dtPosition.DefaultView
                If CShort(dr("position_ID")) = CShort(drv("position_ID")) Then
                    cbxPosition.SelectedItem = dr
                End If
            Next
        Catch ex As Exception
            'Do Nothing
        End Try

    End Sub

    Private Sub representDivision()
        Try
            Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
            For Each dr As DataRowView In dtDivision.DefaultView
                If CShort(dr("div_ID")) = CShort(drv("div_ID")) Then
                    cbxDivision.SelectedItem = dr
                End If
            Next
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    'NOTE: The arrangement of methods in state are important
    Protected Overrides Sub idleState()
        writeStatus("Ready")
        commandButtonsVisible(False)
        hideTabPageDisabler()
        'ENABLE SOME OF THE CONTROLS
        bindNavProject.Enabled = True
        disableOrEnable()
        TabControlProject.SelectedIndex = 0
        setSummary()
    End Sub

    Protected Overrides Sub addingState()
        writeStatus("Adding new project")
        'Unbound controls
        commandButtonsVisible(True)
        addingState_DefaultControls()
        showTabPageDisabler()
        TabControlProject.SelectedIndex = 1
        'DISALBE SOME OF THE CONTROLS
        bindNavProject.Enabled = False
    End Sub

    Protected Overrides Sub modifyingState()
        writeStatus("Modifying an existing project")
        'Unbound controls
        commandButtonsVisible(True)
        showTabPageDisabler()
        TabControlProject.SelectedIndex = 1
        modifyingState_prepare_values()
        'DISALBE SOME OF THE CONTROLS
        bindNavProject.Enabled = False
    End Sub

    Protected Overrides Sub addNewPrime()
        Dim msg As String = ""
        Try
            If dtProject.Rows.Count < 1 Then
                msg = "Project is required."
                writeStatus(msg)
                MyMessageBox.informativeMessage(msg)
                Return
            End If

            If dtPosition.Rows.Count < 1 Then
                msg = "Position is required."
                writeStatus(msg)
                MyMessageBox.informativeMessage(msg)
                Return
            End If

            If dtDivision.Rows.Count < 1 Then
                msg = "Division is required."
                writeStatus(msg)
                MyMessageBox.informativeMessage(msg)
                Return
            End If

            If empNum < 1 Then
                msg = "Project must be place on an Employee."
                writeStatus(msg)
                MyMessageBox.informativeMessage(msg)
                Return
            End If
            getProject()

            Dim pm As New ProjectManager
            g_project.project_ID = pm.add(g_project)

            addingSuccess()
            msg = "New project was added successfully."
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
        Dim msg As String = ""
        Try
            getProject()

            Dim pm As New ProjectManager
            pm.update(g_project)

            RaiseEvent evPerformedDBOperation(DB_Operation.Update)
            msg = "Updating project successful."
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
        Try
            'Add new user to the underlying data source
            Dim newRow = CType(bindSource.AddNew, DataRowView)
            newRow("project_ID") = g_project.project_ID
            newRow("empNum") = g_project.empNum
            newRow("proj_ID") = g_project.proj_ID
            newRow("position_ID") = g_project.position_ID
            newRow("div_ID") = g_project.div_ID

            newRow("workDays") = g_project.workDays
            newRow("regOT_hrs") = g_project.regOT_hrs
            newRow("sunOT_hrs") = g_project.sunOT_hrs
            newRow("holOT_hrs") = g_project.holOT_hrs

            newRow("dateCreated") = Now.ToShortDateString
            newRow("lastModified") = Now()
            newRow("lastModifiedBy") = getCurrentUser_Username()

            newRow("project") = g_project.proj_name
            newRow("position") = g_project.position
            newRow("division") = g_project.division
            bindSource.EndEdit()

            disableOrEnable()
            setSummary()
            setRecordCount()
            'Flag the newly added project
            flag_currentProject()
            RaiseEvent evPerformedDBOperation(DB_Operation.Create)
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Protected Overrides Sub modifyingSuccess()
        Try
            'Update user from the underlying data source
            Dim currentRow = CType(bindSource.Current, DataRowView)
            currentRow.BeginEdit()
            currentRow("proj_ID") = g_project.proj_ID
            currentRow("position_ID") = g_project.position_ID
            currentRow("div_ID") = g_project.div_ID
            currentRow("workDays") = g_project.workDays
            currentRow("regOT_hrs") = g_project.regOT_hrs
            currentRow("sunOT_hrs") = g_project.sunOT_hrs
            currentRow("holOT_hrs") = g_project.holOT_hrs
            ''For viewing
            currentRow("lastModified") = Now
            currentRow("lastModifiedBy") = getCurrentUser_Username()

            currentRow("project") = g_project.proj_name
            currentRow("position") = g_project.position
            currentRow("division") = g_project.division
            currentRow.EndEdit()

            setSummary()
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Protected Overrides Function getBoundSource_PKey() As UInt32
        Try
            If Not bindSource.Current Is Nothing Then
                Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
                Return CUInt(DBNullToNumeric(drv("project_ID")))
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
        Return 0
    End Function

#End Region

    Private Sub Num_TextBox_KeyPress(ByVal sender As Object, ByVal e As  _
                                 System.Windows.Forms.KeyPressEventArgs) _
                                 Handles txtWorkdays.KeyPress, txtRegOT_hrs.KeyPress, txtSunOT_hrs.KeyPress, _
                                 txtHolOT_hrs.KeyPress
        If (Char.IsDigit(e.KeyChar) = False AndAlso Char.IsControl(e.KeyChar) = _
            False) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tsbtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDelete.Click
        deletePrime()
    End Sub

    Private Sub deletePrime()
        Dim msg As String = ""
        Try
            If bindSource.Current Is Nothing Then Return

            If recordDeletionConfirmed() Then
                Dim pm As New ProjectManager
                Dim i As Integer = pm.delete(getBoundSource_PKey())

                RaiseEvent evPerformedDBOperation(DB_Operation.Delete)
                msg = "Project was removed successfully."
                writeStatus(msg)
                MyMessageBox.success_customMessage(msg)
            Else
                writeStatus("Project deletion is cancelled.")
            End If
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            msg = "An error occur while removing project!"
            writeStatus(msg)
            MyMessageBox.error_customMessage(msg)
        End Try
    End Sub

    Private Function recordDeletionConfirmed() As Boolean
        Dim res As DialogResult = _
        MessageBox.Show("Are you sure you want to delete this project?", _
                        "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub dgvProject_Format()
        With dgvProject
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionForeColor = Color.Blue
            '.RowTemplate.Height = 
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
                .Width = 140
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
                .Width = 140
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
                .Width = 140
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

    Private Sub dgvProject_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProject.CellValueChanged
        Dim pKey_currentCell As DataGridViewCell = dgvProject.Item("project_ID", e.RowIndex)
        Dim isHead_currentCell As DataGridViewCell = dgvProject.Item("ishead", e.RowIndex)
        'Loop through the datasource and unchecked all the rows 'isHead' column except from the row that is recently checked.
        For Each drv As DataRowView In CType(CType(dgvProject.DataSource, BindingSource).DataSource, DataView)
            If CUInt(DBNullToNumeric(drv("project_ID"))) <> CUInt(DBNullToNumeric(pKey_currentCell.Value)) Then
                drv("isHead") = False
            End If
        Next
    End Sub

    Private Sub dgvProject_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProject.CurrentCellDirtyStateChanged
        If dgvProject.IsCurrentCellDirty Then
            dgvProject.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    'Set the summary
    Private Sub setSummary()
        Dim myDataView As DataView = CType(bindSource.DataSource, DataView)
        Dim workdays_total As Integer = 0
        Dim regOT_hrs_total As Integer = 0
        Dim sunOT_hrs_total As Integer = 0
        Dim holOT_hrs_total As Integer = 0
        For Each drv As DataRowView In myDataView
            workdays_total += CInt(DBNullToNumeric(drv("workdays")))
            regOT_hrs_total += CInt(DBNullToNumeric(drv("regOT_hrs")))
            sunOT_hrs_total += CInt(DBNullToNumeric(drv("sunOT_hrs")))
            holOT_hrs_total += CInt(DBNullToNumeric(drv("holOT_hrs")))
        Next
        txtWorkdays_total.Text = workdays_total
        txtRegOT_hrs_total.Text = regOT_hrs_total
        txtSunOT_hrs_total.Text = sunOT_hrs_total
        txtHolOT_hrs_total.Text = holOT_hrs_total
    End Sub

    'This is for weekly employees
    Private Sub txtWorkdays_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtWorkdays.Validating
        Try
            If Not emp_payMethod.Equals("Weekly") Then Return

            Dim additional_workdays As Integer = DBNullToNumeric(txtWorkdays.Text)

            Dim current_workdays_total As Integer = DBNullToNumeric(txtWorkdays_total.Text)
            Dim current_project_workdays As Integer

            Select Case getMyState
                Case FormState.Adding
                    'If additional wordays is zero, just return smoothly
                    If additional_workdays < 1 Then
                        Return
                    End If
                Case FormState.Modifying
                    'Get current project's workdays
                    Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
                    current_project_workdays = CInt(DBNullToNumeric(drv("workdays")))
                    'If additional wordays is the same as current project's workdays or lesser, just return smoothly
                    If additional_workdays <= current_project_workdays Then
                        Return
                    End If
                    'Set current_workdays_total excluding the current project's workdays
                    current_workdays_total = current_workdays_total - current_project_workdays
            End Select

            Dim new_workdays_total As Integer = current_workdays_total + additional_workdays
            If new_workdays_total > WEEKLY_MAX_WORKDAYS Then
                authorization = New frmAuthorization("Workdays for 'Weekly' employee cannot exceed 7 days. " & _
                                                     vbCrLf & "An authorization is required.")
                authorization.ShowDialog()

                If Not isAuthorized Then
                    e.Cancel = True
                    Select Case getMyState
                        Case FormState.Adding
                            txtWorkdays.Text = "0"
                        Case FormState.Modifying
                            txtWorkdays.Text = current_project_workdays
                    End Select
                    txtWorkdays.Focus()
                    txtWorkdays.SelectAll()
                Else
                    isAuthorized = False
                End If
            End If
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub authorization_hookie(ByVal _isAuthorize As Boolean) Handles authorization.evAuthorize
        isAuthorized = _isAuthorize
    End Sub

    Private Sub btnFlagProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlagProject.Click
        flag_currentProject()
    End Sub

    Private Sub flag_currentProject()
        Try
            'Return if no project
            If dgvProject.RowCount < 1 Then Return

            Dim drv As DataRowView = CType(CType(dgvProject.DataSource, BindingSource).Current, DataRowView)
            'If the current project in already head, just return
            If CBool(DBNullToNumeric(drv("isHead"))) Then Return
            Dim pm As New ProjectManager
            Dim project_ID As UInteger = CUInt(DBNullToNumeric(drv("project_ID")))
            Dim empNum As UInteger = CUInt(DBNullToNumeric(drv("empNum")))
            pm.flag_head(project_ID, empNum)
            flag_success()
            If Not getMyState = FormState.Adding Then
                MyMessageBox.success_customMessage("Flagging project head successful.")
            End If
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus("An error occur while flagging project head")
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub flag_success()
        Try
            'Check the new project head
            Dim index As Integer = dgvProject.CurrentRow.Index
            Dim isHead_currentCell As DataGridViewCell = dgvProject.Item("ishead", index)
            isHead_currentCell.Value = True
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub
End Class