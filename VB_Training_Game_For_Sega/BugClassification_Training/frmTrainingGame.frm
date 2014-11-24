VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmTrainingGame 
   Caption         =   "Training Game"
   ClientHeight    =   12255
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   11880
   OleObjectBlob   =   "frmTrainingGame.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmTrainingGame"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'****************************************** Change Log 21/09/2011 ***************************************
'  - Readded Debug - to see unique ID's and easily track problems along the data sheet
'  - Fixed the bug where start button remained active for some reason
'  - Added prompt for incorrect awnsers - prompt for correct awnsers is going to be a lot more difficult to implements due to the fact that there is
'    no waiting for user feedback when correct choise is selected


'****************************************** Variable Declerations ***************************************
Public strClass As String
Public intLives As Integer
Public intBugID As Integer

'Vairables for stuff here
Public intRange As Integer
Public intResult As Integer

'Variables declared for use in Score Keeping
Public intAWrong As Integer
Public intBWrong As Integer
Public intCWrong As Integer
Public intDWrong As Integer
Public strScore As String

'Checks to see if the game started
Public blnStarted As Boolean

'Debug mode
Public dBugRun As Boolean

'******************************************OLD CODE SNIPPETS NOT USED ANYMORE ***************************************
'Private Function gameStatus()
'
'    If mainMod.intGameType = 1 Then
'        intRandom
'    Else
'        intStatic
'    End If

'End Function

'Private Function intRandom()

'    Dim strPath As String
'    Dim strImgName As String
'    Dim intResult As Integer
'    Dim intY As Integer
'
'    intY = 1
'    intGetRange
'    ' Initialize the random-number generator.
'    Randomize
'    ' Get the pathname where the folder is saved
'    strPath = Sheets("PathSheet").Cells(2, 2)
'    'Generate a random int between 1 and the range of data in DataSheet
'    intResult = Int((intRange * Rnd) + 3)
'    intBugID = intResult 'Sets the bug ID with the same int and the selected bugImg
'
'    'strPath = strPath + strRange -- Note to self - Won't work idiot you're calling an EOF string
'    strPath = strPath + Sheets("DataSheet").Cells(intResult, intY)
'    strClass = Sheets("DataSheet").Cells(intResult, 2)
'
'    img1.Picture = LoadPicture(strPath & ".jpg")
'    intGetHint
'
'End Function

'****************************************** MAIN PROGRAM RUN ***************************************

Private Function intGetRange()
'Loops through all entries in the DataSheet and sets the total number of values

    Dim intX As Integer
    Dim intY As Integer
    Dim strRange As String
    'Dim intRange As Integer
    
    intRange = 0
    intX = 3
    intY = 1
    strRange = Sheets("DataSheet").Cells(intX, intY)
    
    Do While strRange <> ""
        intRange = intRange + 1 'Defined as public (see top) for use in other functions
        intX = intX + 1
        strRange = Sheets("DataSheet").Cells(intX, intY) 'strRange Again declared public
    Loop
            
   intResult = intRange + 2 '+ 2 to compensate for the title rows on the top of the Datasheet
   mainMod.intTotalBugs = intRange

End Function

Private Function drawResults()
'Called to draw the results screen

    If intResult = 2 Then 'Uses two because bugs start from row 3 in the Datasheet
        mainMod.strResults = lblDesc
        frmResult.Show
        resetGame
        Unload Me
    End If

End Function

Private Function intStatic()
'Handles most of the game logic - Loads the images / calls the DrawResults when required etc

    Dim strPath As String
    'Dim intResult As Integer
    Dim intY As Integer
    Dim intTempBID As Integer
    
    intY = 1
    'intGetRange -- Can't get this because it'll call it every time, so the range will stay maxed out (the same)
    strPath = Sheets("PathSheet").Cells(2, 2)

    strRange = Sheets("DataSheet").Cells(intResult, intY) 'strRange Again declared public - NO CANT DO THAT
    'intTempBID = intResult 'Sets the bug ID with the same int and the selected bugImg
    intBugID = intResult

    strPath = strPath + Sheets("DataSheet").Cells(intResult, intY)
    strClass = Sheets("DataSheet").Cells(intResult, 2)

    If dBugRun = True Then
        lblDebug.Caption = "Unique BugID currently reads: " & Sheets("DataSheet").Cells(intResult, 1)
    End If
    
    If intResult > 2 Then 'TESTING THIS AERA NOW 13/05/2011 @ 11:00
        img1.Picture = LoadPicture(strPath & ".jpg")
        intGetHint
    Else
        drawResults
    End If
    
    intResult = intResult - 1 'Defined as public (see top) for use in other functions - NO CANT DO THAT
    lblTest = intResult

End Function

Private Function intGetID()
'Don't need to hard-code nothin' now, all linked up to Datasheet

    Dim strTemp As String
    Dim intX As Integer
    
    intX = intBugID '+ 2 'Case is always 2 bugs less than the DataSheet values
    
    strTemp = "Class: " & strClass & vbNewLine & Sheets("DataSheet").Cells(intX, 3) & vbNewLine & Sheets("DataSheet").Cells(intX, 4)
    txtExp.Text = strTemp
    
End Function

Public Function resetGame()
'This function resets values to default and Starts the game

    intLives = 2
    lblLives = "Lives Left: " & intLives
    intStatic
    
    blnStarted = True
    intAWrong = 0
    intBWrong = 0
    intCWrong = 0
    intDWrong = 0
    
    'updateScore
    strScore = "A Bugs Incorrect: " & intAWrong & vbNewLine & "B Bugs Incorrect: " & intBWrong & vbNewLine & "C Bugs Incorrect: " & intCWrong & vbNewLine & "D Bugs Incorrect: " & intDWrong
    lblDesc = strScore
    
    
    imgCont.Visible = False
    imgABtn.Enabled = True
    imgBBtn.Enabled = True
    imgCBtn.Enabled = True
        
    txtExp.Text = ""
    
    imgLife1.Visible = True
    imgLife2.Visible = True

End Function

Public Function updateLives()
'Made a func for this cause writing Lives Left: over and over gain is dumb

    'lblLives = "Lives Left: " & intLives
    
    If intLives = 0 Then
        imgLife1.Visible = False
        imgLife2.Visible = False
    Else
        If intLives = 1 Then
            imgLife2.Visible = False
        Else
            If intLives = 2 Then
                imgLife1.Visible = True
                imgLife2.Visible = True
            End If
        End If
    End If

End Function

Public Function updateScore()
'Redraws the little scoreboard *UPDATE* This is now hidden per Julie's request, will only show in the results menu
    Select Case strClass
    Case "A"
    
        intAWrong = intAWrong + 1
        mainMod.intATotalWrong = intAWrong
    
    Case "B"
    
        intBWrong = intBWrong + 1
        mainMod.intBTotalWrong = intBWrong
    
    Case "C"
    
        intCWrong = intCWrong + 1
        mainMod.intCTotalWrong = intCWrong
        
    Case "D"
    
        intDWrong = intDWrong + 1
        mainMod.intDTotalWrong = intDWrong
    
    Case Else
        
        MsgBox "Error: No Score found!" 'Will trigger if no score can be updated. This shouldnt happen ever!
        
    End Select
    
    strScore = "A Bugs Incorrect: " & intAWrong & vbNewLine & "B Bugs Incorrect: " & intBWrong & vbNewLine & "C Bugs Incorrect: " & intCWrong & vbNewLine & "D Bugs Incorrect: " & intDWrong
    lblDesc = strScore

End Function

Public Function contFunc()
'Continue freezes functionality and forces the user to read the text before new image, cannot skip this
  
    imgCont.Visible = True
    imgABtn.Enabled = False
    imgBBtn.Enabled = False
    imgCBtn.Enabled = False

End Function

Private Function intGetHint()
    
    'This is never going to do what I want it to do is it =.= **Fixed it for ya ;)

    Dim strTemp As String
    Dim intY As Integer
    
    intY = 5
    strTemp = strTemp + Sheets("DataSheet").Cells(intBugID, intY)
    lblHint = strTemp
    
End Function

Private Sub CommandButton1_Click()


    frmTrainingGame.PrintForm


End Sub

Private Sub imgABtn_Click()

    If blnStarted = True Then
         'MsgBox "Hello World, This is a test A Selected" + strClass
        If strClass = "A" Then
            txtExp.Text = ""
            intStatic
            intLives = 2
            updateLives
        Else
            '"WRONG! OH NOES!"
            intLives = intLives - 1
            If intLives = 0 Then
                'lblDesc = "Incorrect due to the fact that the cat is a cat is a cat A"
                updateScore
                intGetID
                contFunc
                updateLives
                imgIncorrect.Visible = True '21/09/2011 Adding Incorrect Prompt
            Else
                updateLives
            End If
        End If
    Else
        MsgBox "Press Start to begin!"
    End If

End Sub

Private Sub imgBBtn_Click()

    If blnStarted = True Then
         'MsgBox "Hello World, This is a test A Selected" + strClass
        If strClass = "B" Then
            txtExp.Text = ""
            intStatic
            intLives = 2
            updateLives
        Else
            '"WRONG! OH NOES!"
            intLives = intLives - 1
            If intLives = 0 Then
                'lblDesc = "Incorrect due to the fact that the cat is a cat is a cat A"
                updateScore
                intGetID
                contFunc
                updateLives
                imgIncorrect.Visible = True '21/09/2011 Adding Incorrect Prompt
            Else
                updateLives
            End If
        End If
    Else
        MsgBox "Press Start to begin!"
    End If

End Sub

Private Sub imgCBtn_Click()

    If blnStarted = True Then
         'MsgBox "Hello World, This is a test A Selected" + strClass
        If strClass = "C" Then
            txtExp.Text = ""
            intStatic
            intLives = 2
            updateLives
        Else
            '"WRONG! OH NOES!"
            intLives = intLives - 1
            If intLives = 0 Then
                updateScore
                intGetID
                contFunc
                updateLives
                imgIncorrect.Visible = True '21/09/2011 Adding Incorrect Prompt
            Else
                updateLives
            End If
        End If
    Else
        MsgBox "Press Start to begin!"
    End If

End Sub

Private Sub imgCont_Click()
'used to make sure the user (Testers) can read the text before tossing out a new pic

    intStatic
    intLives = 2 'This is here cause else if you click continue the lives don't reset, crazyness ensues
    updateLives
    imgCont.Visible = False
    imgABtn.Enabled = True
    imgBBtn.Enabled = True
    imgCBtn.Enabled = True
    
    'CAN'T USE resetGame function as it resets the scores, lame, gonna have to type it out
    txtExp.Text = ""

    imgLife1.Visible = True
    imgLife2.Visible = True

    imgIncorrect.Visible = False '21/09/2011 Adding Correct Prompt

End Sub

Private Sub imgDBtn_Click()

    If blnStarted = True Then
         'MsgBox "Hello World, This is a test A Selected" + strClass
        If strClass = "D" Then
            txtExp.Text = ""
            intStatic
            intLives = 2
            updateLives
        Else
            '"WRONG! OH NOES!"
            intLives = intLives - 1
            If intLives = 0 Then
                updateScore
                intGetID
                contFunc
                updateLives
                imgIncorrect.Visible = True '21/09/2011 Adding Incorrect Prompt
            Else
                updateLives
            End If
        End If
    Else
        MsgBox "Press Start to begin!"
    End If

End Sub

Private Sub imgExitBtn_Click()
'Unloads the main game form

    'resetGame - Can't use this if you want to use Exit button before game is started, will crash
    Unload Me
    ThisWorkbook.Application.Visible = True

End Sub

Private Sub imgHelpBtn_Click()
'Shows the help sub menu - this menu is actually a form since you can make those look fancy-like

    frmHelp.Show

End Sub

Private Sub imgStartBtn_Click()
'Starts the game
Dim dBugCheck As String

    intGetRange
    resetGame
    imgStartBtn.Enabled = False
    dBugCheck = Sheets("DataSheet").Cells(1, 4)
    
    If dBugCheck = "True" Then
        debugRun
    End If

End Sub

Private Sub UserForm_Activate()
'Used to select a game type

    imgCont.Visible = False 'makes sure the Continue button is hidden

End Sub

Private Sub debugRun()
    
    dBugRun = True
    MsgBox "Debug set to ON"
    lblDebug.Visible = True
    lblDebug.Caption = "DEBUG: Pending Info Update"

End Sub

