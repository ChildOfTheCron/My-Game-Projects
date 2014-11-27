using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Vector3.left * Time.deltaTime*2);
		transform.Rotate(0,0,Time.deltaTime*160);
	}
}
