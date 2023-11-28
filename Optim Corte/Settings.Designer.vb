<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.GenerationsInput = New System.Windows.Forms.TextBox()
        Me.PopulationSizeInput = New System.Windows.Forms.TextBox()
        Me.CrossoverRateInput = New System.Windows.Forms.TextBox()
        Me.ReplacementInput = New System.Windows.Forms.TextBox()
        Me.MutationFactorInput = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'GenerationsInput
        '
        Me.GenerationsInput.Location = New System.Drawing.Point(116, 6)
        Me.GenerationsInput.Name = "GenerationsInput"
        Me.GenerationsInput.Size = New System.Drawing.Size(100, 20)
        Me.GenerationsInput.TabIndex = 0
        Me.GenerationsInput.Text = "600"
        '
        'PopulationSizeInput
        '
        Me.PopulationSizeInput.Location = New System.Drawing.Point(116, 32)
        Me.PopulationSizeInput.Name = "PopulationSizeInput"
        Me.PopulationSizeInput.Size = New System.Drawing.Size(100, 20)
        Me.PopulationSizeInput.TabIndex = 1
        Me.PopulationSizeInput.Text = "200"
        '
        'CrossoverRateInput
        '
        Me.CrossoverRateInput.Location = New System.Drawing.Point(116, 58)
        Me.CrossoverRateInput.Name = "CrossoverRateInput"
        Me.CrossoverRateInput.Size = New System.Drawing.Size(100, 20)
        Me.CrossoverRateInput.TabIndex = 2
        Me.CrossoverRateInput.Text = "0.25"
        '
        'ReplacementInput
        '
        Me.ReplacementInput.Location = New System.Drawing.Point(116, 84)
        Me.ReplacementInput.Name = "ReplacementInput"
        Me.ReplacementInput.Size = New System.Drawing.Size(100, 20)
        Me.ReplacementInput.TabIndex = 3
        Me.ReplacementInput.Text = "0.25"
        '
        'MutationFactorInput
        '
        Me.MutationFactorInput.Location = New System.Drawing.Point(116, 110)
        Me.MutationFactorInput.Name = "MutationFactorInput"
        Me.MutationFactorInput.Size = New System.Drawing.Size(100, 20)
        Me.MutationFactorInput.TabIndex = 4
        Me.MutationFactorInput.Text = "0.01"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Generations"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Population Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Crossover (0-1)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Replacement (0-1)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Mutation (0-1)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(141, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Go!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(238, 194)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MutationFactorInput)
        Me.Controls.Add(Me.ReplacementInput)
        Me.Controls.Add(Me.CrossoverRateInput)
        Me.Controls.Add(Me.PopulationSizeInput)
        Me.Controls.Add(Me.GenerationsInput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Settings"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GenerationsInput As TextBox
    Friend WithEvents PopulationSizeInput As TextBox
    Friend WithEvents CrossoverRateInput As TextBox
    Friend WithEvents ReplacementInput As TextBox
    Friend WithEvents MutationFactorInput As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
End Class
