using UnityEngine;
using System.Collections;

public class EXAMPLE_MouseMov : MonoBehaviour {
	
	public float horizontalSpeed = 1.0F;
    public float verticalSpeed = 1.0F;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space")){ //if I hold down space then scroll mode time!
		    float h = horizontalSpeed * Input.GetAxis("Mouse Y");
	        float v = verticalSpeed * Input.GetAxis("Mouse X");
	        transform.Translate(v, h, 0);
		}
	}
}
