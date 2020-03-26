using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleAI : MonoBehaviour
{
    BattleInventory inventory;
    public BattleController battleController;

    public EnemyCardUI enemyCardUI;

    private void Start()
    {
        inventory = GetComponent<BattleInventory>();
    }

    public void PlayCard()
    {
        var cardIndex = Random.Range(0, inventory.DrawnCards.Count);
        var card = inventory.DrawnCards[cardIndex];

        enemyCardUI.PlayCard(card);

        battleController.enemyCard = card;
    }

    public void DrawCard()
    {
        enemyCardUI.DrawCard();
    }

}
