using UnityEngine;
using System.Collections;

public class clickWinLose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		if(gameObject.name == "WonGamePanel"){
			//Do win stuff here
		}
		else{
			if(gameObject.name == "LostGamePanel"){
			 //Do lost stuff here
			}
		}
	}
}
