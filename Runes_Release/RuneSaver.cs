using UnityEngine;
using System.Collections;

public class RuneSaver : MonoBehaviour {
	
	public string[] RuneSet;
	public int count;
	public bool isMatch;
	//public int lastRuneCheck;
	
	public bool CheckArrayToggle;
	
	Light godlight;
	bool MakeGodLight;
	
	int ScoreKeeper;
	int BonusScore;
	
	//Added on the 08/05/2013
	//This is used to log the current rune being added
	//This value is then sent to the rune and stored there
	//This means when the rune needs to be removed it can send a
	//RemoveMe request by using it's equavalent of RemCount (see RuneID in RndRune)
	public int RemCount;
	
	// Use this for initialization
	void Start () {
		count = 0;
		isMatch = false;
		RuneSet = new string[3];
		CheckArrayToggle = false;
		
		//lastRuneCheck = 0;
		
		godlight = GameObject.Find("GodLight").gameObject.GetComponent<Light>();
		MakeGodLight = false;
		
	}
	
	// Update is called once per frame
	//01/05/2013
	//***UPDATE I removed the count = 0 as is was resetting things again which means the multiple runes could be selecting as count would be 0 far to often
	// This means though that there is no toggle when CheckArray() is being called, which results in it spamming the player with + score
	// I also changed count > 2 to Count == 3, cause we want to fire the CheckArray off when it's full and needs to be checked.
	// Having > 2 means it'll be called anytime its greater than 2 which is dumb
	// I have removed  the CheckArray toggle from the Update in this class - no point faffing about with a toggle in the Update as
	// setting a toggle to True in the Update will cause it to be set to true constantly even if set to false elsewhere (Duh I know blonde moment by me)
	// I set the toggle to check the array in the Runes script (RND rune) even though I'd rather not for cohesion purposes
	// This toggle will be set to true ONLY if the current rune clicked is the last rune (ie count == 3)
	void Update () {
		
		FadeGodLight();
		
		if(CheckArrayToggle == true){
			Debug.Log("Reached the CheckArray call in update");
			CheckArray();
		}
	}
	
	public void AddToArray(string x){
		
		if(RuneSet[0] == null){
			RuneSet[0] = x;
			RemCount = 0;
			count = 1;
		}
		else{
			if(RuneSet[1] == null){
				RuneSet[1] = x;
				RemCount = 1;
				count = 2;
			}
			else{
				if(RuneSet[2] == null){
					RuneSet[2] = x;
					RemCount = 2;
					count = 3;
				}
			}
		}
		
		//RuneSet[count] = x;
		//RemCount = count; //Stores the current array slot that the current rune is in
		
		//if(count < 3){
		//	count++;
		//	Debug.Log(count);
		//}
		//else{
		//	Debug.Log("ARRAY IS FULL! Run Check!");
		//}
	}
	
	void CheckArray(){
		string tempStr;
		tempStr = RuneSet[0];
		Debug.Log ("tempStr is: " + tempStr);
		Debug.Log ("RuneSet[0]: " + RuneSet[0]);
		Debug.Log ("RuneSet[1]: " + RuneSet[1]);
		Debug.Log ("RuneSet[2]: " + RuneSet[2]);
		//for(int i = 0; i < 3; i++){
		//	Debug.Log("RuneSet[i] is: " + RuneSet[i]);
		//	if(tempStr == RuneSet[i]){
		//		isMatch = true;
		//	}
		//	else{
		//		isMatch = false;
		//		MakeGodLight = false;
		//	}
		//	CheckArrayToggle = false;
		//}
		
		if(RuneSet[0] == tempStr & RuneSet[1] == tempStr & RuneSet[2] == tempStr){
			isMatch = true;
		}
		else{
			isMatch = false;
			MakeGodLight = false;
			BonusScore = 0;
		}
		
		CheckArrayToggle = false;
		
		if(isMatch == true){
			ScoreKeeper++;
			if(ScoreKeeper == 5 || ScoreKeeper == 15 || ScoreKeeper == 20){
				BonusScore = BonusScore + ScoreKeeper;
				MakeGodLight = true;
			}
			else{
				//MakeGodLight = false;
				}
			}
	}
	
	//Added on 08/05/2013
	//This is called by RndRune to remove the current Rune in the array
	//y will be recieved from RuneID which is given it's value by whatever
	//The value of RemRune is AT THE CURRENT RUNES TIME
	//It is then stored in the actual Rune so every rune will have it's RuneID
	//And can be used to remove the Rune from its spot in the array
	public void RemoveRune(int y){
		RuneSet[y] = null;
	}
	
	//Starting work on removing each array element seperatly
	public void RemoveFromArray(string x){
		if(count == 2){
			RuneSet[0] = null;
		}
	}
	
	//public void RemoveFromArray(){
	//This resets the whole array
	public void RemoveFromArray(){
		for(int i = 0; i < 3; i++){
			RuneSet[i] = null;
			count = 0; //**NEW on 09/04/2013
			isMatch = false; //Added on 18/04/2013
			CheckArrayToggle = false;
			//lastRuneCheck = 3;
		}
	}
	
	
	//Bunch of Get / Set methods
	public string getRuneThreeValue(){
			return RuneSet[2];
	}
	public string getRuneTwoValue(){
			return RuneSet[1];
	}
	public string getRuneOneValue(){
			return RuneSet[0];
	}
	
	public bool getMatchBool(){
		return isMatch;
	}
	
	public int getScore(){
		return ScoreKeeper;
	}
	
	public int getBonus(){
		return BonusScore;
	}
	
	
	
	//Bah friends are calling me so I have to call it quits for now
	//Quickly so I dont forget
	//I added this in fast as its a pretty neat fade effect
	//It'll activate if the player activates a song (makes the god sing)
	//It'll fade in and stay there unless the player messes up and missmatches
	//Then the light will fade until the player makes the gods sing again
	void FadeGodLight(){
		if(MakeGodLight == true & godlight.range < 20){
			godlight.range = godlight.range + 2 * Time.deltaTime;
		}
		else{
			if(MakeGodLight == false & godlight.range > 0){
				godlight.range = godlight.range - 2 * Time.deltaTime;
			}
		}
	}
}
