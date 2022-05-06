using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelCoreButtons : MonoBehaviour {
	public GameObject corePic;
	public GameObject player;
	public GameObject interactButton;
	bool active;
	bool allowInteract;
	public AudioClip collectSFX;
	AudioSource src;
	public Sprite deadWire;
	public GameObject wire1, wire2, wire3, wire4, wire5, wire6;

	// Use this for initialization
	void Awake() {
		interactButton.SetActive (false);
		active = true;
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (active && allowInteract) {
			if (Input.GetKeyDown (KeyCode.E)) {
				player.GetComponent<CoreTrackerScript> ().cores++;
				Destroy (corePic);
				src.PlayOneShot (collectSFX);
				interactButton.SetActive (false);
				allowInteract = false;
				active = false;
				DisableWires ();
			}
		}
	}

	void DisableWires() {
		if (wire1 != null)
			wire1.GetComponent<SpriteRenderer> ().sprite = deadWire;
		if (wire2 != null)
			wire2.GetComponent<SpriteRenderer> ().sprite = deadWire;
		if (wire3 != null)
			wire3.GetComponent<SpriteRenderer> ().sprite = deadWire;
		if (wire4 != null)
			wire4.GetComponent<SpriteRenderer> ().sprite = deadWire;
		if (wire5 != null)
			wire5.GetComponent<SpriteRenderer> ().sprite = deadWire;
		if (wire6 != null)
			wire6.GetComponent<SpriteRenderer> ().sprite = deadWire;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (active && other.tag == "Player") {
			interactButton.SetActive (true);
			allowInteract = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			interactButton.SetActive (false);
			allowInteract = false;
		}
	}
}
