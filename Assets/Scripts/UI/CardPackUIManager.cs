using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPackUIManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.IsPaused = true;
        UpdateInventory();
    }

    private void OnDisable()
    {
        GameManager.Instance.IsPaused = false;
    }

    public List<Card> PossibleCards;

    public List<Card> AllCards;

    public List<CardDisplay> CardsInventory;

    public void UpdateInventory()
    {
        var availableCards = PlayerInventory.Instance.AvailableCards;

        AllCards.Clear();
        for (int i = 0; i < 10; i++)
        {
            AllCards.Add(i < availableCards.Count ? availableCards[i] : PossibleCards[0]);
            CardsInventory[i].ActiveCard = AllCards[i];
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 1; i < 4; i++)
        {
            PlayerInventory.Instance.AddCard(PossibleCards[i]);
        }
        UpdateInventory();
    }

    void Update()
    {
        UpdateInventory();
    }


}
