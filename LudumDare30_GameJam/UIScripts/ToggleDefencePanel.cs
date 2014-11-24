using UnityEngine;
using System.Collections;

public class ToggleDefencePanel : MonoBehaviour {
	private bool loadReady;
	private bool loadCheck; //added late
	private int i;
	
	private bool toggle;
	
	//Defence Panel icons/panels
	//GUITexture defencePanel;
	GameObject defencePanel;
	
	//Other panels
	//GUITexture HABPanel_Panel;
	//GUITexture MoneyPanel_Panel;
	//GUITexture HospitalPanel_Panel;
	GameObject HABPanel_Panel;
	GameObject MoneyPanel_Panel;
	GameObject HospitalPanel_Panel;
	
	// Use this for initialization
	void Start () {
		loadCheck = false; //added late
		i = 0;
		toggle = true;
		Debug.Log("in Start - Defence panel toggle is: " + toggle);
		//Hiding all the buildings and the menu panel
		//defencePanel = GameObject.Find("DefPanel").gameObject.GetComponent<GUITexture>();
		defencePanel = GameObject.Find("DefencePanel").gameObject;
		
		//Hiding the other menu's that may be active upon opening this one
		//HABPanel_Panel = GameObject.Find("HABPanel").gameObject.GetComponent<GUITexture>();
		//MoneyPanel_Panel = GameObject.Find("MoneyPanel").gameObject.GetComponent<GUITexture>();
		//HospitalPanel_Panel = GameObject.Find("HealthPanel").gameObject.GetComponent<GUITexture>();
		HABPanel_Panel = GameObject.Find("HABBuildingPanel").gameObject;
		MoneyPanel_Panel = GameObject.Find("MoneyBuildingPanel").gameObject;
		HospitalPanel_Panel = GameObject.Find("HospitalBuildingPanel").gameObject;
		
		if(HABPanel_Panel != null && MoneyPanel_Panel != null && HospitalPanel_Panel != null){ //added late
			loadCheck = true; //added late
		} //added late
		
	}
	
	// Update is called once per frame
	void Update () {
		//HABs - only check panel because if that one is active, all other UI elements -should- have been set to active as well
		while(i < 1){
		if(loadReady == true){
			if(defencePanel.gameObject.activeSelf == true){
				defencePanel.gameObject.SetActive(false);
			}
		}
			i++;
		}
	}
	
	void OnMouseDown() {
		Debug.Log("DEF toggle is: " + toggle);
		//I'm using defencePanel.gameObject.activeSelf here becuase the toggle value will be reset
		//when the object is re-activated by a different script
		//This is what was causing the annoying as hell double click on TAB bug.
		//Using defencePanel.gameObject.activeSelf bypasses this as it can be set by the other scripts or by itself
		//and won't be re-initialised on it's start() method call.
		if(defencePanel.gameObject.activeSelf == false){
			defencePanel.gameObject.SetActive(true);
			toggle = false;
		}
		else{
			defencePanel.gameObject.SetActive(false);
			toggle = true;
		}
		
		//Trying to hide the other menu's that may be open
		//Only checking the panel, if I set the panel to active then I always set the icons to active as well
		if(HABPanel_Panel.gameObject.activeSelf == true){
			Debug.Log(HABPanel_Panel + "Is true setting to false!"); //This is not really setting it to false for some reason??!
			HABPanel_Panel.gameObject.SetActive(false);
		}
		if(MoneyPanel_Panel.gameObject.activeSelf == true){
			Debug.Log(MoneyPanel_Panel + "Is true setting to false!"); //This is not really setting it to false for some reason??!
			MoneyPanel_Panel.gameObject.SetActive(false);
		}
		if(HospitalPanel_Panel.gameObject.activeSelf == true){
			Debug.Log(HospitalPanel_Panel + "Is true setting to false!"); //This is not really setting it to false for some reason??!
			HospitalPanel_Panel.gameObject.SetActive(false);
		}
	}
	
	public bool getLoadCheck(){
		return loadCheck;
	}
	
	public void setLoadReady(bool x){
		loadReady = x;
	}
}
