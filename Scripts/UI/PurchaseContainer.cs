using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Clockies
{
    public class PurchaseContainer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

            if (PointerOver)
            {
                RefreshTooltip();
            }
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerOver = true;

            RefreshTooltip();

            Vars.Instance.ui.priceTooltip.Show();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            PointerOver = false;

            Vars.Instance.ui.priceTooltip.Hide();
        }

        public void RefreshTooltip()
        {
            PriceTooltip priceTooltip = Vars.Instance.ui.priceTooltip;

            priceTooltip._name.text = purchase.Name();
            priceTooltip.description.text = purchase.Description();
            priceTooltip.price.text = purchase.Price.ToString();
        }
    }
}
