using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public Transform spawnPoint;// = Transform.FindObjectOfType();
	public void Start() {
		//spawnpoint = new Transform ();
		//spawnpoint.Find ("Checkpoint");
	}
	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			spawnPoint.position = new Vector3(transform.position.x, 
			                              transform.position.y, 10);
			//spawnPoint.position.y, spawnPoint.position.z);
			Destroy(gameObject);
		}
	}
}
