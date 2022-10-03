using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RequiredIngredient
{
    [SerializeField] private ItemType type;
    public ItemType Type => type;

    [SerializeField] private int amount;
    public int Amount => amount;
}
