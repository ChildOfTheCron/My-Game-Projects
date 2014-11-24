using UnityEngine;
using System.Collections;

public class ActiveChild : MonoBehaviour {
	
	Transform trns;
	
	// Use this for initialization
	void Start () {
		trns = gameObject.transform.FindChild("Sphere");
		Debug.Log("Is a " + trns);	
		trns.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
