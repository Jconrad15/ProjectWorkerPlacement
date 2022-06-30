using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AreaType { Home, Food, Defense, Population };
public class Area : MonoBehaviour
{
    [SerializeField]
    private int meepleLimit;
    [SerializeField]
    private AreaType areaType;

    private List<Meeple> meeples = new List<Meeple>();

    public bool TryAddMeeple(Meeple meeple)
    {
        if (meeple == null) { return false; }

        if (meeples.Count >= meepleLimit) { return false; }

        GameObject meepleGO = meeple.gameObject;
        meepleGO.transform.SetParent(transform);
        meepleGO.transform.position = transform.position;

        meeples.Add(meeple);

        meeple.SetCurrentArea(this);

        return true;
    }

    public void RemoveMeeple(Meeple meeple)
    {
        if (meeples.Contains(meeple))
        {
            meeples.Remove(meeple);
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

}
