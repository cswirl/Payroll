Imports BusinessLogic
Imports CrossCutting
Imports BusinessLogic.BusinessEntity

Public Class frmTables
    Implements IManagerBased

    Public Event evTableUpdated(ByVal table As CodedDomainManager.Tables)

    Private _myCaller As IManagerBased
    Private _myManager As MainForm

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Header1.lblTitle.Text = "Tables Organizer"
        Me.Text = "Tables Organizer"
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

    Private Sub frmTables_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        functionKey_Press(NavUCMain, e)
    End Sub

    Private Sub frmTables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'INITIALIZE MENU AND NAVIGATION
            'NavUCMain and MenuUCMain cannot put into constructor becoz myManager is not yet set at that moment
            With NavUCMain
                .formManager = Me.myManager
                .myOwner = Me
            End With
            MenuUCMain.myMainForm = Me.myManager

            CodedDomainUC_Project.initialize_Me(CodedDomainManager.Tables.Project)
            CodedDomainUC_Position.initialize_Me(CodedDomainManager.Tables.Position)
            CodedDomainUC_Division.initialize_Me(CodedDomainManager.Tables.Division)
            CodedDomainUC_Allowance.initialize_Me(CodedDomainManager.Tables.AllowanceType)
            CodedDomainUC_Bonus.initialize_Me(CodedDomainManager.Tables.BonusType)
            CodedDomainUC_Deduction.initialize_Me(CodedDomainManager.Tables.DeductionType)
        Catch daex As DataAccessException
            writeStatus(daex.Message)
        Catch ex As Exception
            writeStatus("Error while loading Tables Form")
        End Try
    End Sub

    Private Sub writeStatus(ByVal message As String) Handles CodedDomainUC_Project.evStatusMessage, CodedDomainUC_Position.evStatusMessage, CodedDomainUC_Division.evStatusMessage, _
    CodedDomainUC_Allowance.evStatusMessage, CodedDomainUC_Bonus.evStatusMessage, CodedDomainUC_Deduction.evStatusMessage
        StatusStripUC1.writeStatus(message)
    End Sub

    Private Sub position_updated() Handles CodedDomainUC_Position.evPerformedDBOperation
        RaiseEvent evTableUpdated(CodedDomainManager.Tables.Position)
    End Sub

    Private Sub division_updated() Handles CodedDomainUC_Division.evPerformedDBOperation
        RaiseEvent evTableUpdated(CodedDomainManager.Tables.Division)
    End Sub

    Private Sub allowance_updated() Handles CodedDomainUC_Allowance.evPerformedDBOperation
        RaiseEvent evTableUpdated(CodedDomainManager.Tables.AllowanceType)
    End Sub

    Private Sub bonus_updated() Handles CodedDomainUC_Bonus.evPerformedDBOperation
        RaiseEvent evTableUpdated(CodedDomainManager.Tables.BonusType)
    End Sub

    Private Sub deduction_updated() Handles CodedDomainUC_Deduction.evPerformedDBOperation
        RaiseEvent evTableUpdated(CodedDomainManager.Tables.DeductionType)
    End Sub

    Private Sub project_updated() Handles CodedDomainUC_Project.evPerformedDBOperation
        RaiseEvent evTableUpdated(CodedDomainManager.Tables.Project)
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

    Private Sub frmTables_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Presentation_Mod.displayCompanyName(Header1.lblCompanyName)
        setMyCurrentUser()
    End Sub

    'THIS SUB CAN USE ON ALL FORMS TO UPDATE THEIR DATA BY USING SINGLE EVENT ON THE FormManager
    Public Sub setMyCurrentUser()
        displayCurrentUser(Header1.lblUser)
        AdminControlsHandler()
    End Sub

#End Region

    Private Sub deduction_updated(ByVal dbOperation As CrossCutting.CrossCutting_Mod.DB_Operation) Handles CodedDomainUC_Deduction.evPerformedDBOperation

    End Sub

    Private Sub bonus_updated(ByVal dbOperation As CrossCutting.CrossCutting_Mod.DB_Operation) Handles CodedDomainUC_Bonus.evPerformedDBOperation

    End Sub

    Private Sub allowance_updated(ByVal dbOperation As CrossCutting.CrossCutting_Mod.DB_Operation) Handles CodedDomainUC_Allowance.evPerformedDBOperation

    End Sub

    Private Sub division_updated(ByVal dbOperation As CrossCutting.CrossCutting_Mod.DB_Operation) Handles CodedDomainUC_Division.evPerformedDBOperation

    End Sub

    Private Sub position_updated(ByVal dbOperation As CrossCutting.CrossCutting_Mod.DB_Operation) Handles CodedDomainUC_Position.evPerformedDBOperation

    End Sub

    Private Sub project_updated(ByVal dbOperation As CrossCutting.CrossCutting_Mod.DB_Operation) Handles CodedDomainUC_Project.evPerformedDBOperation

    End Sub
End Class