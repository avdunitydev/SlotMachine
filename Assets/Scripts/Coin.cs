using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public Sprite[] coinSprites;
	SpriteRenderer spriteRenderer;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = coinSprites[0];
	}
}
