using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card01 : Card
{
    public override CardType Type { get; protected set; }
     = CardType.Food;

    public override string CardName { get; protected set; }
     = "Bountiful Harvest";

    public override string Description { get; protected set; }
     = "Gain an extra +1 food per farmer";

    public override bool ApplyModifiers()
    {
        CurrentTurnModifiers.Instance.SetAdditionalFoodPerPopulation(1);
        return true;
    }
}
