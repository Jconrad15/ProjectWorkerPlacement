using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Changes the color of an item based on the ColorDatabase.
/// </summary>
public class ColorReference : MonoBehaviour
{
    [SerializeField]
    private CardType cardColorType;

    private void Start()
    {
        GameInit.Instance
            .RegisterOnStartInitializeGame(OnStartInitializeGame);
    }

    private void OnStartInitializeGame()
    {
        SetColor();
    }

    private void SetColor()
    {
        Color selectedColor = ColorDatabase.Instance
            .GetColorByCardType(cardColorType);

        if (TryGetComponent(out SpriteRenderer sr))
        {
            sr.color = selectedColor;
        }
        else if (TryGetComponent(out Image image))
        {
            image.color = selectedColor;
        }
        else
        {
            Debug.LogWarning("No sprite renderer for color");
        }
    }
}
