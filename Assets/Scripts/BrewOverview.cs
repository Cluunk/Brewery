using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BrewOverview : MonoBehaviour
{
    [SerializeField] private GameObject ingredientDisplay;
    [SerializeField] private GameObject recipeSelector;
    
    [SerializeField] private GameObject ingredientScrollView;
    [SerializeField] private GameObject recipeScrollView;

    [SerializeField] private TextMeshProUGUI recipeNameDisplay;
    
    private Recipe activeRecipe;

    private List<IngredientDisplay> activeDisplays = new List<IngredientDisplay>();
    private List<RecipeSelector> recipeSelectors = new List<RecipeSelector>();

    public void OpenBrewOverlay()
    {
        gameObject.SetActive(true);
        SelectRecipe(PlayerMovement.Inventory.UnlockedRecipes[0]);
        GenerateRecipeSelectors();
    }
    
    public void CloseBrewOverlay()
    {
        gameObject.SetActive(false);
    }

    private void GenerateRecipeSelectors()
    {
        foreach (var selector in recipeSelectors)
        {
            if(selector) 
                Destroy(selector.gameObject);
        }
        recipeSelectors.Clear();

        var scrollViewRect = recipeScrollView.GetComponent<RectTransform>();
        scrollViewRect.sizeDelta = new Vector2(scrollViewRect.sizeDelta.x, recipeSelector.GetComponent<RectTransform>().rect.height * PlayerMovement.Inventory.UnlockedRecipes.Count);

        foreach (var recipe in PlayerMovement.Inventory.UnlockedRecipes)
        {
            recipeSelectors.Add(Instantiate(recipeSelector, recipeScrollView.transform).GetComponent<RecipeSelector>());
            recipeSelectors[^1].Button.onClick.AddListener(() => SelectRecipe(recipe));
            recipeSelectors[^1].NameDisplay.text = recipe.RecipeName;
        }
    }

    private void SelectRecipe(Recipe recipe)
    {
        activeRecipe = recipe;
        recipeNameDisplay.text = $"{recipe.OutputAmount}x {recipe.OutputItem}";
        GenerateIngredientList(activeRecipe);
    }


    private void GenerateIngredientList(Recipe recipe)
    {
        foreach (var display in activeDisplays)
        {
            if(display) 
                Destroy(display.gameObject);
        }
        activeDisplays.Clear();

        var ingredients = recipe.Ingredients;

        var scrollViewRect = ingredientScrollView.GetComponent<RectTransform>();
        scrollViewRect.sizeDelta = new Vector2(scrollViewRect.sizeDelta.x, ingredientDisplay.GetComponent<RectTransform>().rect.height* ingredients.Length);
        
        foreach (var ingredient in ingredients)
        {
            activeDisplays.Add(Instantiate(ingredientDisplay, ingredientScrollView.transform).GetComponent<IngredientDisplay>());
            activeDisplays[^1].SetData(ingredient);
        }
    }

    public void Brew()
    {
        if (!activeRecipe)
            return;
        
        foreach (var ingredient in activeRecipe.Ingredients)
        {
            if (!PlayerMovement.Inventory.Items.ContainsKey(ingredient.Type))
                return;
            if (PlayerMovement.Inventory.Items[ingredient.Type] < ingredient.Amount)
                return;
        }

        foreach (var ingredient in activeRecipe.Ingredients)
            PlayerMovement.Inventory.Items[ingredient.Type] -= ingredient.Amount;
        
        PlayerMovement.Inventory.AddItem(activeRecipe.OutputItem, activeRecipe.OutputAmount);
        UpdateDisplays();
    }

    private void UpdateDisplays()
    {
        foreach (var display in activeDisplays)
            display.SetData(display.ActiveIngredient);
    }
}
