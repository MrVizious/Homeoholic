using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class InputController : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;
	[SerializeField]
	private PlayerController playerController;
	[SerializeField]
	private InputVisualizer inputVisualizer;
	[SerializeField]
	private PauseMenuController pauseMenuController;
	private List<string> inputs;
	public bool debug;

	private void Start() {
		inputs = new List<string>();
	}

	public void Update() {
		if (!levelController.PerformingAction && !pauseMenuController.IsGamePaused()) {
			if (Input.anyKeyDown) {
				// Key that has been pressed in the last frame
				string inputKey = Input.inputString.ToUpper();
				// If the input is valid as an action key and the number of inputs isn't more than allowed
				if (inputKey.Length == 1 && (ValidKey(inputKey) || inputKey.Equals(" ")) && inputs.Count < levelController.NumberOfActions) {

					inputs.Add(inputKey);
					inputVisualizer.AddLetter(inputKey);
					if (debug) {

						Debug.Log("Input *" + inputKey + "* was added to the list");

						string s = "";
						foreach (string current in inputs) {
							s += current;
						}

						Debug.Log("Letter added, current input list is: " + s);

					}
				}
				//Send inputs to PlayerController for it to start the actions
				if (Input.GetKeyDown(KeyCode.Return) && inputs.Count == levelController.NumberOfActions) {
					if (debug) Debug.Log("Calling StartActions from PlayerController");
					playerController.StartActions(inputs);
				}

				if (Input.GetKeyDown(KeyCode.Backspace) && inputs.Count > 0) {
					inputs.RemoveAt(inputs.Count - 1);
					inputVisualizer.DeleteLetter();

					if (debug) {
						string s = "";
						foreach (string current in inputs) {
							s += current;
						}
						Debug.Log("Letter removed, current input list is: " + s);
					}

				}
			}

			// TODO: Show Return button in UI if all the letters are full

		}
	}

	private bool ValidKey(string s) {
		return Regex.IsMatch(s, @"^[A-ZÑ]+$");
	}
}
