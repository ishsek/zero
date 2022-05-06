using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreTrackerScript : MonoBehaviour {
	// Core tracking variables
	[HideInInspector]public int cores;
	int delay = 120;
	int counter;
	bool allowInteract;
	GameObject otherObject;
	public GameObject coreUI; // UI object that displays cores

	// Audio variables
	public AudioClip coreCollectSFX;
	private AudioSource src;

	// Use this for initialization
	void Awake () {
		cores = 0;
		counter = 0;
		src = GetComponent<AudioSource> ();
		if (Application.loadedLevel == 3)
			coreUI.SetActive (true);
		else if (Application.loadedLevel == 2)
			coreUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		// Deal with cores and input
		if (allowInteract && Input.GetKey (KeyCode.E) && counter <= 0) {
			counter = delay;
			cores++;
			Destroy (otherObject);
			Debug.Log ("Cores: " + cores);
			src.PlayOneShot (coreCollectSFX);
			coreUI.SetActive (true);
		}

		if (counter > -1)
			counter--;
	}

	// Check for core collision and allow interaction
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Core") {
			allowInteract = true;
			otherObject = other.gameObject;
		}
	}

	// Disable interaction when exiting core collision
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Core") {
			allowInteract = false;
		}
	}
}
