using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueCutsceneSequencer : MonoBehaviour {
	// Variables that require animation
	int sequenceTimer;
	public GameObject scientistDial1;
	public GameObject scientistDial2;
	public GameObject zeroDial1;
	public GameObject zero;
	public Sprite zeroDeactive;
	public GameObject fader;
	float faderAlpha;

	private AudioSource src;
	public AudioClip deactivSFX;
	bool zeroMoved;
	bool audioPlayed;

	// Use this for initialization
	void Awake () {
		sequenceTimer = 0;
		scientistDial1.SetActive (false);
		scientistDial2.SetActive (false);
		zeroDial1.SetActive (false);

		src = GetComponent<AudioSource> ();
		faderAlpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
		sequenceTimer++;

		if (sequenceTimer >= 60 * 27) { // End scene
			Application.LoadLevel (2);
		} else if (sequenceTimer >= 60 * 20) { // Fade out of scene
			if (faderAlpha < 1f) {
				faderAlpha += 0.005f;
				fader.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, faderAlpha);
			}
		} else if (sequenceTimer >= 60 * 17) { // deactive zero
			scientistDial2.SetActive (false);
			Destroy (zero.GetComponent<Animator> ());
			zero.GetComponent<SpriteRenderer> ().sprite = zeroDeactive;
			if (!zeroMoved) {
				zero.transform.Translate (new Vector3 (0f, -0.39f, 0f));
				zeroMoved = true;
			}
			if (!audioPlayed) {
				src.PlayOneShot (deactivSFX);
				audioPlayed = true;
			}
		} else if (sequenceTimer >= 60 * 13) { // Show scientist final dialogue
			zeroDial1.SetActive (false);
			scientistDial2.SetActive (true);
		} else if (sequenceTimer >= 60 * 11) { // Show zero response
			scientistDial1.SetActive (false);
			zeroDial1.SetActive (true);
		} else if (sequenceTimer >= 60 * 3) { // Show scientist dialogue
			scientistDial1.SetActive (true);
		} else {                              // Start by fading in
			if (faderAlpha > 0f) {
				faderAlpha -= 0.005f;
				fader.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, faderAlpha);
			}
		}
	}
}
