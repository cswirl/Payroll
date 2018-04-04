Imports CrossCutting
Imports System.IO
Public Class frmShell
    'DATABASE NAMES
    Private Const PAYROLL_DEDUCTABLES As String = "payroll_deductions.sql"

    Public Event evPayroll_Deductions_restored()

    Private Sub txtCmd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCmd.KeyDown
        If e.KeyCode = Keys.Enter Then
            getCommand(txtCmd.Text)
            txtCmd.SelectAll()
        End If
    End Sub

    Private Sub getCommand(ByVal cmd As String)
        Try
            Dim root As String = System.IO.Directory.GetCurrentDirectory
            Dim temp_filename As String
            If cmd.ToLower.Equals("backup deductables") Then
                BusinessLogic.BusinessLogic_Mod.database_backup("payroll_deductions", root, PAYROLL_DEDUCTABLES)
                txtResult.Text += "Created backup for Payroll Deductions." & Environment.NewLine
            ElseIf cmd.ToLower.Equals("restore deductables") Then
                temp_filename = String.Format("{0}\{1}", root, PAYROLL_DEDUCTABLES)
                If Not File.Exists(temp_filename) Then
                    Throw New MyApplicationException("No Backup data exists.")
                End If
                BusinessLogic.BusinessLogic_Mod.database_restore("payroll_deductions", temp_filename)
                txtResult.Text += "Payroll Deductions database was restored." & Environment.NewLine
                RaiseEvent evPayroll_Deductions_restored()
            ElseIf cmd.ToLower.Equals("quit") Then
                Me.Close()
            Else
                txtResult.Text += "Unknown Command." & Environment.NewLine
            End If
        Catch myappex As MyApplicationException
            txtResult.Text += myappex.Message & Environment.NewLine
        Catch ex As Exception
            txtResult.Text += "Bad Command." & Environment.NewLine
        End Try
    End Sub

    Private Sub frmShell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtResult.Clear()
    End Sub
End Class