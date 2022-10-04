using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketOverlay : MonoBehaviour
{
    [SerializeField] private DealDisplay[] buyDealDisplays;
    [SerializeField] private DealDisplay[] sellDealDisplays;

    public void OpenOverlay()
    {
        
    }

    public void OpenDealOverlay(Deal[] deals, bool buy)
    {
        if (buy)
        {
            foreach (var buyDeal in buyDealDisplays)
                buyDeal.gameObject.SetActive(true);
            foreach (var sellDeal in sellDealDisplays)
                sellDeal.gameObject.SetActive(false);
            for (var i = 0; i < buyDealDisplays.Length; i++)
            {
                buyDealDisplays[i].Clear();
                buyDealDisplays[i].GenerateDisplay(deals[i]);
            }
        }
        else
        {
            foreach (var buyDeal in buyDealDisplays)
                buyDeal.gameObject.SetActive(false);
            foreach (var sellDeal in sellDealDisplays)
                sellDeal.gameObject.SetActive(true);
            
            for (var i = 0; i < sellDealDisplays.Length; i++)
            {
                sellDealDisplays[i].Clear();
                sellDealDisplays[i].GenerateDisplay(deals[i]);
            }
        }
    }
}
