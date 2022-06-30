using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    void OnEnable()
    {
        menu.SetActive(true);
    }

}
