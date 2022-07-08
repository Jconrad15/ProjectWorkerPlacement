using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton for starting the game.
/// </summary>
public class GameInit : MonoBehaviour
{
    [SerializeField]
    private int startingMeepleCount = 3;

    [SerializeField]
    private MeepleCreator meepleCreator;

    private Action cbOnStartInitializeGame;

    public static GameInit Instance { get; private set; }
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

    public void StartButton()
    {
        cbOnStartInitializeGame?.Invoke();

        meepleCreator.NewHomeMeeple(startingMeepleCount);

        PhaseController.Instance.StartPhaseSystem();
    }

    public void RegisterOnStartInitializeGame(Action callbackfunc)
    {
        cbOnStartInitializeGame += callbackfunc;
    }

    public void UnregisterOnStartInitializeGame(Action callbackfunc)
    {
        cbOnStartInitializeGame -= callbackfunc;
    }

}
