using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Clockies
{
    public class TooltipPerformer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public INamedItem data;

        private bool pointerStay = false;

        public void Update()
        {
            if (pointerStay)
            {
                var tooltip = Vars.Instance.ui.tooltip;

                tooltip._name.text = data?.Name();
                tooltip.description.text = data?.Description();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            pointerStay = true;

            Update();

            Vars.Instance.ui.tooltip.Show();

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            pointerStay = false;

            Vars.Instance.ui.tooltip.Hide();
        }
    }
}