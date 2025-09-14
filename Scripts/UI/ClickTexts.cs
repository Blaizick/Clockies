using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Clockies
{
    public class ClickTexts : MonoBehaviour
    {
        public GameObject prefab;

        public RectTransform root;
        public float PrefabHeight
        {
            get
            {
                return prefab.GetComponent<RectTransform>().sizeDelta.y;
            }
        }

        public const float animateTime = 2f;

        public void Spawn(string text, Vector2 position)
        {
            var instance = Instantiate(prefab, root);
            var container = instance.GetComponent<ClickTextContainer>();

            container.text.text = text;
            container.root.anchoredPosition = position;

            var targetPos = container.root.anchoredPosition.y + 200f;
            container.root.DOAnchorPosY(targetPos, animateTime);

            var targetColor = container.text.color;
            targetColor.a = 0;
            container.text.DOColor(targetColor, animateTime).OnComplete(() =>
            {
                container.root.DOKill();
                Destroy(instance);
            });

            // container.DOKill(true);
            // container.root.DOKill(true);

        }
    }
}
