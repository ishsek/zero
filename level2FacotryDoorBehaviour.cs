using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2FacotryDoorBehaviour : MonoBehaviour {
	public Sprite openDoorSprite;
	public GameObject interactButton;
	public GameObject player;
	public AudioClip doorActiveSFX;
	private AudioSource src;
	bool doorOpen;
	bool allowInteract;

	// Use this for initialization
	void Awake () {
		interactButton.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!doorOpen && allowInteract) {
			if (Input.GetKeyDown (KeyCode.E) && player.GetComponent<CoreTrackerScript> ().cores >= 1) {
				player.GetComponent<CoreTrackerScript> ().cores--;
				GetComponent<SpriteRenderer> ().sprite = openDoorSprite;
				src.PlayOneShot (doorActiveSFX);
				doorOpen = true;
			}
		} else if (allowInteract) {
			if (Input.GetKeyDown (KeyCode.E)) {
				Application.LoadLevel (4);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		interactButton.SetActive (true);
		allowInteract = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		interactButton.SetActive (false);
		allowInteract = false;
	}
}
