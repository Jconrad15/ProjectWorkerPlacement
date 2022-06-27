using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPlacementButton : MonoBehaviour
{

    private void Start()
    {
        PhaseController.Instance
            .RegisterOnStartWorkerPlacementPhase(
            OnStartWorkerPlacementPhase);

        Hide();
    }

    private void OnStartWorkerPlacementPhase()
    {
        Show();
    }

    public void ButtonPress()
    {
        Hide();
        PhaseController.Instance.NextPhase();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
