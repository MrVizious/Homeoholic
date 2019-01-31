using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

	private Action action;
	public bool doesntHaveAction;
	public bool debug;
	private void Start() {
		if (debug) StartChecks();
		action = GetComponent<Action>();
	}

	public bool PerformAction(string s) {
		return action.PerformAction(s);
	}


	private void StartChecks() {
		if (!doesntHaveAction && GetComponent<Action>() == null) {
			Debug.Log("There is no action for object " + name + ". Should it have one?", this);
		}
	}

	// TODO: Implement ShowLetter method that is called in Update and generates a circle of coliision to see if the player enters in it, and
	// then show the letters of the actions
}
