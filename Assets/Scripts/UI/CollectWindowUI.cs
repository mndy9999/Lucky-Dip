using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectWindowUI : MonoBehaviour
{
    public CardDisplay EnemyCard;
    public CardDisplay PowerupCard;

    public GameObject CollectButton;
    public GameObject FightButton;

    private CardDisplay TileCard;
    private GameObject TileButton;

    public GameObject InventoryFullWarning;

    public PowerupsUIController powerupsController;

    public Card Card;
    public TextMeshProUGUI BonusPointsText;
    public int BonusPoints;

    private const string pointsText = "Bonus Points: {0}";
    private TileManager tile;


    private void OnEnable()
    {

        GameManager.Instance.IsPaused = true;
        GameManager.Instance.IsCollecting = true;


        tile = GameManager.Instance.PlayerTilePosition.GetComponent<TileManager>();
        
        Card = tile.TileCard;
        BonusPoints = Card.BonusPoints;

        TileCard = Card is BattleCard ? EnemyCard : PowerupCard;
        TileButton = Card is BattleCard ? tile.CanCollect ? CollectButton : FightButton : CollectButton;


        TileButton.SetActive(true);
        TileCard.ActiveCard = Card;
        TileCard.gameObject.SetActive(true);


        BonusPointsText.text = string.Format(pointsText, BonusPoints);
    }

    private void OnDisable()
    {
        GameManager.Instance.IsPaused = false;
        GameManager.Instance.IsCollecting = false;
        TileCard.gameObject.SetActive(false);
        TileButton.gameObject.SetActive(false);
    }

    public void Collect()
    {
        if (tile.IsEnemy)
            CollectCard();
        else
            CollectPowerup();
        tile.ResetTile();
    }

    private void CollectCard()
    {
        PlayerStats.Instance.UnassignedPoints += BonusPoints;
        if (PlayerInventory.Instance.AvailableCards.Count < 3)
        {
            PlayerInventory.Instance.AddCard(Card);
        }
        else
        {
            InventoryFullWarning.SetActive(true);
        }
    }

    private void CollectPowerup()
    {
        PlayerInventory.Instance.AddPowerup(Card);
        powerupsController.UpdateGems();
    }

    public void Fight()
    {
        GameManager.Instance.Enemy = (BattleCard)Card.Enemy;
        GameManager.Instance.LoadBattleScene();
    }

}
