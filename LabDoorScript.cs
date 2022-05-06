using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabDoorScript : MonoBehaviour {
	public GameObject player;
	public Sprite doorActivated;
	public GameObject interactButton;
	public AudioClip doorSFX;
	AudioSource src;
	bool activated;
	bool allowInteract;

	// Use this for initialization
	void Awake () {
		interactButton.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!activated) {
			if (allowInteract && Input.GetKeyDown (KeyCode.E)) {
				if (player.GetComponent<CoreTrackerScript> ().cores >= 1) {
					activated = true;
					player.GetComponent<CoreTrackerScript> ().cores--;
					GetComponent<SpriteRenderer> ().sprite = doorActivated;
					src.PlayOneShot (doorSFX);
				}
			}
		} else if (activated) {
			if (allowInteract && Input.GetKeyDown (KeyCode.E)) {
				Application.LoadLevel (6);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			allowInteract = true;
			interactButton.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			allowInteract = false;	
			interactButton.SetActive (false);
		}
	}
}
