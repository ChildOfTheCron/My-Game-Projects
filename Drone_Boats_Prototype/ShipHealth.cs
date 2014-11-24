using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {
	//GameObject.Find("EnemyDroneSpawn1").transform.position;
	public int Health;
	
	public GameObject DeadCarrier;
	
	// Use this for initialization
	void Start () {
	
		Health = 200;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Health == 0){
			Destroy(gameObject);
			Instantiate(DeadCarrier, transform.position, transform.rotation);
		}
	}
	
	void HurtShip(){
	}
	
	//This allows the drones to be destroyed if they run into any other objects
	void OnTriggerEnter(Collider other){
			Health = Health-25;
			Debug.Log ("Health variable is: " + Health);
	}
}
