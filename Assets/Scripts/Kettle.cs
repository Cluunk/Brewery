using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kettle : MonoBehaviour, IInteractable
{
    [SerializeField] private KettleOverlay overlay;
    
    public void Interact(PlayerMovement player)
    {
        if (PlayerMovement.Interacting)
            return;
        overlay.OpenBrewOverlay();
        Debug.Log("interacting");
    }

    public void QuitInteraction()
    {
        overlay.CloseBrewOverlay();
        Debug.Log("stop interacting");
    }
}
