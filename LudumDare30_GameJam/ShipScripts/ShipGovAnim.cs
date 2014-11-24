using UnityEngine;
using System.Collections;

public class ShipGovAnim : MonoBehaviour {
	
	private BuildingManager tempBuildingManager;
	
	// Use this for initialization
	void Start () {
		tempBuildingManager = GameObject.Find("Main Camera").GetComponent<BuildingManager>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 1 * (Time.deltaTime/4), 0);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "StopShip"){
			Destroy(gameObject);
			
			//Whatever the gov ship drops off
			tempBuildingManager.setCash(25);
			
		}
	}
}
