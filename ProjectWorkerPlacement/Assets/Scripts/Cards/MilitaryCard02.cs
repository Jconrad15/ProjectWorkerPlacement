using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryCard02 : Card
{
    public override CardType Type { get; protected set; }
        = CardType.Military;

    public override string CardName { get; protected set; }
     = "Small Attack Group";

    public override string Description { get; protected set; }
     = "1 attacking warrior arrives";

    public override bool ApplyModifiers()
    {
        CurrentTurnModifiers.Instance.AdjustAttackingWarriors(1);
        return true;
    }
}
