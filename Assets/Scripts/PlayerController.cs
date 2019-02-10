using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;

	[SerializeField]
	private List<string> actions;
	[SerializeField]
	private InputVisualizer inputVisualizer;
	private int layerMask;
	public bool debug;


	private void Start() {
		layerMask = 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("ElementWithCollision") | 1 << LayerMask.NameToLayer("ElementWithoutCollision") | 1 << LayerMask.NameToLayer("NPC");
	}

	/// <summary>
	/// This function receives a List with the names 
	/// </summary>
	/// <param name="actions"></param>
	public void StartActions(List<string> newActions) {
		actions = newActions;
		StartCoroutine("PerformActions");
	}


	/// <summary>
	/// A coroutine that executes the actions given in a string of inputs.
	/// </summary>
	/// <remarks>
	/// This coroutine goes one by one checking wether the input is a movement string or not. If it is,
	/// the routine calls the movement action of the player. If it isn't, all of the elements in front,
	/// behind and on the sides of the player are given the input so they can either use it or not, depending on
	/// wether it is a valid input for them.
	///</remarks> 
	/// <param name="actions">A list of strings containing the inputs given by the player</param>
	/// <returns></returns>
	private IEnumerator PerformActions() {
		int i = 0;
		foreach (string current in actions) {
			bool actionPerformed = false;
			inputVisualizer.HighlightLetter(i);

			//Wait in case something is still running
			yield return new WaitUntil(() => !levelController.PerformingAction);
			//If the action is a movement keys (WASD), the movement action is called
			if (IsMovementKey(current)) {
				actionPerformed = GetComponent<Move>().PerformMove(current);
				if (!actionPerformed && debug) Debug.Log("Couldn't move, an obstacle was found");
			}

			//If the action is a " " (spacebar), it means it is a stall
			else if (current.Equals(" ")) {
				// TODO: Stall action
				actionPerformed = true;
				if (debug) Debug.Log("Pause action performed");
			}

			// If it is not a move action or a pause, a list of all the interactionable elements around is obtained, and their performAction methods are called
			else {

				List<Element> elementsAround = GetElementsAround();
				//This variable checks if the player succesfully performed any action


				foreach (Element element in elementsAround) {
					//Two waits for the action to stop being performed, just in case
					yield return new WaitUntil(() => !levelController.PerformingAction);
					if (element.PerformAction(current)) actionPerformed = true;
					yield return new WaitUntil(() => !levelController.PerformingAction);
				}

				if (!actionPerformed) {
					//TODO: Start action of showing an interrogation or something to indicate that no action was performed
					if (debug) Debug.Log("No element around with activation key " + current);
				}
			}
			if (!actionPerformed) {
				// TODO: No action performed interrogation sign
				yield return new WaitForSeconds(1f);
				if (debug) Debug.Log("No action could be performed!");
			}

			//Wait in case something is still running
			yield return new WaitUntil(() => !levelController.PerformingAction);
			inputVisualizer.StopHighlightLetter(i);
			inputVisualizer.DeHighlightLetter(i);

			i++;
		}
		// TODO: Decide whether to clear the inputs after executing it or not
		actions.Clear();
	}

	private List<Element> GetElementsAround() {

		List<Element> elementsAround = new List<Element>();
		//This starts to Vector2.up just to avoid compilation problems
		Vector2 directionVector = Vector2.up;
		for (int i = 0; i < 4; i++) {
			switch (i) {
				case 0:
					directionVector = Vector2.up;
					break;
				case 1:
					directionVector = Vector2.left;
					break;
				case 2:
					directionVector = Vector2.down;
					break;
				case 3:
					directionVector = Vector2.right;
					break;
				default:
					if (debug) Debug.Log("A wrong direction was sent to GetElementsAround in PLayerController", this);
					break;

			}
			RaycastHit2D hit = Physics2D.Raycast(transform.position, directionVector, 1f, layerMask);
			if (hit.collider != null) {
				Element element = hit.collider.gameObject.GetComponent<Element>();
				if (element != null) elementsAround.Add(element);
			}
		}
		return elementsAround;
	}

	private bool IsMovementKey(string s) {
		return Regex.IsMatch(s, @"^[wasdWASD]+$");
	}
}