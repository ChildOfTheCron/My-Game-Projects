using UnityEngine;
using System.Collections;

public class RightLock : MonoBehaviour {
	
	MoveScript getPlayerMoveScript;
	
	// Use this for initialization
	void Start () {
		//getPlayerMoveScript = 
		getPlayerMoveScript = GameObject.Find("Player").gameObject.GetComponent<MoveScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Player")
		{	
			Debug.Log ("RightBoundHit");
			getPlayerMoveScript.setRightBounds(true);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.name == "Player")
		{	
			Debug.Log ("RightBoundHit");
			getPlayerMoveScript.setRightBounds(false);
		}
	}
}
