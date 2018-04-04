<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
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
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPageResearch = New System.Windows.Forms.TabPage()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.NavUC1 = New Presentation.NavUC()
        Me.MenuMain = New Presentation.MenuUC()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.tsslblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
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
        Me.SplitContainerMain.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblTitle)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SplitContainerMain.Panel2.Controls.Add(Me.TabControlMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.Splitter1)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.NavUC1)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.MenuMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.StatusStripMain)
        Me.SplitContainerMain.Panel2.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1000, 730)
        Me.SplitContainerMain.SplitterWidth = 5
        Me.SplitContainerMain.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblTitle.Location = New System.Drawing.Point(30, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(66, 23)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Home"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPageResearch)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.Location = New System.Drawing.Point(171, 24)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(824, 624)
        Me.TabControlMain.TabIndex = 5
        '
        'TabPageResearch
        '
        Me.TabPageResearch.Location = New System.Drawing.Point(4, 25)
        Me.TabPageResearch.Name = "TabPageResearch"
        Me.TabPageResearch.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageResearch.Size = New System.Drawing.Size(816, 595)
        Me.TabPageResearch.TabIndex = 0
        Me.TabPageResearch.Text = "Research"
        Me.TabPageResearch.UseVisualStyleBackColor = True
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(168, 24)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 624)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        '
        'NavUC1
        '
        Me.NavUC1.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavUC1.Location = New System.Drawing.Point(5, 24)
        Me.NavUC1.Name = "NavUC1"
        Me.NavUC1.Size = New System.Drawing.Size(163, 624)
        Me.NavUC1.TabIndex = 3
        '
        'MenuMain
        '
        Me.MenuMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.MenuMain.Location = New System.Drawing.Point(5, 0)
        Me.MenuMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MenuMain.Name = "MenuMain"
        Me.MenuMain.Size = New System.Drawing.Size(990, 24)
        Me.MenuMain.TabIndex = 2
        '
        'StatusStripMain
        '
        Me.StatusStripMain.BackColor = System.Drawing.SystemColors.ControlLight
        Me.StatusStripMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslblMessage})
        Me.StatusStripMain.Location = New System.Drawing.Point(5, 648)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Size = New System.Drawing.Size(990, 22)
        Me.StatusStripMain.TabIndex = 1
        Me.StatusStripMain.Text = "StatusStrip1"
        '
        'tsslblMessage
        '
        Me.tsslblMessage.Name = "tsslblMessage"
        Me.tsslblMessage.Size = New System.Drawing.Size(43, 17)
        Me.tsslblMessage.Text = "Ready"
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 750)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmHome"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.PerformLayout()
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.PerformLayout()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents MenuMain As Presentation.MenuUC
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NavUC1 As Presentation.NavUC
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPageResearch As System.Windows.Forms.TabPage
End Class
