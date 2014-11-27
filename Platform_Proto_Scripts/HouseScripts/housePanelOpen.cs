using UnityEngine;
using System.Collections;

public class housePanelOpen : MonoBehaviour {
	private bool toggle;
	private GameObject tempObject;
	
	// Use this for initialization
	void Start () {
		toggle = false;
		tempObject = GameObject.Find("BuildingPanel");
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseDown() {
		
		if(tempObject.gameObject.activeSelf == true){
			tempObject.gameObject.SetActive(false);
		}
		else{
			tempObject.gameObject.SetActive(true);
		}
	}
}
