using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public List<Card> AllEnemyCards;

    public BattleInventory enemyInventory;
    public BattleInventory playerInventory;

    public Card enemyCard;
    public Card playerCard;

    public EnemyBattleAI enemyAI;
    public EnemyStats enemyStats;

    public CardsAreaUIController playerCardsArea;
    public CardsAreaUIController enemyCardsArea;

    public PanelController playerPlayPanel;
    public PanelController enemyPlayPanel;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i=0;i < 10; i++)
        {
            enemyInventory.BattleCards.Add(AllEnemyCards[Random.Range(0, AllEnemyCards.Count)]);
            playerInventory.BattleCards.Add(AllEnemyCards[Random.Range(0, AllEnemyCards.Count)]);
        }
        //playerInventory.BattleCards = PlayerInventory.Instance.AvailableCards;
    }

    private void Start()
    {
       for(int i = 0; i < 3; i++)
        {
            DrawCard(enemyInventory);
            DrawCard(playerInventory);
        }

        UpdateCardsUI();
    }

    private bool inBattle;

    // Update is called once per frame
    void Update()
    {
        if(playerCard != null && enemyCard != null && !inBattle)
        {
            inBattle = true;
            Battle();
        }
    }

    private void DrawCard(BattleInventory inventory)
    {
        var cardDrawn = inventory.BattleCards[Random.Range(0, inventory.BattleCards.Count)];
        inventory.DrawnCards.Add(cardDrawn);
        inventory.BattleCards.Remove(cardDrawn);
    }

    public void PlayCard(Card card)
    {
        playerCard = card;
        enemyAI.PlayCard();
    }

    private int Roll()
    {
        return Random.Range(1, 7);
    }

    private void Battle()
    {
        var playerRoll = Roll();
        var enemyRoll = Roll();

        if (enemyCard.CardType != CardTypes.Healing)
            PlayerStats.Instance.CurrentHealth -= (enemyCard.GetCardDamage(enemyRoll) + enemyStats.GetExtraPower(enemyCard.CardType));
        else
            enemyStats.CurrentHealth += (enemyCard.GetCardDamage(enemyRoll) + enemyStats.GetExtraPower(enemyCard.CardType));

        if (playerCard.CardType != CardTypes.Healing)
            enemyStats.CurrentHealth -= (playerCard.GetCardDamage(playerRoll) + PlayerStats.Instance.GetExtraPower(playerCard.CardType));
        else
            PlayerStats.Instance.CurrentHealth += (playerCard.GetCardDamage(playerRoll) + PlayerStats.Instance.GetExtraPower(playerCard.CardType));

        StartCoroutine(ResetCardsCoroutine());
    }

    IEnumerator ResetCardsCoroutine()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        ResetCards();
    }

    private void ResetCards()
    {
        DrawCard(enemyInventory);
        DrawCard(playerInventory);

        DiscardPlayedCards();
        inBattle = false;
    }

    private void UpdateCardsUI()
    {
        playerCardsArea.UpdateCardsArea();
        enemyCardsArea.UpdateCardsArea();
    }

    private void DiscardPlayedCards()
    {
        enemyInventory.DrawnCards.Remove(enemyCard);
        playerInventory.DrawnCards.Remove(playerCard);

        enemyPlayPanel.DiscardPlayedCards();
        playerPlayPanel.DiscardPlayedCards();
        UpdateCardsUI();
    }


}
