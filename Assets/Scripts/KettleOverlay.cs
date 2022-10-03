using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettleOverlay : MonoBehaviour
{
    [SerializeField] private BrewOverview brewOverview;

    public void OpenBrewOverlay()
    {
        brewOverview.gameObject.SetActive(true);
        brewOverview.GenerateIngredientList();
    }
    
    public void CloseBrewOverlay()
    {
        brewOverview.gameObject.SetActive(false);
    }

    public void Brew()
    {
        
    }

    public void Bottle()
    {
        
    }
}
