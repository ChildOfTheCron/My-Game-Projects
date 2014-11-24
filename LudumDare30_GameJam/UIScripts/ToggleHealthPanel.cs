using UnityEngine;
using System.Collections;

public class ToggleHealthPanel : MonoBehaviour {
	private bool loadReady;
	private bool loadCheck; //added late
	private int i;
	
	private bool toggle;
	
	//Health Panel icons/panels
	//GUITexture HealthPanel;
	GameObject HealthPanel;
	
	//Other panels
	//GUITexture HABPanel_Panel;
	//GUITexture MoneyPanel_Panel;
	//GUITexture DefencePanel_Panel;
	GameObject HABPanel_Panel;
	GameObject MoneyPanel_Panel;
	GameObject DefencePanel_Panel;
	
	// Use this for initialization
	void Start () {
		loadCheck = false; //added late
		i = 0;		
		toggle = true;
		Debug.Log("in Start - Health panel toggle is: " + toggle);
		//--
		//HealthPanel = GameObject.Find("HealthPanel").gameObject.GetComponent<GUITexture>();
		HealthPanel = GameObject.Find("HospitalBuildingPanel").gameObject;
		
		//Hiding the other menu's that may be active upon opening this one
		//HABPanel_Panel = GameObject.Find("HABPanel").gameObject.GetComponent<GUITexture>();
		//MoneyPanel_Panel = GameObject.Find("MoneyPanel").gameObject.GetComponent<GUITexture>();
		//DefencePanel_Panel = GameObject.Find("DefPanel").gameObject.GetComponent<GUITexture>();
		DefencePanel_Panel = GameObject.Find("DefencePanel").gameObject;
		HABPanel_Panel = GameObject.Find("HABBuildingPanel").gameObject;
		MoneyPanel_Panel = GameObject.Find("MoneyBuildingPanel").gameObject;
		
		if(HABPanel_Panel != null && MoneyPanel_Panel != null && DefencePanel_Panel != null){ //added late
			loadCheck = true; //added late
		} //added late
	}
	
	// Update is called once per frame
	void Update () {
		//HABs - only check panel because if that one is active, all other UI elements -should- have been set to active as well
		while(i < 1){
		if(loadReady == true){
			if(HealthPanel.gameObject.activeSelf == true){
				HealthPanel.gameObject.SetActive(false);
			}
		}
			i++;
		}
		
	}
	
	void OnMouseDown() {
		Debug.Log("HP toggle is: " + toggle);
		
		if(HealthPanel.gameObject.activeSelf == false){
			HealthPanel.gameObject.SetActive(true);
			toggle = false;
		}
		else{
			HealthPanel.gameObject.SetActive(false);
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
		if(DefencePanel_Panel.gameObject.activeSelf == true){
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
