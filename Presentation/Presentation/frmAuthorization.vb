Option Strict On
Imports System.Text
Imports BusinessLogic
Imports CrossCutting

Public Class frmAuthorization

    Public Event evAuthorize(ByVal isAuthorize As Boolean)

    Sub New(ByVal message As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtMessage.Text = message
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As  _
                              System.EventArgs) Handles MyBase.Load
        tbUserName.Focus()
    End Sub

    Private Sub authorize()
        Try
            writeStatus("Checking Authorization . . .")
            Application.DoEvents()
            Threading.Thread.Sleep(1000)

            Dim lm As New LoginManager
            Dim isAuthorize As Boolean = lm.isAuthorized(tbUserName.Text, tbPassword.Text)

            If isAuthorize Then
                RaiseEvent evAuthorize(isAuthorize)
                messageBox("Authorization successful by '" & tbUserName.Text & "'")
            Else
                messageBox("Authorization Failed.")
            End If

            Me.Close()
        Catch bex As BusinessException
            writeStatus(bex.Message)
            messageBox(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            messageBox(daex.Message)
        Catch ex As Exception
            MyMessageBox.error_generalInput()
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As  _
                              System.EventArgs)
        tbUserName.Clear()
        tbPassword.Clear()
        tbUserName.Focus()
    End Sub

    Private Sub frmLogIn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            authorize()
        End If
    End Sub

    Private Sub writeStatus(ByVal message As String)
        tsslblMessage.Text = message
    End Sub

    Private Sub messageBox(ByVal message As String)
        MsgBox(Message, MsgBoxStyle.OkOnly, "")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        RaiseEvent evAuthorize(False)
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        authorize()
    End Sub
End Class