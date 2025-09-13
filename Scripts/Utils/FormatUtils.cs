

using UnityEngine;

namespace Clockies
{
    public static class FormatUtils
    {
        public static string ClocksFToStringF(float clocks)
        {
            if (clocks >= 1000000)
            {
                float millions = clocks / 1000f;
                return $"{millions} millions";
            }
            else if (clocks >= 1000)
            {
                float thousands = clocks / 1000f;
                return $"{thousands} thousands";
            }
            else
            {
                return $"{clocks}";
            }
        }

        public static string ClocksFToStringI(float clocks)
        {
            if (clocks >= 1000000)
            {
                float millions = Mathf.FloorToInt(clocks / 1000f);
                return $"{millions} millions";
            }
            else if (clocks >= 1000)
            {
                float thousands = Mathf.FloorToInt(clocks / 1000f);
                return $"{thousands} thousands";
            }
            else
            {
                return $"{Mathf.RoundToInt(clocks)}";
            }
        }
    }
}