using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTargetScript : MonoBehaviour {

	public float scoreValue = 100f;
	public int id;

	public void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Ball")) {
			gameObject.SetActive (false);
			PinballManager.instance.addScore (scoreValue);
			TargetManager.instance.targetDown (id);
		}
	}
}
