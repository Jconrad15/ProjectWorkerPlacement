using System;
using System.Collections.Generic;
using UnityEngine;

public enum PhaseState { WorkerPlacement, Card, Growth };
/// <summary>
/// Singleton directing phases
/// </summary>
public class PhaseController : MonoBehaviour
{
    public PhaseState Phase { get; private set; }

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
        Phase = PhaseState.WorkerPlacement;
        cbOnStartWorkerPlacementPhase?.Invoke();
    }

    private void StartCardPhase()
    {
        Phase = PhaseState.Card;
        cbOnStartCardPhase?.Invoke();
    }

    private void StartGrowthPhase()
    {
        Phase = PhaseState.Growth;
        cbOnStartGrowthPhase?.Invoke();
    }

    public void NextPhase()
    {
        if (Phase == PhaseState.WorkerPlacement)
        {
            StartCardPhase();
        }
        else if (Phase == PhaseState.Card)
        {
            StartGrowthPhase();
        }
        else if (Phase == PhaseState.Growth)
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