<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayrollReport
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
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.Header1 = New Presentation.Header()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.tabPayrollReport = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnConsolePayrollReg = New System.Windows.Forms.Button()
        Me.btnPayrollSheet = New System.Windows.Forms.Button()
        Me.NavUCMain = New Presentation.NavUC()
        Me.StatusStripUC1 = New Presentation.StatusStripUC()
        Me.MenuUCMain = New Presentation.MenuUC()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.tabPayrollReport.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(163, 26)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 615)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        Me.Splitter1.Visible = False
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
        Me.TabControlMain.Controls.Add(Me.tabPayrollReport)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.Location = New System.Drawing.Point(166, 26)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(834, 615)
        Me.TabControlMain.TabIndex = 6
        '
        'tabPayrollReport
        '
        Me.tabPayrollReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tabPayrollReport.Controls.Add(Me.Panel1)
        Me.tabPayrollReport.Location = New System.Drawing.Point(4, 25)
        Me.tabPayrollReport.Name = "tabPayrollReport"
        Me.tabPayrollReport.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPayrollReport.Size = New System.Drawing.Size(826, 586)
        Me.tabPayrollReport.TabIndex = 0
        Me.tabPayrollReport.Text = "Payroll Reporting"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnConsolePayrollReg)
        Me.Panel1.Controls.Add(Me.btnPayrollSheet)
        Me.Panel1.Location = New System.Drawing.Point(20, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(389, 542)
        Me.Panel1.TabIndex = 0
        '
        'btnConsolePayrollReg
        '
        Me.btnConsolePayrollReg.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnConsolePayrollReg.Location = New System.Drawing.Point(13, 51)
        Me.btnConsolePayrollReg.Name = "btnConsolePayrollReg"
        Me.btnConsolePayrollReg.Size = New System.Drawing.Size(364, 29)
        Me.btnConsolePayrollReg.TabIndex = 1
        Me.btnConsolePayrollReg.Text = "Consolidated Payroll Register"
        Me.btnConsolePayrollReg.UseVisualStyleBackColor = False
        '
        'btnPayrollSheet
        '
        Me.btnPayrollSheet.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnPayrollSheet.Location = New System.Drawing.Point(13, 16)
        Me.btnPayrollSheet.Name = "btnPayrollSheet"
        Me.btnPayrollSheet.Size = New System.Drawing.Size(364, 29)
        Me.btnPayrollSheet.TabIndex = 0
        Me.btnPayrollSheet.Text = "Payroll Sheet"
        Me.btnPayrollSheet.UseVisualStyleBackColor = False
        '
        'NavUCMain
        '
        Me.NavUCMain.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavUCMain.Location = New System.Drawing.Point(0, 26)
        Me.NavUCMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NavUCMain.Name = "NavUCMain"
        Me.NavUCMain.Size = New System.Drawing.Size(163, 615)
        Me.NavUCMain.TabIndex = 3
        '
        'StatusStripUC1
        '
        Me.StatusStripUC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.StatusStripUC1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusStripUC1.Location = New System.Drawing.Point(0, 641)
        Me.StatusStripUC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.StatusStripUC1.Name = "StatusStripUC1"
        Me.StatusStripUC1.Size = New System.Drawing.Size(1000, 25)
        Me.StatusStripUC1.TabIndex = 5
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
        'frmPayrollReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 750)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPayrollReport"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Payroll Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.tabPayrollReport.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents Header1 As Presentation.Header
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabPayrollReport As System.Windows.Forms.TabPage
    Friend WithEvents NavUCMain As Presentation.NavUC
    Friend WithEvents StatusStripUC1 As Presentation.StatusStripUC
    Friend WithEvents MenuUCMain As Presentation.MenuUC
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnConsolePayrollReg As System.Windows.Forms.Button
    Friend WithEvents btnPayrollSheet As System.Windows.Forms.Button
End Class
