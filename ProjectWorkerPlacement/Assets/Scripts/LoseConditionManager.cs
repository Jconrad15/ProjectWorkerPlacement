using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseConditionManager : MonoBehaviour
{
    private Stockpile stockpile;

    private void Start()
    {
        stockpile = FindObjectOfType<Stockpile>();

        FindObjectOfType<MeepleCreator>()
            .RegisterOnMeepleDestroyed(OnMeepleDestroyed);
    }

    private void OnMeepleDestroyed()
    {
        if (stockpile.MeepleCount <= 0)
        {
            Debug.Log("You Lose");
        }
    }
}
