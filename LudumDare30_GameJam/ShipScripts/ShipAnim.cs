using UnityEngine;
using System.Collections;

public class ShipAnim : MonoBehaviour {
	
	private bool stopped;
	private BuildingManager tempBuildingManager;
	
	// Use this for initialization
	void Start () {
		stopped = false;
		tempBuildingManager = GameObject.Find("Main Camera").GetComponent<BuildingManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(stopped == false){
			transform.Translate(-1 * (Time.deltaTime/2), 0, 0);
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "StopShip"){
			//Debug.Log("stopped set to true");
			stopped = true;
			Destroy(gameObject);
			
			//Note to self - script was being attached twice, thats why the numbers were off you dolt.
			if(gameObject.name == "EvacShipBlue(Clone)"){
				tempBuildingManager.setPop(5, "blue");
			}
			
			if(gameObject.name == "EvacShipRed(Clone)"){
				tempBuildingManager.setPop(5, "red");
			}
			
			if(gameObject.name == "EvacShipGreen(Clone)"){
				tempBuildingManager.setPop(5, "green");
			}
			
			if(gameObject.name == "EvacShipYellow(Clone)"){
				tempBuildingManager.setPop(5, "yellow");
			}
			//Debug.Log(gameObject.name);
		}
	}
}
