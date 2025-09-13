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

        public TextMeshProUGUI rebirthText;
        public Button rebirthButton;

        public Button restartButton;

        public ConfirmDialogue confirmDialogue;

        public ClickTexts clickTexts;

        public GameObject winPanel;


        public void Init()
        {
            rebirthButton.onClick.AddListener(() =>
            {
                if (Vars.Instance.rebirthsManager.CanReborn())
                {
                    confirmDialogue.SetUp("Reborn", "Warning! You will lose all of your progres.", "OK", "Cancel", () =>
                    {
                        Vars.Instance.rebirthsManager.Reborn();
                    }, null);
                    confirmDialogue.Show();
                }
            });

            restartButton.onClick.AddListener(() =>
            {
                confirmDialogue.SetUp("Restart", "Warning! You will lose all of your progres and do not goin anything.", "OK", "Cancel", () =>
                {
                    Vars.Instance.Restart();
                }, null);
                confirmDialogue.Show();
            });


            tooltip.Init();
            priceTooltip.Init();

            purchasesPanel.Init();

            clock.Init();

            confirmDialogue.Init();

            winPanel.SetActive(false);
        }

        public void Reset()
        {
            purchasesPanel.Reset();
        }

        public void Restart()
        {
            purchasesPanel.Restart();
        }

        public void _Update()
        {
            clocksText.text = FormatUtils.ClocksFToStringI(Vars.Instance.clocksManager.Clocks);
            incomeText.text = FormatUtils.ClocksFToStringF(Vars.Instance.incomeManager.GetIncome());

            rebirthText.text = Vars.Instance.rebirthsManager.Rebirths.ToString();

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