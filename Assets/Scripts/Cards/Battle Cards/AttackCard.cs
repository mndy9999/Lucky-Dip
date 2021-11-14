using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : BattleCard
{
    public override void Use(BattleStats caster, BattleStats enemy, int roll)
    {
        var val = GetRollValue(roll) + caster.Damage;
        enemy.TakeDamage(val);
    }
}
