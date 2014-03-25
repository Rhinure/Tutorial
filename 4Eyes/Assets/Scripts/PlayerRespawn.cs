using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {
	public GameObject Player;
	public Transform spawnPoint;
	void OnTriggerEnter2D(Collider2D other) {
		other.transform.position = spawnPoint.position;
	}
}
