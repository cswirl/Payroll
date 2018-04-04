<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpChooser
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Emp_QuickSearchUC1 = New Presentation.Emp_QuickSearchUC()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvEmployee = New System.Windows.Forms.DataGridView()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.tslblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(10, 10)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        Me.SplitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblTitle)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainerMain.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainerMain.Size = New System.Drawing.Size(880, 658)
        Me.SplitContainerMain.SplitterDistance = 55
        Me.SplitContainerMain.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTitle.Location = New System.Drawing.Point(12, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(157, 23)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Choose Employee"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2.Panel1.Controls.Add(Me.Emp_QuickSearchUC1)
        Me.SplitContainer2.Panel1.Padding = New System.Windows.Forms.Padding(10, 5, 10, 10)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnOK)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnExit)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvEmployee)
        Me.SplitContainer2.Size = New System.Drawing.Size(878, 597)
        Me.SplitContainer2.SplitterDistance = 65
        Me.SplitContainer2.TabIndex = 0
        '
        'Emp_QuickSearchUC1
        '
        Me.Emp_QuickSearchUC1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Emp_QuickSearchUC1.Location = New System.Drawing.Point(10, 5)
        Me.Emp_QuickSearchUC1.Name = "Emp_QuickSearchUC1"
        Me.Emp_QuickSearchUC1.Size = New System.Drawing.Size(858, 60)
        Me.Emp_QuickSearchUC1.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnOK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(745, 479)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(124, 28)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(615, 479)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(124, 28)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Blue
        Me.Panel1.Controls.Add(Me.lblRecordCount)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Location = New System.Drawing.Point(9, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(860, 23)
        Me.Panel1.TabIndex = 8
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblRecordCount.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblRecordCount.Location = New System.Drawing.Point(771, 0)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Padding = New System.Windows.Forms.Padding(0, 8, 5, 0)
        Me.lblRecordCount.Size = New System.Drawing.Size(89, 19)
        Me.lblRecordCount.TabIndex = 3
        Me.lblRecordCount.Text = "0 records found"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label15.Location = New System.Drawing.Point(4, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 16)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Employee"
        '
        'dgvEmployee
        '
        Me.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployee.Location = New System.Drawing.Point(9, 38)
        Me.dgvEmployee.Name = "dgvEmployee"
        Me.dgvEmployee.Size = New System.Drawing.Size(860, 432)
        Me.dgvEmployee.TabIndex = 7
        '
        'StatusStripMain
        '
        Me.StatusStripMain.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblMessage})
        Me.StatusStripMain.Location = New System.Drawing.Point(10, 668)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Size = New System.Drawing.Size(880, 22)
        Me.StatusStripMain.TabIndex = 4
        Me.StatusStripMain.Text = "StatusStrip1"
        '
        'tslblMessage
        '
        Me.tslblMessage.BackColor = System.Drawing.Color.Gainsboro
        Me.tslblMessage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblMessage.Name = "tslblMessage"
        Me.tslblMessage.Size = New System.Drawing.Size(43, 17)
        Me.tslblMessage.Text = "Ready"
        '
        'frmEmpChooser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(900, 700)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Controls.Add(Me.StatusStripMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEmpChooser"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employees"
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.PerformLayout()
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tslblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Emp_QuickSearchUC1 As Presentation.Emp_QuickSearchUC
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgvEmployee As System.Windows.Forms.DataGridView
End Class