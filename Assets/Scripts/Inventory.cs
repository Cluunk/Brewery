using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int maxPerIngredient = 50;
    public Dictionary<IngredientType, int> Ingredients { get; private set; } = new Dictionary<IngredientType, int>();

    private void Start()
    {
        Ingredients.Add(IngredientType.Water, 35);
        Ingredients.Add(IngredientType.Grain, 15);
        Ingredients.Add(IngredientType.Hop, 45);
        Ingredients.Add(IngredientType.Yeast, 70);
    }
}
