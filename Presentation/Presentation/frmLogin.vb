Option Strict On
Imports System.Text
Imports BusinessLogic
Imports CrossCutting

Public Class frmLogIn

    Public Event evCurrentUser_Changed()

    Dim loginManager As New LoginManager
    Private _myOwner As MainForm

    Public Property myOwner() As MainForm
        Get
            Return _myOwner
        End Get
        Set(ByVal value As MainForm)
            _myOwner = value
        End Set
    End Property

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As  _
                              System.EventArgs) Handles MyBase.Load
        tbUserName.Focus()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As  _
                              System.EventArgs) Handles btnLogin.Click

        Try
            writeStatus("Logging in . . .")
            Application.DoEvents()
            Threading.Thread.Sleep(1000)
            loginManager.authenticate(tbUserName.Text, tbPassword.Text)

            If Not myOwner Is Nothing Then
                myOwner.showEmployeeForm()
            End If
            Me.Close()

            RaiseEvent evCurrentUser_Changed()

        Catch bex As BusinessException
            writeStatus(bex.Message)
            If bex.code = BusinessRulesViolationCode.ThirdLoginAttempt Then
                Application.Exit()
            End If
        Catch daex As DataAccessException
            ''TODO: frmLogin error code
            'if error code is 1042 or cannot connect to mysql server
            'show different error code
            Me.Hide()
            myOwner.showConfiguration("Database Configuration", daex.Message)
            'end if
            writeStatus(daex.Message)
        Catch ex As Exception
            MyMessageBox.error_generalInput()
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As  _
                              System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As  _
                              System.EventArgs) Handles btnClear.Click
        tbUserName.Clear()
        tbPassword.Clear()
        tbUserName.Focus()
    End Sub

    Private Sub frmLogIn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub writeStatus(ByVal message As String)
        tsslblMessage.Text = message
    End Sub
End Class