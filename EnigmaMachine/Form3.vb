Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        Me.Visible() = False
        EnigmaMain.Visible() = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
End Class