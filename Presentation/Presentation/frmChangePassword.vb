Imports CrossCutting

Public Class frmChangePassword
    Public Event evStatusMessage(ByVal message As String)

    Private _currentPassword As String
    Private _currentUser_ID As UInteger
    Private _hashedPassword As String

    Private _currentRow As DataRowView

    Public WriteOnly Property CurrentPassword() As String
        Set(ByVal value As String)
            _currentPassword = value
        End Set
    End Property

    Public WriteOnly Property CurrentUser_ID() As UInteger
        Set(ByVal value As UInteger)
            _currentUser_ID = value
        End Set
    End Property

    Public Sub setCurrentRow(ByRef drv As DataRowView)
        _currentRow = drv
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If txtNewPass.Text.Length < 1 Then
            writeMessage("Please enter new password.")
            Return
        End If



        If isPasswordConfirmed() Then
            Dim um As New BusinessLogic.UserManager

            Dim i As Integer = 0
            Try

                _hashedPassword = um.changePassword(_currentUser_ID, txtNewPass.Text)
                passwordChangeSuccess()
                RaiseEvent evStatusMessage("Password Changed successfully.")
            Catch myappex As MyApplicationException
                writeMessage(myappex.Message)
            Catch bex As BusinessException
                writeMessage(bex.Message)
            Catch daex As DataAccessException
                writeMessage(daex.Message)
            Catch ex As Exception
                writeMessage(ex.Message)
            End Try
        End If
    End Sub

    Private Sub passwordChangeSuccess()
        _currentRow.BeginEdit()
        _currentRow("userPassword") = _hashedPassword
        _currentRow.EndEdit()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function isPasswordConfirmed() As Boolean
        If txtNewPass.Text.Equals(txtConfirmPass.Text) Then Return True
        writeMessage("Password did not match.")
        Return False
    End Function

    Private Sub writeMessage(ByVal message As String)
        tsslblMessage.Text = message
    End Sub

    Private Sub txtBoxes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtConfirmPass.KeyDown, txtConfirmPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub frmChangePassword_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            Me.Dispose()
        End If
    End Sub
End Class