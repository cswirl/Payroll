Public Class frmHome
    Implements IManagerBased

    Private _myManager As MainForm
    Private _myCaller As IManagerBased

    Public Property myCaller() As IManagerBased Implements IManagerBased.myCaller
        Get
            Return _myCaller
        End Get
        Set(ByVal value As IManagerBased)
            _myCaller = value
        End Set
    End Property

    Public Property myManager() As MainForm Implements IManagerBased.myManager
        Get
            Return _myManager
        End Get
        Set(ByVal value As MainForm)
            _myManager = value
        End Set
    End Property

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblTitle.Text = "Home"
        KeyPreview = True
    End Sub

    Private Sub frmHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With NavUC1
            .formManager = Me.myManager
            .myOwner = Me
        End With

        MenuMain.myMainForm = Me.myManager
    End Sub

    Private Sub frmHome_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        functionKey_Press(NavUC1, e)
    End Sub


    Private Sub WriteStatusMessage(ByVal message As String)
        tsslblMessage.Text = message
    End Sub
End Class