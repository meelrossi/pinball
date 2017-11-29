using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	Vector3 START_POSITION = new Vector3(3.89f, -1.586f, -3.112f);

	public void OnTriggerEnter(Collider col) {
		GameObject ball = col.gameObject;

		ball.transform.position = START_POSITION;
		PinballManager.instance.UpdateBalls ();
	}
}
