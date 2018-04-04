Imports CrossCutting
Imports BusinessLogic
Imports BusinessLogic.BusinessEntity
Imports DataAccess

Public Class frmUser

    Public Event evPerformedDBOperation(ByVal dbOperation As DB_Operation)
    Public Event evUserStatus_Changed(ByVal activate As Boolean)

    Private dtUserType As DataTable
    Private g_user As New User

    Private WithEvents frmChangePass As frmChangePassword

    Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblTitle.Text = "User Master File"
        Me.Text = "User"
        KeyPreview = True
    End Sub

    Private Sub frmUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        functionKey_Press(NavUCMain, e)
    End Sub

    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'INITIALIZE MENU AND NAVIGATION
            'NavUCMain and MenuUCMain cannot put into constructor becoz myManager is not yet set at that moment
            With NavUCMain
                .formManager = Me.myManager
                .myOwner = Me
            End With
            MenuUCMain.myMainForm = Me.myManager

            'Cannot put initializeMyComponent() in constructor coz it issues a connection to the database right away
            'TENTATIVE
            initializeControls()
            initializeMyComponent()
            initializeQuickSearch()
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus("Error while loading User Form")
        End Try

    End Sub

    Private Sub initializeQuickSearch()
        Dim dic As New Dictionary(Of String, DictionaryEntry)
        Dim col1 As New DictionaryEntry
        col1.Key = "user_ID"
        col1.Value = QuickSearchUC.ColumnDataType.iNumeric
        dic.Add("User ID", col1)

        Dim col2 As New DictionaryEntry
        col2.Key = "userName"
        col2.Value = QuickSearchUC.ColumnDataType.iString
        dic.Add("Username", col2)

        ''Dim col3 As New DictionaryEntry
        ''col3.Key = "empNum"
        ''col3.Value = QuickSearchUC.ColumnDataType.iNumeric
        ''dic.Add("Employee Number", col3)

        QuickSearchUCMain.initialize_Me(bindSource, dic)
    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivate.Click
        Try
            Dim isActivated As Boolean = False

            'If user status is Inactivate, the command should activate the user
            If Not CBool(txtStatus.Tag) Then isActivated = True

            Dim um As New UserManager
            um.activate(getBoundSource_PKey, isActivated)

            'Update the bound source and the UI
            Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
            drv.BeginEdit()
            drv("active") = isActivated
            drv.EndEdit()
            representPrimeInfo()

            writeStatus(String.Format("User `{0}` had been {1}", txtUsername.Text, _
                                      IIf(isActivated, "activated", "deactivated")))

            RaiseEvent evUserStatus_Changed(isActivated)
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        End Try
    End Sub

    'UPDATE THE CURRENT USER OF THE APPLICATION? OR CURRENT USER CANNOT CHANGE HER STATUS?
    Private Sub userStatusUpdateSuccessfull(ByVal isActivated As Boolean) _
    Handles Me.evUserStatus_Changed

    End Sub

    'Gets the data needed to insert and update a record
    Private Sub getUser()
        If g_user Is Nothing Then g_user = New User
        Try
            'NUM and STR
            With g_user
                Select Case getMyState
                    Case FormState.Adding
                        .userPassword = txtPassword.Text
                    Case FormState.Modifying
                        .user_ID = getBoundSource_PKey()
                End Select
                'TODO: Get Employee
                .empNum = 0    'Allow changing Employee? This can lead to chaos
                .userName = txtUsername.Text
                .userTypeCode = DBNullToNumeric(cbxUserType.SelectedValue)
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

    Private Sub checkPasswords()
        If Not txtPassword.Text.Equals(txtConfirmPass.Text) Then
            Throw New BusinessException("Passwords does not match. Please Try Again.")
            txtPassword.Focus()
            txtPassword.SelectAll()
        End If

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
        g_user = Nothing

        'Triggers the method inherited from the abstract StateOriented
        DB_OperationPerformed(operationPerformed)
    End Sub

    Private Sub deleteSuccess()
        Try
            bindSource.RemoveCurrent()
            bindSource.EndEdit()
            representPrimeInfo()
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub getRecordCount()
        If Not bindSource.DataSource Is Nothing Then
            writeStatus(bindSource.Count & " record/s found")
        End If

    End Sub

    Private Sub writeStatus(ByVal message As String) Handles frmChangePass.evStatusMessage, QuickSearchUCMain.evStatusMessage
        StatusStripUC1.writeStatus(message)
    End Sub

#Region "Set Display"
    Private Sub AdminControlsHandler()
        'if the user is not an administrative type, hide this button
        If isAdmin(CurrentUser) Then
            btnActivate.Visible = True
        Else
            btnActivate.Visible = False
        End If

    End Sub

    Private Sub frmUser_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Presentation_Mod.displayCompanyName(lblCompanyName)
        setMyCurrentUser()
    End Sub

    'THIS SUB CAN USE ON ALL FORMS TO UPDATE THEIR DATA BY USING SINGLE EVENT ON THE FormManager
    Public Sub setMyCurrentUser()
        displayCurrentUser(lblUser)
        AdminControlsHandler()
    End Sub
#End Region

#Region "State Oriented"
    Protected Overrides Sub initializeMyComponent()
        Try
            addControlToConceal(cbxUserType)
            'SET BUTTONS For State
            myBtnAdd = tsbtnAdd
            myBtnModify = tsbtnEdit
            myBtnSave = btnSave
            myBtnCancel = btnCancel

            'DATA SOURCE AND BINDINGS
            Dim um As New BusinessLogic.UserManager
            dtPrimeDS = um.retrieveAll
            'With dvPrimeDS
            '    .AllowNew = True
            '    .AllowEdit = True
            '    .AllowDelete = True
            'End With

            bindSource = New BindingSource()
            With bindSource
                .AllowNew = True
                .DataSource = dtPrimeDS
            End With

            BindingNavigator1.BindingSource = bindSource

            idleState()
        Catch daex As DataAccessException
            Throw daex
            'writeStatus(daex.Message)
        End Try
    End Sub

    Protected Overrides Sub initializeControls()
        Try
            Dim cd As New CodedDomainManager
            dtUserType = cd.retrieveAll(CodedDomainManager.Tables.UserType)
            With cbxUserType
                .DataSource = dtUserType
                .ValueMember = "userTypeCode"
                .DisplayMember = "name"
            End With
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus(ex.Message)
        End Try
    End Sub

    Protected Overrides Sub bindMyControls()
        'USER
        Try
            If Not bindSource Is Nothing Then
                txtUserID.DataBindings.Add("text", bindSource, "user_ID")
                txtUsername.DataBindings.Add("text", bindSource, "userName")
                txtPassword.DataBindings.Add("text", bindSource, "userPassword")
                'CANNOT REPRESENT DATA - another conversion is use when representing.
                'cbxUserType.DataBindings.Add("tag", bindSource, "userTypeCode")
                txtDateCreated.DataBindings.Add("text", bindSource, "dateCreated")
                txtStatus.DataBindings.Add("tag", bindSource, "active")

                addBoundedControl(txtUserID, txtUsername, txtPassword, _
                                  txtDateCreated, txtStatus)
                isPrimeBound = True
                positionChanged()
            End If
        Catch ex As Exception
            'DISABLE SOME OF THE CONTROLS TO SUPPRESS ERRORS
            writeStatus("An error occured while binding the data to the data source.")
        End Try

    End Sub

    'Use by 3 states
    Protected Overrides Sub boundedControls_readOnly(ByVal bool As Boolean)
        'txtUserID.ReadOnly = bool
        txtUsername.ReadOnly = bool
        'txtPassword.ReadOnly = bool
        'txtDateCreated.ReadOnly = bool
        'txtStatus.ReadOnly = bool
        cbxUserType.Enabled = IIf(bool, False, True)

        If getMyState = FormState.Adding Then
            txtPassword.ReadOnly = False
            txtConfirmPass.ReadOnly = False
        Else
            txtPassword.ReadOnly = True
            txtConfirmPass.ReadOnly = True
        End If

    End Sub

    Protected Overrides Sub addingState_DefaultControls()
        txtUserID.Text = "[Auto]"
        txtUsername.Clear()
        txtPassword.Clear()
        txtConfirmPass.Clear()
        cbxUserType.SelectedIndex = 1
        txtDateCreated.Clear()
        txtStatus.Text = "Active"
        txtUsername.Focus()
    End Sub

    'Represent current user information
    Protected Overrides Sub representPrimeInfo()
        Try
            If bindSource.Current Is Nothing Then
                writeStatus("No record found.")
                Return
            End If
            'User Type
            cbxUserType.SelectedIndex = cbxUserType.FindStringExact(convUTCToString(DBNullToNumeric(CType(bindSource.Current, DataRowView)("userTypeCode"))))
            controlConcealer()

            'User Status
            Dim active As Boolean = CBool(CType(bindSource.Current, DataRowView)("active"))
            txtStatus.Text = convUserActiveToString(CUShort(active))
            If active Then
                btnActivate.Text = "D&eactivate"
            Else
                btnActivate.Text = "&Activate"
            End If
        Catch appex As MyApplicationException
            writeStatus(appex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
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
                        .Text = DBNullToString(CType(cbox.SelectedItem, DataRowView)("name"))
                        .Visible = True
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

    Protected Overrides Sub positionChanged() Handles bindSource.PositionChanged
        If isPrimeBound Then
            representPrimeInfo()
            writeStatus("Ready")
        End If

    End Sub

    'NOTE: The arrangement of methods in state subs are important
    Protected Overrides Sub idleState()
        writeStatus("Ready")
        If Not isPrimeBound Then bindMyControls()
        boundedControls_readOnly(True)
        commandButtonsVisible(False)
        'ENABLE SOME OF THE CONTROLS
        BindingNavigator1.Enabled = True
        QuickSearchUCMain.Enabled = True
        btnChangePass.Enabled = True
        btnActivate.Visible = True
    End Sub

    Protected Overrides Sub addingState()
        writeStatus("Adding new User")
        'Unbound controls
        If isPrimeBound Then unboundMyControls()
        boundedControls_readOnly(False)
        commandButtonsVisible(True)
        addingState_DefaultControls()
        'DISALBE SOME OF THE CONTROLS
        BindingNavigator1.Enabled = False
        QuickSearchUCMain.Enabled = False
        btnChangePass.Enabled = False
        btnActivate.Visible = False
    End Sub

    Protected Overrides Sub modifyingState()
        writeStatus("Modifying a User")
        'Unbound controls
        If isPrimeBound Then unboundMyControls()
        boundedControls_readOnly(False)
        commandButtonsVisible(True)
        'DISALBE SOME OF THE CONTROLS
        BindingNavigator1.Enabled = False
        QuickSearchUCMain.Enabled = False
        btnChangePass.Enabled = False
        btnActivate.Visible = True
        AdminControlsHandler()
        txtUsername.Focus()
    End Sub

    Protected Overrides Sub addNewPrime()
        Try
            checkPasswords()
            getUser()

            Dim um As New UserManager
            g_user.user_ID = um.add(g_user)

            Dim msg As String = String.Format("'{0}' was added successfully.", g_user.userName)
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
            getUser()

            Dim um As New UserManager
            um.update(g_user)

            Dim msg As String = "Updating user successful."
            RaiseEvent evPerformedDBOperation(DB_Operation.Update)

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
            newRow("user_ID") = g_user.user_ID
            newRow("userName") = g_user.userName
            newRow("userPassword") = g_user.userPassword
            newRow("userTypeCode") = g_user.userTypeCode
            newRow("dateCreated") = Now
            newRow("active") = True
            bindSource.EndEdit()

            txtConfirmPass.Clear()
            QuickSearchUCMain.refill_autoComplete()
        Catch ex As Exception
            'Do Nothing
        End Try
        
    End Sub

    Protected Overrides Sub modifyingSuccess()
        Try
            'Update user from the underlying data source
            Dim currentRow = CType(bindSource.Current, DataRowView)
            currentRow.BeginEdit()
            currentRow("userName") = g_user.userName
            currentRow("userTypeCode") = g_user.userTypeCode
            currentRow.EndEdit()
            QuickSearchUCMain.refill_autoComplete()
        Catch ex As Exception
            'Do Nothing
        End Try
    End Sub

    Protected Overrides Function getBoundSource_PKey() As UInt32
        Try
            If Not bindSource Is Nothing Then
                Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
                Return CUInt(DBNullToNumeric(drv("user_ID")))
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
        Return 0
    End Function

#End Region

    Private Sub btnChangePass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePass.Click
        frmChangePass = New frmChangePassword
        Try
            Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
            frmChangePass.CurrentPassword = CStr(drv("userPassword"))
            frmChangePass.CurrentUser_ID = CUInt(drv("user_ID"))
            frmChangePass.setCurrentRow(drv)
            frmChangePass.ShowDialog()
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub tsbtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbtnDelete.Click
        delete_user()
    End Sub

    Private Sub delete_user()
        Dim msg As String = ""
        Try
            If bindSource.Current Is Nothing Then Return

            If recordDeletionConfirmed() Then
                'NUM and STR
                Dim user_ID As UInteger = CUInt(DBNullToNumeric(CType(bindSource.Current, DataRowView)("user_ID")))
                Dim um As New UserManager
                Dim i As Integer = um.delete(user_ID)

                RaiseEvent evPerformedDBOperation(DB_Operation.Delete)
                msg = "User deleted successfully."
                writeStatus(msg)
                MyMessageBox.success_customMessage(msg)
            Else
                msg = "Record deletion is cancelled."
                writeStatus(msg)
            End If
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            msg = "An error occur while deleting user."
            writeStatus(msg)
            MyMessageBox.error_customMessage(msg)
        End Try
    End Sub

    Private Function recordDeletionConfirmed() As Boolean
        Dim res As DialogResult = _
        MessageBox.Show("Are you sure you want to delete this user?", _
                        "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function


End Class