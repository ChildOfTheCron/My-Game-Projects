using UnityEngine;
using System.Collections;

public class ShipLeaveAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, -1 * (Time.deltaTime/4), 0);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "StopShip"){
			Destroy(gameObject);
			
		}
	}
}
