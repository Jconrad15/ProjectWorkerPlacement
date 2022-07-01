using System;
using System.Collections.Generic;
using UnityEngine;

public class MeepleCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject meeplePrefab;

    private Action<Meeple> cbOnMeepleCreated;
    private Action cbOnMeepleDestroyed;

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
        cbOnMeepleCreated?.Invoke(meeple);
    }

    public void CreateNewMeeple()
    {
        GenerateHomeMeeple();
    }

    public void DestroyMeeple()
    {
        // TODO: destroy meeple


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
