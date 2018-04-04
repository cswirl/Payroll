<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeductables
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
        Me.TabPageWTaxWeekly = New System.Windows.Forms.TabPage()
        Me.WTaxUC_Weekly = New Presentation.WTaxUC()
        Me.TabPageWTaxSemi = New System.Windows.Forms.TabPage()
        Me.WTaxUC_Semi = New Presentation.WTaxUC()
        Me.TabPageSSS = New System.Windows.Forms.TabPage()
        Me.SsS_UC1 = New Presentation.SSS_UC()
        Me.TabPagePhilHealth = New System.Windows.Forms.TabPage()
        Me.PhilHealthUC1 = New Presentation.PhilHealthUC()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.NavUCMain = New Presentation.NavUC()
        Me.StatusStripUC1 = New Presentation.StatusStripUC()
        Me.MenuUCMain = New Presentation.MenuUC()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageWTaxWeekly.SuspendLayout()
        Me.TabPageWTaxSemi.SuspendLayout()
        Me.TabPageSSS.SuspendLayout()
        Me.TabPagePhilHealth.SuspendLayout()
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
        Me.SplitContainerMain.Panel2.Controls.Add(Me.StatusStripUC1)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.MenuUCMain)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1000, 730)
        Me.SplitContainerMain.SplitterDistance = 60
        Me.SplitContainerMain.TabIndex = 2
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
        Me.TabControlMain.Controls.Add(Me.TabPageWTaxWeekly)
        Me.TabControlMain.Controls.Add(Me.TabPageWTaxSemi)
        Me.TabControlMain.Controls.Add(Me.TabPageSSS)
        Me.TabControlMain.Controls.Add(Me.TabPagePhilHealth)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlMain.Location = New System.Drawing.Point(166, 26)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(834, 615)
        Me.TabControlMain.TabIndex = 6
        '
        'TabPageWTaxWeekly
        '
        Me.TabPageWTaxWeekly.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPageWTaxWeekly.Controls.Add(Me.WTaxUC_Weekly)
        Me.TabPageWTaxWeekly.Location = New System.Drawing.Point(4, 25)
        Me.TabPageWTaxWeekly.Name = "TabPageWTaxWeekly"
        Me.TabPageWTaxWeekly.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageWTaxWeekly.Size = New System.Drawing.Size(826, 586)
        Me.TabPageWTaxWeekly.TabIndex = 0
        Me.TabPageWTaxWeekly.Text = "WTax - Weekly"
        '
        'WTaxUC_Weekly
        '
        Me.WTaxUC_Weekly.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WTaxUC_Weekly.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WTaxUC_Weekly.Location = New System.Drawing.Point(0, 0)
        Me.WTaxUC_Weekly.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.WTaxUC_Weekly.Name = "WTaxUC_Weekly"
        Me.WTaxUC_Weekly.payMethod = DataAccess.WTax_DAO.PayMethods.Daily
        Me.WTaxUC_Weekly.Size = New System.Drawing.Size(812, 371)
        Me.WTaxUC_Weekly.TabIndex = 0
        '
        'TabPageWTaxSemi
        '
        Me.TabPageWTaxSemi.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPageWTaxSemi.Controls.Add(Me.WTaxUC_Semi)
        Me.TabPageWTaxSemi.Location = New System.Drawing.Point(4, 25)
        Me.TabPageWTaxSemi.Name = "TabPageWTaxSemi"
        Me.TabPageWTaxSemi.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageWTaxSemi.Size = New System.Drawing.Size(826, 586)
        Me.TabPageWTaxSemi.TabIndex = 1
        Me.TabPageWTaxSemi.Text = "WTax - Semi"
        '
        'WTaxUC_Semi
        '
        Me.WTaxUC_Semi.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.WTaxUC_Semi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WTaxUC_Semi.Location = New System.Drawing.Point(0, 0)
        Me.WTaxUC_Semi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.WTaxUC_Semi.Name = "WTaxUC_Semi"
        Me.WTaxUC_Semi.payMethod = DataAccess.WTax_DAO.PayMethods.Daily
        Me.WTaxUC_Semi.Size = New System.Drawing.Size(812, 371)
        Me.WTaxUC_Semi.TabIndex = 1
        '
        'TabPageSSS
        '
        Me.TabPageSSS.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPageSSS.Controls.Add(Me.SsS_UC1)
        Me.TabPageSSS.Location = New System.Drawing.Point(4, 25)
        Me.TabPageSSS.Name = "TabPageSSS"
        Me.TabPageSSS.Size = New System.Drawing.Size(826, 586)
        Me.TabPageSSS.TabIndex = 2
        Me.TabPageSSS.Text = "SSS"
        '
        'SsS_UC1
        '
        Me.SsS_UC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SsS_UC1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SsS_UC1.Location = New System.Drawing.Point(0, 0)
        Me.SsS_UC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SsS_UC1.Name = "SsS_UC1"
        Me.SsS_UC1.Size = New System.Drawing.Size(834, 564)
        Me.SsS_UC1.TabIndex = 0
        '
        'TabPagePhilHealth
        '
        Me.TabPagePhilHealth.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPagePhilHealth.Controls.Add(Me.PhilHealthUC1)
        Me.TabPagePhilHealth.Location = New System.Drawing.Point(4, 25)
        Me.TabPagePhilHealth.Name = "TabPagePhilHealth"
        Me.TabPagePhilHealth.Size = New System.Drawing.Size(826, 586)
        Me.TabPagePhilHealth.TabIndex = 3
        Me.TabPagePhilHealth.Text = "PhilHealth"
        '
        'PhilHealthUC1
        '
        Me.PhilHealthUC1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PhilHealthUC1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PhilHealthUC1.Location = New System.Drawing.Point(0, 0)
        Me.PhilHealthUC1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PhilHealthUC1.Name = "PhilHealthUC1"
        Me.PhilHealthUC1.Size = New System.Drawing.Size(823, 582)
        Me.PhilHealthUC1.TabIndex = 0
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
        'frmDeductables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 750)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDeductables"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "frmDeductables"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageWTaxWeekly.ResumeLayout(False)
        Me.TabPageWTaxSemi.ResumeLayout(False)
        Me.TabPageSSS.ResumeLayout(False)
        Me.TabPagePhilHealth.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NavUCMain As Presentation.NavUC
    Friend WithEvents Header1 As Presentation.Header
    Friend WithEvents TabPageWTaxWeekly As System.Windows.Forms.TabPage
    Friend WithEvents StatusStripUC1 As Presentation.StatusStripUC
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPageWTaxSemi As System.Windows.Forms.TabPage
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents MenuUCMain As Presentation.MenuUC
    Friend WithEvents WTaxUC_Weekly As Presentation.WTaxUC
    Friend WithEvents WTaxUC_Semi As Presentation.WTaxUC
    Friend WithEvents TabPageSSS As System.Windows.Forms.TabPage
    Friend WithEvents SsS_UC1 As Presentation.SSS_UC
    Friend WithEvents TabPagePhilHealth As System.Windows.Forms.TabPage
    Friend WithEvents PhilHealthUC1 As Presentation.PhilHealthUC
End Class
