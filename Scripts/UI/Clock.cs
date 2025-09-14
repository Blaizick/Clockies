using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Clockies
{
    public class Clock : MonoBehaviour
    {
        public Button button;
        public Transform animateTransform;
        public bool AnimatingNow { get; private set; }

        public void Init()
        {
            AnimatingNow = false;

            button.onClick.AddListener(() =>
            {
                Vars.Instance.ui.clickTexts.Spawn(FormatUtils.ClocksToStringI(Vars.Instance.clicksManager.GetClocksOnClick()), Vars.Instance.input.mousePos);
                Vars.Instance.clicksManager.Click();

                if (!AnimatingNow)
                {
                    AnimatingNow = true;
                    animateTransform.DOPunchScale(new Vector2(0.1f, 0.1f), 0.15f).OnComplete(() =>
                    {
                        AnimatingNow = false;
                    });
                }
            });
        }
    }
}