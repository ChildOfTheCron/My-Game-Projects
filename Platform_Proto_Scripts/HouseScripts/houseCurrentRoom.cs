using UnityEngine;
using System.Collections;

public class houseCurrentRoom : MonoBehaviour {
	
	houseRoomOverlord tempRoomHolder;
	
	// Use this for initialization
	void Start () {
		tempRoomHolder = GameObject.Find("Main Camera").GetComponent<houseRoomOverlord>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		tempRoomHolder.setCurrentRoom(gameObject);
	}
}
