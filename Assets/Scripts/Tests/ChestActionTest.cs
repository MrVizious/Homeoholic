using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestActionTest : Action {

	public override bool PerformAction(string s) {
		Debug.Log("Esto es un cofre!");
		return true;
	}
}
