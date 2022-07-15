using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrowthEstimatorDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI foodText;

    [SerializeField]
    private TextMeshProUGUI woodText;

    [SerializeField]
    private TextMeshProUGUI stoneText;

    [SerializeField]
    private TextMeshProUGUI defenseText;

    [SerializeField]
    private TextMeshProUGUI populationText;

    [SerializeField]
    private TextMeshProUGUI wonderText;

    private void Start()
    {
        GrowthEstimator ge = FindObjectOfType<GrowthEstimator>();

        ge.RegisterOnFoodEstimationChanged(
            OnFoodEstimationChanged);
        ge.RegisterOnWoodEstimationChanged(
            OnWoodEstimationChanged);
        ge.RegisterOnStoneEstimationChanged(
            OnStoneEstimationChanged);
        ge.RegisterOnDefenseEstimationChanged(
            OnDefenseEstimationChanged);
        ge.RegisterOnPopulationEstimationChanged(
            OnPopulationEstimationChanged);
        ge.RegisterOnWonderEstimationChanged(
            OnWonderEstimationChanged);

        SetAllZero();
    }

    private void OnFoodEstimationChanged(int amount)
    {
        foodText.SetText(amount.ToString());
    }

    private void OnWoodEstimationChanged(int amount)
    {
        woodText.SetText(amount.ToString());
    }

    private void OnStoneEstimationChanged(int amount)
    {
        stoneText.SetText(amount.ToString());
    }

    private void OnDefenseEstimationChanged(int amount)
    {
        defenseText.SetText(amount.ToString());
    }

    private void OnPopulationEstimationChanged(int amount)
    {
        populationText.SetText(amount.ToString());
    }

    private void OnWonderEstimationChanged(int amount)
    {
        wonderText.SetText(amount.ToString());
    }

    private void SetAllZero()
    {
        foodText.SetText("0");
        woodText.SetText("0");
        stoneText.SetText("0");
        defenseText.SetText("0");
        populationText.SetText("0");
        wonderText.SetText("0");
    }

}
