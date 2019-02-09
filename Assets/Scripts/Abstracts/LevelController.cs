using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelController : MonoBehaviour {

	public bool PerformingAction;
	public int NumberOfActions;
	public bool debug;
	protected void Start() {
		if (NumberOfActions <= 0) Debug.LogError("Number of actions can't be less than one!", this);
		if (debug) {

		}
	}

}
