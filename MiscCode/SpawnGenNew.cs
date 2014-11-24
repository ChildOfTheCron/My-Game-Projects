using UnityEngine;
using System.Collections;

//This script is used to generate a matrix of room objects
public class SpawnGenNew : MonoBehaviour {
	
	public GUITexture room3;
	
	int drawHorizontal;
	int drawVerticle;
	
	float basexInset;
	float baseyInset;
	float xInsetStore;
	float yInsetStore;
	
	// Use this for initialization
	void Start () {
		
		//Store the base values so that I can reset the X axis after
		//the row is drawn (see below)
		basexInset = 25;
		baseyInset = Screen.height-75;
		
		xInsetStore = basexInset;
		yInsetStore = baseyInset;
		
		drawVerticle = 0;
		drawHorizontal = 0;
		
		//Rect pos = room3.pixelInset;
		//pos.x = xInsetStore;
		//pos.y = yInsetStore;
		//room3.pixelInset = pos;	
		//Instantiate(room3, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//genHozVec = stores the baseVector vec3 for horizontal spawns
	//genVertVec = stores the baseVector vec3 for verticle spawns
	//It's a loop in a loop. At the end of the inner loop the 
	// genHozVec V3 gets reset to the baseVector and the Offset gets reset to default
	void OnMouseDown() {
		//This loop drawd the rows and is responsable for the Y axis
		for (drawVerticle = 0; drawVerticle < 3; drawVerticle++)
		{
			//Draws the first room
			Instantiate(room3, transform.position, Quaternion.identity);
					
			//This loop is responsable for drawing the X axis
			for (drawHorizontal = 0; drawHorizontal < 3; drawHorizontal++)
			{
				xInsetStore=xInsetStore+175;
				Rect posHoz = room3.pixelInset;
			    posHoz.x = xInsetStore;//+175;
				//posHoz.y = yInsetStore; is this really needed?
			    room3.pixelInset = posHoz;
				Debug.Log(room3.pixelInset);
				Instantiate(room3, transform.position, Quaternion.identity);
			}
			
			//Makes the room3.inset ready for the next row
			xInsetStore=basexInset; //Load the base value to reset the row
			yInsetStore=yInsetStore-100; // change the y axis
			Rect posVert = room3.pixelInset;
			posVert.x = xInsetStore;
			posVert.y = yInsetStore;
			room3.pixelInset = posVert;
			
			Debug.Log("Grid has been drawn.");
		}
		
	}
	
}
