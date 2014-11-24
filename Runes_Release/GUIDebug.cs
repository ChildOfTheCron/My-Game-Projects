using UnityEngine;
using System.Collections;

public class GUIDebug : MonoBehaviour {
	
	public GUIStyle DebugStyle;
	
	string ArrayDebugValOne;
	string ArrayDebugValTwo;
	string ArrayDebugValThree;
	bool IsMatchVal;
	int ScoreVal;
	
	bool ToggleDebug;
	
	public RuneSaver runesaver; //create a RuneSaver object
	
	// Use this for initialization
	void Start () {
		ToggleDebug = false;
		runesaver = GameObject.Find("Main Camera").gameObject.GetComponent<RuneSaver>();
		
	}
	
	// Update is called once per frame
	void Update () {
			ArrayDebugValThree = runesaver.getRuneThreeValue();
			ArrayDebugValTwo = runesaver.getRuneTwoValue();
			ArrayDebugValOne = runesaver.getRuneOneValue();
			IsMatchVal = runesaver.getMatchBool();
			ScoreVal = runesaver.getScore();
	}
	
	void OnGUI(){
		//GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.Box (new Rect (0,0,400,25), "Debug Output");
		
		if(GUI.Button(new Rect(0,0,50,25), "Toggle")) {
			if(ToggleDebug == false){
				ToggleDebug = true;
			}
			else{
				ToggleDebug = false;
			}
		
		}
		if(ToggleDebug == true){
			GUI.Box (new Rect (0,25,400,25), "Array Value 1: " + ArrayDebugValOne);
			GUI.Box (new Rect (0,50,400,25), "Array Value 2: " + ArrayDebugValTwo);
			GUI.Box (new Rect (0,75,400,25), "Array Value 3: " + ArrayDebugValThree);
			GUI.Box (new Rect (0,100,400,25), "Is Match Bool?: " + IsMatchVal);
			GUI.Box (new Rect (0,125,400,25), "Score is: " + ScoreVal);
		}
	}
	
}
