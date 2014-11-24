using UnityEngine;
using System.Collections;

public class OnRoomClickUpdate : MonoBehaviour {

	private RoomSelectTracker roomList;
	// Use this for initialization
	void Start () {
		roomList = GameObject.Find("Main Camera").GetComponent<RoomSelectTracker>();
		roomList.updateList(this.gameObject);
		//roomList.addRoom(this.gameObject);
		//roomList.setUnselectedVisual();
		//roomList.quickDebug();
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		//Got this of the net - Behaviours are Components that can be enabled or disabled
		//The Halo type doesn't work like other components it seems. This works though
		//Strange syntax - returns the type Halo and then uses the Behaviour variable to set eneabled = true
		roomList.setUnselectedVisual();
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = true;
		roomList.quickDebug();
	}
	
	public void setNoHalo(){
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = false;
	}
}