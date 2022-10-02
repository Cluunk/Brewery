using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deal : ScriptableObject
{
    public abstract void AcceptDeal(Inventory player);

    public abstract bool DealPossible(Inventory player);
}
