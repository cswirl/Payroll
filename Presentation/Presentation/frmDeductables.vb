Imports BusinessLogic
Imports CrossCutting
Imports BusinessLogic.BusinessEntity

Public Class frmDeductables
    Implements IManagerBased

    Private _myCaller As IManagerBased
    Private _myManager As MainForm

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Header1.lblTitle.Text = "Deductable Tables"
        Me.Text = "Deductable Tables"
        KeyPreview = True
    End Sub

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

    Private Sub frmDeductables_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        functionKey_Press(NavUCMain, e)
    End Sub

    Private Sub frmDeductables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'INITIALIZE MENU AND NAVIGATION
            'NavUCMain and MenuUCMain cannot put into constructor becoz myManager is not yet set at that moment
            With NavUCMain
                .formManager = Me.myManager
                .myOwner = Me
            End With
            MenuUCMain.myMainForm = Me.myManager

            'Deductables
            WTaxUC_Weekly.initializeMe(DataAccess.WTax_DAO.PayMethods.Weekly)
            WTaxUC_Semi.initializeMe(DataAccess.WTax_DAO.PayMethods.Semi)
            SsS_UC1.initializeMe()
            PhilHealthUC1.initializeMe()
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus("Error while loading Deducatbles Form")
        End Try
    End Sub

    Private Sub writeStatus(ByVal message As String) Handles WTaxUC_Weekly.evStatusMessage, _
        WTaxUC_Semi.evStatusMessage, SsS_UC1.evStatusMessage, PhilHealthUC1.evStatusMessage
        StatusStripUC1.writeStatus(message)
    End Sub

    'Display common functions for all Primary forms
#Region "Set Display"
    Private Sub AdminControlsHandler()
        'if the user is not an administrative type, hide this button
        If isAdmin(CurrentUser) Then
            '
        Else

        End If

    End Sub

    Private Sub frmDeductables_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Presentation_Mod.displayCompanyName(Header1.lblCompanyName)
        setMyCurrentUser()
    End Sub

    'THIS SUB CAN USE ON ALL FORMS TO UPDATE THEIR DATA BY USING SINGLE EVENT ON THE FormManager
    Public Sub setMyCurrentUser()
        displayCurrentUser(Header1.lblUser)
        AdminControlsHandler()
    End Sub

#End Region
End Class