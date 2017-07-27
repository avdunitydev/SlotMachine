using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour {
	public GameObject knobDown;
	public Sprite[] knobSprites;
	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = knobSprites[0];
	}
	
#region Button glow
	void OnMouseEnter()
	{
		spriteRenderer.sprite = knobSprites[1];
	}

	void OnMouseExit()
	{
		spriteRenderer.sprite = knobSprites[0];
	}	
#endregion
#region Button onClick
	void OnMouseDown()
	{
		if(!Manager.GetInstance.m_IsInsertCoin && 
			!Manager.GetInstance.m_IsSpin && 
			Manager.GetInstance.m_Score > 0)
		{
			Manager.GetInstance.firstStart = false;
			Manager.GetInstance.m_SpeedSlotL = Random.Range(2, 9);
			Manager.GetInstance.m_SpeedSlotC = Random.Range(2, 9);
			Manager.GetInstance.m_SpeedSlotR = Random.Range(2, 9);
			Manager.GetInstance.m_changeSpeedSwich = !Manager.GetInstance.m_changeSpeedSwich;
			Manager.GetInstance.m_IsSpin = true;
			Manager.GetInstance.m_IsSpinL = true;
			Manager.GetInstance.m_IsSpinC = true;
			Manager.GetInstance.m_IsSpinR = true;
			gameObject.SetActive(!gameObject.activeInHierarchy);
			knobDown.SetActive(!knobDown.activeInHierarchy);
			Invoke("UpKnob", Random.Range(2f, 4f));
		}
	}
	void UpKnob()
	{
		gameObject.SetActive(!gameObject.activeInHierarchy);
		knobDown.SetActive(!knobDown.activeInHierarchy);
		Manager.GetInstance.m_TurnIsEnd = true;
	}
#endregion
}
