using System.Collections;
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
	public GameObject helpCanvas;
	public GameObject bonusSprite;
	public GameObject bigBonusSprite;
	public GameObject openSprite;

	public BallScript ball;

	//Score and lifes.
	public Text scoreText;
	float score;
	public Text ballsText;
	int balls = 3;
	float multiplier = 1;
	float delta = 10;
	bool isBonus = false;

	Vector3 START_POSITION = new Vector3(3.81f, -0.52f, -0.04f);

	AudioSource winSource;
	AudioSource loseSource;

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
		winSource = winCanvas.GetComponent<AudioSource> ();
		loseSource = gameOverCanvas.GetComponent<AudioSource> ();
		bonusSprite.SetActive (false);
		bigBonusSprite.SetActive (false);
		openSprite.SetActive (false);
	}

	public void StartGame() {
		mainMenuCanvas.SetActive (false);
		scoreCanvas.SetActive (true);
	}

	public void GoToMainMenu() {
		helpCanvas.SetActive (false);
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

	public void UpdateBalls() {
		balls--;
		if (balls == 0) {
			gameOverCanvas.SetActive (true);
			ball.PauseBall (true);
			loseSource.Play ();
		} else {
			ballsText.text = balls + "";
			BouncerManager.instance.resetValues ();
		}
	}

	public void RestartGame () {
		paused = false;
		pausePanel.SetActive (false);
		gameOverCanvas.SetActive (false);
		score = 0;
		balls = 3;
		scoreText.text = score + "";
		ballsText.text = balls + "";
		ball.transform.position = START_POSITION;
		ball.PauseBall (false);
		LaneManager.instance.resetValues ();
		BouncerManager.instance.resetValues ();
		TargetManager.instance.resetValues ();
	}

	public void ShowHelp () {
		mainMenuCanvas.SetActive (false);
		helpCanvas.SetActive (true);
	}
			
	public void addScore (float value) {
		score += value * multiplier;
		scoreText.text = score + "";
	}

	public void startBonus () {
		if (!isBonus) {
			StartCoroutine (BonusTime(10.0f, bonusSprite, 0.5f));
		}
	}

	public void startBigBonus() {
		if (!isBonus) {
			StartCoroutine (BonusTime (20.0f, bigBonusSprite, 5.0f));
		}
	}

	public IEnumerator BonusTime (float duration, GameObject sprite, float addition) {
		multiplier  += addition;
		sprite.SetActive (true);
		isBonus = true;
		yield return new WaitForSeconds (duration);
		multiplier -= addition;
		sprite.SetActive (false);
		isBonus = false;
	}
}
 