using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck
{
    private Queue<Card> cards;

    public CardDeck()
    {
        cards = CardDeckCreator.CreateDeck();
    }

    public Card DrawCard()
    {
        if (cards.Count == 0) 
        {
            Debug.Log("No more cards");
            return null; 
        }

        return cards.Dequeue();
    }

    public Card Peek()
    {
        return cards.Peek();
    }

}
