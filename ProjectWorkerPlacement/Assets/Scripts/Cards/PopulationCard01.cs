using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationCard01 : Card
{
    public override CardType Type { get; protected set; }
        = CardType.Population;

    public override string CardName { get; protected set; }
     = "Twins";

    public override string Description { get; protected set; }
     = "Gain an extra +1 population from the population slots";

    public override bool ApplyModifiers()
    {
        CurrentTurnModifiers.Instance.AdjustAdditionalChildren(1);
        return true;
    }

}
