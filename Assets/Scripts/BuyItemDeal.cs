using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuyItemDeal", menuName = "ScriptableObjects/Deals/BuyItemDeal")]
public class BuyItemDeal : Deal
{
    [SerializeField] private ItemType item;
    public ItemType Item => item;

    public override string DealName() =>
        item.ToString();

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
