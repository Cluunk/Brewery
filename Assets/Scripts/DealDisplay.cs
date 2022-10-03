using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DealDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI amount;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Button acceptButton;

    public void GenerateDisplay(Deal deal)
    {
        itemName.text = deal.Item.ToString();
        amount.text = deal.Amount.ToString();
        price.text = deal.Price + "$";
        acceptButton.onClick.AddListener(() => deal.AcceptDeal(PlayerMovement.Inventory));
    }

    public void Clear()
    {
        
    }
}