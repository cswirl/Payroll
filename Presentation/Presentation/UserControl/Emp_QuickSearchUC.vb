Imports CrossCutting

Public Class Emp_QuickSearchUC

    Public Shadows Event evStatusMessage(ByVal message As String)

    Public Overloads Sub initialize_Me(ByRef bindingSource As BindingSource)
        _bindingSource = bindingSource
        initializeQuickSearch()
        initializeAutoComplete()
        initializeComboBox()
    End Sub

    Private Sub initializeQuickSearch()
        Dim dic As New Dictionary(Of String, DictionaryEntry)
        Dim col1 As New DictionaryEntry
        col1.Key = "empNum"
        col1.Value = QuickSearchUC.ColumnDataType.iNumeric
        columnToSearch.Add("Employee Number", col1)

        Dim col2 As New DictionaryEntry
        col2.Key = "firstName"
        col2.Value = QuickSearchUC.ColumnDataType.iString
        columnToSearch.Add("First Name", col2)

        Dim col3 As New DictionaryEntry
        col3.Key = "lastName"
        col3.Value = QuickSearchUC.ColumnDataType.iString
        columnToSearch.Add("Last Name", col3)
    End Sub

    Private Sub GetAll_Selected()
        _bindingSource.RemoveFilter()
        RaiseEvent evStatusMessage(_bindingSource.Count & " records found.")
    End Sub

    Protected Overrides Sub fill_AutoComplete()
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
        Dim emp As New BusinessLogic.BusinessEntity.Employee
        Try
            For Each drv As DataRowView In myCopyOfDataSource.DefaultView
                If Not columnContext.Key Is Nothing Then
                    If CStr(columnContext.Key).Equals("empNum") Then
                        emp.empNum = CUInt(DBNullToNumeric(drv("empNum")))
                        emp.dateHired = CDate(DBNullToString(drv("dateHired")))
                        autoComp.Add(emp.getFormattedEmpNum)
                    Else
                        autoComp.Add(CStr(drv(columnContext.Key)))
                    End If

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

    Protected Overrides Sub filter()
        If tstxtSearch.Text.Length < 1 Then Return

        'Exit if the user selects the Get ALL 
        If tscbxSearchBy.SelectedIndex = tscbxSearchBy.Items.Count - 1 Then
            GetAll_Selected()
            Return
        End If

        Dim expression As String = Nothing
        Dim colName As String = CStr(columnContext.Key)
        Try
            _bindingSource.RemoveFilter()
            Select Case columnContext().Value
                Case ColumnDataType.iNumeric
                    If authenticateEmpNumber(tstxtSearch.Text) Then
                        expression = String.Format("{0} = {1}", colName, _
                                                   BusinessLogic.empNumExtractor(tstxtSearch.Text))
                    Else
                        expression = "1=0"
                    End If

                Case ColumnDataType.iString
                    expression = String.Format("{0} LIKE '{1}%'", colName, tstxtSearch.Text)
            End Select

            _bindingSource.Filter = expression

            'If no record found, revert to the last filter with the last record onview
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

    Private Function authenticateEmpNumber(ByVal employeeNumber As String) As Boolean
        Dim emp As New BusinessLogic.BusinessEntity.Employee
        Try
            For Each drv As DataRowView In myCopyOfDataSource.DefaultView
                emp.empNum = CUInt(DBNullToNumeric(drv("empNum")))
                emp.dateHired = CDate(DBNullToString(drv("dateHired")))
                If emp.getFormattedEmpNum.Equals(employeeNumber) Then
                    Return True
                End If
            Next
        Catch ex As Exception
            DataAccess.Bugs_DAO.log(ex)
            'RaiseEvent evStatusMessage("Error while filling auto complete functionality.")
        End Try
        Return False
    End Function
End Class