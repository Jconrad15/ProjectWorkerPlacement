using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    private Area homeArea;

    private void OnEnable()
    {
        homeArea = GetComponent<Area>();

        FindObjectOfType<MeepleCreator>()
            .RegisterOnMeepleCreated(OnMeepleCreated);
    }

    private void OnMeepleCreated(Meeple meeple)
    {
        AddNewMeeple(meeple);
    }

    private void AddNewMeeple(Meeple meeple)
    {
        homeArea.TryAddMeeple(meeple);
    }

    private void OnDestroy()
    {
        MeepleCreator mc = FindObjectOfType<MeepleCreator>();
        if (mc != null)
        {
            mc.UnregisterOnMeepleCreated(OnMeepleCreated);
        }
    }

}
