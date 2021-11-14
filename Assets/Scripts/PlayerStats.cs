using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // singleton
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = (PlayerStats)FindObjectOfType(typeof(PlayerStats));
            return instance;
        }
    }

    public int CurrentHealth;

    public int MovesLeft;

    public int AttackPower;
    public int AbilityPower;
    public int HealingPower;

    public int MaxHealth;

    public int UnassignedPoints;

    private bool mDoubleDamage;
    public bool DoubleDamage
    {
        get
        {
            return mDoubleDamage;
        }
        set
        {
            if (mDoubleDamage == value)
                return;
            if (value)
            {
                AttackPower *= 2;
                AbilityPower *= 2;
            }
            else
            {
                AttackPower /= 2;
                AbilityPower /= 2;
            }
        }
    }

    private bool mDoubleHealth;
    public bool DoubleHealth
    {
        get
        {
            return mDoubleHealth;
        }
        set
        {
            if (mDoubleHealth == value)
                return;
            if (value)
            {
                MaxHealth *= 2;
            }
            else
            {
                MaxHealth /= 2;
            }
            
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        MovesLeft = 2;
        AttackPower = 1;
        AbilityPower = 1;
        HealingPower = 1;
        MaxHealth = 20;
        UnassignedPoints = 10;

    }

}
