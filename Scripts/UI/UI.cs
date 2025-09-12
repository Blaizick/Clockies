using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clockies
{
    public class UI : MonoBehaviour
    {
        public Clock clock;
        public TextMeshProUGUI clocksText;
        public TextMeshProUGUI incomeText;

        public Tooltip tooltip;
        public PriceTooltip priceTooltip;

        public PurchasePanel purchasesPanel;

        public TextMeshProUGUI rebirthsText;
        public Button rebirthButton;

        public GameObject winPanel;


        public void Init()
        {
            rebirthButton.onClick.AddListener(() =>
            {
                if (Vars.Instance.rebirthsManager.CanReborn())
                {
                    Vars.Instance.rebirthsManager.Reborn();
                }
            });

            tooltip.Init();
            priceTooltip.Init();

            purchasesPanel.Init();

            clock.Init();

            winPanel.SetActive(false);
        }

        public void Reset()
        {
            purchasesPanel.Reset();
        }

        public void _Update()
        {
            clocksText.text = Mathf.Round(Vars.Instance.clocksManager.Clocks).ToString();
            incomeText.text = Vars.Instance.incomeManager.GetIncome().ToString();

            rebirthsText.text = Vars.Instance.rebirthsManager.Rebirths.ToString();

            if (Vars.Instance.state == GameState.Win && !winPanel.activeInHierarchy)
            {
                winPanel.SetActive(true);
            }
            else if (Vars.Instance.state == GameState.Running && winPanel.activeInHierarchy)
            {
                winPanel.SetActive(false);
            }

            purchasesPanel._Update();
        }
    }
}