using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {
	
	float scr_w = Screen.width/2;
	float scr_y = Screen.height-50;
	//Rect screenPos = new Rect(0F, 0F, Screen.width/2, Screen.height/4);
	//Vector2 screenPos;
	
	GUIText timerObject; 
	
	bool TmrRun;
	
	int clock;
	
	// Use this for initialization
	void Start () {
		TmrRun = true;
		timerObject = GameObject.Find("Counter").gameObject.GetComponent<GUIText>();
		timerObject.pixelOffset = new Vector2(scr_w, scr_y);
		
		InvokeRepeating("customCounter", 1F, 1F);
		
		//TimerTextScr_w = GameObject.Find("Timer").gameObject.GetComponent<GUIText>().pixelOffset.x;
		//TimerTextScr_y = GameObject.Find("Timer").gameObject.GetComponent<GUIText>().pixelOffset.y;
		
		//TimerTextScr_w = scr_w;
		//TimerTextScr_y = scr_y;

	}
	
	// Update is called once per frame
	void Update () {
		if(TmrRun == true){
			GameObject.Find("Counter").gameObject.GetComponent<GUIText>().text = clock.ToString("0:00");
			//Devided below by 255 as the float numbers in Color are not Color32 and need to be diveded to get a number between 0.0 and 1.0
			GameObject.Find("Counter").gameObject.GetComponent<GUIText>().color = new Color(197F/255,130F/255,12F/255,255F/255);
		}
		else{
			GameObject.Find("Counter").gameObject.GetComponent<GUIText>().color = Color.blue;
			GameObject.Find("Counter").gameObject.GetComponent<GUIText>().text = "SPLASHED!";
			clock = 0;
			
			GameObject.Find("RetryButton").gameObject.GetComponent<GUIText>().enabled = true;
		}
	}
	
	public bool setTimer(bool x)
	{
		TmrRun = x;
		return TmrRun;
	}
	
	void customCounter(){
		clock++;
	}
}
