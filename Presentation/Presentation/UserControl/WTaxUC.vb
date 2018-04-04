Imports CrossCutting
Imports BusinessLogic
Imports BusinessLogic.BusinessEntity
Imports MySql.Data.MySqlClient
Imports DataAccess

Public Class WTaxUC
    Private _payMethod As WTax_DAO.PayMethods

    'DataSource
    Private dsBaseBracket_Over As DataSet
    Private dsBaseBracket As DataSet
    Private dsTaxBracket As DataSet

    Private daBaseBracket_Over As MySqlDataAdapter
    Private daBaseBracket As MySqlDataAdapter
    Private daTaxBracket As MySqlDataAdapter

    Public Event evStatusMessage(ByVal msg As String)

    Public Property payMethod() As WTax_DAO.PayMethods
        Get
            Return _payMethod
        End Get
        Set(ByVal value As WTax_DAO.PayMethods)
            _payMethod = value
        End Set
    End Property

    Public Sub initializeMe(ByVal payMethod As WTax_DAO.PayMethods)
        Me.payMethod = payMethod
        Try
            lblTitle.Text = WTax_DAO.Paymethod_ToString(payMethod)
            getDataSources()
            fill_BaseBrackets_Over()
            fill_BaseBrackets()
            fill_TaxBrackets()
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
            Dim wtaxDAO As New WTax_DAO
            dsBaseBracket_Over = wtaxDAO.retrieveBaseBracket_Over(daBaseBracket_Over)
            dsBaseBracket = wtaxDAO.retrieveBaseBracket(daBaseBracket, payMethod)
            dsTaxBracket = wtaxDAO.retrieveTaxBracket(daTaxBracket, payMethod)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw New Exception("An error occur while getting datasources.")
        End Try
    End Sub

    Private Sub fill_BaseBrackets_Over()
        Dim current_Label As Label
        Dim controls As Control()
        Try
            Dim dTable As DataTable = dsBaseBracket_Over.Tables(WTax_DAO.MyTables_ToString(WTax_DAO.MyTables.BaseBracketOver))
            For x = 1 To 8
                controls = TableLayoutPanel1.Controls.Find("over" & x, True)
                'The Control.Find function should return only one control
                If controls.Count <> 1 Then
                    Throw New MyApplicationException("Unexpected number of controls had been fetched.")
                End If
                current_Label = CType(controls.ElementAt(0), Label)
                current_Label.Text = over_ToString(CDbl(dTable.Rows().Find(x)("over")))
            Next
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Throw ex
        End Try
    End Sub

    Private Sub fill_TaxBrackets()
        Dim current_TextBox As TextBox
        Dim controls As Control()
        Dim counter As Integer = 0
        Try
            Dim dTable As DataTable = dsTaxBracket.Tables(WTax_DAO.MyTables_ToString(WTax_DAO.MyTables.TaxBracket))
            For x = 1 To 6
                For y = 1 To 8
                    controls = TableLayoutPanel1.Controls.Find("t" & x & y, True)
                    'The Control.Find function should return only one control
                    If controls.Count <> 1 Then
                        Throw New MyApplicationException("Unexpected number of controls had been fetched.")
                    End If
                    current_TextBox = CType(controls.ElementAt(0), TextBox)
                    current_TextBox.Text = truncateTrailingZeroes(dTable.Rows(counter)("exemption").ToString)
                    counter += 1
                Next
            Next
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Throw ex
        End Try
    End Sub

    Private Sub fill_BaseBrackets()
        Dim current_TextBox As TextBox
        Dim controls As Control()
        Try
            Dim dTable As DataTable = dsBaseBracket.Tables(WTax_DAO.MyTables_ToString(WTax_DAO.MyTables.BaseBracket))
            For x = 1 To 8
                controls = TableLayoutPanel1.Controls.Find("ex" & x, True)
                'The Control.Find function should return only one control
                If controls.Count <> 1 Then
                    Throw New MyApplicationException("Unexpected number of controls had been fetched.")
                End If
                current_TextBox = CType(controls.ElementAt(0), TextBox)
                current_TextBox.Text = dTable.Rows(x - 1)("baseBracket").ToString
                'dTable.Rows().Find(New Object() {x, WTax_DAO.Paymethod_ToString(payMethod)})("baseBracket").ToString
            Next
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Throw ex
        End Try
    End Sub

    Private Function truncateTrailingZeroes(ByVal value As String) As String
        Try
            Dim pointLoc As Integer = IIf(value.Contains("."), value.IndexOf("."), value.Length - 1)
            Dim places As String = value.Substring(pointLoc + 1)
            If CUInt(places) > 0 Then
                Return value
            Else
                Return CInt(value).ToString
            End If
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Throw ex
        End Try
    End Function

    Private Sub get_BaseBrackets()
        Dim current_TextBox As TextBox
        Dim controls As Control()
        Dim dr As DataRow
        Try
            Dim dTable As DataTable = dsBaseBracket.Tables(WTax_DAO.MyTables_ToString(WTax_DAO.MyTables.BaseBracket))
            For x = 1 To 8
                controls = TableLayoutPanel1.Controls.Find("ex" & x, True)
                'The Control.Find function should return only one control
                If controls.Count <> 1 Then
                    Throw New MyApplicationException("Unexpected number of controls had been fetched.")
                End If
                current_TextBox = CType(controls.ElementAt(0), TextBox)
                dr = dTable.Rows(x - 1)
                dr.BeginEdit()
                dr("baseBracket") = CDbl(DBNullToNumeric(current_TextBox.Text))
                dr.EndEdit()
                'dTable.Rows().Find(New Object() {x, WTax_DAO.Paymethod_ToString(payMethod)})("baseBracket").ToString
            Next
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Throw ex
        End Try
    End Sub

    Private Sub get_TaxBrackets()
        Dim current_TextBox As TextBox
        Dim controls As Control()
        Dim counter As Integer = 0
        Dim dr As DataRow
        Try
            Dim dTable As DataTable = dsTaxBracket.Tables(WTax_DAO.MyTables_ToString(WTax_DAO.MyTables.TaxBracket))
            For x = 1 To 6
                For y = 1 To 8
                    controls = TableLayoutPanel1.Controls.Find("t" & x & y, True)
                    'The Control.Find function should return only one control
                    If controls.Count <> 1 Then
                        Throw New MyApplicationException("Unexpected number of controls had been fetched.")
                    End If
                    current_TextBox = CType(controls.ElementAt(0), TextBox)
                    dr = dTable.Rows(counter)
                    dr.BeginEdit()
                    dr("exemption") = CDbl(DBNullToNumeric(current_TextBox.Text))
                    dr.EndEdit()
                    counter += 1
                Next
            Next
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Throw ex
        End Try
    End Sub

    Private Function over_ToString(ByVal over As Double) As String
        Dim value As Integer
        Try
            value = over * 100
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Throw New Exception("Error while on over ToString function.")
        End Try

        Return String.Format("+{0}% over", value)
    End Function

    Private Sub save()
        Try
            get_BaseBrackets()
            get_TaxBrackets()
            daBaseBracket.Update(dsBaseBracket.Tables(0))
            daTaxBracket.Update(dsTaxBracket.Tables(0))

            RaiseEvent evStatusMessage("WTax - " & WTax_DAO.Paymethod_ToString(payMethod) & " updated successfully")
            Messages.SuccessMessage("WTax - " & WTax_DAO.Paymethod_ToString(payMethod) & " updated successfully")
        Catch bex As BusinessException
            RaiseEvent evStatusMessage(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            RaiseEvent evStatusMessage(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            RaiseEvent evStatusMessage("Error updating WTax - " & WTax_DAO.Paymethod_ToString(payMethod))
            MyMessageBox.error_customMessage("Error updating WTax - " & WTax_DAO.Paymethod_ToString(payMethod))
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save()
    End Sub

    Private Sub Exemption_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles ex1.KeyPress, ex2.KeyPress, ex3.KeyPress, ex4.KeyPress, ex5.KeyPress, ex6.KeyPress, ex7.KeyPress, ex8.KeyPress, _
        t11.KeyPress, t12.KeyPress, t13.KeyPress, t14.KeyPress, t15.KeyPress, t16.KeyPress, t17.KeyPress, t18.KeyPress, _
        t21.KeyPress, t22.KeyPress, t23.KeyPress, t24.KeyPress, t25.KeyPress, t26.KeyPress, t27.KeyPress, t28.KeyPress, _
        t31.KeyPress, t32.KeyPress, t33.KeyPress, t34.KeyPress, t35.KeyPress, t36.KeyPress, t37.KeyPress, t38.KeyPress, _
        t41.KeyPress, t42.KeyPress, t43.KeyPress, t44.KeyPress, t45.KeyPress, t46.KeyPress, t47.KeyPress, t48.KeyPress, _
        t51.KeyPress, t52.KeyPress, t53.KeyPress, t54.KeyPress, t55.KeyPress, t56.KeyPress, t57.KeyPress, t58.KeyPress, _
        t61.KeyPress, t62.KeyPress, t63.KeyPress, t64.KeyPress, t65.KeyPress, t66.KeyPress, t67.KeyPress, t68.KeyPress

        If (Char.IsDigit(e.KeyChar) = False AndAlso Char.IsControl(e.KeyChar) = _
            False) Then
            e.Handled = True
        End If

        If CType(sender, TextBox).Text.Contains(".") = False Then
            If e.KeyChar = CChar(".") Then
                e.Handled = False
            End If
        End If
    End Sub
End Class