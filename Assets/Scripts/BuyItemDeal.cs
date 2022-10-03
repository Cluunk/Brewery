using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuyItemDeal", menuName = "ScriptableObjects/Deals/BuyItemDeal")]
public class BuyItemDeal : Deal
{
    public override void AcceptDeal(Inventory player)
    {
        if (!DealPossible(player))
            return;
        player.Buy(Price);
        
    }

    public override bool DealPossible(Inventory player)
    {
        return player.Balance >= Price;
    }
}
