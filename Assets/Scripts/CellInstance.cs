using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInstance : MonoBehaviour {
#region Public variables
	public GameObject cellPrefab;
#endregion
#region Private variables
	float posX, posY, posZ, deltaSpeed, maxDistance, maxTime;
	GameObject m_cellFirst, m_cellSecond, m_cellThird, m_cellFourth;
#endregion

	void Start () {
		deltaSpeed = 0.022f;
		maxDistance = 0.026f;
		maxTime = 13f;
		InitGOPosition();
		InitCellStart();
	}
	
	void Update () {
		if(Manager.GetInstance.m_IsSpin){
			SlotSpin(m_cellFirst, m_cellSecond, m_cellThird, m_cellFourth);
		}
		if(Manager.GetInstance.m_TurnIsEnd){
			SlotSpinEnd(m_cellFirst, m_cellSecond, m_cellThird, m_cellFourth);
		}
	}

	void InitGOPosition() {
		posX = transform.position.x;
		posY = transform.position.y;
		posZ = transform.position.z;
	}

	GameObject InitCell(GameObject cell, string cellName, float addPosY){
		cell = Instantiate(cellPrefab, new Vector3(posX, posY + addPosY, posZ), transform.rotation, transform);
		cell.name = cellName;
		//Debug.Log(cell);
		//Debug.Log(m_cellFirst);
		return cell;
	}

	void InitCellStart(){
		if(Equals(gameObject.GetComponentInParent<SpriteMask>().name, "slot_L")){
			m_cellFourth = InitCell(m_cellFourth, "cell_4L", 2f);
			m_cellThird = InitCell(m_cellThird, "cell_3L", 1f);
			m_cellSecond = InitCell(m_cellSecond, "cell_2L", 0f);
			m_cellFirst = InitCell(m_cellFirst, "cell_1L", -1f);
		}else if(Equals(gameObject.GetComponentInParent<SpriteMask>().name, "slot_C")){
			m_cellFourth = InitCell(m_cellFourth, "cell_4C", 2f);
			m_cellThird = InitCell(m_cellThird, "cell_3C", 1f);
			m_cellSecond = InitCell(m_cellSecond, "cell_2C", 0f);
			m_cellFirst = InitCell(m_cellFirst, "cell_1C", -1f);
		}else if(Equals(gameObject.GetComponentInParent<SpriteMask>().name, "slot_R")){
			m_cellFourth = InitCell(m_cellFourth, "cell_4R", 2f);
			m_cellThird = InitCell(m_cellThird, "cell_3R", 1f);
			m_cellSecond = InitCell(m_cellSecond, "cell_2R", 0f);
			m_cellFirst = InitCell(m_cellFirst, "cell_1R", -1f);
		}
	}

	void CheckOut(string slotIndex){
		if(m_cellFirst.transform.position.y <= -2f){
			Destroy(m_cellFirst);
			m_cellFirst = InitCell(m_cellFirst, "cell_1" + slotIndex, m_cellFourth.transform.position.y +1f);
		}else if(m_cellSecond.transform.position.y <= -2f){
			Destroy(m_cellSecond);
			m_cellSecond = InitCell(m_cellSecond, "cell_2" + slotIndex, m_cellFirst.transform.position.y +1f);
		}else if(m_cellThird.transform.position.y <= -2f){
			Destroy(m_cellThird);
			m_cellThird = InitCell(m_cellThird, "cell_3" + slotIndex, m_cellSecond.transform.position.y +1f);
		}else if(m_cellFourth.transform.position.y <= -2f){
			Destroy(m_cellFourth);
			m_cellFourth = InitCell(m_cellFourth, "cell_4" + slotIndex, m_cellThird.transform.position.y +1f);
		} 
	}

	void SlotSpin(GameObject cell_1, GameObject cell_2, GameObject cell_3, GameObject cell_4)
	{
		if(Equals(cell_1.name, "cell_1L") && Manager.GetInstance.m_IsSpinL){
			cell_1.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotL);
			cell_2.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotL);
			cell_3.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotL);
			cell_4.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotL);
			CheckOut("L");
		}else if(Equals(cell_1.name, "cell_1C") && Manager.GetInstance.m_IsSpinC){
			cell_1.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotC);
			cell_2.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotC);
			cell_3.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotC);
			cell_4.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotC);
			CheckOut("C");
		}else if(Equals(cell_1.name, "cell_1R") && Manager.GetInstance.m_IsSpinR){
			cell_1.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotR);
			cell_2.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotR);
			cell_3.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotR);
			cell_4.transform.Translate(Vector3.down * deltaSpeed * Manager.GetInstance.m_SpeedSlotR);
			CheckOut("R");
		}
	}

	void SlotSpinEnd(GameObject cell_1, GameObject cell_2, GameObject cell_3, GameObject cell_4){
		Manager.GetInstance.m_SpeedSlotL -= 0.001f;
		Manager.GetInstance.m_SpeedSlotC -= 0.001f;
		Manager.GetInstance.m_SpeedSlotR -= 0.001f;

		if(Equals(cell_1.name, "cell_1L")){
			if(Vector3.Distance(cell_2.transform.position, Manager.GetInstance.m_SlotLCenterPosition) <= maxDistance){
				Manager.GetInstance.m_IsSpinL = false;
			}
		}else if(Equals(cell_1.name, "cell_1C")){
			if(Vector3.Distance(cell_2.transform.position, Manager.GetInstance.m_SlotCCenterPosition) <= maxDistance){
				Manager.GetInstance.m_IsSpinC = false;
			}
		}else if(Equals(cell_1.name, "cell_1R")){
			Debug.Log("right dirtance >>> " + Vector3.Distance(cell_2.transform.position, Manager.GetInstance.m_SlotRCenterPosition));
			if(Vector3.Distance(cell_2.transform.position, Manager.GetInstance.m_SlotRCenterPosition) <= maxDistance){
				Manager.GetInstance.m_IsSpinR = false;
			}
		}
		if(!Manager.GetInstance.m_IsSpinL && !Manager.GetInstance.m_IsSpinC && !Manager.GetInstance.m_IsSpinR){
			Manager.GetInstance.m_IsSpin = false;
			Manager.GetInstance.m_TurnIsEnd = false;
			Manager.GetInstance.m_Score = 0;
		}
		if (Manager.GetInstance.m_GlobalTimer >= maxTime){
			Manager.GetInstance.m_IsSpinL = false;
			Manager.GetInstance.m_IsSpinC = false;
			Manager.GetInstance.m_IsSpinR = false;
		}
	}
}
