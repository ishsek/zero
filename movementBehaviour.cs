using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBehaviour : MonoBehaviour {
	[HideInInspector]public bool active;
	bool shouldMove;
	public float moveSpeed;
	public GameObject moveToLocation;
	private Vector3 startPos;

	float leaveTime = 60;
	bool countdown;

	// Use this for initialization
	void Awake () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldMove && active) {
			if (transform.position.y < moveToLocation.transform.position.y) {
				transform.Translate (new Vector3 (0, moveSpeed, 0));
			}
		} else if (shouldMove == false && active) {
			if (transform.position.y > startPos.y) {
				transform.Translate (new Vector3 (0, -moveSpeed, 0));
			}
		}

		if (countdown) {
			leaveTime--;
			if (leaveTime <= 0)
				shouldMove = false;
		} else {
			leaveTime = 60;
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			countdown = false;
			shouldMove = true;
			Debug.Log ("MOVE ME");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		
			if (other.tag == "Player") {
				countdown = true;
				Debug.Log ("STOP MOVING");
			}

	}
}
