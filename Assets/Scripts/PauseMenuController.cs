using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
	private bool isPaused = false;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	}
}
