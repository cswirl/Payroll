Imports CrossCutting
Imports MySql.Data.MySqlClient
Imports DataAccess

Public Class PhilHealthUC

    Private dsPhilHealth As DataSet
    Private daPhilHealth As MySqlDataAdapter

    Public Event evStatusMessage(ByVal msg As String)

    Public Sub initializeMe()
        Try
            dgv_Phealthformat()
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
            Dim phDAO As New PhilHealth_DAO
            dsPhilHealth = phDAO.retrieveAll(daPhilHealth)

            dgvPhealth.DataSource = dsPhilHealth.Tables(0)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw New Exception("An error occur while getting datasources.")
        End Try
    End Sub

    Private Sub dgv_Phealthformat()
        With dgvPhealth
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
            Dim ColumnPhil_health_id As New DataGridViewTextBoxColumn
            With ColumnPhil_health_id
                .DataPropertyName = "ID"
                .Name = "ID"
                .HeaderText = "Phil_Health_Id"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 60
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = False
            End With
            .Columns.Add(ColumnPhil_health_id)

            Dim ColumnFrom As New DataGridViewTextBoxColumn()
            With ColumnFrom
                .DataPropertyName = "rangeFrom"
                .Name = "rangeFrom"
                .HeaderText = "From"
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 100
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
                .Width = 100
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightGray
            End With
            .Columns.Add(ColumnTo)

            Dim ColumnSal_base As New DataGridViewTextBoxColumn
            With ColumnSal_base
                .DataPropertyName = "sal_base"
                .Name = "sal_base"
                .HeaderText = "Sal_Base"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 90
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightSalmon
            End With
            .Columns.Add(ColumnSal_base)

            Dim ColumnEes As New DataGridViewTextBoxColumn
            With ColumnEes
                .DataPropertyName = "ees"
                .Name = "ees"
                .HeaderText = "EES"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 120
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(ColumnEes)

            Dim ColumnErs As New DataGridViewTextBoxColumn
            With ColumnErs
                .DataPropertyName = "ers"
                .Name = "ers"
                .HeaderText = "ERS"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 120
                .ReadOnly = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
            End With
            .Columns.Add(ColumnErs)

            Dim ColumnTmc As New DataGridViewTextBoxColumn
            With ColumnTmc
                .DataPropertyName = "tmc"
                .Name = "tmc "
                .HeaderText = "TMC"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 120
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Visible = True
                .DefaultCellStyle.BackColor = Color.LightSalmon
            End With
            .Columns.Add(ColumnTmc)
        End With
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            dgvPhealth.EndEdit()
            daPhilHealth.Update(dsPhilHealth.Tables(0))

            'Update the UI
            getDataSources()
            Messages.SuccessMessage("Updating PhilHealth table successful.")
        Catch appex As MyApplicationException
            RaiseEvent evStatusMessage(appex.Message)
        Catch bex As BusinessException
            RaiseEvent evStatusMessage(bex.Message)
        Catch daex As DataAccessException
            RaiseEvent evStatusMessage(daex.Message)
        Catch ex As Exception
            RaiseEvent evStatusMessage("Updating PhilHealth table failed.")
        End Try
    End Sub

    Private Sub dgvPhealth_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPhealth.DataError
        MyMessageBox.error_customMessage("Invalid input data.")
    End Sub
End Class