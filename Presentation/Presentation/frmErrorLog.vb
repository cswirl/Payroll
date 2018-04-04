Imports DataAccess

Public Class frmErrorLog

    Private dtErrLog As DataTable
    Private myTable As Tables

    Sub New(ByVal table As Tables)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        myTable = table
        Select Case myTable
            Case Tables.Exception
                lblTitle.Text = "Exception Log"
                Me.Text = "Exception Log"
            Case Tables.Bug
                lblTitle.Text = "Bug Log"
                Me.Text = "Bug Log"
        End Select
    End Sub

    Private Sub frmErrorLog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmErrorLog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Right Then NextRec()
        If e.KeyCode = Keys.Left Then PrevRec()
        If e.KeyCode = Keys.Home Then FirstRec()
        If e.KeyCode = Keys.End Then LastRec()
    End Sub

    Private Sub frmErrorLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAll()
    End Sub

    Private Sub getAll()
        Try
            Select Case myTable
                Case Tables.Exception
                    dtErrLog = ExceptionLog_DAO.getAll
                Case Tables.Bug
                    dtErrLog = Bugs_DAO.getAll
            End Select
            Initialize_Bindings()
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Me.Close()
        End Try
    End Sub

    Private Function filterData() As Boolean

        Try
            dtErrLog = New DataTable
            Select Case myTable
                Case Tables.Exception
                    dtErrLog = ExceptionLog_DAO.getByDate(dtpFrom.Value, dtpTo.Value)
                Case Tables.Bug
                    dtErrLog = Bugs_DAO.getByDate(dtpFrom.Value, dtpTo.Value)
            End Select

            If dtErrLog.Rows.Count > 0 Then
                Return True
            End If
        Catch ex As Exception
            Bugs_DAO.log(ex)
        End Try

        Return False
    End Function

    Private Sub Initialize_Bindings()
        Try
            unBind()
            tbDate.DataBindings.Add("text", dtErrLog, "dateCreated")
            txtErrorCode.DataBindings.Add("text", dtErrLog, "errorCode")
            tbSource.DataBindings.Add("text", dtErrLog, "errorSource")
            tbClass.DataBindings.Add("text", dtErrLog, "classDefiningMember")
            tbMemberName.DataBindings.Add("text", dtErrLog, "memberName")
            tbMemberType.DataBindings.Add("text", dtErrLog, "memberType")
            tbMessage.DataBindings.Add("text", dtErrLog, "message")
            tbStackTrace.DataBindings.Add("text", dtErrLog, "stackTrace")
            txtUser.DataBindings.Add("text", dtErrLog, "user_ID")

            AddHandler Me.BindingContext(dtErrLog).PositionChanged, _
            AddressOf dtPositionChanged

            GetRecordPosition()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Initialize_Bindings")
        End Try
    End Sub

    Private Sub unBind()
        tbDate.DataBindings.Clear()
        txtErrorCode.DataBindings.Clear()
        tbSource.DataBindings.Clear()
        tbClass.DataBindings.Clear()
        tbMemberName.DataBindings.Clear()
        tbMemberType.DataBindings.Clear()
        tbMessage.DataBindings.Clear()
        tbStackTrace.DataBindings.Clear()
        txtUser.DataBindings.Clear()

        clearData()
    End Sub

    Private Sub clearData()
        tbDate.Clear()
        txtErrorCode.Clear()
        tbSource.Clear()
        tbClass.Clear()
        tbMemberName.Clear()
        tbMemberType.Clear()
        tbMessage.Clear()
        tbStackTrace.Clear()
        txtUser.Clear()
    End Sub

    Private Sub dtPositionChanged()
        GetRecordPosition()
    End Sub

    Private Sub GetRecordPosition()
        lblRecordPos.Text = "Record " & Me.BindingContext(dtErrLog).Position + 1 & _
        " of " & dtErrLog.Rows.Count
    End Sub

    Private Sub reBind()
        unBind()
        If filterData() Then Initialize_Bindings()
        GetRecordPosition()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        'frmErrorLog_Load(Me, New System.EventArgs)
        reBind()
    End Sub

    Private Sub PrevRec()
        Me.BindingContext(dtErrLog).Position -= 1
    End Sub

    Private Sub NextRec()
        Me.BindingContext(dtErrLog).Position += 1
    End Sub

    Private Sub FirstRec()
        Me.BindingContext(dtErrLog).Position = 0
    End Sub

    Private Sub LastRec()
        Me.BindingContext(dtErrLog).Position = dtErrLog.Rows.Count - 1
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        FirstRec()
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        PrevRec()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        NextRec()
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        LastRec()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Enum Tables
        Exception
        Bug
    End Enum

    Private Sub btnGetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAll.Click
        getAll()
    End Sub
End Class