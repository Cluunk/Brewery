using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuyItemDeal", menuName = "ScriptableObjects/Deals/BuyItemDeal")]
public class BuyRecipeDeal : Deal
{
    
    
    public override void AcceptDeal(Inventory player)
    {
        throw new System.NotImplementedException();
    }

    public override bool DealPossible(Inventory player)
    {
        throw new System.NotImplementedException();
    }
}
