<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subForm
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
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer
        Me.lblTitle = New System.Windows.Forms.Label
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip
        Me.tsslblMessage = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.StatusStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerMain
        '
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
        Me.SplitContainerMain.Panel2.Controls.Add(Me.StatusStripMain)
        Me.SplitContainerMain.Size = New System.Drawing.Size(575, 412)
        Me.SplitContainerMain.SplitterDistance = 45
        Me.SplitContainerMain.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 11)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(58, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStripMain
        '
        Me.StatusStripMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslblMessage})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 341)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStripMain.Size = New System.Drawing.Size(575, 22)
        Me.StatusStripMain.TabIndex = 0
        Me.StatusStripMain.Text = "StatusStrip1"
        '
        'tsslblMessage
        '
        Me.tsslblMessage.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tsslblMessage.Name = "tsslblMessage"
        Me.tsslblMessage.Size = New System.Drawing.Size(43, 17)
        Me.tsslblMessage.Text = "Ready"
        Me.tsslblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsslblMessage.ToolTipText = "Status"
        '
        'frmCodedDomain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(595, 432)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCodedDomain"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.PerformLayout()
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.PerformLayout()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslblMessage As System.Windows.Forms.ToolStripStatusLabel
End Class
