public class WoodCard01 : Card
{
    public override CardType Type { get; protected set; }
     = CardType.Wood;

    public override string CardName { get; protected set; }
     = "Sharpened Axes";

    public override string Description { get; protected set; }
     = "Gain an extra +1 wood per worker";

    public override bool ApplyModifiers()
    {
        CurrentTurnModifiers.Instance
            .AdjustAdditionalWoodPerPopulation(1);
        return true;
    }
}
