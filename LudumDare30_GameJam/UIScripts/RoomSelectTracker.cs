using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomSelectTracker : MonoBehaviour {
	//Using this class to track which building the user has selected
	//And update the selection visually
	//I dont want to jam this into the Building_Instance class since this is a visual thing
	//and Building_instnace doe sneough as it is in terms of val updates
	private List<GameObject> list;
	//private OnRoomClick room;
	
	// Use this for initialization
	void Start () {
		//list = new List<GameObject>(); <- Can't call this here because OnRoomClick starts
		//first for some reason. Meaning this will stay null and we'd get nullpointers :(
		//Need to read up on a better way of doing this.
	}
	
	void Awake(){
		list = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	
	public void addRoom(GameObject x){
		//for (int i = 0; i < list.Count; i++){
			//if(list[i] == null){
				//list.Insert(i, x); ,-- will append
			//	list.RemoveAt(i);
			//	list.Insert(i, x);
			//	Debug.Log("room added to an empty slot of the list");
			//}else{
				list.Add(x);
				Debug.Log("room added to the end of the list");
			//}
		//}	
			//list.Add(x);
			//Debug.Log("room added to the list");
	}
	
	public void updateList(GameObject x){
		for (int i = 0; i < list.Count; i++){
			if(list[i] == null){
				list.RemoveAt(i);
				list.Insert(i, x);
				Debug.Log("room added to an empty slot of the list");
			}else{
				Debug.Log("Skipped updateList for some reason");
				//list.Add(x); <--DONT UNCOmMENT! WILL CRASH UNITY! D:
			}
		}
	}
	
	public void setUnselectedVisual(){
		foreach (GameObject room in list){
			if(room != null){
				if(room.name != "RoomBlock"){
					room.GetComponent<OnRoomClickUpdate>().setNoHalo();
				}else{
					room.GetComponent<OnRoomClick>().setNoHalo();
				}
			}
		}
		
		//foreach (GameObject room in list){
			//if(room.name == "RoomBlock"){
				//Debug.Log(list[5]);
			//}
		//}
		
	}
	
	public void quickDebug(){
		for (int i = 0; i < list.Count; i++){
		Debug.Log("quickDebug is " + list[i]);
		}
	}
}
