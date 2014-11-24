using UnityEngine;
using System.Collections;

public class CloseCredMenu : MonoBehaviour {

	GUITexture credits;
	GUITexture closeCredbtn;

	// Use this for initialization
	void Start () {
		credits = GameObject.Find("CreditsBox").gameObject.GetComponent<GUITexture>();
		closeCredbtn = GameObject.Find("closeCredMenu").gameObject.GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		credits.gameObject.SetActive(false);
		closeCredbtn.gameObject.SetActive(false);	
	}
}
