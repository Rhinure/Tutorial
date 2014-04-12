using UnityEngine;
using System.Collections;
//attach to moving platform
//platform needs rigidbody2d, with isKinematic and fixedAngle checked
//a negative x/y value will make it move to the left/down first instead of right/up
//code from http://forum.unity3d.com/threads/229918-Moving-platforms-are-slippery

public class MovingPlatform : MonoBehaviour {
	//Proxy - MovingPhysicsPlatform Script v1.0
	//How far in Units we want to go in X/Y.
	public Vector2 moveDistance = new Vector2(2f,0); 
	public float moveSpeed = 5f;
	public float waitDuration = 1.5f;
	public bool goingRight = true;
	private Vector2 startPos;
	private int direction = 1;
	private float goalDistance;
	void Start() {
		//Store our starting position so we can check 
		//when we've returned to this position
		startPos = transform.position;          
		//Always have a goal distance of at least 0.006
		goalDistance = 0.006f + (moveSpeed * 0.008f);   
		if (moveDistance.x < 0 || moveDistance.y < 0) {
			goingRight = false;
		} else {
			goingRight = true;
		}
	}

	void FixedUpdate(){
		//If the Distance between our current position 
		//and the position we wanted to reach is less than the goalDistance, 
		//change direction and wait if waitDuration set
		if( direction == 1 && (Vector2.Distance(
			transform.position, startPos + moveDistance) < goalDistance ) ) {
			//Start our wait/change direction Coroutine once we hit goal
			StartCoroutine( ChangeDir() );  
			goingRight = false;
		}
		else if( direction == -1 && 
		        (Vector2.Distance(transform.position, startPos) < goalDistance ) ) {
			StartCoroutine(ChangeDir());		
			goingRight = true;
		}
		//Normalize our moveDistance to a 0-1 range
		rigidbody2D.velocity =  (moveSpeed * moveDistance.normalized) * direction;
		/*if (goingRight) {
			if (gameObject.tag == "Player") {
				gameObject.rigidbody2D.velocity += rigidbody2D.velocity*-1;
		}
		}*/


	}

	IEnumerator ChangeDir() {
		//change the direction
		direction *= -1;
		//store the moveSpeed temporarily
		float lastMoveSpeed = moveSpeed;
		//and set the actual moveSpeed to 0 so it doesn't move
		moveSpeed = 0;
		//Wait for how long we choose
		yield return new WaitForSeconds(waitDuration);
		//start moving again
		moveSpeed = lastMoveSpeed;
	}
	/*void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			other.rigidbody2D.velocity += rigidbody2D.velocity;
		}
		/*if (other.tag == "Player") {
			other.rigidbody2D.AddForce(other.transform.forward*rigidbody2D.velocity.x);
			other.rigidbody2D.AddForce(other.transform.up*rigidbody2D.velocity.y);
		}*/
	//}
	
	/*void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") {
			other.rigidbody2D.velocity += direction*rigidbody2D.velocity;
		}
	}*/
}