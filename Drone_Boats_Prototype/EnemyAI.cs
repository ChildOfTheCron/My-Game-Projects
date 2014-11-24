using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//If you add or subtract to a value every frame chances are you should multiply with Time.deltaTime.
		//When you multiply with Time.deltaTime you essentially express: I want to move this object 10 meters per second
		//instead of 10 meters per frame. This is not only good because your game will run the same independent of the 
		//frame rate but also because the units used for the motion are easy to understand. (10 meters per second) 
		
		if(gameObject.name == "SpaceStation"){
		//The 0.2F is a Floating number, if you simply write 0.2 it will try to store a double (0.2) to a floating
		// doing this will cause a compiler error
			transform.Rotate(0, 0.2F, 0);
		}
		
		if(gameObject.name == "DroneSpawner"){
		//The 0.2F is a Floating number, if you simply write 0.2 it will try to store a double (0.2) to a floating
		// doing this will cause a compiler error
			transform.Rotate(0, Random.Range(-10F * Time.deltaTime, 10 * Time.deltaTime), 0);
		}
	}
}
