Imports CrystalDecisions.CrystalReports.Engine
Imports CrossCutting
Imports BusinessLogic
Imports DataAccess

Public Class frmReport

    Private myReport As ReportGenerator.Reports
    Private payMethod As ReportGenerator.PayMethod

    Private _dateFrom As New Date
    Private _dateTo As New Date

    Public Property dateFrom() As Date
        Get
            Return _dateFrom
        End Get
        Set(ByVal value As Date)
            _dateFrom = value
        End Set
    End Property

    Public Property dateTo() As Date
        Get
            Return _dateTo
        End Get
        Set(ByVal value As Date)
            _dateTo = value
        End Set
    End Property


    Sub New(ByVal report As ReportGenerator.Reports,
            Optional ByVal _payMethod As ReportGenerator.PayMethod = ReportGenerator.PayMethod.All)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        myReport = report
        Me.payMethod = _payMethod
        dateFrom = Now
        dateTo = Now
    End Sub

    Private Sub frmReport_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        If Me.Visible = False Then
            Me.Dispose()
        End If
    End Sub

    Private Sub frmReport_shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        loadReport()
    End Sub

    Private Sub loadReport()
        Dim repGen As New ReportGenerator
        Dim myData As New DataSet
        Dim report_doc As New ReportDocument
        Dim report_file As String
        Try
            report_file = ReportGenerator.getFilename(myReport)
            myData = repGen.getData(myReport, payMethod)
            Dim path As String = System.IO.Directory.GetCurrentDirectory & _
               "\Reports\" & report_file
            If Not System.IO.File.Exists(path) Then
                Throw New BusinessException("Cannot find the report file `" & report_file & "`")
            End If
            report_doc.Load(path)
            report_doc.SetDataSource(myData.Tables(0))
            CrystalReportViewer1.ReportSource = report_doc
        Catch bex As BusinessException
            writeStatus(bex.Message)
            MyMessageBox.error_customMessage(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
            MyMessageBox.error_customMessage(daex.Message)
        Catch ex As Exception
            Dim msg As String = "Critical error. Please report to the administrator."
            writeStatus(msg)
            Bugs_DAO.log(ex)
            MyMessageBox.error_customMessage(msg)
        End Try
    End Sub

    Private Sub writeStatus(ByVal message As String)
        tsslblMessage.Text = message
    End Sub

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class