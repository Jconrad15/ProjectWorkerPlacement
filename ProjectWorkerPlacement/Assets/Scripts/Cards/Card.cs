using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Food, Population, Military };
public class Card
{
    public CardAction cardAction;
    public CardType cardType;

    public Card(CardAction cardAction, CardType cardType)
    {
        this.cardAction = cardAction;
        this.cardType = cardType;
    }

    public bool Perform()
    {
        return cardAction.ApplyModifiers();
    }

}
