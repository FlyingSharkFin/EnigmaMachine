Public Class EnigmaMain
    Dim intTempLBtn As Integer
    Dim intTempMBtn As Integer
    Dim intTempRBtn As Integer
    Dim tempnum As Integer
    Dim keypressed As String
    Dim keystring As Label
    Dim i As Integer
    Dim keypressindex As Integer
    Dim lampidentifier As String
    'Dim lampdict As Dictionary(Of KeyEventArgs, Label) = New Dictionary(Of KeyEventArgs, Label)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        intTempLBtn = 1
        intTempMBtn = 1
        intTempRBtn = 1
        KeyPreview = True
        keypressindex = 0
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

    Private Sub RotorDecrement(ByRef windowsection)

        tempnum = Asc(windowsection.Text)
        If tempnum = 65 Then
            windowsection.text = "Z"
        Else
            windowsection.text = Chr(tempnum - 1)
        End If

    End Sub

    Private Sub btnDecrementLrotor_Click(sender As Object, e As EventArgs) Handles btnDecrementLrotor.Click

        RotorDecrement(labWindowLrotor)
        RotorDecrement(labWindowLrotorNext)
        RotorDecrement(labWindowLrotorPrev)

    End Sub

    Private Sub btnDecrementMrotor_Click(sender As Object, e As EventArgs) Handles btnDecrementMrotor.Click

        RotorDecrement(labWindowMrotor)
        RotorDecrement(labWindowMrotorNext)
        RotorDecrement(labWindowMrotorPrev)

    End Sub

    Private Sub btnDecrementRrotor_Click(sender As Object, e As EventArgs) Handles btnDecrementRrotor.Click

        RotorDecrement(labWindowRrotor)
        RotorDecrement(labWindowRrotorNext)
        RotorDecrement(labWindowRrotorPrev)

    End Sub

    Private Sub RotorIncrement(ByRef windowsection)

        tempnum = Asc(windowsection.Text)
        If tempnum = 90 Then
            windowsection.text = "A"
        Else
            windowsection.text = Chr(tempnum + 1)
        End If

    End Sub

    Private Sub btnIncrementLrotor_Click(sender As Object, e As EventArgs) Handles btnIncrementLrotor.Click

        RotorIncrement(labWindowLrotor)
        RotorIncrement(labWindowLrotorNext)
        RotorIncrement(labWindowLrotorPrev)

    End Sub

    Private Sub btnIncrementMrotor_Click(sender As Object, e As EventArgs) Handles btnIncrementMrotor.Click

        RotorIncrement(labWindowMrotor)
        RotorIncrement(labWindowMrotorNext)
        RotorIncrement(labWindowMrotorPrev)

    End Sub

    Private Sub btnIncrementRrotor_Click(sender As Object, e As EventArgs) Handles btnIncrementRrotor.Click

        RotorIncrement(labWindowRrotor)
        RotorIncrement(labWindowRrotorNext)
        RotorIncrement(labWindowRrotorPrev)

    End Sub

    Private Sub Enigmamain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        While keypressindex = 0
            If e.KeyCode >= 65 And e.KeyCode <= 90 Then
                keypressed = Chr(e.KeyCode)
                lampidentifier = "lab" + keypressed + "lamp"
                For Each label In Panel1.Controls.OfType(Of Label)
                    If label.Name.Equals(lampidentifier) Then
                        label.ImageIndex = 1
                        label.ForeColor = Color.Black
                    End If
                Next
                keypressindex = 1
            End If
        End While

    End Sub

    Private Sub EnigmaMain_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

        If e.KeyCode = Asc(keypressed) Then
            For Each label In Panel1.Controls.OfType(Of Label)
                If label.ImageIndex = 1 Then
                    label.ImageIndex = 0
                    label.ForeColor = Color.White
                End If
            Next

            keypressindex = 0
        End If


    End Sub


    'Private Sub EnimgaMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    '    keypressed = e.KeyCode
    '    keystring = "lab" + keypressed + "lamp"
    '    keystring.image
    'End Sub
    'Object.name("labQlamp").imageindex = 1
    'labQlamp.imageindex = 1

End Class
