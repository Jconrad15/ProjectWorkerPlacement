using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckDisplay : MonoBehaviour
{
    [SerializeField]
    private CardPhaseManager cardPhaseManager;

    [SerializeField]
    private GameObject knownCardDeck;
    private SpriteRenderer knownSR;

    [SerializeField]
    private GameObject hiddenCardDeck;
    private SpriteRenderer hiddenSR;

    private void Start()
    {
        cardPhaseManager.RegisterOnCardDrawn(OnCardDrawn);
        cardPhaseManager.RegisterOnCardDecksCreated(InitialPeek);

        knownSR = knownCardDeck.GetComponent<SpriteRenderer>();
        hiddenSR = hiddenCardDeck.GetComponent<SpriteRenderer>();
    }

    private void InitialPeek()
    {
        OnCardDrawn(null, DeckType.Hidden);
        OnCardDrawn(null, DeckType.Known);
    }

    private void OnCardDrawn(Card drawnCard, DeckType deckType)
    {
        // Need to peak at top card on deck
        Card peekedCard = cardPhaseManager.PeekAtCard(deckType);

        // Determine which spriterenderer to use
        SpriteRenderer currentSR = null;
        switch (deckType)
        {
            case DeckType.Hidden:
                currentSR = hiddenSR;
                break;

            case DeckType.Known:
                currentSR = knownSR;
                break;
        }

        Color c = ColorDatabase.Instance
            .GetColorByCardType(peekedCard.Type);
        currentSR.color = c;
    }
}
