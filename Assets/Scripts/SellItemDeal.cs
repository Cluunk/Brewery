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
    }

    public override bool DealPossible(Inventory player)
    {
        if (!player.Items.ContainsKey(item))
            return false;
        return player.Items[Item] >= amount;
    }
}
