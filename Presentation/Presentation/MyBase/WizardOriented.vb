'Option Strict On
Imports CrossCutting

Public MustInherit Class WizardOriented
    Inherits Presentation.StateOrientedBase_Form
    Implements IWizard

    Private Const FORWARD As String = "&Next >>"
    Private Const BACKWARD As String = "<< &Back"
    Private Const CANCEL As String = "&Cancel"
    Private Const SAVE As String = "&Save"


    'Events
    Public Event evWizardStep_changed(ByVal index As Integer)
    Public Event evWizardCancelled()
    Public Event evSteppingForwardCancelled()

    'Controls
    Friend WithEvents myBtnWizardForward As New Button
    Friend WithEvents myBtnWizardForwardShadow As New Button
    Friend WithEvents myBtnWizardBack As New Button
    Friend WithEvents myBtnWizardCancel As New Button

    Friend WithEvents _myTabControl As New TabControl

    Protected index As Integer  'Step = index + 1
    Protected mySteps(0) As String

    Protected MustOverride Sub initializeMyWizard(ByVal ParamArray steps() As String)
    Protected MustOverride Function canStepForward() As Boolean


    Sub New()
        AddHandler myBtnWizardBack.Click, AddressOf stepBackWard
        AddHandler myBtnWizardCancel.Click, AddressOf cancelWizardOperation

    End Sub

    Public WriteOnly Property myTabControl() As TabControl
        Set(ByVal value As TabControl)
            _myTabControl = value
        End Set
    End Property

    'IWizard
    Private Sub cancelWizardOperation() Implements IWizard.cancelWizardOperation
        index = 0
        RaiseEvent evWizardCancelled()
    End Sub

    Public Function getCurrentStep() As Integer Implements IWizard.getCurrentStep
        Return index + 1
    End Function

    Public Function getCurrentStepToString() As String Implements IWizard.getCurrentStepToString
        Return mySteps.ElementAt(index)
    End Function

    Private Sub stepForward(ByVal sender As Object, ByVal e As EventArgs) Implements IWizard.stepForward
        Dim indexFoo As Integer = index + 1
        'If Not indexFoo > _myTabControl.TabPages.Count - 1 Then
        If index < mySteps.Count - 1 Then
            If canStepForward() Then
                index += 1
                RaiseEvent evWizardStep_changed(index)
            Else
                RaiseEvent evSteppingForwardCancelled()
            End If

        End If

    End Sub

    Private Sub stepBackWard() Implements IWizard.stepBackWard
        Dim indexFoo As Integer = index - 1
        If Not indexFoo < 0 Then
            index -= 1
            '_myTabControl.SelectedIndex = index
            RaiseEvent evWizardStep_changed(index)
        End If

    End Sub

    'Use in setting command controls in First and Last Step
    Private Sub index_changed() Handles Me.evWizardStep_changed
        'If step not 1
        If index > 0 Then
            myBtnWizardBack.Visible = True
        Else
            myBtnWizardBack.Visible = False
        End If

        'If final step
        If index = mySteps.Count - 1 Then
            myBtnWizardForward.Text = SAVE
            'RemoveHandler myBtnWizardForward.Click, AddressOf stepForward
            MyBase.myBtnSave = myBtnWizardForward
        Else
            'AddHandler myBtnWizardForward.Click, AddressOf stepForward
            myBtnWizardForward.Text = FORWARD
            MyBase.myBtnSave = Nothing
        End If
    End Sub

    Protected Sub stepOne_DefaultControls()
        'Remove the action to myBtnSave
        AddHandler myBtnWizardForward.Click, AddressOf stepForward
        MyBase.myBtnSave = Nothing
        With myBtnWizardForward
            .Visible = True
            .Text = FORWARD
        End With

        With myBtnWizardBack
            .Visible = False
            .Text = BACKWARD
        End With

        With myBtnWizardCancel
            .Visible = True
            .Text = CANCEL
        End With

        index = 0
        '_myTabControl.SelectedIndex = 0
    End Sub

    Protected Sub modifyng_DefaultControls()
        'Assign the myBtnSave the button myBtnWizardForward
        RemoveHandler myBtnWizardForward.Click, AddressOf stepForward
        myBtnSave = myBtnWizardForward
        With myBtnWizardForward
            .Visible = True
            .Text = SAVE
        End With

        With myBtnWizardCancel
            .Visible = True
            .Text = CANCEL
        End With


        'Remove the action to myBtnWizardForward - This must be place prior to changing myBtnWizardForward properties
        'myBtnWizardForward = blankControlButton
    End Sub

    Public Sub addSteps(ByVal ParamArray steps() As String) Implements IWizard.addSteps
        'ReDim mySteps(steps.Length)
        mySteps = steps
    End Sub

    Protected Overridable Sub state_changed(ByVal state As FormState) Handles MyBase.evStateChange

        Select Case state
            Case FormState.Idle
                wizardButtonsVisible(False)
            Case FormState.Adding
                stepOne_DefaultControls()
            Case FormState.Modifying
                'wizardButtonsVisible(False)
                modifyng_DefaultControls()
        End Select

    End Sub

    Protected Overridable Sub wizardButtonsVisible(ByVal visible As Boolean)
        With myBtnWizardForward
            .Visible = visible
        End With

        With myBtnWizardBack
            .Visible = visible
        End With

        With myBtnWizardCancel
            .Visible = visible
        End With
    End Sub

    'This should be called after the Form is maximized on the screen
    Public Sub initializeMyWizardButtons(ByVal parentControl As Control, _
                                                ByVal marginRight As Integer, _
                                                ByVal marginBottom As Integer, _
                                                ByVal offsetRight As Integer, _
                                                ByVal offsetBottom As Integer)

        Dim totalRightMargin As Integer = marginRight + offsetRight
        Dim totalBottomMargin As Integer = marginBottom + offsetBottom
        Dim walkerButtons_spacing As Integer = 5
        Dim yLoc As Integer = parentControl.Height - totalBottomMargin

        With myBtnWizardForward
            .Width = 130
            .Height = 25
            .BackColor = Color.Silver
            .TextAlign = ContentAlignment.MiddleCenter
            Dim xLoc As Integer = parentControl.Width - (.Width + totalRightMargin)

            .Location = New Point(xLoc, yLoc)
            .BringToFront()
            .Text = FORWARD
        End With

        With myBtnWizardBack
            .Width = 130
            .Height = 25
            .BackColor = Color.Silver
            .TextAlign = ContentAlignment.MiddleCenter
            Dim xLoc As Integer = myBtnWizardForward.Location.X - (.Width + walkerButtons_spacing)
            .Location = New Point(xLoc, yLoc)
            .BringToFront()
            .Text = BACKWARD
        End With

        Dim centerHorizontalParent As Integer = parentControl.Width / 2
        Dim offsetFromCenter As Integer = 2

        With myBtnWizardCancel
            .Width = 150
            .Height = 25
            .BackColor = Color.Silver
            .TextAlign = ContentAlignment.MiddleCenter
            Dim xLoc As Integer = centerHorizontalParent - (.Width / 2)
            .Location = New Point(xLoc, yLoc)
            .BringToFront()
            .Text = CANCEL
        End With

        'Assign the button cancel to the Base Class to leverage embedded functionality
        myBtnCancel = myBtnWizardCancel
        myBtnWizardForwardShadow = myBtnWizardForward

        'Make wizard buttons invisible
        wizardButtonsVisible(False)
    End Sub

End Class