using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCard : Card
{
    public int RollLow;
    public int RollMed;
    public int RollHigh;

    public GameObject Enemy;

    protected int GetRollValue(int roll)
    {
        if (roll < 2)
            return RollLow;
        else if (roll < 4)
            return RollMed;
        else
            return RollHigh;
    }

}
