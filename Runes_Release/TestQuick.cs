using UnityEngine;
using System.Collections;

public class TestQuick : MonoBehaviour {

	public int Type;	
	
	// Use this for initialization
	void Start () {
	Type = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		meh();
		Debug.Log("Test TYPE IS:" + Type);
	}
	
	void meh(){
		int randoms;
		randoms = Random.Range(1, 8);
		Debug.Log("Random Gnenerated number is: " + randoms);
		Type = Type + randoms;
	}
}
