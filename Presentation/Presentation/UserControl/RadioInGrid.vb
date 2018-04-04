Imports CrossCutting

Public Class RadioInGrid
    Inherits System.Windows.Forms.Control

    Private WithEvents pointer As RadioButton      'Points to the checked radio button
    Private WithEvents radio As RadioButton
    Private radioBox As New Generic.List(Of RadioButton)
    Private target_column As String
    Private radioGroup As New GroupBox

    Public Event selection_changed(ByVal radio As RadioButton)


    Sub New(ByVal columnName As String)
        target_column = columnName
    End Sub

    Public Sub clearRadios()
        For Each radio As RadioButton In radioBox
            RemoveHandler radio.CheckedChanged, AddressOf radio_select_changed
        Next
        radioBox.Clear()
    End Sub

    Private Sub radio_select_changed(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent selection_changed(CType(sender, RadioButton))
    End Sub

    Public Sub create_radioButton(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
        Try
            Dim _datagridview As DataGridView = CType(sender, DataGridView)

            'Clear radioBox automatically on row index 0
            'If _datagridview.CurrentRow.Index <= 0 Then clearRadios()

            'In this context we will used our datasource type in our project
            Dim drv As DataRowView = CType(_datagridview.CurrentRow.DataBoundItem, DataRowView)

            'Identify the column we need to patch by radio buttons
            Dim _index As Integer = _datagridview.Columns(target_column).Index
            If e.ColumnIndex = _index AndAlso e.RowIndex >= 0 Then

                'Create new radiobutton instances for the cell
                radio = New RadioButton
                'Register handler of the newly created radio button
                AddHandler radio.CheckedChanged, AddressOf radio_select_changed

                'Draw the radio button inside the datagridview cell
                With radio
                    .Width = e.CellBounds.Width
                    .Height = e.CellBounds.Height
                    .Checked = DBNullToNumeric(e.Value)
                    .Location = New Point(e.CellBounds.X, e.CellBounds.Y)
                End With

                'Set the pointer
                If radio.Checked Then
                    pointer = radio
                End If

                Me.Controls.Add(radio)
                radioBox.Add(radio)
                radioGroup.Controls.Add(radio)

                MsgBox(String.Format("Employee Number is {0} | Project is {1} ", drv("empNum"), drv("project")))


                'e.PaintBackground(e.ClipBounds, True)

                'Dim rectRadioButton As Rectangle

                'rectRadioButton.Width = 14
                'rectRadioButton.Height = 14
                'rectRadioButton.X = e.CellBounds.X + (e.CellBounds.Width - rectRadioButton.Width) / 2
                'rectRadioButton.Y = e.CellBounds.Y + (e.CellBounds.Height - rectRadioButton.Height) / 2

                'If IsDBNull(e.Value) OrElse e.Value = False Then
                '    ControlPaint.DrawRadioButton(e.Graphics, rectRadioButton, ButtonState.Normal)
                'Else
                '    ControlPaint.DrawRadioButton(e.Graphics, rectRadioButton, ButtonState.Checked)
                'End If

                'e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus)

                e.Handled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
