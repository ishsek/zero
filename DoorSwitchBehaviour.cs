using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSwitchBehaviour : MonoBehaviour {
	// Variables that are affected by door state
	public GameObject player;
	public GameObject door;
	public Sprite doorOpened;
	public GameObject interactSymbol;
	public GameObject interactResponse;
	public GameObject core;
	public GameObject jumpInstructObject;
	bool allowInteract;
	bool doorOpen;
	int doorInteractDelay;
	public GameObject objectiveText;
	public string getCoreText;
	public string enterFactoryText;
	public string openDoorText;


	// Audio variables
	public AudioClip doorOpenSFX;
	private AudioSource src;

	// Use this for initialization
	void Awake () {
		interactSymbol.SetActive (false);
		interactResponse.SetActive (false);
		core.SetActive (false);
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (doorInteractDelay > -1)
			doorInteractDelay--;

		// Door response to player interact key presses
		if (allowInteract && Input.GetKey(KeyCode.E) && doorInteractDelay <= 0) {
			// If player has enough cores to open the door, use the core and open door
			if (player.GetComponent<CoreTrackerScript> ().cores == 1 && doorOpen == false) {
				player.GetComponent<CoreTrackerScript> ().cores -= 1;
				interactResponse.SetActive (false);
				door.GetComponent<SpriteRenderer> ().sprite = doorOpened;
				doorOpen = true;
				interactSymbol.transform.Translate (new Vector3 (0.1f, 0f, 0f));
				src.PlayOneShot (doorOpenSFX);

				doorInteractDelay = 90;
				objectiveText.GetComponent<Text> ().text = enterFactoryText;
			} 
			// If door is open and player is in area, enter the factory to level 2
			else if (doorOpen && allowInteract && Input.GetKey(KeyCode.E) && doorInteractDelay <= 0) {
				Application.LoadLevel (3);
				doorInteractDelay = 90;
			}
			// If player does not have enough cores to open door
			else if (player.GetComponent<CoreTrackerScript>().cores == 0) {
				if (interactResponse != null) 
					interactResponse.SetActive (true);
				if (jumpInstructObject != null) 
					jumpInstructObject.SetActive (true);
				if (core != null)
					core.SetActive (true);

				doorInteractDelay = 90;
				objectiveText.GetComponent<Text> ().text = getCoreText;
			}
		}

		if (core == null && !doorOpen) {
			objectiveText.GetComponent<Text> ().text = openDoorText;
		}
	}

	// Draw the E button when player enters area
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			interactSymbol.SetActive (true);
			allowInteract = true;
		}
	}

	// Remove instructins when player leaves area
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			interactSymbol.SetActive (false);
			interactResponse.SetActive (false);
			allowInteract = false;
		}
	}
}
