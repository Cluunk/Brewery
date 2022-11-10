using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuyItemDeal", menuName = "ScriptableObjects/Deals/BuyItemDeal")]
public class BuyItemDeal : Deal
{
    [SerializeField] private ItemType item;
    public ItemType Item => item;

    [SerializeField] private int amount;
    public int Amount => amount;

    public override DealType Type() => 
        DealType.BuyItem;

    public override string DealName() =>
        item.ToString();

    public override void AcceptDeal(Market market, Inventory player)
    {
        if (!DealPossible(player))
            return;
        player.Buy(Price);
        player.AddItem(Item, Amount);
    }

    public override bool DealPossible(Inventory player)
    {
        return player.Balance >= Price;
    }
}
