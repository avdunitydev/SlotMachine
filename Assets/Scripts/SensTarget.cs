using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensTarget : MonoBehaviour {
	string m_GOname;
	bool m_IsEnterOnTrigger;

	void Awake () {
		m_IsEnterOnTrigger = false;
		m_GOname = gameObject.name;
	}
	
    private void CheckCellName(Collider2D other)
    {
        if(Equals(m_GOname, "SensL")){
			Manager.GetInstance.m_LeftCellName = other.gameObject.GetComponent<SpriteRenderer>().sprite.ToString();
		}else if(Equals(m_GOname, "SensC")){
			Manager.GetInstance.m_CenterCellName = other.gameObject.GetComponent<SpriteRenderer>().sprite.ToString();
		}else if (Equals(m_GOname, "SensR")){
			Manager.GetInstance.m_RightCellName = other.gameObject.GetComponent<SpriteRenderer>().sprite.ToString();
		}
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		m_IsEnterOnTrigger = !m_IsEnterOnTrigger;
		CheckCellName(other);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		
	}

	void OnTriggerExit2D(Collider2D other)
	{
		m_IsEnterOnTrigger = !m_IsEnterOnTrigger;
	}
}
