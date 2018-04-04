Imports BusinessLogic.BusinessEntity
Imports DataAccess
Imports CrossCutting

Public Class frmEmpChooser

    Private WithEvents bindSource As BindingSource
    Private dtEmployee As DataTable

    Public Event evEmployeeSelected(ByVal drv As DataRowView)

    Sub New(ByVal dateFrom As Date, ByVal dateTo As Date)

        Me.New()
    End Sub

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        initializeMyComponent()
    End Sub

    Private Sub getRecordCount() Handles bindSource.ListChanged     'bindSource.PositionChanged, 
        If Not bindSource.DataSource Is Nothing Then
            lblRecordCount.Text = bindSource.Count & " record/s found"
        End If
    End Sub

    Private Sub getData()
        Try
            Dim em As New BusinessLogic.EmployeeManager
            dtEmployee = em.retrieveUnlockedEmployee
            bindSource = New BindingSource
            bindSource.DataSource = dtEmployee
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            writeStatus("Error while feching data.")
            Throw ex
        End Try
    End Sub

    Private Sub initializeMyComponent()
        Try
            DGV_Format()
            getData()
            dgvEmployee.DataSource = bindSource
            Emp_QuickSearchUC1.initialize_Me(bindSource)
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            Bugs_DAO.log(ex)
            writeStatus("Error while initializing components.")
        End Try
    End Sub

    Private Sub writeStatus(ByVal message As String)
        tslblMessage.Text = message
    End Sub

    Private Sub dgvEmployee_CellFormatting(ByVal sender As Object, _
    ByVal e As DataGridViewCellFormattingEventArgs) Handles dgvEmployee.CellFormatting

        Try
            ' If the column is the empNum column, format the value.
            If Me.dgvEmployee.Columns(e.ColumnIndex).Name _
                = "empNum" Then
                EmployeeNumberFormat(e)
            ElseIf Me.dgvEmployee.Columns(e.ColumnIndex).Name.Equals("birthDate") Then
                'ShortFormDateFormat(e)
            End If

        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
    End Sub

    Private Sub EmployeeNumberFormat(ByVal formatting As DataGridViewCellFormattingEventArgs)
        If formatting.Value IsNot Nothing Then
            Try
                Dim emp As New Employee
                emp.empNum = CType(formatting.Value, UInteger)
                emp.dateHired = Date.Parse(dgvEmployee.CurrentRow.Cells("dateHired").Value)
                formatting.Value = emp.getFormattedEmpNum
                formatting.FormattingApplied = True
            Catch notInDateFormat As FormatException
                ' Set to false in case there are other handlers interested trying to
                ' format this DataGridViewCellFormattingEventArgs instance.
                formatting.FormattingApplied = False
            Catch ex As Exception
                Bugs_DAO.log(ex)
            End Try
        End If
    End Sub

    Private Sub DGV_Format()
        With dgvEmployee
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
            Dim ColumnEmpNum As New DataGridViewTextBoxColumn
            With ColumnEmpNum
                .DataPropertyName = "empNum"
                .Name = "empNum"
                .HeaderText = "Employee #"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 100
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnEmpNum)

            Dim ColumnFN As New DataGridViewTextBoxColumn
            With ColumnFN
                .DataPropertyName = "firstName"
                .Name = "firstName"
                .HeaderText = "First Name"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 120
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnFN)

            Dim ColumnLN As New DataGridViewTextBoxColumn()
            With ColumnLN
                .DataPropertyName = "lastName"
                .Name = "lastName"
                .HeaderText = "Last Name"
                ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 120
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnLN)

            Dim ColumnGender As New DataGridViewTextBoxColumn
            With ColumnGender
                .DataPropertyName = "gender"
                .Name = "gender"
                .HeaderText = "Gender"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 80
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnGender)

            Dim ColumnBirthDate As New DataGridViewTextBoxColumn
            With ColumnBirthDate
                .DataPropertyName = "birthDate"
                .Name = "birthDate"
                .HeaderText = "Date of Birth"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 120
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnBirthDate)

            Dim ColumnContact As New DataGridViewTextBoxColumn
            With ColumnContact
                .DataPropertyName = "contactNum"
                .Name = "contactNum"
                .HeaderText = "Contact #"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 80
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnContact)

            Dim ColumnEmail As New DataGridViewTextBoxColumn
            With ColumnEmail
                .DataPropertyName = "email"
                .Name = "email"
                .HeaderText = "Email"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Width = 80
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.Add(ColumnEmail)
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If bindSource Is Nothing OrElse bindSource.Current Is Nothing Then
                Return
            End If

            Dim drv As DataRowView = CType(bindSource.Current, DataRowView)
            RaiseEvent evEmployeeSelected(drv)
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

        btnExit.PerformClick()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmEmpChooser_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            Me.Dispose()
        End If
    End Sub
End Class