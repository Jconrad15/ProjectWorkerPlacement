using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stockpile : MonoBehaviour
{
    [SerializeField]
    private MeepleCreator meepleCreator;

    public int MeepleCount { get; protected set; } = 0;
    public int FoodCount { get; protected set; } = 2;

    private void Start()
    {
        meepleCreator.RegisterOnMeepleCreated(OnMeepleCreated);
    }

    private void OnMeepleCreated(Meeple m)
    {
        MeepleCount += 1;
    }

    public void AddFood(int amount)
    {
        FoodCount += amount;
    }

    public void RemoveFood(int amount)
    {
        FoodCount -= amount;
    }


}
