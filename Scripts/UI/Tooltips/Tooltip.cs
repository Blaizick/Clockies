using TMPro;
using UnityEngine;

namespace Clockies
{
    public class Tooltip : MonoBehaviour
    {
        public TextMeshProUGUI _name;
        public TextMeshProUGUI description;
        public RectTransform root;

        public void Init()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}