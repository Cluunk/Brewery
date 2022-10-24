using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SellItemDeal", menuName = "ScriptableObjects/Deals/SellItemDeal")]
public class SellItemDeal : Deal
{
    [SerializeField] private ItemType item;
    public ItemType Item => item;

    [SerializeField] private int amount;
    public int Amount => amount;
    
    public override DealType Type() =>
        DealType.SellItem;

    public override string DealName() =>
        item.ToString();

    public override void AcceptDeal(Market market, Inventory player)
    {
        if (!DealPossible(player))
            return;
        player.Sell(Price);
        player.Items[Item] -= amount;
        market.Overlay.UpdateBalance();
    }

    protected override bool DealPossible(Inventory player)
    {
        return player.Items[Item] >= amount;
    }
}
