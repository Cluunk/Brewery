using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Deal : ScriptableObject
{
    [SerializeField] private ItemType item;
    public ItemType Item => item;

    [SerializeField] private int amount;

    public int Amount => amount;

    [SerializeField] private int price;
    public int Price => price;
    
    public abstract void AcceptDeal(Inventory player);

    public abstract bool DealPossible(Inventory player);
}
