using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;
	private Vector2 target;
	private int layerMask;
	[SerializeField]
	private float speed;
	public bool debug;
	public bool instantMovement;

	private void Start() {
		layerMask = 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("ElementWithCollision") | 1 << LayerMask.NameToLayer("NPC");
	}
	public bool PerformMove(string s) {
		switch (s) {
			case "W":
			case "w":
				return MoveInDirection(Vector2.up);
			case "A":
			case "a":
				return MoveInDirection(Vector2.left);
			case "S":
			case "s":
				return MoveInDirection(Vector2.down);
			case "D":
			case "d":
				return MoveInDirection(Vector2.right);
			default:
				if (debug) Debug.Log("A bad input was sent to PerformMove()", this);
				return false;
		}
	}

	/// <summary>
	/// The gameObject moves towards the direction of the input Vector if it is able to do so.true If not, it returns false.
	/// </summary>
	/// <param name="directionVector">Vector2 containing the direction of the movement.</param>   
	/// <remarks>
	/// First, the function calls the method <see cref="CanMove"/> to see if there is anything obstructing
	/// it from moving. If it is false, the gameObject changes its target position to the wanted one.
	/// After that, it turns PerformingAction to true.   
	/// </remarks>
	/// <returns>Returns true if it moved, false if it didn't.</returns>    
	private bool MoveInDirection(Vector2 directionVector) {

		if (debug) {
			Debug.Log(gameObject.name + " tried to move! ... Could it? " + CanMove(directionVector));
			Debug.Log("Before moving, PerformingAction was: " + levelController.PerformingAction);
		}


		if (CanMove(directionVector)) {
			levelController.PerformingAction = true;
			target = (Vector2) transform.position + directionVector;
			if (instantMovement) transform.position = target;
			return true;
		}
		levelController.PerformingAction = false;
		return false;
	}

	//TODO: Avoid raycasting objects in layers that shouldn't interact with it
	/// <summary>
	/// Checks wether the movement in a certain direction is possible or there is an obstacle.
	/// </summary>
	/// <param name="direction"></param>
	/// <returns></returns>
	private bool CanMove(Vector3 direction) {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, layerMask);
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

		// Once the target is reached, the movement action is stopped, thus changing PerformingAction to False
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
