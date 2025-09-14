using UnityEngine;

namespace Clockies
{
    public class DesktopInput
    {
        public InputSystem_Actions actions;

        public Vector2 mousePos;

        public void Init()
        {
            actions = new();
            actions.Enable();
        }
        public void Update()
        {
            mousePos = actions.Main.MousePosition.ReadValue<Vector2>();

            SetTooltipPos(mousePos, Vars.Instance.ui.tooltip.root);
            SetTooltipPos(mousePos, Vars.Instance.ui.priceTooltip.root);

            //Secret combo used for debugging
            if (actions.Main.Shift.IsPressed() && actions.Main.Space.IsPressed() && actions.Main.RightArrow.IsPressed())
            {
                if (actions.Main.J.IsPressed())
                {
                    Time.timeScale = 100f;
                }
                else if (actions.Main.K.IsPressed())
                {
                    Time.timeScale = 1f;
                }
            }
        }

        public void SetTooltipPos(Vector2 position, RectTransform root)
        {
            var halfSize = root.sizeDelta / 2f;

            float rightBound = position.x + root.sizeDelta.x;
            float bottomBound = position.y - root.sizeDelta.y;

            float x, y;

            if (rightBound > Camera.main.pixelWidth)
            {
                x = position.x - halfSize.x;
            }
            else
            {
                x = position.x + halfSize.x;
            }
            if (bottomBound < 0)
            {
                y = position.y + halfSize.y;
            }
            else
            {
                y = position.y - halfSize.y;
            }

            root.anchoredPosition = new Vector2(x, y);
        }
    }
}
