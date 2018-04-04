Imports CrossCutting
Imports MySql.Data.MySqlClient
Imports DataAccess

Public Class SSS_UC

    Private dsSSS As DataSet
    Private daSSS As MySqlDataAdapter

    Public Event evStatusMessage(ByVal msg As String)

    Public Sub initializeMe()
        Try
            dgv_format()
            getDataSources()
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub getDataSources()
        Try
            Dim sssDAO As New SSS_DAO
            dsSSS = sssDAO.retrieveAll(daSSS)

            dgvSSS.DataSource = dsSSS.Tables(0)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw New Exception("An error occur while getting datasources.")
        End Try
    End Sub

    Private Sub dgv_format()
        With dgvSSS
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
            Dim ColumnSSS_ID As New DataGridViewTextBoxColumn
            With ColumnSSS_ID
                .DataPropertyName = "ID"
                .Name = "ID"
                .HeaderText = "SSS_ID"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnSSS_ID)

            Dim ColumnFrom As New DataGridViewTextBoxColumn()
            With ColumnFrom
                .DataPropertyName = "rangeFrom"
                .Name = "rangeFrom"
                .HeaderText = "From"
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 85
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightGray
            End With
            .Columns.Add(ColumnFrom)

            Dim ColumnTo As New DataGridViewTextBoxColumn
            With ColumnTo
                .DataPropertyName = "rangeTo"
                .Name = "rangeTo"
                .HeaderText = "To"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 85
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightGray
            End With
            .Columns.Add(ColumnTo)

            Dim ColumnER_1 As New DataGridViewTextBoxColumn
            With ColumnER_1
                .DataPropertyName = "er_1"
                .Name = "er_1"
                .HeaderText = "ER_1"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 80
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(ColumnER_1)

            Dim ColumnEE_1 As New DataGridViewTextBoxColumn
            With ColumnEE_1
                .DataPropertyName = "ee_1"
                .Name = "ee_1"
                .HeaderText = "EE_1"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 70
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(ColumnEE_1)

            Dim ColumnTotal_1 As New DataGridViewTextBoxColumn
            With ColumnTotal_1
                .DataPropertyName = "total_1"
                .Name = "total_1"
                .HeaderText = "Total_1"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightSalmon
            End With
            .Columns.Add(ColumnTotal_1)

            Dim ColumnER_2 As New DataGridViewTextBoxColumn
            With ColumnER_2
                .DataPropertyName = "er_2"
                .Name = "er_2"
                .HeaderText = "ER_2 "
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 70
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(ColumnER_2)

            Dim ColumnER_3 As New DataGridViewTextBoxColumn
            With ColumnER_3
                .DataPropertyName = "er_3"
                .Name = "er_3"
                .HeaderText = "ER_3 "
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 80
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightGray
            End With
            .Columns.Add(ColumnER_3)

            Dim ColumnEE_2 As New DataGridViewTextBoxColumn
            With ColumnEE_2
                .DataPropertyName = "ee_2"
                .Name = "ee_2 "
                .HeaderText = "EE_2 "
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightGray
            End With
            .Columns.Add(ColumnEE_2)

            Dim ColumnTotal_2 As New DataGridViewTextBoxColumn
            With ColumnTotal_2
                .DataPropertyName = "total_2"
                .Name = "total_2"
                .HeaderText = "Total_2"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 70
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightSalmon
            End With
            .Columns.Add(ColumnTotal_2)

            Dim ColumnTotal_contri As New DataGridViewTextBoxColumn
            With ColumnTotal_contri
                .DataPropertyName = "total_contri"
                .Name = "total_contri"
                .HeaderText = "Total_Contri"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 80
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightSalmon
            End With
            .Columns.Add(ColumnTotal_contri)
        End With
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            dgvSSS.EndEdit()
            daSSS.Update(dsSSS.Tables(0))

            'update the ui
            getDataSources()
            Messages.SuccessMessage("Updating SSS table successful.")
        Catch appex As MyApplicationException
            RaiseEvent evStatusMessage(appex.Message)
        Catch bex As BusinessException
            RaiseEvent evStatusMessage(bex.Message)
        Catch daex As DataAccessException
            RaiseEvent evStatusMessage(daex.Message)
        Catch ex As Exception
            RaiseEvent evStatusMessage("Updating SSS table failed.")
        End Try
    End Sub

    Private Sub dgvSSS_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvSSS.DataError
        MyMessageBox.error_customMessage("Invalid input data.")
    End Sub
End Class