using UnityEngine;
using System.Collections;

public class ToggleHabPanel : MonoBehaviour {
	
	public bool loadCheck;
	public bool loadReady;
	private int i;
	
	//button toggle
	private bool toggle;
	
	//This is messy but I'm tired of working with GUITextures now
	//HAB Panel
	//GUITexture habPanel;
	GameObject habPanel;

	//Other panels
	//GUITexture DefencePanel_Panel;
	//GUITexture MoneyPanel_Panel;
	//GUITexture HospitalPanel_Panel;
	GameObject DefencePanel_Panel;
	GameObject MoneyPanel_Panel;
	GameObject HospitalPanel_Panel;
		
	// Use this for initialization
	void Start () {
		loadCheck = false;
		i = 0;
		//Setting the toggle
		toggle = true;
		Debug.Log("in Start - HAB panel toggle is: " + toggle);
		//Hiding all the buildings and the menu panel
		//habPanel = GameObject.Find("HABPanel").gameObject.GetComponent<GUITexture>();
		habPanel = GameObject.Find("HABBuildingPanel").gameObject;
		
		//Hiding the other menu's that may be active upon opening this one
		//DefencePanel_Panel = GameObject.Find("DefPanel").gameObject.GetComponent<GUITexture>();
		//MoneyPanel_Panel = GameObject.Find("MoneyPanel").gameObject.GetComponent<GUITexture>();
		//HospitalPanel_Panel = GameObject.Find("HealthPanel").gameObject.GetComponent<GUITexture>();
		DefencePanel_Panel = GameObject.Find("DefencePanel").gameObject;
		MoneyPanel_Panel = GameObject.Find("MoneyBuildingPanel").gameObject;
		HospitalPanel_Panel = GameObject.Find("HospitalBuildingPanel").gameObject;
		
		if(DefencePanel_Panel != null && MoneyPanel_Panel != null && HospitalPanel_Panel != null){
			loadCheck = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//HABs - only check panel because if that one is active, all other UI elements -should- have been set to active as well
		while(i < 1){
		if(loadReady == true){
			if(habPanel.gameObject.activeSelf == true){
				habPanel.gameObject.SetActive(false);
			}
		}
			i++;
		}

	}
	
	void OnMouseDown() {
		Debug.Log("HAB PANEL toggle is: " + toggle);
		
		if(habPanel.gameObject.activeSelf == false){
			habPanel.gameObject.SetActive(true);
			toggle = false;
		}
		else{
			habPanel.gameObject.SetActive(false);
			toggle = true;
		}
		
		//Trying to hide the other menu's that may be open
		//Only checking the panel, if I set the panel to active then I always set the icons to active as well
		if(DefencePanel_Panel.gameObject.activeSelf == true){
			Debug.Log(DefencePanel_Panel + "Is true setting to false!"); //This is not really setting it to false for some reason??!
			DefencePanel_Panel.gameObject.SetActive(false);
		}
		if(MoneyPanel_Panel.gameObject.activeSelf == true){
			Debug.Log(MoneyPanel_Panel + "Is true setting to false!"); //This is not really setting it to false for some reason??!
			MoneyPanel_Panel.gameObject.SetActive(false);
		}
		if(HospitalPanel_Panel.gameObject.activeSelf == true){
			Debug.Log(DefencePanel_Panel + "Is true setting to false!"); //This is not really setting it to false for some reason??!
			DefencePanel_Panel.gameObject.SetActive(false);
		}
	}
	
	public bool getLoadCheck(){
		return loadCheck;
	}
	
	public void setLoadReady(bool x){
		loadReady = x;
	}
}
