using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ingredientDisplay;
    [SerializeField] private TextMeshProUGUI amountDisplay;

    public void SetData(RequiredIngredient ingredient)
    {
        ingredientDisplay.text = ingredient.Type.ToString();
        amountDisplay.text = $"{ingredient.Amount} Needed";
    }
}
