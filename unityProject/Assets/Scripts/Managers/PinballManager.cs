using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballManager: MonoBehaviour  {
	static PinballManager instance = null;

	bool paused;
	public GameObject pausePanel;

	public BallScript ball;

	int score;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start () {
		pausePanel.SetActive (false);
	}

	public void PauseGame() {
		paused = !paused;
		if (paused) {
			pausePanel.SetActive (true);
		} else {
			pausePanel.SetActive (false);
		}
		ball.PauseBall (paused);
	}
}
