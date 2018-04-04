Imports Bridge

Public Module Validation
    'TODO: SQL Injection Chararacters
    'SAMPLE CHARACTERS
    Private Const SQLInjectionChars As String = "&, $, ^"

    Public Function isAdmin(ByVal user As Bridge.IUser) As Boolean
        If user Is Nothing Then
            Return False
        End If
        Select Case user.userTypeCode
            Case 1
                Return True

            Case Else
                Return False
        End Select

    End Function

    Private Function hasValidLength(ByVal value As String, ByVal maxLength As Integer) As Boolean
        If value.Length > maxLength Then
            Return False
        End If
        Return True
    End Function

    'A Wrapper is to enforce requirement String data types
    Public Function REQUIRED(ByVal value As String) As String
        If value.Length < 1 Then
            Throw New BusinessException("This field is required")
        End If
        Return value
    End Function

    'Experiment: A Wrapper on numeric data types. We're counting on implicit casting
    Public Function NON_ZERO(ByVal value As Object) As Object
        If IsNumeric(value) Then
            If value < 1 Then
                Throw New BusinessException("Cannot contain zero or negative value")
            End If
        End If
        Return value
    End Function


    Private Function hasSQLInjectionChar(ByVal value As String) As Boolean
        'Search Here
        Dim SQLInj As New String(SQLInjectionChars)
        Dim arrChar As String() = SQLInj.Split(",")

        For Each c As String In arrChar
            If value.Contains(c.Trim) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function stringChecker(ByVal value As String, ByVal maxLength As Integer) As String
        If hasSQLInjectionChar(value) Then
            Dim msg As String = " Cannot contain invalid character (" & _
            SQLInjectionChars & ")"
            Throw New SQLInjectionException(msg)
        ElseIf Not hasValidLength(value, maxLength) Then
            Throw New BusinessException(" Max character length is " & _
                                        maxLength)
        End If

        Return Trim(value)
    End Function

    Public Function uintChecker(ByVal value As UInteger, Optional ByVal range As UInteger = UInteger.MaxValue) As UInteger
        If value > range Then
            Throw New BusinessException("Max range is " & range)
        End If

        Return value
    End Function

    Public Function DBNullToString(ByVal obj As Object) As String
        If obj Is Nothing OrElse IsDBNull(obj) Then
            Return ""
        End If

        Return obj.ToString
    End Function

    'Can be use on Boolean?
    Public Function DBNullToNumeric(ByVal obj As Object) As Object
        If obj Is Nothing OrElse IsDBNull(obj) OrElse isEmptyOrZero(obj) Then
            Return 0
        End If

        Return obj
    End Function

    Public Function IsDuplicated(ByVal value As String, ByVal fieldName As String, ByVal dataTable As System.Data.DataTable) As Boolean
        For Each dr As System.Data.DataRow In dataTable.Rows
            If value.Equals(DBNullToString(dr(fieldName))) Then
                Return True
            End If
        Next

        Return False
    End Function

    'Switch reference between dates From and To
    Public Sub DateRange_autoCorrect(ByRef dateFrom As Date, ByRef dateTo As Date)
        Dim temp As Date
        If dateFrom > dateTo Then
            temp = dateTo
            dateTo = dateFrom
            dateFrom = temp
        End If
    End Sub

    Public Function isRangeValid(ByVal dateFrom As Date, ByVal dateTo As Date)
        If dateFrom >= dateTo Then
            Return False
        End If
        Return True
    End Function










    '''DEPRECATED FUNCTIONS

    'CAN ACCEPT STRING AND NUMERIC
    'Return True if empty string, zero or negative value for numeric
    Private Function isEmptyOrZero(ByVal value As Object) As Boolean
        If IsNumeric(value) Then
            If value < 1 Then
                Return True
            End If

        ElseIf CStr(value).Length < 1 Then
            Return True
        End If

        Return False
    End Function

    Private Function requiredFieldChecker(ByVal value As Object, ByVal minValue As Integer) As Boolean
        'For required fields
        'minValue greater than zero means required
        If minValue > 0 AndAlso isEmptyOrZero(value) Then
            Return True
        End If
    End Function

    Private Function hasMinimumLength(ByVal value As String, ByVal minLength As Integer) As Boolean
        If value.Length < minLength Then
            Return False
        End If
        Return True
    End Function



End Module