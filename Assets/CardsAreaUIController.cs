using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsAreaUIController : MonoBehaviour
{

    public CardDisplay[] CardsArea;
    public BattleInventory inventory;

    public void UpdateCardsArea()
    {
        foreach(var area in CardsArea)
        {
            area.gameObject.SetActive(true);
        }
    }

}
