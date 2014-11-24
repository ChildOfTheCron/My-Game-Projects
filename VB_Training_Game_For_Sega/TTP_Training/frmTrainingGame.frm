VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmTrainingGame 
   Caption         =   "Training Game"
   ClientHeight    =   12870
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   14430
   OleObjectBlob   =   "frmTrainingGame.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmTrainingGame"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public strCat As String
Public intLives As Integer
Public intBugID As Integer

'Vairables for stuff here
Public intRange As Integer
Public intResult As Integer

'Variables declared for use in Score Keeping
Public intWrongCount As Integer
Public strScore As String

'Checks to see if the game started
Public blnStarted As Boolean

Private Function intGetRange()
'Loops through all entries in the DataSheet and sets the total number of values this way

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
        strRange = Sheets("DataSheet").Cells(intX, intY)
    Loop
            
   intResult = intRange + 2 '+ 2 to compensate for the title rows on the top of the Data sheet
   mainMod.intTotalBugs = intRange
            
End Function

Private Function intCboData()
'Loops through all entries in the DataSheet and sets the total number of values this way - For the dropdown list

    Dim intX As Integer
    Dim intY As Integer
    Dim intIndex As Integer
    Dim strRange As String

    intX = 3
    intY = 2
    intIndex = 0
    strRange = Sheets("List").Cells(intX, intY)
    
    Do While strRange <> ""
        cboData.AddItem strRange
        'MsgBox cboData.List(intIndex)
        intIndex = intIndex + 1
        intX = intX + 1
        strRange = Sheets("List").Cells(intX, intY)
        'cboData.List (intX)
        
    Loop
            
   'intResult = intRange + 2 '+ 2 to compensate for the title rows on the top of the Data sheet
   'mainMod.intTotalBugs = intRange
            
End Function

Private Function drawResults()

    If intResult = 2 Then 'Uses two because bugs start from row 3 in the Datasheet
        mainMod.strResults = lblDesc
        frmResult.Show
        resetGame
        Unload Me
    End If

End Function

Private Function intStatic()

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
    strCat = Sheets("DataSheet").Cells(intResult, 2)

    If intResult > 2 Then 'TESTING THIS AERA NOW 13/05/2011 @ 11:00
        img1.Picture = LoadPicture(strPath & ".jpg")
        'Label1.Caption = strPath
        intGetHint
    Else
        drawResults
    End If
    
    intResult = intResult - 1

End Function

Private Function intGetID()
'The image links here.

    Dim strTemp As String
    Dim intX As Integer
    
    intX = intBugID
    
    strTemp = Sheets("DataSheet").Cells(intX, 4)
    txtExp.Text = Sheets("DataSheet").Cells(intX, 3) & vbNewLine & "" & vbNewLine & strTemp
    

End Function

Public Function resetGame()
'This function resets values to default and Starts the game
    
    blnStarted = True
    intCboData
    intGetRange
    intLives = 2
    updateLives
    intStatic
    txtExp.Text = ""

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

Private Function updateScore()
'Redraws the little scoreboard

    'Dim scoreKeep As Integer

    If strCat <> cboData.Value Then
        intWrongCount = intWrongCount + 1
        mainMod.intTotalWrong = intWrongCount
    End If
    
    strScore = "TTP Bugs Incorrect : " & intWrongCount
    lblDesc = strScore


End Function

Public Function contFunc()
'Continue freezes functionality and forces the user to read the text before new image, cannot skip this
  
    imgCont.Visible = True

End Function


Private Function intGetHint()
    
    'This is never going to do what I want it to do is it =.=

    Dim strTemp As String
    Dim intY As Integer
    
    intY = 5
    strTemp = strTemp + Sheets("DataSheet").Cells(intBugID, intY)
    lblHint = strTemp
    
End Function

Private Sub cboData_Change()
'On change set cbo data to something here - USED FOR TESTING/Debugging

    'MsgBox cboData.Value

End Sub

Private Sub imgGoBtn_Click()

    If blnStarted = True Then
         'MsgBox "Hello World, This is a test A Selected" + strClass
        If strCat = cboData.Value Then 'Change this to if user selected option = the sheet option
            txtExp.Text = "" 'add cont func here and also text
            contFunc
            intLives = 2
            updateLives
            intGetID
            contFunc
        Else
            '"WRONG! OH NOES!"
            intLives = intLives - 1
            If intLives = 0 Then
                'lblDesc = "Incorrect due to the fact that the cat is a cat is a cat A"
                updateScore
                intGetID
                contFunc
                updateLives
            Else
                updateLives
            End If
        End If
    Else
        MsgBox "Press Start to begin!"
    End If

  'intGetID

End Sub

Private Sub imgCont_Click()
'used to make sure the user (Testers) can read the text before tossing out a new pic

    txtExp.Text = ""
    intStatic
    intLives = 2
    updateLives
    imgCont.Visible = False

End Sub

Private Sub imgExitBtn_Click()
'Unloads the main game form

    resetGame
    Unload Me
    ThisWorkbook.Application.Visible = True

End Sub

Private Sub imgHelpBtn_Click()
'Shows the help sub menu - this menu is actually a form since you can make those look fancy

    frmHelp.Show

End Sub

Private Sub imgStartBtn_Click()
'Starts the game

    'blnStarted = True
    'intCboData
    'intGetRange
    resetGame
    imgStartBtn.Enabled = False

End Sub

Private Sub UserForm_Activate()
'Used to select a game type

    imgCont.Visible = False 'makes sure the Continue button is hidden
    blnStarted = False

End Sub

