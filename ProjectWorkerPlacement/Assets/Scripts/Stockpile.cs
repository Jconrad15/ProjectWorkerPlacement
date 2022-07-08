using System;
using System.Collections.Generic;
using UnityEngine;

public class Stockpile : MonoBehaviour
{
    [SerializeField]
    private MeepleCreator meepleCreator;

    private Action<int> cbOnFoodCountChanged;
    private Action<int> cbOnMeepleCountChanged;
    private Action<int> cbOnWoodCountChanged;
    private Action<int> cbOnStoneCountChanged;

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

    private int woodCount;
    public int WoodCount
    {
        get => woodCount;
        protected set
        {
            woodCount = value;
            cbOnWoodCountChanged?.Invoke(woodCount);
        }
    }

    private int stoneCount;
    public int StoneCount
    {
        get => stoneCount;
        protected set
        {
            stoneCount = value;
            cbOnStoneCountChanged?.Invoke(stoneCount);
        }
    }

    private void Start()
    {
        // Starting stockpile values
        MeepleCount = 0;
        FoodCount = 2;
        WoodCount = 0;
        StoneCount = 0;

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

    public void AddWood(int amount)
    {
        WoodCount += amount;
    }

    public void RemoveWood(int amount)
    {
        WoodCount -= amount;
    }

    public void AddStone(int amount)
    {
        StoneCount += amount;
    }

    public void RemoveStone(int amount)
    {
        StoneCount -= amount;
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

    public void RegisterOnFoodCountChanged(
        Action<int> callbackfunc)
    {
        cbOnFoodCountChanged += callbackfunc;
    }

    public void UnregisterOnFoodCountChanged(
        Action<int> callbackfunc)
    {
        cbOnFoodCountChanged -= callbackfunc;
    }

    public void RegisterOnMeepleCountChanged(
        Action<int> callbackfunc)
    {
        cbOnMeepleCountChanged += callbackfunc;
    }

    public void UnregisterOnMeepleCountChanged(
        Action<int> callbackfunc)
    {
        cbOnMeepleCountChanged -= callbackfunc;
    }

    public void RegisterOnWoodCountChanged(
        Action<int> callbackfunc)
    {
        cbOnWoodCountChanged += callbackfunc;
    }

    public void UnregisterOnWoodCountChanged(
        Action<int> callbackfunc)
    {
        cbOnWoodCountChanged -= callbackfunc;
    }

    public void RegisterOnStoneCountChanged(
        Action<int> callbackfunc)
    {
        cbOnStoneCountChanged += callbackfunc;
    }

    public void UnregisterOnStoneCountChanged(
        Action<int> callbackfunc)
    {
        cbOnStoneCountChanged -= callbackfunc;
    }
}
