using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	Vector3 START_POSITION = new Vector3(2.75f, -1.033f, -3.42f);

	public void OnTriggerEnter(Collider col) {
		GameObject ball = col.gameObject;

		ball.transform.position = START_POSITION;
	}
}
