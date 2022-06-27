using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPhaseManager : MonoBehaviour
{
    [SerializeField]
    private CardDeck cardDeck;

    private void Start()
    {
        PhaseController.Instance
            .RegisterOnStartCardPhase(OnStartCardPhase);
    }

    private void OnStartCardPhase()
    {
        // Perform the card phase
        Debug.Log("Perform Card Phase");

        PhaseController.Instance.NextPhase();
    }


}
