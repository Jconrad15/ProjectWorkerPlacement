using System;
using System.Collections.Generic;
using UnityEngine;

public enum PhaseState { WorkerPlacement, Card, Growth };
/// <summary>
/// Singleton directing phases
/// </summary>
public class PhaseController : MonoBehaviour
{
    private PhaseState phase;

    private Action cbOnStartWorkerPlacementPhase;
    private Action cbOnStartCardPhase;
    private Action cbOnStartGrowthPhase;

    public static PhaseController Instance { get; private set; }
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

    public void StartPhaseSystem()
    {
        StartWorkerPlacementPhase();
    }

    private void StartWorkerPlacementPhase()
    {
        phase = PhaseState.WorkerPlacement;
        cbOnStartWorkerPlacementPhase?.Invoke();
    }

    private void StartCardPhase()
    {
        phase = PhaseState.Card;
        cbOnStartCardPhase?.Invoke();
    }

    private void StartGrowthPhase()
    {
        phase = PhaseState.Growth;
        cbOnStartGrowthPhase?.Invoke();
    }

    public void NextTurn()
    {
        if (phase == PhaseState.WorkerPlacement)
        {
            StartCardPhase();
        }
        else if (phase == PhaseState.Card)
        {
            StartGrowthPhase();
        }
        else if (phase == PhaseState.Growth)
        {
            StartWorkerPlacementPhase();
        }
        else
        {
            Debug.LogError("Something bad happened with the turn order.");
        }
    }

    public void RegisterOnStartWorkerPlacementPhase(Action callbackfunc)
    {
        cbOnStartWorkerPlacementPhase += callbackfunc;
    }

    public void UnregisterOnStartWorkerPlacementPhase(Action callbackfunc)
    {
        cbOnStartWorkerPlacementPhase -= callbackfunc;
    }

    public void RegisterOnStartCardPhase(Action callbackfunc)
    {
        cbOnStartCardPhase += callbackfunc;
    }

    public void UnregisterOnStartCardPhase(Action callbackfunc)
    {
        cbOnStartCardPhase -= callbackfunc;
    }

    public void RegisterOnStartGrowthPhase(Action callbackfunc)
    {
        cbOnStartGrowthPhase += callbackfunc;
    }

    public void UnregisterOnStartGrowthPhase(Action callbackfunc)
    {
        cbOnStartGrowthPhase -= callbackfunc;
    }
}