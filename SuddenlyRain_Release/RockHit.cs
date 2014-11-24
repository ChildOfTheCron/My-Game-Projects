using UnityEngine;
using System.Collections;

public class RockHit : MonoBehaviour {
	
	//Object getTimerScript;
	
	// Use this for initialization
	void Start () {
		//getTimerScript = GameObject.Find("Timer").gameObject.GetComponent<TimerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Rock(Clone)")
		{
			Debug.Log ("Rock Hit Player");
			GameObject.Find("Counter").gameObject.GetComponent<TimerScript>().setTimer(false);
			GameObject.Find("Camera").gameObject.GetComponent<SoundManager>().PlaySplash();
		}
	}
}
