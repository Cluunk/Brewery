using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private InventorySlot[] slots;

    [SerializeField] private Button next;
    [SerializeField] private Button previous;
    
    private int currentPage;
    private List<InventoryItem> items;

    public void DisplayInventory()
    {
        items = InventoryItemsToList();
        DisplayPage(0);
    }
    
    public void GoToNextPage()
    {
        DisplayPage(currentPage + 1);
    }
    
    public void GoToPreviousPage()
    {
        DisplayPage(currentPage - 1);
    }

    private void DisplayPage(int page)
    {
        foreach (var slot in slots)
            ClearSlot(slot);
        
        if (items.Count <= 0)
            return;

        if (page <= 0)
            page = 0;
        if (page >= (float)items.Count / slots.Length)
            page = items.Count / slots.Length;
        
        for (int i = 0, startIndex = page * slots.Length; i < slots.Length; i++)
        {
            if (startIndex + i >= items.Count){
                ClearSlot(slots[i]);
                continue;
            }

            slots[i].NameDisplay.text = items[startIndex + i].Item.ToString();
            slots[i].AmountDisplay.text = $"{items[startIndex + i].Amount}/{Inventory.maxPerItem}";
        }

        currentPage = page;
        
        SetNavigationButtons();
    }
    
    private List<InventoryItem> InventoryItemsToList()
    {
        var t = new List<InventoryItem>();
        foreach (var item in inventory.Items)
            t.Add(new InventoryItem(item.Key, item.Value));

        return t;
    }

    private void ClearSlot(InventorySlot slot)
    {
        slot.NameDisplay.text = "Empty";
        slot.AmountDisplay.text = "";
    }

    private void SetNavigationButtons()
    {
        next.gameObject.SetActive(items.Count % slots.Length == 0 ? 
            currentPage < items.Count / slots.Length - 1 : 
            currentPage < items.Count / slots.Length);
        previous.gameObject.SetActive(currentPage > 0);
    }
}

[Serializable]
internal class InventorySlot
{
    [SerializeField] private TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI NameDisplay => nameDisplay;

    [SerializeField] private TextMeshProUGUI amountDisplay;
    public TextMeshProUGUI AmountDisplay => amountDisplay;
}

internal class InventoryItem
{
    public ItemType Item { get; }
    public int Amount { get; }

    public InventoryItem(ItemType item, int amount = 0)
    {
        Item = item;
        Amount = amount;
    }
}
