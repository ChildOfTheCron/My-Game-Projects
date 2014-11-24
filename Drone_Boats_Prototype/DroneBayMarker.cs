using UnityEngine;
using System.Collections;

public class DroneBayMarker : MonoBehaviour {
	
	//Draw the gizmo every frame
    public void OnDrawGizmos() {
		Gizmos.DrawIcon(transform.position, "DroneMarker.gif");
    }
}
