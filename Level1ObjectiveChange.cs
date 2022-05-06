using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1ObjectiveChange : MonoBehaviour {
	public GameObject objectiveText;
	public string useCoreText;
	public GameObject core;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (core == null) {
			objectiveText.GetComponent<Text> ().text = useCoreText;
			Destroy (gameObject);
		}
	}
}
