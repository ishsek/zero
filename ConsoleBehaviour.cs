using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleBehaviour : MonoBehaviour {
	public GameObject consoleText;

	// Use this for initialization
	void Awake () {
		consoleText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			consoleText.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			consoleText.SetActive (false);
		}
	}
}
