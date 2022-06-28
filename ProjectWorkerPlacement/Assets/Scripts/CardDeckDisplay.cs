using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckDisplay : MonoBehaviour
{
    [SerializeField]
    private CardPhaseManager cardPhaseManager;

    [SerializeField]
    private GameObject knownCardDeck;
    [SerializeField]
    private GameObject hiddenCardDeck;

    private void Start()
    {
        cardPhaseManager.RegisterOnCardDrawn(OnCardDrawn);
    }

    private void OnCardDrawn(Card card, DeckType deckType)
    {
        // TODO: Show back of the next card in the deck


    }
}
