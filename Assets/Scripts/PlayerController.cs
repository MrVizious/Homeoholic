using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;

	[SerializeField]
	private List<string> actions;


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
		foreach (string current in actions) {
			//Wait in case something is still running
			yield return new WaitUntil(() => levelController.PerformingAction == false);
			//If the action is a movement keys (WASD), the movement action is called
			if (IsMovementKey(current)) {
				GetComponent<Move>().PerformMove(current);
			}

			//If the action is a " " (spacebar), it means it is a pause
			else if (current.Equals(" ")) {
				// TODO: Pause action
			}

			// If it is not a move actionor a pause, a list of all the interactionable elements around is obtained, and their performAction methods are called
			else {
				List<Element> elementsAround = GetElementsAround();
				//This variable checks if the player succesfully performed any action
				bool actionPerformed = false;

				foreach (Element element in elementsAround) {
					//Two waits for the action to stop being performed, just in case
					yield return new WaitUntil(() => !levelController.PerformingAction);
					if (element.PerformAction(current)) actionPerformed = true;
					yield return new WaitUntil(() => !levelController.PerformingAction);
				}

				if (!actionPerformed) {
					//TODO: Start action of showing an interrogation or something to indicate that no action was performed
				}
			}
			//Wait in case something is still running
			yield return new WaitUntil(() => !levelController.PerformingAction);
		}
		actions.Clear();

		// levelController.PerformingAction = true;
		// Debug.Log("Waiting for castle to open... Press esc. Right now, PerformingAction is: " + levelController.PerformingAction);
		// while (levelController.PerformingAction == true) {
		// 	yield return new WaitForSeconds(0.05f);
		// }
		// levelController.PerformingAction = false;
		// Debug.Log("The castle opened! Just shout for the princess to come out... . Right now, PerformingAction is: " + levelController.PerformingAction);

		// levelController.PerformingAction = true;
		// while (levelController.PerformingAction == true) {
		// 	yield return new WaitForSeconds(0.05f);
		// }
		// Debug.Log("The preincess went out of the castle... Very well done");
		// yield return null;
	}

	private List<Element> GetElementsAround() {

		List<Element> elementsAround = new List<Element>();

		// Checking for elements up
		//(W)
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f);
		Element up = hit.collider.gameObject.GetComponent<Element>();
		if (up != null) elementsAround.Add(up);

		// Checking for elements left
		//(A)
		hit = Physics2D.Raycast(transform.position, Vector2.left, 1f);
		Element left = hit.collider.gameObject.GetComponent<Element>();
		if (left != null) elementsAround.Add(left);

		// Checking for elements down
		//(S)
		hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
		Element down = hit.collider.gameObject.GetComponent<Element>();
		if (down != null) elementsAround.Add(down);

		// Checking for elements right
		//(D)
		hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
		Element right = hit.collider.gameObject.GetComponent<Element>();
		if (right != null) elementsAround.Add(right);

		return elementsAround;

	}

	private bool IsMovementKey(string s) {
		return Regex.IsMatch(s, @"^[wasdWASD]+$");
	}
}