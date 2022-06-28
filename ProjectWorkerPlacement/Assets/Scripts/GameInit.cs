using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    [SerializeField]
    private int startingMeepleCount = 3;

    [SerializeField]
    private MeepleCreator meepleCreator;

    public void StartButton()
    {
        meepleCreator.NewHomeMeeple(startingMeepleCount);

        PhaseController.Instance.StartPhaseSystem();
    }

}
