using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private GameObject inventoryItem;
    [SerializeField] private ItemType[] ingredients;
    [SerializeField] private ItemType[] booze;
    [SerializeField] private GameObject itemScrollView;

    [SerializeField] private List<GameObject> activeItems;
    [SerializeField] private AudioClip openDisplaySound;

    
    public void DisplayInventory()
    {
        DisplayIngredients();
    }

    public void DisplayIngredients()
    {
        var ingredientsInInventory = new List<InventoryItem>();

        foreach (var (key, value) in PlayerMovement.Inventory.Items)
        {
            if (ingredients.Contains(key))
                ingredientsInInventory.Add(new InventoryItem(key, value));
        }
        SoundManager.Instance.PlayAudio(openDisplaySound);
        GenerateItemDisplays(ingredientsInInventory);
    }
    
    public void DisplayBooze()
    {
        var boozeInInventory = new List<InventoryItem>();

        foreach (var (key, value) in PlayerMovement.Inventory.Items)
        {
            if (booze.Contains(key))
                boozeInInventory.Add(new InventoryItem(key, value));
        }
        SoundManager.Instance.PlayAudio(openDisplaySound);
        GenerateItemDisplays(boozeInInventory);
    }

    private void GenerateItemDisplays(List<InventoryItem> items)
    {
        foreach (var item in activeItems)
            Destroy(item);
        
        var scrollViewRect = itemScrollView.GetComponent<RectTransform>();
        scrollViewRect.sizeDelta = new Vector2(scrollViewRect.sizeDelta.x, inventoryItem.GetComponent<RectTransform>().rect.height * items.Count);
        
        foreach (var item in items)
        {
            activeItems.Add(Instantiate(inventoryItem, itemScrollView.transform));
            var texts = activeItems[^1].GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = item.Item.ToString();
            texts[1].text = item.Amount.ToString();
        }
    }
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
