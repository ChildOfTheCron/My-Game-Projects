using UnityEngine;
using System.Collections;

public class GameOverButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		Application.LoadLevel("MainMenu");
	}
}
