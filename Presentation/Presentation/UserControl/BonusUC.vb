Imports BusinessLogic
Imports CrossCutting
Imports BusinessLogic.BusinessEntity
Imports DataAccess

Public Class BonusUC
    ''Events
    Public Event evModifyingRow()
    Public Event evPerformedDBOperation(ByVal dbOperation As DB_Operation)
    Public Event evStatusMessage(ByVal message As String)

    'My Controls
    Friend WithEvents bsContext As BindingSource
    Private WithEvents dtContext As DataTable
    Private g_Bonus As New Bonus
    Private dtDomain As DataTable

    Private myCurrentTable As New Tables

    Private dgvc_currentPKey As DataGridViewCell

    Private _codedDomain_fKey As UInteger
    Public Property codedDomain_fKey() As UInteger
        Get
            Return _codedDomain_fKey
        End Get
        Set(ByVal value As UInteger)
            _codedDomain_fKey = value
        End Set
    End Property

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bsContext = New BindingSource
    End Sub

    Public Sub filterByEmployee(ByVal employeeID As UInteger)
        Try
            If Not bsContext Is Nothing Then
                Me.codedDomain_fKey = employeeID
                bsContext.Filter = "empNum = " & Me.codedDomain_fKey
                getRecordCount()
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Public Sub refilterByEmployee()
        Try
            If Not bsContext Is Nothing Then
                bsContext.Filter = "empNum = " & Me.codedDomain_fKey
                getRecordCount()
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Public Sub initialize_Me(ByVal table As Tables)
        myCurrentTable = table
        ''
        setDisplay()
        initilize_Controller()
    End Sub

    Private Sub setDisplay()
        PanelTitle.Width = dgvContext.Width - 20
        lblTableTitle.Text = "Employee Bonus"
        gbxAddNew.Text = "Add Bonus"
        lblType.Text = "Choose bonus"
    End Sub

    Private Sub initilize_Controller()
        Try
            cbxDomain_Fill()
            Dim bu As New BonusUtility
            dtContext = bu.retrieveAll

            initDGV()
            AddHandler dgvContext.CurrentCellChanged, AddressOf dgv_current_CurrentCellChanged
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DataGrid_refresh()
        Try
            Dim bu As New BonusUtility
            dtContext = bu.retrieveAll

            bsContext.DataSource = dtContext
            dgvContext.DataSource = bsContext
            getRecordCount()
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cbxDomain_Fill()
        Try
            Dim cm As New CodedDomainManager
            dtDomain = cm.retrieveEnabled(CodedDomainManager.Tables.BonusType)
            With cbxBonusType
                .Text = ""
                .DataSource = dtDomain
                .DisplayMember = "name"
                .ValueMember = "bonusTypeCode"
                .Refresh()
            End With
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub initDGV()
        Main_DGV_Format()
        bsContext.DataSource = dtContext
        dgvContext.DataSource = bsContext
        getRecordCount()
    End Sub

    Private Sub getRecordCount()
        If Not bsContext.DataSource Is Nothing Then
            lblRecordCount.Text = bsContext.Count & " record/s found"
        End If

    End Sub

    Private Sub dgvContext_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If Not dgvc_currentPKey Is Nothing Then
                If e.KeyCode = Keys.Delete Then
                    btnDelete.PerformClick()
                End If
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub dgv_current_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Not dgvContext.CurrentRow Is Nothing Then
                Dim currentRowIndex As Integer = dgvContext.CurrentRow.Index
                'Gets the current row's name value
                dgvc_currentPKey = dgvContext.Item(0, currentRowIndex)
            End If
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub writeStatus(ByVal message As String)
        RaiseEvent evStatusMessage(message)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        add()
    End Sub

    Private Sub add()
        Dim msg As String = ""
        Try
            If dtDomain.Rows.Count < 1 Then
                msg = "Bonus type is required."
                writeStatus(msg)
                MyMessageBox.informativeMessage(msg)
                Return
            End If

            If codedDomain_fKey < 1 Then
                msg = "Bonus must be place on an Employee."
                writeStatus(msg)
                MyMessageBox.informativeMessage(msg)
                Return
            End If

            'CHECK FOR DUPLICATION
            If Not isUnique_String(CStr(CType(cbxBonusType.SelectedItem, DataRowView)("name")), "name", CType(bsContext.DataSource, DataTable)) Then
                msg = "Adding bonus failed. Bonus type already exist on this employee."
                writeStatus(msg)
                MyMessageBox.error_customMessage(msg)
                Return
            End If

            Dim bu As New BonusUtility
            With g_Bonus
                .empNum = Me.codedDomain_fKey
                .bonusTypeCode = CShort(DBNullToNumeric(cbxBonusType.SelectedValue))
                .specify = ""
                .amount = CDbl(DBNullToNumeric(txtAmount.Text))
                .remark = ""
                .ID = bu.add(g_Bonus)
            End With

            RaiseEvent evPerformedDBOperation(DB_Operation.Create)
            msg = String.Format("Adding '{0}' successful.", _
                                DBNullToString(CType(cbxBonusType.SelectedItem, DataRowView)("name")))
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
            msg = "An error occur while adding a new bonus."
            writeStatus(msg)
            MyMessageBox.error_customMessage(msg)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        delete()
    End Sub

    Private Sub delete()
        Dim msg As String = ""
        Try
            If dgvContext.CurrentRow Is Nothing Then Return

            If recordDeletionConfirmed() Then
                'NUM and STR
                Dim bu As New BonusUtility
                bu.delete(CUInt(DBNullToNumeric(dgvc_currentPKey.Value)))

                RaiseEvent evPerformedDBOperation(DB_Operation.Delete)
                msg = "Bonus was deleted successfully."
                writeStatus(msg)
                MyMessageBox.success_customMessage(msg)
            Else
                writeStatus("Bonus deletion was cancelled.")
            End If
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            msg = "An error occur while deleting Bonus. Please contact the administrator."
            writeStatus(msg)
            MyMessageBox.error_customMessage(msg)
        End Try
    End Sub

    Private Sub PosisionDB_OperationPerformed(ByVal operationPerformed As DB_Operation) _
    Handles Me.evPerformedDBOperation
        Select Case operationPerformed
            Case DB_Operation.Create
                addSuccess()
            Case DB_Operation.Delete
                deleteSuccess()
        End Select
    End Sub

    Private Sub addSuccess()
        Try
            RaiseEvent evStatusMessage("Adding bonus successful.")
            'Add new user to the underlying data source
            Dim newRow = CType(bsContext.AddNew, DataRowView)
            newRow("ID") = g_Bonus.ID
            newRow("empNum") = codedDomain_fKey
            newRow("name") = CType(cbxBonusType.SelectedItem, DataRowView)("name")
            newRow("amount") = CDbl(DBNullToNumeric(txtAmount.Text))
            newRow("dateCreated") = Now.ToShortDateString
            newRow("lastModifiedBy") = getCurrentUser_Username()
            bsContext.EndEdit()
            getRecordCount()
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub deleteSuccess()
        Try
            bsContext.RemoveCurrent()
            bsContext.EndEdit()
            getRecordCount()
        Catch ex As Exception
            'Log
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub Main_DGV_Format()
        With dgvContext
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.SelectionForeColor = Color.Blue
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .ReadOnly = False
            .MultiSelect = False
            .Font = New Font(New FontFamily("tahoma"), 9, FontStyle.Regular)
            .Columns.Clear()

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
                .Width = 120
                .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnAmount)

            Dim ColumnDateCreated As New DataGridViewTextBoxColumn
            With ColumnDateCreated
                .DataPropertyName = "dateCreated"
                .Name = "dateCreated"
                .HeaderText = "Date Created"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 130
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnDateCreated)

            Dim ColumnLastModifiedBy As New DataGridViewTextBoxColumn
            With ColumnLastModifiedBy
                .DataPropertyName = "lastModifiedBy"
                .Name = "lastModifiedBy"
                .HeaderText = "Created by"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 150
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnLastModifiedBy)

            'Invisible
            Dim ColumnID As New DataGridViewTextBoxColumn
            With ColumnID
                .DataPropertyName = "ID"
                .Name = "id"
                .HeaderText = "Seq #"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnID)

            Dim ColumnEmpNum As New DataGridViewTextBoxColumn
            With ColumnEmpNum
                .DataPropertyName = "empNum"
                .Name = "empNum"
                .HeaderText = "Employee Number"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnEmpNum)
        End With
    End Sub

    Private Function recordDeletionConfirmed() As Boolean
        Dim res As DialogResult = _
        MessageBox.Show("Are you sure you want to delete this row?", _
                        "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Enum Tables
        Bonus
    End Enum

    Private Sub txtAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub cbxBonusType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtAmount.Focus()
        txtAmount.SelectAll()
    End Sub
End Class