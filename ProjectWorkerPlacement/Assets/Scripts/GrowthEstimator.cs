using System;
using UnityEngine;

public class GrowthEstimator : MonoBehaviour
{
    [SerializeField]
    private WorkAreaManager workAreaManager;

    private Action<int> cbOnFoodEstimationChanged;
    private Action<int> cbOnWoodEstimationChanged;
    private Action<int> cbOnStoneEstimationChanged;
    private Action<int> cbOnDefenseEstimationChanged;
    private Action<int> cbOnPopulationEstimationChanged;
    private Action<int> cbOnWonderEstimationChanged;

    private void Start()
    {
        Area[] foodAreas = workAreaManager.FoodAreas;
        for (int i = 0; i < foodAreas.Length; i++)
        {
            foodAreas[i].RegisterOnMeepleAdded(OnMeepleAdded);
            foodAreas[i].RegisterOnMeepleRemoved(OnMeepleRemoved);
        }

        Area[] woodAreas = workAreaManager.WoodAreas;
        for (int i = 0; i < woodAreas.Length; i++)
        {
            woodAreas[i].RegisterOnMeepleAdded(OnMeepleAdded);
            woodAreas[i].RegisterOnMeepleRemoved(OnMeepleRemoved);
        }

        Area[] stoneAreas = workAreaManager.StoneAreas;
        for (int i = 0; i < stoneAreas.Length; i++)
        {
            stoneAreas[i].RegisterOnMeepleAdded(OnMeepleAdded);
            stoneAreas[i].RegisterOnMeepleRemoved(OnMeepleRemoved);
        }

        Area[] defenseAreas = workAreaManager.DefenseAreas;
        for (int i = 0; i < defenseAreas.Length; i++)
        {
            defenseAreas[i].RegisterOnMeepleAdded(OnMeepleAdded);
            defenseAreas[i].RegisterOnMeepleRemoved(OnMeepleRemoved);
        }

        Area[] populationAreas = workAreaManager.PopulationAreas;
        for (int i = 0; i < populationAreas.Length; i++)
        {
            populationAreas[i].RegisterOnMeepleAdded(OnMeepleAdded);
            populationAreas[i].RegisterOnMeepleRemoved(OnMeepleRemoved);
        }

        Area[] wonderAreas = workAreaManager.WonderAreas;
        for (int i = 0; i < wonderAreas.Length; i++)
        {
            wonderAreas[i].RegisterOnMeepleAdded(OnMeepleAdded);
            wonderAreas[i].RegisterOnMeepleRemoved(OnMeepleRemoved);
        }
    }

    private void OnMeepleAdded(Area area)
    {
        ChangeAmount(area);
    }

    private void OnMeepleRemoved(Area area)
    {
        ChangeAmount(area);
    }

    private void ChangeAmount(Area area)
    {
        int amount;
        switch (area.GetAreaType())
        {
            case AreaType.Home:
                // Do nothing here
                return;

            case AreaType.Food:
                amount = BaseAreaYields.GetBaseFoodYield(
                    workAreaManager.DetermineMeepleCount(
                        workAreaManager.FoodAreas));

                cbOnFoodEstimationChanged?.Invoke(amount);
                break;

            case AreaType.Defense:
                amount = BaseAreaYields.GetBaseDefenseYield(
                    workAreaManager.DetermineMeepleCount(
                        workAreaManager.DefenseAreas));

                cbOnDefenseEstimationChanged?.Invoke(amount);
                break;

            case AreaType.Population:
                amount = BaseAreaYields.GetBasePopulationYield(
                    workAreaManager.DetermineMeepleCount(
                        workAreaManager.PopulationAreas));

                cbOnPopulationEstimationChanged?.Invoke(amount);
                break;

            case AreaType.Wood:
                amount = BaseAreaYields.GetBaseWoodYield(
                    workAreaManager.DetermineMeepleCount(
                        workAreaManager.WoodAreas));

                cbOnWoodEstimationChanged?.Invoke(amount);
                break;

            case AreaType.Stone:
                amount = BaseAreaYields.GetBaseStoneYield(
                    workAreaManager.DetermineMeepleCount(
                        workAreaManager.StoneAreas));

                cbOnStoneEstimationChanged?.Invoke(amount);
                break;

            case AreaType.Wonder:
                amount = BaseAreaYields.GetBaseWonderYield(
                    workAreaManager.DetermineMeepleCount(
                        workAreaManager.WonderAreas));

                cbOnWonderEstimationChanged?.Invoke(amount);
                break;

            default:
                break;
        }
    }

    public void RegisterOnFoodEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnFoodEstimationChanged += callbackfunc;
    }

    public void UnregisterOnFoodEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnFoodEstimationChanged -= callbackfunc;
    }

    public void RegisterOnWoodEstimationChanged(
    Action<int> callbackfunc)
    {
        cbOnWoodEstimationChanged += callbackfunc;
    }

    public void UnregisterOnWoodEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnWoodEstimationChanged -= callbackfunc;
    }

    public void RegisterOnStoneEstimationChanged(
    Action<int> callbackfunc)
    {
        cbOnStoneEstimationChanged += callbackfunc;
    }

    public void UnregisterOnStoneEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnStoneEstimationChanged -= callbackfunc;
    }

    public void RegisterOnDefenseEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnDefenseEstimationChanged += callbackfunc;
    }

    public void UnregisterOnDefenseEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnDefenseEstimationChanged -= callbackfunc;
    }

    public void RegisterOnPopulationEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnPopulationEstimationChanged += callbackfunc;
    }

    public void UnregisterOnPopulationEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnPopulationEstimationChanged -= callbackfunc;
    }

    public void RegisterOnWonderEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnWonderEstimationChanged += callbackfunc;
    }

    public void UnregisterOnWonderEstimationChanged(
        Action<int> callbackfunc)
    {
        cbOnWonderEstimationChanged -= callbackfunc;
    }
}
