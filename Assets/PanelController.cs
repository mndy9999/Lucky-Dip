using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    public CardDisplay playedCardDisplay;

    private void Start()
    {
        playedCardDisplay = transform.GetChild(0).GetComponent<CardDisplay>();
    }

    public void DiscardPlayedCards()
    {
        playedCardDisplay.gameObject.SetActive(false);
    }

    public void ShowEnemyCard(Card card)
    {
        playedCardDisplay.ActiveCard = card;
        playedCardDisplay.gameObject.SetActive(true);
    }

}
