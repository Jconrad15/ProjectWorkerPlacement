using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeckType { Hidden, Known };
public class CardPhaseManager : MonoBehaviour
{
    private Action<Card, DeckType> cbOnCardDrawn;
    private Action cbOnCardsCleared;
    private Action cbOnCardDecksCreated;

    private CardDeck knownCardDeck;
    private CardDeck hiddenCardDeck;

    private List<Card> currentCards = new List<Card>();

    // ------------------
    // Card Phase Outline
    //
    // Show hidden card
    // Perfrom known card
    // Perform hidden card
    // end card phase
    //
    // ------------------

    private void Start()
    {
        PhaseController.Instance
            .RegisterOnStartCardPhase(OnStartCardPhase);

        CreateCardDecks();

        // Draw the first known card at the beginning of the game
        DrawNextKnownCard();
    }

    private void CreateCardDecks()
    {
        knownCardDeck = new CardDeck();
        hiddenCardDeck = new CardDeck();
        cbOnCardDecksCreated?.Invoke();
    }

    private void OnStartCardPhase()
    {
        StartCoroutine(CardPhase());
    }

    private IEnumerator CardPhase()
    {
        // Perform the card phase
        Debug.Log("Perform Card Phase");

        DrawHiddenCard();
        yield return new WaitForSeconds(1.5f);

        // Perform Cards
        foreach (Card card in currentCards)
        {
            bool cardIsDone = false;
            while (cardIsDone == false)
            {
                cardIsDone = card.ApplyModifiers();

                yield return new WaitForSeconds(0.4f);
            }
        }

        ClearCards();
        yield return new WaitForSeconds(1f);

        DrawNextKnownCard();
        yield return new WaitForEndOfFrame();

        PhaseController.Instance.NextPhase();
    }

    private void ClearCards()
    {
        // Destroy the cards
        currentCards.Clear();
        cbOnCardsCleared?.Invoke();
    }

    private void DrawHiddenCard()
    {
        Card drawnHiddenCard = hiddenCardDeck.DrawCard();
        if (drawnHiddenCard == null) { return; }

        currentCards.Add(drawnHiddenCard);
        cbOnCardDrawn?.Invoke(drawnHiddenCard, DeckType.Hidden);
    }

    private void DrawNextKnownCard()
    {
        Card drawNextKnownCard = knownCardDeck.DrawCard();
        if (drawNextKnownCard == null) { return; }

        currentCards.Add(drawNextKnownCard);
        cbOnCardDrawn?.Invoke(drawNextKnownCard, DeckType.Known);
    }

    public Card PeekAtCard(DeckType deckType)
    {
        if (deckType == DeckType.Hidden)
        {
            return hiddenCardDeck.Peek();
        }
        else
        {
            return knownCardDeck.Peek();
        }
    }

    public void RegisterOnCardDrawn(Action<Card, DeckType> callbackfunc)
    {
        cbOnCardDrawn += callbackfunc;
    }

    public void UnregisterOnCardDrawn(Action<Card, DeckType> callbackfunc)
    {
        cbOnCardDrawn -= callbackfunc;
    }

    public void RegisterOnCardsCleared(Action callbackfunc)
    {
        cbOnCardsCleared += callbackfunc;
    }

    public void UnregisterOnCardsCleared(Action callbackfunc)
    {
        cbOnCardsCleared -= callbackfunc;
    }

    public void RegisterOnCardDecksCreated(Action callbackfunc)
    {
        cbOnCardDecksCreated += callbackfunc;
    }

    public void UnregisterOnCardDecksCreated(Action callbackfunc)
    {
        cbOnCardDecksCreated -= callbackfunc;
    }
}
