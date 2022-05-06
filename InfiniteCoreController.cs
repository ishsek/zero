using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteCoreController : MonoBehaviour {
	public GameObject infinite;
	public Sprite infiniteDeactive;
	public GameObject core1, core2, core3, core4;
	public GameObject myCorePic;
	public AudioClip deactivateSFX;
	AudioSource src;
	bool played;
	public Sprite deadWire;
	public GameObject wire1, wire2, wire3, wire4, wire5, wire6;
	public GameObject objectiveText;
	public string newObjective;

	// Use this for initialization
	void Awake () {
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (core1 == null && core2 == null && core3 == null && core4 == null) {
			if (!played) {
				src.PlayOneShot (deactivateSFX);
				DisableWires ();
				Destroy (myCorePic);
				infinite.GetComponent<SpriteRenderer> ().sprite = infiniteDeactive;
				played = true;
				objectiveText.GetComponent<Text> ().text = newObjective;
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
}
