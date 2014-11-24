VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmResult 
   Caption         =   "Results Screen"
   ClientHeight    =   6705
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   6420
   OleObjectBlob   =   "frmResult.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmResult"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Form displays the result menu after the game has been completed
Private totals As Integer
Private passRate As Integer

Private Sub cmdPrint_Click()

    frmResult.PrintForm

End Sub

Private Sub imgClose_Click()
'Closes the forms

    Unload Me
    Unload frmTrainingGame
    ThisWorkbook.Application.Visible = True

End Sub

Private Sub UserForm_Activate()
'On form load - load up the results and calculate pass rate

    addTotal
    lblData = mainMod.strResults & vbNewLine & " " & vbNewLine & "Total Score: " & totals & "/" & mainMod.intTotalBugs & vbNewLine & "Pass Rate: " & passRate & "%"

End Sub

Private Function addTotal()
'Calculate Procedure

    Dim tmpTotalWrong As Integer
    Dim tmpPassRate As Integer
    
    tmpTotalWrong = mainMod.intATotalWrong + mainMod.intBTotalWrong + mainMod.intCTotalWrong + mainMod.intDTotalWrong
    totals = mainMod.intTotalBugs - tmpTotalWrong
    
    tmpPassRate = totals / mainMod.intTotalBugs * 100
    passRate = tmpPassRate

End Function

