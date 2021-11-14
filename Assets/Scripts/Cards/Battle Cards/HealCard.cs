using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : BattleCard
{
    public override void Use(BattleStats caster, BattleStats enemy, int roll)
    {
        var val = GetRollValue(roll) + caster.Healing;
        caster.Heal(val);
    }
}
