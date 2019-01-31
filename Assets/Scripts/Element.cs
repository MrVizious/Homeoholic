using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

	private Action action;
	public bool doesntHaveAction;
	private void Start() {
		StartChecks();
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
}
