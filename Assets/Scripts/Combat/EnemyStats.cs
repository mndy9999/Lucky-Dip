﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static int Health;
    public int AttackPower;
    public int AbilityPower;
    public int HealingPower;


    public CardDisplay EnemyCard;
    public TurnManager turnManager;
    // Start is called before the first frame update
    void Awake()
    {
        Health = Random.Range(PlayerStats.SCurrentHealth-4,PlayerStats.SCurrentHealth+4);
        AttackPower = 1;
        AbilityPower = 1;
        HealingPower = 1;
    }
    public void EnemyTurn()
    {
        //could not invoke a different files function
        Invoke("EnemyTurn2",1);
    }
    private void EnemyTurn2(){ 
        turnManager.CardSeleted(EnemyCard);
        //print(EnemyCard);
    }
}