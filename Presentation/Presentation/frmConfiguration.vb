Option Strict On
Imports CrossCutting
Imports BusinessLogic

Public Class frmConfiguration
    Implements IManagerBased

    Private configToTest As New Configuration

    'IManagerBased
    Private _myManager As MainForm
    Private _myCaller As IManagerBased

    Public Property myManager() As MainForm Implements IManagerBased.myManager
        Get
            Return _myManager
        End Get
        Set(ByVal value As MainForm)
            _myManager = value
        End Set
    End Property

    Public Property myCaller() As IManagerBased Implements IManagerBased.myCaller
        Get
            Return _myCaller
        End Get
        Set(ByVal value As IManagerBased)
            _myCaller = value
        End Set
    End Property

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Sub New(ByVal title As String)
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        lblTitle.Text = title
    End Sub

    Private Sub frmInitialSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillDefaults()
    End Sub

    'Show the current configuration to the user and copy to the CrossCutting to be used by Data Access
    Private Sub fillDefaults()
        With configToTest
            txtCompanyName.Text = My.Settings.CompanyName
            txtServer.Text = My.Settings.Server
            txtPort.Text = CStr(My.Settings.Port)
            txtUsername.Text = My.Settings.Username
            txtPassword.Text = My.Settings.Password
            txtDatabase.Text = My.Settings.Database
        End With

    End Sub

    'Prepares the data to be use against the database
    'If any data is missing or incorrect, do not proceed testing
    Private Sub prepConfigToTest()
        Try
            'NUMERIC
            With configToTest
                .companyName = txtCompanyName.Text
                .server = txtServer.Text
                .port = CType(txtPort.Text, UInt16)
                .username = txtUsername.Text
                .password = txtPassword.Text
                .database = txtDatabase.Text
            End With

            configToTest.useConfiguration()
        Catch icex As InvalidCastException
            Throw New MyApplicationException(MyMessageBox.INVALID_DATA_TYPE)
        Catch ofex As OverflowException
            Throw New MyApplicationException(MyMessageBox.outOfRange(0))
        Catch bex As BusinessException
            Throw bex
        Catch ex As Exception
            MyMessageBox.error_generalInput()
            Throw New MyApplicationException()
        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            writeStatus("Establishing connection to the database.")
            Application.DoEvents()
            Threading.Thread.Sleep(1000)
            testConnection()

            'If configuration testing is fine, set working config to app settings
            With configToTest
                My.Settings.CompanyName = .companyName
                My.Settings.Server = .server
                My.Settings.Port = .port
                My.Settings.Username = .username
                My.Settings.Password = .password
                My.Settings.Database = .database
            End With

            ''TODO: My.Settings.InitialConfiguration
            'My.Settings.InitialConfiguration = True

            'close this form and dispose all its resources
            Me.Close()

            'myOwner is nothing if this object is spawned not by FormManager

            If Not myManager Is Nothing Then
                myManager.initialize_MyForms()
            End If



        Catch appex As MyApplicationException
            writeStatus(appex.Message)
        Catch bex As BusinessException
            writeStatus(bex.Message)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus("An error occur while saving your configuration.")
        End Try

    End Sub

    Private Sub writeStatus(ByVal message As String)
        tsslblMessage.Text = message
    End Sub

    Private Sub testConnection()
        writeStatus("Testing the connection.")
        Try
            prepConfigToTest()
            BusinessLogic.TestConnection()
            writeStatus("Connection established successfully.")
        Catch appex As MyApplicationException
            Throw appex
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Exit the application if the Config Form is spawned by FormManager
        If myManager IsNot Nothing AndAlso myManager.Name.Equals(MainForm.Name) Then
            Application.Exit()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmConfiguration_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            Me.Dispose()
        End If
    End Sub
End Class