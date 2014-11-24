using UnityEngine;
using System.Collections;

public class TogglePanels : MonoBehaviour {
	
	private ToggleHabPanel HabPanelLoadCheck;
	private ToggleDefencePanel DefPanelLoadCheck;
	private ToggleMoneyPanel MoneyPanelLoadCheck;
	private ToggleHealthPanel HealthPanelLoadCheck;
	
	private bool defBool;
	private bool habBool;
	private bool monBool;
	private bool hpbool;
	
	// Use this for initialization
	void Start () {
		HabPanelLoadCheck = GameObject.Find("HABTag").gameObject.GetComponent<ToggleHabPanel>();
		DefPanelLoadCheck = GameObject.Find("DefTag").gameObject.GetComponent<ToggleDefencePanel>();
		MoneyPanelLoadCheck = GameObject.Find("MoneyTag").gameObject.GetComponent<ToggleMoneyPanel>();
		HealthPanelLoadCheck = GameObject.Find("HealthTag").gameObject.GetComponent<ToggleHealthPanel>();
		
		defBool = DefPanelLoadCheck.getLoadCheck();
		habBool = HabPanelLoadCheck.getLoadCheck();
		monBool = MoneyPanelLoadCheck.getLoadCheck();
		hpbool = HealthPanelLoadCheck.getLoadCheck();
		
	}
	
	// Update is called once per frame
	void Update () {
		defBool = DefPanelLoadCheck.getLoadCheck();
		habBool = HabPanelLoadCheck.getLoadCheck();
		monBool = MoneyPanelLoadCheck.getLoadCheck();
		hpbool = HealthPanelLoadCheck.getLoadCheck();
		
		if(defBool == true && habBool == true && monBool == true && hpbool == true){
			//Debug.Log ("All panel elements loaded into toggle buttons!");
			HabPanelLoadCheck.setLoadReady(true);
			DefPanelLoadCheck.setLoadReady(true);
			MoneyPanelLoadCheck.setLoadReady(true);
			HealthPanelLoadCheck.setLoadReady(true);
		}else{
			Debug.Log ("Not done loading!");
		}

	}
}
