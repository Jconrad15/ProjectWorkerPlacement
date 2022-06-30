using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton tracking modifiers.
/// </summary>
public class CurrentTurnModifiers: MonoBehaviour
{
    public int PopulationGrowth { get; private set; }

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


    public void AdjustPopulationGrowth(int amount)
    {
        PopulationGrowth += amount;
    }



}
