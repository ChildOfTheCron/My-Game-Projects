using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {
	
	private bool check;
	
	// Use this for initialization
	void Start () {
		check = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(check == false){
			transform.Translate(Vector3.up * Time.deltaTime*4);
			check = true;
		}
	}
}
