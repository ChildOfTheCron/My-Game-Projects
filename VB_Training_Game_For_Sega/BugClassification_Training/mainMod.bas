Attribute VB_Name = "mainMod"
Public intGameType As Integer 'If it's one it means Random, if it's zero it means static
Public strResults As String

'Totals used for calcs in score frm
Public intATotalWrong As Integer
Public intBTotalWrong As Integer
Public intCTotalWrong As Integer
Public intDTotalWrong As Integer
Public intTotalBugs As Integer


Sub Button17_Click()

    'frmChoose.Show
    'frmTrainingGame.Show
    ThisWorkbook.Application.Visible = False
    frmWelcome.Show
    
    
End Sub
