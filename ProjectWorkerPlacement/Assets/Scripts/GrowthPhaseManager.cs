using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthPhaseManager : MonoBehaviour
{
    [SerializeField]
    private Area homeArea;

    private void Start()
    {
        PhaseController.Instance
            .RegisterOnStartGrowthPhase(OnStartGrowthPhase);
    }

    private void OnStartGrowthPhase()
    {
        // Perform the growth phase
        Debug.Log("Perform Growth Phase");

        ReturnMeeplesHome();

        PhaseController.Instance.NextPhase();
    }

    private void ReturnMeeplesHome()
    {
        // For now just find them
        // TODO: optimize this/ cache values

        Meeple[] meeples = FindObjectsOfType<Meeple>();
        foreach (Meeple meeple in meeples)
        {
            homeArea.TryAddMeeple(meeple);
        }
    }

}
