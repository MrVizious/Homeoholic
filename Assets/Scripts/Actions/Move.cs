using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;
	private Vector2 target;
	public bool debug;
	public bool PerformMove(string s) {
		switch (s) {
			case "W":
			case "w":
				return MoveUp();
			case "A":
			case "a":
				return MoveLeft();
			case "S":
			case "s":
				return MoveDown();
			case "D":
			case "d":
				return MoveRight();
			default:
				if (debug) Debug.Log("A bad input was sent to PerformMove()", this);
				return false;
		}
	}

	/// <summary>
	/// The gameObject moves up if it is able to do so.true If not, it returns false.
	/// </summary>
	/// <remarks>
	/// First, the function calls the method <see cref="CanMove"/> to see if there is anything obstructing
	/// it from moving. If it is false, the gameObject changes its target position to the wanted one.
	/// </remarks>   
	private bool MoveUp() {
		//TODO: Remove debugging logs
		if (debug) Debug.Log(gameObject.name + " tried to move up! ... Could it? " + CanMove(Vector2.up));
		target = (Vector2) transform.position + Vector2.up;
		return CanMove(Vector2.up);
	}
	private bool MoveLeft() {
		if (debug) Debug.Log(gameObject.name + " tried to move left! ...Could it ? " + CanMove(Vector2.left));
		target = (Vector2) transform.position + Vector2.left;
		return CanMove(Vector2.left);
	}
	private bool MoveDown() {
		if (debug) Debug.Log(gameObject.name + " tried to move down! ...Could it ? " + CanMove(Vector2.down));
		target = (Vector2) transform.position + Vector2.down;
		return CanMove(Vector2.down);
	}
	private bool MoveRight() {
		if (debug) Debug.Log(gameObject.name + " tried to move right! ...Could it ? " + CanMove(Vector2.right));
		target = (Vector2) transform.position + Vector2.right;
		return CanMove(Vector2.right);
	}

	private bool CanMove(Vector3 direction) {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
		if (hit.collider == null) {
			return true;
		}
		return false;
	}

	private void Update() {
		//TODO: Move towards target

		//Checks if the move action is finished, and updates it conrrespondingly
		if (levelController.PerformingAction) {
			if (transform.position.Equals(target)) {
				levelController.PerformingAction = false;
			}
		}
	}
}
