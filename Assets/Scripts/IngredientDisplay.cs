using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientDisplay : MonoBehaviour
{
    public RequiredIngredient ActiveIngredient { get; private set; }
    
    [SerializeField] private TextMeshProUGUI ingredientDisplay;
    [SerializeField] private TextMeshProUGUI amountDisplay;
    [SerializeField] private Color insufficientColor;

    public void SetData(RequiredIngredient ingredient)
    {
        ActiveIngredient = ingredient;
        
        ingredientDisplay.text = ingredient.Type.ToString();
        var amountOfPlayer = PlayerMovement.Inventory.Items.ContainsKey(ingredient.Type)
            ? PlayerMovement.Inventory.Items[ingredient.Type]
            : 0;
        amountDisplay.text = $"{amountOfPlayer}/{ingredient.Amount}";
        if (amountOfPlayer < ingredient.Amount)
            amountDisplay.color = insufficientColor;
    }
}
