using UnityEngine;
using System.Collections;

//Ok - Don't try to use the dumb RuneType variable to compare different objects in an array.
//For some reason this is reset to 0 every freaken time a OnMouseDown() is preformed (after 2 secs) - I think it's because the click event is run, even
// if it is being frozen by the yield function.
//I'm going around in circles trying to figure it out BUT
// There may be a work around!
// Instead get the current gameobject (cause no matter what it's cant be 0 or null).
// This seems to be working and will do well.
// Get the gameobject and add it to the array
// Go change the array to a String one and not an int one
// See if that works cause it's been 4 hours and im about to just say "Fuck comparing vaiables via array to be fancy - lets just get really drunk instead"
// **Update! - IT WORKS! Now just go to RuneSaver and run through array comparing!

public class RndRune : MonoBehaviour {
	
	public GameObject Rune1;
	public GameObject Rune2;
	public GameObject Rune3;
	public GameObject Rune4;
	public GameObject Rune5;
	public GameObject Rune6;
	public GameObject Rune7;
	public GameObject Rune8;
	public GameObject ParticleEffect;
	
	Transform aura;
	
	string RuneType;
	int DeactivateRuneToggle;
	
	int RuneID;
		
	public RuneSaver runesaver; //create a RuneSaver object
	public SoundManager soundmanager; //create a sound manger object
	
	public bool Freeze;
	public bool Isclicked;
	public bool IsStored; //Used to see if this specific rune has been stored in the array
	bool MyParticleActive; //Checks to see if the active particle is already running
	bool ToggleAura; //used as a toggle in ActivateAura();
	bool ToggleSound; //Used to toggle the sound to play once since Update() is being a little bitch and I can't just use soundmanager.PlayRockSound(); in there
	bool quicktoggle;
	bool ArrayCleared;
	
	// Use this for initialization
	void Start () {
											
		//Initualizing my bools, yo!
		Isclicked = false;
		Freeze = false;
		IsStored = false;
		MyParticleActive = false;
		ToggleAura = true;
		ToggleSound = false;
		quicktoggle = false; //Toggles the ActivateAura so it doesnt spam loads due to being in the update
		ArrayCleared = true;

		runesaver = GameObject.Find("Main Camera").gameObject.GetComponent<RuneSaver>();
		soundmanager = GameObject.Find("Main Camera").gameObject.GetComponent<SoundManager>();
		
		SetRuneName();
		
		//see mouseclick
		InvokeRepeating("GetNewRune", 2, 5F);
	}
	
	 //Update is called once per frame
	void Update () {
		//Note to self:
		// Don't get confused between the yield wait and the Update()
		// The CoRoutine below is called every time, the fact that what you
		// See only happens after some time is caused by your coroutine
		// So the runesaver.getRuneThreeValue() == null will be true all the time
		// until it isnt but by then the StartCoroutine has already started
		// Maybe try adding another one that has a set time before resetting?
		// That way if runesaver.getRuneThreeValue() == null that one will be called
		// else the other one is ... hmm... but that means the first Coroutine
		// will always be done. Need to think about this.
		// Next time make a proper design and stick to it!
		// 		UPDATE - I fixed this now, easy if you think things through
		// 		Check OnMouseClick/Down/ what ever it's called
		// 		I changed it to an Enumerator with it's own wait yield
		//		Not Perfect yet see OnMouse comments for fix methods
		if(Isclicked == true && runesaver.getRuneThreeValue() != null){			
			transform.Translate(0,Random.Range(-2 * Time.deltaTime, 2 * Time.deltaTime),0);
			MakeParticle();
			PlayActiveSound();
			StartCoroutine(DeactivateRunes());
			GetNewRune(); // Added in to make it so once old runes are done being selected new ones spawn quickly
		}

	}
	
	//This gets the 5th char from the gameobjects name.
	//Because all game object are named like: Stone#(clone)... this means that
	// the 5th char will always be the stones number. Thats the important part
	// of the name. We grab that, add it to a string and then rename the gameobject
	// to Stone(5thchar).
	//This results in Stone# without those pesky (clones) being in the way :D
	void SetRuneName(){
		RuneType = gameObject.name[5].ToString();
		gameObject.name = "Stone" + RuneType;
		Debug.Log("gameObject.name: " + gameObject.name);
	}
	
	void GetNewRune(){
		// Ok all this function does now is destroy and create different rune types
		// On the spot where a different rune was
		// It spawns randomly :)
		if (Freeze == false){
			
			int rnd;
		
			rnd = Random.Range(1, 8);
		//To fix the match making fucking up I need to find a way to remove (clone)
		//Instantiate doesn't just instantiate - it makes a clone of the original object
			switch (rnd){
				case 1:
					//RuneType = 1;
					Instantiate(Rune1, transform.position, transform.rotation);
					//gameObject.name = "Stone111";
					Destroy(gameObject);
					//Debug.Log("gameObject.name: " + gameObject.name);
					break;
				case 2:
					//RuneType = 2;
					Instantiate(Rune2, transform.position, transform.rotation);
					//gameObject.name = "Stone222";
					Destroy(gameObject);
					//Debug.Log("gameObject.name: " + gameObject.name);
					break;
				case 3:
					//RuneType = 3;
					Instantiate(Rune3, transform.position, transform.rotation);
					Destroy(gameObject);
					break;
				case 4:
					//RuneType = 4;
					Instantiate(Rune4, transform.position, transform.rotation);
					Destroy(gameObject);
					break;
				case 5:
					//RuneType = 5;
					Instantiate(Rune5, transform.position, transform.rotation);
					Destroy(gameObject);
					break;
				case 6:
					//RuneType = 6;
					Instantiate(Rune6, transform.position, transform.rotation);
					Destroy(gameObject);
					break;
				case 7:
					//RuneType = 7;
					Instantiate(Rune7, transform.position, transform.rotation);
					Destroy(gameObject);
					break;
				case 8:
					//RuneType = 8;
					Instantiate(Rune8, transform.position, transform.rotation);
					Destroy(gameObject);
					break;
				default:
					Debug.Log("No Case Reached");
					break;
				//case 1:
					//RuneType = 1;
					//Instantiate(Rune1, transform.position, transform.rotation);
					//Destroy(gameObject);
					//Rune1.name = "Stone1";
					//break;
			
			}
		}
	}
	
	IEnumerator OnMouseDown(){
	if(MyParticleActive == false){
		//if(runesaver.count < 3 & IsStored == false){ //count could always be < 3
		if(runesaver.getRuneThreeValue() == null & IsStored == false & ArrayCleared == true){
		//if(IsStored == false){
			//Why is this 0 all the time?! - See invokerepeating at the Start() - Causes to many RNDs
			//This might be tied to the IEnumerator as it is only zero in this func for some reason
			//Debug.Log("OnMouseDown - RuneTypes random number is: " + RuneType);
			//RuneType is set to zero in this method because Freeze is set to true, but this freeze
			// Doesn't step the above invokerepeating method
			// This means that even though it doesn't show - the rune is still being destroyed?
			// RuneType is only ever set to zero if this event triggers ...
			Freeze = true;
			Isclicked = true;
			runesaver.AddToArray(gameObject.name);
			//Debug.Log("gameObject.name: " + gameObject.name);
			IsStored = true;
			MyParticleActive = true;
			ActivateAura();
			ToggleSound = true;
			RuneID = runesaver.RemCount;
			//Debug.Log("RUNESAVER COUNT IS: " + runesaver.count);
			if(runesaver.count == 3){
				runesaver.CheckArrayToggle = true;
			}
			quicktoggle = true;
			ArrayCleared = false;
			//In here - add a link to the RuneSaver accessing a
			yield return new WaitForSeconds(5F);
			
			//It's no good resetting the whole array per value
			// Since the runes could deactivate in a desync way
			// Meaning that while one rune is shown as active
			// It's value has been reset by a different Rune resetting the
			// whole array
			// You need to find the current rune in the array and remove it
			// that way runes will be able to remove themselves
			// I sure hope this doesn't fuck up the other runes in the array
			// 		Update: This is gonna fuck up the array as I dont keep
			// 		track of the runes in the array once they are in
			//		I'm gonna have to add an index or something to RuneSavers
			// 		AddToArray code to keep track then other here not reset the array
			// 		Just remove the rune that needs to go
			//		Might have to rewrite the iterators in RunSaver also
			//		Since they just loop through by count and don't check for null values
			//		Uurgh lame - done for today spend 2 hours already
			//		It'll be quick and easy he said
			// 		Just a "match three" game he said
			// 		Should have designed this properly
			if(runesaver.getRuneThreeValue() == null){
				Freeze = false;
				Isclicked = false; //Added 18/04/2013
				IsStored = false;
					if(quicktoggle == true){
						ActivateAura();
						quicktoggle = false;
						//runesaver.RemoveFromArray(); //ResetsArray - name is misleading
						runesaver.RemoveRune(RuneID);
					}
			}
		}
	}
	else{
		if(MyParticleActive == true & runesaver.getRuneThreeValue() == null){
		Freeze = false;
		Isclicked = false; //Added 18/04/2013
		IsStored = false;
		if(quicktoggle == true){
			ActivateAura();
			quicktoggle = false;
			//runesaver.RemoveFromArray(); //ResetsArray - name is misleading
			runesaver.RemoveRune(RuneID);
		}	
		}
		}
	}
	
	IEnumerator DeactivateRunes(){
		yield return new WaitForSeconds(4F);
		//Debug.Log("BLAH BLAH");
		Freeze = false;
		Isclicked = false; //Added 18/04/2013
		IsStored = false;
		if(quicktoggle == true){
			ActivateAura();
			quicktoggle = false;
			runesaver.RemoveFromArray();
		}
	}
	
	void MakeParticle(){
		if(runesaver.getMatchBool() == true){
			//Changes the x axis of the particle effect object once its instatianted.
			//Cause fuck working with the inspector, hassles man!
			Quaternion tempRotation = Quaternion.Euler(-90, 0, 0);
			if(MyParticleActive == true){
				Instantiate(ParticleEffect, transform.position, tempRotation);
				MyParticleActive = false;
				soundmanager.PlayChimeSound();
				GetGodSound();
			}
		}
	}
	
	//This searches for the child prefab (ActiveChild) and sets it to active/hidden depending on the bool
	//This is used to show off what the player clicked on
	void ActivateAura(){
		if(ToggleAura == true){
			aura = gameObject.transform.FindChild("ActiveChild");
			//Debug.Log("AURA IS " + aura);	
			aura.gameObject.SetActive(true);
			ToggleAura = false;
		}
		else{
			aura = gameObject.transform.FindChild("ActiveChild");
			//Debug.Log("AURA IS " + aura);	
			aura.gameObject.SetActive(false);
			ToggleAura = true;
		}
	}
	
	//Added 30/04/2013
	//Plays the active sound (Rock sound) from the sound manager
	//I cant add it in the Update() directly cause it tries to constantly play is which results in it not properly at all
	//I use the bool down here like a toggle - pretty much the same way I use it in ActivateAura
	//Hacky code but it works and I need to finish this thing by yesterday!
	void PlayActiveSound(){
		if(ToggleSound == true){
			soundmanager.PlayRockSound();
			ToggleSound = false;
		}
	}
	
	//Yay firs time and it works lol
	void GetGodSound(){
		switch (runesaver.getScore()){
			case 5:
				soundmanager.PlayGodSing_One();
				break;
			case 15:
				soundmanager.PlayGodSing_Two();
				break;
			case 20:
				soundmanager.PlayGodSing_Three();
				break;
			default:
				Debug.Log("No Case Reached in GetGodSound");
				break;
		}
	}
}