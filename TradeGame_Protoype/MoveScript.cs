using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	
	//Material playerDownMat;
	//Material playerUpMat;
	
	Texture downTexture;
	Texture upTexture;
	Texture leftTexture;
	Texture rightTexture;
	
	// Use this for initialization
	void Start () {
		//No longer change mats and shaders, only textures
		//playerDownMat = Resources.Load("My Mats/Guy_Down", typeof(Material)) as Material;
		//playerUpMat = Resources.Load("My Mats/Guy_Up", typeof(Material)) as Material;
		
		downTexture = Resources.Load ("My_Textures/DudePL", typeof(Texture)) as Texture;
		upTexture = Resources.Load ("My_Textures/DudePL_D", typeof(Texture)) as Texture;
		leftTexture = Resources.Load ("My_Textures/DudePL_Left", typeof(Texture)) as Texture;
		rightTexture = Resources.Load ("My_Textures/DudePL_Right", typeof(Texture)) as Texture;
		
	}
	
	// Update is called once per frame
	//Rather than change the Material (and thus the Shader) I changed it to rather just change the Texture
	//No longer uses GameObject.Find("Dude").gameObject.GetComponent<Renderer>().material = playerDownMat;
	void Update () {
		if (Input.GetKey ("w")){
			//transform.Translate(Input.mousePosition * Time.deltaTime);//, Space.World);
			transform.Translate(Vector3.up * Time.deltaTime/4);
			GameObject.Find("Dude").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", upTexture);
			//GameObject.Find("Dude").gameObject.transform.position(x
			//Debug.Log ("space key was pressed " + Input.mousePosition);
		}
		
		if (Input.GetKey ("a")){
			transform.Translate(Vector3.left * Time.deltaTime/4);
			GameObject.Find("Dude").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", leftTexture);
		}
		
		if (Input.GetKey ("s")){
			transform.Translate(Vector3.down * Time.deltaTime/4);
			GameObject.Find("Dude").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", downTexture);
		}
		
		if (Input.GetKey ("d")){
			transform.Translate(Vector3.right * Time.deltaTime/4);
			GameObject.Find("Dude").gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", rightTexture);
		}
	}
	
}
