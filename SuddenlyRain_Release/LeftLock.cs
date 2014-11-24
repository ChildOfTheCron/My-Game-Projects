using UnityEngine;
using System.Collections;

public class LeftLock : MonoBehaviour {
	
	MoveScript getPlayerMoveScript;
	
	// Use this for initialization
	void Start () {
		getPlayerMoveScript = GameObject.Find("Player").gameObject.GetComponent<MoveScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Player")
		{	
			Debug.Log ("LeftBoundHit");
			getPlayerMoveScript.setLeftBounds(true);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.name == "Player")
		{	
			Debug.Log ("LeftBoundHit");
			getPlayerMoveScript.setLeftBounds(false);
		}
	}
}
