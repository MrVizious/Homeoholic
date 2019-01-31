using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;
	private Vector2 target;
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
				Debug.Log("A bad input was sent to PerformMove()", this);
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
		Debug.Log(gameObject.name + " tried to move up! ... Could it? " + CanMove(Vector2.up));
		//TODO: Add logic
		return CanMove(Vector2.up);
	}
	private bool MoveLeft() {
		Debug.Log(gameObject.name + " tried to move left! ...Could it ? " + CanMove(Vector2.left));
		return CanMove(Vector2.left);
	}
	private bool MoveDown() {
		Debug.Log(gameObject.name + " tried to move down! ...Could it ? " + CanMove(Vector2.down));
		return CanMove(Vector2.down);
	}
	private bool MoveRight() {
		Debug.Log(gameObject.name + " tried to move right! ...Could it ? " + CanMove(Vector2.right));
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
