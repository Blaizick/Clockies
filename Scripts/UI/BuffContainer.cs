using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clockies
{
    public class BuffContainer : MonoBehaviour
    {
        public RectTransform root;
        public Button button;
        public Image image;
        public TooltipPerformer performer;

        [NonSerialized] public BuffsManager.DisplayedBuff buff;
    }
}