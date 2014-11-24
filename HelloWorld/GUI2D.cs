using UnityEngine;
using System.Collections;

public class GUI2D : MonoBehaviour {
	
	public Texture2D controlTexture;
	
	public bool MsgBoxUp = false;
	
	// Use this for initialization
	void Start () {
		//Lets leave this for now...
		//GameObject.Text("lol");
		//GUIText.Equals("Text Has Changed!");
	}
	
	void Update(){
		
	}

	void OnGUI () {
		//GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
		//GUIContent is used to combinee the texture and a string and display them as a GUIContant object
		GUI.Box (new Rect (Screen.width - 100,0,100,50), new GUIContent("Smiley Label!", controlTexture));
		//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
		//GUI.Box (new Rect (0,0,100,50), "Top-left");
		// Rect() defines four properties: left-most position, top-most position, total width, total height.
		
		if (GUI.Button (new Rect (10,10,150,100), "Sexy 2D button")) {
			print ("You clicked the button!");
			if (MsgBoxUp == false){
			MsgBoxUp = true;
			}
			else{
				MsgBoxUp = false;	
			}
		}
	
		if (MsgBoxUp) {
			GUI.Box(new Rect(Screen.width/4,Screen.height/4,400,200), "Compartment Change");
			print ("MakeMsgBox is now set to TRUE");
		}
	}
}