using UnityEngine;
using System.Collections;

public class SpawnRock : MonoBehaviour {

	public GameObject Rock_One;
	
	// Use this for initialization
	void Start () {
		
		InvokeRepeating("spawnRocks", 2F, 0.3F);
		//spawnRocks();
		//Vector3 position = new Vector3(Random.Range(-3.5F, 3.5F), 2F, 2F);
		//Instantiate(Rock_One, position, Quaternion.identity);
		//Instantiate(Rock_One, new Vector3(2F, 2F, 2F), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void spawnRocks(){
		Vector3 position = new Vector3(Random.Range(-2F, 3F), 2F, 2F);
		Instantiate(Rock_One, position, Quaternion.identity);
	}
}
