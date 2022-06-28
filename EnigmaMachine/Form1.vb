Imports System.IO 'used for file manipulation purposes
Public Class EnigmaMain
    'creating the dimensions for many many many many global variables
    Dim intTempLBtn As Integer
    Dim intTempMBtn As Integer
    Dim intTempRBtn As Integer
    Dim tempnum As Integer
    Dim keypressed As String
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
    Dim plugboardsettings As String
    Dim AddSpacesCounter As Integer
    Dim KeyPressedYetBool As Boolean 'used to decide what information is saved in the output file
    Dim outputfilerotororder As String
    Dim outputfilerotorsetting As String
    Dim outputfilereflectorsetting As String
    Dim outputfileplugboardsetting As String
    Dim leftrotorbool As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'initialising a few key variables that are integral to the rest of the program
        KeyPressedYetBool = False
        intTempLBtn = 1
        intTempMBtn = 2
        intTempRBtn = 3
        KeyPreview = True 'this means that while the form is in focus, all keypresses will be noticed by the program
        keypressindex = 0
        AddSpacesCounter = 0

        globalalphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        rotori = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"
        rotorii = "AJDKSIRUXBLHWTMCQGZNPYFVOE"
        rotoriii = "BDFHJLCPRTXVZNYEIWGAKMUSQO"
        rotoriv = "ESOVPZJAYQUIRHXLNFTGKDCMWB"
        rotorv = "VZBRGITYUPSDNHLXAWMJQOFECK"
        reflectorb = "YRUHQSLDPXNGOKMIEBFZCWVJAT"
        reflectorc = "FVPJIAOYEDRZXWGCTKUQSBNMHL"

        For i = 1 To 26 'puts the normal alphabet into each array so that the scrambled alphabet has something to compare to
            leftrotor(1, i) = Mid(globalalphabet, i, 1)
            middlerotor(1, i) = Mid(globalalphabet, i, 1)
            rightrotor(1, i) = Mid(globalalphabet, i, 1)
            reflector(1, i) = Mid(globalalphabet, i, 1)
            reflector(2, i) = Mid(reflectorb, i, 1)
        Next

        SelectRotorType(btnLrotor, tempnum, leftrotor, lnotch)
        SelectRotorType(btnMrotor, tempnum, middlerotor, mnotch)
        SelectRotorType(btnRrotor, tempnum, rightrotor, rnotch)
        btnReflectorB.FlatStyle = FlatStyle.Flat 'makes the B reflector look flat already

    End Sub

    Private Sub SelectRotorType(ByRef button, ByRef temp, ByRef rotor, ByRef notch)
        'This sub makes the rotor array change depending on which rotor has been chosen
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

    'when you press the rotor order buttons at the top of the program, these subs run
    Private Sub btnLrotor_Click(sender As Object, e As EventArgs) Handles btnLrotor.Click
        SelectRotorType(btnLrotor, intTempLBtn, leftrotor, lnotch)
    End Sub
    Private Sub btnMrotor_Click(sender As Object, e As EventArgs) Handles btnMrotor.Click
        SelectRotorType(btnMrotor, intTempMBtn, middlerotor, mnotch)
    End Sub
    Private Sub btnRrotor_Click(sender As Object, e As EventArgs) Handles btnRrotor.Click
        SelectRotorType(btnRrotor, intTempRBtn, rightrotor, rnotch)
    End Sub

    'when a reflector is clicked, it goes flat and the other one "sticks up", they are basically radio buttons
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

    'When these subs are called, they rotate the visible "windows" in a revolving cycle
    Private Sub WindowDecrement(ByRef windowsection)
        tempnum = Asc(windowsection.Text)
        If tempnum = 65 Then 'if you try to decrement below A, it jumps forward to Z
            windowsection.text = "Z"
        Else
            windowsection.text = Chr(tempnum - 1)
        End If
    End Sub
    Private Sub WindowIncrement(ByRef windowsection)
        tempnum = Asc(windowsection.Text)
        If tempnum = 90 Then 'if you increment above Z, it goes back around to A
            windowsection.text = "A"
        Else
            windowsection.text = Chr(tempnum + 1)
        End If
    End Sub

    'These increment or decrement all 3 rotor windows at once
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

    '6 arrow buttons, 6 nearly identical button click subs which change different rotors
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

    'This sub occurs when you press a key down and for the duration that you keep that key pressed
    Private Sub Enigmamain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If KeyPressedYetBool = False Then
            'if this is the first key pressed since the textboxes were cleared, then the below information gets saved for if the user chooses to save this output.
            outputfilerotororder = (btnLrotor.Text & ", " & btnMrotor.Text & ", " & btnRrotor.Text)
            outputfilerotorsetting = labWindowLrotor.Text & labWindowMrotor.Text & labWindowRrotor.Text
            If btnReflectorB.FlatStyle = FlatStyle.Flat Then
                outputfilereflectorsetting = "B"
            Else
                outputfilereflectorsetting = "C"
            End If
            outputfileplugboardsetting = plugboardsettings
            KeyPressedYetBool = True
        End If

        While keypressindex = 0
            'keypressindex is a variable introduced because you could push down another key and then release it, activating the KeyUp event
            'By using this variable, only if the same key that was pressed down is then released will the program properly do the KeyUp event

            If e.KeyCode >= 65 And e.KeyCode <= 90 Then 'key pressed must be a letter on the keyboard, not any other key
                keypressed = Chr(e.KeyCode)
                outputletter = RotorCycle(keypressed) 'RotorCycle is the main function of the program
                lampidentifier = "lab" + outputletter + "lamp" 'the result of the encryption is put into this naming convention to be used below
                For Each label In Panel1.Controls.OfType(Of Label) 'Panel1 contains every lampboard label
                    If label.Name.Equals(lampidentifier) Then
                        label.ImageIndex = 1 'the label corresponding to the encrypted letter lights up
                        label.ForeColor = Color.Black
                    End If
                Next

                If AddSpacesCounter <> 5 Then 'this section fills up the input and output textboxes with letters
                    InputTextbox.Text = InputTextbox.Text + keypressed
                    OutputTextbox.Text = OutputTextbox.Text + outputletter
                    AddSpacesCounter += 1
                Else
                    InputTextbox.Text = InputTextbox.Text + " " 'every 5 letters, the program puts a space into the output for readability
                    OutputTextbox.Text = OutputTextbox.Text + " "
                    InputTextbox.Text = InputTextbox.Text + keypressed
                    OutputTextbox.Text = OutputTextbox.Text + outputletter
                    AddSpacesCounter = 1
                End If
                keypressindex = 1
            Else
                keypressindex = 1
            End If
        End While



    End Sub

    Private Sub EnigmaMain_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

        If e.KeyCode >= 65 And e.KeyCode <= 90 Then
            If e.KeyCode = Asc(keypressed) Then 'makes sure the key being released is the same as the key that was pressed
                For Each label In Panel1.Controls.OfType(Of Label)
                    If label.ImageIndex = 1 Then
                        label.ImageIndex = 0 'returns the lit lamp to the neutral off position
                        label.ForeColor = Color.White
                    End If
                Next
                keypressindex = 0
            End If
        Else
            keypressindex = 0
        End If


    End Sub

    Function RotorCycle(inputletter) 'This is where many major functions are consolidated so that they can be called on every keypress
        reflected = False
        inputletter = PlugboardFunc(inputletter)
        leftrotorbool = True
        inputletter = RotorFunc(inputletter, rightrotor, rnotch, labWindowRrotor, labWindowRrotorNext, labWindowRrotorPrev)
        leftrotorbool = False
        inputletter = RotorFunc(inputletter, middlerotor, mnotch, labWindowMrotor, labWindowMrotorNext, labWindowMrotorPrev)
        inputletter = RotorFunc(inputletter, leftrotor, lnotch, labWindowLrotor, labWindowLrotorNext, labWindowLrotorPrev)
        inputletter = ReflectorFunc(inputletter)
        reflected = True
        inputletter = RotorFunc(inputletter, leftrotor, lnotch, labWindowLrotor, labWindowLrotorNext, labWindowLrotorPrev)
        inputletter = RotorFunc(inputletter, middlerotor, mnotch, labWindowMrotor, labWindowMrotorNext, labWindowMrotorPrev)
        inputletter = RotorFunc(inputletter, rightrotor, rnotch, labWindowRrotor, labWindowRrotorNext, labWindowRrotorPrev)
        inputletter = PlugboardFunc(inputletter)
        RotorCycle = inputletter
        reflected = False
    End Function

    Private Sub btnOpenPlugboard_Click(sender As Object, e As EventArgs) Handles btnOpenPlugboard.Click
        Dim openingtext As String
        Dim newplugsettings As String
        openingtext = ("Enter Plugboard Connections in the format 'XX XX XX...'" + Chr(13) +
            "Do not repeat letters, use only upper case." + Chr(13) + "Refer to the Help Menu or User Documentation for further assistance.")
        Do
            plugboardsettings = InputBox(openingtext, "Plugboard Input", "") 'an inputbox where the user can enter the plugboardswaps they desire
            PlugboardErrorChecking(plugboardsettings) 'see line 300
        Loop Until (PlugboardErrorChecking(plugboardsettings) = True) Or plugboardsettings = "" ' "" is the  value that appears when you press cancel
        newplugsettings = plugboardsettings.Replace(" ", "") 'removes spaces from plugboardsettings, making it less readable but more efficient for the program

        For i = 1 To Len(newplugsettings) Step 2 'the plugboard array fills with the letter swaps that were entered above
            plugboard(1, i) = Mid(newplugsettings, i, 1)
            plugboard(2, i) = Mid(newplugsettings, i + 1, 1)
            plugboard(1, i + 1) = Mid(newplugsettings, i + 1, 1)
            plugboard(2, i + 1) = Mid(newplugsettings, i, 1)
        Next
    End Sub

    Function PlugboardErrorChecking(inputsettings) 'A complicated piece of error checking with several different parts
        Dim pair As String
        Dim letter As String
        Dim alreadyusedplugboardletters As String = String.Empty
        PlugboardErrorChecking = True
        inputsettings = Split(inputsettings) 'splits the plugboardsettings into pairs separated by whitespace

        For Each pair In inputsettings
            If Len(pair) <> 2 Then
                PlugboardErrorChecking = False 'input was wrong if any pair had less or more than 2 letters in it
            End If

            For Each letter In pair
                If Asc(letter) < 65 Or Asc(letter) > 90 Then
                    PlugboardErrorChecking = False 'Each letter inputted into the plugboard must be a capital letter
                ElseIf alreadyusedplugboardletters.Contains(letter) Then
                    PlugboardErrorChecking = False 'Every letter entered must be unique and cannot be a duplicate of something "alreadyused"
                Else
                    alreadyusedplugboardletters += letter
                End If

            Next
        Next
    End Function

    Function PlugboardFunc(letter) 'The plugboard is checked to see if the inputletter has a swap with another letter
        Dim newletter As String
        newletter = letter
        For i = 1 To 26
            If letter = plugboard(1, i) Then
                newletter = plugboard(2, i)
            End If
        Next
        PlugboardFunc = newletter
    End Function

    Function RotorFunc(letter, inputrotor, notch, window, windownext, windowprev) 'simulates the movement and encryption of the rotors

        Dim offset As Integer
        Dim newletter As String
        Dim rotor(2, 26) As String

        For i = 1 To 26 ' required to ensure that the rotor is not passed byref as is required by the language
            rotor(1, i) = inputrotor(1, i)
            rotor(2, i) = inputrotor(2, i)
        Next

        If reflected = True Then 'when the signal is reflected back through the machine from L to R, the rotors alphabet and scrambled sides are reversed
            For i = 1 To 26
                temp = rotor(1, i)
                rotor(1, i) = rotor(2, i)
                rotor(2, i) = temp
            Next

        ElseIf leftrotorbool = True Then 'the left rotor rotates on every single keypress
            RotorIncrement(window, windowprev, windownext)
            nextrotorrotate = False

        ElseIf nextrotorrotate = True Then 'if the previous rotor reached its notch, this rotor will rotate aswell
            RotorIncrement(window, windowprev, windownext)
            nextrotorrotate = False
        End If

        If windowprev.text = notch And reflected = False Then 'if the notch has been passed by this rotor, then the next rotor will rotate
            nextrotorrotate = True

        End If

        offset = Asc(window.text) - 65 'the letter on the window of the rotor denotes the offset that needs to be put onto the encryption

        If Asc(letter) + offset <= 90 Then
            letter = Chr(Asc(letter) + offset)
        Else
            letter = Chr(Asc(letter) + offset - 26) 'cant allow the letter to overflow past Z and into non-letter characters
        End If

        newletter = "!!!if you see this - it is broken!!!" 'prevents a nullexception and serves as errorchecking

        For i = 1 To 26
            If letter = rotor(1, i) Then
                newletter = rotor(2, i) 'the actual encryption of the inputletter through this rotor and its scrambled alphabet
            End If
        Next
        If Asc(newletter) - offset >= 65 Then 'the offset that was put on before is now reversed on the far side of the encryption
            newletter = Chr(Asc(newletter) - offset)
        Else
            newletter = Chr(Asc(newletter) - offset + 26) 'cant allow underflow (is that a word) past A into lowercase letters
        End If
        RotorFunc = newletter
    End Function



    Function ReflectorFunc(letter)
        Dim newletter As String
        newletter = "!!!if you see this - it is broken!!!"
        For i = 1 To 26
            If letter = reflector(1, i) Then
                newletter = reflector(2, i) 'like a simpler version the rotor, in one side and out the other
            End If
        Next
        ReflectorFunc = newletter

    End Function

    Private Sub btnExittomenu_Click(sender As Object, e As EventArgs) Handles btnExittomenu.Click
        Me.Visible() = False
        Form3.Visible() = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click 'clears the textboxes
        KeyPressedYetBool = False 'resets the keypressedyetbool so that any new settings are saved for if the user presses the save button
        AddSpacesCounter = 0
        InputTextbox.Text = ""
        OutputTextbox.Text = ""
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click 'saves details about the encryption and the output to the documents folder
        i = 0
        If My.Computer.FileSystem.DirectoryExists(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\EnigmaMachineOutputs") = False Then
            My.Computer.FileSystem.CreateDirectory(
                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\EnigmaMachineOutputs")
        End If 'if the EnigmaMachineOutputs folder doesnt exist, make it exist
        For Each filefound In My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\EnigmaMachineOutputs")
            i = i + 1
        Next 'this is used to create the incrementing number system in the save folder, so that there are no repeated filenames
        Dim newfilename As String
        newfilename = (My.Computer.FileSystem.SpecialDirectories.MyDocuments &
                       "\EnigmaMachineOutputs\" & Format(Date.Today, "ddMMyyyy") & "EnigmaOutput" & Str(i) & ".txt") 'eg. 29062022EnigmaOutput 0.txt
        Dim file As StreamWriter 'StreamWriter is an imported system class that is used for writing to files easily in VB.NET
        file = My.Computer.FileSystem.OpenTextFileWriter(newfilename, True) 'this initialises the creation of the new file
        file.WriteLine("Date of File Creation: " & Date.Today)
        file.WriteLine("Rotor Order:           " & outputfilerotororder)
        file.WriteLine("Rotor Setting:         " & outputfilerotorsetting)
        file.WriteLine("Reflector Setting:     " & outputfilereflectorsetting)
        file.WriteLine("Plugboard Setting:     " & outputfileplugboardsetting)
        file.WriteLine("Input Text:")
        file.WriteLine(InputTextbox.Text)
        file.WriteLine("")
        file.WriteLine("Output Text:")
        file.WriteLine(OutputTextbox.Text)
        file.Close() 'fill up the file with data and then close it
    End Sub

    Private Sub btnPurge_Click(sender As Object, e As EventArgs) Handles btnPurge.Click 'deletes all files in the EnigmaMachineOutputs folder
        Dim purgefiles As String
        purgefiles = MsgBox("Are you sure? This will delete all saved enigma output files!", MsgBoxStyle.YesNo) 'Makes sure user hasnt pressed accidentally
        If purgefiles = MsgBoxResult.Yes Then
            For Each filefound In My.Computer.FileSystem.GetFiles(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\EnigmaMachineOutputs")
                My.Computer.FileSystem.DeleteFile(filefound) 'delete each file found in the EnigmaMachineOutputs folder
            Next
        End If
    End Sub
End Class