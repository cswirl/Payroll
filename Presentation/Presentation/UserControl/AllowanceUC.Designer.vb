<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllowanceUC
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
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.gbxAddNew = New System.Windows.Forms.GroupBox()
        Me.checkTaxable = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.cbxDomain = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.PanelTitle = New System.Windows.Forms.Panel()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.lblTableTitle = New System.Windows.Forms.Label()
        Me.dgvContext = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.gbxAddNew.SuspendLayout()
        Me.PanelTitle.SuspendLayout()
        CType(Me.dgvContext, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.gbxAddNew)
        Me.SplitContainer5.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer5.Panel1MinSize = 5
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainer5.Panel2.Controls.Add(Me.PanelTitle)
        Me.SplitContainer5.Panel2.Controls.Add(Me.dgvContext)
        Me.SplitContainer5.Size = New System.Drawing.Size(720, 350)
        Me.SplitContainer5.SplitterDistance = 77
        Me.SplitContainer5.TabIndex = 2
        '
        'gbxAddNew
        '
        Me.gbxAddNew.Controls.Add(Me.checkTaxable)
        Me.gbxAddNew.Controls.Add(Me.Label28)
        Me.gbxAddNew.Controls.Add(Me.lblType)
        Me.gbxAddNew.Controls.Add(Me.txtAmount)
        Me.gbxAddNew.Controls.Add(Me.cbxDomain)
        Me.gbxAddNew.Controls.Add(Me.btnDelete)
        Me.gbxAddNew.Controls.Add(Me.btnAdd)
        Me.gbxAddNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxAddNew.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAddNew.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxAddNew.Location = New System.Drawing.Point(5, 5)
        Me.gbxAddNew.Name = "gbxAddNew"
        Me.gbxAddNew.Size = New System.Drawing.Size(710, 67)
        Me.gbxAddNew.TabIndex = 0
        Me.gbxAddNew.TabStop = False
        Me.gbxAddNew.Text = "Add [what]"
        '
        'checkTaxable
        '
        Me.checkTaxable.AutoSize = True
        Me.checkTaxable.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkTaxable.Location = New System.Drawing.Point(292, 21)
        Me.checkTaxable.Name = "checkTaxable"
        Me.checkTaxable.Size = New System.Drawing.Size(68, 20)
        Me.checkTaxable.TabIndex = 15
        Me.checkTaxable.Text = "taxable"
        Me.checkTaxable.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(185, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 14)
        Me.Label28.TabIndex = 14
        Me.Label28.Text = "amount"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(11, 44)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(108, 14)
        Me.lblType.TabIndex = 13
        Me.lblType.Text = "Choose what type"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(185, 21)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(101, 22)
        Me.txtAmount.TabIndex = 12
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxDomain
        '
        Me.cbxDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDomain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDomain.FormattingEnabled = True
        Me.cbxDomain.Location = New System.Drawing.Point(14, 21)
        Me.cbxDomain.Name = "cbxDomain"
        Me.cbxDomain.Size = New System.Drawing.Size(165, 22)
        Me.cbxDomain.TabIndex = 9
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnDelete.Location = New System.Drawing.Point(584, 19)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(102, 25)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnAdd.Location = New System.Drawing.Point(366, 19)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(102, 25)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'PanelTitle
        '
        Me.PanelTitle.BackColor = System.Drawing.Color.Blue
        Me.PanelTitle.Controls.Add(Me.lblRecordCount)
        Me.PanelTitle.Controls.Add(Me.lblTableTitle)
        Me.PanelTitle.Location = New System.Drawing.Point(19, 16)
        Me.PanelTitle.Name = "PanelTitle"
        Me.PanelTitle.Size = New System.Drawing.Size(672, 20)
        Me.PanelTitle.TabIndex = 7
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblRecordCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.ForeColor = System.Drawing.Color.Transparent
        Me.lblRecordCount.Location = New System.Drawing.Point(561, 0)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Padding = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.lblRecordCount.Size = New System.Drawing.Size(111, 18)
        Me.lblRecordCount.TabIndex = 1
        Me.lblRecordCount.Text = "0 record/s found"
        Me.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblTableTitle
        '
        Me.lblTableTitle.AutoSize = True
        Me.lblTableTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableTitle.ForeColor = System.Drawing.Color.Transparent
        Me.lblTableTitle.Location = New System.Drawing.Point(12, 2)
        Me.lblTableTitle.Name = "lblTableTitle"
        Me.lblTableTitle.Size = New System.Drawing.Size(35, 16)
        Me.lblTableTitle.TabIndex = 0
        Me.lblTableTitle.Text = "Title"
        Me.lblTableTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvContext
        '
        Me.dgvContext.AllowUserToOrderColumns = True
        Me.dgvContext.AllowUserToResizeColumns = False
        Me.dgvContext.AllowUserToResizeRows = False
        Me.dgvContext.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvContext.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvContext.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContext.Location = New System.Drawing.Point(19, 36)
        Me.dgvContext.Name = "dgvContext"
        Me.dgvContext.Size = New System.Drawing.Size(672, 197)
        Me.dgvContext.TabIndex = 0
        '
        'AllowanceUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.SplitContainer5)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "AllowanceUC"
        Me.Size = New System.Drawing.Size(720, 350)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.gbxAddNew.ResumeLayout(False)
        Me.gbxAddNew.PerformLayout()
        Me.PanelTitle.ResumeLayout(False)
        Me.PanelTitle.PerformLayout()
        CType(Me.dgvContext, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbxAddNew As System.Windows.Forms.GroupBox
    Friend WithEvents checkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents cbxDomain As System.Windows.Forms.ComboBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents PanelTitle As System.Windows.Forms.Panel
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents lblTableTitle As System.Windows.Forms.Label
    Friend WithEvents dgvContext As System.Windows.Forms.DataGridView

End Class
