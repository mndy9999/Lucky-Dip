using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class PowerupsUIController : MonoBehaviour
{
    public Text SkipTurnGem;
    public Text LeaveBattleGem;
    public Text DoubleDamageGem;
    public Text DoubleHealthGem;

    public void Start()
    {
        UpdateGems();
    }

    // Update is called once per frame
    public void UpdateGems()
    {
        var skipTurn = PlayerInventory.Instance.AvailablePowerups.Count(a => a.CardType == CardTypes.SkipTurn);
        var leaveBattle = PlayerInventory.Instance.AvailablePowerups.Count(a => a.CardType == CardTypes.LeaveBattle);
        var doubleDamage = PlayerInventory.Instance.AvailablePowerups.Count(a => a.CardType == CardTypes.DoubleDamage);
        var doubleHealth = PlayerInventory.Instance.AvailablePowerups.Count(a => a.CardType == CardTypes.DoubleHealth);

        SkipTurnGem.text = skipTurn.ToString();
        LeaveBattleGem.text = leaveBattle.ToString();
        DoubleDamageGem.text = doubleDamage.ToString();
        DoubleHealthGem.text = doubleHealth.ToString();

        SkipTurnGem.transform.parent.GetComponent<Button>().interactable = skipTurn > 0;
        LeaveBattleGem.transform.parent.GetComponent<Button>().interactable = leaveBattle > 0 && !GameManager.Instance.IsInWorldScene;
        DoubleDamageGem.transform.parent.GetComponent<Button>().interactable = doubleDamage > 0 && !GameManager.Instance.IsInWorldScene && !PlayerStats.Instance.DoubleDamage;
        DoubleHealthGem.transform.parent.GetComponent<Button>().interactable = doubleHealth > 0 && !GameManager.Instance.IsInWorldScene && !PlayerStats.Instance.DoubleHealth;
    }

    public void SkipTurn()
    {
        PlayerStats.Instance.MovesLeft = 0;
        var listString = PlayerInventory.Instance.AvailablePowerups;
        var match = listString.FirstOrDefault(x => x.CardType == CardTypes.SkipTurn);

        if (match != null)
            listString.Remove(match);
        UpdateGems();
    }

    public void LeaveBattle()
    {
        GameManager.Instance.LoadMapScene();
        UpdateGems();
    }

    public void DoubleDamage()
    {
        PlayerStats.Instance.DoubleDamage = true;
        UpdateGems();
    }

    public void DoubleHealth()
    {
        PlayerStats.Instance.DoubleHealth = true;
        UpdateGems();
    }


}
