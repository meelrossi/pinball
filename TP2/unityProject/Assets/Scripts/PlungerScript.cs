using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour {
	float power;
	float minPower = 0f;
	public float maxPower = 100f;
	public Slider powerSlider;
	List<Rigidbody> ballList =  new List<Rigidbody>();
	bool ballReady;

	// Use this for initialization
	void Start () {
		powerSlider.minValue = 0f;
		powerSlider.maxValue = maxPower;
	}
	
	// Update is called once per frame
	void Update () {

		if (ballReady) {
			powerSlider.gameObject.SetActive (true);
		} else {
			powerSlider.gameObject.SetActive (false);
		}

		powerSlider.value = power;
		if (ballList.Count > 0) {
			ballReady = true;
			if (Input.GetKey (KeyCode.Space)) {
				if (power <= maxPower) {
					power += 50f * Time.deltaTime;
				}
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				foreach (Rigidbody r in ballList) {
					r.AddForce (power * Vector3.forward);
				}
			}
		} else {
			ballReady = false;
			power = 0f;
		}
	}

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Ball")) {
			ballList.Add (other.gameObject.GetComponent<Rigidbody>());
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Ball")) {
			ballList.Remove (other.gameObject.GetComponent<Rigidbody> ());
			power = 0f;
		}
	}
}
