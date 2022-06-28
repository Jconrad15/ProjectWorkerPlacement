using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawnCardDisplay : MonoBehaviour
{
    [SerializeField]
    private CardPhaseManager cardPhaseManager;

    [SerializeField]
    private GameObject drawnCardPrefab;

    [SerializeField]
    private Vector2 drawnHiddenCardPos;
    [SerializeField]
    private Vector2 drawnKnownCardPos;

    private GameObject createdHiddenCard;
    private GameObject createdKnownCard;

    private void Start()
    {
        cardPhaseManager.RegisterOnCardDrawn(OnCardDrawn);
        cardPhaseManager.RegisterOnCardsCleared(OnCardsCleared);
    }

    private void OnCardDrawn(Card card, DeckType deckType)
    {
        GameObject newCard = Instantiate(drawnCardPrefab, transform);

        Vector2 cardPosition;
        // Deck type determines position
        if (deckType == DeckType.Hidden)
        {
            createdHiddenCard = newCard;
            cardPosition = drawnHiddenCardPos;
        }
        else
        {
            createdKnownCard = newCard;
            cardPosition = drawnKnownCardPos;
        }

        newCard.transform.position = cardPosition;
    }

    private void OnCardsCleared()
    {
        DestroyHiddenCard();
        DestroyKnownCard();
    }

    private void DestroyKnownCard()
    {
        Destroy(createdKnownCard);
    }

    private void DestroyHiddenCard()
    {
        Destroy(createdHiddenCard);
    }

}
