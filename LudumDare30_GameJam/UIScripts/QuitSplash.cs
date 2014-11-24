using UnityEngine;
using System.Collections;

public class QuitSplash : MonoBehaviour {
	
	GameObject obj;
	
	// Use this for initialization
	void Start () {
		obj = GameObject.Find("Holder");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		Destroy(obj);
	}
}
