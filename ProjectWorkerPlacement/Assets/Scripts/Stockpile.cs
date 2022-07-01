using System;
using System.Collections.Generic;
using UnityEngine;

public class Stockpile : MonoBehaviour
{
    [SerializeField]
    private MeepleCreator meepleCreator;

    private Action<int> cbOnFoodCountChanged;
    private Action<int> cbOnMeepleCountChanged;

    private int meepleCount;
    public int MeepleCount 
    { 
        get => meepleCount;
        protected set
        {
            meepleCount = value;
            cbOnMeepleCountChanged?.Invoke(meepleCount);
        }
    }

    private int foodCount;
    public int FoodCount 
    {
        get => foodCount;
        protected set
        {
            foodCount = value;
            cbOnFoodCountChanged?.Invoke(foodCount);
        }
    }

    private void Start()
    {
        // Starting stockpile values
        MeepleCount = 0;
        FoodCount = 2;

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

    public void AddMeeple(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            meepleCreator.CreateNewMeeple();
        }
    }

    public void RemoveMeeple()
    {
        MeepleCount -= 1;
        meepleCreator.DestroyMeeple();
    }

    public void RegisterOnFoodCountChanged(Action<int> callbackfunc)
    {
        cbOnFoodCountChanged += callbackfunc;
    }

    public void UnregisterOnFoodCountChanged(Action<int> callbackfunc)
    {
        cbOnFoodCountChanged -= callbackfunc;
    }

    public void RegisterOnMeepleCountChanged(Action<int> callbackfunc)
    {
        cbOnMeepleCountChanged += callbackfunc;
    }

    public void UnregisterOnMeepleCountChanged(Action<int> callbackfunc)
    {
        cbOnMeepleCountChanged -= callbackfunc;
    }
}
