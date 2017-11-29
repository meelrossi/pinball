using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	public Light light;
	public float score = 0.0f;

	void Start () {
		light.gameObject.SetActive (false);
	}
	
	public void OnTriggerEnter(Collider col) {
		if (col.CompareTag ("Ball")) {
			light.gameObject.SetActive (true);
		}
	}

	public void OnTriggerExit(Collider col) {
		if (col.CompareTag ("Ball")) {
			light.gameObject.SetActive (false);
			PinballManager.instance.addScore (score);
		}
	}
}
