using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int AttackDamage;
    public int AbilityPower;
    public int Healing;

    public int CurrentHealth;

    public int GetExtraPower(CardTypes card)
    {
        switch (card) {

            case CardTypes.Attack:
                return AttackDamage;
            case CardTypes.Ability:
                return AbilityPower;
            case CardTypes.Healing:
                return Healing;
            default:
                return 0;
        }

    }

}
