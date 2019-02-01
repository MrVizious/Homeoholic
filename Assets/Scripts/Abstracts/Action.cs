using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {

	[SerializeField]
	protected string actionKey;
	[SerializeField]
	protected LevelController levelController;


	/// <summary>
	/// Performs the action. Once it is finished, the action is set as not running in the LevelController.
	/// If the action was succesfully completed, it returns true, but returns false otherwise.   
	/// </summary>
	public abstract bool PerformAction(string s);

}