<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrimaryStructure
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
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.NavUCMain = New Presentation.NavUC()
        Me.StatusStripUC1 = New Presentation.StatusStripUC()
        Me.MenuUCMain = New Presentation.MenuUC()
        Me.Header1 = New Presentation.Header()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
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
        Me.SplitContainerMain.Panel2.Controls.Add(Me.Splitter1)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.NavUCMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.StatusStripUC1)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.MenuUCMain)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1000, 730)
        Me.SplitContainerMain.SplitterDistance = 60
        Me.SplitContainerMain.TabIndex = 0
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
        'Header1
        '
        Me.Header1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Header1.Location = New System.Drawing.Point(0, 0)
        Me.Header1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Header1.Name = "Header1"
        Me.Header1.Size = New System.Drawing.Size(1000, 60)
        Me.Header1.TabIndex = 0
        '
        'PrimaryStructure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 750)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PrimaryStructure"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "PrimaryStructure"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents MenuUCMain As Presentation.MenuUC
    Friend WithEvents NavUCMain As Presentation.NavUC
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents StatusStripUC1 As Presentation.StatusStripUC
    Friend WithEvents Header1 As Presentation.Header
End Class
