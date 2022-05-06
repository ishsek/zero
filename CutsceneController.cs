using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour {
	public GameObject player;
	public GameObject zeroDialogue;
	public GameObject infiniteDialogue;
	bool beginAnimations;
	int sceneCounter;
	public GameObject blocker;
	public GameObject cam;
	public GameObject cutsceneCam;
	public GameObject objectiveText;
	public string newObjective;

	// Use this for initialization
	void Awake () {
		zeroDialogue.SetActive (false);
		infiniteDialogue.SetActive (false);
		sceneCounter = 0;
		cutsceneCam.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (beginAnimations) {
			sceneCounter++;
			if (sceneCounter == 5) {
				player.GetComponent<PlayerController> ().allowControl = false;
				player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				cam.SetActive (false);
				cutsceneCam.SetActive (true);
				zeroDialogue.SetActive (true);
				Debug.Log ("Part 1");
			} else if (sceneCounter == 60 * 4) {
				zeroDialogue.SetActive (false);
				infiniteDialogue.SetActive (true);
				Debug.Log ("Part 2");
			} else if (sceneCounter == 60 * 18) {
				infiniteDialogue.SetActive (false);
				blocker.SetActive (false);
				Debug.Log ("Part 3");
			} else if (sceneCounter == 60 * 20) {
				blocker.SetActive (true);
				cam.SetActive (true);
				cutsceneCam.SetActive (false);
				Debug.Log ("Part 4");
				player.GetComponent<PlayerController> ().allowControl = true;
				objectiveText.GetComponent<Text> ().text = newObjective;
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			beginAnimations = true;
		}
	}
}
