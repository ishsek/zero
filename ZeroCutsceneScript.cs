using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroCutsceneScript : MonoBehaviour {
	public GameObject text; // Intro dialogue box
	public GameObject player;
	public GameObject lightning;
	public AudioClip lightningSFX;
	private AudioSource src;
	int lightningCountdown = 60 * 2;
	int lightningRemovalCountdown = 60 * 3;
	int dialogueCountdown = 60 * 5;
	int playTime = 60 * 10;
	public GameObject objective;

	// Use this for initialization
	void Awake () {
		if (text != null)
			text.SetActive (false);
		if (player != null)
			player.SetActive (false);
		if (lightning != null)
			lightning.SetActive (false);
		src = GetComponent<AudioSource> ();
		objective.SetActive (false);
		GetComponent<Animator> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		// Countdown each cutscene section
		lightningCountdown--;
		lightningRemovalCountdown--;
		dialogueCountdown--;
		playTime--;

		// set activity for cutscene objects
		if (lightningCountdown <= 0) {
			lightning.SetActive (true);
			src.PlayOneShot (lightningSFX);
			lightningCountdown = 60 * 60;
		} else if (lightningRemovalCountdown <= 0) {
			lightning.SetActive (false);
			GetComponent<Animator>().enabled = true;
			transform.Translate(new Vector3(0f, 0.4f, 0f));
			lightningRemovalCountdown = 60 * 60;
		} else if (dialogueCountdown <= 0) {
			text.SetActive (true);
			dialogueCountdown = 60 * 60;
		} else if (playTime <= 0) {
			player.SetActive (true);
			Destroy (gameObject);
			objective.SetActive (true);
		}
	}
}
