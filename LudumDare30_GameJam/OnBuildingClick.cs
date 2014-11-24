using UnityEngine;
using System.Collections;

public class OnBuildingClick : MonoBehaviour {
	
	public int BuildingID;
	BuildingOverlord tempRoomHolder;
	
	
	// Use this for initialization
	void Start () {
		tempRoomHolder = GameObject.Find("Main Camera").GetComponent<BuildingOverlord>();
		//BuildingID = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		tempRoomHolder.setSelectedBuilding(BuildingID);
		tempRoomHolder.spawnBuilding();
		Debug.Log("OnBuildingClicked");
	}
}
