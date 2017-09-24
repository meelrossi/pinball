using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			Impluse ();
		}
	}

	void Impluse()
	{
		GetComponent<Rigidbody>().AddForce(-transform.up * 30, ForceMode.Impulse);
		GetComponent<Rigidbody>().useGravity = true;
	}
}
