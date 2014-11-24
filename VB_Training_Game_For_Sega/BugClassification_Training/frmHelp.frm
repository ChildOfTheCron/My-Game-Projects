VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmHelp 
   Caption         =   "Help Menu"
   ClientHeight    =   5070
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   6330
   OleObjectBlob   =   "frmHelp.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmHelp"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Form displays the in-game help menu
Private Sub imgClose_Click()

    Unload Me

End Sub

Private Sub txtHelp_Change()

End Sub

Private Sub UserForm_Activate()

    txtHelp.Text = "Welcome to the SEGA Class training game!" & vbNewLine & "- Click Start to begin the game." & vbNewLine & "- If you guess wrong 2 times a message will appear stating the correct choice and why." & vbNewLine & "- Select Exit to quit the game and return to the spreadsheet area." & vbNewLine & "- Made by the Quality Control FNC Team! :D"

End Sub

