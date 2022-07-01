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

    private readonly int basePopulationFoodConsumption = 1;
    private readonly int baseDefensePerDefender = 1;

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

        // Charge pop upkeep, then grow pop
        PopulationUpkeep();
        EvaluatePopulationSlots();

        ReturnMeeplesHome();

        yield return null;
        PhaseController.Instance.NextPhase();
    }

    private void PopulationUpkeep()
    {
        int upkeepPerPop =
            basePopulationFoodConsumption +
            modifiers.FoodUpkeepPerPopulation;

        int upkeep = stockpile.MeepleCount * upkeepPerPop;

        // Apply food upkeep to food stockpile
        // If not enough food, remove population
        bool isDone = false;
        while (isDone == false)
        {
            if (stockpile.FoodCount > 0)
            {
                stockpile.RemoveFood(1);
                upkeep -= 1;
            }
            else
            {
                stockpile.RemoveMeeple();
                upkeep -= 1;
            }

            if (upkeep <= 0) { isDone = true; }
        }
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
        // Return if there are no attackers
        if (modifiers.Attackers <= 0) { return; }

        Area[] defenseAreas = workAreaManager.DefenseAreas;
        int meepleCount = DetermineMeepleCount(defenseAreas);

        int defenders = meepleCount *
            (baseDefensePerDefender + modifiers.DefensePerDefender);

        int damage = modifiers.Attackers - defenders;

        if (damage <= 0) { return; }

        // Effects of not stopping attackers
        // Remove food or meeples
        bool isDone = false;
        while (isDone == false)
        {
            if (stockpile.FoodCount > 0)
            {
                stockpile.RemoveFood(1);
                damage -= 1;
            }
            else
            {
                // not enough food
                stockpile.RemoveMeeple();
                damage -= 1;
            }

            if (damage <= 0) { isDone = true; }
        }

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
            int childCount = 1 + modifiers.AdditionalChildren;
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
