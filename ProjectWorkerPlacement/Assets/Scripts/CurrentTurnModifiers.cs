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
    public int FoodRaiders { get; private set; }
    public int AttackingWarriors { get; private set; }
    public int DefensePerDefender { get; private set; }
    public int AdditionalChildren { get; private set; }
    public int AdditionalWoodPerPopulation { get;private set; }
    public int AdditionalStonePerPopulation { get; private set; }

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
        FoodRaiders = 0;
        AttackingWarriors = 0;
        DefensePerDefender = 0;
        AdditionalChildren = 0;
        AdditionalWoodPerPopulation = 0;
        AdditionalStonePerPopulation = 0;
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

    public void AdjustFoodRaiders(int amount)
    {
        FoodRaiders += amount;
    }

    public void AdjustAttackingWarriors(int amount)
    {
        AttackingWarriors += amount;
    }

    public void AdjustDefensePerDefender(int amount)
    {
        DefensePerDefender += amount;
    }

    public void AdjustAdditionalChildren(int amount)
    {
        AdditionalChildren += amount;
    }

    public void AdjustAdditionalWoodPerPopulation(int amount)
    {
        AdditionalWoodPerPopulation += amount;
    }

    public void AdjustAdditionalStonePerPopulation(int amount)
    {
        AdditionalStonePerPopulation += amount;
    }
}
