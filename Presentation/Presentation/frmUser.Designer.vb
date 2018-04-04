<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
    Inherits Presentation.PrimaryForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerHeader = New System.Windows.Forms.SplitContainer()
        Me.PanelCompany = New System.Windows.Forms.Panel()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.SplitContainerTitle = New System.Windows.Forms.SplitContainer()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.tabDetail = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.QuickSearchUCMain = New Presentation.QuickSearchUC()
        Me.btnChooseEmployee = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
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
        Me.tsbtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.gbxUser = New System.Windows.Forms.GroupBox()
        Me.btnActivate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConfirmPass = New System.Windows.Forms.MaskedTextBox()
        Me.txtPassword = New System.Windows.Forms.MaskedTextBox()
        Me.btnChangePass = New System.Windows.Forms.Button()
        Me.cbxUserType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtDateCreated = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.NavUCMain = New Presentation.NavUC()
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
        Me.TabControlMain.SuspendLayout()
        Me.tabDetail.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.gbxUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.SplitContainerMain.Panel2.Controls.Add(Me.TabControlMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.Splitter1)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.NavUCMain)
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
        Me.PanelCompany.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
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
        Me.SplitContainerTitle.BackColor = System.Drawing.Color.Gray
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
        Me.SplitContainerTitle.Panel2.Padding = New System.Windows.Forms.Padding(0, 3, 10, 0)
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
        Me.lblTitle.Size = New System.Drawing.Size(147, 21)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "User Master File"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblUser.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(428, 3)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(158, 18)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Welcome, username"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.tabDetail)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.Location = New System.Drawing.Point(166, 26)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(834, 612)
        Me.TabControlMain.TabIndex = 8
        '
        'tabDetail
        '
        Me.tabDetail.Controls.Add(Me.SplitContainer1)
        Me.tabDetail.Location = New System.Drawing.Point(4, 25)
        Me.tabDetail.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.tabDetail.Name = "tabDetail"
        Me.tabDetail.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.tabDetail.Size = New System.Drawing.Size(826, 583)
        Me.tabDetail.TabIndex = 0
        Me.tabDetail.Text = "Detail"
        Me.tabDetail.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 5)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.QuickSearchUCMain)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnChooseEmployee)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCancel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BindingNavigator1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbxUser)
        Me.SplitContainer1.Size = New System.Drawing.Size(820, 573)
        Me.SplitContainer1.SplitterDistance = 63
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'QuickSearchUCMain
        '
        Me.QuickSearchUCMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.QuickSearchUCMain.Location = New System.Drawing.Point(5, 5)
        Me.QuickSearchUCMain.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.QuickSearchUCMain.Name = "QuickSearchUCMain"
        Me.QuickSearchUCMain.Size = New System.Drawing.Size(810, 53)
        Me.QuickSearchUCMain.TabIndex = 0
        '
        'btnChooseEmployee
        '
        Me.btnChooseEmployee.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnChooseEmployee.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChooseEmployee.ForeColor = System.Drawing.Color.Black
        Me.btnChooseEmployee.Location = New System.Drawing.Point(674, 269)
        Me.btnChooseEmployee.Name = "btnChooseEmployee"
        Me.btnChooseEmployee.Size = New System.Drawing.Size(122, 27)
        Me.btnChooseEmployee.TabIndex = 6
        Me.btnChooseEmployee.Text = "Choose employee"
        Me.btnChooseEmployee.UseVisualStyleBackColor = False
        Me.btnChooseEmployee.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(135, 322)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(122, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.Visible = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(262, 322)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        Me.btnSave.Visible = False
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.tsbtnAdd, Me.tsbtnEdit, Me.tsbtnDelete})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 480)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BindingNavigator1.Size = New System.Drawing.Size(820, 25)
        Me.BindingNavigator1.TabIndex = 2
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Enabled = False
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(42, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Enabled = False
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnAdd
        '
        Me.tsbtnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsbtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbtnAdd.Image = Global.Presentation.My.Resources.Resources.plus1
        Me.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAdd.Name = "tsbtnAdd"
        Me.tsbtnAdd.Size = New System.Drawing.Size(52, 22)
        Me.tsbtnAdd.Text = "&ADD"
        Me.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'tsbtnEdit
        '
        Me.tsbtnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsbtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbtnEdit.Image = Global.Presentation.My.Resources.Resources.edit_logo1
        Me.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnEdit.Name = "tsbtnEdit"
        Me.tsbtnEdit.Size = New System.Drawing.Size(55, 22)
        Me.tsbtnEdit.Text = "&EDIT"
        Me.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'tsbtnDelete
        '
        Me.tsbtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tsbtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbtnDelete.Image = Global.Presentation.My.Resources.Resources.Delete_icon2
        Me.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnDelete.Name = "tsbtnDelete"
        Me.tsbtnDelete.Size = New System.Drawing.Size(71, 22)
        Me.tsbtnDelete.Text = "&DELETE"
        Me.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'gbxUser
        '
        Me.gbxUser.Controls.Add(Me.btnActivate)
        Me.gbxUser.Controls.Add(Me.Label1)
        Me.gbxUser.Controls.Add(Me.txtConfirmPass)
        Me.gbxUser.Controls.Add(Me.txtPassword)
        Me.gbxUser.Controls.Add(Me.btnChangePass)
        Me.gbxUser.Controls.Add(Me.cbxUserType)
        Me.gbxUser.Controls.Add(Me.Label9)
        Me.gbxUser.Controls.Add(Me.Label8)
        Me.gbxUser.Controls.Add(Me.Label7)
        Me.gbxUser.Controls.Add(Me.Label6)
        Me.gbxUser.Controls.Add(Me.Label5)
        Me.gbxUser.Controls.Add(Me.Label4)
        Me.gbxUser.Controls.Add(Me.txtStatus)
        Me.gbxUser.Controls.Add(Me.txtDateCreated)
        Me.gbxUser.Controls.Add(Me.txtUsername)
        Me.gbxUser.Controls.Add(Me.txtUserID)
        Me.gbxUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxUser.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxUser.Location = New System.Drawing.Point(33, 33)
        Me.gbxUser.Name = "gbxUser"
        Me.gbxUser.Size = New System.Drawing.Size(353, 285)
        Me.gbxUser.TabIndex = 0
        Me.gbxUser.TabStop = False
        Me.gbxUser.Text = "User Account"
        '
        'btnActivate
        '
        Me.btnActivate.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnActivate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActivate.Location = New System.Drawing.Point(237, 242)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(91, 23)
        Me.btnActivate.TabIndex = 7
        Me.btnActivate.Text = "Activate"
        Me.btnActivate.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 14)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Confirm Password :"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPass.ForeColor = System.Drawing.Color.Black
        Me.txtConfirmPass.Location = New System.Drawing.Point(140, 125)
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPass.ReadOnly = True
        Me.txtConfirmPass.Size = New System.Drawing.Size(188, 22)
        Me.txtConfirmPass.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(140, 96)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.ReadOnly = True
        Me.txtPassword.Size = New System.Drawing.Size(188, 22)
        Me.txtPassword.TabIndex = 2
        '
        'btnChangePass
        '
        Me.btnChangePass.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnChangePass.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePass.ForeColor = System.Drawing.Color.Black
        Me.btnChangePass.Location = New System.Drawing.Point(197, 151)
        Me.btnChangePass.Name = "btnChangePass"
        Me.btnChangePass.Size = New System.Drawing.Size(131, 25)
        Me.btnChangePass.TabIndex = 4
        Me.btnChangePass.Text = "Change Password"
        Me.btnChangePass.UseVisualStyleBackColor = False
        '
        'cbxUserType
        '
        Me.cbxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxUserType.Enabled = False
        Me.cbxUserType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxUserType.ForeColor = System.Drawing.Color.Black
        Me.cbxUserType.FormattingEnabled = True
        Me.cbxUserType.Location = New System.Drawing.Point(140, 183)
        Me.cbxUserType.Name = "cbxUserType"
        Me.cbxUserType.Size = New System.Drawing.Size(188, 22)
        Me.cbxUserType.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(81, 245)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 14)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Status :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(46, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 14)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "DateCreated :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(59, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 14)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "User Type :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(62, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Password :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(59, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Username :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(75, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "User ID :"
        '
        'txtStatus
        '
        Me.txtStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.ForeColor = System.Drawing.Color.Black
        Me.txtStatus.Location = New System.Drawing.Point(140, 242)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(91, 22)
        Me.txtStatus.TabIndex = 5
        '
        'txtDateCreated
        '
        Me.txtDateCreated.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.Location = New System.Drawing.Point(140, 213)
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.ReadOnly = True
        Me.txtDateCreated.Size = New System.Drawing.Size(188, 22)
        Me.txtDateCreated.TabIndex = 6
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.Black
        Me.txtUsername.Location = New System.Drawing.Point(140, 67)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(188, 22)
        Me.txtUsername.TabIndex = 1
        '
        'txtUserID
        '
        Me.txtUserID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.ForeColor = System.Drawing.Color.Black
        Me.txtUserID.Location = New System.Drawing.Point(140, 38)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.ReadOnly = True
        Me.txtUserID.Size = New System.Drawing.Size(113, 22)
        Me.txtUserID.TabIndex = 0
        Me.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(163, 26)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 612)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        Me.Splitter1.Visible = False
        '
        'NavUCMain
        '
        Me.NavUCMain.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavUCMain.Location = New System.Drawing.Point(0, 26)
        Me.NavUCMain.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.NavUCMain.Name = "NavUCMain"
        Me.NavUCMain.Size = New System.Drawing.Size(163, 612)
        Me.NavUCMain.TabIndex = 3
        '
        'StatusStripUC1
        '
        Me.StatusStripUC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.StatusStripUC1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusStripUC1.Location = New System.Drawing.Point(0, 638)
        Me.StatusStripUC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.StatusStripUC1.Name = "StatusStripUC1"
        Me.StatusStripUC1.Size = New System.Drawing.Size(1000, 28)
        Me.StatusStripUC1.TabIndex = 2
        '
        'MenuUCMain
        '
        Me.MenuUCMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuUCMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuUCMain.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.MenuUCMain.Name = "MenuUCMain"
        Me.MenuUCMain.Size = New System.Drawing.Size(1000, 26)
        Me.MenuUCMain.TabIndex = 0
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 750)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmUser"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "User"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
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
        Me.TabControlMain.ResumeLayout(False)
        Me.tabDetail.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.gbxUser.ResumeLayout(False)
        Me.gbxUser.PerformLayout()
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
    Friend WithEvents MenuUCMain As Presentation.MenuUC
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDetail As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnChooseEmployee As System.Windows.Forms.Button
    Friend WithEvents gbxUser As System.Windows.Forms.GroupBox
    Friend WithEvents txtConfirmPass As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPassword As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnChangePass As System.Windows.Forms.Button
    Friend WithEvents cbxUserType As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtDateCreated As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnActivate As System.Windows.Forms.Button
    Friend WithEvents QuickSearchUCMain As Presentation.QuickSearchUC
    Friend WithEvents StatusStripUC1 As Presentation.StatusStripUC
End Class
