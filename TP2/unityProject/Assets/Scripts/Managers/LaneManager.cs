using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour {

	public static LaneManager instance = null;

	public GameObject laneDoor;
	public LaneScript lane1;
	public LaneScript lane2;
	public LaneScript lane3;

	bool[] lane = new bool[]{false, false, false};
	bool allTargetsDown = false;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void lanePass(int id) {
		lane [id] = true;
		bool shouldOpen = true;
		for (int i = 0; i < lane.Length && shouldOpen; i++) {
			shouldOpen = shouldOpen && lane [i];
		}
		if (shouldOpen) {
			laneDoor.SetActive (false);
		}
	}

	public void resetValues() {
		for (int i = 0; i < lane.Length; i++) {
			lane [i] = false;
		}
		lane1.resetValue ();
		lane2.resetValue ();
		lane3.resetValue ();
	}
}
