

using UnityEngine;

namespace Clockies
{
    public static class FormatUtils
    {
        public static string ClocksToStringF(float clocks)
        {
            if (clocks >= 1000000)
            {
                float millions = clocks / 1000f;
                return $"{millions} million";
            }
            else if (clocks >= 1000)
            {
                float thousands = clocks / 1000f;
                return $"{thousands} thousand";
            }
            else
            {
                return $"{clocks}";
            }
        }

        public static string ClocksToStringI(float clocks)
        {
            if (clocks >= 1000000)
            {
                float millions = clocks / 1000f;
                return $"{millions} million";
            }
            else if (clocks >= 1000)
            {
                float thousands = clocks / 1000f;
                return $"{thousands} thousand";
            }
            else
            {
                return $"{Mathf.RoundToInt(clocks)}";
            }
        }
    }
}