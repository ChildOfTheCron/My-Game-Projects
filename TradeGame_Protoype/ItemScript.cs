using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	public int itemVal;
	public string itemCat;
	Texture2D itemSkin;
	
	int randomNum;
	
	bool isSelected;
	
	// Use this for initialization
	void Start () {
		
		//For spawnItem() see below:
		//The reason for that is that Resources.Load doesn't know what it is you will be asking for at compile time,
		//so it uses UnityEngine.
		//Object as a return type, and boxes it up.
		//Then mainTexture sees an Object, not realizing it internally is a Texture2D and cannot convert.
		//Using the as will cast the Return from Load into a Texture2D so that mainTexture can be assigned properly. 
		//itemSkin = Resources.Load("My_Textures/I_C_Apple",  typeof(Texture2D)) as Texture2D;
		spawnItem();
		isSelected = false;
		//moved below to Update()
		//gameObject.GetComponent<GUITexture>().texture = itemSkin;
		
	}
	
	// Update is called once per frame
	void Update () {
		//Moved this from Start .. needs to changed based on successful trade in TradeManager
		gameObject.GetComponent<GUITexture>().texture = itemSkin;
	}
	
	void spawnItem(){
		randomNum = Random.Range(0, 7);
		
		switch (randomNum)
		{
			case 0:
				itemSkin = Resources.Load("My_Textures/I_C_Apple",  typeof(Texture2D)) as Texture2D;
				itemVal = 10;
			break;
			case 1:
				itemSkin = Resources.Load("My_Textures/I_C_Carrot",  typeof(Texture2D)) as Texture2D;
				itemVal = 10;
			break;
			case 2:
				itemSkin = Resources.Load("My_Textures/I_C_Cheese",  typeof(Texture2D)) as Texture2D;
				itemVal = 15;
			break;
			case 3:
				itemSkin = Resources.Load("My_Textures/I_C_Bread",  typeof(Texture2D)) as Texture2D;
				itemVal = 15;
			break;
			case 4:
				itemSkin = Resources.Load("My_Textures/I_C_Banana",  typeof(Texture2D)) as Texture2D;
				itemVal = 10;
			break;
			case 5:
				itemSkin = Resources.Load("My_Textures/I_C_Cherry",  typeof(Texture2D)) as Texture2D;
				itemVal = 10;
			break;
			case 6:
				itemSkin = Resources.Load("My_Textures/I_C_Egg",  typeof(Texture2D)) as Texture2D;
				itemVal = 10;
			break;
			case 7:
				itemSkin = Resources.Load("My_Textures/I_C_Fish",  typeof(Texture2D)) as Texture2D;
				itemVal = 15;
			break;
			default:
			Debug.Log("Default case");
			break;
		}
	}
	
	void OnMouseDown(){
		//Making a toggle! Yaaaay
		if(isSelected == false){
			isSelected = true;
			Debug.Log (isSelected);
		}
		else{
			isSelected = false;
			Debug.Log (isSelected);
		}
	}
	
	public int GetItemVal(){
		return itemVal;
	}
	
	public int SetItemVal(int x){
		itemVal = x;
		return itemVal;
	}
	
	public string GetItemCat(){
		return itemCat;
	}
	
	public bool GetSelectState(){
		return isSelected;
	}
	
	public bool SetSelectedState(bool x){
		isSelected = x;
		return isSelected;
	}
	
	//This is used to store the skin for the item in the array(WIP)
	public Texture2D GetItemSkin(){
		return itemSkin;
	}
	
	public Texture2D SetItemSkin(Texture2D x){
		itemSkin = x;
		return itemSkin;
	}
	
	//Should be using a class for item, not a whole load of variables
	//But that'll do pig ... that'll do
	//public class itemClass{
    //	itemSkin {get;set;}
    //	itemVale {get;set;}
	//}
}
