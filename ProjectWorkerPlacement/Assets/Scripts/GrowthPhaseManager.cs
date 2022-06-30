using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthPhaseManager : MonoBehaviour
{
    [SerializeField]
    private Area homeArea;
    [SerializeField]
    private WorkAreaManager workAreaManager;
    [SerializeField]
    private Stockpile stockpile;

    private CurrentTurnModifiers modifiers;

    private void Start()
    {
        PhaseController.Instance
            .RegisterOnStartGrowthPhase(OnStartGrowthPhase);

        modifiers = CurrentTurnModifiers.Instance;
    }

    private void OnStartGrowthPhase()
    {
        StartCoroutine(GrowthPhase());
    }

    private IEnumerator GrowthPhase()
    {
        // Perform the growth phase
        Debug.Log("Perform Growth Phase");

        // Evaluate placement slots
        EvaluateFoodSlots();
        EvaluateDefenseSlots();
        EvaluatePopulationSlots();

        ReturnMeeplesHome();

        yield return null;
        PhaseController.Instance.NextPhase();
    }

    private void EvaluateFoodSlots()
    {
        Area[] foodAreas = workAreaManager.FoodAreas;
        int meepleCount = DetermineMeepleCount(foodAreas);

        // Base food is factorial but with addtion
        int baseFoodCount =
            ((meepleCount * meepleCount) + meepleCount) / 2;

        // TODO: modifiers from cards here
        int foodCount =
            baseFoodCount +
            (modifiers.AdditionalFoodPerPopulation * meepleCount);

        stockpile.AddFood(foodCount);
    }

    private void EvaluateDefenseSlots()
    {

    }

    private void EvaluatePopulationSlots()
    {
        Area[] populationAreas = workAreaManager.PopulationAreas;
        int meepleCount = DetermineMeepleCount(populationAreas);

        // Add modifiers from cards
        int additionalPopulation = modifiers.AdditionalPopulation;
        if (additionalPopulation > 0)
        {
            stockpile.AddMeeple(additionalPopulation);
        }

        // Base slot growth
        if (meepleCount == 2)
        {
            int childCount = 1;
            stockpile.AddMeeple(childCount);
        }

    }

    private int DetermineMeepleCount(Area[] areas)
    {
        int meepleCount = 0;
        for (int i = 0; i < areas.Length; i++)
        {
            meepleCount += areas[i].GetMeepleCount();
        }

        return meepleCount;
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
