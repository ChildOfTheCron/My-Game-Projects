using UnityEngine;
using System.Collections;

public class CloseHowToMenu : MonoBehaviour {
	
	GUITexture howtoplay;
	GUITexture closebtn;

	// Use this for initialization
	void Start () {
		howtoplay = GameObject.Find("HowToPlayBox").gameObject.GetComponent<GUITexture>();
		closebtn = GameObject.Find("closeHowMenu").gameObject.GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		howtoplay.gameObject.SetActive(false);
		closebtn.gameObject.SetActive(false);	
	}
}
