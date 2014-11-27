using UnityEngine;
using System.Collections;

public class houseSelectBuilding : MonoBehaviour {
	
	GameObject tempRoomHolder;
	Texture itemTexture;
	public GameObject mkQuad;
	
	// Use this for initialization
	void Start () {
		itemTexture = Resources.Load("Textures/slug",  typeof(Texture)) as Texture;
		
		//tempRoomHolder = GameObject.Find("Main Camera").GetComponent<houseRoomOverlord>().getCurrentRoom();
		//downTexture = Resources.Load ("My_Textures/DudePL", typeof(Texture)) as Texture;
	}
	
	// Update is called once per frame
	void Update () {
		//A quick test
		GameObject clone;
		clone = Instantiate(mkQuad, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,1.0f)), Quaternion.identity) as GameObject;
	}
	
	void OnMouseDown() {
		//tempRoomHolder = GameObject.Find("Main Camera").GetComponent<houseRoomOverlord>().getCurrentRoom();
		//tempRoomHolder.GetComponent<Renderer>().material.SetTexture("_MainTex", itemTexture);
		//GameObject.Find("BuildingPanel").gameObject.SetActive(false);
		
		//A quick test
		//GameObject clone;
		//clone = Instantiate(mkQuad, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10.0f)), Quaternion.identity) as GameObject; 
	}
}
