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

    Private _empNum As UInteger
    Public Property empNum() As UInteger
        Get
            Return _empNum
        End Get
        Set(ByVal value As UInteger)
            _empNum = value
        End Set
    End Property

    'This is equivalent to a load event of its parent
    'This should be place on form load event
    Public Sub initialize_Me()
        initializeMyComponent()
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
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub myDB_OperationPerformed(ByVal operationPerformed As DB_Operation) _
    Handles Me.evPerformedDBOperation
        Select Case operationPerformed
            Case DB_Operation.Create
                addingSuccess()
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
            End With
        Catch icex As InvalidCastException
            ErrorMessage.invalidDataType()
            Throw New MyApplicationException("Adding new project  failed.")
        Catch ofex As OverflowException
            ErrorMessage.customMessage("The number you input is very large. Please check your input")
            Throw New MyApplicationException("Adding new project  failed.")
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            ErrorMessage.generalInput()
            Throw ex
        End Try
    End Sub

    'This should be called whenever the user will see its data
    Public Sub filterByEmployee(ByVal employeeNumber As UInteger)
        Try
            If Not dvPrimeDS Is Nothing Then
                empNum = employeeNumber
                dvPrimeDS.RowFilter = "empNum = " & empNum

                disableOrEnable()
                representPrimeInfo()

                TabControlProject.SelectedIndex = 0
                If bindSource.Count > 1 Then bindSource.Position = 0
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try

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
            dvPrimeDS = pm.retrieveAll.DefaultView
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

            idleState()
        Catch daex As DataAccessException
            Throw daex
        End Try
    End Sub

    Protected Overrides Sub bindMyControls()
        'USER
        Try
            If Not bindSource Is Nothing Then
                'CANNOT REPRESENT DATA - another conversion is use when representing.
                'cbxDivision.DataBindings.Add("tag", bindSource, "div_ID")
                'cbxPosition.DataBindings.Add("tag", bindSource, "position_ID")
                Dim dateCreatedBinding As New Binding("text", bindSource, "dateCreated")
                txtDateCreated.DataBindings.Add(dateCreatedBinding)
                AddHandler dateCreatedBinding.Format, AddressOf DBdateTextbox
                AddHandler dateCreatedBinding.Parse, AddressOf TextBoxDBdate
                txtLastModified.DataBindings.Add("text", bindSource, "lastModified")
                txtLastModifiedBy.DataBindings.Add("text", bindSource, "lastModifiedBy")

                txtWorkdays.DataBindings.Add("text", bindSource, "workdays")
                txtRegOT_hrs.DataBindings.Add("text", bindSource, "regOT_hrs")
                txtSunOT_hrs.DataBindings.Add("text", bindSource, "sunOT_hrs")
                txtHolOT_hrs.DataBindings.Add("text", bindSource, "holOT_hrs")

                addBoundedControl(txtDateCreated, txtLastModified, _
                                  txtLastModifiedBy, txtWorkdays, txtRegOT_hrs, txtSunOT_hrs, _
                                  txtHolOT_hrs)

                isPrimeBound = True
                positionChanged()
            End If
        Catch ex As Exception
            'DISABLE SOME OF THE CONTROLS TO SUPPRESS ERRORS
            writeStatus("An error occured while binding the data to the data source.")
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

    'Use by 3 states
    Protected Overrides Sub boundedControls_readOnly(ByVal bool As Boolean)
        cbxProject.Enabled = IIf(bool, False, True)
        cbxPosition.Enabled = IIf(bool, False, True)
        cbxDivision.Enabled = IIf(bool, False, True)
        txtWorkdays.ReadOnly = bool
        txtRegOT_hrs.ReadOnly = bool
        txtSunOT_hrs.ReadOnly = bool
        txtHolOT_hrs.ReadOnly = bool

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

            TabControlProject.SelectedIndex = 0
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try


    End Sub

    'Represent current project information
    Protected Overrides Sub representPrimeInfo()
        Try
            representProject()
            representPosition()
            representDivision()
            controlConcealer()
        Catch appex As MyApplicationException
            writeStatus(appex.Message)
        End Try

    End Sub

    Protected Overrides Sub controlConcealer()
        'WARNING: If the cbox has no selected item. A null reference can occur. However, DBNullToString should do the trick
        Dim key As Object
        Dim keys As ICollection = controlsToConceal.Keys
        Dim cbox As ComboBox
        Dim dtp As DateTimePicker
        Dim lbl As Label
        For Each key In keys
            lbl = CType(controlsToConceal(key), Label)
            If CType(key, Control).Enabled Then
                With lbl
                    .Visible = False
                End With
            Else
                If TypeOf (key) Is ComboBox Then
                    cbox = CType(key, ComboBox)
                    With lbl
                        If cbox.SelectedItem IsNot Nothing Then
                            .Text = DBNullToString(CType(cbox.SelectedItem, DataRowView)("name"))
                            .Visible = True
                        End If
                    End With
                ElseIf TypeOf (key) Is DateTimePicker Then
                    dtp = CType(key, DateTimePicker)
                    With lbl
                        .Text = DBNullToString(dtp.Text)
                        .Visible = True
                    End With
                End If

            End If
        Next

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
                    cbxDivision.SelectedItem = dr  ' CStr(dr("name"))
                End If
            Next
        Catch ex As Exception
            'Do Nothing
        End Try
    End Sub

    Protected Overrides Sub positionChanged() Handles bindSource.PositionChanged
        If isPrimeBound Then
            representPrimeInfo()
            writeStatus("Ready")
            ''Filter children controls
            TabControlProject.SelectedIndex = 0
        End If

    End Sub

    'NOTE: The arrangement of methods in state are important
    Protected Overrides Sub idleState()
        writeStatus("Ready")
        If Not isPrimeBound Then bindMyControls()
        boundedControls_readOnly(True)
        commandButtonsVisible(False)
        hideTabPageDisabler()
        'ENABLE SOME OF THE CONTROLS
        bindNavProject.Enabled = True
        disableOrEnable()
    End Sub

    Protected Overrides Sub addingState()
        writeStatus("Adding new project")
        'Unbound controls
        If isPrimeBound Then unboundMyControls()
        boundedControls_readOnly(False)
        commandButtonsVisible(True)
        addingState_DefaultControls()
        showTabPageDisabler()
        'DISALBE SOME OF THE CONTROLS
        bindNavProject.Enabled = False
    End Sub

    Protected Overrides Sub modifyingState()
        writeStatus("Modifying an existing project")
        'Unbound controls
        If isPrimeBound Then unboundMyControls()
        boundedControls_readOnly(False)
        commandButtonsVisible(True)
        showTabPageDisabler()
        TabControlProject.SelectedIndex = 0
        'DISALBE SOME OF THE CONTROLS
        bindNavProject.Enabled = False
    End Sub

    Protected Overrides Sub addNewPrime()
        Try
            If empNum < 1 Then
                RaiseEvent evStatusMessage("Project must be place on an Employee.")
                Return
            End If
            getProject()

            Dim pm As New ProjectManager
            g_project.project_ID = pm.add(g_project)

            RaiseEvent evPerformedDBOperation(DB_Operation.Create)
            writeStatus("New project was added successfully.")
        Catch appex As MyApplicationException
            writeStatus(AddErrorMsg())
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus(AddErrorMsg())
        End Try

    End Sub

    Protected Overrides Sub updatePrime()
        Try
            getProject()

            Dim pm As New ProjectManager
            pm.update(g_project)

            RaiseEvent evPerformedDBOperation(DB_Operation.Update)
            writeStatus("Updating project successful.")
        Catch appex As MyApplicationException
            writeStatus(ModifyErrorMsg())
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus(ModifyErrorMsg())
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
            bindSource.EndEdit()

            disableOrEnable()
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
            currentRow.EndEdit()
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
        Try
            If bindSource.Current Is Nothing Then Return

            If recordDeletionConfirmed() Then
                Dim pm As New ProjectManager
                Dim i As Integer = pm.delete(getBoundSource_PKey())

                RaiseEvent evPerformedDBOperation(DB_Operation.Delete)
                writeStatus("Project was removed successfully.")
            Else
                writeStatus("Project deletion is cancelled.")
            End If
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus("An error occur while removing project!")
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

End Class