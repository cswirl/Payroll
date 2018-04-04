<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpProjectUC
    Inherits Presentation.Concrete_SOB_UC

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmpProjectUC))
        Me.TabControlProject = New System.Windows.Forms.TabControl()
        Me.TabPageProject = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbxProject = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxPosition = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.cbxDivision = New System.Windows.Forms.ComboBox()
        Me.txtLastModifiedBy = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtLastModified = New System.Windows.Forms.TextBox()
        Me.txtDateCreated = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtHolOT_hrs = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSunOT_hrs = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtRegOT_hrs = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtWorkdays = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.bindNavProject = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.TabControlProject.SuspendLayout()
        Me.TabPageProject.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.bindNavProject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindNavProject.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlProject
        '
        Me.TabControlProject.Controls.Add(Me.TabPageProject)
        Me.TabControlProject.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControlProject.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlProject.Location = New System.Drawing.Point(0, 30)
        Me.TabControlProject.Name = "TabControlProject"
        Me.TabControlProject.SelectedIndex = 0
        Me.TabControlProject.Size = New System.Drawing.Size(601, 356)
        Me.TabControlProject.TabIndex = 86
        '
        'TabPageProject
        '
        Me.TabPageProject.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPageProject.Controls.Add(Me.btnCancel)
        Me.TabPageProject.Controls.Add(Me.btnSave)
        Me.TabPageProject.Controls.Add(Me.GroupBox2)
        Me.TabPageProject.Controls.Add(Me.GroupBox3)
        Me.TabPageProject.Location = New System.Drawing.Point(4, 25)
        Me.TabPageProject.Name = "TabPageProject"
        Me.TabPageProject.Size = New System.Drawing.Size(593, 327)
        Me.TabPageProject.TabIndex = 4
        Me.TabPageProject.Text = "Project"
        Me.TabPageProject.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Image = Global.Presentation.My.Resources.Resources.exit11
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(305, 276)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(128, 34)
        Me.btnCancel.TabIndex = 85
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Image = Global.Presentation.My.Resources.Resources.save1
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(439, 276)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(128, 34)
        Me.btnSave.TabIndex = 84
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxProject)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbxPosition)
        Me.GroupBox2.Controls.Add(Me.Label51)
        Me.GroupBox2.Controls.Add(Me.cbxDivision)
        Me.GroupBox2.Controls.Add(Me.txtLastModifiedBy)
        Me.GroupBox2.Controls.Add(Me.Label46)
        Me.GroupBox2.Controls.Add(Me.Label50)
        Me.GroupBox2.Controls.Add(Me.Label45)
        Me.GroupBox2.Controls.Add(Me.txtLastModified)
        Me.GroupBox2.Controls.Add(Me.txtDateCreated)
        Me.GroupBox2.Controls.Add(Me.Label49)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(23, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 223)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Project Info"
        '
        'cbxProject
        '
        Me.cbxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProject.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProject.FormattingEnabled = True
        Me.cbxProject.Location = New System.Drawing.Point(129, 34)
        Me.cbxProject.Name = "cbxProject"
        Me.cbxProject.Size = New System.Drawing.Size(164, 22)
        Me.cbxProject.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(69, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Project :"
        '
        'cbxPosition
        '
        Me.cbxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPosition.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPosition.FormattingEnabled = True
        Me.cbxPosition.Location = New System.Drawing.Point(129, 62)
        Me.cbxPosition.Name = "cbxPosition"
        Me.cbxPosition.Size = New System.Drawing.Size(164, 22)
        Me.cbxPosition.TabIndex = 1
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(19, 179)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(104, 14)
        Me.Label51.TabIndex = 82
        Me.Label51.Text = "Last modified by :"
        '
        'cbxDivision
        '
        Me.cbxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDivision.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDivision.FormattingEnabled = True
        Me.cbxDivision.Location = New System.Drawing.Point(129, 92)
        Me.cbxDivision.Name = "cbxDivision"
        Me.cbxDivision.Size = New System.Drawing.Size(164, 22)
        Me.cbxDivision.TabIndex = 2
        '
        'txtLastModifiedBy
        '
        Me.txtLastModifiedBy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtLastModifiedBy.Location = New System.Drawing.Point(129, 176)
        Me.txtLastModifiedBy.Name = "txtLastModifiedBy"
        Me.txtLastModifiedBy.ReadOnly = True
        Me.txtLastModifiedBy.Size = New System.Drawing.Size(164, 22)
        Me.txtLastModifiedBy.TabIndex = 81
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(66, 68)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(57, 14)
        Me.Label46.TabIndex = 25
        Me.Label46.Text = "Position :"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(36, 151)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(87, 14)
        Me.Label50.TabIndex = 80
        Me.Label50.Text = "Last modified :"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(69, 95)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(54, 14)
        Me.Label45.TabIndex = 26
        Me.Label45.Text = "Division :"
        '
        'txtLastModified
        '
        Me.txtLastModified.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastModified.ForeColor = System.Drawing.Color.Black
        Me.txtLastModified.Location = New System.Drawing.Point(129, 148)
        Me.txtLastModified.Name = "txtLastModified"
        Me.txtLastModified.ReadOnly = True
        Me.txtLastModified.Size = New System.Drawing.Size(164, 22)
        Me.txtLastModified.TabIndex = 79
        '
        'txtDateCreated
        '
        Me.txtDateCreated.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.Location = New System.Drawing.Point(129, 120)
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.ReadOnly = True
        Me.txtDateCreated.Size = New System.Drawing.Size(164, 22)
        Me.txtDateCreated.TabIndex = 77
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(39, 123)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(84, 14)
        Me.Label49.TabIndex = 78
        Me.Label49.Text = "DateCreated :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtHolOT_hrs)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtSunOT_hrs)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.txtRegOT_hrs)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.txtWorkdays)
        Me.GroupBox3.Controls.Add(Me.Label57)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox3.Location = New System.Drawing.Point(385, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(182, 223)
        Me.GroupBox3.TabIndex = 73
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Work and OTs"
        '
        'txtHolOT_hrs
        '
        Me.txtHolOT_hrs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHolOT_hrs.ForeColor = System.Drawing.Color.Black
        Me.txtHolOT_hrs.Location = New System.Drawing.Point(90, 176)
        Me.txtHolOT_hrs.Name = "txtHolOT_hrs"
        Me.txtHolOT_hrs.ReadOnly = True
        Me.txtHolOT_hrs.Size = New System.Drawing.Size(77, 22)
        Me.txtHolOT_hrs.TabIndex = 89
        Me.txtHolOT_hrs.Text = "0"
        Me.txtHolOT_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(15, 179)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 14)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "HolOT hrs :"
        '
        'txtSunOT_hrs
        '
        Me.txtSunOT_hrs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSunOT_hrs.ForeColor = System.Drawing.Color.Black
        Me.txtSunOT_hrs.Location = New System.Drawing.Point(90, 130)
        Me.txtSunOT_hrs.Name = "txtSunOT_hrs"
        Me.txtSunOT_hrs.ReadOnly = True
        Me.txtSunOT_hrs.Size = New System.Drawing.Size(77, 22)
        Me.txtSunOT_hrs.TabIndex = 88
        Me.txtSunOT_hrs.Text = "0"
        Me.txtSunOT_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(11, 85)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 14)
        Me.Label25.TabIndex = 50
        Me.Label25.Text = "RegOT hrs :"
        '
        'txtRegOT_hrs
        '
        Me.txtRegOT_hrs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegOT_hrs.ForeColor = System.Drawing.Color.Black
        Me.txtRegOT_hrs.Location = New System.Drawing.Point(90, 82)
        Me.txtRegOT_hrs.Name = "txtRegOT_hrs"
        Me.txtRegOT_hrs.ReadOnly = True
        Me.txtRegOT_hrs.Size = New System.Drawing.Size(77, 22)
        Me.txtRegOT_hrs.TabIndex = 87
        Me.txtRegOT_hrs.Text = "0"
        Me.txtRegOT_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(11, 133)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 14)
        Me.Label29.TabIndex = 49
        Me.Label29.Text = "SunOT hrs :"
        '
        'txtWorkdays
        '
        Me.txtWorkdays.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkdays.ForeColor = System.Drawing.Color.Black
        Me.txtWorkdays.Location = New System.Drawing.Point(90, 34)
        Me.txtWorkdays.Name = "txtWorkdays"
        Me.txtWorkdays.ReadOnly = True
        Me.txtWorkdays.Size = New System.Drawing.Size(77, 22)
        Me.txtWorkdays.TabIndex = 86
        Me.txtWorkdays.Text = "0"
        Me.txtWorkdays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.Black
        Me.Label57.Location = New System.Drawing.Point(12, 37)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(72, 14)
        Me.Label57.TabIndex = 43
        Me.Label57.Text = "Work days :"
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(0, 25)
        Me.Splitter2.MinExtra = 5
        Me.Splitter2.MinSize = 5
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(601, 5)
        Me.Splitter2.TabIndex = 87
        Me.Splitter2.TabStop = False
        '
        'bindNavProject
        '
        Me.bindNavProject.AddNewItem = Nothing
        Me.bindNavProject.CountItem = Me.BindingNavigatorCountItem1
        Me.bindNavProject.DeleteItem = Nothing
        Me.bindNavProject.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bindNavProject.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindNavProject.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5, Me.tsbtnAdd, Me.tsbtnEdit, Me.tsbtnDelete})
        Me.bindNavProject.Location = New System.Drawing.Point(0, 0)
        Me.bindNavProject.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.bindNavProject.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.bindNavProject.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.bindNavProject.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.bindNavProject.Name = "bindNavProject"
        Me.bindNavProject.Padding = New System.Windows.Forms.Padding(10, 0, 1, 0)
        Me.bindNavProject.PositionItem = Me.BindingNavigatorPositionItem1
        Me.bindNavProject.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.bindNavProject.Size = New System.Drawing.Size(601, 25)
        Me.bindNavProject.TabIndex = 88
        Me.bindNavProject.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(41, 22)
        Me.BindingNavigatorCountItem1.Text = "of {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem1
        '
        Me.BindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem1.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem1.Name = "BindingNavigatorMoveFirstItem1"
        Me.BindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem1.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem1
        '
        Me.BindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem1.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem1.Name = "BindingNavigatorMovePreviousItem1"
        Me.BindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem1.Text = "Move previous"
        '
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = False
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem1"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem1
        '
        Me.BindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem1.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem1.Name = "BindingNavigatorMoveNextItem1"
        Me.BindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem1.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem1
        '
        Me.BindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem1.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem1.Name = "BindingNavigatorMoveLastItem1"
        Me.BindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem1.Text = "Move last"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnAdd
        '
        Me.tsbtnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsbtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbtnAdd.Image = Global.Presentation.My.Resources.Resources.plus1
        Me.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAdd.Name = "tsbtnAdd"
        Me.tsbtnAdd.Size = New System.Drawing.Size(49, 22)
        Me.tsbtnAdd.Text = "Add"
        Me.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'tsbtnEdit
        '
        Me.tsbtnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsbtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbtnEdit.Image = Global.Presentation.My.Resources.Resources.edit_logo1
        Me.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnEdit.Name = "tsbtnEdit"
        Me.tsbtnEdit.Size = New System.Drawing.Size(48, 22)
        Me.tsbtnEdit.Text = "Edit"
        Me.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'tsbtnDelete
        '
        Me.tsbtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tsbtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbtnDelete.Image = Global.Presentation.My.Resources.Resources.Delete_icon2
        Me.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnDelete.Name = "tsbtnDelete"
        Me.tsbtnDelete.Size = New System.Drawing.Size(63, 22)
        Me.tsbtnDelete.Text = "Delete"
        Me.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'EmpProjectUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Controls.Add(Me.TabControlProject)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.bindNavProject)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "EmpProjectUC"
        Me.Size = New System.Drawing.Size(601, 387)
        Me.TabControlProject.ResumeLayout(False)
        Me.TabPageProject.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.bindNavProject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindNavProject.ResumeLayout(False)
        Me.bindNavProject.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControlProject As System.Windows.Forms.TabControl
    Friend WithEvents TabPageProject As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents cbxDivision As System.Windows.Forms.ComboBox
    Friend WithEvents txtLastModifiedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtLastModified As System.Windows.Forms.TextBox
    Friend WithEvents txtDateCreated As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents bindNavProject As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtHolOT_hrs As System.Windows.Forms.TextBox
    Friend WithEvents txtSunOT_hrs As System.Windows.Forms.TextBox
    Friend WithEvents txtRegOT_hrs As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkdays As System.Windows.Forms.TextBox
    Friend WithEvents cbxProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
