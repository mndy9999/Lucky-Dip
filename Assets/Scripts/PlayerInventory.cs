using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static PlayerInventory instance;
    public static PlayerInventory Instance
    {
        get
        {
            if(instance == null)
                instance = (PlayerInventory)FindObjectOfType(typeof(PlayerInventory));
            return instance;
        }
    }

    public List<Card> AvailableCards;

    public List<Card> AvailablePowerups;

    public void AddCard(Card card)
    {
        AvailableCards.Add(card);
    }

    public void AddPowerup(Card powerup)
    {
        AvailablePowerups.Add(powerup);
    }
}
