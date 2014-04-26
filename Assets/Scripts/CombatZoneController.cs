
using System;
using UnityEngine;
using System.Collections.Generic;

public class CombatZoneController : MonoBehaviour
{
	const int MAX_COMBAT_SIZE = 6;

	List<GameCard> gameCards;
	PlayerBrain defender;

	void Awake()
	{
		gameCards = new List<GameCard>();
	}

	public void BeginAttackPhase(PlayerBrain defender)
	{
		this.defender = defender;
	}

	public void AddAttackCard(GameCard card)
	{
		if(gameCards.Count > 6) return;

		card.transform.localPositionTo(.25f,new Vector3(gameCards.Count * 10f,35f, gameObject.transform.localPosition.z));
		gameCards.Add(card);
	}
}


