using UnityEngine;
using System.Collections;

public class SpawnGovShip : MonoBehaviour {

	public GameObject shipHolder;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnNewShip", 6F, 40F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SpawnNewShip(){
		Instantiate(shipHolder, gameObject.transform.position, gameObject.transform.rotation);
	}
}
