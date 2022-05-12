Public Class EnimgaMain
    Dim intTempLBtn As Integer
    Dim intTempMBtn As Integer
    Dim intTempRBtn As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        intTempLBtn = 1
        intTempMBtn = 1
        intTempRBtn = 1

    End Sub

    Private Sub btnLrotor_Click(sender As Object, e As EventArgs) Handles btnLrotor.Click

        SelectRotorType(btnLrotor, intTempLBtn)

    End Sub

    Private Sub btnMrotor_Click(sender As Object, e As EventArgs) Handles btnMrotor.Click


        SelectRotorType(btnMrotor, intTempMBtn)


    End Sub

    Private Sub btnRrotor_Click(sender As Object, e As EventArgs) Handles btnRrotor.Click

        SelectRotorType(btnRrotor, intTempRBtn)


    End Sub

    Private Sub SelectRotorType(ByRef button, ByRef temp)


        If temp < 5 Then
            temp = temp + 1
        Else
            temp = 1
        End If
        Select Case temp
            Case Is = 1
                button.Text = "I"
            Case Is = 2
                button.Text = "II"
            Case Is = 3
                button.Text = "III"
            Case Is = 4
                button.Text = "IV"
            Case Is = 5
                button.Text = "V"
        End Select


    End Sub

End Class
