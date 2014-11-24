using UnityEngine;
using System.Collections;

public class RockSpeed : MonoBehaviour {

	public Material rock_one;
	//public Material rock_two;
	//public Material rock_three;
	//public Material rock_four;
	
	// Use this for initialization
	void Start () {
		gameObject.rigidbody.drag = Random.value*5;
		
		int x = Random.Range(1,4);
		switch(x) 
		{
		case 1:
			gameObject.renderer.material = rock_one;
			break;
		case 2:
			gameObject.renderer.material = rock_one;
			break;
		case 3:
			gameObject.renderer.material = rock_one;
			break;
		case 4:
			gameObject.renderer.material = rock_one;
			break;
		default:
			gameObject.renderer.material = rock_one;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
