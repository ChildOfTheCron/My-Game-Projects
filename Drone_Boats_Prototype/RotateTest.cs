using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour {
	
	GUITest currentGUI; //create an instance of a GUITest script to store the current IsEnemy value
	bool aiEnemy; //marks which AI needs to be triggered - friendly drone or enemy AI one
	
	//For future reference even a particle is a GameObject and NOT a particle system when using a prefab.
	public GameObject explosion;
	public GameObject ProbeRedOne;
	
	// Use this for initialization
	void Start () {
	//Gets the IsEnemy bool from the GUITest script (or current instance there of?) and stores it in currentGUI
	//This is then used to trigger which AI (direction) to send the drones in
		
		currentGUI = GameObject.Find("Main Camera").gameObject.GetComponent<GUITest>();
		Debug.Log (currentGUI.IsEnemy);
		
		if (currentGUI.IsEnemy == true){
			aiEnemy = true;
		}
		else {
			if (currentGUI.IsEnemy == false){
				aiEnemy = false;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//If you add or subtract to a value every frame chances are you should multiply with Time.deltaTime.
		//When you multiply with Time.deltaTime you essentially express: I want to move this object 10 meters per second
		//instead of 10 meters per frame. This is not only good because your game will run the same independent of the 
		//frame rate but also because the units used for the motion are easy to understand. (10 meters per second) 
		
		//Sets the pathfinding - which is a strong word but I send the drones in a direction depending on the value of aiEnemy
		if (aiEnemy == true){
			transform.Translate(Random.Range(-1 * Time.deltaTime, 1 * Time.deltaTime), Random.Range(-1 * Time.deltaTime, 1 * Time.deltaTime),Random.Range(0 * Time.deltaTime, -40 * Time.deltaTime));
		}
		else{
			if (aiEnemy == false){
				transform.Translate(Random.Range(-1 * Time.deltaTime, 1 * Time.deltaTime), Random.Range(-1 * Time.deltaTime, 1 * Time.deltaTime),Random.Range(0 * Time.deltaTime, 40 * Time.deltaTime));
			}
		}
	
	}
	
	//This allows the drones to be destroyed if they run into any other objects
	void OnTriggerEnter(Collider other){
		if(other.name == gameObject.name){
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
			Debug.Log("COLLIDED WITH " + other.name);
			//Debug.Log("GAME OBJECT IS " + ProbeRedOne);
		}
		else{
			if(other.name == "ProbeRedOne(Clone)" & gameObject.name == "DroneType2(Clone)"){
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
			}
			else{
				if(other.name == "DroneType2(Clone)" & gameObject.name == "DroneType3(Clone)"){
				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(gameObject);
				}
				else{
					if(other.name == "DroneType3(Clone)" & gameObject.name == "ProbeRedOne(Clone)"){
					Instantiate(explosion, transform.position, transform.rotation);
					Destroy(gameObject);
					}
				}
			}
		}
	}
	
	//Just for testing purposes
	void OnMouseDown(){
		Destroy(gameObject);
	}
}
