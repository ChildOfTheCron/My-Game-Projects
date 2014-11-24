using UnityEngine;
using System.Collections;

public class BuildingOverlord : MonoBehaviour {
	
	//I should really rework these classes - Building Manager now also deals with all the global stats - not good
	// But running out of time and getting sleepy! So im using it as is for now. Need to access the Cash var
	private BuildingManager tempBuildingManager;
	
	private int BuildingSelect;
	private Vector3 tempVec;
	
	public GameObject Building0;
	public GameObject Building1;
	public GameObject Building2;
	public GameObject Building3;
	public GameObject Building4;
	
	//Factories go here
	public GameObject Building5;
	public GameObject Building6;
	public GameObject Building7;
	public GameObject Building8;
	
	//Defence buildings
	public GameObject Building9;
	
	//Defence buildings
	public GameObject Building10;
	
	private GameObject killObject;
	
	// Use this for initialization
	void Start () {
		tempBuildingManager = GameObject.Find("Main Camera").GetComponent<BuildingManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setSelectedBuilding(int x){
		BuildingSelect = x;
		Debug.Log(BuildingSelect);
	}
	
	public void getTrans(Vector3 x){
		tempVec = x;
		//tempObject.transform.position = x;
		//Debug.Log(tempObject.transform.position);
		//Instantiate(Building2, x, transform.rotation);
	}
	
	public void setKill(GameObject x){
		killObject = x;
		Debug.Log("Object to Set Kill is: " + killObject); 
	}
	
	public void spawnBuilding(){
		if(tempBuildingManager.getCash() > 0){
			//Destroy(killObject);
			switch (BuildingSelect) {
				//HAB blocks
				case 0: Instantiate(Building0, tempVec, transform.rotation);
						Destroy(killObject);
	            break;
	        	case 1: Instantiate(Building1, tempVec, transform.rotation);
						Destroy(killObject);
	            break;
				case 2: Destroy(killObject); Instantiate(Building2, tempVec, transform.rotation);
						//Destroy(killObject);
						//Messy but can add OnROomClickUpdate call here?
						//NO NO - I got dis! You instantiate BEFORE you Destroy
						//This means you can't update the list as it won't have a null value
						//UNtill after the Instantiate. Swap the two!
	            break;
				case 3: Instantiate(Building3, tempVec, transform.rotation);
						Destroy(killObject);
	            break;
				case 4: Instantiate(Building4, tempVec, transform.rotation);
						Destroy(killObject);
	            break;
				//Factories
				//Need to see if we have enough refugees to help man the stations before we allow a building
				case 5: if(tempBuildingManager.getRedPop() > 0){ 
							Instantiate(Building5, tempVec, transform.rotation);
							Destroy(killObject);
						}
	            break;
				case 6: if(tempBuildingManager.getBluePop() > 0){ 
							Instantiate(Building6, tempVec, transform.rotation);
							Destroy(killObject);
						}
	            break;
				case 7: if(tempBuildingManager.getYellowPop() > 0){
							Instantiate(Building7, tempVec, transform.rotation);
							Destroy(killObject);
						}
	            break;
				case 8: if(tempBuildingManager.getGreenPop() > 0){
						Instantiate(Building8, tempVec, transform.rotation);
						Destroy(killObject);
						}
				break;
				//Defence
				case 9: if(tempBuildingManager.getRedPop() > 0){ 
						Instantiate(Building9, tempVec, transform.rotation);
						Destroy(killObject);
						}
	            break;
				//Hospitals
				case 10: if(tempBuildingManager.getBluePop() > 0){ 
						Instantiate(Building10, tempVec, transform.rotation);;
						Destroy(killObject);
						}
	            break;
				default: Instantiate(Building0, tempVec, transform.rotation);
	            break;
			}
		}
	}
}
