using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	AudioSource windLoop;
	AudioSource IntroTalk;
	AudioSource RockSound;
	AudioSource ChimeSound;
	
	bool windToggle;
	
	AudioSource GodSing_One;
	AudioSource GodSing_Two;
	AudioSource GodSing_Three;
	
	AudioSource[] Asources;
	// Use this for initialization
	void Start () {
		
		Asources = gameObject.GetComponents<AudioSource>();

		windLoop = Asources[0];
		IntroTalk = Asources[1];
		RockSound = Asources[2];
		ChimeSound = Asources[3];
		
		GodSing_One = Asources[4];
		GodSing_Two = Asources[5];
		GodSing_Three = Asources[6];
		
		windToggle = true;
		
		IntroTalk.Play();
					
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!IntroTalk.isPlaying & windToggle == true){
			windLoop.Play();
			windToggle = false;
		}

	}
	
	public void PlayRockSound(){
		RockSound.Play();
	}
	
	public void PlayChimeSound(){
		ChimeSound.Play();
	}
	
	public void PlayGodSing_One(){
		GodSing_One.Play();
	}
	
	public void PlayGodSing_Two(){
		GodSing_Two.Play();
	}
	
	public void PlayGodSing_Three(){
		GodSing_Three.Play();
	}
	
}
