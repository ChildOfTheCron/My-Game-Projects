using UnityEngine;
using System.Collections;

public class HoverFunc : MonoBehaviour {
	
	GUIText hovertext;
	bool isactive;
	
	// Use this for initialization
	void Start () {
		Debug.Log (gameObject.name);
		if(gameObject.name == "StartText"){
			hovertext = GameObject.Find("StartDescription").gameObject.GetComponent<GUIText>();
			hovertext.gameObject.SetActive(false);
		}
		
		if(gameObject.name == "HowText"){
			hovertext = GameObject.Find("HowDescription").gameObject.GetComponent<GUIText>();
			hovertext.gameObject.SetActive(false);
		}
		
		if(gameObject.name == "CreditText"){
			hovertext = GameObject.Find("CredDescription").gameObject.GetComponent<GUIText>();
			hovertext.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver(){
		hovertext.gameObject.SetActive(true);
	}
	
	void OnMouseExit(){
		hovertext.gameObject.SetActive(false);
	}
}
