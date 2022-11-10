using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DealDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI amount;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Button acceptButton;
    [SerializeField] private AudioClip acceptAudio;

    private Deal currentDeal;
    private Market market;

    public void GenerateDisplay(Market m, Deal deal)
    {
        if (!deal)
            return;

        market = m;

        currentDeal = deal;
        
        itemName.text = deal.DealName();

        switch (deal.Type())
        {
            case DealType.BuyItem:
                var buyDeal = deal as BuyItemDeal;
                if (buyDeal)
                    amount.text = buyDeal.Amount.ToString();
                break;
            case DealType.SellItem:
                var sellDeal = deal as SellItemDeal;
                if (sellDeal)
                    amount.text = sellDeal.Amount.ToString();
                break;
            default:
                amount.text = string.Empty;
                break;
        }

        price.text = deal.Price + "$";

        market.AcceptDeal += UpdateDisplay;

        acceptButton.onClick.AddListener(() => deal.AcceptDeal(market, PlayerMovement.Inventory));
        acceptButton.onClick.AddListener(() => SoundManager.Instance.PlayAudio(acceptAudio));
        acceptButton.onClick.AddListener(() => GameManager.CheckLoss(market.BuyDeals.Concat(market.SellDeals).ToArray()));
        acceptButton.onClick.AddListener(GameManager.CheckWin);
        acceptButton.onClick.AddListener(market.AcceptDealTrigger);

        acceptButton.interactable = deal.DealPossible(PlayerMovement.Inventory);

    }

    private void UpdateDisplay()
    {
        acceptButton.interactable = currentDeal.DealPossible(PlayerMovement.Inventory);
    }

    private void OnDestroy()
    {
        market.AcceptDeal -= UpdateDisplay;
    }
}