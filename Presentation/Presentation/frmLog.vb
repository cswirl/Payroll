Imports DataAccess

Public Class frmLog
    Private dtLog As DataTable

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblTitle.Text = "Log"
        Me.Text = "Log"
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
            dtLog = Log_DAO.getAll
            Initialize_Bindings()
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Me.Close()
        End Try
    End Sub

    Private Function filterData() As Boolean
        Try
            dtLog = New DataTable
            dtLog = Log_DAO.getByDate(dtpFrom.Value, dtpTo.Value)
            If dtLog.Rows.Count > 0 Then
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
            tbDate.DataBindings.Add("text", dtLog, "dateCreated")
            txtCode.DataBindings.Add("text", dtLog, "code")
            tbMessage.DataBindings.Add("text", dtLog, "message")
            tbStackTrace.DataBindings.Add("text", dtLog, "stackTrace")
            txtUser.DataBindings.Add("text", dtLog, "user_ID")

            AddHandler Me.BindingContext(dtLog).PositionChanged, _
            AddressOf dtPositionChanged

            GetRecordPosition()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Initialize_Bindings")
        End Try
    End Sub

    Private Sub unBind()
        tbDate.DataBindings.Clear()
        txtCode.DataBindings.Clear()
        tbMessage.DataBindings.Clear()
        tbStackTrace.DataBindings.Clear()
        txtUser.DataBindings.Clear()
        clearData()
    End Sub

    Private Sub clearData()
        tbDate.Clear()
        txtCode.Clear()
        tbMessage.Clear()
        tbStackTrace.Clear()
        txtUser.Clear()
    End Sub

    Private Sub dtPositionChanged()
        GetRecordPosition()
    End Sub

    Private Sub GetRecordPosition()
        lblRecordPos.Text = "Record " & Me.BindingContext(dtLog).Position + 1 & _
        " of " & dtLog.Rows.Count
    End Sub

    Private Sub reBind()
        unBind()
        If filterData() Then Initialize_Bindings()
        GetRecordPosition()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        reBind()
    End Sub

    Private Sub PrevRec()
        Me.BindingContext(dtLog).Position -= 1
    End Sub

    Private Sub NextRec()
        Me.BindingContext(dtLog).Position += 1
    End Sub

    Private Sub FirstRec()
        Me.BindingContext(dtLog).Position = 0
    End Sub

    Private Sub LastRec()
        Me.BindingContext(dtLog).Position = dtLog.Rows.Count - 1
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

    Private Sub btnGetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAll.Click
        getAll()
    End Sub
End Class