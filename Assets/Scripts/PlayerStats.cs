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

    public int MovesLeft;

    public int AttackPower;
    public int AbilityPower;
    public int HealingPower;

    public int MaxHealth;

    public int UnassignedPoints;

    // Start is called before the first frame update
    void Awake()
    {
        MovesLeft = 10;
        AttackPower = 1;
        AbilityPower = 1;
        HealingPower = 1;
        MaxHealth = 20;
        UnassignedPoints = 10;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
