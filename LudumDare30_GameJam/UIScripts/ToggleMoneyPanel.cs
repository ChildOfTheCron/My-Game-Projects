using UnityEngine;
using System.Collections;

public class ToggleMoneyPanel : MonoBehaviour {
	
	private bool toggle;
	public bool loadCheck;
	public bool loadReady;
	private int i;
	
	//Money Panel icons/panels
	//GUITexture moneyPanel;
	GameObject moneyPanel;
	
	
	//Other panels
	//GUITexture DefencePanel_Panel;
	//GUITexture HABPanel_Panel;
	//GUITexture HospitalPanel_Panel;
	GameObject DefencePanel_Panel;
	GameObject HABPanel_Panel;
	GameObject HospitalPanel_Panel;
	
	//Seeing if I can fix the GUI panel bug.
	//This seems to work! I don't like using public scope and plugging things in via the engine but
	//low on time.
	//Getting this to fix my bug fully is not going to be hard but it's going to take way to much time :(
	//I'm gonna leave the bug in, for now
	//public GUITexture HABPanel;
	//public GUITexture DefPanel;
	//public GUITexture HealPanel;
	
	// Use this for initialization
	void Start () {
		//--
		loadCheck = false;
		i = 0;
		toggle = true;
		Debug.Log("in Start - Money panel toggle is: " + toggle);
		
		//moneyPanel = GameObject.Find("MoneyPanel").gameObject.GetComponent<GUITexture>();
		moneyPanel = GameObject.Find("MoneyBuildingPanel").gameObject;
		
		//Hiding the other menu's that may be active upon opening this one
		//DefencePanel_Panel = GameObject.Find("DefPanel").gameObject.GetComponent<GUITexture>();
		//HABPanel_Panel = GameObject.Find("HABPanel").gameObject.GetComponent<GUITexture>();
		//HospitalPanel_Panel = GameObject.Find("HealthPanel").gameObject.GetComponent<GUITexture>();
		DefencePanel_Panel = GameObject.Find("DefencePanel").gameObject;
		HABPanel_Panel = GameObject.Find("HABBuildingPanel").gameObject;
		HospitalPanel_Panel = GameObject.Find("HospitalBuildingPanel").gameObject;
		
		if(DefencePanel_Panel != null && HABPanel_Panel != null && HospitalPanel_Panel != null){
			loadCheck = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//HABs - only check panel because if that one is active, all other UI elements -should- have been set to active as well
		while(i < 1){
		if(loadReady == true){
			if(moneyPanel.gameObject.activeSelf == true){
				moneyPanel.gameObject.SetActive(false);
			}
		}
			i++;
		}
	}
	
	void OnMouseDown() {
		Debug.Log("Money toggle is: " + toggle);
		//I'm using defencePanel.gameObject.activeSelf here becuase the toggle value will be reset
		//when the object is re-activated by a different script
		//This is what was causing the annoying as hell double click on TAB bug.
		//Using defencePanel.gameObject.activeSelf bypasses this as it can be set by the other scripts or by itself
		//and won't be re-initialised on it's start() method call.
		if(moneyPanel.gameObject.activeSelf == false){
			moneyPanel.gameObject.SetActive(true);
			toggle = false;
		}
		else{
			moneyPanel.gameObject.SetActive(false);
			toggle = true;
		}
		
		//Trying to hide the other menu's that may be open
		//Only checking the panel, if I set the panel to active then I always set the icons to active as well
		if(DefencePanel_Panel.gameObject.activeSelf == true){
			Debug.Log(DefencePanel_Panel + "Is true setting to false!"); //This is not really setting it to false for some reason??!
			DefencePanel_Panel.gameObject.SetActive(false);
		}
		if(HABPanel_Panel.gameObject.activeSelf == true){
			Debug.Log(HABPanel_Panel + "Is true setting to false!"); //This is not really setting it to false for some reason??!
			HABPanel_Panel.gameObject.SetActive(false);
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
