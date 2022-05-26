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

    Dim plugboard(2, 26) As String
    Dim rightrotor(2, 26) As String
    Dim middlerotor(2, 26) As String
    Dim leftrotor(2, 26) As String
    Dim reflector(2, 26) As String

    Dim globalalphabet As String
    Dim rotori As String
    Dim rotorii As String
    Dim rotoriii As String
    Dim rotoriv As String
    Dim rotorv As String
    Dim reflectorb As String
    Dim reflectorc As String
    Dim lnotch As String
    Dim mnotch As String
    Dim rnotch As String

    Dim reflected As Boolean
    Dim inputletter As String
    Dim temp As String
    Dim nextrotorrotate As Boolean
    Dim outputletter As String




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        intTempLBtn = 1
        intTempMBtn = 1
        intTempRBtn = 1
        KeyPreview = True
        keypressindex = 0

        globalalphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        rotori = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
        rotorii = "AJDKSIRUXBLHWTMCQGZNPYFVOE"
        rotoriii = "BDFHJLCPRTXVZNYEIWGAKMUSQO"
        rotoriv = "ESOVPZJAYQUIRHXLNFTGKDCMWB"
        rotorv = "VZBRGITYUPSDNHLXAWMJQOFECK"
        reflectorb = "YRUHQSLDPXNGOKMIEBFZCWVJAT"
        reflectorc = "FVPJIAOYEDRZXWGCTKUQSBNMHL"

        For i = 1 To 26
            leftrotor(1, i) = Mid(globalalphabet, i, 1)
            middlerotor(1, i) = Mid(globalalphabet, i, 1)
            rightrotor(1, i) = Mid(globalalphabet, i, 1)
            reflector(1, i) = Mid(globalalphabet, i, 1)
            reflector(2, i) = Mid(reflectorb, i, 1)
        Next

        SelectRotorType(btnLrotor, tempnum, leftrotor, lnotch)
        SelectRotorType(btnMrotor, tempnum, middlerotor, mnotch)
        SelectRotorType(btnRrotor, tempnum, rightrotor, rnotch)
        btnReflectorB.FlatStyle = FlatStyle.Flat

    End Sub


    Private Sub btnLrotor_Click(sender As Object, e As EventArgs) Handles btnLrotor.Click
        SelectRotorType(btnLrotor, intTempLBtn, leftrotor, lnotch)
    End Sub

    Private Sub btnMrotor_Click(sender As Object, e As EventArgs) Handles btnMrotor.Click
        SelectRotorType(btnMrotor, intTempMBtn, middlerotor, mnotch)
    End Sub

    Private Sub btnRrotor_Click(sender As Object, e As EventArgs) Handles btnRrotor.Click
        SelectRotorType(btnRrotor, intTempRBtn, rightrotor, rnotch)
    End Sub

    Private Sub SelectRotorType(ByRef button, ByRef temp, ByRef rotor, ByRef notch)

        Dim rotortemp As String
        If temp < 5 Then
            temp = temp + 1
        Else
            temp = 1
        End If
        Select Case temp
            Case Is = 1
                button.Text = "I"
                rotortemp = rotori
                notch = "Q"
            Case Is = 2
                button.Text = "II"
                rotortemp = rotorii
                notch = "E"
            Case Is = 3
                button.Text = "III"
                rotortemp = rotoriii
                notch = "V"
            Case Is = 4
                button.Text = "IV"
                rotortemp = rotoriv
                notch = "K"
            Case Is = 5
                button.Text = "V"
                rotortemp = rotorv
                notch = "Z"
            Case Else
                rotortemp = ""
        End Select
        For i = 1 To 26
            rotor(2, i) = Mid(rotortemp, i, 1)
        Next

    End Sub

    Private Sub btnReflectorB_Click(sender As Object, e As EventArgs) Handles btnReflectorB.Click
        For i = 1 To 26
            reflector(2, i) = Mid(reflectorb, i, 1)
        Next
        btnReflectorB.FlatStyle = FlatStyle.Flat
        btnReflectorC.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub btnReflectorC_Click(sender As Object, e As EventArgs) Handles btnReflectorC.Click
        For i = 1 To 26
            reflector(2, i) = Mid(reflectorc, i, 1)
        Next
        btnReflectorC.FlatStyle = FlatStyle.Flat
        btnReflectorB.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub WindowDecrement(ByRef windowsection)

        tempnum = Asc(windowsection.Text)
        If tempnum = 65 Then
            windowsection.text = "Z"
        Else
            windowsection.text = Chr(tempnum - 1)
        End If

    End Sub

    Private Sub WindowIncrement(ByRef windowsection)

        tempnum = Asc(windowsection.Text)
        If tempnum = 90 Then
            windowsection.text = "A"
        Else
            windowsection.text = Chr(tempnum + 1)
        End If

    End Sub

    Private Sub RotorDecrement(ByRef window, ByRef Windownext, ByRef Windowprev)
        WindowDecrement(window)
        WindowDecrement(Windownext)
        WindowDecrement(Windowprev)
    End Sub

    Private Sub RotorIncrement(ByRef window, ByRef Windownext, ByRef Windowprev)
        WindowIncrement(window)
        WindowIncrement(Windownext)
        WindowIncrement(Windowprev)
    End Sub



    Private Sub btnDecrementLrotor_Click(sender As Object, e As EventArgs) Handles btnDecrementLrotor.Click
        RotorDecrement(labWindowLrotor, labWindowLrotorNext, labWindowLrotorPrev)
    End Sub

    Private Sub btnDecrementMrotor_Click(sender As Object, e As EventArgs) Handles btnDecrementMrotor.Click
        RotorDecrement(labWindowMrotor, labWindowMrotorNext, labWindowMrotorPrev)
    End Sub

    Private Sub btnDecrementRrotor_Click(sender As Object, e As EventArgs) Handles btnDecrementRrotor.Click
        RotorDecrement(labWindowRrotor, labWindowRrotorNext, labWindowRrotorPrev)
    End Sub

    Private Sub btnIncrementLrotor_Click(sender As Object, e As EventArgs) Handles btnIncrementLrotor.Click
        RotorIncrement(labWindowLrotor, labWindowLrotorNext, labWindowLrotorPrev)
    End Sub

    Private Sub btnIncrementMrotor_Click(sender As Object, e As EventArgs) Handles btnIncrementMrotor.Click
        RotorIncrement(labWindowMrotor, labWindowMrotorNext, labWindowMrotorPrev)
    End Sub

    Private Sub btnIncrementRrotor_Click(sender As Object, e As EventArgs) Handles btnIncrementRrotor.Click
        RotorIncrement(labWindowRrotor, labWindowRrotorNext, labWindowRrotorPrev)
    End Sub

    Private Sub Enigmamain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        While keypressindex = 0
            If e.KeyCode >= 65 And e.KeyCode <= 90 Then
                keypressed = Chr(e.KeyCode)
                outputletter = RotorCycle(keypressed)
                lampidentifier = "lab" + outputletter + "lamp"
                For Each label In Panel1.Controls.OfType(Of Label)
                    If label.Name.Equals(lampidentifier) Then
                        label.ImageIndex = 1
                        label.ForeColor = Color.Black
                    End If
                Next
                InputTextbox.Text = InputTextbox.Text + keypressed
                OutputTextbox.Text = OutputTextbox.Text + outputletter
                keypressindex = 1
            End If
        End While



    End Sub

    Private Sub EnigmaMain_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

        If e.KeyCode >= 65 And e.KeyCode < 90 Then
            If e.KeyCode = Asc(keypressed) Then
                For Each label In Panel1.Controls.OfType(Of Label)
                    If label.ImageIndex = 1 Then
                        label.ImageIndex = 0
                        label.ForeColor = Color.White
                    End If
                Next

                keypressindex = 0
            End If
        End If


    End Sub

    Function RotorCycle(inputletter)
        rnotch = ""
        reflected = False
        'inputletter = PlugboardFunc(inputletter)
        inputletter = RotorFunc(inputletter, rightrotor, rnotch, labWindowRrotor, labWindowRrotorNext, labWindowRrotorPrev)
        inputletter = RotorFunc(inputletter, middlerotor, mnotch, labWindowMrotor, labWindowMrotorNext, labWindowMrotorPrev)
        inputletter = RotorFunc(inputletter, leftrotor, lnotch, labWindowLrotor, labWindowLrotorNext, labWindowLrotorPrev)
        inputletter = ReflectorFunc(inputletter)
        reflected = True
        inputletter = RotorFunc(inputletter, leftrotor, lnotch, labWindowLrotor, labWindowLrotorNext, labWindowLrotorPrev)
        inputletter = RotorFunc(inputletter, middlerotor, mnotch, labWindowMrotor, labWindowMrotorNext, labWindowMrotorPrev)
        inputletter = RotorFunc(inputletter, rightrotor, rnotch, labWindowRrotor, labWindowRrotorNext, labWindowRrotorPrev)
        'inputletter = PlugboardFunc(inputletter)
        RotorCycle = keypressed
    End Function


    Function RotorFunc(letter, rotor, notch, window, windowprev, windownext)

        Dim offset As Integer
        Dim newletter As String

        MsgBox(NameOf(rotor))

        If reflected = True Then
            For i = 1 To 26
                temp = rotor(1, i)
                rotor(1, i) = rotor(2, i)
                rotor(2, i) = temp
            Next

        ElseIf NameOf(rotor) = ("leftrotor") Then
            RotorIncrement(window, windowprev, windownext)

        ElseIf nextrotorrotate = True Then
            RotorIncrement(window, windowprev, windownext)
            nextrotorrotate = False
        End If

        If window.text = notch Then
            nextrotorrotate = True
        End If


        offset = Asc(window.text) - 65

        If Asc(letter) + offset <= 90 Then
            letter = Chr(Asc(letter) + offset)
        Else
            letter = Chr(Asc(letter) + offset - 26)
        End If

        newletter = "!!!if you see this - it is broken!!!"

        For i = 1 To 26
            If letter = rotor(1, i) Then
                newletter = rotor(2, i)
            End If
        Next

        If Asc(newletter) - offset >= 65 Then
            newletter = Chr(Asc(newletter) + offset)
        Else
            newletter = Chr(Asc(newletter) + offset + 26)
        End If
        RotorFunc = newletter
    End Function

    Function ReflectorFunc(letter)

        Dim newletter As String
        newletter = "!!!if you see this - it is broken!!!"

        For i = 1 To 26
            If letter = reflector(1, i) Then
                newletter = reflector(2, i)
            End If
        Next
        ReflectorFunc = newletter

    End Function


    'Private Sub EnimgaMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    '    keypressed = e.KeyCode
    '    keystring = "lab" + keypressed + "lamp"
    '    keystring.image
    'End Sub
    'Object.name("labQlamp").imageindex = 1
    'labQlamp.imageindex = 1

End Class
