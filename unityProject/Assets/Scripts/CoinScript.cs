using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	void Start() {
		PinballManager.instance.addCoin (this.gameObject);
	}

	public void OnTriggerEnter(Collider col) {
		if (col.CompareTag ("Ball")) {
			//Destroy (this.gameObject);
			this.gameObject.SetActive(false);
			GetComponent<MeshRenderer>().enabled = false;
			PinballManager.instance.UpdateScore ();
		}
	}
}
