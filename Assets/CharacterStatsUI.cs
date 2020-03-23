using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsUI : MonoBehaviour
{
    public PlayerStats playerStats;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        UpdateValues();
    }

    void UpdateValues()
    {
        AttackPowerText.text = string.Format(attackText, playerStats.AttackPower.ToString());
        AbilityPowerText.text = string.Format(abilityText, playerStats.AbilityPower.ToString());
        HealingPowerText.text = string.Format(healingText, playerStats.HealingPower.ToString());
        MaxHealthText.text = string.Format(healthText, playerStats.MaxHealth.ToString());
        UnassignedPointsText.text = string.Format(pointsText, playerStats.UnassignedPoints.ToString());

        tempAttack = playerStats.AttackPower;
        tempAbility = playerStats.AbilityPower;
        tempHealing = playerStats.HealingPower;
        tempHealth = playerStats.MaxHealth;
        tempPoints = playerStats.UnassignedPoints;
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
        playerStats.AttackPower = tempAttack;
        playerStats.AbilityPower = tempAbility;
        playerStats.HealingPower = tempHealing;
        playerStats.MaxHealth = tempHealth;
        playerStats.UnassignedPoints = tempPoints;
    }

    public void IncreaseDecreaseAttack(bool increase)
    {
        if (increase && tempPoints > 0)
        {
            tempAttack += 1;
            tempPoints--;
        }
        else if (!increase && tempAttack > playerStats.AttackPower)
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
        else if (!increase && tempAbility > playerStats.AbilityPower)
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
        else if (!increase && tempHealing > playerStats.HealingPower)
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
        else if (!increase && tempHealth > playerStats.MaxHealth)
        {
            tempHealth -= 10;
            tempPoints++;
        }
        UpdateTempValues();
    }


}
