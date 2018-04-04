Imports CrossCutting
Imports DataAccess

Public Class QuickSearchUC

    Public Event evStatusMessage(ByVal message As String)
    Protected WithEvents _bindingSource As New BindingSource

    Protected columnToSearch As New Dictionary(Of String, DictionaryEntry)
    Protected autoComp As New AutoCompleteStringCollection

    Protected myCopyOfDataSource As DataTable
    Protected lastGoodExpression As String
    Protected prevBindSourcePosition As Integer

    Public Enum ColumnDataType
        iNumeric
        iString
    End Enum

    Public Sub initialize_Me(ByRef bindingSource As BindingSource, _
                             ByVal items As Dictionary(Of String, DictionaryEntry))
        _bindingSource = bindingSource
        columnToSearch = items
        initializeAutoComplete()
        initializeComboBox()
    End Sub

    Public Sub setTitle(ByVal title As String)
        gbxQuickSearch.Text = title
    End Sub

    Protected Sub initializeComboBox()
        Try
            'Fill combo box
            Dim key As String
            Dim keys As ICollection = columnToSearch.Keys
            For Each key In keys
                tscbxSearchBy.Items.Add(key)
            Next
            'Add the select all filter
            tscbxSearchBy.Items.Add("Get ALL")
            tscbxSearchBy.SelectedIndex = 0     'This triggers the fill_AutoComplete
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try
        
    End Sub

    Protected Sub copyDataSource()
        Try
            If _bindingSource Is Nothing AndAlso _bindingSource.DataSource Is Nothing Then Return
            myCopyOfDataSource = CType(_bindingSource.DataSource, DataTable).Copy
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

    End Sub

    Protected Sub initializeAutoComplete()
        copyDataSource()
        'Set autocomplete for Textbox Search
        With tstxtSearch
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = autoComp
        End With
    End Sub

    Protected Function columnContext() As DictionaryEntry
        Dim col As DictionaryEntry
        Try
            col = CType(columnToSearch(CStr(tscbxSearchBy.SelectedItem)), DictionaryEntry)
        Catch ex As Exception
            'Do Nothing
        End Try

        Return col
    End Function

    Private Sub GetAll_Selected()
        _bindingSource.RemoveFilter()
        RaiseEvent evStatusMessage(_bindingSource.Count & " records found.")
    End Sub

    Public Sub refill_autoComplete()
        copyDataSource()
        fill_AutoComplete()
    End Sub

    Protected Overridable Sub fill_AutoComplete() Handles tscbxSearchBy.SelectedIndexChanged
        'Exit if the user selects the Get ALL 
        If tscbxSearchBy.SelectedIndex = tscbxSearchBy.Items.Count - 1 Then
            tstxtSearch.Clear()
            tstxtSearch.Enabled = False
            autoComp.Clear()
            GetAll_Selected()
            Return
        Else
            tstxtSearch.Enabled = True
        End If

        If _bindingSource Is Nothing OrElse _bindingSource.DataSource Is Nothing Then
            RaiseEvent evStatusMessage("No Data Source found.")
            Return
        End If

        autoComp.Clear()
        Try
            'autoComp is not functioning if starts in numeric type and has value less than 10
            'Therfore a little trick is added by adding trailing blank spaces. 
            'These trailing spaces will then be trimmed to extract the original value
            For Each drv As DataRowView In myCopyOfDataSource.DefaultView
                If Not columnContext().Key Is Nothing Then
                    autoComp.Add(String.Format("{0}{1}", CStr(drv(columnContext().Key)), "   "))
                End If
            Next

            RaiseEvent evStatusMessage("Searching for `" & tscbxSearchBy.SelectedItem & "`")

            tstxtSearch.Focus()
            tstxtSearch.SelectAll()
        Catch ex As Exception
            DataAccess.Bugs_DAO.log(ex)
            'RaiseEvent evStatusMessage("Error while filling auto complete functionality.")
        End Try
    End Sub

    Protected Overridable Sub filter()
        If tstxtSearch.Text.Length < 1 Then Return

        'Exit if the user selects the Get ALL 
        If tscbxSearchBy.SelectedIndex = tscbxSearchBy.Items.Count - 1 Then
            GetAll_Selected()
            Return
        End If

        Dim expression As String = Nothing
        Dim colName As String = CStr(columnContext().Key)
        Try
            _bindingSource.RemoveFilter()
            Select Case columnContext.Value
                Case ColumnDataType.iNumeric
                    expression = String.Format("{0} = {1}", colName, CUInt(Trim(tstxtSearch.Text)))
                Case ColumnDataType.iString
                    expression = String.Format("{0} LIKE '{1}%'", colName, Trim(tstxtSearch.Text))
            End Select

            _bindingSource.Filter = expression

            'If no record found, revert to the last filter with the last record on-view
            If _bindingSource.Count < 1 Then
                _bindingSource.RemoveFilter()
                _bindingSource.Filter = lastGoodExpression
                _bindingSource.Position = prevBindSourcePosition
                RaiseEvent evStatusMessage("No record found.")
            Else
                'Keep track of previous good expression on filter
                lastGoodExpression = expression
                RaiseEvent evStatusMessage(_bindingSource.Count & " records found.")
            End If

        Catch icex As InvalidCastException
            RaiseEvent evStatusMessage("Invalid input. Please check your input data.")
        Catch ofex As OverflowException
            RaiseEvent evStatusMessage("Invalid input. Max number cannot exceed " & UInteger.MaxValue)
        Catch ex As Exception
            DataAccess.Bugs_DAO.log(ex)
            RaiseEvent evStatusMessage("Error while filtering.")
        End Try
    End Sub

    Private Sub tsBtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnGo.Click
        filter()
    End Sub

    Private Sub tstxtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tstxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            filter()
        End If
    End Sub

    Private Sub _bindingsource_positionChanged() Handles _bindingSource.PositionChanged
        'Every use of Filter on _bindingSource, its position property becomes zero(0)
        'This only captures position changes made by the user.
        If _bindingSource.Position > 0 Then prevBindSourcePosition = _bindingSource.Position
    End Sub
End Class