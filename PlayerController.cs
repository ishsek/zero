using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// Move the player variables
	Rigidbody2D myRB;
	SpriteRenderer mySR;
	public float moveSpeed;
	public float jumpPower;
	bool canJump;
	bool canDoubleJump;
	bool DoubleJumped;
	bool facingLeft, facingRight;

	// Animation variables
	private Animator animator;
	bool running;
	bool jumping;

	// Control Cameras
	public GameObject mainCam;
	public GameObject mapCam;
	[HideInInspector]public bool allowControl;

	// Use this for initialization
	void Awake () {
		running = false;
		facingRight = true;
		facingLeft = false;
		myRB = GetComponent<Rigidbody2D> ();
		mySR = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();

		if (mainCam != null) mainCam.SetActive (true);
		if (mapCam != null) mapCam.SetActive (false);
		allowControl = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (allowControl) {
			// Move player and animate run based on key pressed
			if (Input.GetKey (KeyCode.A)) {
				myRB.AddForce (new Vector2 (-moveSpeed, 0));
				if (!jumping)
					MakeRun ();
				if (facingLeft == false) {
					mySR.flipX = true;
					facingLeft = true;
					facingRight = false;
				}
			} else if (Input.GetKey (KeyCode.D)) {
				myRB.AddForce (new Vector2 (moveSpeed, 0));
				if (!jumping)
					MakeRun ();
				if (facingRight == false) {
					mySR.flipX = false;
					facingLeft = false;
					facingRight = true;
				}
			}

			// Let player jump and double jump based on spacebar
			if (canJump && Input.GetKey (KeyCode.Space)) {
				myRB.AddForce (new Vector2 (0, jumpPower));
				animator.SetTrigger ("Jump");
				jumping = true;
				canJump = false;
				Debug.Log ("Jumped");
			} else if (canDoubleJump && Input.GetKey (KeyCode.Space)) {
				myRB.velocity = new Vector3 (myRB.velocity.x, 0, 0);
				myRB.AddForce (new Vector2 (0, jumpPower));
				jumping = true;
				canDoubleJump = false;
				DoubleJumped = true;
				Debug.Log ("DoubleJumped");
			}

			// Let the player double jump once per jump after releasing space key
			if (Input.GetKeyUp (KeyCode.Space) && jumping) {
				if (!DoubleJumped) {
					canDoubleJump = true;
				} 
			}
		}

		// Make the player animation to idle when not moving or jumping
		if (myRB.velocity.x < 0.1 && myRB.velocity.x > -0.1 && jumping == false && running == true) {
			animator.SetTrigger ("Idle");
			running = false;
			jumping = false;
		}

		// Change between map and standard camera
		if (Input.GetKeyDown (KeyCode.M)) {
			if (mainCam != null && mapCam != null) {
				if (mainCam.activeSelf) {
					if (mapCam != null) {
						mainCam.SetActive (false);
						mapCam.SetActive (true);
					}
				} else {
					if (mapCam != null) {
						mapCam.SetActive (false);
						mainCam.SetActive (true);
					}
				}
			}
		}
	}

	// Swap to run animation
	private void MakeRun() {
		if (running == false) {
			animator.SetTrigger ("Run");
			running = true;
		}

	}

	// Check when player is on platform, and allow jumping then
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Platform" && canJump == false) {
			myRB.velocity = new Vector3 (myRB.velocity.x, 0, 0);
			canJump = true;
			canDoubleJump = false;
			DoubleJumped = false;
			jumping = false;
			if (myRB.velocity.x > -1 && myRB.velocity.x < 1) {
				animator.SetTrigger ("Idle");
				running = false;
			} else {
				animator.SetTrigger ("Run");
				running = true;
			}
		}

		if (other.tag == "JumpPlatform") {
			myRB.velocity = new Vector3 (myRB.velocity.x, 0, 0);
			myRB.AddForce (new Vector2 (0, 800));
		}
	}

	// Give player a little more speed on platform to account for drag
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Platform") {
			myRB.velocity = new Vector3 (myRB.velocity.x * 1.03f, 0, 0);
		}
	}

	// Dont let player jump if they fall off platform
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Platform") {
			canJump = false;
		}
	}
}
