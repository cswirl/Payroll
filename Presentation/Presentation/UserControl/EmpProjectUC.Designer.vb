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
        Me.TabControlProject = New System.Windows.Forms.TabControl()
        Me.TabPageProject = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvProject = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtHolOT_hrs_total = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSunOT_hrs_total = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRegOT_hrs_total = New System.Windows.Forms.TextBox()
        Me.txtWorkdays_total = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLastModifiedBy_readOnly = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLastModified_readOnly = New System.Windows.Forms.TextBox()
        Me.txtDateCreated_readOnly = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PanelTitle = New System.Windows.Forms.Panel()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.TabPageAdd_Mod = New System.Windows.Forms.TabPage()
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
        Me.tsbtnAdd = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnFlagProject = New System.Windows.Forms.Button()
        Me.TabControlProject.SuspendLayout()
        Me.TabPageProject.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvProject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanelTitle.SuspendLayout()
        Me.TabPageAdd_Mod.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.bindNavProject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindNavProject.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlProject
        '
        Me.TabControlProject.Controls.Add(Me.TabPageProject)
        Me.TabControlProject.Controls.Add(Me.TabPageAdd_Mod)
        Me.TabControlProject.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControlProject.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlProject.Location = New System.Drawing.Point(0, 37)
        Me.TabControlProject.Name = "TabControlProject"
        Me.TabControlProject.SelectedIndex = 0
        Me.TabControlProject.Size = New System.Drawing.Size(790, 353)
        Me.TabControlProject.TabIndex = 86
        '
        'TabPageProject
        '
        Me.TabPageProject.Controls.Add(Me.Panel1)
        Me.TabPageProject.Location = New System.Drawing.Point(4, 25)
        Me.TabPageProject.Name = "TabPageProject"
        Me.TabPageProject.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageProject.Size = New System.Drawing.Size(782, 324)
        Me.TabPageProject.TabIndex = 5
        Me.TabPageProject.Text = "Project"
        Me.TabPageProject.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.dgvProject)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.PanelTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 318)
        Me.Panel1.TabIndex = 0
        '
        'dgvProject
        '
        Me.dgvProject.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProject.Location = New System.Drawing.Point(10, 38)
        Me.dgvProject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProject.Name = "dgvProject"
        Me.dgvProject.Size = New System.Drawing.Size(750, 122)
        Me.dgvProject.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtHolOT_hrs_total)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txtSunOT_hrs_total)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtRegOT_hrs_total)
        Me.GroupBox4.Controls.Add(Me.txtWorkdays_total)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox4.Location = New System.Drawing.Point(11, 239)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(749, 70)
        Me.GroupBox4.TabIndex = 85
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SUMMARY"
        '
        'txtHolOT_hrs_total
        '
        Me.txtHolOT_hrs_total.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHolOT_hrs_total.ForeColor = System.Drawing.Color.Black
        Me.txtHolOT_hrs_total.Location = New System.Drawing.Point(656, 36)
        Me.txtHolOT_hrs_total.Name = "txtHolOT_hrs_total"
        Me.txtHolOT_hrs_total.ReadOnly = True
        Me.txtHolOT_hrs_total.Size = New System.Drawing.Size(77, 22)
        Me.txtHolOT_hrs_total.TabIndex = 102
        Me.txtHolOT_hrs_total.Text = "0"
        Me.txtHolOT_hrs_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(656, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 14)
        Me.Label12.TabIndex = 101
        Me.Label12.Text = "HolOT hrs"
        '
        'txtSunOT_hrs_total
        '
        Me.txtSunOT_hrs_total.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSunOT_hrs_total.ForeColor = System.Drawing.Color.Black
        Me.txtSunOT_hrs_total.Location = New System.Drawing.Point(445, 36)
        Me.txtSunOT_hrs_total.Name = "txtSunOT_hrs_total"
        Me.txtSunOT_hrs_total.ReadOnly = True
        Me.txtSunOT_hrs_total.Size = New System.Drawing.Size(77, 22)
        Me.txtSunOT_hrs_total.TabIndex = 100
        Me.txtSunOT_hrs_total.Text = "0"
        Me.txtSunOT_hrs_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(445, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 14)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "SunOT hrs"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(234, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 14)
        Me.Label10.TabIndex = 97
        Me.Label10.Text = "RegOT hrs"
        '
        'txtRegOT_hrs_total
        '
        Me.txtRegOT_hrs_total.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegOT_hrs_total.ForeColor = System.Drawing.Color.Black
        Me.txtRegOT_hrs_total.Location = New System.Drawing.Point(234, 36)
        Me.txtRegOT_hrs_total.Name = "txtRegOT_hrs_total"
        Me.txtRegOT_hrs_total.ReadOnly = True
        Me.txtRegOT_hrs_total.Size = New System.Drawing.Size(77, 22)
        Me.txtRegOT_hrs_total.TabIndex = 98
        Me.txtRegOT_hrs_total.Text = "0"
        Me.txtRegOT_hrs_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWorkdays_total
        '
        Me.txtWorkdays_total.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkdays_total.ForeColor = System.Drawing.Color.Black
        Me.txtWorkdays_total.Location = New System.Drawing.Point(23, 36)
        Me.txtWorkdays_total.Name = "txtWorkdays_total"
        Me.txtWorkdays_total.ReadOnly = True
        Me.txtWorkdays_total.Size = New System.Drawing.Size(77, 22)
        Me.txtWorkdays_total.TabIndex = 96
        Me.txtWorkdays_total.Text = "0"
        Me.txtWorkdays_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(23, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 14)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "Work days"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtLastModifiedBy_readOnly)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtLastModified_readOnly)
        Me.GroupBox1.Controls.Add(Me.txtDateCreated_readOnly)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(10, 156)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(750, 65)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(569, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 14)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Last modified by :"
        '
        'txtLastModifiedBy_readOnly
        '
        Me.txtLastModifiedBy_readOnly.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastModifiedBy_readOnly.ForeColor = System.Drawing.Color.Black
        Me.txtLastModifiedBy_readOnly.Location = New System.Drawing.Point(569, 34)
        Me.txtLastModifiedBy_readOnly.Name = "txtLastModifiedBy_readOnly"
        Me.txtLastModifiedBy_readOnly.ReadOnly = True
        Me.txtLastModifiedBy_readOnly.Size = New System.Drawing.Size(164, 22)
        Me.txtLastModifiedBy_readOnly.TabIndex = 81
        Me.txtLastModifiedBy_readOnly.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(292, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 14)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Last modified :"
        '
        'txtLastModified_readOnly
        '
        Me.txtLastModified_readOnly.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastModified_readOnly.ForeColor = System.Drawing.Color.Black
        Me.txtLastModified_readOnly.Location = New System.Drawing.Point(292, 31)
        Me.txtLastModified_readOnly.Name = "txtLastModified_readOnly"
        Me.txtLastModified_readOnly.ReadOnly = True
        Me.txtLastModified_readOnly.Size = New System.Drawing.Size(164, 22)
        Me.txtLastModified_readOnly.TabIndex = 79
        Me.txtLastModified_readOnly.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDateCreated_readOnly
        '
        Me.txtDateCreated_readOnly.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateCreated_readOnly.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated_readOnly.Location = New System.Drawing.Point(15, 34)
        Me.txtDateCreated_readOnly.Name = "txtDateCreated_readOnly"
        Me.txtDateCreated_readOnly.ReadOnly = True
        Me.txtDateCreated_readOnly.Size = New System.Drawing.Size(164, 22)
        Me.txtDateCreated_readOnly.TabIndex = 77
        Me.txtDateCreated_readOnly.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(12, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 14)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "DateCreated :"
        '
        'PanelTitle
        '
        Me.PanelTitle.BackColor = System.Drawing.Color.Blue
        Me.PanelTitle.Controls.Add(Me.lblRecordCount)
        Me.PanelTitle.Controls.Add(Me.lblProject)
        Me.PanelTitle.Location = New System.Drawing.Point(10, 15)
        Me.PanelTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelTitle.Name = "PanelTitle"
        Me.PanelTitle.Size = New System.Drawing.Size(750, 23)
        Me.PanelTitle.TabIndex = 3
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblRecordCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.ForeColor = System.Drawing.Color.White
        Me.lblRecordCount.Location = New System.Drawing.Point(643, 0)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Padding = New System.Windows.Forms.Padding(0, 9, 6, 0)
        Me.lblRecordCount.Size = New System.Drawing.Size(107, 22)
        Me.lblRecordCount.TabIndex = 1
        Me.lblRecordCount.Text = "0 record/s found"
        '
        'lblProject
        '
        Me.lblProject.AutoSize = True
        Me.lblProject.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProject.ForeColor = System.Drawing.Color.White
        Me.lblProject.Location = New System.Drawing.Point(20, 5)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(62, 16)
        Me.lblProject.TabIndex = 0
        Me.lblProject.Text = "Projects"
        '
        'TabPageAdd_Mod
        '
        Me.TabPageAdd_Mod.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPageAdd_Mod.Controls.Add(Me.btnCancel)
        Me.TabPageAdd_Mod.Controls.Add(Me.btnSave)
        Me.TabPageAdd_Mod.Controls.Add(Me.GroupBox2)
        Me.TabPageAdd_Mod.Controls.Add(Me.GroupBox3)
        Me.TabPageAdd_Mod.Location = New System.Drawing.Point(4, 25)
        Me.TabPageAdd_Mod.Name = "TabPageAdd_Mod"
        Me.TabPageAdd_Mod.Size = New System.Drawing.Size(782, 324)
        Me.TabPageAdd_Mod.TabIndex = 4
        Me.TabPageAdd_Mod.Text = "Add_Mod"
        Me.TabPageAdd_Mod.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Image = Global.Presentation.My.Resources.Resources.exit11
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(473, 259)
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
        Me.btnSave.Location = New System.Drawing.Point(625, 259)
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
        Me.GroupBox2.Size = New System.Drawing.Size(423, 223)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Project Info"
        '
        'cbxProject
        '
        Me.cbxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProject.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProject.FormattingEnabled = True
        Me.cbxProject.Location = New System.Drawing.Point(168, 34)
        Me.cbxProject.Name = "cbxProject"
        Me.cbxProject.Size = New System.Drawing.Size(164, 22)
        Me.cbxProject.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(108, 40)
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
        Me.cbxPosition.Location = New System.Drawing.Point(168, 62)
        Me.cbxPosition.Name = "cbxPosition"
        Me.cbxPosition.Size = New System.Drawing.Size(164, 22)
        Me.cbxPosition.TabIndex = 1
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(58, 179)
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
        Me.cbxDivision.Location = New System.Drawing.Point(168, 92)
        Me.cbxDivision.Name = "cbxDivision"
        Me.cbxDivision.Size = New System.Drawing.Size(164, 22)
        Me.cbxDivision.TabIndex = 2
        '
        'txtLastModifiedBy
        '
        Me.txtLastModifiedBy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtLastModifiedBy.Location = New System.Drawing.Point(168, 176)
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
        Me.Label46.Location = New System.Drawing.Point(105, 68)
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
        Me.Label50.Location = New System.Drawing.Point(75, 151)
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
        Me.Label45.Location = New System.Drawing.Point(108, 95)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(54, 14)
        Me.Label45.TabIndex = 26
        Me.Label45.Text = "Division :"
        '
        'txtLastModified
        '
        Me.txtLastModified.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastModified.ForeColor = System.Drawing.Color.Black
        Me.txtLastModified.Location = New System.Drawing.Point(168, 148)
        Me.txtLastModified.Name = "txtLastModified"
        Me.txtLastModified.ReadOnly = True
        Me.txtLastModified.Size = New System.Drawing.Size(164, 22)
        Me.txtLastModified.TabIndex = 79
        '
        'txtDateCreated
        '
        Me.txtDateCreated.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.Location = New System.Drawing.Point(168, 120)
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
        Me.Label49.Location = New System.Drawing.Point(78, 123)
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
        Me.GroupBox3.Location = New System.Drawing.Point(473, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(280, 223)
        Me.GroupBox3.TabIndex = 73
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Work and OTs"
        '
        'txtHolOT_hrs
        '
        Me.txtHolOT_hrs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHolOT_hrs.ForeColor = System.Drawing.Color.Black
        Me.txtHolOT_hrs.Location = New System.Drawing.Point(148, 176)
        Me.txtHolOT_hrs.Name = "txtHolOT_hrs"
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
        Me.Label20.Location = New System.Drawing.Point(73, 179)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 14)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "HolOT hrs :"
        '
        'txtSunOT_hrs
        '
        Me.txtSunOT_hrs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSunOT_hrs.ForeColor = System.Drawing.Color.Black
        Me.txtSunOT_hrs.Location = New System.Drawing.Point(148, 130)
        Me.txtSunOT_hrs.Name = "txtSunOT_hrs"
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
        Me.Label25.Location = New System.Drawing.Point(69, 85)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 14)
        Me.Label25.TabIndex = 50
        Me.Label25.Text = "RegOT hrs :"
        '
        'txtRegOT_hrs
        '
        Me.txtRegOT_hrs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegOT_hrs.ForeColor = System.Drawing.Color.Black
        Me.txtRegOT_hrs.Location = New System.Drawing.Point(148, 82)
        Me.txtRegOT_hrs.Name = "txtRegOT_hrs"
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
        Me.Label29.Location = New System.Drawing.Point(69, 133)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 14)
        Me.Label29.TabIndex = 49
        Me.Label29.Text = "SunOT hrs :"
        '
        'txtWorkdays
        '
        Me.txtWorkdays.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkdays.ForeColor = System.Drawing.Color.Black
        Me.txtWorkdays.Location = New System.Drawing.Point(148, 34)
        Me.txtWorkdays.Name = "txtWorkdays"
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
        Me.Label57.Location = New System.Drawing.Point(70, 37)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(72, 14)
        Me.Label57.TabIndex = 43
        Me.Label57.Text = "Work days :"
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(0, 0)
        Me.Splitter2.MinExtra = 5
        Me.Splitter2.MinSize = 5
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(790, 5)
        Me.Splitter2.TabIndex = 87
        Me.Splitter2.TabStop = False
        '
        'bindNavProject
        '
        Me.bindNavProject.AddNewItem = Nothing
        Me.bindNavProject.CountItem = Nothing
        Me.bindNavProject.DeleteItem = Nothing
        Me.bindNavProject.Dock = System.Windows.Forms.DockStyle.None
        Me.bindNavProject.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bindNavProject.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindNavProject.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnAdd, Me.BindingNavigatorSeparator4, Me.tsbtnEdit, Me.BindingNavigatorSeparator3, Me.tsbtnDelete})
        Me.bindNavProject.Location = New System.Drawing.Point(591, 1)
        Me.bindNavProject.MoveFirstItem = Nothing
        Me.bindNavProject.MoveLastItem = Nothing
        Me.bindNavProject.MoveNextItem = Nothing
        Me.bindNavProject.MovePreviousItem = Nothing
        Me.bindNavProject.Name = "bindNavProject"
        Me.bindNavProject.Padding = New System.Windows.Forms.Padding(10, 0, 1, 0)
        Me.bindNavProject.PositionItem = Nothing
        Me.bindNavProject.Size = New System.Drawing.Size(185, 25)
        Me.bindNavProject.TabIndex = 88
        Me.bindNavProject.Text = "BindingNavigator1"
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
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel2.Controls.Add(Me.lblEmployeeName)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(790, 28)
        Me.Panel2.TabIndex = 89
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.AutoSize = True
        Me.lblEmployeeName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeName.ForeColor = System.Drawing.Color.White
        Me.lblEmployeeName.Location = New System.Drawing.Point(19, 5)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Size = New System.Drawing.Size(234, 18)
        Me.lblEmployeeName.TabIndex = 0
        Me.lblEmployeeName.Text = "PROJECTS OF : Juan dele Cruz"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.btnFlagProject)
        Me.Panel3.Controls.Add(Me.bindNavProject)
        Me.Panel3.Location = New System.Drawing.Point(1, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(786, 27)
        Me.Panel3.TabIndex = 1
        '
        'btnFlagProject
        '
        Me.btnFlagProject.BackColor = System.Drawing.Color.Silver
        Me.btnFlagProject.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFlagProject.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnFlagProject.Location = New System.Drawing.Point(311, 1)
        Me.btnFlagProject.Name = "btnFlagProject"
        Me.btnFlagProject.Size = New System.Drawing.Size(169, 23)
        Me.btnFlagProject.TabIndex = 89
        Me.btnFlagProject.Text = "Flag as Head"
        Me.btnFlagProject.UseVisualStyleBackColor = False
        '
        'EmpProjectUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabControlProject)
        Me.Controls.Add(Me.Splitter2)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 0, 3, 4)
        Me.Name = "EmpProjectUC"
        Me.Size = New System.Drawing.Size(790, 390)
        Me.TabControlProject.ResumeLayout(False)
        Me.TabPageProject.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvProject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelTitle.ResumeLayout(False)
        Me.PanelTitle.PerformLayout()
        Me.TabPageAdd_Mod.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.bindNavProject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindNavProject.ResumeLayout(False)
        Me.bindNavProject.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlProject As System.Windows.Forms.TabControl
    Friend WithEvents TabPageAdd_Mod As System.Windows.Forms.TabPage
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
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents TabPageProject As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvProject As System.Windows.Forms.DataGridView
    Friend WithEvents PanelTitle As System.Windows.Forms.Panel
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHolOT_hrs_total As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSunOT_hrs_total As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRegOT_hrs_total As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkdays_total As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLastModifiedBy_readOnly As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLastModified_readOnly As System.Windows.Forms.TextBox
    Friend WithEvents txtDateCreated_readOnly As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblEmployeeName As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnFlagProject As System.Windows.Forms.Button

End Class
