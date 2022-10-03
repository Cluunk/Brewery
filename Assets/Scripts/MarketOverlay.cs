using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketOverlay : MonoBehaviour
{
    [SerializeField] private DealDisplay[] buyDealDisplays;
    [SerializeField] private DealDisplay[] sellDealDisplays;
    
    public void OpenDealOverlay(Deal[] deals, bool buy)
    {
        if (buy)
        {
            foreach (var buyDeal in buyDealDisplays)
                buyDeal.gameObject.SetActive(true);
            foreach (var sellDeal in sellDealDisplays)
                sellDeal.gameObject.SetActive(false);
            for (int i = 0, availableDeals = deals.Length; i < buyDealDisplays.Length; i++)
            {
                if (i >= availableDeals)
                    buyDealDisplays[i].Clear();
                else
                    buyDealDisplays[i].GenerateDisplay(deals[i]);
            }
        }
        else
        {
            foreach (var buyDeal in buyDealDisplays)
                buyDeal.gameObject.SetActive(false);
            foreach (var sellDeal in sellDealDisplays)
                sellDeal.gameObject.SetActive(true);
            
            for (int i = 0, availableDeals = deals.Length; i < sellDealDisplays.Length; i++)
            {
                if (i >= availableDeals)
                    sellDealDisplays[i].Clear();
                else
                    sellDealDisplays[i].GenerateDisplay(deals[i]);
            }
        }
    }
}
