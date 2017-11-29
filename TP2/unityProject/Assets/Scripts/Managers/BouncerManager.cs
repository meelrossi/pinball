using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerManager : MonoBehaviour {

	public static BouncerManager instance = null;

	public bool[] bouncers = new bool[]{ false, false, false, false };

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void bounceApply (int id){
		bouncers [id] = true;
		bool shouldBonus = true;
		for (int i = 0; i < bouncers.Length && shouldBonus; i++) {
			shouldBonus = shouldBonus && bouncers [i];
		}
		if (shouldBonus) {
			PinballManager.instance.startBonus ();
			for (int j = 0; j < bouncers.Length; j++) {
				bouncers [j] = false;
			}
		}
	}

	public void resetValues () {
		for (int i = 0; i < bouncers.Length; i++) {
			bouncers [i] = false;
		}
	}
}
