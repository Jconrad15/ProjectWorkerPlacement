using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryCard01 : Card
{
    public override CardType Type { get; protected set; }
        = CardType.Military;

    public override string CardName { get; protected set; }
     = "Small Raid";

    public override string Description { get; protected set; }
     = "1 raider arrives";

    public override bool ApplyModifiers()
    {
        CurrentTurnModifiers.Instance.AdjustAttackers(1);
        return true;
    }
}
