using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This class is in control of organizing and creating visually all the letter holders.
/// </summary>
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(GridLayoutGroup))]
public class LetterHoldersUI : MonoBehaviour {

	private GridLayoutGroup gridLayoutGroup;
	private RectTransform rectTransform;
	[SerializeField]
	private GameObject letterHolderPrefab;
	public LevelController levelController;

	private void Start() {

		//Getting the components
		rectTransform = GetComponent<RectTransform>();
		gridLayoutGroup = GetComponent<GridLayoutGroup>();

		setInitialSize();
		setChildren();
	}

	/// <summary>
	/// This method takes care of giving an adequate initial size for the grid of letterHolders
	/// </summary>
	private void setInitialSize() {

		// The width is twice the gap (the right and left borders), the number of elements multiplied by the size of the element, and the gaps between the elements
		float x = gridLayoutGroup.spacing.x * 2 + (levelController.NumberOfActions - 1) * gridLayoutGroup.spacing.x + levelController.NumberOfActions * gridLayoutGroup.cellSize.x;
		// The height is just the height of an element plus the borders (twice the gap)
		float y = gridLayoutGroup.spacing.y * 2 + gridLayoutGroup.cellSize.y;
		// Now we just change the sizeDelta, which is the rectTransform measure for size
		rectTransform.sizeDelta = new Vector2(x, y);

	}

	/// <summary>
	/// This method populates the array of children with the prefab that is used for the letterholders
	/// </summary>
	private void setChildren() {
		// TODO: Populate and create an array of children for future use
	}

	// TODO: Method that changes color of the current letter being executed
	// TODO: Method that adds a letter
}
