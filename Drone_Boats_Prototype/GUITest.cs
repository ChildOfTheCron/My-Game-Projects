using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	
	//The two Drone types available
	public GameObject Drone;
	public GameObject Drone2;
	public GameObject Drone3;
	
	//Button images are stored in here and used for the toggle buttons in the GUI
	//There must be a better way to do this but I can't think of any for now.
	//Maybe having the 2 icon1 and icon2 variables be static and have other Texture2D variables
	//point to them depending on the type required?
	//Lets try that - Static below
	public Texture2D icon1;
	public Texture2D icon2;
	public Texture2D icon3;
	//Button 1
	public Texture2D B1icon;
	//Button 2
	public Texture2D B2icon;
	//Button 3
	public Texture2D B3icon;
	//Button 4
	public Texture2D B4icon;

	
	//Need to find a way to get the vector of an object, the tranform is different - WHY THE FUCK IS THIS WORKING NOW? WHAT DID I DO LAST NIGHT?
	public Vector3 SpawnPoint1;
	public Vector3 SpawnPoint2;
	public Vector3 SpawnPoint3;
	public Vector3 SpawnPoint4;
	
	public string ESpawnPattern; //The current pattern spawn is stored here
	public Vector3 ESpawn1; //All these are enemy drone spawn points
	public Vector3 ESpawn2;
	public Vector3 ESpawn3;
	public Vector3 ESpawn4;
	
	public bool IsEnemy; //true is it's an enemy drone
	
	public int DroneSpawnBay1;
	public int DroneSpawnBay2;
	public int DroneSpawnBay3;
	public int DroneSpawnBay4;
		
	public GUIStyle fontStyle;
	
	void Start(){
		
		//Using this in SpawnDrone to see if I can spawn from a spawn point
		SpawnPoint1 = GameObject.Find("DroneSpawn1").transform.position;
		SpawnPoint2 = GameObject.Find("DroneSpawn2").transform.position;
		SpawnPoint3 = GameObject.Find("DroneSpawn3").transform.position;
		SpawnPoint4 = GameObject.Find("DroneSpawn4").transform.position;
		
		ESpawnPattern = "Pattern1";
		ESpawn1 = GameObject.Find("EnemyDroneSpawn1").transform.position;
		ESpawn2 = GameObject.Find("EnemyDroneSpawn2").transform.position;
		ESpawn3 = GameObject.Find("EnemyDroneSpawn3").transform.position;
		ESpawn4 = GameObject.Find("EnemyDroneSpawn4").transform.position;
		
		IsEnemy = false; //marker for enemy drone, initialised here
		
		DroneSpawnBay1 = 1;
		DroneSpawnBay2 = 1; //All these set the starting drone type
		DroneSpawnBay3 = 1;
		DroneSpawnBay4 = 1;
		
		//Don't need B1icon2 since you just need 1 variable to store the current desired icon image
		B1icon = icon1;
		B2icon = icon1;
		B3icon = icon1;
		B4icon = icon1;
		
		//InvokeRepeating("SpawnDrone(ESpawn2)", 2, 10.0F);
		// Above is an old and non-working function. I dont know why
		// but it won't work when calling a method with a paramenter.
		// So for a quick fix I call a generic method that then fires off
		// the existing SpawnDrone method and passes the enemy spawn as the
		// Spawnpoint.
		InvokeRepeating("SpawnEnemyDrone", 2, 10F);
		
	}
	
	//Calls the SpawnDrone function at the enemy spawn points
	void SpawnEnemyDrone(){
		switch (ESpawnPattern){
			case "Pattern1":
				SpawnDrone(ESpawn1,1);
				SpawnDrone(ESpawn2,2);
				SpawnDrone(ESpawn3,2);
				SpawnDrone(ESpawn4,1);
				ESpawnPattern = "Pattern2";
				break;
			case "Pattern2":
				SpawnDrone(ESpawn1,2);
				SpawnDrone(ESpawn2,3);
				SpawnDrone(ESpawn3,3);
				SpawnDrone(ESpawn4,2);
				ESpawnPattern = "Pattern1";
				break;
			default:
				Debug.Log("No case reached");
				break;
		}
	}
	
	void SpawnDrone(Vector3 AtSpawn, int DroneType) {
		//Yay I finally got the or operator working - God i'm dumb
		//I see if the current spawn is any of the enemy spawns, if this is the case then I set IsEnemy to true
		// After I instantiate a drone at the spawn and write some debug stuff
		
		if (ESpawn1 == AtSpawn | ESpawn2 == AtSpawn | ESpawn3 == AtSpawn | ESpawn4 == AtSpawn){
			IsEnemy = true;
			if (DroneType == 1){
				Instantiate(Drone,AtSpawn,Quaternion.identity);
			}
			else{
				if (DroneType == 2){
				Instantiate(Drone2,AtSpawn,Quaternion.identity);
				}
				else{
					if (DroneType == 3){
					Instantiate(Drone3,AtSpawn,Quaternion.identity);
					}
				}
			}
			Debug.Log("Spawning Enemy at spawn at " + AtSpawn + "IsEnemy is " + IsEnemy);
		}
		else{
			IsEnemy = false;		
			if (DroneType == 1){
				Instantiate(Drone,AtSpawn,Quaternion.identity);
			}
			else{
				if (DroneType == 2){
				Instantiate(Drone2,AtSpawn,Quaternion.identity);
				}
				else{
					if (DroneType == 3){
					Instantiate(Drone3,AtSpawn,Quaternion.identity);
					}
				}
			}
			Debug.Log("Not at enemy spawn, cannot spawn enemy" + "IsEnemy is " + IsEnemy);
		}
	}
	
	void OnGUI() {
		
		//All this should be in a case statement but because I'm working with GUI I can't get it that way atm. I'll change this but for now only 4 buttons
		// so why bother?
		//This sets the type of drone the player wants to launch, then at the bottom the Launch button
		// will launch all the drones. This is pretty sloppy code but it works
		GUI.Box (new Rect (0,Screen.height - 100,Screen.width,100), "Command",fontStyle);
		if (GUI.Button (new Rect (Screen.width/8,Screen.height - 60,100,50), B1icon)) {
				
			if (DroneSpawnBay1 == 1){ 
				//Rejigger this this bit, won't be efficient for all buttons
				//Keeping this cause I think it's a nifty example of a (very simple)
				// linked list datastructure
				//DroneSpawnBay1 = 2;
				//iconTemp = icon1;
				//icon1 = icon2;
				
				//Kay, I rejiggered it all now, all buttons below use the icon1 and icon2 as static variables
				// and reference to their contents rather than storing the contents in one button and swapping
				// it around like crazy. Because of this we no longer need iconTemp!
				DroneSpawnBay1 = 2;
				B1icon = icon2;
			}
			else{
				if (DroneSpawnBay1 == 2){
					DroneSpawnBay1 = 3;
					B1icon = icon3;
				}
				else{
					if (DroneSpawnBay1 == 3){
					DroneSpawnBay1 = 1;
					B1icon = icon1;
					}
				}
			}
		}
		
		if (GUI.Button (new Rect (Screen.width/4+40,Screen.height - 60,100,50), B2icon)) {
			print ("You clicked the Drone 2 button!");
			
			if (DroneSpawnBay2 == 1){ 
					//print ("Spawing DroneType1!");
					//SpawnDrone(SpawnPoint2,1);
					DroneSpawnBay2 = 2;
					B2icon = icon2;
			}
			else{
				if (DroneSpawnBay2 == 2){
					DroneSpawnBay2 = 3;
					B2icon = icon3;
				}
				else{
					if (DroneSpawnBay2 == 3){
					DroneSpawnBay2 = 1;
					B2icon = icon1;
					}
				}
			}
		}

		if (GUI.Button (new Rect (Screen.width/2+40,Screen.height - 60,100,50), B3icon)) {
			print ("You clicked the Drone 3 button!");
			
			if (DroneSpawnBay3 == 1){ 
					//print ("Spawing DroneType1!");
					//SpawnDrone(SpawnPoint3,1);
					DroneSpawnBay3 = 2;
					B3icon = icon2;
			}
			else{
				if (DroneSpawnBay3 == 2){
					DroneSpawnBay3 = 3;
					B3icon = icon3;
				}
				else{
					if (DroneSpawnBay3 == 3){
					DroneSpawnBay3 = 1;
					B3icon = icon1;
					}
				}
			}
		}
		
		if (GUI.Button (new Rect (Screen.width/2+160,Screen.height - 60,100,50), B4icon)) {
			print ("You clicked the Drone 4 button!");
			
			if (DroneSpawnBay4 == 1){ 
				//print ("Spawing DroneType1!");
				//SpawnDrone(SpawnPoint3,1);
				DroneSpawnBay4 = 2;
				B4icon = icon2;
			}
			else{
				if (DroneSpawnBay4 == 2){
					DroneSpawnBay4 = 3;
					B4icon = icon3;
				}
				else{
					if (DroneSpawnBay4 == 3){
					DroneSpawnBay4 = 1;
					B4icon = icon1;
					}
				}
			}
		}
		
		//This is used to launch all the friendly drones :D
		GUI.Box(new Rect(10,10,100,90), "DEBUG Loader");
		if (GUI.Button (new Rect(20,40,80,20), "LAUNCH!")) {
		
		//UPDATE: Removed the HUGE amount of if-statements here and replaced them with
		//switches
		switch (DroneSpawnBay1){
			case 1:
				SpawnDrone(SpawnPoint1,1);
				break;
			case 2:
				SpawnDrone(SpawnPoint1,2);
				break;
			case 3:
				SpawnDrone (SpawnPoint1,3);
				break;
			default:
				Debug.Log("No case reached");
				break;
		}
		
		switch (DroneSpawnBay2){
			case 1:
				SpawnDrone(SpawnPoint2,1);
				break;
			case 2:
				SpawnDrone(SpawnPoint2,2);
				break;
			case 3:
				SpawnDrone (SpawnPoint2,3);
				break;
			default:
				Debug.Log("No case reached");
				break;
		}
		
		switch (DroneSpawnBay3){
			case 1:
				SpawnDrone(SpawnPoint3,1);
				break;
			case 2:
				SpawnDrone(SpawnPoint3,2);
				break;
			case 3:
				SpawnDrone (SpawnPoint3,3);
				break;
			default:
				Debug.Log("No case reached");
				break;
		}		
		
		switch (DroneSpawnBay4){
			case 1:
				SpawnDrone(SpawnPoint4,1);
				break;
			case 2:
				SpawnDrone(SpawnPoint4,2);
				break;
			case 3:
				SpawnDrone (SpawnPoint4,3);
				break;
		default:
			Debug.Log("No case reached");
			break;
		}
		
	}	

	//Don't need to use this timer anymore, I use InvokeRepeating() instead
	//IEnumerator SpawnEnemyWait(int Secs){
	//	yield return new WaitForSeconds(Secs);
	//}
	}
	
	//This is used to launch all the friendly drones :D
	public void LaunchDrones(){
		
		switch (DroneSpawnBay1){
			case 1:
				SpawnDrone(SpawnPoint1,1);
				break;
			case 2:
				SpawnDrone(SpawnPoint1,2);
				break;
			case 3:
				SpawnDrone (SpawnPoint1,3);
				break;
			default:
				Debug.Log("No case reached");
				break;
		}
		
		switch (DroneSpawnBay2){
			case 1:
				SpawnDrone(SpawnPoint2,1);
				break;
			case 2:
				SpawnDrone(SpawnPoint2,2);
				break;
			case 3:
				SpawnDrone (SpawnPoint2,3);
				break;
			default:
				Debug.Log("No case reached");
				break;
		}
		
		switch (DroneSpawnBay3){
			case 1:
				SpawnDrone(SpawnPoint3,1);
				break;
			case 2:
				SpawnDrone(SpawnPoint3,2);
				break;
			case 3:
				SpawnDrone (SpawnPoint3,3);
				break;
			default:
				Debug.Log("No case reached");
				break;
		}		
		
		switch (DroneSpawnBay4){
			case 1:
				SpawnDrone(SpawnPoint4,1);
				break;
			case 2:
				SpawnDrone(SpawnPoint4,2);
				break;
			case 3:
				SpawnDrone (SpawnPoint4,3);
				break;
		default:
			Debug.Log("No case reached");
			break;
		}
		
	}
}