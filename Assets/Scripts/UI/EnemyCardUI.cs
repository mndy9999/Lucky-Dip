using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardUI : MonoBehaviour
{

    public PanelController enemyPanel;
    public GameObject[] displayCards;


    private int playedCardIndex;

    public void PlayCard(Card card)
    {
        enemyPanel.ShowEnemyCard(card);
        playedCardIndex = Random.Range(0, 3);
        displayCards[playedCardIndex].SetActive(false);
    }

    public void DrawCard()
    {
        displayCards[playedCardIndex].SetActive(false);
    }

}
