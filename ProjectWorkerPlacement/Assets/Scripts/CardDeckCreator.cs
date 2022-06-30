using System.Collections.Generic;
using UnityEngine;

public static class CardDeckCreator
{
    private static readonly List<Card> allPossibleCards = new List<Card>();

    private static void CreateAllPossibleCardsList()
    {
        allPossibleCards.Add(new Card01());
    }

    public static Queue<Card> CreateDeck()
    {
        if (allPossibleCards.Count <= 0)
        {
            CreateAllPossibleCardsList();
        }

        int deckSize = 10;
        Queue<Card> deck = new Queue<Card>();

        for (int i = 0; i < deckSize; i++)
        {
            // TODO: Better deck creation
            int selectedCard = Random.Range(0, allPossibleCards.Count);
            Card c = allPossibleCards[selectedCard];

            deck.Enqueue(c);
        }

        return deck;
    }

}
