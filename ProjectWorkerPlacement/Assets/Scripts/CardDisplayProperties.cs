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
                c = new Color32(57, 159, 44, 255);
                break;

            case CardType.Population:
                c = new Color32(25, 37, 144, 255);
                break;

            case CardType.Military:
                c = new Color32(157, 2, 8, 255);
                break;
        }

        return c;
    }


}
