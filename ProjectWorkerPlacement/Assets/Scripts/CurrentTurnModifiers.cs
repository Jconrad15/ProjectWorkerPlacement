using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton tracking modifiers.
/// </summary>
public class CurrentTurnModifiers: MonoBehaviour
{
    public int AdditionalPopulation { get; private set; }
    public int AdditionalFoodPerPopulation { get; private set; }
    public int FoodUpkeepPerPopulation { get; private set; }
    public int Attackers { get; private set; }
    public int DefensePerDefender { get; private set; }
    public int AdditionalChildren { get; private set; }

    public static CurrentTurnModifiers Instance { get; private set; }
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

    private void Start()
    {
        SetDefault();

        PhaseController.Instance
            .RegisterOnStartWorkerPlacementPhase(SetDefault);
    }

    /// <summary>
    /// Set modifiers to default values on start worker placement phase.
    /// </summary>
    private void SetDefault()
    {
        AdditionalPopulation = 0;
        AdditionalFoodPerPopulation = 0;
        FoodUpkeepPerPopulation = 0;
        Attackers = 0;
        DefensePerDefender = 0;
        AdditionalChildren = 0;
    }

    public void SetAdditionalPopulation(int amount)
    {
        AdditionalPopulation = amount;
    }

    public void AdjustAdditionalFoodPerPopulation(int amount)
    {
        AdditionalFoodPerPopulation += amount;
    } 

    public void AdjustFoodUpkeepPerPopulation(int amount)
    {
        FoodUpkeepPerPopulation += amount;
    }

    public void AdjustAttackers(int amount)
    {
        Attackers += amount;
    }

    public void AdjustDefensePerDefender(int amount)
    {
        DefensePerDefender += amount;
    }

    public void AdjustAdditionalChildren(int amount)
    {
        AdditionalChildren += amount;
    }

}
