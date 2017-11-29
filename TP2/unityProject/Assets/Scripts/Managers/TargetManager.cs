using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

	public static TargetManager instance = null;

	public GameObject target1;
	public GameObject target2;
	public GameObject target3;
	bool[] targets = new bool[]{false, false, false};
	bool allTargetsDown = false;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void targetDown(int id) {
		targets [id] = true;
		bool shouldBonus = !allTargetsDown;
		Debug.Log (id);
		for (int i = 0; i < targets.Length && shouldBonus; i++) {
			shouldBonus = shouldBonus && targets [i];
		}
		if (shouldBonus) {
			PinballManager.instance.startBigBonus ();
		}
	}

	public void resetValues() {
		for (int i = 0; i < targets.Length; i++) {
			targets [i] = false;
		}
		target1.SetActive (true);
		target2.SetActive (true);
		target3.SetActive (true);
	}
}
