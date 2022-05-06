using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingPlatformController : MonoBehaviour {
	public Sprite activeSprite;
	public GameObject player;
	public GameObject closeOtherPath;
	public GameObject interactButton;
	bool allowInteract;
	bool activated;
	public GameObject wire1;
	public GameObject wire2;
	public Sprite wireActiveSprite;
	public GameObject thePlatform;

	public AudioClip activateSFX;
	AudioSource src;

	public GameObject objectiveText;
	public string newObjective;

	// Use this for initialization
	void Awake() {
		closeOtherPath.SetActive (false);
		interactButton.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (allowInteract && Input.GetKeyDown (KeyCode.E)) {
			if (!activated && player.GetComponent<CoreTrackerScript>().cores >= 1) {
				activated = true;
				player.GetComponent<CoreTrackerScript> ().cores--;
				this.GetComponent<SpriteRenderer> ().sprite = activeSprite;
				wire1.GetComponent<SpriteRenderer> ().sprite = wireActiveSprite;
				wire2.GetComponent<SpriteRenderer> ().sprite = wireActiveSprite;
				src.PlayOneShot (activateSFX);
				thePlatform.GetComponent<movementBehaviour> ().active = true;

				allowInteract = false;
				interactButton.SetActive (false);
				closeOtherPath.SetActive (true);
				objectiveText.GetComponent<Text> ().text = newObjective;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (!activated) {
			allowInteract = true;
			interactButton.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		allowInteract = false;
		interactButton.SetActive (false);
	}
}
