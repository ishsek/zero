using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClawControllerScript : MonoBehaviour {
	// Show activity status
	public Sprite disabled;
	public GameObject player;
	public GameObject claw;
	public Sprite clawReleased;
	public GameObject myCrate;
	public GameObject interactText;
	public GameObject wires;
	public Sprite wireOff;
	bool clawOn;
	bool allowInteract;

	// Core collect sound
	public AudioClip coreSFX;
	AudioSource src;

	public GameObject objectiveText;
	public string newObjective;


	// Use this for initialization
	void Awake () {
		clawOn = true;
		myCrate.SetActive (false);
		interactText.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (allowInteract && Input.GetKeyDown (KeyCode.E)) {
			if (clawOn) {
				clawOn = false;
				this.GetComponent<SpriteRenderer> ().sprite = disabled;
				claw.GetComponent<SpriteRenderer> ().sprite = clawReleased;
				myCrate.SetActive (true);
				player.GetComponent<CoreTrackerScript> ().cores++;
				src.PlayOneShot (coreSFX);

				allowInteract = false;
				interactText.SetActive (false);

				wires.GetComponent<SpriteRenderer> ().sprite = wireOff;
				objectiveText.GetComponent<Text> ().text = newObjective;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (clawOn) {
			allowInteract = true;
			interactText.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		allowInteract = false;
		interactText.SetActive (false);
	}
}
