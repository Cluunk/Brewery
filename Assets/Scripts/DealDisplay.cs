using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DealDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI amount;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Button acceptButton;

    public void GenerateDisplay(Market market, Deal deal)
    {
        if (!deal)
            return;
        
        itemName.text = deal.DealName();

        switch (deal.Type())
        {
            case DealType.BuyItem:
                var buyDeal = deal as BuyItemDeal;
                amount.text = buyDeal.Amount.ToString();
                break;
            case DealType.SellItem:
                var sellDeal = deal as SellItemDeal;
                amount.text = sellDeal.Amount.ToString();
                break;
            default:
                amount.text = string.Empty;
                break;
        }
        price.text = deal.Price + "$";
        acceptButton.onClick.AddListener(() => deal.AcceptDeal(market, PlayerMovement.Inventory));
        acceptButton.interactable = true;
    }
}
