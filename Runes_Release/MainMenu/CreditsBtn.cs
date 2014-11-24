using UnityEngine;
using System.Collections;

public class CreditsBtn : MonoBehaviour {
	
	GUITexture credits;
	GUITexture closecredits;
	
	// Use this for initialization
	void Start () {
		credits = GameObject.Find("CreditsBox").gameObject.GetComponent<GUITexture>();
		closecredits = GameObject.Find("closeCredMenu").gameObject.GetComponent<GUITexture>();

		credits.gameObject.SetActive(false);
		closecredits.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		if(gameObject.name == "CreditText"){
		credits.gameObject.SetActive(true);
		closecredits.gameObject.SetActive(true);
		}
	}
}
