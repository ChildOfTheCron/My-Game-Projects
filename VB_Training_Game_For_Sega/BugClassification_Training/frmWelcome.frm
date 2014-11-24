VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmWelcome 
   Caption         =   "Welcome!"
   ClientHeight    =   7305
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   6015
   OleObjectBlob   =   "frmWelcome.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmWelcome"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub btnCloseWel_Click()
'Loads up the training game once the Welcome is closed
    frmTrainingGame.Show
    Unload Me
        
End Sub
