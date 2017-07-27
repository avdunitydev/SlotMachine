using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
#region Public values
	[Header("Sprite array")]
	[ContextMenuItem("Run Start", "Start")]
	public Sprite[] slotSprites;
	[HideInInspector]
	public SpriteRenderer m_spriteCell;
#endregion

	void Start () {
		m_spriteCell = GetComponent<SpriteRenderer>();
		m_spriteCell.sprite = slotSprites[RandomSprites()];
	}

	int RandomSprites(){
		return Random.Range(0, slotSprites.Length);
	}
}
