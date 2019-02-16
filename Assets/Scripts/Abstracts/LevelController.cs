using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelController : MonoBehaviour {

	public bool PerformingAction;
	public int NumberOfActions;
	public bool debug;

	[SerializeField]
	protected InputController inputController;

	[SerializeField]
	protected InputVisualizer inputVisualizer;

	[SerializeField]
	protected PlayerController playerController;

	[SerializeField]
	protected PauseMenuController pauseMenuController;

	protected void Start() {
		if (NumberOfActions <= 0) Debug.LogError("Number of actions can't be less than one!", this);
	}

	public InputController getInputController() {
		return this.inputController;
	}
	public InputVisualizer getInputVisualizer() {
		return this.inputVisualizer;
	}
	public PlayerController getPlayerController() {
		return this.playerController;
	}
	public PauseMenuController getPauseMenuController() {
		return this.pauseMenuController;
	}

}
