using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDeal : Deal
{
    private IngredientType type;
    private int amountToBuy;

    [SerializeField] private int cost;
    public int Cost => cost;
    
    
    public override void AcceptDeal(Inventory player)
    {
        if (!DealPossible(player))
            return;
        player.Buy(cost);
        
    }

    public override bool DealPossible(Inventory player)
    {
        return player.Balance >= Cost;
    }
}
