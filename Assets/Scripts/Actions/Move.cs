using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;
	private Vector2 target;
	[SerializeField]
	private float speed;
	public bool debug;
	public bool instantMovement;
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

		//TODO: Change movement
		if (debug) {
			Debug.Log(gameObject.name + " tried to move up! ... Could it? " + CanMove(Vector2.up));
			Debug.Log("Before moving up, PerformingAction was: " + levelController.PerformingAction);
		}


		if (CanMove(Vector2.up)) {
			levelController.PerformingAction = true;
			target = (Vector2) transform.position + Vector2.up;
			if (instantMovement) transform.position = target;
			return true;
		}
		return false;
	}
	private bool MoveLeft() {

		if (debug) {
			Debug.Log(gameObject.name + " tried to move left! ... Could it? " + CanMove(Vector2.left));
			Debug.Log("Before moving left, PerformingAction was: " + levelController.PerformingAction);
		}

		if (CanMove(Vector2.left)) {
			levelController.PerformingAction = true;
			target = (Vector2) transform.position + Vector2.left;
			if (instantMovement) transform.position = target;
			return true;
		}
		return false;
	}
	private bool MoveDown() {
		if (debug) {
			Debug.Log(gameObject.name + " tried to move down! ... Could it? " + CanMove(Vector2.down));
			Debug.Log("Before moving down, PerformingAction was: " + levelController.PerformingAction);
		}

		if (CanMove(Vector2.down)) {
			levelController.PerformingAction = true;
			target = (Vector2) transform.position + Vector2.down;
			if (instantMovement) transform.position = target;
			return true;
		}
		return false;
	}
	private bool MoveRight() {
		if (debug) {
			Debug.Log(gameObject.name + " tried to move right! ... Could it? " + CanMove(Vector2.right));
			Debug.Log("Before moving right, PerformingAction was: " + levelController.PerformingAction);
		}

		if (CanMove(Vector2.right)) {
			levelController.PerformingAction = true;
			target = (Vector2) transform.position + Vector2.right;
			if (instantMovement) transform.position = target;
			return true;
		}
		return false;
	}

	//TODO: Avoid raycasting objects in layers that shouldn't interact with it
	private bool CanMove(Vector3 direction) {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f);
		if (hit.collider == null) {
			return true;
		}
		return false;
	}

	private void Update() {

		// If the position is very close to the target, it just changes to it
		if (Vector2.Distance(transform.position, target) < 0.001f) {
			transform.position = target;
		}

		if (transform.position.Equals(target)) {
			if (levelController.PerformingAction) {
				if (debug) Debug.Log("PerformingAction changed to false because " + name + " arrived to its target!", this);
				levelController.PerformingAction = false;
			}
		} else {
			// Move position towards target
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, target, step);
		}
	}
}
