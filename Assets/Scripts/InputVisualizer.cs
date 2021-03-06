﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This class is in control of organizing and creating visually all the letter holders.
/// </summary>
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(GridLayoutGroup))]
public class InputVisualizer : MonoBehaviour {

	[SerializeField]
	private LevelController levelController;
	[SerializeField]
	private GameObject letterHolderPrefab;
	private GridLayoutGroup gridLayoutGroup;
	private RectTransform rectTransform;
	private List<GameObject> letterHolders;
	private Sprite[] sprites;
	private int currentLetter;

	private void Start() {

		//Getting the components
		rectTransform = GetComponent<RectTransform>();
		gridLayoutGroup = GetComponent<GridLayoutGroup>();
		letterHolders = new List<GameObject>();
		Debug.Log("Trying to get the sprite...");

		currentLetter = 0;

		SetInitialSize();
		SetChildren();
		LoadSprites();
	}

	/// <summary>
	/// This method takes care of giving an adequate initial size for the grid of letterHolders
	/// </summary>
	private void SetInitialSize() {

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
	private void SetChildren() {
		for (int i = 0; i < levelController.NumberOfActions; i++) {
			// The letter holder is instantiated and added to the list
			letterHolders.Add(Instantiate(letterHolderPrefab, this.transform));
		}
	}

	/// <summary>
	/// Loads all the sprites from the folder Letters under Resources and saves them to an array
	/// </summary>
	private void LoadSprites() {
		sprites = Resources.LoadAll<Sprite>("Letters/");
	}

	/// <summary>
	/// Goes to the next letter to fill and passes it the letter
	/// </summary>
	/// <param name="newLetter">String with the letter to be added</param>
	public void AddLetter(string newLetter) {
		letterHolders[currentLetter].GetComponentInChildren<LetterManager>().SetLetter(SelectLetter(newLetter));
		currentLetter++;
	}

	public void DeleteLetter() {
		currentLetter--;
		letterHolders[currentLetter].GetComponentInChildren<LetterManager>().DeleteLetter();
	}

	private Sprite SelectLetter(string letter) {
		string spriteName = "LettersSprites_";
		switch (letter) {
			case "W":
				spriteName += "Up";
				break;
			case "A":
				spriteName += "Left";
				break;
			case "S":
				spriteName += "Down";
				break;
			case "D":
				spriteName += "Right";
				break;
			case " ":
				spriteName += "Stall";
				break;
			default:
				spriteName += letter;
				break;

		}
		foreach (Sprite current in sprites) {

			if (current.name.Equals(spriteName)) {
				Debug.Log("Name correct!");
				return current;
			}
		}
		return null;
	}

	public void HighlightLetter(int i) {
		letterHolders[i].GetComponent<Image>().color = new Color(0.5f, 0.15f, 0.5f, 1f);
	}

	public void StopHighlightLetter(int i) {
		letterHolders[i].GetComponent<Image>().color = new Color(0.0943f, 0.0943f, 0.0943f, 1f);
	}
	public void DeHighlightLetter(int i) {
		Color tempColor = letterHolders[i].GetComponentsInChildren<Image>()[1].color;
		tempColor.a = 0.4f;
		letterHolders[i].GetComponentsInChildren<Image>()[1].color = tempColor;
	}
}
