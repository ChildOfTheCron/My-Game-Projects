using UnityEngine;
using System.Collections;

public class CodeholderTEST : MonoBehaviour {
	
	//Texture2D testLoad;
	
	//Added on - 22/03/2014
	public class Room{
		private int itemVal;
		private Texture2D itemSkin;
		private bool itemSelect;
		
		public Room(int val, Texture2D tex, bool state){
			itemVal = val;
			itemSkin = tex;
			itemSelect = state;
		}
	}
	
	// Use this for initialization
	void Start () {
		//testLoad = Resources.Load("Textures/slug",  typeof(Texture2D)) as Texture2D;
		Room testroom = new Room(1, (Resources.Load("Textures/slug",  typeof(Texture2D)) as Texture2D), false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
