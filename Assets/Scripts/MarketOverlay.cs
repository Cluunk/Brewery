using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MarketOverlay : MonoBehaviour
{
    [SerializeField] private Market market;

    [SerializeField] private GameObject buyDealDisplay;
    [SerializeField] private GameObject sellDealDisplay;

    [SerializeField] private TextMeshProUGUI balanceDisplay;
    
    [SerializeField] private GameObject DealScrollView;

    private List<DealDisplay> activeDeals = new List<DealDisplay>();

    [SerializeField] private AudioClip openDisplaySound;

    public void UpdateBalance()
    {
        balanceDisplay.text = $"{PlayerMovement.Inventory.Balance}$ / {Inventory.BalanceGoal}$";
    }
    
    public void OpenOverlay()
    {
        gameObject.SetActive(true);
        DisplayBuyDeals();
        UpdateBalance();
    }
    
    public void CloseOverlay()
    {
        gameObject.SetActive(false);
    }

    public void DisplayBuyDeals()
    {
        OpenDealOverlay(market.BuyDeals, DealType.BuyItem);
        SoundManager.Instance.PlayAudio(openDisplaySound);
    }

    public void DisplaySellDeals()
    {
        OpenDealOverlay(market.SellDeals, DealType.SellItem);
        SoundManager.Instance.PlayAudio(openDisplaySound);
    }

    public void DisplayRecipeDeals() {
        OpenDealOverlay(market.RecipeDeals, DealType.BuyRecipe);
        SoundManager.Instance.PlayAudio(openDisplaySound);
    }
    
    private void OpenDealOverlay(List<Deal> deals, DealType dealType)
    {
        foreach (var dealDisplay in activeDeals)
        {
            if(dealDisplay) 
                Destroy(dealDisplay.gameObject);
        }
        activeDeals.Clear();

        var display = dealType == DealType.BuyItem || dealType == DealType.BuyRecipe ? buyDealDisplay : sellDealDisplay;

        var scrollViewRect = DealScrollView.GetComponent<RectTransform>();
        scrollViewRect.sizeDelta = new Vector2(scrollViewRect.sizeDelta.x, display.GetComponent<RectTransform>().rect.height * deals.Count);

        foreach (var deal in deals)
        {
            activeDeals.Add(Instantiate(display, DealScrollView.transform).GetComponent<DealDisplay>());
            activeDeals[^1].GenerateDisplay(market, deal);
        }
    }
}