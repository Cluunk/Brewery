using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Deal : ScriptableObject
{
    public abstract DealType Type();
    
    public abstract string DealName();

    [SerializeField] private int price;
    public int Price => price;
    
    public abstract void AcceptDeal(Market market, Inventory player);

    public abstract bool DealPossible(Inventory player);
}
