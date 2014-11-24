VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmChoose 
   Caption         =   "Select Game Type"
   ClientHeight    =   9390
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   7335
   OleObjectBlob   =   "frmChoose.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmChoose"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Form is now used for the help menu in Datasheet
Private Sub imgClose_Click()

    Unload Me

End Sub

Private Sub UserForm_Activate()

txtHelp.Text = "The data seen in this sheet can be used to manage and add new bugs to the game." _
& vbNewLine & " " & vbNewLine & "As long as the format of the datasheet is not changed the game will be able to use the data. " & _
"To add additional bugs add new entries at the bottom of the datasheet. To remove a bug delete the WHOLE row of the bug." _
& vbNewLine & " " & vbNewLine & "Important Notes:" & vbNewLine & " " & vbNewLine _
& "Using only numbers as an ID name will not work, the ID name can be anything as long as it contains only digits AND characters e.g.: JG453. Following the template thus far will be the best solution. COL_A1 means the first Collision issue of class A." _
& vbNewLine & " " & vbNewLine & "Ensure that the image name used corresponds to the name of the image you wish to use for the bug. For ID COL_A1 the image name of the actual image needs to be COL_A1." _
& vbNewLine & " " & vbNewLine & "Ensure images are in the .JPG format. The game requires this format to work and load the images." & vbNewLine & " " & vbNewLine _
& "It is important to ensure all the areas are filled in with information as the game reads through this and blank entries will cause issues." & vbNewLine & " " & vbNewLine _
& "Only use A, B, C, and D for bug classes. Any other classes or combinations will cause the game to crash. If the bug is a high C low B then it is best to mark it as a certain class and mention this fact in the Description." & vbNewLine & " " & vbNewLine _
& "There is no limit to how many bugs you can add, but the more bugs you have, the slower the game will run." & _
"When in doubt it may be wise to backup this sheet should anything happen to the original." & vbNewLine & " " & vbNewLine _
& "- QC FNC Team"



End Sub

Private Sub UserForm_Click()



End Sub
