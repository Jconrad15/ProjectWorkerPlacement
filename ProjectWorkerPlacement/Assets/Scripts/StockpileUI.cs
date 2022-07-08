using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockpileUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI foodText;
    [SerializeField]
    private TextMeshProUGUI woodText;
    [SerializeField]
    private TextMeshProUGUI stoneText;
    [SerializeField]
    private TextMeshProUGUI populationText;


    private void Start()
    {
        Stockpile s = FindObjectOfType<Stockpile>();
        s.RegisterOnFoodCountChanged(OnFoodCountChanged);
        s.RegisterOnWoodCountChanged(OnWoodCountChanged);
        s.RegisterOnStoneCountChanged(OnStoneCountChanged);
        s.RegisterOnMeepleCountChanged(OnMeepleCountChanged);
    }

    private void OnFoodCountChanged(int amount)
    {
        foodText.SetText(amount.ToString());
    }

    private void OnWoodCountChanged(int amount)
    {
        woodText.SetText(amount.ToString());
    }

    private void OnStoneCountChanged(int amount)
    {
        stoneText.SetText(amount.ToString());
    }

    private void OnMeepleCountChanged(int amount)
    {
        populationText.SetText(amount.ToString());
    }
}
