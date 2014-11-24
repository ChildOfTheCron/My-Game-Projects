using UnityEngine;
using System.Collections;

public class CollideScript : MonoBehaviour {

	GUITexture menuPanel;
	public GameObject objNPCItem1;
	public GameObject objNPCItem2;
	public GameObject objNPCItem3;
	public GameObject objNPCItem4;
	
	Object tempObj1;
	Object tempObj2;
	Object tempObj3;
	Object tempObj4;
	
	// Use this for initialization
	void Start () {
		//menupanel = GameObject.Find("MenuPanel").gameObject.GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
    void OnTriggerEnter(Collider other) {
		GameObject.Find("MenuPanel").gameObject.GetComponent<GUITexture>().enabled = true;
		GameObject.Find("Trade").gameObject.GetComponent<GUITexture>().enabled = true;
        Debug.Log ("You have met an NPC!");
		
		//For temp use - need to use Instantiate and DEstroy over just spawning and hiding the same NPC items
		//Instantiate(NPCItem1, transform.position, transform.rotation);
		//GameObject.Find("NPCItem1").gameObject.GetComponent<GUITexture>().enabled = true;
		//GameObject.Find("NPCItem2").gameObject.GetComponent<GUITexture>().enabled = true;
		//GameObject.Find("NPCItem3").gameObject.GetComponent<GUITexture>().enabled = true;
		//GameObject.Find("NPCItem4").gameObject.GetComponent<GUITexture>().enabled = true;
		
		//Hard coded the vector coordinates
		tempObj1 = Instantiate(objNPCItem1, new Vector3(0.6F, 0.07F, 0.1F), Quaternion.identity);
		tempObj2 = Instantiate(objNPCItem2, new Vector3(0.72F, 0.07F, 0.1F), Quaternion.identity);
		tempObj3 = Instantiate(objNPCItem3, new Vector3(0.85F, 0.07F, 0.1F), Quaternion.identity);
		tempObj4 = Instantiate(objNPCItem4, new Vector3(0.96F, 0.07F, 0.1F), Quaternion.identity);
    }
	
	void OnTriggerExit(Collider other) {
		GameObject.Find("MenuPanel").gameObject.GetComponent<GUITexture>().enabled = false;
		GameObject.Find("Trade").gameObject.GetComponent<GUITexture>().enabled = false;
        Debug.Log ("You have met an NPC!");
		
		//For temp use - need to use Instantiate and DEstroy over just spawning and hiding the same NPC items
		//GameObject.Find("NPCItem1").gameObject.GetComponent<GUITexture>().enabled = false;
		//GameObject.Find("NPCItem2").gameObject.GetComponent<GUITexture>().enabled = false;
		//GameObject.Find("NPCItem3").gameObject.GetComponent<GUITexture>().enabled = false;
		//GameObject.Find("NPCItem4").gameObject.GetComponent<GUITexture>().enabled = false;
		
		Destroy(tempObj1);
		Destroy(tempObj2);
		Destroy(tempObj3);
		Destroy(tempObj4);
    }
}
