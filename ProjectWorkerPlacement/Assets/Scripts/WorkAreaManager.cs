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

    public Area[] FoodAreas { get; private set; }
    public Area[] DefenseAreas { get; private set; }
    public Area[] PopulationAreas { get; private set; }

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
    }

}
