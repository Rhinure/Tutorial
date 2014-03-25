using UnityEngine;
using System.Collections;

public class SmoothFollow2 : MonoBehaviour {
	public Transform target;
	public int distance = 10;
	public int height = 0;
	public float damping = 5.0f;
	public bool smoothRotation = false;
	public float rotationDamping = 10.0f;
	public bool lockRotation = true;

	public void Update() {
		Vector3 wantedPosition = target.TransformPoint (0, height, -distance);
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		if (smoothRotation) {
			Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else transform.LookAt (target, target.up);
		if(lockRotation){
			transform.localRotation = Quaternion.Euler(0,0,0);
		}
	}
}

