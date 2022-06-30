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

    }

    public void SetAdditionalPopulation(int amount)
    {
        AdditionalPopulation = amount;
    }

    public void SetAdditionalFoodPerPopulation(int amount)
    {
        AdditionalFoodPerPopulation = amount;
    } 

}
