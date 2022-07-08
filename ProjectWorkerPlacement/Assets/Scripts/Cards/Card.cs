using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Food, Population, Military, Wood, Stone };
public abstract class Card
{
    public abstract CardType Type { get; protected set; }
    public abstract string CardName { get; protected set; }
    public abstract string Description { get; protected set; }

    public abstract bool ApplyModifiers();

}
