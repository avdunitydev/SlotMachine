using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {
	public Transform sensL, sensC, sensR;
	public RectTransform panelWin;
	public TextMesh m_InfoText;

	// Use this for initialization
	void Awake () {
		Manager.GetInstance.m_SpeedSlotL = Random.Range(2, 9);
		Manager.GetInstance.m_SpeedSlotC = Random.Range(2, 9);
		Manager.GetInstance.m_SpeedSlotR = Random.Range(2, 9);
		Manager.GetInstance.m_SlotLCenterPosition = sensL.position;
		Manager.GetInstance.m_SlotCCenterPosition = sensC.position;
		Manager.GetInstance.m_SlotRCenterPosition = sensR.position;
	}
	
	void Update()
	{
		if(Manager.GetInstance.m_IsSpin){
			Manager.GetInstance.m_GlobalTimer += Time.deltaTime;
		}else {
			Manager.GetInstance.m_GlobalTimer = 0;
		}
		if (Manager.GetInstance.m_Score == 0 && !Manager.GetInstance.m_IsSpin){
			m_InfoText.text = "Please insert coin";
		}else {
			m_InfoText.text = "your balance : " + Manager.GetInstance.m_Balance.ToString();
		}
		CheckIsWin();
		if(!Manager.GetInstance.m_IsSpin && !Manager.GetInstance.firstStart)
		{
			CheckIsLine();
		}
	}

	public void RestartGame()
	{
		Manager.GetInstance.m_IsWin = false;
		Manager.GetInstance.firstStart = true;
		Manager.GetInstance.m_Score = 0;
		panelWin.gameObject.SetActive(false);
	}
	
	void CheckIsWin(){
		if (Manager.GetInstance.m_IsWin){
			panelWin.gameObject.SetActive(true);
		}
	}

	void CheckIsLine(){
		if(Equals(Manager.GetInstance.m_LeftCellName, Manager.GetInstance.m_CenterCellName) &&
			Equals(Manager.GetInstance.m_LeftCellName, Manager.GetInstance.m_RightCellName))
		{
			//Debug.Log(Manager.GetInstance.m_IsWin);
			Manager.GetInstance.m_IsWin = true;
		}
	}
}
