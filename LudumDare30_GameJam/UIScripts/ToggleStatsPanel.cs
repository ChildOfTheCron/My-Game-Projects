using UnityEngine;
using System.Collections;

public class ToggleStatsPanel : MonoBehaviour {
	
	private bool toggle;
	
	GameObject statsPanel;

	// Use this for initialization
	void Start () {
		//Setting the toggle
		toggle = false;
		Debug.Log("in Start - Stats panel toggle is: " + toggle);
		//Hiding all the menus
		//habPanel = GameObject.Find("DEBUG").gameObject.GetComponent<GUITexture>();
		statsPanel = GameObject.Find("StatsMasterPanel").gameObject;

		//statsPanel.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		Debug.Log("Stats toggle is: " + toggle);
		
		if(statsPanel.gameObject.activeSelf == false){
			statsPanel.gameObject.SetActive(true);
			toggle = false;
		}
		else{
			statsPanel.gameObject.SetActive(false);
			toggle = true;
		}					
	}
}
