using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Card TileCard;

    public GameObject tileUI;


    public bool CanCollect;
    public bool CanFight;
    
    public int BonusPoints;


    public bool IsEnemy
    {
        get
        {
            return TileCard.CardType.IsEnemyCard();
        }
    }


    public void ResetTile()
    {
        GetComponent<Node>().Collected = true;
        TileCard = null;
    }

    void OnMouseOver()
    {
        if (!GameManager.Instance.IsPaused && TileCard != null)
        {
            tileUI.GetComponent<CardDisplay>().ActiveCard = GetComponent<Node>().SteppedOn ? TileCard : null;
            tileUI.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (TileCard != null)
            tileUI.SetActive(false);
    }
}
