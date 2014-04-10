using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;
	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public float jumpForce = 750;
	public LayerMask whatIsGround;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per fram		e
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}

	}
	void Update() {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool("Ground", false);
			grounded = false;
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
		}
	}
	void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}

