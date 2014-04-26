//------------------------------------------------------------------------------
//Game Card Monobehaviour
//--------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCard : MonoBehaviour
{
	CardModel Model;

	GameObject clubs;
	GameObject hearts;
	GameObject diamonds;
	GameObject spades;
	GameObject suitObject;

	public void Initialize(CardModel model)
	{
		Model = model;
		clubs = gameObject.transform.Find ("clubs").gameObject;
		hearts = gameObject.transform.Find ("hearts").gameObject;
		diamonds = gameObject.transform.Find ("diamonds").gameObject;
		spades = gameObject.transform.Find ("spades").gameObject;
		suitObject = gameObject.transform.Find (Model.Suit.ToString ().ToLower ()).gameObject;
		//suitObject.SetActive (true);
		suitObject.transform.GetChild (((int)model.Value)).gameObject.SetActive (true);
		gameObject.name = UnityEngine.Random.value.ToString();
	}
}


