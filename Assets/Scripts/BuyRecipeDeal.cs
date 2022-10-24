using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuyRecipeDeal", menuName = "ScriptableObjects/Deals/BuyRecipeDeal")]
public class BuyRecipeDeal : Deal
{
    [SerializeField] private Recipe recipe;

    public override DealType Type() =>
        DealType.BuyRecipe;

    public override string DealName() =>
        recipe.RecipeName;

    public override void AcceptDeal(Market market, Inventory player)
    {
        if (!DealPossible(player))
            return;
        player.Buy(Price);
        player.UnlockedRecipes.Add(recipe);
        market.RecipeDeals.Remove(this);
        market.Overlay.DisplayRecipeDeals();
        market.Overlay.UpdateBalance();
    }

    protected override bool DealPossible(Inventory player)
    {
        return player.Balance >= Price;
    }
}
