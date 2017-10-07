using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	public void OnTriggerEnter(Collider col) {
		if (col.CompareTag ("Ball")) {
			Destroy (this.gameObject);
		}
	}
}
