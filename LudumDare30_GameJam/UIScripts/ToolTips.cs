using UnityEngine;
using System.Collections;

public class ToolTips : MonoBehaviour {
	
	GUIText guiTooltip;
	
	// Use this for initialization
	void Start () {
		guiTooltip = GameObject.Find("tooltipText").gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver() {
		//Panel tool tips
		if(gameObject.name == "HABTag"){
			guiTooltip.text = "Habitation blocks - used to house refugees and increase population.";
		}
		if(gameObject.name == "DefTag"){
			guiTooltip.text = "Defences - used to enforce laws and increase population safety.";
		}
		if(gameObject.name == "HealthTag"){
			guiTooltip.text = "Medical Buildings - used to provide medical support to injured refugees.";
		}
		if(gameObject.name == "MoneyTag"){
			guiTooltip.text = "Industrial complexes - refugees who feel able can work here providing us with funds.";
		}
		if(gameObject.name == "StatsTag"){
			guiTooltip.text = "Quick station overview.";
		}
		
		
		//Building tooltips
		if(gameObject.name == "SecurityBuilding"){
			guiTooltip.text = "Security checkpoints increase saftey and happiness.";
		}
		if(gameObject.name == "BlueHAB"){
			guiTooltip.text = "Habitation block for the Maki (blue) refugees.";
		}
		if(gameObject.name == "RedHAB"){
			guiTooltip.text = "Habitation block for the Korr (red) refugees.";
		}
		if(gameObject.name == "GreenHAB"){
			guiTooltip.text = "Habitation block for the Klein (green) refugees.";
		}
		if(gameObject.name == "YellowHAB"){
			guiTooltip.text = "Habitation block for the Tzik (yellow) refugees.";
		}
		if(gameObject.name == "MedBay"){
			guiTooltip.text = "MedBay Facility provides emergency medical care to arriving refugees.";
		}
		if(gameObject.name == "FoodPlant"){
			guiTooltip.text = "Food Processing Plant - Ideal for Klein refugees who want to help.";
		}
		if(gameObject.name == "Mecha_Factory"){
			guiTooltip.text = "Mechanicum Factory - Ideal for Korr refugees who want to help.";
		}
		if(gameObject.name == "PurePlant"){
			guiTooltip.text = "Water Purification Plant - Ideal for Maki refugees who want to help.";
		}
		if(gameObject.name == "SolarArray"){
			guiTooltip.text = "Solar Array - Ideal for Tzik refugees who want to help.";
		}
		if(gameObject.name == "RoomBlock"){
			guiTooltip.text = "Empty block - Try building a building here.";
		}
		
	}
	
	void OnMouseExit(){
		guiTooltip.text = "";
	}
	
}
