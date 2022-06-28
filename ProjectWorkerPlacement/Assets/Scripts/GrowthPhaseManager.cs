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
        StartCoroutine(GrowthPhase());
    }

    private IEnumerator GrowthPhase()
    {
        // Perform the growth phase
        Debug.Log("Perform Growth Phase");

        // Apply the outcomes of the turn here.







        ReturnMeeplesHome();

        yield return null;
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
