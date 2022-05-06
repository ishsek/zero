using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserSystemScript : MonoBehaviour {
	bool activated;
	bool allowInteract;
	public GameObject player;
	public Sprite disabledSprite;
	public GameObject interactButton;
	public AudioClip collectSFX;
	AudioSource src;

	public GameObject wire1, wire2, wire3, wire4, wire5, wire6, wire7, wire8, wire9;
	public Sprite wireSprite;
	public GameObject laser, blocker;

	public GameObject objectiveText;
	public string useCoreObjective;

	// Use this for initialization
	void Awake () {
		activated = true;
		interactButton.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			if (allowInteract && Input.GetKeyDown (KeyCode.E)) {
				activated = false;
				interactButton.SetActive (false);
				GetComponent<SpriteRenderer> ().sprite = disabledSprite;
				player.GetComponent<CoreTrackerScript> ().cores++;
				src.PlayOneShot (collectSFX);

				wire1.GetComponent<SpriteRenderer> ().sprite = wireSprite;
				wire2.GetComponent<SpriteRenderer> ().sprite = wireSprite;
				wire3.GetComponent<SpriteRenderer> ().sprite = wireSprite;
				wire4.GetComponent<SpriteRenderer> ().sprite = wireSprite;
				wire5.GetComponent<SpriteRenderer> ().sprite = wireSprite;
				wire6.GetComponent<SpriteRenderer> ().sprite = wireSprite;
				wire7.GetComponent<SpriteRenderer> ().sprite = wireSprite;
				wire8.GetComponent<SpriteRenderer> ().sprite = wireSprite;
				wire9.GetComponent<SpriteRenderer> ().sprite = wireSprite;

				laser.SetActive (false);
				blocker.transform.Translate (new Vector3 (0, -3, 0));

				objectiveText.GetComponent<Text> ().text = useCoreObjective;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (activated && other.tag == "Player") {
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
