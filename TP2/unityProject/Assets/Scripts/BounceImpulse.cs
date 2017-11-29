using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceImpulse : MonoBehaviour {

	public float POWER = 1.2f;
	public Light myLight;
	int count = 0;
	public int id;
	public AudioSource bounceSound;
	public float scoreValue = 10f;

	// Use this for initialization
	void Start () {
		myLight.intensity = 10;
		myLight.enabled = false;
		myLight.gameObject.SetActive (true);
		bounceSound = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (myLight.enabled) {
			count++;
			if (count > 15) {
				count = 0;
				myLight.enabled = false;
			}
		}
	}

	public void OnTriggerEnter(Collider col) {
		if (col.CompareTag ("Ball")) {
			GameObject ball = col.gameObject;

			var force = transform.position - col.transform.position;
			force = force.normalized;

			ball.GetComponent<Rigidbody> ().AddForce (-POWER * force);
			myLight.enabled = true;
			bounceSound.Play ();
			PinballManager.instance.addScore (scoreValue);
			BouncerManager.instance.bounceApply (id);
		}
	}
}
