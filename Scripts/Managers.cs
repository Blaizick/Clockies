using System.Collections.Generic;
using UnityEngine;

namespace Clockies
{
    public class ClocksManager
    {
        public float Clocks { get; set; }

        public void Init()
        {
            Clocks = 0;
        }

        public void Reset()
        {
            Clocks = 0;
        }
    }

    public class IncomeManager
    {
        public float Multiplier { get; set; }
        public float OverrideMultiplier { get; set; }

        public void Init()
        {
            OverrideMultiplier = 1f;
            Multiplier = OverrideMultiplier;
        }

        public void Reset()
        {
            Multiplier = OverrideMultiplier;
        }

        public void Update()
        {
            Vars.Instance.clocksManager.Clocks += GetIncome() * Time.deltaTime;
        }

        public float GetIncome()
        {
            float income = 0f;
            foreach (var purchase in Purchases.All)
            {
                income += purchase.TotalIncome;
            }
            return income * Multiplier;
        }
    }

    public class PurchaseManager
    {
        public void Init()
        {

        }

        public void Reset()
        {

        }

        public void Buy(Purchase purchase)
        {
            Vars.Instance.clocksManager.Clocks -= purchase.Price;
            purchase.Bought++;
        }
    }

    public class ClicksManager
    {
        public float OverrideFromIncome { get; set; }
        public float FromIncome { get; set; }
        public float OverrideMultiplier { get; set; }
        public float Multiplier { get; set; }


        public void Init()
        {
            OverrideFromIncome = 0f;
            OverrideMultiplier = 1f;
            FromIncome = OverrideFromIncome;
            OverrideMultiplier = OverrideMultiplier;
        }

        public void Reset()
        {
            FromIncome = OverrideFromIncome;
            OverrideMultiplier = OverrideMultiplier;
        }

        public void Click()
        {
            Vars.Instance.clocksManager.Clocks += GetClocksOnClick();
        }

        public float GetClocksOnClick()
        {
            return (Vars.Instance.incomeManager.GetIncome() * FromIncome * Multiplier) + 1f;
        }
    }

    public class RebirthsManager
    {
        public int Rebirths { get; set; }
        public const int neededRebirths = 2;
        public const float firstRebirthPrice = 100000f;

        public const float incomeMultiplier = 0.2f;
        public const float clicksFromIncome = 0.1f;

        public void Init()
        {

        }

        public bool CanReborn()
        {
            return Rebirths < neededRebirths && GetRebithPrice() < Vars.Instance.clocksManager.Clocks;
        }

        public float GetRebithPrice()
        {
            return (Rebirths + 1) * firstRebirthPrice;
        }

        public void Reborn()
        {
            Vars.Instance.incomeManager.OverrideMultiplier += incomeMultiplier;
            Vars.Instance.incomeManager.Multiplier += incomeMultiplier;

            Vars.Instance.clicksManager.OverrideFromIncome += clicksFromIncome;
            Vars.Instance.clicksManager.FromIncome += clicksFromIncome;

            Rebirths++;

            Vars.Instance.Reset();

            if (Rebirths == neededRebirths)
            {
                Vars.Instance.state = GameState.Win;
            }
        }

        public string GetFormattedRebirthsBonuses()
        {
            return string.Empty;
        }
    }

    public class UnlockManager
    {
        public HashSet<Purchase> Purchases { get; private set; }

        public void Init()
        {
            Purchases = new();

            Update();
        }

        public void Reset()
        {
            Purchases.Clear();
        }

        public void Update()
        {
            foreach (var purchase in Clockies.Purchases.All)
            {
                if (Vars.Instance.clocksManager.Clocks >= purchase.ClocksToUnlock && !Purchases.Contains(purchase))
                {
                    Purchases.Add(purchase);
                }
            }
        }
    }
}