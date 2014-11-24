using UnityEngine;
using System.Collections;

public class DebugText : MonoBehaviour {
	
	string txtDebug;
	
	// Use this for initialization
	void Start () {
		txtDebug = null;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = txtDebug;
	}
	
	public string SetText(string x){
		txtDebug = x;
		return txtDebug;
	}
}
