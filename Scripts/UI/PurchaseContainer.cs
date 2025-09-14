using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clockies
{
    public class PurchaseContainer : MonoBehaviour
    {
        public Button button;

        public Image iconImage;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI priceText;
        public TextMeshProUGUI incomeText;
        public TextMeshProUGUI boughtText;

        [NonSerialized] public Purchase purchase;

        public TooltipPerformer tooltipPerformer;

        public bool PointerOver { get; private set; }

        public void Init()
        {
            button.onClick.AddListener(() =>
            {
                Vars.Instance.modules.purchaseManager.Buy(purchase);
                _Update();
            });

            PointerOver = false;

            _Update();
        }

        public void _Update()
        {
            iconImage.sprite = purchase.Sprite;
            nameText.text = purchase.Name();
            priceText.text = purchase.Price.ToString();
            incomeText.text = purchase.Income.ToString();
            boughtText.text = purchase.Bought.ToString();
        }
    }
}
