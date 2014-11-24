using UnityEngine;
using System.Collections;

public class AdjustUIText : MonoBehaviour {

	private GUIText myGUIText;
	
	private float getXInset;
	private float getYInset;
	
	public int imgHeightModifier;
	public int imgWidthModifier;
	
	// Use this for initialization
    void Start()
    {
		//myGUIText = this.gameObject.GetComponent("GUIText") as GUIText;
		
		//getXInset = myGUIText.pixelInset.x;
		//getYInset = myGUIText.pixelInset.y;
    }
	
	// Update is called once per frame
	void Update () {
		
		// Position the billboard in the center,
	    // but respect the picture aspect ratio
	    //int textureHeight = guiTexture.texture.height;
	    //int textureWidth = guiTexture.texture.width;
	    //int screenHeight = Screen.height/imgHeightModifier;
	    //int screenWidth = Screen.width/imgWidthModifier;
	     
	    //int screenAspectRatio = (screenWidth / screenHeight);
	    //int textureAspectRatio = (textureWidth / textureHeight);
	     
	    int scaledHeight;
	    int scaledWidth;
	    
		
		//We have to change by screen. If we change by texture we'll just keep the textures ratio consistent
		//which is not the point. We want to scale UI elements with the screen.
		//This means we need to adjust according to the screen.
		//if (textureAspectRatio <= screenAspectRatio) //To get the new ratio Height or to adjust by Height
	    //{
		    // The scaled size is based on the height
		    //scaledHeight = screenHeight;
		    //scaledWidth = (screenHeight * textureAspectRatio);
	    //}
	    //else
	    //{
		    // The scaled size is based on the width
		    //scaledWidth = screenWidth;
		    //scaledHeight = (scaledWidth / textureAspectRatio);
	    //}
	    
		//float xPosition = getXInset;
	    //myGUIText.pixelOffset =
	    //new Rect(xPosition, scaledHeight - scaledHeight, //Won't scaledHeight always be 0 here? What the butts?
	    //scaledWidth, scaledHeight);
	}	
}
