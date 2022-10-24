using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSelector : MonoBehaviour
{
    [SerializeField] private Button button;
    public Button Button => button;

    [SerializeField] private TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI NameDisplay => nameDisplay;
}
