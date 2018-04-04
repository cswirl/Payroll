Imports BusinessLogic
Imports CrossCutting
Imports BusinessLogic.BusinessEntity
Imports DataAccess

Public Class CodedDomainUC
    ''Events
    Public Event evModifyingRow()
    Public Event evPerformedDBOperation(ByVal dbOperation As DB_Operation)
    Public Event evStatusMessage(ByVal message As String)

    'My Controls
    Friend WithEvents bsContext As New BindingSource
    Private WithEvents dtContext As New DataTable
    Private g_DomainContext As New CodedDomain

    Private myCurrentTable As New CodedDomainManager.Tables
    Private dgv_name_HeaderText As String
    Private txtdgvCourier_suspend As Boolean = False

    'Tracks Changes in records to be updated
    Private origDataForUpdate As New Hashtable
    Private newDataForUpdate As New Hashtable
    Private finalDataForUpdate As New Generic.List(Of CodedDomain)

    Private dgvc_CurrentName As DataGridViewCell

    Public Sub initialize_Me(ByVal table As CodedDomainManager.Tables)
        myCurrentTable = table
        'dgvContext = New DataGridView
        Main_DGV_Format()
        initilize_Controller()
        PanelTitle.Width = dgvContext.Width - 18
        lblTableTitle.Text = CodedDomainManager.TableNameToString(myCurrentTable) & " Table"
        gbxTitle.Text = "Add new " & CodedDomainManager.TableNameToString(myCurrentTable)
    End Sub

    Private Sub initilize_Controller()
        Try
            'Me.Invalidate()
            Dim cm As New CodedDomainManager
            dtContext = cm.retrieveAll(myCurrentTable)
            bsContext.DataSource = dtContext
            dgvContext.DataSource = bsContext

            hideNameTextCourier()
            getRecordCount()
            AddHandler dgvContext.CurrentCellChanged, AddressOf dgv_current_CurrentCellChanged
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

    Private Sub getRecordCount()
        If Not bsContext.DataSource Is Nothing Then
            lblRecordCount.Text = bsContext.Count & " record/s found"
        End If

    End Sub

    Private Sub txtdgvCourier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdgvCourier.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    'Skip these commands if 'blank' or equal to the original data
                    If txtdgvCourier.Text.Length > 0 And Not txtdgvCourier.Text.Equals(dgvc_CurrentName.Value) Then
                        If isUnique_String(Trim(txtdgvCourier.Text), "name", dtContext) Then
                            RaiseEvent evModifyingRow()
                            applyChangesToDGV_name()
                        Else
                            RaiseEvent evStatusMessage("Duplicate data ont the data source. Please 'Update' the data source.")
                        End If
                    End If

                    If dgvContext.CurrentCell.ColumnIndex = 1 Then
                        'If the cursor is ON the last row, put the cursor next(right) to the current column
                        If dgvContext.CurrentRow.Index = dgvContext.RowCount - 1 Then
                            txtdgvCourier.Hide()
                            dgvContext.Rows(dgvContext.CurrentRow.Index).Cells(2).Selected = True
                            'If the cursor is NOT on the last row, put the cursor below the current row
                        ElseIf dgvContext.CurrentRow.Index < dgvContext.RowCount - 1 Then
                            dgvContext.Rows(dgvContext.CurrentRow.Index + 1).Cells(1).Selected = True
                        End If

                    End If

                Case Keys.Up
                    If dgvContext.CurrentRow.Index > 0 Then
                        dgvContext.Rows(dgvContext.CurrentRow.Index - 1).Cells(1).Selected = True
                    End If
                Case Keys.Down
                    If dgvContext.CurrentRow.Index < dgvContext.RowCount - 1 Then
                        dgvContext.Rows(dgvContext.CurrentRow.Index + 1).Cells(1).Selected = True
                    End If

            End Select

            If Not dgvc_CurrentName Is Nothing AndAlso e.Control And e.KeyCode = Keys.E Then
                RaiseEvent evModifyingRow()
                Dim enable_currentCell As DataGridViewCell = dgvContext.Item("enable", dgvc_CurrentName.RowIndex)
                'Invert the value of 'enable' field
                enable_currentCell.Value = IIf(CBool(DBNullToNumeric(enable_currentCell.Value)), False, True)
                e.SuppressKeyPress = True
            End If

        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Public Sub refreshDataFromDatabase()
        MyMessageBox.error_customMessage("A 'Duplicate data' error occured while updating at the database level. Some data may not be updated." & _
                                   vbCrLf & "You may want to update data one(1) at a time to resolve this kind of problem." & _
                                   vbCrLf & vbCrLf & "Data will now be refreshed from the Database.")
        initilize_Controller()
        Invalidate()
        'Clear the temporary data
        origDataForUpdate.Clear()
        newDataForUpdate.Clear()
        finalDataForUpdate.Clear()

        RaiseEvent evStatusMessage("Ready.")
    End Sub

    Private Sub dgv_current_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvContext.KeyDown
        Try
            If Not dgvc_CurrentName Is Nothing Then
                If e.Control And e.KeyCode = Keys.E Then
                    RaiseEvent evModifyingRow()
                    Dim enable_currentCell As DataGridViewCell = dgvContext.Item("enable", dgvc_CurrentName.RowIndex)
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
            If Not dgvContext.CurrentRow Is Nothing Then
                Dim currentRowIndex As Integer = dgvContext.CurrentRow.Index
                Dim currentColumnIndex As Integer = dgvContext.CurrentCell.ColumnIndex

                'Gets the current row's name value
                dgvc_CurrentName = dgvContext.Item(1, currentRowIndex)

                'Shows/Hides the text box use in fethcing data from the data grid
                Select Case dgvContext.CurrentCell.ColumnIndex
                    Case 1
                        With txtdgvCourier
                            .BringToFront()
                            .Text = Convert.ToString(dgvContext.Item(currentColumnIndex, currentRowIndex).Value)
                            .Left = dgvContext.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, False).X + dgvContext.Left
                            .Top = dgvContext.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, False).Y + dgvContext.Top
                            .Width = dgvContext.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, False).Width
                            .Height = dgvContext.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, False).Height
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
        updatePrime()
    End Sub

    Private Sub updatePrime()
        Dim msg As String = ""
        Try
            If bsContext.Current Is Nothing Then Return

            Dim i As Integer = 0
            Dim cm As New CodedDomainManager
            i = cm.update(finalizeDataToUpdate_Position, myCurrentTable)

            If i = 0 Then
                msg = "There are no changes made on the records. Press 'ENTER' on the record you wish to modify."
                writeStatus(msg)
                MyMessageBox.success_customMessage(msg)
                Return
            End If

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
            msg = "An error occur while updating."
            writeStatus(msg)
            MyMessageBox.error_customMessage(msg)
            refreshDataFromDatabase()
        End Try

    End Sub

    Private Sub writeStatus(ByVal message As String)
        RaiseEvent evStatusMessage(message)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        addPrime()
    End Sub

    Private Sub addPrime()
        Dim msg As String = ""
        Try
            If txtName.Text.Length < 1 Then
                msg = String.Format("{0} name is required.", CodedDomainManager.TableNameToString(myCurrentTable))
                writeStatus(msg)
                MyMessageBox.informativeMessage(msg)
                Return
            End If

            Dim cm As New CodedDomainManager
            With g_DomainContext
                .name = txtName.Text
                .primaryKey = cm.add(.name, myCurrentTable)
            End With

            RaiseEvent evPerformedDBOperation(DB_Operation.Create)
            msg = String.Format("'{0}' was added successfully.", g_DomainContext.name)
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
            msg = "An error occur while adding a new record. Please check your input and try again."
            writeStatus(msg)
            MyMessageBox.error_customMessage(msg)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        deletePrime()
    End Sub

    Private Sub deletePrime()
        Dim msg As String = ""
        Try
            If bsContext.Current Is Nothing Then Return
            If recordDeletionConfirmed() Then
                'NUM and STR
                Dim cm As New CodedDomainManager
                cm.delete(CUShort(DBNullToNumeric(dgvContext.Item(0, dgvContext.CurrentRow.Index).Value)), _
                          myCurrentTable)

                RaiseEvent evPerformedDBOperation(DB_Operation.Delete)
                msg = "Record was deleted successfully."
                writeStatus(msg)
                MyMessageBox.success_customMessage(msg)
            Else
                RaiseEvent evStatusMessage("Record deletion is cancelled.")
            End If
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            msg = "An error occur while deleting a record. Please try again."
            writeStatus(msg)
            MyMessageBox.error_customMessage(msg)
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
        Try
            RemoveHandler dgvContext.CurrentCellChanged, AddressOf dgv_current_CurrentCellChanged
            'Add new user to the underlying data source
            Dim newRow As DataRowView = CType(bsContext.AddNew, DataRowView)
            newRow(CodedDomainManager.getPrimaryKeyIdentifier(myCurrentTable)) = g_DomainContext.primaryKey
            newRow("name") = g_DomainContext.name
            newRow("enable") = True
            newRow("dateCreated") = Now.ToShortDateString
            newRow("lastModified") = Now
            newRow("lastModifiedBy") = getCurrentUser_Username() 'getCurrentUser_UserID()
            bsContext.EndEdit()
            getRecordCount()

            AddHandler dgvContext.CurrentCellChanged, AddressOf dgv_current_CurrentCellChanged
            txtName.Clear()
            txtdgvCourier.Hide()
            dgvContext.Rows(dgvContext.CurrentRow.Index).Cells(2).Selected = True
        Catch ex As Exception
            'Log
            DataAccess.Bugs_DAO.log(ex)
        End Try

    End Sub

    Private Sub deleteSuccess()
        Dim pKey As UShort = DBNullToNumeric(CType(bsContext.Current, DataRowView) _
                                             (CodedDomainManager.getPrimaryKeyIdentifier(myCurrentTable)))
        'Delete the row on the DataTable
        CType(bsContext.DataSource, DataTable).Rows.RemoveAt(bsContext.Position)
        'Remove the deleted row from the position_oldData to avoid deletion of ghost data from the database
        If origDataForUpdate.ContainsKey(pKey) Then origDataForUpdate.Remove(pKey)
        getRecordCount()

        select_DGV_EnableColumn()
        txtdgvCourier.Hide()
    End Sub

    'Get the original data candidate for an update
    Private Sub getPositionOriginalData() Handles Me.evModifyingRow
        'Dim drv As DataRowView = CType(bsContext.Current, DataRowView)
        'Dim pKey As UShort = CShort(drv(CodedDomainManager.getPrimaryKeyIdentifier(myCurrentTable)))
        'Dim name As String = CStr(drv("name"))
        'Dim enable As Boolean = CBool(DBNullToNumeric(drv("enable")))

        Dim currentRowIndex As Integer = dgvContext.CurrentRow.Index

        Dim pKey_currentCell As DataGridViewCell = dgvContext.Item("id", currentRowIndex)
        Dim name_currentCell As DataGridViewCell = dgvContext.Item("name", currentRowIndex)
        Dim enable_currentCell As DataGridViewCell = dgvContext.Item("enable", currentRowIndex)

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
        dgvContext.BindingContext(CType(bsContext.DataSource, DataTable)).EndCurrentEdit()
    End Sub

    'Use by the check box column state change event
    Private Sub dgv_current_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvContext.CurrentCellDirtyStateChanged
        If dgvContext.IsCurrentCellDirty Then
            RaiseEvent evModifyingRow()
            'This will fire the dgvPosition.CellValueChanged event
            dgvContext.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub trackChanges(ByVal sender As Object, _
    ByVal e As DataGridViewCellEventArgs) Handles dgvContext.CellValueChanged

        Dim pKey_currentCell As DataGridViewCell = dgvContext.Item("id", e.RowIndex)
        Dim name_currentCell As DataGridViewCell = dgvContext.Item("name", e.RowIndex)
        Dim enable_currentCell As DataGridViewCell = dgvContext.Item("enable", e.RowIndex)

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
    End Sub

    'Checks if an update is needed to the database
    Private Function finalizeDataToUpdate_Position() As Generic.List(Of CodedDomain)
        Dim cdomainList As New Generic.List(Of CodedDomain)
        Dim val As CodedDomain
        Dim orig As CodedDomain
        Dim values As ICollection = newDataForUpdate.Values
        For Each value In values
            val = CType(value, CodedDomain)
            'It is expected that an identical primary key is present to both hash table
            orig = CType(origDataForUpdate.Item(val.primaryKey), CodedDomain)
            'Compare the new data for update against the original data
            If Not val.name.Equals(orig.name) Or Not val.enable = orig.enable Then
                cdomainList.Add(val)
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
            For Each dr As DataRow In CType(bsContext.DataSource, DataTable).Rows
                If CInt(DBNullToNumeric(dr(CodedDomainManager.getPrimaryKeyIdentifier(myCurrentTable)))) = cd.primaryKey Then
                    dr.BeginEdit()
                    dr("name") = cd.name
                    dr("enable") = cd.enable
                    dr("lastModified") = Now
                    dr("lastModifiedBy") = getCurrentUser_Username()
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
            If Not dgvContext.CurrentRow Is Nothing Then
                dgvContext.Item(2, dgvContext.CurrentRow.Index).Selected = True
            End If
        Catch ex As Exception
            'Do Nothing
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
            .AllowUserToDeleteRows = False  'flag
            .AllowUserToAddRows = False     'flag
            .ReadOnly = False                'flag : True
            .MultiSelect = False
            .Font = New Font(New FontFamily("tahoma"), 10, FontStyle.Regular)
            .Columns.Clear()

            Dim ColumnName As New DataGridViewTextBoxColumn
            With ColumnName
                .DataPropertyName = "name"
                .Name = "name"
                .HeaderText = CodedDomainManager.TableNameToString(myCurrentTable)
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
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

            'Invisible
            Dim ColumnID As New DataGridViewTextBoxColumn
            With ColumnID
                .DataPropertyName = CodedDomainManager.getPrimaryKeyIdentifier(myCurrentTable)
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

    Private Sub txtDomainName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
        End If
    End Sub

End Class