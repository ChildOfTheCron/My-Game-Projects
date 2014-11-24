using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	
	//Material playerDownMat;
	//Material playerUpMat;
	
	Texture leftTexture;
	Texture rightTexture;
	
	bool rightBounds;
	bool leftBounds;
	
	SoundManager soundscript;
	
	// Use this for initialization
	void Start () {
		//No longer change mats and shaders, only textures
		//playerDownMat = Resources.Load("My Mats/Guy_Down", typeof(Material)) as Material;
		//playerUpMat = Resources.Load("My Mats/Guy_Up", typeof(Material)) as Material;
		
		//downTexture = Resources.Load ("My_Textures/DudePL", typeof(Texture)) as Texture;
		//upTexture = Resources.Load ("My_Textures/DudePL_D", typeof(Texture)) as Texture;
		leftTexture = Resources.Load ("Textures/Slug1", typeof(Texture)) as Texture;
		rightTexture = Resources.Load ("Textures/Slug2", typeof(Texture)) as Texture;
		
		soundscript = GameObject.Find("Camera").gameObject.GetComponent<SoundManager>();
		
		rightBounds = false;
		leftBounds = false;
		
	}
	
	// Update is called once per frame
	//Rather than change the Material (and thus the Shader) I changed it to rather just change the Texture
	//No longer uses GameObject.Find("Dude").gameObject.GetComponent<Renderer>().material = playerDownMat;
	void Update () {
		
		if(leftBounds == false)
		{
			if (Input.GetKey ("a")){
				transform.Translate(Vector3.left * Time.deltaTime*2);
				GameObject.Find("Player").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", leftTexture);
				playPanicSound();
			}
		}
		
		//if (Input.GetKey ("s")){
			//transform.Translate(Vector3.down * Time.deltaTime/4);
			//GameObject.Find("Dude").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", downTexture);
		//}
		
		if(rightBounds == false)
		{
			if (Input.GetKey ("d")){
				transform.Translate(Vector3.right * Time.deltaTime*2);
				GameObject.Find("Player").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", rightTexture);
				playPanicSound();
			}
		}
	}
	
	public void setRightBounds(bool x){
		rightBounds = x;
		//return rightBounds;
	}
	
	public void setLeftBounds(bool x){
		leftBounds = x;
		//return leftBounds;	
	}
	
	void playPanicSound(){
				
		int x = Random.Range(1,6);
		switch(x) 
		{
		case 1:
			soundscript.PlayScream_One();
			break;
		case 2:
			soundscript.PlayScream_Two();
			break;
		case 3:
			soundscript.PlayScream_Three();
			break;
		default:
			soundscript.PlayIdleSound();
			break;
		}
	}
	
}
