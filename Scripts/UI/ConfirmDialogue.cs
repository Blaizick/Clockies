using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Clockies
{
    public class ConfirmDialogue : MonoBehaviour
    {
        public TextMeshProUGUI headerText;
        public TextMeshProUGUI descriptionText;

        [Space]

        public Button successButton;
        public TextMeshProUGUI successText;

        [Space]

        public Button cancelButton;
        public TextMeshProUGUI cancelText;

        [Space]

        public RectTransform root;

        public void Init()
        {
            root.gameObject.SetActive(false);
        }


        public void SetUp(string header, string description, string successText, string cancelText, Action onSuccess, Action onCancel)
        {
            successButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();

            headerText.text = header;
            descriptionText.text = description;

            this.successText.text = successText;
            this.cancelText.text = cancelText;

            successButton.onClick.AddListener(() =>
            {
                Hide();
                onSuccess?.Invoke();
            });
            cancelButton.onClick.AddListener(() =>
            {
                Hide();
                onCancel?.Invoke();
            });
        }

        private bool animating = false;
        public void Show()
        {
            root.gameObject.SetActive(true);

            if (!animating)
            {
                animating = true;
                root.DOPunchScale(new Vector3(0.25f, 0.25f), 0.15f).OnComplete(() =>
                {
                    animating = false;
                });
            }
        }
        public void Hide()
        {
            root.gameObject.SetActive(false);
        }
    }
}
