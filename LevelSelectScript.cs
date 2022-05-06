using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectScript : MonoBehaviour {
	public int level;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void  ButtonClicked() {
		if (level >= 0 && level <= 7) {
			Application.LoadLevel (level);
		} else if (level == 8) {
			Application.Quit();
		}
	}
}
