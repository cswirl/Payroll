<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodedDomainUC
    Inherits System.Windows.Forms.UserControl

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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbxTitle = New System.Windows.Forms.GroupBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtdgvCourier = New System.Windows.Forms.TextBox()
        Me.dgvContext = New System.Windows.Forms.DataGridView()
        Me.PanelTitle = New System.Windows.Forms.Panel()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.lblTableTitle = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbxTitle.SuspendLayout()
        CType(Me.dgvContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbxTitle)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(6)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtdgvCourier)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvContext)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelTitle)
        Me.SplitContainer1.Size = New System.Drawing.Size(973, 657)
        Me.SplitContainer1.SplitterDistance = 65
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'gbxTitle
        '
        Me.gbxTitle.Controls.Add(Me.txtName)
        Me.gbxTitle.Controls.Add(Me.btnUpdate)
        Me.gbxTitle.Controls.Add(Me.btnDelete)
        Me.gbxTitle.Controls.Add(Me.btnAdd)
        Me.gbxTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxTitle.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxTitle.Location = New System.Drawing.Point(6, 6)
        Me.gbxTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbxTitle.Name = "gbxTitle"
        Me.gbxTitle.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbxTitle.Size = New System.Drawing.Size(961, 53)
        Me.gbxTitle.TabIndex = 0
        Me.gbxTitle.TabStop = False
        Me.gbxTitle.Text = "Add New"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(23, 22)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(205, 22)
        Me.txtName.TabIndex = 3
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(623, 20)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(149, 25)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(453, 20)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(149, 25)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(234, 20)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(149, 25)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txtdgvCourier
        '
        Me.txtdgvCourier.Location = New System.Drawing.Point(32, 419)
        Me.txtdgvCourier.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtdgvCourier.Name = "txtdgvCourier"
        Me.txtdgvCourier.Size = New System.Drawing.Size(180, 23)
        Me.txtdgvCourier.TabIndex = 2
        '
        'dgvContext
        '
        Me.dgvContext.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvContext.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvContext.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContext.Location = New System.Drawing.Point(32, 61)
        Me.dgvContext.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvContext.Name = "dgvContext"
        Me.dgvContext.Size = New System.Drawing.Size(755, 350)
        Me.dgvContext.TabIndex = 1
        '
        'PanelTitle
        '
        Me.PanelTitle.BackColor = System.Drawing.Color.Blue
        Me.PanelTitle.Controls.Add(Me.lblRecordCount)
        Me.PanelTitle.Controls.Add(Me.lblTableTitle)
        Me.PanelTitle.Location = New System.Drawing.Point(32, 35)
        Me.PanelTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelTitle.Name = "PanelTitle"
        Me.PanelTitle.Size = New System.Drawing.Size(755, 28)
        Me.PanelTitle.TabIndex = 0
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblRecordCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.ForeColor = System.Drawing.Color.White
        Me.lblRecordCount.Location = New System.Drawing.Point(648, 0)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Padding = New System.Windows.Forms.Padding(0, 9, 6, 0)
        Me.lblRecordCount.Size = New System.Drawing.Size(107, 22)
        Me.lblRecordCount.TabIndex = 1
        Me.lblRecordCount.Text = "0 record/s found"
        '
        'lblTableTitle
        '
        Me.lblTableTitle.AutoSize = True
        Me.lblTableTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableTitle.ForeColor = System.Drawing.Color.White
        Me.lblTableTitle.Location = New System.Drawing.Point(20, 5)
        Me.lblTableTitle.Name = "lblTableTitle"
        Me.lblTableTitle.Size = New System.Drawing.Size(93, 16)
        Me.lblTableTitle.TabIndex = 0
        Me.lblTableTitle.Text = "Domain Table"
        '
        'CodedDomainUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "CodedDomainUC"
        Me.Size = New System.Drawing.Size(973, 657)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbxTitle.ResumeLayout(False)
        Me.gbxTitle.PerformLayout()
        CType(Me.dgvContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTitle.ResumeLayout(False)
        Me.PanelTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbxTitle As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents PanelTitle As System.Windows.Forms.Panel
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents lblTableTitle As System.Windows.Forms.Label
    Friend WithEvents txtdgvCourier As System.Windows.Forms.TextBox
    Friend WithEvents dgvContext As System.Windows.Forms.DataGridView

End Class
