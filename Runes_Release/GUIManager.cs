using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	RuneSaver runesaver; //create a RuneSaver object
	GUIText scoretext;
	GUIText timertext;
	GUIText godstext;
	GUIText gameoverscore;
	GUIText gameovertitle;
	
	public GUITexture gameoverborder;
	public GUITexture gameoverbtn;
	
	int ScoreVal;
	int TimerVal;
	int BonusScoreVal;
	
	// Use this for initialization
	void Start () {
		runesaver = GameObject.Find("Main Camera").gameObject.GetComponent<RuneSaver>();
		scoretext = GameObject.Find("ScrText").gameObject.GetComponent<GUIText>();
		timertext = GameObject.Find("TmrText").gameObject.GetComponent<GUIText>();
		godstext = GameObject.Find("GodSingBonusText").gameObject.GetComponent<GUIText>();
		gameoverscore = GameObject.Find("GameOverScoreText").gameObject.GetComponent<GUIText>();
		gameovertitle = GameObject.Find("GameOverText").gameObject.GetComponent<GUIText>();
		
		gameoverbtn = GameObject.Find("GameOverButton").gameObject.GetComponent<GUITexture>();
		gameoverborder = GameObject.Find("GameOverBorder").gameObject.GetComponent<GUITexture>();
				
		scoretext.material.color = Color.white;
		timertext.material.color = Color.white;
		gameoverscore.material.color = Color.white;
		gameovertitle.material.color = Color.white;
		godstext.material.color = Color.white;
		
		TimerVal = 250;
		godstext.gameObject.SetActive(false);
		gameoverbtn.gameObject.SetActive(false);
		gameoverborder.gameObject.SetActive(false);
		gameoverscore.gameObject.SetActive(false);
		gameovertitle.gameObject.SetActive(false);
		
		InvokeRepeating("UpdateTimer", 1, 1F);
	}
	
	// Update is called once per frame
	void Update () {
		ScoreVal = runesaver.getScore();
		BonusScoreVal = runesaver.getBonus();
		scoretext.text = "CURRENT SCORE: " + (ScoreVal*10) + " + " + (BonusScoreVal*10);
		gameoverscore.text = "Your overall score is: " + (ScoreVal + BonusScoreVal)*10;
		timertext.text = TimerVal.ToString();
	}
	
	void OnGUI(){
		if (Time.time % 2 < 1) {
			if(ScoreVal == 5 || ScoreVal == 15 || ScoreVal == 20){
				godstext.gameObject.SetActive(true);
			}
		}
		else{
			godstext.gameObject.SetActive(false);	
			}
	}
	
	void UpdateTimer(){
		if(TimerVal > 0){
			TimerVal--;
		}
		else{
			gameoverbtn.gameObject.SetActive(true);
			gameoverborder.gameObject.SetActive(true);
			gameoverscore.gameObject.SetActive(true);
			gameovertitle.gameObject.SetActive(true);
		}
	}
}
