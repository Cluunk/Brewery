using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour, IInteractable
{
    [SerializeField] private MarketOverlay overlay;
    
    [SerializeField] private Deal[] buyDeals = new Deal[5];
    public Deal[] BuyDeals => buyDeals;
    
    [SerializeField] private Deal[] sellDeals = new Deal[5];
    public Deal[] SellDeals => sellDeals;

    private void Start()
    {
        DisplayBuyDeals();
    }

    public void Interact(PlayerMovement player)
    {
        if (PlayerMovement.Interacting)
            return;
        
    }

    public void QuitInteraction()
    {
        
    }

    public void DisplayBuyDeals()
    {
        overlay.OpenDealOverlay(buyDeals, true);
    }

    public void DisplaySellDeals()
    {
        overlay.OpenDealOverlay(sellDeals, false);
    }
}
