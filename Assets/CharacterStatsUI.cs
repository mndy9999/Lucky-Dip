using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsUI : MonoBehaviour
{

    public TextMeshProUGUI AttackPowerText;
    public TextMeshProUGUI AbilityPowerText;
    public TextMeshProUGUI HealingPowerText;

    public TextMeshProUGUI MaxHealthText;

    public TextMeshProUGUI UnassignedPointsText;

    private int tempAttack;
    private int tempAbility;
    private int tempHealing;
    private int tempHealth;
    private int tempPoints;

    private const string attackText = "Attack Power: {0}";
    private const string abilityText = "Ability Power: {0}";
    private const string healingText = "Healing Power: {0}";
    private const string healthText = "Max Health: \n{0}";
    private const string pointsText = "Unassigned Points: {0}";

    private void OnEnable()
    {
        UpdateValues();
    }

    void UpdateValues()
    {
        AttackPowerText.text = string.Format(attackText, PlayerStats.Instance.AttackPower.ToString());
        AbilityPowerText.text = string.Format(abilityText, PlayerStats.Instance.AbilityPower.ToString());
        HealingPowerText.text = string.Format(healingText, PlayerStats.Instance.HealingPower.ToString());
        MaxHealthText.text = string.Format(healthText, PlayerStats.Instance.MaxHealth.ToString());
        UnassignedPointsText.text = string.Format(pointsText, PlayerStats.Instance.UnassignedPoints.ToString());

        tempAttack = PlayerStats.Instance.AttackPower;
        tempAbility = PlayerStats.Instance.AbilityPower;
        tempHealing = PlayerStats.Instance.HealingPower;
        tempHealth = PlayerStats.Instance.MaxHealth;
        tempPoints = PlayerStats.Instance.UnassignedPoints;
    }

    void UpdateTempValues()
    {
        AttackPowerText.text = string.Format(attackText, tempAttack);
        AbilityPowerText.text = string.Format(abilityText, tempAbility);
        HealingPowerText.text = string.Format(healingText, tempHealing);
        MaxHealthText.text = string.Format(healthText, tempHealth);
        UnassignedPointsText.text = string.Format(pointsText, tempPoints);
    }

    public void UpdatePlayerStats()
    {
        PlayerStats.Instance.AttackPower = tempAttack;
        PlayerStats.Instance.AbilityPower = tempAbility;
        PlayerStats.Instance.HealingPower = tempHealing;
        PlayerStats.Instance.MaxHealth = tempHealth;
        PlayerStats.Instance.UnassignedPoints = tempPoints;
    }

    public void IncreaseDecreaseAttack(bool increase)
    {
        if (increase && tempPoints > 0)
        {
            tempAttack += 1;
            tempPoints--;
        }
        else if (!increase && tempAttack > PlayerStats.Instance.AttackPower)
        {
            tempAttack -= 1;
            tempPoints++;
        }    
        UpdateTempValues();
    }

    public void IncreaseDecreaseAbility(bool increase)
    {
        if (increase && tempPoints > 0)
        {
            tempAbility += 1;
            tempPoints--;
        }
        else if (!increase && tempAbility > PlayerStats.Instance.AbilityPower)
        {
            tempAbility -= 1;
            tempPoints++;
        }
        UpdateTempValues();
    }

    public void IncreaseDecreaseHealing(bool increase)
    {
        if (increase && tempPoints > 0)
        {
            tempHealing += 1;
            tempPoints--;
        }
        else if (!increase && tempHealing > PlayerStats.Instance.HealingPower)
        {
            tempHealing -= 1;
            tempPoints++;
        }
        UpdateTempValues();
    }

    public void IncreaseDecreaseHealth(bool increase)
    {
        if (increase && tempPoints > 0)
        {
            tempHealth += 10;
            tempPoints--;
        }
        else if (!increase && tempHealth > PlayerStats.Instance.MaxHealth)
        {
            tempHealth -= 10;
            tempPoints++;
        }
        UpdateTempValues();
    }


}
