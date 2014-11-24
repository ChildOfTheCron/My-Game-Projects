using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {
	
	float scr_w = Screen.width/2;
	float scr_y = Screen.height/2;
	
	GUIText retryObject;
	
	// Use this for initialization
	void Start () {
		retryObject = GameObject.Find("RetryButton").gameObject.GetComponent<GUIText>();
		retryObject.pixelOffset = new Vector2(scr_w, scr_y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		GameObject.Find("Counter").gameObject.GetComponent<TimerScript>().setTimer(true);
		retryObject.enabled = false;
		Debug.Log("Clicked Retry");
	}
	
}
