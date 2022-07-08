using System;
using System.Collections.Generic;
using UnityEngine;

public class MeepleCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject meeplePrefab;

    private Action<Meeple> cbOnMeepleCreated;
    private Action cbOnMeepleDestroyed;

    private List<GameObject> meepleGOs = new List<GameObject>();

    public void NewHomeMeeple(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            GenerateHomeMeeple();
        }
    }

    private void GenerateHomeMeeple()
    {
        GameObject meepleGO = Instantiate(meeplePrefab);
        Meeple meeple = meepleGO.GetComponent<Meeple>();

        meepleGOs.Add(meepleGO);

        cbOnMeepleCreated?.Invoke(meeple);
    }

    public void CreateNewMeeple()
    {
        GenerateHomeMeeple();
    }

    public void DestroyMeeple()
    {
        int lastIndex = meepleGOs.Count - 1;

        if (lastIndex < 0)
        {
            Debug.LogWarning("No meeple to destroy");
            return;
        }

        GameObject meepleGO = meepleGOs[lastIndex];
        Destroy(meepleGO);
        meepleGOs.RemoveAt(lastIndex);

        cbOnMeepleDestroyed?.Invoke();
    }

    public void RegisterOnMeepleCreated(Action<Meeple> callbackfunc)
    {
        cbOnMeepleCreated += callbackfunc;
    }

    public void UnregisterOnMeepleCreated(Action<Meeple> callbackfunc)
    {
        cbOnMeepleCreated -= callbackfunc;
    }

    public void RegisterOnMeepleDestroyed(Action callbackfunc)
    {
        cbOnMeepleDestroyed += callbackfunc;
    }

    public void UnregisterOnMeepleDestroyed(Action callbackfunc)
    {
        cbOnMeepleDestroyed -= callbackfunc;
    }

}
