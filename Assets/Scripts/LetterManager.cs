using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LetterManager : MonoBehaviour {

	private Image image;
	private void Start() {
		image = GetComponent<Image>();
	}

	public void SetLetter(Sprite sprite) {
		image.sprite = sprite;
		Color tempColor = image.color;
		tempColor.a = 1f;
		image.color = tempColor;
	}

	public void DeleteLetter() {
		image.sprite = null;
		Color tempColor = image.color;
		tempColor.a = 0f;
		image.color = tempColor;
	}
}
