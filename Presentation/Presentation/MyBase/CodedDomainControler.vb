Imports BusinessLogic
Imports CrossCutting
Imports BusinessLogic.BusinessEntity

'This Class contain the primary basic controls needed to operate on the Windows Form and Database
Public Class CodedDomainControler
    ''Events
    Public Event evModifyingRow()
    Public Event evPerformedDBOperation(ByVal dbOperation As DB_Operation)
    Public Event evStatusMessage(ByVal message As String)

    'My Controls
    Private WithEvents bs_current As New BindingSource
    Private WithEvents dt_current As New DataTable
    Private g_currentDomain As New CodedDomain

    Private myCurrentTable As New CodedDomainManager.Tables
    Private dgv_name_HeaderText As String
    Private txtdgvCourier_suspend As Boolean = False

    'Tracks Changes in records to be updated
    Private origDataForUpdate As New Hashtable
    Private newDataForUpdate As New Hashtable
    Private finalDataForUpdate As New Generic.List(Of CodedDomain)

    'UI Controls reference that need live object
    Private WithEvents txtNameToAdd As New TextBox
    Private WithEvents btnAdd As New Button
    Private WithEvents btnDelete As New Button
    Private WithEvents btnUpdate As New Button
    Private WithEvents lblTableTitle As New Label
    Private WithEvents lblRecordCount As New Label
    Private WithEvents tsslblMessage As New ToolStripLabel
    Private WithEvents dgv_current As New DataGridView
    Private WithEvents txtdgvCourier As New TextBox

    Private dgvc_CurrentName As DataGridViewCell

    'Upon construction, initialize ALL its resources
    Sub New(ByVal table As CodedDomainManager.Tables, _
            ByRef txtNameToAdd As TextBox, _
            ByRef btnAdd As Button, _
ByRef btnDelete As Button, _
ByRef btnUpdate As Button, _
ByRef lblTableTitle As Label, _
ByRef lblRecordCount As Label, _
ByRef tsslblMessage As ToolStripLabel, _
ByRef dgvContext As DataGridView, _
ByRef txtdgvCourier As TextBox)

        myCurrentTable = table
        Me.txtNameToAdd = txtNameToAdd
        Me.btnAdd = btnAdd
        Me.btnDelete = btnDelete
        Me.btnUpdate = btnUpdate
        Me.lblTableTitle = lblTableTitle
        Me.lblRecordCount = lblRecordCount
        Me.tsslblMessage = tsslblMessage
        Me.dgv_current = dgvContext
        Me.txtdgvCourier = txtdgvCourier

        Main_DGV_Format()
        initilize_Controller()
    End Sub

    Private Sub initilize_Controller()
        Try
            Dim cm As New CodedDomainManager
            dt_current = cm.retrieveAll(myCurrentTable)
            bs_current.DataSource = dt_current
            dgv_current.DataSource = bs_current
            hideNameTextCourier()
            getRecordCount_Position()
            AddHandler dgv_current.CurrentCellChanged, AddressOf dgv_current_CurrentCellChanged
            'AddHandler dgvPosition.LostFocus, AddressOf hideNameTextCourier
            select_DGV_EnableColumn()
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub getRecordCount_Position()
        If Not bs_current.DataSource Is Nothing Then
            lblRecordCount.Text = CType(bs_current.DataSource, DataTable).Rows.Count & " record/s found"
        End If

    End Sub

    Private Sub txtdgvCourier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdgvCourier.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                RaiseEvent evModifyingRow()
                applyChangesToDGV_name()
            Case Keys.Up
                If dgv_current.CurrentRow.Index > 0 Then
                    dgv_current.Rows(dgv_current.CurrentRow.Index - 1).Cells(1).Selected = True
                End If
            Case Keys.Down
                If dgv_current.CurrentRow.Index < dgv_current.RowCount - 1 Then
                    dgv_current.Rows(dgv_current.CurrentRow.Index + 1).Cells(1).Selected = True
                End If

        End Select

        If Not dgvc_CurrentName Is Nothing AndAlso e.Shift And e.KeyCode = Keys.E Then
            RaiseEvent evModifyingRow()
            Dim enable_currentCell As DataGridViewCell = dgv_current.Item("enable", dgvc_CurrentName.RowIndex)
            enable_currentCell.Value = IIf(CBool(DBNullToNumeric(enable_currentCell.Value)), False, True)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgv_current_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_current.KeyDown
        Try
            If Not dgvc_CurrentName Is Nothing Then
                If e.Shift And e.KeyCode = Keys.E Then
                    RaiseEvent evModifyingRow()
                    Dim enable_currentCell As DataGridViewCell = dgv_current.Item("enable", dgvc_CurrentName.RowIndex)
                    enable_currentCell.Value = IIf(CBool(DBNullToNumeric(enable_currentCell.Value)), False, True)
                    e.SuppressKeyPress = True
                End If
            End If
        Catch ex As Exception
            'Do Nothing
        End Try
        
    End Sub

    Private Sub dgv_current_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Not dgv_current.CurrentRow Is Nothing Then
                Dim currentRowIndex As Integer = dgv_current.CurrentRow.Index
                Dim currentColumnIndex As Integer = dgv_current.CurrentCell.ColumnIndex

                'Gets the current row's name value
                dgvc_CurrentName = dgv_current.Item(1, currentRowIndex)

                'Shows/Hides the text box use in fethcing data from the data grid
                Select Case dgv_current.CurrentCell.ColumnIndex
                    Case 1
                        With txtdgvCourier
                            .BringToFront()
                            .Text = Convert.ToString(dgv_current.Item(currentColumnIndex, currentRowIndex).Value)
                            .Left = dgv_current.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, False).X + dgv_current.Left
                            .Top = dgv_current.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, False).Y + dgv_current.Top
                            .Width = dgv_current.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, False).Width
                            .Height = dgv_current.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, False).Height
                            .Show()
                            .Focus()
                            .SelectAll()
                        End With
                        Exit Select
                    Case Else
                        hideNameTextCourier()
                End Select
            End If
        Catch ex As Exception
            'Do Nothing
        End Try
        
    End Sub

    Private Sub hideNameTextCourier()
        txtdgvCourier.Hide()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim i As Integer = 0
            Dim cm As New CodedDomainManager
            i = cm.update(finalizeDataToUpdate_Position, myCurrentTable)

            RaiseEvent evPerformedDBOperation(DB_Operation.Update)
            RaiseEvent evStatusMessage("Update Successful.")

        Catch bex As BusinessException
            RaiseEvent evStatusMessage(bex.Message)
        Catch daex As DataAccessException
            RaiseEvent evStatusMessage(daex.Message)
        Catch ex As Exception
            RaiseEvent evStatusMessage("An error occur while updating.")
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim cm As New CodedDomainManager
            With g_currentDomain
                .name = txtNameToAdd.Text
                .primaryKey = cm.add(.name, myCurrentTable)
            End With
            RaiseEvent evPerformedDBOperation(DB_Operation.Create)
        Catch bex As BusinessException
            RaiseEvent evStatusMessage(bex.Message)
        Catch daex As DataAccessException
            RaiseEvent evStatusMessage(daex.Message)
        Catch ex As Exception
            RaiseEvent evStatusMessage("An error occur while adding a new record. Please check your input and try again.")
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If recordDeletionConfirmed() Then
                'NUM and STR
                Dim cm As New CodedDomainManager
                cm.delete(CUShort(DBNullToNumeric(dgv_current.Item(0, dgv_current.CurrentRow.Index).Value)), _
                          myCurrentTable)

                RaiseEvent evPerformedDBOperation(DB_Operation.Delete)
            Else
                RaiseEvent evStatusMessage("Record deletion is cancelled.")
            End If
        Catch icex As InvalidCastException
            MyMessageBox.invalidDataType()
            RaiseEvent evStatusMessage("An error occur while deleting a record. Please try again.")
        Catch ofex As OverflowException
            MyMessageBox.outOfRange(UInt16.MaxValue)
            RaiseEvent evStatusMessage("An error occur while deleting a record. Please try again.")
        Catch bex As BusinessException
            RaiseEvent evStatusMessage(bex.Message)
        Catch daex As DataAccessException
            RaiseEvent evStatusMessage(daex.Message)
        Catch ex As Exception
            RaiseEvent evStatusMessage("An error occur while deleting a record. Please try again.")
        End Try
    End Sub

    Private Sub PosisionDB_OperationPerformed(ByVal operationPerformed As DB_Operation) _
    Handles Me.evPerformedDBOperation
        Select Case operationPerformed
            Case DB_Operation.Create
                addSuccess()
            Case DB_Operation.Update
                updateSuccess()
            Case DB_Operation.Delete
                deleteSuccess()
        End Select
    End Sub

    Private Sub addSuccess()
        RemoveHandler dgv_current.CurrentCellChanged, AddressOf dgv_current_CurrentCellChanged
        'Add new user to the underlying data source
        Dim newRow = CType(bs_current.AddNew, DataRowView)
        newRow(getPrimaryKeyIdentifier(myCurrentTable)) = g_currentDomain.primaryKey
        newRow("name") = g_currentDomain.name
        newRow("enable") = True
        newRow("dateCreated") = Now.ToShortDateString
        newRow("lastModified") = Now
        newRow("lastModifiedBy") = getCurrentUser_Username() 'getCurrentUser_UserID()
        bs_current.EndEdit()
        getRecordCount_Position()

        AddHandler dgv_current.CurrentCellChanged, AddressOf dgv_current_CurrentCellChanged

        txtNameToAdd.Clear()
    End Sub

    Private Sub deleteSuccess()
        Dim pKey As UShort = DBNullToNumeric(CType(bs_current.Current, DataRowView) _
                                             (getPrimaryKeyIdentifier(myCurrentTable)))
        'Delete the row on the DataTable
        CType(bs_current.DataSource, DataTable).Rows.RemoveAt(bs_current.Position)
        'Remove the deleted row from the position_oldData to avoid deletion of ghost data from the database
        If origDataForUpdate.ContainsKey(pKey) Then origDataForUpdate.Remove(pKey)
        getRecordCount_Position()

        select_DGV_EnableColumn()
    End Sub

    'Get the original data candidate for an update
    Private Sub getPositionOriginalData() Handles Me.evModifyingRow
        Dim currentRowIndex As Integer = dgv_current.CurrentRow.Index

        Dim pKey_currentCell As DataGridViewCell = dgv_current.Item("id", currentRowIndex)
        Dim name_currentCell As DataGridViewCell = dgv_current.Item("name", currentRowIndex)
        Dim enable_currentCell As DataGridViewCell = dgv_current.Item("enable", currentRowIndex)

        Dim cdomainOrig As New CodedDomain
        cdomainOrig.primaryKey = CShort(pKey_currentCell.Value)
        'Add the propective row to be updated - only fresh rows will be added
        If Not origDataForUpdate.ContainsKey(cdomainOrig.primaryKey) Then
            cdomainOrig.name = CStr(name_currentCell.Value)
            cdomainOrig.enable = CBool(DBNullToNumeric(enable_currentCell.Value))
            origDataForUpdate.Add(cdomainOrig.primaryKey, cdomainOrig)
        End If
    End Sub

    'This will fire the dgvPosition.CellValueChanged event
    Private Sub applyChangesToDGV_name()
        dgvc_CurrentName.Value = txtdgvCourier.Text
        dgv_current.BindingContext(CType(bs_current.DataSource, DataTable)).EndCurrentEdit()
    End Sub

    'Use by the check box column state change event
    Private Sub dgv_current_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_current.CurrentCellDirtyStateChanged
        If dgv_current.IsCurrentCellDirty Then
            RaiseEvent evModifyingRow()
            'This will fire the dgvPosition.CellValueChanged event
            dgv_current.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub trackChanges(ByVal sender As Object, _
    ByVal e As DataGridViewCellEventArgs) Handles dgv_current.CellValueChanged

        Dim pKey_currentCell As DataGridViewCell = dgv_current.Item("id", e.RowIndex)
        Dim name_currentCell As DataGridViewCell = dgv_current.Item("name", e.RowIndex)
        Dim enable_currentCell As DataGridViewCell = dgv_current.Item("enable", e.RowIndex)

        'Gets the row `enable` value
        Dim isCurrentRowEnable As Boolean = CBool(DBNullToNumeric(enable_currentCell.Value))

        'Set and Add the value of rows subject to be updated
        Dim cdomainNew As CodedDomain
        If Not newDataForUpdate.ContainsKey(pKey_currentCell.Value) Then
            cdomainNew = New CodedDomain
            cdomainNew.primaryKey = CShort(pKey_currentCell.Value)
            cdomainNew.name = CStr(name_currentCell.Value)
            cdomainNew.enable = isCurrentRowEnable
            newDataForUpdate.Add(cdomainNew.primaryKey, cdomainNew)
        Else
            cdomainNew = newDataForUpdate.Item(pKey_currentCell.Value)
            'Check if needs to overwrite current data
            If Not cdomainNew.name.Equals(CStr(name_currentCell.Value)) Then
                cdomainNew.name = CStr(name_currentCell.Value)
            End If

            If Not cdomainNew.enable = isCurrentRowEnable Then
                cdomainNew.enable = isCurrentRowEnable
            End If

        End If

        ''Not neccessary since this just fetches data
        'dgvPosition.Invalidate()

        If e.ColumnIndex = 1 Then
            If dgv_current.CurrentRow.Index < dgv_current.RowCount - 1 Then
                dgv_current.Rows(dgv_current.CurrentRow.Index + 1).Cells(1).Selected = True
            End If
        End If
    End Sub

    'Checks if an update is needed to the database
    Private Function finalizeDataToUpdate_Position() As Generic.List(Of CodedDomain)
        Dim cdomainList As New Generic.List(Of CodedDomain)
        Dim val As CodedDomain
        Dim toUpdate As CodedDomain
        Dim values As ICollection = origDataForUpdate.Values
        For Each value In values
            val = CType(value, CodedDomain)
            toUpdate = CType(newDataForUpdate.Item(val.primaryKey), CodedDomain)
            If Not val.name.Equals(toUpdate.name) Or Not val.enable = toUpdate.enable Then
                cdomainList.Add(toUpdate)
            End If
        Next
        finalDataForUpdate = cdomainList
        Return cdomainList
    End Function

    'Call this only in successful updates
    Private Sub updateSuccess()
        'Update position underlying data source
        Dim x As Integer = 0
        For Each cd As CodedDomain In finalDataForUpdate
            For Each dr As DataRow In CType(bs_current.DataSource, DataTable).Rows
                If CInt(DBNullToNumeric(dr(getPrimaryKeyIdentifier(myCurrentTable)))) = cd.primaryKey Then
                    dr.BeginEdit()
                    dr("lastModified") = Now
                    dr("lastModifiedBy") = getCurrentUser_Username()  'getCurrentUser_UserID()
                    dr.EndEdit()
                    Exit For
                End If
            Next
        Next

        'Make the newly updated data the original
        origDataForUpdate.Clear()
        newDataForUpdate.Clear()
        finalDataForUpdate.Clear()
    End Sub

    Private Sub select_DGV_EnableColumn()
        Try
            If Not dgv_current.CurrentRow Is Nothing Then
                dgv_current.Item(2, dgv_current.CurrentRow.Index).Selected = True
            End If
        Catch ex As Exception
            'Do Nothing
        End Try

    End Sub

    Private Sub Main_DGV_Format()
        With dgv_current
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.RowTemplate.Height = 
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False  'flag
            .AllowUserToAddRows = False     'flag
            .ReadOnly = False                'flag : True
            .MultiSelect = False
            .Font = New Font(New FontFamily("tahoma"), 10, FontStyle.Regular)
            .Columns.Clear()
            Dim ColumnID As New DataGridViewTextBoxColumn
            With ColumnID
                .DataPropertyName = getPrimaryKeyIdentifier(myCurrentTable)
                .Name = "id"
                .HeaderText = "ID"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnID)
            Dim ColumnName As New DataGridViewTextBoxColumn
            With ColumnName
                .DataPropertyName = "name"
                .Name = "name"
                .HeaderText = TableNameToString(myCurrentTable)
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 175
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnName)
            Dim ColumnEnable As New DataGridViewCheckBoxColumn()
            With ColumnEnable
                .DataPropertyName = "enable"
                .Name = "enable"
                .HeaderText = "Enable"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .FlatStyle = FlatStyle.Standard
                .CellTemplate = New DataGridViewCheckBoxCell()
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 70
            End With
            .Columns.Add(ColumnEnable)
            Dim ColumnDateCreated As New DataGridViewTextBoxColumn
            With ColumnDateCreated
                .DataPropertyName = "dateCreated"
                .Name = "dateCreated"
                .HeaderText = "Date Created"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 130
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnDateCreated)
            Dim ColumnLastModified As New DataGridViewTextBoxColumn
            With ColumnLastModified
                .DataPropertyName = "lastModified"
                .Name = "lastModified"
                .HeaderText = "Last Modified"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 170
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnLastModified)
            Dim ColumnLastModifiedBy As New DataGridViewTextBoxColumn
            With ColumnLastModifiedBy
                .DataPropertyName = "lastModifiedBy"
                .Name = "lastModifiedBy"
                .HeaderText = "Last Modified By"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 150
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnLastModifiedBy)
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

    Private Function getPrimaryKeyIdentifier(ByVal table As CodedDomainManager.Tables) As String
        Select Case table
            Case CodedDomainManager.Tables.UserType
                Return "userTypeCode"
            Case CodedDomainManager.Tables.Division
                Return "div_ID"
            Case CodedDomainManager.Tables.Position
                Return "position_ID"
            Case CodedDomainManager.Tables.BonusType
                Return "bonusTypeCode"
            Case CodedDomainManager.Tables.DeductionType
                Return "deductTypeCode"
            Case CodedDomainManager.Tables.AllowanceType
                Return "allowTypeCode"
            Case Else
                Throw New BusinessException("Invalid Selection")
        End Select
    End Function

    Private Function TableNameToString(ByVal table As CodedDomainManager.Tables) As String
        Select Case table
            Case CodedDomainManager.Tables.UserType
                Return "User Type"
            Case CodedDomainManager.Tables.Division
                Return "Division"
            Case CodedDomainManager.Tables.Position
                Return "Position"
            Case CodedDomainManager.Tables.BonusType
                Return "Bonus Type"
            Case CodedDomainManager.Tables.DeductionType
                Return "Deduction Type"
            Case CodedDomainManager.Tables.AllowanceType
                Return "Allowance Type"
            Case Else
                Throw New BusinessException("Invalid Selection")
        End Select
    End Function
End Class