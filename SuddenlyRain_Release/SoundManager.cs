using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	AudioSource rain;
	AudioSource scream1;
	AudioSource scream2;
	AudioSource scream3;
	AudioSource idle;
	AudioSource splash;

	
	AudioSource[] Asources;
	// Use this for initialization
	void Start () {
		
		Asources = gameObject.GetComponents<AudioSource>();
		
		rain = Asources[0];
		scream1 = Asources[1];
		scream2 = Asources[2];
		scream3 = Asources[3];
		idle = Asources[4];
		splash = Asources[5]; 
		
		idle.Play();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void PlayScream_One(){
		if(!scream1.isPlaying & !scream2.isPlaying & !scream3.isPlaying){
			idle.Stop();
			scream1.Play();
		}
	}
	
	public void PlayScream_Two(){
		if(!scream1.isPlaying & !scream2.isPlaying & !scream3.isPlaying){
			idle.Stop();
			scream2.Play();
		}
	}
	
	public void PlayScream_Three(){
		if(!scream1.isPlaying & !scream2.isPlaying & !scream3.isPlaying){
			idle.Stop();
			scream3.Play();
		}
	}
	
	public void PlaySplash(){
		splash.Play();
	}
	
	public void PlayIdleSound(){
		idle.Play();
	}		
	
}