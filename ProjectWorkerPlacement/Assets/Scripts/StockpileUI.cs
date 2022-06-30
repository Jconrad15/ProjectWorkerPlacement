using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockpileUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI foodText;
    [SerializeField]
    private TextMeshProUGUI populationText;

    private void Start()
    {
        Stockpile s = FindObjectOfType<Stockpile>();
        s.RegisterOnFoodCountChanged(OnFoodCountChanged);
        s.RegisterOnMeepleCountChanged(OnMeepleCountChanged);
    }

    private void OnFoodCountChanged(int amount)
    {
        foodText.SetText("Food: " + amount);
    }

    private void OnMeepleCountChanged(int amount)
    {
        populationText.SetText("Population: " + amount);
    }
}
