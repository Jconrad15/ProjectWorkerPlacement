using System;
using System.Collections.Generic;
using UnityEngine;

public enum AreaType 
{
    Home, Food, Defense, Population, Wood, Stone, Wonder
};

public class Area : MonoBehaviour
{
    [SerializeField]
    private int meepleLimit;
    [SerializeField]
    private AreaType areaType;

    private List<Meeple> meeples = new List<Meeple>();
    private Action<Area> cbOnMeepleAdded;
    private Action<Area> cbOnMeepleRemoved;

    public AreaType GetAreaType()
    {
        return areaType;
    }

    public bool TryAddMeeple(Meeple meeple)
    {
        if (meeple == null) { return false; }

        if (meeples.Count >= meepleLimit) { return false; }

        GameObject meepleGO = meeple.gameObject;
        meepleGO.transform.SetParent(transform);
        meepleGO.transform.position = transform.position;

        meeples.Add(meeple);
        meeple.SetCurrentArea(this);
        cbOnMeepleAdded?.Invoke(this);
        return true;
    }

    public void RemoveMeeple(Meeple meeple)
    {
        if (meeples.Contains(meeple))
        {
            meeples.Remove(meeple);
            cbOnMeepleRemoved?.Invoke(this);
        }
        else
        {
            Debug.LogError("Trying to remove meeple that is " +
                "not in the list of meeples");
        }
    }

    public int GetMeepleCount()
    {
        return meeples.Count;
    }

    public void RegisterOnMeepleAdded(
        Action<Area> callbackfunc)
    {
        cbOnMeepleAdded += callbackfunc;
    }

    public void UnregisterOnMeepleAdded(
        Action<Area> callbackfunc)
    {
        cbOnMeepleAdded -= callbackfunc;
    }

    public void RegisterOnMeepleRemoved(
        Action<Area> callbackfunc)
    {
        cbOnMeepleRemoved += callbackfunc;
    }

    public void UnregisterOnMeepleRemoved(
        Action<Area> callbackfunc)
    {
        cbOnMeepleRemoved -= callbackfunc;
    }
}
