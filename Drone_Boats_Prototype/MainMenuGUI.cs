using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	
	Texture tex;
	public GUIStyle newStyle;
	
	// Use this for initialization
	void Start () {
	
		//newStyle.font = spaceage;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(Screen.width/2-60,Screen.height/2-50,100,90), "Main Menu",newStyle);

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width/2-40,Screen.height/2,80,20), "New Game")) {
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(Screen.width/2-40,Screen.height/2+25,80,20), "Tutorial")) {
			Application.LoadLevel(2);
		}
		if(GUI.Button(new Rect(Screen.width/2-40,Screen.height/2+50,80,20), "Credits")) {
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(Screen.width/2-40,Screen.height/2+75,80,20), "Quit")) {
			Application.LoadLevel(1);
		}

	}
}

