using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCoresScript : MonoBehaviour {
	public GameObject player;
	public GameObject firstCore, secondCore, thirdCore, fourthCore;

	// Use this for initialization
	void Awake () {
		if (firstCore != null)
			firstCore.SetActive (false);
		if (secondCore != null)
			secondCore.SetActive (false);
		if (thirdCore != null)
			thirdCore.SetActive (false);
		if (fourthCore != null)
			fourthCore.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<CoreTrackerScript> ().cores == 0) {
			if (firstCore!= null) firstCore.SetActive (false);
			if (secondCore!= null) secondCore.SetActive (false);
			if (thirdCore!= null) thirdCore.SetActive (false);
			if (fourthCore!= null) fourthCore.SetActive (false);
		} else if (player.GetComponent<CoreTrackerScript> ().cores == 1) {
			if (firstCore!= null) firstCore.SetActive (true);
			if (secondCore!= null) secondCore.SetActive (false);
			if (thirdCore!= null) thirdCore.SetActive (false);
			if (fourthCore!= null) fourthCore.SetActive (false);
		} else if (player.GetComponent < CoreTrackerScript> ().cores == 2) {
			if (firstCore!= null)firstCore.SetActive (true);
			if (secondCore!= null)secondCore.SetActive (true);
			if (thirdCore!= null)thirdCore.SetActive (false);
			if (fourthCore!= null)fourthCore.SetActive (false);
		} else if (player.GetComponent<CoreTrackerScript> ().cores == 3) {
			if (firstCore!= null)firstCore.SetActive (true);
			if (secondCore!= null)secondCore.SetActive (true);
			if (thirdCore!= null)thirdCore.SetActive (true);
			if (fourthCore!= null)fourthCore.SetActive (false);
		} else if (player.GetComponent<CoreTrackerScript> ().cores == 4) {
			if (firstCore!= null)firstCore.SetActive (true);
			if (secondCore!= null)secondCore.SetActive (true);
			if (thirdCore!= null)thirdCore.SetActive (true);
			if (fourthCore!= null)fourthCore.SetActive (true);
		}
		
//		if (firstCore != null) {
//			if (player.GetComponent<CoreTrackerScript> ().cores == 1) {
//				firstCore.SetActive (true);
//			} else {
//				firstCore.SetActive (false);
//			}
//		}
//
//		if (secondCore != null) {
//			if (player.GetComponent<CoreTrackerScript> ().cores == 2) {
//				secondCore.SetActive (true);
//			} else {
//				secondCore.SetActive (false);
//			}
//		}
//
//		if (thirdCore != null) {
//			if (player.GetComponent<CoreTrackerScript> ().cores == 3) {
//				thirdCore.SetActive (true);
//			} else {
//				thirdCore.SetActive (false);
//			}
//		}
//
//		if (fourthCore != null) {
//			if (player.GetComponent<CoreTrackerScript> ().cores == 4) {
//				fourthCore.SetActive (true);
//			} else {
//				fourthCore.SetActive (false);
//			}
//		}
	}
}
