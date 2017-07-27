using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Опис завдання
	//	Треба зробити слот-машину. Основні функції слот машини:
	//		- гравець повинен натиснути на ручку слот-машини.
	//		- програти анімацію візуального опускання ручки, запустити монетку у отвір.
	//		- запустити слот машину
	//	у результаті однакової лінії, показати напис "You win!"
#endregion
	 
[HelpURL("http://example.com/docs/MyComponent.html")]
public class test : MonoBehaviour {

	[ContextMenu ("Do Something")]
	void DoSomething () {
		Debug.Log ("Perform operation on script >>> " + gameObject.name);
	}

	//Используйте этот атрибут для добавления контекстного меню к полю, которое вызывает указанный метод
	[ContextMenuItem("Reset", "ResetBiography")] 
    [Multiline(3)]
    public string playerBiography = "";
    void ResetBiography() {
        playerBiography = "";
    }

	//Для добавления заголовка над полями в окне Inspector
	[Header("Health Settings")] 
    public int health = 0;
    public int maxHealth = 100;
    //Для добавления заголовка над полями в окне Inspector
	[Header("Shield Settings")] 
    public int shield = 0;
    public int maxShield = 300;

	//Делает переменную не видимой в инспекторе, но сериализуемой
	[HideInInspector] 
    public int p = 5;

	[Tooltip("Health value between 0 and 100.")]
	[Space(10)]
	[SerializeField]
	private int characterHP = 100;

	// 
	[Space (0, order=0)]
	[Space (10, order=2)]
	[Header ("Header with some space around it", order=1)]
	public string playerName = "Unnamed";
}
