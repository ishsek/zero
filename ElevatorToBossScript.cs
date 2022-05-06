using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorToBossScript : MonoBehaviour {
	bool activated;
	bool allowInteract;
	public GameObject player;
	public GameObject interactButton;
	public Sprite activeElevSprite;
	public AudioClip unlockSound;
	AudioSource src;

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
					player.GetComponent<CoreTrackerScript> ().cores--;
					activated = true;
					GetComponent<SpriteRenderer> ().sprite = activeElevSprite;
					src.PlayOneShot (unlockSound);
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
