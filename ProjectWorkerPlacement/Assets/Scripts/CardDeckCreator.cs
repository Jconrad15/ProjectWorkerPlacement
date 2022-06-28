using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardDeckCreator
{




    public static Queue<Card> CreateDeck()
    {
        int deckSize = 10;
        Queue<Card> deck = new Queue<Card>();

        for (int i = 0; i < deckSize; i++)
        {
            CardAction action = new CardAction();

            Card c = new Card(action, CardType.Food);

            deck.Enqueue(c);
        }




        return deck;
    }



}
