using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCard : BattleCard
{
    public override void Use(BattleStats caster, BattleStats enemy, int roll)
    {
        var val = GetRollValue(roll) + caster.Ability;
        enemy.TakeDamage(val);
    }
}
