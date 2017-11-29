using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
	Vector3 savedVelocity;
	Vector3 savedAngularVelocity;

	public void PauseBall(bool paused) {
		Rigidbody ball = GetComponent<Rigidbody> ();
		if (paused) {
			savedVelocity = ball.velocity;
			savedAngularVelocity = ball.angularVelocity;
			ball.isKinematic = true;
		} else {
			// un-paused
			ball.isKinematic = false;
			ball.velocity = savedVelocity;
			ball.angularVelocity = savedAngularVelocity;
			ball.WakeUp();
		}
	}
}
