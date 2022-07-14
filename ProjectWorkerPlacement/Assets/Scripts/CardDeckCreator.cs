using System.Collections.Generic;
using UnityEngine;

public static class CardDeckCreator
{
    private static bool cardsInitialized = false;

    private static readonly List<Card> foodCards =
        new List<Card>();
    private static void CreateFoodCards()
    {
        foodCards.Add(new FoodCard01());

    }

    private static readonly List<Card> militaryCards = new
        List<Card>();
    private static void CreateMilitaryCards()
    {
        militaryCards.Add(new MilitaryCard01());
        militaryCards.Add(new MilitaryCard02());
    }

    private static readonly List<Card> populationCards = new
        List<Card>();
    private static void CreatePopulationCards()
    {
        populationCards.Add(new PopulationCard01());
    }

    private static readonly List<Card> woodCards = new
        List<Card>();
    private static void CreateWoodCards()
    {
        woodCards.Add(new WoodCard01());
    }

    private static readonly List<Card> stoneCards = new
        List<Card>();
    private static void CreateStoneCards()
    {
        stoneCards.Add(new StoneCard01());
    }

    private static readonly List<Card> allPossibleCards =
        new List<Card>();
    private static void CreateAllPossibleCardsList()
    {
        foreach (Card card in foodCards)
        {
            allPossibleCards.Add(card);
        }
        foreach (Card card in militaryCards)
        {
            allPossibleCards.Add(card);
        }
        foreach (Card card in populationCards)
        {
            allPossibleCards.Add(card);
        }
        foreach (Card card in woodCards)
        {
            allPossibleCards.Add(card);
        }
        foreach (Card card in stoneCards)
        {
            allPossibleCards.Add(card);
        }
    }

    private static void InitializeCardLists()
    {
        CreateFoodCards();
        CreateMilitaryCards();
        CreatePopulationCards();
        CreateWoodCards();
        CreateStoneCards();
        CreateAllPossibleCardsList();

        cardsInitialized = true;
    }

    public static Queue<Card> CreateDeck()
    {
        if (cardsInitialized == false)
        {
            InitializeCardLists();
        }

        int deckSize = 10;
        Queue<Card> deck = new Queue<Card>();

        for (int i = 0; i < deckSize; i++)
        {
            // TODO: Better deck creation
            int selectedCard =
                Random.Range(0, allPossibleCards.Count);

            Card c = allPossibleCards[selectedCard];

            deck.Enqueue(c);
        }

        return deck;
    }

}
