using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	bool paused = false;
	public GameObject pauseButton;

	private Button sr;

	void Start () {
		gameObject.SetActive (false);
	}

	public void PauseGame() {
		if (!paused) {
			paused = true;
			gameObject.SetActive (true);
		} else {
			paused = false;
			gameObject.SetActive (false);
		}
	}

	public void RestartGame() {
		gameObject.SetActive (false);
		paused = false;
	}
}