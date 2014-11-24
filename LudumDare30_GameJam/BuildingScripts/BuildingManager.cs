using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {
	
	//I feel dirty soiling my clean Building manager like, it's not supposed to touch other classes :(
	//But this'll look neat so Im doing it
	//I'll need to rework where the cash stuff is handled, because other factors also deal with money income/expenditure now
	SpawnLeavingShip tempLeaveShip;
	GameObject statsPanel;
	//GameObject statsPanel; //This won't work see below
	
	//Totals
	private int population;
	private int cash;
	private int cap;
	
	//Capacity for each race
	private int blueCap;
	private int redCap;
	private int greenCap;
	private int yellowCap;
	
	//Population based on race
	private int bluePop;
	private int redPop;
	private int greenPop;
	private int yellowPop;
	
	private int happyRate;
	
	private bool wonGame;
	private bool lostGame;
	
	// Use this for initialization
	void Start () {
		population = 0;
		cash = 100;
		happyRate = 0;
		
		blueCap = 0;
		redCap = 0;
		greenCap = 0;
		yellowCap = 0;
		
		tempLeaveShip = GameObject.Find("ShipLeaveSpawner").GetComponent<SpawnLeavingShip>();
		GameObject.Find("txtMoney").guiText.text = cash.ToString();
		statsPanel = GameObject.Find("StatsMasterPanel");
		//statsPanel = GameObject.Find("DEBUG").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		population = (bluePop + redPop + greenPop + yellowPop);
		cap = (blueCap + redCap + greenCap + yellowCap);
		//if(statsPanel.gameObject.activeSelf == true){
		//This whole class uses the debug menu so I can't do this.
		//Thought it'd be a quick work around but no luck. For now this is just gonna have to say active
		if(statsPanel.gameObject.activeSelf == true){
				GameObject.Find("txtCap").guiText.text = cap.ToString();
				GameObject.Find("txtPop").guiText.text = population.ToString();
			
				GameObject.Find("RedCap_Pop").guiText.text = redPop.ToString();
				GameObject.Find("BlueCap_Pop").guiText.text = bluePop.ToString();
				GameObject.Find("GreenCap_Pop").guiText.text = greenPop.ToString();
				GameObject.Find("YellowCap_Pop").guiText.text = yellowPop.ToString();
			
				GameObject.Find("hppyVal").guiText.text = happyRate.ToString();
				GameObject.Find("txtMoney").guiText.text = cash.ToString();
			
				GameObject.Find("RedCap_Val").guiText.text = redCap.ToString();
				GameObject.Find("BlueCap_Val").guiText.text = blueCap.ToString();
				GameObject.Find("GreenCap_Val").guiText.text = greenCap.ToString();
				GameObject.Find("YellowCap_Val").guiText.text = yellowCap.ToString();			
		}
		
		//Some sloppy victory conditions
		if(population >= 200){
			Debug.Log ("YOU WON THE GAME!");
			wonGame = true;
		}
		
		if(happyRate < 0){
			Debug.Log("The refugees have rebelled, sir!");
			lostGame = true;
		}
	}
	
	//*****************************************************************************************
	//Making nice old school comment dividers cause my eyes are getting blurry! :D
	//Sets the population values per worlds race
	//*****************************************************************************************
	public void setPop(int x, string y){
		if(y == "red" && redCap != 0 && redCap >= redPop){
			redPop += x;
			//GameObject.Find("RedCap_Pop").guiText.text = redPop.ToString();
		}else{
			if(y == "blue" && blueCap != 0 && blueCap >= bluePop){
				bluePop += x;
				//GameObject.Find("BlueCap_Pop").guiText.text = bluePop.ToString();
			}else{
				if(y == "green" && greenCap != 0 && greenCap >= greenPop){
					greenPop += x;
					//GameObject.Find("GreenCap_Pop").guiText.text = greenPop.ToString();
				}else{
					if(y == "yellow" && yellowCap != 0 && yellowCap >= yellowPop){
						yellowPop += x;
						//GameObject.Find("YellowCap_Pop").guiText.text = yellowPop.ToString();
					}else{
						tempLeaveShip.SpawnNewShip();
						UnHappy25(); //Because of refugees being forced off the station you bad person you!
					}
				}
			}
		}
		
	}
	
	//% chance of an unhappy being added to overall happyness
	public void UnHappy25(){
		int rndNum;
		rndNum = (Random.Range(0, 40));
		if(rndNum == 1){
			happyRate -= 1;
		}
		//GameObject.Find("hppyVal").guiText.text = happyRate.ToString();
	}
	//*****************************************************************************************
	//*****************************************************************************************
	
	//% chance of a happy being added to overall happyness
	public void AddHappy(){
		int rndNum;
		rndNum = (Random.Range(0, 5));
		if(rndNum == 1){
			happyRate += 1;
		}
		//GameObject.Find("hppyVal").guiText.text = happyRate.ToString();
	}
	//*****************************************************************************************
	//*****************************************************************************************
	
	public void setCash(int x){
		cash += x;
		//GameObject.Find("txtMoney").guiText.text = cash.ToString();
	}
	
	//*****************************************************************************************
	//Making nice old school comment dividers cause my eyes are getting blurry! :D
	//Sets the capacity of the base for each worlds refugee
	//*****************************************************************************************
	public void setCap(int x, string y){
		if(y == "red"){
			//Debug.Log("THIS IS: " + x);
			//cap += x; //remember to move this elsewhere so that you can just add up totals
			redCap += x;
			//GameObject.Find("RedCap_Val").guiText.text = redCap.ToString();
		}	
		if(y == "blue"){
			blueCap += x;
			//GameObject.Find("BlueCap_Val").guiText.text = blueCap.ToString();
		}
		if(y == "green"){
			greenCap += x;
			//GameObject.Find("GreenCap_Val").guiText.text = greenCap.ToString();
		}
		if(y == "yellow"){
			yellowCap += x;
			//GameObject.Find("YellowCap_Val").guiText.text = yellowCap.ToString();
		}
	}
	//*****************************************************************************************
	//*****************************************************************************************

	public void deductCash(int x){
		cash -= x;
		//GameObject.Find("txtMoney").guiText.text = cash.ToString();
	}
	
	//*****************************************************************************************
	//Making nice old school comment dividers cause my eyes are getting blurry! :D
	//Man cost of running a building
	//*****************************************************************************************
	public void deductPop(int x, string y){
		if(y == "red"){
			redPop -= x;
			//GameObject.Find("RedCap_Pop").guiText.text = redPop.ToString();
		}
		if(y == "blue"){
			bluePop -= x;
			//GameObject.Find("BlueCap_Pop").guiText.text = bluePop.ToString();
		}
		if(y == "green"){
			greenPop -= x;
			//GameObject.Find("GreenCap_Pop").guiText.text = greenPop.ToString();
		}
		if(y == "yellow"){
			yellowPop -= x;
			//GameObject.Find("YellowCap_Pop").guiText.text = yellowPop.ToString();
		}
		//population -= x;
		//GameObject.Find("txtPop").guiText.text = population.ToString();
	}
	
	public void addManualPop(int x, string y){
		if(y == "red"){
			redPop += x;
			//GameObject.Find("RedCap_Pop").guiText.text = redPop.ToString();
		}
		if(y == "blue"){
			bluePop += x;
			//GameObject.Find("BlueCap_Pop").guiText.text = bluePop.ToString();
		}
		if(y == "green"){
			greenPop += x;
			//GameObject.Find("GreenCap_Pop").guiText.text = greenPop.ToString();
		}
		if(y == "yellow"){
			yellowPop += x;
			//GameObject.Find("YellowCap_Pop").guiText.text = yellowPop.ToString();
		}
		//population -= x;
		//GameObject.Find("txtPop").guiText.text = population.ToString();
	}
	
	//I should really rework these classes - Building Manager now also deals with all the global stats - not good
	// But running out of time and getting sleepy! So im using it as is for now. Need to access the Cash var
	public int getCash(){
		return cash;
	}

	public int getBluePop(){
		return bluePop;
	}
	public int getRedPop(){
		return redPop;
	}
	public int getYellowPop(){
		return yellowPop;
	}
	public int getGreenPop(){
		return greenPop;
	}
	
	//Return win/loose conditions
	public bool getWonGame(){
		return wonGame;
	}
	public bool getLostGame(){
		return lostGame;
	}
}
