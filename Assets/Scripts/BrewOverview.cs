using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewOverview : MonoBehaviour
{
    [SerializeField] private GameObject ingredientDisplay;
    [SerializeField] private GameObject ScrollViewContent;

    [SerializeField] private Recipe recipe;

    private List<GameObject> activeDisplays = new List<GameObject>();

    public void GenerateIngredientList()
    {
        var ingredients = recipe.Ingredients;
        var displayHeight = ingredientDisplay.GetComponent<RectTransform>().rect.height;
        var contentHeight = displayHeight * ingredients.Length;

        var scrollViewRect = ScrollViewContent.GetComponent<RectTransform>();
        scrollViewRect.sizeDelta = new Vector2(scrollViewRect.sizeDelta.x, contentHeight);
        
        for (var i = 0; i < ingredients.Length; i++)
        {
            var display = Instantiate(ingredientDisplay, ScrollViewContent.transform);
            display.GetComponent<IngredientDisplay>().SetData(ingredients[i]);
            activeDisplays.Add(display);
        }
    }

    public void Brew()
    {
        foreach (var ingredient in recipe.Ingredients)
        {
            if (!PlayerMovement.Inventory.Items.ContainsKey(ingredient.Type))
                return;
            if (PlayerMovement.Inventory.Items[ingredient.Type] < ingredient.Amount)
                return;
        }

        foreach (var ingredient in recipe.Ingredients)
            PlayerMovement.Inventory.Items[ingredient.Type] -= ingredient.Amount;
        
        Debug.Log("Brew Succesfull");
        PlayerMovement.Inventory.AddItem(recipe.OutputItem, recipe.OutputAmount);
    }
}
