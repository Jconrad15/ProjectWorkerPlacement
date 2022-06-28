using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck
{
    private Queue<Card> cards;

    public CardDeck()
    {
        cards = new Queue<Card>();

        // TODO: create the deck of cards
        // For now create two blank cards
        cards.Enqueue(new Card());
        cards.Enqueue(new Card());
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



}
