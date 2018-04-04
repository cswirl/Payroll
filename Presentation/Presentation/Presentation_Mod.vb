
Module Presentation_Mod

    'Centers the Company Name Label even if maximized
    Public Sub displayCompanyName(ByRef lblCompanyName As Label)
        lblCompanyName.Text = CrossCutting.getCompanyName

        Dim parentHorizontalCenter As Integer = lblCompanyName.Parent.Width / 2
        Dim xLocation As Integer = parentHorizontalCenter - (lblCompanyName.Width / 2)

        Dim parentVerticalCenter As Integer = lblCompanyName.Parent.Height / 2
        Dim yLocation As Integer = parentVerticalCenter - (lblCompanyName.Height / 2)

        lblCompanyName.Location = New Point(xLocation, yLocation)

    End Sub

    Public Sub displayCurrentUser(ByVal lblUser As Label)
        lblUser.Text = String.Format("Welcome, {0}", CrossCutting.getCurrentUser_Username())
    End Sub


    'DataGridView
    Public Sub ShortFormDateFormat(ByVal formatting As DataGridViewCellFormattingEventArgs)
        If formatting.Value IsNot Nothing Then
            Try
                Dim dateString As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim theDate As Date = DateTime.Parse(formatting.Value.ToString())

                dateString.Append(theDate.Month)
                dateString.Append("/")
                dateString.Append(theDate.Day)
                dateString.Append("/")
                'dateString.Append(theDate.Year.ToString().Substring(2))
                dateString.Append(theDate.Year)
                formatting.Value = dateString.ToString()
                formatting.FormattingApplied = True
            Catch notInDateFormat As FormatException
                ' Set to false in case there are other handlers interested trying to
                ' format this DataGridViewCellFormattingEventArgs instance.
                formatting.FormattingApplied = False
            End Try
        End If
    End Sub

    Public Sub functionKey_Press(ByVal nav As NavUC, ByVal e As System.Windows.Forms.KeyEventArgs)
        If CrossCutting.isAdmin(CrossCutting.getCurrentUser) Then
            'CommandShell
            If e.Control = True And e.Alt = True And e.KeyCode = Keys.C Then
                nav.formManager.showShellForm()
                Return
            End If

            'ExceptionLog
            If e.Control = True And e.Alt = True And e.KeyCode = Keys.E Then
                Dim errLog As New frmErrorLog(frmErrorLog.Tables.Exception)
                errLog.ShowDialog()
                Return
            End If
            'BugLog
            If e.Control = True And e.Alt = True And e.KeyCode = Keys.B Then
                Dim errLog As New frmErrorLog(frmErrorLog.Tables.Bug)
                errLog.ShowDialog()
                Return
            End If
            'Log
            If e.Control = True And e.Alt = True And e.KeyCode = Keys.L Then
                Dim log As New frmLog()
                log.ShowDialog()
                Return
            End If
        End If

        With nav
            Select Case e.KeyCode
                Case Keys.Home
                    .tsbtnHome.PerformClick()
                Case Keys.F1
                    .tsbtnEmployeeMF.PerformClick()
                Case Keys.F2
                    .tsbtnPayroll_Rev.PerformClick()
                Case Keys.F3
                    .tsbtnUserMF.PerformClick()
                Case Keys.F4
                    .tsbtnTables.PerformClick()
                Case Keys.F5
                    .tsbtnDeductables.PerformClick()
                Case Keys.F6
                    .tsbtnCreatePayroll.PerformClick()
                Case Keys.F7
                    .tsbtnPayrollRep.PerformClick()
            End Select
        End With
    End Sub

    Public Function isUnique_String(ByVal value As String, ByVal fieldName As String, ByVal table As DataTable) As Boolean
        For Each drv As DataRowView In table.DefaultView
            If value.Equals(drv(fieldName)) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function isUnique_UInteger(ByVal value As UInteger, ByVal fieldName As String, ByVal table As DataTable) As Boolean
        For Each drv As DataRowView In table.DefaultView
            If value.Equals(drv(fieldName)) Then
                Return False
            End If
        Next
        Return True
    End Function

End Module