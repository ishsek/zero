using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBehaviour : MonoBehaviour {
	public GameObject interactText;
	bool allowInteract;

	// Use this for initialization
	void Awake () {
		interactText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (allowInteract) {
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			interactText.SetActive (true);
			allowInteract = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			interactText.SetActive (false);
			allowInteract = false;
		}
	}
}
