using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton color database.
/// </summary>
public class ColorDatabase : MonoBehaviour
{
    [SerializeField]
    private Color populationColor;
    [SerializeField]
    private Color foodColor;
    [SerializeField]
    private Color woodColor;
    [SerializeField]
    private Color stoneColor;
    [SerializeField]
    private Color militaryColor;

    public static ColorDatabase Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Color GetColorByCardType(CardType cardType)
    {
        switch (cardType)
        {
            case CardType.Food:
                return foodColor;

            case CardType.Population:
                return populationColor;

            case CardType.Military:
                return militaryColor;

            case CardType.Wood:
                return woodColor;

            case CardType.Stone:
                return stoneColor;

            default:
                return Color.magenta;
        }
    }

}
