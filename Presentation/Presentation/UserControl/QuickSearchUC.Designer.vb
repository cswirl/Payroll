<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuickSearchUC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QuickSearchUC))
        Me.gbxQuickSearch = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tscbxSearchBy = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.tsBtnGo = New System.Windows.Forms.ToolStripButton()
        Me.gbxQuickSearch.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxQuickSearch
        '
        Me.gbxQuickSearch.Controls.Add(Me.ToolStrip1)
        Me.gbxQuickSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxQuickSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxQuickSearch.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gbxQuickSearch.Location = New System.Drawing.Point(0, 0)
        Me.gbxQuickSearch.Name = "gbxQuickSearch"
        Me.gbxQuickSearch.Padding = New System.Windows.Forms.Padding(5)
        Me.gbxQuickSearch.Size = New System.Drawing.Size(682, 60)
        Me.gbxQuickSearch.TabIndex = 0
        Me.gbxQuickSearch.TabStop = False
        Me.gbxQuickSearch.Text = "Search By"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.tscbxSearchBy, Me.ToolStripSeparator1, Me.tstxtSearch, Me.tsBtnGo})
        Me.ToolStrip1.Location = New System.Drawing.Point(5, 21)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(672, 34)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'tscbxSearchBy
        '
        Me.tscbxSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscbxSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.tscbxSearchBy.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscbxSearchBy.Name = "tscbxSearchBy"
        Me.tscbxSearchBy.Size = New System.Drawing.Size(140, 34)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'tstxtSearch
        '
        Me.tstxtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.tstxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tstxtSearch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtSearch.Name = "tstxtSearch"
        Me.tstxtSearch.Size = New System.Drawing.Size(240, 34)
        '
        'tsBtnGo
        '
        Me.tsBtnGo.BackColor = System.Drawing.Color.Transparent
        Me.tsBtnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsBtnGo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnGo.Image = CType(resources.GetObject("tsBtnGo.Image"), System.Drawing.Image)
        Me.tsBtnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnGo.Name = "tsBtnGo"
        Me.tsBtnGo.Padding = New System.Windows.Forms.Padding(15)
        Me.tsBtnGo.Size = New System.Drawing.Size(50, 31)
        Me.tsBtnGo.Text = "Search"
        Me.tsBtnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'QuickSearchUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbxQuickSearch)
        Me.Name = "QuickSearchUC"
        Me.Size = New System.Drawing.Size(682, 60)
        Me.gbxQuickSearch.ResumeLayout(False)
        Me.gbxQuickSearch.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxQuickSearch As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tscbxSearchBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstxtSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsBtnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator

End Class
