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

	public BallScript ball;

	//Score and lifes.
	public Text scoreText;
	int score;
	static int coins = 11;
	int winScore = 10 * coins;
	public Text ballsText;
	int balls = 3;

	private List<GameObject> coinList = new List<GameObject>();

	Vector3 START_POSITION = new Vector3(2.75f, -1.033f, -3.42f);

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
	}

	public void StartGame() {
		mainMenuCanvas.SetActive (false);
		scoreCanvas.SetActive (true);
		// Set coins.
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

	public void UpdateScore() {
		score += 10;
		scoreText.text = score + "";
		if (score == winScore) {
			winCanvas.SetActive (true);
			ball.PauseBall (true);
			winSource.Play ();
		}
	}

	public void UpdateBalls() {
		balls--;
		if (balls == -1) {
			gameOverCanvas.SetActive (true);
			ball.PauseBall (true);
			loseSource.Play ();
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
		ball.transform.position = START_POSITION;
		ball.PauseBall (false);
	}

	public void ShowHelp() {
		mainMenuCanvas.SetActive (false);
		helpCanvas.SetActive (true);
	} 

	public void addCoin(GameObject gameObj) {
		coinList.Add (gameObj);
	}
}
