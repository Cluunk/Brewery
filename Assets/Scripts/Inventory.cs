using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryDisplay inventoryDisplay;
    public int Balance { get; private set; } = 2500;
    
    //public const int maxPerItem = 500;
    [SerializeField] private Recipe baseRecipe;
    public List<Recipe> UnlockedRecipes { get; } = new List<Recipe>();

    public Dictionary<ItemType, int> Items { get; } = new Dictionary<ItemType, int>();

    private void Start()
    {
        /*Items.Add(ItemType.Water, 35);
        Items.Add(ItemType.Grain, 15);
        Items.Add(ItemType.Hop, 45);
        Items.Add(ItemType.Yeast, 70);*/
        UnlockedRecipes.Add(baseRecipe);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !PlayerMovement.Interacting)
            ToggleInventory();
    }

    public void Buy(int cost)
    {
        Balance -= cost;
    }
    public void Sell(int profit)
    {
        Balance += profit;
    }

    private void ToggleInventory()
    {
        if (!inventoryDisplay)
            return;
        inventoryDisplay.gameObject.SetActive(!inventoryDisplay.gameObject.activeSelf);
        inventoryDisplay.DisplayInventory();
    }

    public void AddItem(ItemType item, int amount)
    {
        if (PlayerMovement.Inventory.Items.ContainsKey(item))
            PlayerMovement.Inventory.Items[item] += amount;
        else
            PlayerMovement.Inventory.Items.Add(item, amount);

        //if (PlayerMovement.Inventory.Items[item] > maxPerItem)
        //   PlayerMovement.Inventory.Items[item] = maxPerItem;
    }

    /*public int FreeSpaceForItem(ItemType item)
    {
        if (!Items.ContainsKey(item))
            return maxPerItem;

        return maxPerItem - Items[item];
    }*/
}
