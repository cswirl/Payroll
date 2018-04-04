<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTables
    Inherits System.Windows.Forms.Form

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
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.Header1 = New Presentation.Header()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPageProject = New System.Windows.Forms.TabPage()
        Me.CodedDomainUC_Project = New Presentation.CodedDomainUC()
        Me.TabPagePosition = New System.Windows.Forms.TabPage()
        Me.CodedDomainUC_Position = New Presentation.CodedDomainUC()
        Me.TabPageDivision = New System.Windows.Forms.TabPage()
        Me.CodedDomainUC_Division = New Presentation.CodedDomainUC()
        Me.TabPageAllowance = New System.Windows.Forms.TabPage()
        Me.CodedDomainUC_Allowance = New Presentation.CodedDomainUC()
        Me.TabPageBonus = New System.Windows.Forms.TabPage()
        Me.CodedDomainUC_Bonus = New Presentation.CodedDomainUC()
        Me.TabPageDeduction = New System.Windows.Forms.TabPage()
        Me.CodedDomainUC_Deduction = New Presentation.CodedDomainUC()
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
        Me.TabControlMain.SuspendLayout()
        Me.TabPageProject.SuspendLayout()
        Me.TabPagePosition.SuspendLayout()
        Me.TabPageDivision.SuspendLayout()
        Me.TabPageAllowance.SuspendLayout()
        Me.TabPageBonus.SuspendLayout()
        Me.TabPageDeduction.SuspendLayout()
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
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Header1)
        '
        'SplitContainerMain.Panel2
        '
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
        'Header1
        '
        Me.Header1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Header1.Location = New System.Drawing.Point(0, 0)
        Me.Header1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Header1.Name = "Header1"
        Me.Header1.Size = New System.Drawing.Size(1000, 60)
        Me.Header1.TabIndex = 0
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPageProject)
        Me.TabControlMain.Controls.Add(Me.TabPagePosition)
        Me.TabControlMain.Controls.Add(Me.TabPageDivision)
        Me.TabControlMain.Controls.Add(Me.TabPageAllowance)
        Me.TabControlMain.Controls.Add(Me.TabPageBonus)
        Me.TabControlMain.Controls.Add(Me.TabPageDeduction)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Location = New System.Drawing.Point(166, 26)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(834, 612)
        Me.TabControlMain.TabIndex = 5
        '
        'TabPageProject
        '
        Me.TabPageProject.Controls.Add(Me.CodedDomainUC_Project)
        Me.TabPageProject.Location = New System.Drawing.Point(4, 25)
        Me.TabPageProject.Name = "TabPageProject"
        Me.TabPageProject.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageProject.Size = New System.Drawing.Size(826, 583)
        Me.TabPageProject.TabIndex = 5
        Me.TabPageProject.Text = "Project"
        Me.TabPageProject.UseVisualStyleBackColor = True
        '
        'CodedDomainUC_Project
        '
        Me.CodedDomainUC_Project.Dock = System.Windows.Forms.DockStyle.Top
        Me.CodedDomainUC_Project.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodedDomainUC_Project.Location = New System.Drawing.Point(3, 3)
        Me.CodedDomainUC_Project.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CodedDomainUC_Project.Name = "CodedDomainUC_Project"
        Me.CodedDomainUC_Project.Size = New System.Drawing.Size(820, 657)
        Me.CodedDomainUC_Project.TabIndex = 0
        '
        'TabPagePosition
        '
        Me.TabPagePosition.Controls.Add(Me.CodedDomainUC_Position)
        Me.TabPagePosition.Location = New System.Drawing.Point(4, 25)
        Me.TabPagePosition.Name = "TabPagePosition"
        Me.TabPagePosition.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagePosition.Size = New System.Drawing.Size(826, 583)
        Me.TabPagePosition.TabIndex = 0
        Me.TabPagePosition.Tag = "Position Table"
        Me.TabPagePosition.Text = "Position"
        Me.TabPagePosition.UseVisualStyleBackColor = True
        '
        'CodedDomainUC_Position
        '
        Me.CodedDomainUC_Position.Dock = System.Windows.Forms.DockStyle.Top
        Me.CodedDomainUC_Position.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodedDomainUC_Position.Location = New System.Drawing.Point(3, 3)
        Me.CodedDomainUC_Position.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CodedDomainUC_Position.Name = "CodedDomainUC_Position"
        Me.CodedDomainUC_Position.Size = New System.Drawing.Size(820, 657)
        Me.CodedDomainUC_Position.TabIndex = 0
        '
        'TabPageDivision
        '
        Me.TabPageDivision.Controls.Add(Me.CodedDomainUC_Division)
        Me.TabPageDivision.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDivision.Name = "TabPageDivision"
        Me.TabPageDivision.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDivision.Size = New System.Drawing.Size(826, 583)
        Me.TabPageDivision.TabIndex = 1
        Me.TabPageDivision.Tag = "Division Table"
        Me.TabPageDivision.Text = "Division"
        Me.TabPageDivision.UseVisualStyleBackColor = True
        '
        'CodedDomainUC_Division
        '
        Me.CodedDomainUC_Division.Dock = System.Windows.Forms.DockStyle.Top
        Me.CodedDomainUC_Division.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodedDomainUC_Division.Location = New System.Drawing.Point(3, 3)
        Me.CodedDomainUC_Division.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CodedDomainUC_Division.Name = "CodedDomainUC_Division"
        Me.CodedDomainUC_Division.Size = New System.Drawing.Size(820, 657)
        Me.CodedDomainUC_Division.TabIndex = 0
        '
        'TabPageAllowance
        '
        Me.TabPageAllowance.Controls.Add(Me.CodedDomainUC_Allowance)
        Me.TabPageAllowance.Location = New System.Drawing.Point(4, 25)
        Me.TabPageAllowance.Name = "TabPageAllowance"
        Me.TabPageAllowance.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAllowance.Size = New System.Drawing.Size(826, 583)
        Me.TabPageAllowance.TabIndex = 2
        Me.TabPageAllowance.Text = "Allowance Type"
        Me.TabPageAllowance.UseVisualStyleBackColor = True
        '
        'CodedDomainUC_Allowance
        '
        Me.CodedDomainUC_Allowance.Dock = System.Windows.Forms.DockStyle.Top
        Me.CodedDomainUC_Allowance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodedDomainUC_Allowance.Location = New System.Drawing.Point(3, 3)
        Me.CodedDomainUC_Allowance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CodedDomainUC_Allowance.Name = "CodedDomainUC_Allowance"
        Me.CodedDomainUC_Allowance.Size = New System.Drawing.Size(820, 657)
        Me.CodedDomainUC_Allowance.TabIndex = 0
        '
        'TabPageBonus
        '
        Me.TabPageBonus.Controls.Add(Me.CodedDomainUC_Bonus)
        Me.TabPageBonus.Location = New System.Drawing.Point(4, 25)
        Me.TabPageBonus.Name = "TabPageBonus"
        Me.TabPageBonus.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageBonus.Size = New System.Drawing.Size(826, 583)
        Me.TabPageBonus.TabIndex = 3
        Me.TabPageBonus.Text = "Bonus Type"
        Me.TabPageBonus.UseVisualStyleBackColor = True
        '
        'CodedDomainUC_Bonus
        '
        Me.CodedDomainUC_Bonus.Dock = System.Windows.Forms.DockStyle.Top
        Me.CodedDomainUC_Bonus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodedDomainUC_Bonus.Location = New System.Drawing.Point(3, 3)
        Me.CodedDomainUC_Bonus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CodedDomainUC_Bonus.Name = "CodedDomainUC_Bonus"
        Me.CodedDomainUC_Bonus.Size = New System.Drawing.Size(820, 657)
        Me.CodedDomainUC_Bonus.TabIndex = 0
        '
        'TabPageDeduction
        '
        Me.TabPageDeduction.Controls.Add(Me.CodedDomainUC_Deduction)
        Me.TabPageDeduction.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDeduction.Name = "TabPageDeduction"
        Me.TabPageDeduction.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDeduction.Size = New System.Drawing.Size(826, 583)
        Me.TabPageDeduction.TabIndex = 4
        Me.TabPageDeduction.Text = "Deduction Type"
        Me.TabPageDeduction.UseVisualStyleBackColor = True
        '
        'CodedDomainUC_Deduction
        '
        Me.CodedDomainUC_Deduction.Dock = System.Windows.Forms.DockStyle.Top
        Me.CodedDomainUC_Deduction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodedDomainUC_Deduction.Location = New System.Drawing.Point(3, 3)
        Me.CodedDomainUC_Deduction.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CodedDomainUC_Deduction.Name = "CodedDomainUC_Deduction"
        Me.CodedDomainUC_Deduction.Size = New System.Drawing.Size(820, 657)
        Me.CodedDomainUC_Deduction.TabIndex = 0
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
        Me.NavUCMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NavUCMain.Name = "NavUCMain"
        Me.NavUCMain.Size = New System.Drawing.Size(163, 612)
        Me.NavUCMain.TabIndex = 3
        '
        'StatusStripMain
        '
        Me.StatusStripMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslblMessage})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 616)
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
        Me.MenuUCMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MenuUCMain.Name = "MenuUCMain"
        Me.MenuUCMain.Size = New System.Drawing.Size(1000, 26)
        Me.MenuUCMain.TabIndex = 0
        '
        'frmTables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 750)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmTables"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "frmTables"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.PerformLayout()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageProject.ResumeLayout(False)
        Me.TabPagePosition.ResumeLayout(False)
        Me.TabPageDivision.ResumeLayout(False)
        Me.TabPageAllowance.ResumeLayout(False)
        Me.TabPageBonus.ResumeLayout(False)
        Me.TabPageDeduction.ResumeLayout(False)
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPagePosition As System.Windows.Forms.TabPage
    Friend WithEvents TabPageDivision As System.Windows.Forms.TabPage
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents NavUCMain As Presentation.NavUC
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuUCMain As Presentation.MenuUC
    Friend WithEvents TabPageAllowance As System.Windows.Forms.TabPage
    Friend WithEvents CodedDomainUC_Position As Presentation.CodedDomainUC
    Friend WithEvents CodedDomainUC_Allowance As Presentation.CodedDomainUC
    Friend WithEvents CodedDomainUC_Division As Presentation.CodedDomainUC
    Friend WithEvents TabPageBonus As System.Windows.Forms.TabPage
    Friend WithEvents CodedDomainUC_Bonus As Presentation.CodedDomainUC
    Friend WithEvents TabPageDeduction As System.Windows.Forms.TabPage
    Friend WithEvents CodedDomainUC_Deduction As Presentation.CodedDomainUC
    Friend WithEvents TabPageProject As System.Windows.Forms.TabPage
    Friend WithEvents CodedDomainUC_Project As Presentation.CodedDomainUC
    Friend WithEvents StatusStripUC1 As Presentation.StatusStripUC
    Friend WithEvents Header1 As Presentation.Header
End Class
