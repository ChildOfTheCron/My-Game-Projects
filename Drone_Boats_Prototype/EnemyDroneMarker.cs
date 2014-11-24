using UnityEngine;
using System.Collections;

public class EnemyDroneMarker : MonoBehaviour {

    public void OnDrawGizmos() {
		Gizmos.DrawIcon(transform.position, "EnemyDroneMarker.gif");
    }
}
