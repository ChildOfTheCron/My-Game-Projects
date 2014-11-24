using UnityEngine;
using System.Collections;

public class HowToBtn : MonoBehaviour {

	GUITexture howtoplay;
	GUITexture closebtn;	
	
	// Use this for initialization
	void Start () {
		howtoplay = GameObject.Find("HowToPlayBox").gameObject.GetComponent<GUITexture>();
		closebtn = GameObject.Find("closeHowMenu").gameObject.GetComponent<GUITexture>();
		
		howtoplay.gameObject.SetActive(false);
		closebtn.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		if(gameObject.name == "HowText"){
			howtoplay.gameObject.SetActive(true);
			closebtn.gameObject.SetActive(true);
		}
	}
}
