using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kettle : MonoBehaviour, IInteractable
{
    [SerializeField] private BrewOverview overlay;
    
    public void Interact(PlayerMovement player)
    {
        if (PlayerMovement.Interacting)
            return;
        overlay.OpenBrewOverlay();
    }

    public void QuitInteraction()
    {
        overlay.CloseBrewOverlay();
    }
}
