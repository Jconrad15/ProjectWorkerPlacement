using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardDisplayProperties
{
    public static Color DetermineCardColor(Card card)
    {
        Color c = Color.white;
        switch (card.Type)
        {
            case CardType.Food:
                c = Color.green;
                break;

            case CardType.Population:
                c = Color.blue;
                break;

            case CardType.Military:
                c = Color.red;
                break;
        }

        return c;
    }


}
