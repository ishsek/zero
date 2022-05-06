using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreRotator : MonoBehaviour {
	float amount;

	// Use this for initialization
	void Start () {
		amount = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3 (transform.rotation.x, transform.rotation.y, amount));
	}
}
