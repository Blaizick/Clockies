using UnityEngine;
using UnityEngine.EventSystems;

namespace Clockies
{
    public class RebirthTooltipPerformer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            var tooltip = Vars.Instance.ui.tooltip;
            var rebirthsManager = Vars.Instance.rebirthsManager;

            tooltip._name.text = "Rebirth";
            tooltip.description.text = $"If you have enough money, you can reborn, all your buildings and money will disappear but you will get bonuses {rebirthsManager.GetFormattedRebirthsBonuses()}, to win you need to respawn {RebirthsManager.neededRebirths} times, the current respawn costs {rebirthsManager.GetRebithPrice()} hours.";

            tooltip.Show();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Vars.Instance.ui.tooltip.Hide();
        }
    }
}