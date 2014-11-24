VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmResult 
   Caption         =   "Results Screen"
   ClientHeight    =   7020
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   6840
   OleObjectBlob   =   "frmResult.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmResult"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Form loads the results screen
Private totals As Integer
Private passRate As Integer
Private pathName As String

Private Sub cmdPrint_Click()

    frmResult.PrintForm

End Sub

Private Sub imgClose_Click()

    Unload Me
    Unload frmTrainingGame
    ThisWorkbook.Application.Visible = True

End Sub


Private Sub UserForm_Activate()
    addTotal
    lblData = mainMod.strResults & vbNewLine & " " & vbNewLine & "Total Score: " & totals & "/" & mainMod.intTotalBugs & vbNewLine & "Pass Rate: " & passRate & "%"
    getAdvice

End Sub

Private Function addTotal()

    Dim tmpTotalWrong As Integer
    Dim tmpPassRate As Integer
    
    totals = mainMod.intTotalBugs - mainMod.intTotalWrong
    'totals = mainMod.intTotalBugs - tmpTotalWrong
    
    'tmpPassRate = 0    'Use this to test whether the results work.
    tmpPassRate = totals / mainMod.intTotalBugs * 100
    passRate = tmpPassRate

End Function

Private Function getAdvice()
'Shows the results based on a percentage (Passrate achieved)

    pathName = Sheets("PathSheet").Cells(2, 2)

    Select Case passRate
    
        Case Is < 25
            lblResAd = Sheets("List").Cells(3, 6) & vbNewLine & "" & vbNewLine & Sheets("List").Cells(3, 7)
            imgResPic.Picture = LoadPicture(pathName & Sheets("List").Cells(3, 5) & ".jpg")
        Case 25 To 49
            lblResAd = Sheets("List").Cells(4, 6) & vbNewLine & "" & vbNewLine & Sheets("List").Cells(4, 7)
            imgResPic.Picture = LoadPicture(pathName & Sheets("List").Cells(4, 5) & ".jpg")
        Case 50 To 79
            lblResAd = Sheets("List").Cells(5, 6) & vbNewLine & "" & vbNewLine & Sheets("List").Cells(5, 7)
            imgResPic.Picture = LoadPicture(pathName & Sheets("List").Cells(5, 5) & ".jpg")
        Case 80 To 100
            lblResAd = Sheets("List").Cells(6, 6) & vbNewLine & "" & vbNewLine & Sheets("List").Cells(6, 7)
            imgResPic.Picture = LoadPicture(pathName & Sheets("List").Cells(6, 5) & ".jpg")
        Case Else
            lblResAd = "Game Over"
    End Select
    
End Function
