﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinballManager: MonoBehaviour  {

	public static PinballManager instance = null;

	bool paused;

	//Canvasses
	public GameObject pausePanel;
	public GameObject gameOverCanvas;
	public GameObject mainMenuCanvas;
	public GameObject scoreCanvas;
	public GameObject winCanvas;

	public BallScript ball;

	//Score and lifes.
	public Text scoreText;
	int score;
	static int coins = 13;
	int winScore = 10 * coins;
	public Text ballsText;
	int balls = 3;

	private List<GameObject> coinList = new List<GameObject>();

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start () {
		pausePanel.SetActive (false);
		gameOverCanvas.SetActive (false);
		scoreCanvas.SetActive (false);
		winCanvas.SetActive (false);
	}

	public void StartGame() {
		mainMenuCanvas.SetActive (false);
		scoreCanvas.SetActive (true);
		// Set coins.
	}

	public void GoToMainMenu() {
		winCanvas.SetActive (false);
		mainMenuCanvas.SetActive (true);
		RestartGame ();
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

	public void UpdateScore() {
		score += 10;
		scoreText.text = score + "";
		if (score == winScore) {
			winCanvas.SetActive (true);
			// Pause the ball.
		}
	}

	public void UpdateBalls() {
		balls--;
		if (balls == -1) {
			gameOverCanvas.SetActive (true);
			// Pause the ball.
		} else {
			ballsText.text = balls + "";
		}
	}

	public void RestartGame() {
		paused = false;
		pausePanel.SetActive (false);
		gameOverCanvas.SetActive (false);
		score = 0;
		balls = 3;
		scoreText.text = score + "";
		ballsText.text = balls + "";
		foreach (GameObject gameObj in coinList) {
			gameObj.SetActive (true);
			gameObj.GetComponent<MeshRenderer> ().enabled = true;
		}
	}

	public void addCoin(GameObject gameObj) {
		coinList.Add (gameObj);
	}
}
