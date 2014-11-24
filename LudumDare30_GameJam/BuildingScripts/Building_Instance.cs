using UnityEngine;
using System.Collections;

public class Building_Instance : MonoBehaviour {

	private BuildingOverlord tempRoomHolder;
	private BuildingManager tempBuildingManager;
	
	private Vector3 tempVec; 
	
	// Use this for initialization
	void Start () {
		tempRoomHolder = GameObject.Find("Main Camera").GetComponent<BuildingOverlord>();
		tempBuildingManager = GameObject.Find("Main Camera").GetComponent<BuildingManager>();
		
		//The Capacity buildings are checked here. This is a Cap building then set the revelent details
		if(gameObject.name == "Building_HABRED(Clone)"){
			setRedHAB_stats();
		}
		if(gameObject.name == "Building_HABBLUE(Clone)"){
			setBlueHAB_stats();
		}
		if(gameObject.name == "Building_HABGREEN(Clone)"){
			setGreenHAB_stats();
		}
		if(gameObject.name == "Building_HABYELLOW(Clone)"){
			setYellowHAB_stats();
		}
		
		//Money buildsings checked here. Is this instantiation a money building? Set details if so
		if(gameObject.name == "Building_MechaFac(Clone)"){
			setMecha_stats();
		}
		if(gameObject.name == "Building_SolarArray(Clone)"){
			setSolarArray_stats();
		}
		if(gameObject.name == "Building_Pure(Clone)"){
			setPurification_stats();
		}
		if(gameObject.name == "Building_FoodPlant(Clone)"){
			setFoodPlant_stats();
		}
		
		//Defence buildings
		if(gameObject.name == "Building_Security(Clone)"){
			setSecurity_stats();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseDown() {
		
		gameObject.renderer.material.color = Color.red;
		tempVec = gameObject.transform.position;
		tempRoomHolder.getTrans(tempVec);
		Debug.Log(gameObject.transform.position);
		//Instantiate(BuildingTypeStore, transform.position, transform.rotation);
		//Destroy(gameObject);
		//tempRoomHolder.setKill(gameObject);
		removeRoom(); //<-Can't just call this willy nilly, if the player clicks ona building stats are removed, even if they didnt want to!
	}
	//Forgot that I could overwrite a building with another. This would mean that sombody could spam the same building and the
	//Stats wouldnt reset! D: I reset them below.
	void removeRoom(){		
		//Remove All teh Stats before destroying the building
		if(gameObject.name == "Building_HABRED(Clone)"){
			int capacityIncrease = -50;
			int buildingCost = 25;
			tempBuildingManager.setCap(capacityIncrease,"red");
			tempBuildingManager.setCash(buildingCost);
		}
		if(gameObject.name == "Building_HABBLUE(Clone)"){
			int capacityIncrease = -50;
			int buildingCost = 25;
			tempBuildingManager.setCap(capacityIncrease,"blue");
			tempBuildingManager.setCash(buildingCost);
		}
		if(gameObject.name == "Building_HABGREEN(Clone)"){
			int capacityIncrease = -50;
			int buildingCost = 25;
			tempBuildingManager.setCap(capacityIncrease,"green");
			tempBuildingManager.setCash(buildingCost);
		}
		if(gameObject.name == "Building_HABYELLOW(Clone)"){
			int capacityIncrease = -50;
			int buildingCost = 25;
			tempBuildingManager.setCap(capacityIncrease,"yellow");
			tempBuildingManager.setCash(buildingCost);
		}
		
		//Money buildings
		if(gameObject.name == "Building_MechaFac(Clone)"){
			int buildingCost = 25;
			int popCost = 10;
			tempBuildingManager.deductPop(popCost, "red");
			tempBuildingManager.setCash(buildingCost);
			tempBuildingManager.addManualPop(popCost, "red");
		}
		if(gameObject.name == "Building_SolarArray(Clone)"){
			int buildingCost = 25;
			int popCost = 10;
			tempBuildingManager.addManualPop(popCost, "yellow");
			tempBuildingManager.setCash(buildingCost);
		}
		if(gameObject.name == "Building_Pure(Clone)"){
			int buildingCost = 25;
			int popCost = 10;
			tempBuildingManager.addManualPop(popCost, "blue");
			tempBuildingManager.setCash(buildingCost);
		}
		if(gameObject.name == "Building_FoodProcPlant(Clone)"){
			int buildingCost = 25;
			int popCost = 10;
			tempBuildingManager.addManualPop(popCost, "green");
			tempBuildingManager.setCash(buildingCost);
		}
		
		//Defence buildings	
		if(gameObject.name == "Building_Security(Clone)"){
			int buildingCost = 25;
			int popCost = 5;
			tempBuildingManager.addManualPop(popCost, "red");
			tempBuildingManager.setCash(buildingCost);
		}
		
		//Healthcare buildings
		if(gameObject.name == "Building_MedBay(Clone)"){
			int buildingCost = 10;
			int popCost = 5;
			tempBuildingManager.addManualPop(popCost, "blue");
			tempBuildingManager.setCash(buildingCost);
		}
				
		tempRoomHolder.setKill(gameObject);
	}
	
	//Capacity buildings (HAB blocks)
	//*****************************************************************************************
	void setRedHAB_stats(){
		int capacityIncrease = 50;
		int buildingCost = 50;
		tempBuildingManager.setCap(capacityIncrease,"red");
		tempBuildingManager.deductCash(buildingCost);
	}
	
	void setBlueHAB_stats(){
		int capacityIncrease = 50;
		int buildingCost = 50;
		tempBuildingManager.setCap(capacityIncrease,"blue");
		tempBuildingManager.deductCash(buildingCost);
	}
	
	void setYellowHAB_stats(){
		int capacityIncrease = 50;
		int buildingCost = 50;
		tempBuildingManager.setCap(capacityIncrease,"yellow");
		tempBuildingManager.deductCash(buildingCost);
	}
	
	void setGreenHAB_stats(){
		int capacityIncrease = 50;
		int buildingCost = 50;
		tempBuildingManager.setCap(capacityIncrease,"green");
		tempBuildingManager.deductCash(buildingCost);
	}
	//*****************************************************************************************
	
	//Money buildings (Factories)
	//*****************************************************************************************	
	void setSolarArray_stats(){
		int moneyIncrease = 100;
		int buildingCost = 50;
		int popCost = 10;
		InvokeRepeating("repeatCashIncome_15", 1F, 10F);
		tempBuildingManager.deductPop(popCost, "yellow");
		tempBuildingManager.setCash(moneyIncrease);
		tempBuildingManager.deductCash(buildingCost);
	}
	
	void setMecha_stats(){
		int moneyIncrease = 100;
		int buildingCost = 50;
		int popCost = 10;
		InvokeRepeating("repeatCashIncome_10", 1F, 10F);
		tempBuildingManager.deductPop(popCost, "red");
		tempBuildingManager.setCash(moneyIncrease);
		tempBuildingManager.deductCash(buildingCost);
	}
	//Not done yet!
	void setPurification_stats(){
		int buildingCost = 50;
		int popCost = 10;
		tempBuildingManager.deductPop(popCost, "blue");
		tempBuildingManager.deductCash(buildingCost);
	}
	
	void setFoodPlant_stats(){
		int moneyIncrease = 100;
		int buildingCost = 50;
		int popCost = 10;
		InvokeRepeating("repeatCashIncome_5", 1F, 10F);
		tempBuildingManager.deductPop(popCost, "green");
		tempBuildingManager.setCash(moneyIncrease);
		tempBuildingManager.deductCash(buildingCost);
	}
	
	//Defence buildings
	//*****************************************************************************************	
	void setSecurity_stats(){
		int buildingCost = 35;
		int popCost = 5;
		InvokeRepeating("repeatHappyRate", 1F, 2F);
		//tempBuildingManager.AddHappy();
		tempBuildingManager.deductPop(popCost, "red");
		tempBuildingManager.deductCash(buildingCost);
	}
	//Healthcare buildings
	//*****************************************************************************************	
	void setMedBay_stats(){
		int buildingCost = 50;
		int popCost = 5;
		InvokeRepeating("repeatHappyRate", 1F, 4F);
		//tempBuildingManager.AddHappy();
		tempBuildingManager.deductPop(popCost, "blue");
		tempBuildingManager.deductCash(buildingCost);
	}
	
	
	//Putting this here to work with invokeRepeataing ... I hope
	//REALLY want to rework the happyness system! This is to chaotic
	void repeatHappyRate(){
		tempBuildingManager.AddHappy();
	}
	
	//Was trying to use -- void repeatCashIncome_5(int x){ then do tempBuildingManager.setCash(x);
	//But invokeRepeating doesn't like it when I do that :( No time to figure it out 14 hours left!
	//Set the income you get from cash buildings (make a new method if you need to add a new rate
	void repeatCashIncome_2(){
		tempBuildingManager.setCash(2);
	}
	void repeatCashIncome_5(){
		tempBuildingManager.setCash(5);
	}
	void repeatCashIncome_10(){
		tempBuildingManager.setCash(10);
	}
	void repeatCashIncome_15(){
		tempBuildingManager.setCash(15);
	}
}