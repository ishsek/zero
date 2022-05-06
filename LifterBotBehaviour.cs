using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifterBotBehaviour : MonoBehaviour {
	// Objects requiring scripting with interaction
	public Sprite activatedSprite;
	public GameObject player;
	public GameObject interactButton;
	public GameObject requiresCoreText;
	public GameObject responseDialogue;
	public GameObject blockingPillar;
	public GameObject pillarToTopFloor;
	bool ventMoved;
	bool activated;
	bool allowInteract;
	int responseDuration;
	public AudioClip ventSFX;
	public AudioClip activatedSFX;
	private AudioSource src;
	public GameObject objectiveText;
	public string findCoreText;

	// Use this for initialization
	void Start () {
		interactButton.SetActive (false);
		requiresCoreText.SetActive (false);
		responseDialogue.SetActive (false);
		responseDuration = 60 * 8;
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if player presses E and is in area and robot is not active yet
		if (allowInteract && Input.GetKeyDown (KeyCode.E) && !activated) {
			// If player has core, then use it on robot
			if (player.GetComponent<CoreTrackerScript> ().cores >= 1) {
				GetComponent<SpriteRenderer> ().sprite = activatedSprite;
//				transform.Translate (new Vector2 (0, 1));
				activated = true;
				src.PlayOneShot (activatedSFX);
				player.GetComponent<CoreTrackerScript> ().cores--;
			} else { // If player doens't have core then give response text
				requiresCoreText.SetActive (true);
				objectiveText.GetComponent<Text> ().text = findCoreText;
				if (!ventMoved) {
					pillarToTopFloor.transform.Translate (new Vector2 (-4, -3));
					pillarToTopFloor.transform.Rotate (new Vector3 (0, 0, 85));
					src.PlayOneShot (ventSFX);
					ventMoved = true;
				}
			}
		} else if (activated && responseDuration > 0) { // If robot is activated, then animate it
			requiresCoreText.SetActive (false);
			interactButton.SetActive (false);
			responseDialogue.SetActive (true);
			responseDuration--;
		} else if (activated && responseDuration <= 0) { // Stop animation and remove blocking pillar
			responseDialogue.SetActive (false);
			blockingPillar.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (!activated) {
				interactButton.SetActive (true);
				allowInteract = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			interactButton.SetActive (false);
			requiresCoreText.SetActive (false);
			allowInteract = false;
		}
	}
}
