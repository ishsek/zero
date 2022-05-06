using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour {
	public GameObject text;
	bool textActive;

	// Use this for initialization
	void Awake () {
		textActive = false;
		text.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			text.SetActive (true);
			textActive = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			Destroy (gameObject, 4);
		}
	}
}
