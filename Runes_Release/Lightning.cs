using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {
	
	//new Transform StartPoint;
	//int NewYTrans;
	//int NewZTrans;
	//int NewXTrans;
	
	public int LightningTimer;
	
	// Use this for initialization
	void Start () {
		LightningTimer = 5;
	}
	
	// Update is called once per frame
	void Update () {
		//StartPoint = gameObject.transform.position;
		//gameObject.transform.Translate(4,4,4);
		//transform.Translate(Vector3.up * (Time.deltaTime*4), Space.World);
	}
	
	void MakeLightning(){
		transform.Translate(Vector3.up * (Time.deltaTime*4), Space.World);
	}
}
