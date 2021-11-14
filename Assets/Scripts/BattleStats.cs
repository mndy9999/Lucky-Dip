using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStats : MonoBehaviour
{

    public int Damage;
    public int Healing;
    public int Ability;

    private int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Heal(int val)
    {
        health += val;
    }

}
