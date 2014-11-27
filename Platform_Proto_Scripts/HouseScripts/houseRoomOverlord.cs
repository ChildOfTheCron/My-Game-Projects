using UnityEngine;
using System.Collections;

public class houseRoomOverlord : MonoBehaviour {
	
	GameObject currentRoom;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setCurrentRoom(GameObject x){
		currentRoom = x;
		Debug.Log(currentRoom);
	}
	
	public GameObject getCurrentRoom(){
		return currentRoom;
		Debug.Log(currentRoom);
	}
}
