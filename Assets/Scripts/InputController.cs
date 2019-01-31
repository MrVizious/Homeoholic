using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class InputController : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;
	public void Update() {
		if (!levelController.PerformingAction) {
			if (Input.anyKeyDown) {

				string inputKey = Input.inputString;

				if (inputKey.Length == 1 && (ValidKey(inputKey) || inputKey.Equals(" "))) {
					//TODO: Add letter
				}

			}
			if (Input.GetKeyDown(KeyCode.Return)) {
				//TODO: Start Actions Routine
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			//TODO: Pause menu
		}

	}

	private bool ValidKey(string s) {
		return Regex.IsMatch(s, @"^[a-zA-Z]+$");
	}
}
