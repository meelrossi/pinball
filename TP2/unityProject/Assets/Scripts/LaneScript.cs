using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneScript: MonoBehaviour {

	public int idNumber;

	public void OnTriggerExit(Collider col) {
		if (col.CompareTag ("Ball")) {
			LaneManager.instance.lanePass (idNumber);
			GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.green);
		}
	}

	public void resetValue() {
		GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.red);
	}
}
