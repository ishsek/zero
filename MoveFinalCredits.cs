using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFinalCredits : MonoBehaviour {
	public float creditsSpeed;
	public int durationInSeconds;

	// Use this for initialization
	void Awake () {
		durationInSeconds *= 60;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (0f, creditsSpeed));

		durationInSeconds--;
		if (durationInSeconds <= 0) {
			Application.LoadLevel (0);
		}
	}
}
