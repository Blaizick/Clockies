using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Clockies
{
    public class PriceTooltip : MonoBehaviour
    {
        public TextMeshProUGUI _name;
        public TextMeshProUGUI description;
        public TextMeshProUGUI price;
        public RectTransform root;

        public void Init()
        {
            Hide();
        }

        private bool animating = false;
        public void Show()
        {
            gameObject.SetActive(true);

            if (!animating)
            {
                animating = true;
                root.DOPunchScale(new Vector3(0.15f, 0.15f, 0f), 0.25f).OnComplete(() =>
                {
                    animating = false;
                });
            }
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}