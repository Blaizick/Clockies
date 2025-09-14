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

        [Space]

        public Tooltip tooltip;
        public PriceTooltip priceTooltip;

        [Space]

        public PurchasePanel purchasesPanel;

        [Space]

        public Button rebirthButton;
        public TooltipPerformer rebirthButtonPerformer;

        public TextMeshProUGUI rebirthText;
        public TooltipPerformer rebirthTextPerformer;

        [Space]

        public Button restartButton;
        public TooltipPerformer restartPerformer;

        public ConfirmDialogue confirmDialogue;

        public ClickTexts clickTexts;

        public GameObject winPanel;

        public BuffsDisplayer buffsDisplayer;


        public void Init()
        {
            rebirthButton.onClick.AddListener(() =>
            {
                if (Vars.Instance.modules.rebirthsManager.CanReborn())
                {
                    confirmDialogue.SetUp("Rebirth", "Warning! You will lose all progress", "OK", "Cancel", () =>
                    {
                        Vars.Instance.modules.rebirthsManager.Reborn();
                    }, null);
                    confirmDialogue.Show();
                }
            });
            rebirthButtonPerformer.data = NamedItems.Rebirth;
            rebirthTextPerformer.data = NamedItems.Rebirth;

            restartPerformer.data = NamedItems.Restart;

            restartButton.onClick.AddListener(() =>
            {
                confirmDialogue.SetUp("Restart", "Warning! You will lose all progress and will not receive any benefits", "OK", "Cancel", () =>
                {
                    Vars.Instance.Restart();
                }, null);
                confirmDialogue.Show();
            });


            tooltip.Init();
            priceTooltip.Init();

            purchasesPanel.Init();
            buffsDisplayer.Init();

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
            clocksText.text = FormatUtils.ClocksToStringI(Vars.Instance.modules.clocksManager.Clocks);
            incomeText.text = FormatUtils.ClocksToStringF(Vars.Instance.modules.incomeManager.GetUndelayedIncome());

            rebirthText.text = Vars.Instance.modules.rebirthsManager.Rebirths.ToString();

            if (Vars.Instance.state == GameState.Win && !winPanel.activeInHierarchy)
            {
                winPanel.SetActive(true);
            }
            else if (Vars.Instance.state == GameState.Running && winPanel.activeInHierarchy)
            {
                winPanel.SetActive(false);
            }

            purchasesPanel._Update();
            buffsDisplayer._Update();
        }
    }
}