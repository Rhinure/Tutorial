using UnityEngine;
using System.Collections;

public class Sparks : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			//you have half of the key needed to advance
			//you now need to find the next one
		}
	}
}
