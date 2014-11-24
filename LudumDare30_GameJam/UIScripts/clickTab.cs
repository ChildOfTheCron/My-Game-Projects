using UnityEngine;
using System.Collections;

public class clickTab : MonoBehaviour {
	
	public GameObject tempHolder;
	//Hiding a bug - this is some serious BS. Gotta setactive to ture via the parent but for the life of me I cant get it working
	//I have done this kind of panel control is SO MANY OTHER langauges/IDEs. Why does Unity make it such a ball ache?
	//Will try and fix it later, I have other things to do
	GameObject tempHider;
	
	// Use this for initialization
	void Start () {
		tempHider = GameObject.Find("BugHiderPanel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		if(tempHolder.gameObject.activeSelf == true){
			tempHolder.gameObject.SetActive(false);
			tempHider.gameObject.SetActive(false);
		}
		else{
			tempHolder.gameObject.SetActive(true);
		}
	}
}
