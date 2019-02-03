using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestActionTest : Action {

	public override bool PerformAction(string s) {
		Debug.Log("This is a chest!");
		return true;
	}
}
