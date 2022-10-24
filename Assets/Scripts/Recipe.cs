using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] private string recipeName;
    public string RecipeName => recipeName;
    
    [SerializeField] private RequiredIngredient[] ingredients;
    public RequiredIngredient[] Ingredients => ingredients;

    [SerializeField] private ItemType outputItem;
    public ItemType OutputItem => outputItem;

    [SerializeField] private int outputAmount;
    public int OutputAmount => outputAmount;
}