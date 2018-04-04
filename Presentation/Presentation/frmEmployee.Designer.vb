<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployee
    Inherits Presentation.WizardPrimeForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployee))
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerHeader = New System.Windows.Forms.SplitContainer()
        Me.PanelCompany = New System.Windows.Forms.Panel()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.SplitContainerTitle = New System.Windows.Forms.SplitContainer()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.BindingNavigatorMain = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPagePersonal = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PanelEmpHead = New System.Windows.Forms.Panel()
        Me.SplitContainerEmpHead = New System.Windows.Forms.SplitContainer()
        Me.gbxEmpNum = New System.Windows.Forms.GroupBox()
        Me.txtEmpNum = New System.Windows.Forms.TextBox()
        Me.Emp_QuickSearchUC1 = New Presentation.Emp_QuickSearchUC()
        Me.gbxAffiliation = New System.Windows.Forms.GroupBox()
        Me.txtPRC_num = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPAGIBIG_num = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSSS_num = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPhilHealth_num = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTIN_num = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbxPersonal = New System.Windows.Forms.GroupBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cbxStatus = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpDateHired = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.cbxCivilStatus = New System.Windows.Forms.ComboBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.cbxGender = New System.Windows.Forms.ComboBox()
        Me.txtMN = New System.Windows.Forms.TextBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtFN = New System.Windows.Forms.TextBox()
        Me.txtLN = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPageSalary = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.checkPAGIBIG = New System.Windows.Forms.CheckBox()
        Me.checkPhilHealth = New System.Windows.Forms.CheckBox()
        Me.checkSSS = New System.Windows.Forms.CheckBox()
        Me.checkWTax = New System.Windows.Forms.CheckBox()
        Me.gbxDeductables = New System.Windows.Forms.GroupBox()
        Me.txtPersonalLoan = New System.Windows.Forms.TextBox()
        Me.txtSSS_Loan = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.gbxSalaries = New System.Windows.Forms.GroupBox()
        Me.txtNumOfDependents = New System.Windows.Forms.TextBox()
        Me.txtRegOT_rate = New System.Windows.Forms.TextBox()
        Me.txtHolOT_rate = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtSunOT_rate = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.cbxPayMethod = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtBasicRate = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TabPageProject = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.EmpProjectUC1 = New Presentation.EmpProjectUC()
        Me.TabPageMisc = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.TabCtrlMisc = New System.Windows.Forms.TabControl()
        Me.TabPageAllow = New System.Windows.Forms.TabPage()
        Me.AllowanceUC1 = New Presentation.AllowanceUC()
        Me.TabPageOtherDed = New System.Windows.Forms.TabPage()
        Me.OtherDeductionUC1 = New Presentation.OtherDeductionUC()
        Me.TabPageBonus = New System.Windows.Forms.TabPage()
        Me.BonusUC1 = New Presentation.BonusUC()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.NavUCMain = New Presentation.NavUC()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.tsslblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStripUC1 = New Presentation.StatusStripUC()
        Me.MenuUCMain = New Presentation.MenuUC()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        CType(Me.SplitContainerHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerHeader.Panel1.SuspendLayout()
        Me.SplitContainerHeader.Panel2.SuspendLayout()
        Me.SplitContainerHeader.SuspendLayout()
        Me.PanelCompany.SuspendLayout()
        CType(Me.SplitContainerTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerTitle.Panel1.SuspendLayout()
        Me.SplitContainerTitle.Panel2.SuspendLayout()
        Me.SplitContainerTitle.SuspendLayout()
        CType(Me.BindingNavigatorMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigatorMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPagePersonal.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PanelEmpHead.SuspendLayout()
        CType(Me.SplitContainerEmpHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerEmpHead.Panel1.SuspendLayout()
        Me.SplitContainerEmpHead.Panel2.SuspendLayout()
        Me.SplitContainerEmpHead.SuspendLayout()
        Me.gbxEmpNum.SuspendLayout()
        Me.gbxAffiliation.SuspendLayout()
        Me.gbxPersonal.SuspendLayout()
        Me.TabPageSalary.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbxDeductables.SuspendLayout()
        Me.gbxSalaries.SuspendLayout()
        Me.TabPageProject.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.TabPageMisc.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.TabCtrlMisc.SuspendLayout()
        Me.TabPageAllow.SuspendLayout()
        Me.TabPageOtherDed.SuspendLayout()
        Me.TabPageBonus.SuspendLayout()
        Me.StatusStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.IsSplitterFixed = True
        Me.SplitContainerMain.Location = New System.Drawing.Point(10, 10)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        Me.SplitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.SplitContainerHeader)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.BindingNavigatorMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.TabControlMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.Splitter1)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.NavUCMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.StatusStripMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.StatusStripUC1)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.MenuUCMain)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1000, 730)
        Me.SplitContainerMain.SplitterDistance = 60
        Me.SplitContainerMain.TabIndex = 1
        '
        'SplitContainerHeader
        '
        Me.SplitContainerHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitContainerHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerHeader.IsSplitterFixed = True
        Me.SplitContainerHeader.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerHeader.Name = "SplitContainerHeader"
        Me.SplitContainerHeader.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerHeader.Panel1
        '
        Me.SplitContainerHeader.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitContainerHeader.Panel1.Controls.Add(Me.PanelCompany)
        '
        'SplitContainerHeader.Panel2
        '
        Me.SplitContainerHeader.Panel2.BackColor = System.Drawing.Color.Gray
        Me.SplitContainerHeader.Panel2.Controls.Add(Me.SplitContainerTitle)
        Me.SplitContainerHeader.Panel2MinSize = 5
        Me.SplitContainerHeader.Size = New System.Drawing.Size(1000, 60)
        Me.SplitContainerHeader.SplitterDistance = 31
        Me.SplitContainerHeader.SplitterWidth = 1
        Me.SplitContainerHeader.TabIndex = 0
        '
        'PanelCompany
        '
        Me.PanelCompany.Controls.Add(Me.lblCompanyName)
        Me.PanelCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCompany.Location = New System.Drawing.Point(0, 0)
        Me.PanelCompany.Name = "PanelCompany"
        Me.PanelCompany.Size = New System.Drawing.Size(1000, 31)
        Me.PanelCompany.TabIndex = 0
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCompanyName.AutoEllipsis = True
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyName.ForeColor = System.Drawing.Color.White
        Me.lblCompanyName.Location = New System.Drawing.Point(20, 5)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(157, 25)
        Me.lblCompanyName.TabIndex = 0
        Me.lblCompanyName.Text = "Company XYZ"
        Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainerTitle
        '
        Me.SplitContainerTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerTitle.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerTitle.Name = "SplitContainerTitle"
        '
        'SplitContainerTitle.Panel1
        '
        Me.SplitContainerTitle.Panel1.Controls.Add(Me.lblTitle)
        '
        'SplitContainerTitle.Panel2
        '
        Me.SplitContainerTitle.Panel2.Controls.Add(Me.lblUser)
        Me.SplitContainerTitle.Panel2.Padding = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.SplitContainerTitle.Size = New System.Drawing.Size(1000, 28)
        Me.SplitContainerTitle.SplitterDistance = 400
        Me.SplitContainerTitle.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(30, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(47, 21)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblUser.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(428, 5)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(158, 18)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Welcome, username"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'BindingNavigatorMain
        '
        Me.BindingNavigatorMain.AddNewItem = Nothing
        Me.BindingNavigatorMain.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigatorMain.DeleteItem = Nothing
        Me.BindingNavigatorMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigatorMain.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigatorMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.tsbtnAdd, Me.tsbtnEdit})
        Me.BindingNavigatorMain.Location = New System.Drawing.Point(166, 601)
        Me.BindingNavigatorMain.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigatorMain.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigatorMain.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigatorMain.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigatorMain.Name = "BindingNavigatorMain"
        Me.BindingNavigatorMain.Padding = New System.Windows.Forms.Padding(15, 0, 1, 0)
        Me.BindingNavigatorMain.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigatorMain.Size = New System.Drawing.Size(834, 43)
        Me.BindingNavigatorMain.TabIndex = 0
        Me.BindingNavigatorMain.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(48, 40)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 40)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 40)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 43)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 26)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 43)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 40)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 40)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 43)
        '
        'tsbtnAdd
        '
        Me.tsbtnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tsbtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbtnAdd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnAdd.Image = CType(resources.GetObject("tsbtnAdd.Image"), System.Drawing.Image)
        Me.tsbtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAdd.Name = "tsbtnAdd"
        Me.tsbtnAdd.Padding = New System.Windows.Forms.Padding(10)
        Me.tsbtnAdd.Size = New System.Drawing.Size(76, 40)
        Me.tsbtnAdd.Text = "&ADD"
        Me.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'tsbtnEdit
        '
        Me.tsbtnEdit.BackColor = System.Drawing.Color.Wheat
        Me.tsbtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbtnEdit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnEdit.Image = CType(resources.GetObject("tsbtnEdit.Image"), System.Drawing.Image)
        Me.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbtnEdit.Name = "tsbtnEdit"
        Me.tsbtnEdit.Padding = New System.Windows.Forms.Padding(10)
        Me.tsbtnEdit.Size = New System.Drawing.Size(76, 40)
        Me.tsbtnEdit.Text = "ED&IT"
        Me.tsbtnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPagePersonal)
        Me.TabControlMain.Controls.Add(Me.TabPageSalary)
        Me.TabControlMain.Controls.Add(Me.TabPageProject)
        Me.TabControlMain.Controls.Add(Me.TabPageMisc)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Location = New System.Drawing.Point(166, 26)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(834, 618)
        Me.TabControlMain.TabIndex = 5
        '
        'TabPagePersonal
        '
        Me.TabPagePersonal.BackColor = System.Drawing.SystemColors.Control
        Me.TabPagePersonal.Controls.Add(Me.SplitContainer1)
        Me.TabPagePersonal.Location = New System.Drawing.Point(4, 25)
        Me.TabPagePersonal.Name = "TabPagePersonal"
        Me.TabPagePersonal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagePersonal.Size = New System.Drawing.Size(826, 589)
        Me.TabPagePersonal.TabIndex = 0
        Me.TabPagePersonal.Tag = "Personal Information"
        Me.TabPagePersonal.Text = "Personal"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelEmpHead)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(10, 10, 10, 5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbxAffiliation)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbxPersonal)
        Me.SplitContainer1.Size = New System.Drawing.Size(820, 583)
        Me.SplitContainer1.SplitterDistance = 59
        Me.SplitContainer1.TabIndex = 0
        '
        'PanelEmpHead
        '
        Me.PanelEmpHead.BackColor = System.Drawing.SystemColors.Control
        Me.PanelEmpHead.Controls.Add(Me.SplitContainerEmpHead)
        Me.PanelEmpHead.Location = New System.Drawing.Point(3, 0)
        Me.PanelEmpHead.Name = "PanelEmpHead"
        Me.PanelEmpHead.Padding = New System.Windows.Forms.Padding(5)
        Me.PanelEmpHead.Size = New System.Drawing.Size(810, 67)
        Me.PanelEmpHead.TabIndex = 0
        '
        'SplitContainerEmpHead
        '
        Me.SplitContainerEmpHead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerEmpHead.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerEmpHead.IsSplitterFixed = True
        Me.SplitContainerEmpHead.Location = New System.Drawing.Point(5, 5)
        Me.SplitContainerEmpHead.Name = "SplitContainerEmpHead"
        '
        'SplitContainerEmpHead.Panel1
        '
        Me.SplitContainerEmpHead.Panel1.Controls.Add(Me.gbxEmpNum)
        '
        'SplitContainerEmpHead.Panel2
        '
        Me.SplitContainerEmpHead.Panel2.Controls.Add(Me.Emp_QuickSearchUC1)
        Me.SplitContainerEmpHead.Size = New System.Drawing.Size(800, 57)
        Me.SplitContainerEmpHead.SplitterDistance = 185
        Me.SplitContainerEmpHead.SplitterWidth = 5
        Me.SplitContainerEmpHead.TabIndex = 0
        '
        'gbxEmpNum
        '
        Me.gbxEmpNum.Controls.Add(Me.txtEmpNum)
        Me.gbxEmpNum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxEmpNum.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxEmpNum.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxEmpNum.Location = New System.Drawing.Point(0, 0)
        Me.gbxEmpNum.Name = "gbxEmpNum"
        Me.gbxEmpNum.Size = New System.Drawing.Size(185, 57)
        Me.gbxEmpNum.TabIndex = 13
        Me.gbxEmpNum.TabStop = False
        Me.gbxEmpNum.Text = "Employee Number"
        '
        'txtEmpNum
        '
        Me.txtEmpNum.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpNum.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtEmpNum.Location = New System.Drawing.Point(16, 21)
        Me.txtEmpNum.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmpNum.Name = "txtEmpNum"
        Me.txtEmpNum.ReadOnly = True
        Me.txtEmpNum.Size = New System.Drawing.Size(155, 27)
        Me.txtEmpNum.TabIndex = 11
        Me.txtEmpNum.Text = "0000000000"
        Me.txtEmpNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Emp_QuickSearchUC1
        '
        Me.Emp_QuickSearchUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Emp_QuickSearchUC1.Location = New System.Drawing.Point(0, 0)
        Me.Emp_QuickSearchUC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Emp_QuickSearchUC1.Name = "Emp_QuickSearchUC1"
        Me.Emp_QuickSearchUC1.Size = New System.Drawing.Size(610, 57)
        Me.Emp_QuickSearchUC1.TabIndex = 0
        '
        'gbxAffiliation
        '
        Me.gbxAffiliation.Controls.Add(Me.txtPRC_num)
        Me.gbxAffiliation.Controls.Add(Me.Label16)
        Me.gbxAffiliation.Controls.Add(Me.txtPAGIBIG_num)
        Me.gbxAffiliation.Controls.Add(Me.Label15)
        Me.gbxAffiliation.Controls.Add(Me.txtSSS_num)
        Me.gbxAffiliation.Controls.Add(Me.Label9)
        Me.gbxAffiliation.Controls.Add(Me.txtPhilHealth_num)
        Me.gbxAffiliation.Controls.Add(Me.Label8)
        Me.gbxAffiliation.Controls.Add(Me.txtTIN_num)
        Me.gbxAffiliation.Controls.Add(Me.Label7)
        Me.gbxAffiliation.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAffiliation.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxAffiliation.Location = New System.Drawing.Point(20, 304)
        Me.gbxAffiliation.Name = "gbxAffiliation"
        Me.gbxAffiliation.Size = New System.Drawing.Size(783, 149)
        Me.gbxAffiliation.TabIndex = 8
        Me.gbxAffiliation.TabStop = False
        Me.gbxAffiliation.Text = "Affiliation"
        '
        'txtPRC_num
        '
        Me.txtPRC_num.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRC_num.Location = New System.Drawing.Point(407, 34)
        Me.txtPRC_num.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPRC_num.Name = "txtPRC_num"
        Me.txtPRC_num.ReadOnly = True
        Me.txtPRC_num.Size = New System.Drawing.Size(175, 22)
        Me.txtPRC_num.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(404, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 14)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "PRC Number"
        '
        'txtPAGIBIG_num
        '
        Me.txtPAGIBIG_num.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPAGIBIG_num.Location = New System.Drawing.Point(214, 94)
        Me.txtPAGIBIG_num.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPAGIBIG_num.Name = "txtPAGIBIG_num"
        Me.txtPAGIBIG_num.ReadOnly = True
        Me.txtPAGIBIG_num.Size = New System.Drawing.Size(175, 22)
        Me.txtPAGIBIG_num.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(212, 119)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 14)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "PAGIBIG Number"
        '
        'txtSSS_num
        '
        Me.txtSSS_num.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSSS_num.Location = New System.Drawing.Point(214, 34)
        Me.txtSSS_num.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSSS_num.Name = "txtSSS_num"
        Me.txtSSS_num.ReadOnly = True
        Me.txtSSS_num.Size = New System.Drawing.Size(175, 22)
        Me.txtSSS_num.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(212, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "SSS Number"
        '
        'txtPhilHealth_num
        '
        Me.txtPhilHealth_num.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhilHealth_num.Location = New System.Drawing.Point(23, 94)
        Me.txtPhilHealth_num.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPhilHealth_num.Name = "txtPhilHealth_num"
        Me.txtPhilHealth_num.ReadOnly = True
        Me.txtPhilHealth_num.Size = New System.Drawing.Size(175, 22)
        Me.txtPhilHealth_num.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(20, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 14)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "PhilHealth Number"
        '
        'txtTIN_num
        '
        Me.txtTIN_num.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIN_num.Location = New System.Drawing.Point(23, 34)
        Me.txtTIN_num.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTIN_num.Name = "txtTIN_num"
        Me.txtTIN_num.ReadOnly = True
        Me.txtTIN_num.Size = New System.Drawing.Size(175, 22)
        Me.txtTIN_num.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(20, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 14)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "TIN Number"
        '
        'gbxPersonal
        '
        Me.gbxPersonal.Controls.Add(Me.Label42)
        Me.gbxPersonal.Controls.Add(Me.cbxStatus)
        Me.gbxPersonal.Controls.Add(Me.Label17)
        Me.gbxPersonal.Controls.Add(Me.dtpDateHired)
        Me.gbxPersonal.Controls.Add(Me.Label6)
        Me.gbxPersonal.Controls.Add(Me.Label5)
        Me.gbxPersonal.Controls.Add(Me.Label4)
        Me.gbxPersonal.Controls.Add(Me.Label3)
        Me.gbxPersonal.Controls.Add(Me.Label2)
        Me.gbxPersonal.Controls.Add(Me.Label1)
        Me.gbxPersonal.Controls.Add(Me.dtpBirthDate)
        Me.gbxPersonal.Controls.Add(Me.cbxCivilStatus)
        Me.gbxPersonal.Controls.Add(Me.txtCity)
        Me.gbxPersonal.Controls.Add(Me.txtAddress)
        Me.gbxPersonal.Controls.Add(Me.cbxGender)
        Me.gbxPersonal.Controls.Add(Me.txtMN)
        Me.gbxPersonal.Controls.Add(Me.txtContact)
        Me.gbxPersonal.Controls.Add(Me.txtEmail)
        Me.gbxPersonal.Controls.Add(Me.txtFN)
        Me.gbxPersonal.Controls.Add(Me.txtLN)
        Me.gbxPersonal.Controls.Add(Me.Label14)
        Me.gbxPersonal.Controls.Add(Me.Label13)
        Me.gbxPersonal.Controls.Add(Me.Label12)
        Me.gbxPersonal.Controls.Add(Me.Label11)
        Me.gbxPersonal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxPersonal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxPersonal.Location = New System.Drawing.Point(20, 15)
        Me.gbxPersonal.Name = "gbxPersonal"
        Me.gbxPersonal.Size = New System.Drawing.Size(783, 274)
        Me.gbxPersonal.TabIndex = 2
        Me.gbxPersonal.TabStop = False
        Me.gbxPersonal.Text = "Personal Information"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(596, 241)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(42, 14)
        Me.Label42.TabIndex = 29
        Me.Label42.Text = "Status"
        '
        'cbxStatus
        '
        Me.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxStatus.Enabled = False
        Me.cbxStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxStatus.FormattingEnabled = True
        Me.cbxStatus.Location = New System.Drawing.Point(599, 214)
        Me.cbxStatus.Name = "cbxStatus"
        Me.cbxStatus.Size = New System.Drawing.Size(150, 22)
        Me.cbxStatus.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(596, 184)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 14)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Date Hired"
        '
        'dtpDateHired
        '
        Me.dtpDateHired.Enabled = False
        Me.dtpDateHired.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateHired.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateHired.Location = New System.Drawing.Point(599, 158)
        Me.dtpDateHired.Name = "dtpDateHired"
        Me.dtpDateHired.Size = New System.Drawing.Size(150, 22)
        Me.dtpDateHired.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(404, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 14)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "City"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(596, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Civil Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(596, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Gender"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Birthday"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 14)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(404, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Middle Name"
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Enabled = False
        Me.dtpBirthDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBirthDate.Location = New System.Drawing.Point(23, 158)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.Size = New System.Drawing.Size(175, 22)
        Me.dtpBirthDate.TabIndex = 7
        '
        'cbxCivilStatus
        '
        Me.cbxCivilStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCivilStatus.Enabled = False
        Me.cbxCivilStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCivilStatus.FormattingEnabled = True
        Me.cbxCivilStatus.Location = New System.Drawing.Point(599, 97)
        Me.cbxCivilStatus.Name = "cbxCivilStatus"
        Me.cbxCivilStatus.Size = New System.Drawing.Size(150, 22)
        Me.cbxCivilStatus.TabIndex = 6
        '
        'txtCity
        '
        Me.txtCity.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(407, 97)
        Me.txtCity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ReadOnly = True
        Me.txtCity.Size = New System.Drawing.Size(175, 22)
        Me.txtCity.TabIndex = 5
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(23, 97)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(367, 22)
        Me.txtAddress.TabIndex = 4
        '
        'cbxGender
        '
        Me.cbxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGender.Enabled = False
        Me.cbxGender.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxGender.FormattingEnabled = True
        Me.cbxGender.Location = New System.Drawing.Point(599, 35)
        Me.cbxGender.Name = "cbxGender"
        Me.cbxGender.Size = New System.Drawing.Size(150, 22)
        Me.cbxGender.TabIndex = 3
        '
        'txtMN
        '
        Me.txtMN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMN.Location = New System.Drawing.Point(407, 36)
        Me.txtMN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMN.Name = "txtMN"
        Me.txtMN.ReadOnly = True
        Me.txtMN.Size = New System.Drawing.Size(175, 22)
        Me.txtMN.TabIndex = 2
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(215, 158)
        Me.txtContact.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.ReadOnly = True
        Me.txtContact.Size = New System.Drawing.Size(175, 22)
        Me.txtContact.TabIndex = 8
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(407, 158)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(175, 22)
        Me.txtEmail.TabIndex = 9
        '
        'txtFN
        '
        Me.txtFN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFN.Location = New System.Drawing.Point(215, 36)
        Me.txtFN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFN.Name = "txtFN"
        Me.txtFN.ReadOnly = True
        Me.txtFN.Size = New System.Drawing.Size(175, 22)
        Me.txtFN.TabIndex = 1
        '
        'txtLN
        '
        Me.txtLN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLN.Location = New System.Drawing.Point(23, 36)
        Me.txtLN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLN.Name = "txtLN"
        Me.txtLN.ReadOnly = True
        Me.txtLN.Size = New System.Drawing.Size(175, 22)
        Me.txtLN.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(404, 184)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 14)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Email"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(211, 184)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 14)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Contact Number"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(211, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 14)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "First Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(20, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 14)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Last Name"
        '
        'TabPageSalary
        '
        Me.TabPageSalary.BackColor = System.Drawing.Color.Transparent
        Me.TabPageSalary.Controls.Add(Me.SplitContainer2)
        Me.TabPageSalary.Location = New System.Drawing.Point(4, 22)
        Me.TabPageSalary.Name = "TabPageSalary"
        Me.TabPageSalary.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageSalary.Size = New System.Drawing.Size(826, 592)
        Me.TabPageSalary.TabIndex = 1
        Me.TabPageSalary.Tag = "Salary and Other Information"
        Me.TabPageSalary.Text = "Salary & Others"
        Me.TabPageSalary.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.gbxDeductables)
        Me.SplitContainer2.Panel2.Controls.Add(Me.gbxSalaries)
        Me.SplitContainer2.Size = New System.Drawing.Size(820, 586)
        Me.SplitContainer2.SplitterDistance = 59
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.checkPAGIBIG)
        Me.GroupBox1.Controls.Add(Me.checkPhilHealth)
        Me.GroupBox1.Controls.Add(Me.checkSSS)
        Me.GroupBox1.Controls.Add(Me.checkWTax)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(386, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(133, 212)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Deductables"
        '
        'checkPAGIBIG
        '
        Me.checkPAGIBIG.AutoSize = True
        Me.checkPAGIBIG.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkPAGIBIG.ForeColor = System.Drawing.SystemColors.InfoText
        Me.checkPAGIBIG.Location = New System.Drawing.Point(23, 172)
        Me.checkPAGIBIG.Name = "checkPAGIBIG"
        Me.checkPAGIBIG.Size = New System.Drawing.Size(73, 20)
        Me.checkPAGIBIG.TabIndex = 3
        Me.checkPAGIBIG.Text = "PAGIBIG"
        Me.checkPAGIBIG.UseVisualStyleBackColor = True
        '
        'checkPhilHealth
        '
        Me.checkPhilHealth.AutoSize = True
        Me.checkPhilHealth.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkPhilHealth.ForeColor = System.Drawing.SystemColors.InfoText
        Me.checkPhilHealth.Location = New System.Drawing.Point(23, 125)
        Me.checkPhilHealth.Name = "checkPhilHealth"
        Me.checkPhilHealth.Size = New System.Drawing.Size(87, 20)
        Me.checkPhilHealth.TabIndex = 2
        Me.checkPhilHealth.Text = "Phil Health"
        Me.checkPhilHealth.UseVisualStyleBackColor = True
        '
        'checkSSS
        '
        Me.checkSSS.AutoSize = True
        Me.checkSSS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkSSS.ForeColor = System.Drawing.SystemColors.InfoText
        Me.checkSSS.Location = New System.Drawing.Point(23, 78)
        Me.checkSSS.Name = "checkSSS"
        Me.checkSSS.Size = New System.Drawing.Size(51, 20)
        Me.checkSSS.TabIndex = 1
        Me.checkSSS.Text = "SSS"
        Me.checkSSS.UseVisualStyleBackColor = True
        '
        'checkWTax
        '
        Me.checkWTax.AutoSize = True
        Me.checkWTax.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkWTax.ForeColor = System.Drawing.SystemColors.InfoText
        Me.checkWTax.Location = New System.Drawing.Point(23, 31)
        Me.checkWTax.Name = "checkWTax"
        Me.checkWTax.Size = New System.Drawing.Size(60, 20)
        Me.checkWTax.TabIndex = 0
        Me.checkWTax.Text = "WTax"
        Me.checkWTax.UseVisualStyleBackColor = True
        '
        'gbxDeductables
        '
        Me.gbxDeductables.Controls.Add(Me.txtPersonalLoan)
        Me.gbxDeductables.Controls.Add(Me.txtSSS_Loan)
        Me.gbxDeductables.Controls.Add(Me.Label22)
        Me.gbxDeductables.Controls.Add(Me.Label23)
        Me.gbxDeductables.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDeductables.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxDeductables.Location = New System.Drawing.Point(20, 245)
        Me.gbxDeductables.Name = "gbxDeductables"
        Me.gbxDeductables.Size = New System.Drawing.Size(339, 104)
        Me.gbxDeductables.TabIndex = 10
        Me.gbxDeductables.TabStop = False
        Me.gbxDeductables.Text = "Loans"
        '
        'txtPersonalLoan
        '
        Me.txtPersonalLoan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonalLoan.Location = New System.Drawing.Point(24, 35)
        Me.txtPersonalLoan.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPersonalLoan.Name = "txtPersonalLoan"
        Me.txtPersonalLoan.ReadOnly = True
        Me.txtPersonalLoan.Size = New System.Drawing.Size(97, 22)
        Me.txtPersonalLoan.TabIndex = 3
        Me.txtPersonalLoan.Text = "0.0"
        Me.txtPersonalLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSSS_Loan
        '
        Me.txtSSS_Loan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSSS_Loan.Location = New System.Drawing.Point(216, 35)
        Me.txtSSS_Loan.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSSS_Loan.Name = "txtSSS_Loan"
        Me.txtSSS_Loan.ReadOnly = True
        Me.txtSSS_Loan.Size = New System.Drawing.Size(97, 22)
        Me.txtSSS_Loan.TabIndex = 0
        Me.txtSSS_Loan.Text = "0.0"
        Me.txtSSS_Loan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(21, 60)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 14)
        Me.Label22.TabIndex = 21
        Me.Label22.Text = "Personal Loan"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(213, 60)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 14)
        Me.Label23.TabIndex = 15
        Me.Label23.Text = "SSS Loan"
        '
        'gbxSalaries
        '
        Me.gbxSalaries.Controls.Add(Me.txtNumOfDependents)
        Me.gbxSalaries.Controls.Add(Me.txtRegOT_rate)
        Me.gbxSalaries.Controls.Add(Me.txtHolOT_rate)
        Me.gbxSalaries.Controls.Add(Me.Label58)
        Me.gbxSalaries.Controls.Add(Me.Label55)
        Me.gbxSalaries.Controls.Add(Me.txtSunOT_rate)
        Me.gbxSalaries.Controls.Add(Me.Label56)
        Me.gbxSalaries.Controls.Add(Me.cbxPayMethod)
        Me.gbxSalaries.Controls.Add(Me.Label18)
        Me.gbxSalaries.Controls.Add(Me.txtBasicRate)
        Me.gbxSalaries.Controls.Add(Me.Label19)
        Me.gbxSalaries.Controls.Add(Me.Label21)
        Me.gbxSalaries.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxSalaries.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxSalaries.Location = New System.Drawing.Point(20, 15)
        Me.gbxSalaries.Name = "gbxSalaries"
        Me.gbxSalaries.Size = New System.Drawing.Size(339, 212)
        Me.gbxSalaries.TabIndex = 9
        Me.gbxSalaries.TabStop = False
        Me.gbxSalaries.Text = "Salaries and Other Information"
        '
        'txtNumOfDependents
        '
        Me.txtNumOfDependents.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumOfDependents.Location = New System.Drawing.Point(24, 151)
        Me.txtNumOfDependents.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNumOfDependents.Name = "txtNumOfDependents"
        Me.txtNumOfDependents.ReadOnly = True
        Me.txtNumOfDependents.Size = New System.Drawing.Size(62, 22)
        Me.txtNumOfDependents.TabIndex = 2
        Me.txtNumOfDependents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRegOT_rate
        '
        Me.txtRegOT_rate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegOT_rate.Location = New System.Drawing.Point(216, 31)
        Me.txtRegOT_rate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtRegOT_rate.Name = "txtRegOT_rate"
        Me.txtRegOT_rate.ReadOnly = True
        Me.txtRegOT_rate.Size = New System.Drawing.Size(97, 22)
        Me.txtRegOT_rate.TabIndex = 3
        Me.txtRegOT_rate.Text = "1.25"
        Me.txtRegOT_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHolOT_rate
        '
        Me.txtHolOT_rate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHolOT_rate.Location = New System.Drawing.Point(216, 151)
        Me.txtHolOT_rate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtHolOT_rate.Name = "txtHolOT_rate"
        Me.txtHolOT_rate.ReadOnly = True
        Me.txtHolOT_rate.Size = New System.Drawing.Size(97, 22)
        Me.txtHolOT_rate.TabIndex = 5
        Me.txtHolOT_rate.Text = "2"
        Me.txtHolOT_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(213, 176)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(66, 14)
        Me.Label58.TabIndex = 6
        Me.Label58.Text = "holOT rate"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(213, 55)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(68, 14)
        Me.Label55.TabIndex = 30
        Me.Label55.Text = "regOT rate"
        '
        'txtSunOT_rate
        '
        Me.txtSunOT_rate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSunOT_rate.Location = New System.Drawing.Point(216, 92)
        Me.txtSunOT_rate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSunOT_rate.Name = "txtSunOT_rate"
        Me.txtSunOT_rate.ReadOnly = True
        Me.txtSunOT_rate.Size = New System.Drawing.Size(97, 22)
        Me.txtSunOT_rate.TabIndex = 4
        Me.txtSunOT_rate.Text = "1.3"
        Me.txtSunOT_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.Black
        Me.Label56.Location = New System.Drawing.Point(213, 117)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(69, 14)
        Me.Label56.TabIndex = 28
        Me.Label56.Text = "sunOT rate"
        '
        'cbxPayMethod
        '
        Me.cbxPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPayMethod.Enabled = False
        Me.cbxPayMethod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPayMethod.FormattingEnabled = True
        Me.cbxPayMethod.Location = New System.Drawing.Point(24, 31)
        Me.cbxPayMethod.Name = "cbxPayMethod"
        Me.cbxPayMethod.Size = New System.Drawing.Size(97, 22)
        Me.cbxPayMethod.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(21, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 14)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Pay Method"
        '
        'txtBasicRate
        '
        Me.txtBasicRate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBasicRate.Location = New System.Drawing.Point(24, 93)
        Me.txtBasicRate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBasicRate.Name = "txtBasicRate"
        Me.txtBasicRate.ReadOnly = True
        Me.txtBasicRate.Size = New System.Drawing.Size(97, 22)
        Me.txtBasicRate.TabIndex = 1
        Me.txtBasicRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(21, 118)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 14)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Basic Rate"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(21, 176)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(102, 14)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "# of Dependents"
        '
        'TabPageProject
        '
        Me.TabPageProject.Controls.Add(Me.SplitContainer4)
        Me.TabPageProject.Location = New System.Drawing.Point(4, 22)
        Me.TabPageProject.Name = "TabPageProject"
        Me.TabPageProject.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageProject.Size = New System.Drawing.Size(826, 592)
        Me.TabPageProject.TabIndex = 3
        Me.TabPageProject.Tag = "Employee Project"
        Me.TabPageProject.Text = "Project"
        Me.TabPageProject.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.BackColor = System.Drawing.SystemColors.Control
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainer4.Panel2.Controls.Add(Me.EmpProjectUC1)
        Me.SplitContainer4.Size = New System.Drawing.Size(820, 586)
        Me.SplitContainer4.SplitterDistance = 59
        Me.SplitContainer4.TabIndex = 1
        '
        'EmpProjectUC1
        '
        Me.EmpProjectUC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EmpProjectUC1.empNum = CType(0UI, UInteger)
        Me.EmpProjectUC1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpProjectUC1.Location = New System.Drawing.Point(20, 20)
        Me.EmpProjectUC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EmpProjectUC1.myCaller = Nothing
        Me.EmpProjectUC1.myManager = Nothing
        Me.EmpProjectUC1.Name = "EmpProjectUC1"
        Me.EmpProjectUC1.Size = New System.Drawing.Size(790, 390)
        Me.EmpProjectUC1.TabIndex = 0
        '
        'TabPageMisc
        '
        Me.TabPageMisc.Controls.Add(Me.SplitContainer3)
        Me.TabPageMisc.Location = New System.Drawing.Point(4, 22)
        Me.TabPageMisc.Name = "TabPageMisc"
        Me.TabPageMisc.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMisc.Size = New System.Drawing.Size(826, 592)
        Me.TabPageMisc.TabIndex = 2
        Me.TabPageMisc.Tag = "Miscellaneous"
        Me.TabPageMisc.Text = "Miscellaneous"
        Me.TabPageMisc.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainer3.Panel2.Controls.Add(Me.TabCtrlMisc)
        Me.SplitContainer3.Size = New System.Drawing.Size(820, 586)
        Me.SplitContainer3.SplitterDistance = 59
        Me.SplitContainer3.TabIndex = 1
        '
        'TabCtrlMisc
        '
        Me.TabCtrlMisc.Controls.Add(Me.TabPageAllow)
        Me.TabCtrlMisc.Controls.Add(Me.TabPageOtherDed)
        Me.TabCtrlMisc.Controls.Add(Me.TabPageBonus)
        Me.TabCtrlMisc.Location = New System.Drawing.Point(20, 20)
        Me.TabCtrlMisc.Name = "TabCtrlMisc"
        Me.TabCtrlMisc.SelectedIndex = 0
        Me.TabCtrlMisc.Size = New System.Drawing.Size(716, 394)
        Me.TabCtrlMisc.TabIndex = 0
        '
        'TabPageAllow
        '
        Me.TabPageAllow.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageAllow.Controls.Add(Me.AllowanceUC1)
        Me.TabPageAllow.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageAllow.Location = New System.Drawing.Point(4, 25)
        Me.TabPageAllow.Name = "TabPageAllow"
        Me.TabPageAllow.Size = New System.Drawing.Size(708, 365)
        Me.TabPageAllow.TabIndex = 1
        Me.TabPageAllow.Text = "Allowance"
        '
        'AllowanceUC1
        '
        Me.AllowanceUC1.BackColor = System.Drawing.SystemColors.Control
        Me.AllowanceUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AllowanceUC1.empNum = CType(0UI, UInteger)
        Me.AllowanceUC1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllowanceUC1.Location = New System.Drawing.Point(0, 0)
        Me.AllowanceUC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AllowanceUC1.Name = "AllowanceUC1"
        Me.AllowanceUC1.Size = New System.Drawing.Size(708, 365)
        Me.AllowanceUC1.TabIndex = 0
        '
        'TabPageOtherDed
        '
        Me.TabPageOtherDed.Controls.Add(Me.OtherDeductionUC1)
        Me.TabPageOtherDed.Location = New System.Drawing.Point(4, 22)
        Me.TabPageOtherDed.Name = "TabPageOtherDed"
        Me.TabPageOtherDed.Size = New System.Drawing.Size(708, 368)
        Me.TabPageOtherDed.TabIndex = 2
        Me.TabPageOtherDed.Text = "Other Deduction"
        Me.TabPageOtherDed.UseVisualStyleBackColor = True
        '
        'OtherDeductionUC1
        '
        Me.OtherDeductionUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OtherDeductionUC1.empNum = CType(0UI, UInteger)
        Me.OtherDeductionUC1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OtherDeductionUC1.Location = New System.Drawing.Point(0, 0)
        Me.OtherDeductionUC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OtherDeductionUC1.Name = "OtherDeductionUC1"
        Me.OtherDeductionUC1.Size = New System.Drawing.Size(708, 368)
        Me.OtherDeductionUC1.TabIndex = 0
        '
        'TabPageBonus
        '
        Me.TabPageBonus.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageBonus.Controls.Add(Me.BonusUC1)
        Me.TabPageBonus.Location = New System.Drawing.Point(4, 22)
        Me.TabPageBonus.Name = "TabPageBonus"
        Me.TabPageBonus.Size = New System.Drawing.Size(708, 368)
        Me.TabPageBonus.TabIndex = 0
        Me.TabPageBonus.Text = "Bonus"
        '
        'BonusUC1
        '
        Me.BonusUC1.codedDomain_fKey = CType(0UI, UInteger)
        Me.BonusUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BonusUC1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BonusUC1.Location = New System.Drawing.Point(0, 0)
        Me.BonusUC1.Name = "BonusUC1"
        Me.BonusUC1.Size = New System.Drawing.Size(708, 368)
        Me.BonusUC1.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(163, 26)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 618)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        Me.Splitter1.Visible = False
        '
        'NavUCMain
        '
        Me.NavUCMain.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavUCMain.Location = New System.Drawing.Point(0, 26)
        Me.NavUCMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NavUCMain.Name = "NavUCMain"
        Me.NavUCMain.Size = New System.Drawing.Size(163, 618)
        Me.NavUCMain.TabIndex = 3
        '
        'StatusStripMain
        '
        Me.StatusStripMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslblMessage})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 622)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStripMain.Size = New System.Drawing.Size(1000, 22)
        Me.StatusStripMain.TabIndex = 1
        Me.StatusStripMain.Text = "StatusStrip1"
        Me.StatusStripMain.Visible = False
        '
        'tsslblMessage
        '
        Me.tsslblMessage.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tsslblMessage.Name = "tsslblMessage"
        Me.tsslblMessage.Size = New System.Drawing.Size(43, 17)
        Me.tsslblMessage.Text = "Ready"
        Me.tsslblMessage.ToolTipText = "Status"
        '
        'StatusStripUC1
        '
        Me.StatusStripUC1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStripUC1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusStripUC1.Location = New System.Drawing.Point(0, 644)
        Me.StatusStripUC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.StatusStripUC1.Name = "StatusStripUC1"
        Me.StatusStripUC1.Size = New System.Drawing.Size(1000, 22)
        Me.StatusStripUC1.TabIndex = 2
        '
        'MenuUCMain
        '
        Me.MenuUCMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuUCMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuUCMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MenuUCMain.Name = "MenuUCMain"
        Me.MenuUCMain.Size = New System.Drawing.Size(1000, 26)
        Me.MenuUCMain.TabIndex = 0
        '
        'frmEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 750)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEmployee"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "frmEmployee"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.PerformLayout()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.SplitContainerHeader.Panel1.ResumeLayout(False)
        Me.SplitContainerHeader.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerHeader.ResumeLayout(False)
        Me.PanelCompany.ResumeLayout(False)
        Me.PanelCompany.PerformLayout()
        Me.SplitContainerTitle.Panel1.ResumeLayout(False)
        Me.SplitContainerTitle.Panel1.PerformLayout()
        Me.SplitContainerTitle.Panel2.ResumeLayout(False)
        Me.SplitContainerTitle.Panel2.PerformLayout()
        CType(Me.SplitContainerTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerTitle.ResumeLayout(False)
        CType(Me.BindingNavigatorMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigatorMain.ResumeLayout(False)
        Me.BindingNavigatorMain.PerformLayout()
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPagePersonal.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PanelEmpHead.ResumeLayout(False)
        Me.SplitContainerEmpHead.Panel1.ResumeLayout(False)
        Me.SplitContainerEmpHead.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerEmpHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerEmpHead.ResumeLayout(False)
        Me.gbxEmpNum.ResumeLayout(False)
        Me.gbxEmpNum.PerformLayout()
        Me.gbxAffiliation.ResumeLayout(False)
        Me.gbxAffiliation.PerformLayout()
        Me.gbxPersonal.ResumeLayout(False)
        Me.gbxPersonal.PerformLayout()
        Me.TabPageSalary.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxDeductables.ResumeLayout(False)
        Me.gbxDeductables.PerformLayout()
        Me.gbxSalaries.ResumeLayout(False)
        Me.gbxSalaries.PerformLayout()
        Me.TabPageProject.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.TabPageMisc.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.TabCtrlMisc.ResumeLayout(False)
        Me.TabPageAllow.ResumeLayout(False)
        Me.TabPageOtherDed.ResumeLayout(False)
        Me.TabPageBonus.ResumeLayout(False)
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerHeader As System.Windows.Forms.SplitContainer
    Friend WithEvents PanelCompany As System.Windows.Forms.Panel
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents SplitContainerTitle As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents NavUCMain As Presentation.NavUC
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuUCMain As Presentation.MenuUC
    Friend WithEvents BindingNavigatorMain As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPagePersonal As System.Windows.Forms.TabPage
    Friend WithEvents TabPageSalary As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbxPersonal As System.Windows.Forms.GroupBox
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtFN As System.Windows.Forms.TextBox
    Friend WithEvents txtLN As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbxCivilStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents cbxGender As System.Windows.Forms.ComboBox
    Friend WithEvents txtMN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tsbtnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbxAffiliation As System.Windows.Forms.GroupBox
    Friend WithEvents txtTIN_num As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPRC_num As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPAGIBIG_num As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSSS_num As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPhilHealth_num As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpDateHired As System.Windows.Forms.DateTimePicker
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtEmpNum As System.Windows.Forms.TextBox
    Friend WithEvents gbxEmpNum As System.Windows.Forms.GroupBox
    Friend WithEvents PanelEmpHead As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerEmpHead As System.Windows.Forms.SplitContainer
    Friend WithEvents gbxSalaries As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtBasicRate As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbxPayMethod As System.Windows.Forms.ComboBox
    Friend WithEvents gbxDeductables As System.Windows.Forms.GroupBox
    Friend WithEvents txtPersonalLoan As System.Windows.Forms.TextBox
    Friend WithEvents txtSSS_Loan As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TabPageMisc As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cbxStatus As System.Windows.Forms.ComboBox
    Friend WithEvents TabPageProject As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtHolOT_rate As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents txtSunOT_rate As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents EmpProjectUC1 As Presentation.EmpProjectUC
    Friend WithEvents Emp_QuickSearchUC1 As Presentation.Emp_QuickSearchUC
    Friend WithEvents txtNumOfDependents As System.Windows.Forms.TextBox
    Friend WithEvents txtRegOT_rate As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripUC1 As Presentation.StatusStripUC
    Friend WithEvents TabCtrlMisc As System.Windows.Forms.TabControl
    Friend WithEvents TabPageAllow As System.Windows.Forms.TabPage
    Friend WithEvents TabPageOtherDed As System.Windows.Forms.TabPage
    Friend WithEvents TabPageBonus As System.Windows.Forms.TabPage
    Friend WithEvents AllowanceUC1 As Presentation.AllowanceUC
    Friend WithEvents OtherDeductionUC1 As Presentation.OtherDeductionUC
    Friend WithEvents BonusUC1 As Presentation.BonusUC
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents checkPAGIBIG As System.Windows.Forms.CheckBox
    Friend WithEvents checkPhilHealth As System.Windows.Forms.CheckBox
    Friend WithEvents checkSSS As System.Windows.Forms.CheckBox
    Friend WithEvents checkWTax As System.Windows.Forms.CheckBox
End Class