<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTester
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
        Me.CodedDomainUC1 = New Presentation.CodedDomainUC
        Me.SuspendLayout()
        '
        'CodedDomainUC1
        '
        Me.CodedDomainUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CodedDomainUC1.Location = New System.Drawing.Point(0, 0)
        Me.CodedDomainUC1.Name = "CodedDomainUC1"
        Me.CodedDomainUC1.Size = New System.Drawing.Size(830, 514)
        Me.CodedDomainUC1.TabIndex = 0
        '
        'frmTester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 514)
        Me.Controls.Add(Me.CodedDomainUC1)
        Me.Name = "frmTester"
        Me.Text = "Tester"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CodedDomainUC1 As Presentation.CodedDomainUC
End Class
