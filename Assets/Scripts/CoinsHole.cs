using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsHole : MonoBehaviour {
	public GameObject coinPrefab;
	public Sprite[] coinSprites;

	
	float posX, posY, posZ;
	float timeRuning = 0.5f;
	float timeDelay = 0.5f;
	GameObject coin;

	void OnMouseDown()
	{
		if(!Manager.GetInstance.m_IsInsertCoin && !Manager.GetInstance.m_IsSpin){
			Manager.GetInstance.m_IsInsertCoin = true;
			InitGOPosition();
			InitCoin(coinPrefab);
			RunCoinAnimation(coin, posX + .35f, timeRuning, "ChangeSprite");
			RunCoinAnimation(coin, posX + .15f, timeRuning, "DestroyCoin", timeDelay);
		}
	}

	void InitGOPosition()
	{
		posX = transform.position.x;
		posY = transform.position.y;
		posZ = transform.position.z;
	}
	void InitCoin(GameObject m_object){
		coin = Instantiate(m_object, new Vector3(posX + .55f, posY, posZ), transform.rotation, transform);
	}
	void ChangeSprite(GameObject m_object){
		m_object.GetComponent<SpriteRenderer>().sprite = coinSprites[1];
		Manager.GetInstance.m_Score += 10;
		Manager.GetInstance.m_Balance -= 10;
		//Debug.Log("m_object.GetComponent<SpriteRenderer>().sprite.ToString() >>> " + m_object.GetComponent<SpriteRenderer>().sprite.ToString());
	}
	void DestroyCoin(GameObject m_object){
		Destroy(m_object, timeDelay);
		StartCoroutine(ChangeBoolWithDelay(Manager.GetInstance.m_IsInsertCoin, timeDelay));
	}

	IEnumerator ChangeBoolWithDelay(bool targetVariable, float delay){
        yield return new WaitForSeconds(delay);
		Manager.GetInstance.m_IsInsertCoin = !targetVariable;
	}

	void RunCoinAnimation(GameObject targetCoin, float positionX, float time, string methodName){
		iTween.MoveTo (targetCoin, iTween.Hash (
			"x", positionX, 
			"time", time, 
			"easetype", iTween.EaseType.linear,
			"oncomplete", methodName,
			"oncompletetarget", gameObject,
			"oncompleteparams", targetCoin
		));
	}
	void RunCoinAnimation(GameObject targetCoin, float positionX, float time, string methodName, float delayRun){
		iTween.MoveTo (targetCoin, iTween.Hash (
			"x", positionX, 
			"time", time,
			"delay", delayRun,
			"easetype", iTween.EaseType.linear,
			"oncomplete", methodName,
			"oncompletetarget", gameObject,
			"oncompleteparams", targetCoin
		));
	}
}
