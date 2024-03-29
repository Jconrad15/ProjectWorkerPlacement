using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryCard01 : Card
{
    public override CardType Type { get; protected set; }
        = CardType.Military;

    public override string CardName { get; protected set; }
     = "Small Food Raid";

    public override string Description { get; protected set; }
     = "1 food raider arrives";

    public override bool ApplyModifiers()
    {
        CurrentTurnModifiers.Instance.AdjustFoodRaiders(1);
        return true;
    }
}
