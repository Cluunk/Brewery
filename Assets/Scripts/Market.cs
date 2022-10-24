using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour, IInteractable
{
    [SerializeField] private MarketOverlay overlay;
    public MarketOverlay Overlay => overlay;
    
    [SerializeField] private List<Deal> buyDeals = new List<Deal>();
    public List<Deal> BuyDeals => buyDeals;
    
    [SerializeField] private List<Deal> sellDeals = new List<Deal>();
    public List<Deal> SellDeals => sellDeals;
    
    [SerializeField] private List<Deal> recipeDeals = new List<Deal>();
    public List<Deal> RecipeDeals => recipeDeals;


    public void Interact(PlayerMovement player)
    {
        if (PlayerMovement.Interacting)
            return;
        overlay.OpenOverlay();
    }

    public void QuitInteraction()
    {
        overlay.CloseOverlay();
    }
}
