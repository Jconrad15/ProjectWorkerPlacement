using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardPrefabDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private SpriteRenderer sr;

    public void SetupCard(Card card)
    {
        nameText.SetText(card.CardName);
        descriptionText.SetText(card.Description);

        Color c = CardDisplayProperties.DetermineCardColor(card);
        sr.color = c;

    }


}
