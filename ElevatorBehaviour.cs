using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviour : MonoBehaviour {
	public Sprite activeElevator;
	public GameObject player;
	bool activated;
	bool allowInteract;
	public GameObject interactButton;


	public AudioClip doorSFX;
	AudioSource src;

	// Use this for initialization
	void Awake () {
		interactButton.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (allowInteract && Input.GetKeyDown (KeyCode.E)) {
			if (!activated) {
				if (player.GetComponent<CoreTrackerScript> ().cores >= 1) {
					activated = true;
					player.GetComponent<CoreTrackerScript> ().cores--;
					this.GetComponent<SpriteRenderer> ().sprite = activeElevator;
					src.PlayOneShot (doorSFX);
				}
			} else if (activated) {
				Application.LoadLevel (6);
			}
		}	
	}

	void OnTriggerEnter2D(Collider2D other) {
		allowInteract = true;
		interactButton.SetActive (true);
	}

	void OnTriggerExit2D(Collider2D other) {
		allowInteract = false;
		interactButton.SetActive (false);
	}
}
