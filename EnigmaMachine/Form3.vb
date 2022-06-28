Public Class Form3
    'Each of these are pretty self explanatory, they open the form specific to the button pushed
    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        Me.Visible() = False
        EnigmaMain.Visible() = True
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Me.Visible() = False
        Form2.Visible() = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
End Class