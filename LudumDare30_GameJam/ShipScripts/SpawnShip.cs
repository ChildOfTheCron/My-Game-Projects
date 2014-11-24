using UnityEngine;
using System.Collections;

public class SpawnShip : MonoBehaviour {

	public GameObject shipHolder1;
	public GameObject shipHolder2;
	public GameObject shipHolder3;
	public GameObject shipHolder4;
	
	//Random rndShip = new Random();
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnNewShip", 4, 4F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void SpawnNewShip(){
		int rndShip;
		int rndSpawnChance; //Going to try and make them more tattered so they dont all come running at once!
		rndShip = (Random.Range(0, 4));
		rndSpawnChance = (Random.Range(0, 6));
		
		if(rndSpawnChance == 3){
			switch (rndShip) {
				case 0: Instantiate(shipHolder1, gameObject.transform.position, gameObject.transform.rotation);
	            break;
	        	case 1: Instantiate(shipHolder2, gameObject.transform.position, gameObject.transform.rotation);
	            break;
				case 2: Instantiate(shipHolder3, gameObject.transform.position, gameObject.transform.rotation);
	            break;
				case 3: Instantiate(shipHolder4, gameObject.transform.position, gameObject.transform.rotation);
				break;
				default: Instantiate(shipHolder1, gameObject.transform.position, gameObject.transform.rotation);
	            break;
			}
		}
		
		//Instantiate(shipHolder, gameObject.transform.position, gameObject.transform.rotation);
	}
}
