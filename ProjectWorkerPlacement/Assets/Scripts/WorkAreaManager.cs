using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkAreaManager : MonoBehaviour
{
    [SerializeField]
    private Area foodArea0;
    [SerializeField]
    private Area foodArea1;
    [SerializeField]
    private Area foodArea2;
    [SerializeField]
    private Area foodArea3;

    [SerializeField]
    private Area defenseArea0;
    [SerializeField]
    private Area defenseArea1;

    [SerializeField]
    private Area populationArea0;
    [SerializeField]
    private Area populationArea1;

    [SerializeField]
    private Area woodArea0;
    [SerializeField]
    private Area woodArea1;

    [SerializeField]
    private Area stoneArea0;
    [SerializeField]
    private Area stoneArea1;

    [SerializeField]
    private Area wonderArea0;

    public Area[] FoodAreas { get; private set; }
    public Area[] DefenseAreas { get; private set; }
    public Area[] PopulationAreas { get; private set; }
    public Area[] WoodAreas { get; private set; }
    public Area[] StoneAreas { get; private set; }
    public Area[] WonderAreas { get; private set; }

    private void OnEnable()
    {
        FoodAreas = new Area[4]
        {
            foodArea0,
            foodArea1,
            foodArea2,
            foodArea3
        };

        DefenseAreas = new Area[2]
        {
            defenseArea0,
            defenseArea1
        };

        PopulationAreas = new Area[2]
        {
            populationArea0,
            populationArea1
        };

        WoodAreas = new Area[2]
        {
            woodArea0,
            woodArea1
        };

        StoneAreas = new Area[2]
        {
            stoneArea0,
            stoneArea1
        };

        WonderAreas = new Area[1]
        {
            wonderArea0
        };
    }

    public int DetermineMeepleCount(Area[] areas)
    {
        int meepleCount = 0;
        for (int i = 0; i < areas.Length; i++)
        {
            meepleCount += areas[i].GetMeepleCount();
        }

        return meepleCount;
    }

}
