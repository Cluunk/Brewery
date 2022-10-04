using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuyItemDeal", menuName = "ScriptableObjects/Deals/BuyItemDeal")]
public class BuyItemDeal : Deal
{
    public override void AcceptDeal(Inventory inventory)
    {
        if (!DealPossible(inventory))
            return;
        inventory.Buy(Price);
        inventory.AddItem(Item, Amount);
    }

    public override bool DealPossible(Inventory player)
    {
        return player.Balance >= Price;
    }
}
