using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckController : MonoBehaviour {

	static CardValue[] CARD_VALUES = new CardValue[13]{CardValue.two, CardValue.three, CardValue.four, CardValue.five, 
		CardValue.six, CardValue.seven, CardValue.eight, CardValue.nine, CardValue.ten, CardValue.Jack, CardValue.Queen,
		CardValue.King, CardValue.Ace};
	static CardSuit[] CARD_SUITS = new CardSuit[4]{CardSuit.Clubs, CardSuit.Spades, CardSuit.Diamonds, CardSuit.Hearts};


	List<CardModel> cardModels;

	// Use this for initialization
	void Awake () 
	{
		cardModels = new List<CardModel> ();
		foreach (CardSuit suit in CARD_SUITS) 
		{
			foreach(CardValue val in CARD_VALUES)
			{
				CardModel cm = new CardModel(suit,val);
				cardModels.Add(cm);
			}
		}
	}

	public void Initialize()
	{
		this.GetComponent<DeckView> ().Initialize ();
	}

	public CardModel TakeCardFromDeck()
	{
		int randCardIndex = UnityEngine.Random.Range (0, cardModels.Count);
		CardModel takenCard = cardModels [randCardIndex];
		cardModels.RemoveAt (randCardIndex);
		return takenCard;
	}


}

public enum CardSuit
{
	Clubs,
	Spades,
	Diamonds,
	Hearts
}

public enum CardValue
{
	two,
	three,
	four,
	five,
	six,
	seven,
	eight,
	nine,
	ten,
	Jack,
	Queen,
	King,
	Ace
}
