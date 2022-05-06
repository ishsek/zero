using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalConsoleController : MonoBehaviour {
	public GameObject player;
	public GameObject dial1, dial2;
	bool allowInteract;
	bool activated;
	int countdown;
	public AudioClip reactivateSFX;
	bool played;
	AudioSource src;
	bool useCredits1;
	public Sprite changeSprite;

	// Use this for initialization
	void Awake () {
		dial1.SetActive (false);
		dial2.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (allowInteract && !activated && player.GetComponent<CoreTrackerScript>().cores >= 4) {
			if (Input.GetKeyDown (KeyCode.J)) {
				dial2.SetActive (false);
				allowInteract = false;
				activated = true;
				player.GetComponent<CoreTrackerScript> ().cores -= 4;
				useCredits1 = true;
				GetComponent<SpriteRenderer> ().sprite = changeSprite;
			} else if (Input.GetKeyDown (KeyCode.K)) {
				dial1.SetActive (false);
				allowInteract = false;
				activated = true;
				player.GetComponent<CoreTrackerScript> ().cores -= 4;
				useCredits1 = false;
				GetComponent<SpriteRenderer> ().sprite = changeSprite;
			}
		} else if (activated) {
			countdown++;
			if (!played) {
				src.PlayOneShot (reactivateSFX);
				played = true;
			}
			if (countdown > 60 * 4) {
				if (useCredits1) {
					Application.LoadLevel (8);
				} else {
					Application.LoadLevel (9);
				}
			}
		}
	}	

	void OnTriggerEnter2D(Collider2D other) {
		if (!activated && other.tag == "Player") {
			allowInteract = true;
			dial1.SetActive (true);
			dial2.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			allowInteract = false;
			if (!activated) {
				dial1.SetActive (false);
				dial2.SetActive (false);
			}
		}
	}
}
