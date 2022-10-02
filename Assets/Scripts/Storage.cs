using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private IngredientType type;
    public IngredientType Type => type;

    public int Amount { get; private set; }
    [SerializeField] private int maxAmount;
    public int MaxAmount => maxAmount;

    private Inventory player;

    private void Start()
    {
        StorageManager.Storages.Add(this);
    }
    
    public void Upgrade()
    {
        maxAmount *= 2;
    }

    public void Deposit(Inventory player, int amount)
    {
        if (!player.Ingredients.ContainsKey(type))
            return;
        
        var maxDepositAmount = MaxDeposit(player, amount);
        if (amount > maxDepositAmount)
            amount = maxDepositAmount;

        player.Ingredients[type] -= amount;
        Amount += amount;
    }
    
    public void Deposit(int amount)
    {
        var maxDepositAmount = MaxDeposit(amount);
        if (amount > maxDepositAmount)
            amount = maxDepositAmount;

        player.Ingredients[type] -= amount;
        Amount += amount;
    }

    private void Deposit(int amount, out int leftOver)
    {
        
        leftOver = 0;
    }

    public void Withdraw(Inventory player, int amount)
    {
        if (!player.Ingredients.ContainsKey(type))
            return;
        
        var maxWithdrawAmount = MaxWithdraw(player);
        if (amount > maxWithdrawAmount)
            amount = maxWithdrawAmount;

        player.Ingredients[type] += amount;
        Amount -= amount;
    }

    private int MaxWithdraw(Inventory player)
    {
        if (!player.Ingredients.ContainsKey(type))
            return Inventory.maxPerIngredient;

        return Inventory.maxPerIngredient - player.Ingredients[type] >= 0 ? Inventory.maxPerIngredient - player.Ingredients[type] : 0;
    }

    private int MaxDeposit(int amount)
    {


        return Amount + amount > maxAmount ? maxAmount - Amount : amount;
    }
    
    private int MaxDeposit(Inventory player, int amount)
    {
        if (!player.Ingredients.ContainsKey(type))
            return 0;

        if (amount > player.Ingredients[type])
            return player.Ingredients[type];

        return Amount + amount > maxAmount ? maxAmount - Amount : amount;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.GetComponent<PlayerMovement>())
            return;
        player = other.GetComponent<PlayerMovement>().Inventory;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
            player = null;
    }

    private void Update()
    {
        if (player && Input.GetKeyDown(KeyCode.T))
        {
            Deposit(player, 5);
            Debug.Log($"{type}      Inventory: {player.Ingredients[type]}      Storage: {Amount}");
        }
        if (player && Input.GetKeyDown(KeyCode.Q))
        {
            Withdraw(player, 7);
            Debug.Log($"{type}      Inventory: {player.Ingredients[type]}      Storage: {Amount}");
        }
    }
}
