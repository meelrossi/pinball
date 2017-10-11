using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	
	public AudioSource coinSound;

	void Start() {
		PinballManager.instance.addCoin (this.gameObject);
		coinSound = GetComponent<AudioSource> ();
	}

	public void OnTriggerEnter(Collider col) {
		if (col.CompareTag ("Ball")) {
			StartCoroutine (playSound());
		}
	}

	IEnumerator playSound(){
		coinSound.Play ();
		yield return new WaitForSeconds (0.15f);
		PinballManager.instance.UpdateScore ();
		this.gameObject.SetActive(false);
		GetComponent<MeshRenderer>().enabled = false;
	}
}
