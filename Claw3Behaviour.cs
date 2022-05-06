using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Claw3Behaviour : MonoBehaviour {
	public GameObject player;
	public Sprite activeSprite;
	public GameObject firstPort;
	public GameObject secondPort;
	bool allowInteract;
	public GameObject interactButton;
	bool activated;
	public GameObject wire;
	public Sprite wireActive;
	public GameObject firstClaw;
	public GameObject secondClaw;
	public Sprite deactiveClaw;
	public GameObject pathCloser;

	public AudioClip useSFX;
	AudioSource src;

	public GameObject objectiveText;
	public string newObjective;

	// Use this for initialization
	void Awake() {
		interactButton.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (allowInteract && Input.GetKeyDown (KeyCode.E)) {
			
			if (player.GetComponent<CoreTrackerScript> ().cores >= 2) {
				player.GetComponent<CoreTrackerScript> ().cores -= 2;
				firstPort.GetComponent<SpriteRenderer> ().sprite = activeSprite;
				secondPort.GetComponent<SpriteRenderer> ().sprite = activeSprite;
				src.PlayOneShot (useSFX);
				wire.GetComponent<SpriteRenderer> ().sprite = wireActive;
				firstClaw.GetComponent<SpriteRenderer> ().sprite = deactiveClaw;
				firstClaw.transform.Translate (new Vector3 (0f, 1.5f, 0f));
				firstClaw.GetComponent<BoxCollider2D> ().isTrigger = true;
				secondClaw.GetComponent<SpriteRenderer> ().sprite = deactiveClaw;
				secondClaw.transform.Translate (new Vector3 (0f, 1.5f, 0f));
				secondClaw.GetComponent<BoxCollider2D> ().isTrigger = true;
				pathCloser.SetActive (true);

				objectiveText.GetComponent<Text> ().text = newObjective;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" && !activated) {
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
