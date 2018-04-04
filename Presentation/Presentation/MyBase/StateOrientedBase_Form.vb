Imports CrossCutting
Imports System.Collections.Generic
Imports System.Collections

Public MustInherit Class StateOrientedBase_Form
    Inherits System.Windows.Forms.Form
    Implements IManagerBased


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


    'controls
    Friend WithEvents bindSource As New BindingSource
    Friend WithEvents myBtnAdd As New ToolStripButton
    Friend WithEvents myBtnModify As New ToolStripButton
    Friend WithEvents myBtnSave As New Button
    Friend WithEvents myBtnCancel As New Button
    'Dummy
    Friend blankToolStripButton As New ToolStripButton
    Friend blankControlButton As New Button

    Protected dtPrimeDS As DataTable
    'Protected drvPrevRow As DataRowView

    Protected controlsToConceal As New Hashtable
    Private boundedControls As New ArrayList
    Friend WithEvents lblCBoxConcealer As Label

    Public Event evStateChange(ByVal formState As FormState)

    Private myState As FormState
    Protected isPrimeBound As Boolean

    'CONSTANTS  
    Private Const concealerOffset As Integer = 2
    Private Const concealerLessWidth As Integer = 20
    Private Const concealerLessHeight As Integer = 4
    Private concealerBackColor As Color = Color.LightGray


    'State oriented properties
    Protected ReadOnly Property getMyState() As FormState
        Get
            Return myState
        End Get
    End Property


    'State methods
    Protected MustOverride Sub idleState()
    Protected MustOverride Sub addingState()
    Protected MustOverride Sub modifyingState()

    'Methods use while changing state
    Protected MustOverride Sub initializeMyComponent()
    Protected MustOverride Sub initializeControls()
    Protected MustOverride Sub bindMyControls()
    Protected MustOverride Sub addingState_DefaultControls()
    Protected MustOverride Sub positionChanged() Handles bindSource.PositionChanged
    Protected MustOverride Sub addNewPrime()
    Protected MustOverride Sub updatePrime()
    Protected MustOverride Sub representPrimeInfo()
    Protected MustOverride Sub addingSuccess()
    Protected MustOverride Sub modifyingSuccess()
    Protected MustOverride Function getBoundSource_PKey() As UInt32

    'Embedded methods
    Private Sub stateChange(ByVal formState As FormState) Handles Me.evStateChange
        myState = formState
        Select Case formState
            Case CrossCutting_Mod.FormState.Idle
                idleState()
            Case CrossCutting_Mod.FormState.Adding
                addingState()
            Case CrossCutting_Mod.FormState.Modifying
                modifyingState()
        End Select
        controlConcealer()
    End Sub

    Protected Overridable Sub setMyButtons(ByVal addButton As ToolStripButton, _
                                           ByVal editButton As ToolStripButton, _
                                           ByVal saveButton As Button, _
                                           ByVal cancelButton As Button)

        myBtnAdd = addButton
        myBtnModify = editButton
        myBtnSave = saveButton
        myBtnCancel = cancelButton
    End Sub

    'COMMAND BUTTONS
    Private Sub myBtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myBtnModify.Click
        If bindSource.Count < 1 Then Return
        RaiseEvent evStateChange(FormState.Modifying)
    End Sub

    Private Sub myBtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myBtnAdd.Click
        RaiseEvent evStateChange(FormState.Adding)
    End Sub

    Private Sub myBtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myBtnCancel.Click
        RaiseEvent evStateChange(FormState.Idle)
    End Sub

    Private Sub myBtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myBtnSave.Click
        Select Case myState
            Case FormState.Adding
                'ADD NEW USER CODE HERE
                addNewPrime()
            Case FormState.Modifying
                'UPDATE USER CODE HERE
                updatePrime()
        End Select
    End Sub

    'CONTROL TO CONCEAL (ComboCox, DateTimePicker, etc...)
    Protected Overloads Sub addControlToConceal(ByVal control As Control)
        lblCBoxConcealer = New Label
        'Add the label cotrol to the cbox parent first BEFORE calling BringToFront() method
        control.Parent.Controls.Add(lblCBoxConcealer)
        With lblCBoxConcealer
            .Top = control.Location.Y + concealerOffset
            .Left = control.Location.X + concealerOffset ' cBox.Parent.Left + 2
            .Width = control.Width - concealerLessWidth
            .Height = control.Height - concealerLessHeight
            .Font = New Font(control.Font, FontStyle.Regular)
            .ForeColor = control.ForeColor
            .BackColor = concealerBackColor
            .BringToFront()
        End With
        controlsToConceal.Add(control, lblCBoxConcealer)
    End Sub

    Protected Overloads Sub addControlToConceal(ByVal controlList As Hashtable)
        controlsToConceal = controlList
    End Sub

    Protected Overloads Sub addControlToConceal(ByVal ParamArray control() As Control)
        For i = 0 To control.Count - 1
            lblCBoxConcealer = New Label
            'Add the label cotrol to the cbox parent first BEFORE calling BringToFront() method
            control.ElementAt(i).Parent.Controls.Add(lblCBoxConcealer)
            With lblCBoxConcealer
                .Top = control.ElementAt(i).Location.Y + concealerOffset
                .Left = control.ElementAt(i).Location.X + concealerOffset
                .Width = control.ElementAt(i).Width - concealerLessWidth
                .Height = control.ElementAt(i).Height - concealerLessHeight
                .Font = New Font(control.ElementAt(i).Font, FontStyle.Regular)
                .ForeColor = control.ElementAt(i).ForeColor
                .BackColor = concealerBackColor
                .BringToFront()
            End With
            controlsToConceal.Add(control.ElementAt(i), lblCBoxConcealer)
        Next
    End Sub

    'BOUNDED CONTROLS
    Protected Overloads Sub addBoundedControl(ByVal control As Control)
        boundedControls.Add(control)
    End Sub

    Protected Overloads Sub addBoundedControl(ByVal controlList As ArrayList)
        boundedControls = controlList
    End Sub

    Protected Overloads Sub addBoundedControl(ByVal ParamArray control() As Control)
        For i = 0 To control.Count - 1
            boundedControls.Add(control.ElementAt(i))
        Next
    End Sub

    'SHOW/HIDE THE Control BOX CONCEALER
    Protected Overridable Sub controlConcealer()
        'WARNING: If the cbox has no selected item. A null reference can occur. However, DBNullToString should do the trick
        Dim key As Object
        Dim keys As ICollection = controlsToConceal.Keys
        Dim cbox As ComboBox
        Dim dtp As DateTimePicker
        Dim lbl As Label
        For Each key In keys
            lbl = CType(controlsToConceal(key), Label)
            If CType(key, Control).Enabled Then
                With lbl
                    .Visible = False
                End With
            Else
                If TypeOf (key) Is ComboBox Then
                    cbox = CType(key, ComboBox)
                    With lbl
                        .Text = DBNullToString(cbox.SelectedItem)
                        .Visible = True
                    End With
                ElseIf TypeOf (key) Is DateTimePicker Then
                    dtp = CType(key, DateTimePicker)
                    With lbl
                        .Text = DBNullToString(dtp.Text)
                        .Visible = True
                    End With
                End If

            End If
        Next

    End Sub

    'CAN PERFORM ADDITIONAL OPERATION IF A DATABASE OPERATION IS DONE
    Protected Sub DB_OperationPerformed(ByVal operationPerformed As DB_Operation)
        Select Case operationPerformed
            Case DB_Operation.Create

                'more implementation here
            Case DB_Operation.Update

                'more implementation here
            Case DB_Operation.Delete

                'more implementation here
        End Select
        RaiseEvent evStateChange(FormState.Idle)
    End Sub

    'OVERRIDABLEs
    Protected Overridable Sub boundedControls_readOnly(ByVal bool As Boolean)
        For i = 0 To boundedControls.Count - 1
            If TypeOf (boundedControls(i)) Is TextBoxBase Then
                CType(boundedControls(i), TextBox).ReadOnly = bool
            Else
                CType(boundedControls(i), Control).Enabled = IIf(bool, False, True)
            End If
        Next

    End Sub

    Protected Overridable Sub unboundMyControls()
        For i = 0 To boundedControls.Count - 1
            CType(boundedControls(i), Control).DataBindings.Clear()
        Next
        isPrimeBound = False
    End Sub

    Protected Overridable Sub commandButtonsVisible(ByVal bool As Boolean)
        If _myBtnSave IsNot Nothing Then _myBtnSave.Visible = bool
        If _myBtnSave IsNot Nothing Then _myBtnCancel.Visible = bool

    End Sub

    Protected Overridable Function AddErrorMsg() As String
        Return "An error occur while adding a new record. Please Try Again."
    End Function

    Protected Overridable Function ModifyErrorMsg() As String
        Return "An error occur while modifying a record. Please Try Again."
    End Function

    Protected Overridable Function DeleteErrorMsg() As String
        Return "An error occur while deleting a record. Please Try Again."
    End Function


    'AUTO GENERATED
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'StateOriented
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 750)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "StateOriented"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "StateOriented"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub


End Class