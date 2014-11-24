using UnityEngine;
using System.Collections;

public class TEST_GUIList : MonoBehaviour {
	private RoomSelectTracker tempShowDebugList;
	// Use this for initialization
	void Start () {
		tempShowDebugList = GameObject.Find("Main Camera").GetComponent<RoomSelectTracker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		tempShowDebugList.quickDebug();
	}
}
