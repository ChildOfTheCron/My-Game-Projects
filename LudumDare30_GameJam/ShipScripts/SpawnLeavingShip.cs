using UnityEngine;
using System.Collections;

public class SpawnLeavingShip : MonoBehaviour {

	public GameObject shipHolder;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SpawnNewShip(){
		Instantiate(shipHolder, gameObject.transform.position, gameObject.transform.rotation);
	}
}
