<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Header
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
        Me.SplitContainerHeader = New System.Windows.Forms.SplitContainer()
        Me.PanelCompany = New System.Windows.Forms.Panel()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.SplitContainerTitle = New System.Windows.Forms.SplitContainer()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        CType(Me.SplitContainerHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerHeader.Panel1.SuspendLayout()
        Me.SplitContainerHeader.Panel2.SuspendLayout()
        Me.SplitContainerHeader.SuspendLayout()
        Me.PanelCompany.SuspendLayout()
        CType(Me.SplitContainerTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerTitle.Panel1.SuspendLayout()
        Me.SplitContainerTitle.Panel2.SuspendLayout()
        Me.SplitContainerTitle.SuspendLayout()
        Me.SuspendLayout()
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
        Me.SplitContainerHeader.TabIndex = 1
        '
        'PanelCompany
        '
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
        Me.lblCompanyName.Location = New System.Drawing.Point(20, 2)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(157, 25)
        Me.lblCompanyName.TabIndex = 0
        Me.lblCompanyName.Text = "Company XYZ"
        Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainerTitle
        '
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
        Me.SplitContainerTitle.Panel2.Padding = New System.Windows.Forms.Padding(0, 5, 10, 0)
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
        Me.lblTitle.Location = New System.Drawing.Point(30, 3)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(47, 21)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblUser.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(428, 5)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(158, 18)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Welcome, username"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Header
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerHeader)
        Me.Name = "Header"
        Me.Size = New System.Drawing.Size(1000, 60)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerHeader As System.Windows.Forms.SplitContainer
    Friend WithEvents PanelCompany As System.Windows.Forms.Panel
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents SplitContainerTitle As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label

End Class
