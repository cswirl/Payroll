Imports DataAccess
Imports System.IO
Imports System.Windows.Forms
Imports CrossCutting

Public Class MenuUC

    Friend WithEvents _myMainForm As New MainForm

    Public Property myMainForm() As MainForm
        Get
            Return _myMainForm
        End Get
        Set(ByVal value As MainForm)
            _myMainForm = value
        End Set
    End Property

    Private Sub tsmiLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiLogout.Click
        If MyMessageBox.questionMessage("Do you want to logout?") Then
            CrossCutting.logoutCurrentUser()
            Me.ParentForm.Hide()
            myMainForm.showLogin()
        End If

    End Sub

    Private Sub ConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem.Click
        Dim config As New frmConfiguration("Database Configuration")
        config.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CrossCutting.logoutCurrentUser()
        Me.ParentForm.Hide()
        myMainForm.showLogin()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Try
            'Directory Browser
            Dim directory As String
            Using FBrowser As New FolderBrowserDialog()
                If My.Settings.LastBackupDir.Length > 0 AndAlso _
                    System.IO.Directory.Exists(My.Settings.LastBackupDir.Length) Then
                    FBrowser.SelectedPath = My.Settings.LastBackupDir
                End If
                If FBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    directory = FBrowser.SelectedPath
                    My.Settings.LastBackupDir = directory
                Else
                    Return
                End If
            End Using
            MainForm.showStatus("Starting Database Back-up. . .")
            Dim filename As String = String.Format("{0}{1}", Format(Now.Date, "MM-dd-yyyy"), ".sql")
            BusinessLogic.BusinessLogic_Mod.database_backup(CrossCutting.getDB_name(), directory, filename)
            MsgBox("Backup Succesful.", MsgBoxStyle.Information, "")
        Catch ex As Exception
            Bugs_DAO.log(ex)
            MsgBox("Backup Failed!!!", MsgBoxStyle.Exclamation, "")
        Finally
            MainForm.hideStatus()
        End Try
        
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        Try
            'Directory Browser
            Dim filename As String

            Using opd As New OpenFileDialog()
                With opd
                    .Filter = "SQL files (*.sql)|*.sql"
                    .RestoreDirectory = True
                End With
                If opd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    filename = opd.FileName
                Else
                    Return
                End If
            End Using

            If MessageBox.Show("Restoring the database will erase any changes you have made since you last backup. Are you sure you want to do this?", _
                "Restore Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                MsgBox("Operation Cancelled")
                Exit Sub
            End If
            MainForm.showStatus("Restoring Database. . .")
            BusinessLogic.BusinessLogic_Mod.database_restore(CrossCutting.getDB_name(), filename)
            MsgBox("Database Restore Succesful.", MsgBoxStyle.Information, "")
        Catch ex As Exception
            Bugs_DAO.log(ex)
            MsgBox("Database Restore Failed!!!", MsgBoxStyle.Exclamation, "")
        Finally
            MainForm.hideStatus()
        End Try
    End Sub

    Private Sub tsmiRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiRefresh.Click
        myMainForm.update_currentForm()
    End Sub
End Class