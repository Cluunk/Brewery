using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static event Notify Loss;
    public static event Notify Win;

    public static void CheckLoss(Deal[] deals)
    {
        var brewPossible = false;
        var dealPossible = false;
        
        foreach (var recipe in PlayerMovement.Inventory.UnlockedRecipes)
        {
            if (recipe.RecipePossible())
                brewPossible = true;
        }

        
        foreach (var deal in deals)
        {
            if (deal.DealPossible(PlayerMovement.Inventory))
                dealPossible = true;
        }

        if (!brewPossible && !dealPossible)
            Loss?.Invoke();
    }

    public static void CheckWin()
    {
        if (PlayerMovement.Inventory.Balance >= Inventory.BalanceGoal)
            Win?.Invoke();
    }
}
