using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour {

	TextMesh scoresText;

	// Use this for initialization
	void Start () {
		scoresText = GetComponent<TextMesh>();
		scoresText.text = Manager.GetInstance.m_Score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		scoresText.text = Manager.GetInstance.m_Score.ToString();
	}
}
