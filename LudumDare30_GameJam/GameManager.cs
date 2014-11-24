using UnityEngine;
using System.Collections;

//At the moment all this does is check to see if the player won or lost the game
//I want to add the happyness stuff here
//Also want to add food/sickness etc
public class GameManager : MonoBehaviour {
	
	private BuildingManager tempBuildingManager;
	
	public GameObject LosePanelHolder;
	public GameObject WinPanelHolder;
	
	bool drawnWinPanel;
	bool drawnLostPanel;
	
	// Use this for initialization
	void Start () {
		tempBuildingManager = GameObject.Find("Main Camera").GetComponent<BuildingManager>();
		drawnWinPanel = false;
		drawnLostPanel = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(tempBuildingManager.getWonGame() == true && drawnWinPanel == false){
			drawWinPanel();
		}else{
			if(tempBuildingManager.getLostGame() == true && drawnLostPanel == false){
				drawLosePanel();
			}
		}
	
	}
	
	void drawWinPanel(){
		Instantiate(WinPanelHolder, new Vector3(0.5F,0.5F,0), gameObject.transform.rotation);
		drawnWinPanel = true;
	}
	void drawLosePanel(){
		Instantiate(LosePanelHolder, new Vector3(0.5F,0.5F,0), gameObject.transform.rotation);
		drawnLostPanel = true;
	}
	
	
}
