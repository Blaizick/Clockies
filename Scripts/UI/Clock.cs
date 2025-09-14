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
                Vector2 clickPos = Vars.Instance.input.mousePos;
                clickPos.y += Vars.Instance.ui.clickTexts.PrefabHeight / 2f;
                Vars.Instance.ui.clickTexts.Spawn(FormatUtils.ClocksToStringI(Vars.Instance.modules.clicksManager.GetClocksOnClick()), clickPos);

                Vars.Instance.modules.clicksManager.Click();

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