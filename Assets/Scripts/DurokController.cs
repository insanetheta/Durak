using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DurokController : MonoBehaviour {

	public GameObject DeckPrefab;
	public GameObject CardPrefab;
	public GameObject Hand1;
	public GameObject Hand2;


	DeckController GameDeck;
	DeckView GameDeckView;
	CombatZoneController CombatZone;

	List<HandController> Players;
	

	// Use this for initialization
	void Start () 
	{
		//GameDeck = GameObjectUtils.AddAndPosition (DeckPrefab, this.gameObject, Vector3.zero).GetComponent<DeckController>();
		GameDeck = transform.Find ("Deck").gameObject.GetComponent<DeckController> ();
		CombatZone = transform.Find("CombatZone").gameObject.GetComponent<CombatZoneController>();
		Players = new List<HandController>();
		StartCoroutine (Deal ());
	}

	IEnumerator Deal()
	{
		GameDeck.Initialize ();
		HandController Player1 = Hand1.GetComponent<HandController>();
		Player1.Initialize(GameDeck, HandType.Player);
		Player1.gameObject.AddComponent<PlayerBrain>().Initialize(CombatZone);
		yield return StartCoroutine(Player1.Deal());
		HandController Player2 = Hand2.GetComponent<HandController>();
		Player2.Initialize(GameDeck, HandType.Opponent);
		Player2.gameObject.AddComponent<PlayerBrain>().Initialize(CombatZone);
		yield return StartCoroutine(Player2.Deal());

		Players.Add(Player1);
		Players.Add(Player2);
		//GameCard trumpCard = GameObjectUtils.AddAndPosition (CardPrefab, this.gameObject, new Vector3()).GetComponent<GameCard> ();
		//Debug.Log (null != GameDeck);
		//trumpCard.Initialize (GameDeck.TakeCardFromDeck ());

		yield return new WaitForSeconds(1);
		BeginGame();
	}

	void BeginGame()
	{
		Debug.Log("BeginGame");
		Players[0].GetComponent<PlayerBrain>().EnterAttack(Players[1].GetComponent<PlayerBrain>());
		Players[1].GetComponent<PlayerBrain>().EnterDefense();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
