public class StoneCard01 : Card
{
    public override CardType Type { get; protected set; }
     = CardType.Stone;

    public override string CardName { get; protected set; }
     = "Speedy Pickaxes";

    public override string Description { get; protected set; }
     = "Gain an extra +1 stone per worker";

    public override bool ApplyModifiers()
    {
        CurrentTurnModifiers.Instance
            .AdjustAdditionalStonePerPopulation(1);
        return true;
    }
}
