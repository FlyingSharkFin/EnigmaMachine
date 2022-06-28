Public Class Form2
    Dim ImageNameArray(7) As Image
    Dim i As Integer

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        i = 1
        'this is a really inefficient way of initialising these images into the array
        ImageNameArray(1) = My.Resources.UserDocumentationPage1
        ImageNameArray(2) = My.Resources.RotorOrderGuide
        ImageNameArray(3) = My.Resources.RotorSettingGuide
        ImageNameArray(4) = My.Resources.ReflectorSettingGuide
        ImageNameArray(5) = My.Resources.LampboardGuide
        ImageNameArray(6) = My.Resources.PlugboardGuide
        ImageNameArray(7) = My.Resources.SaveButtonsGuide
    End Sub

    Private Sub Nextbtn_Click(sender As Object, e As EventArgs) Handles Nextbtn.Click
        If i < 7 Then 'stops the user from clicking past the 7 images within the help system and causing an error
            i += 1
        End If
        PictureBox1.Image = ImageNameArray(i)
    End Sub

    Private Sub Previousbtn_Click(sender As Object, e As EventArgs) Handles Previousbtn.Click
        If i > 1 Then 'stops the user from clicking backwards past the first image in the help menu order
            i -= 1
        End If
        PictureBox1.Image = ImageNameArray(i)
    End Sub

    Private Sub Exittomenu_Click(sender As Object, e As EventArgs) Handles Exittomenu.Click
        Me.Visible() = False
        Form3.Visible() = True
    End Sub
End Class