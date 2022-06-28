<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Previousbtn = New System.Windows.Forms.Button()
        Me.Nextbtn = New System.Windows.Forms.Button()
        Me.Exittomenu = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.EnigmaMachine.My.Resources.Resources.UserDocumentationPage1
        Me.PictureBox1.Location = New System.Drawing.Point(67, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(750, 926)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Previousbtn
        '
        Me.Previousbtn.Location = New System.Drawing.Point(716, 987)
        Me.Previousbtn.Name = "Previousbtn"
        Me.Previousbtn.Size = New System.Drawing.Size(75, 23)
        Me.Previousbtn.TabIndex = 1
        Me.Previousbtn.Text = "Previous"
        Me.Previousbtn.UseVisualStyleBackColor = True
        '
        'Nextbtn
        '
        Me.Nextbtn.Location = New System.Drawing.Point(797, 987)
        Me.Nextbtn.Name = "Nextbtn"
        Me.Nextbtn.Size = New System.Drawing.Size(75, 23)
        Me.Nextbtn.TabIndex = 2
        Me.Nextbtn.Text = "Next"
        Me.Nextbtn.UseVisualStyleBackColor = True
        '
        'Exittomenu
        '
        Me.Exittomenu.Location = New System.Drawing.Point(793, 12)
        Me.Exittomenu.Name = "Exittomenu"
        Me.Exittomenu.Size = New System.Drawing.Size(80, 20)
        Me.Exittomenu.TabIndex = 3
        Me.Exittomenu.Text = "Exit To Menu"
        Me.Exittomenu.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.EnigmaMachine.My.Resources.Resources.images
        Me.ClientSize = New System.Drawing.Size(884, 1041)
        Me.Controls.Add(Me.Exittomenu)
        Me.Controls.Add(Me.Nextbtn)
        Me.Controls.Add(Me.Previousbtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Previousbtn As Button
    Friend WithEvents Nextbtn As Button
    Friend WithEvents Exittomenu As Button
End Class
