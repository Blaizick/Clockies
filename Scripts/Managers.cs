using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor.Build;
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

        public void Restart()
        {
            Clocks = 0;
        }
    }

    public class IncomeManager
    {
        public float Multiplier { get; set; }
        public float SaveMultiplier { get; set; }
        public float OverrideMultiplier { get; set; }

        public float DelayedMultiplier { get; set; }

        public void Init()
        {
            OverrideMultiplier = 1f;
            SaveMultiplier = OverrideMultiplier;
            Multiplier = SaveMultiplier;

            DelayedMultiplier = 0f;
        }

        public void Reset()
        {
            Multiplier = SaveMultiplier;
        }

        public void Restart()
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
            return income * Multiplier * (DelayedMultiplier + 1);
        }

        public float GetUndelayedIncome()
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

        public void Restart()
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
        public float SaveFromIncome { get; set; }
        public float FromIncome { get; set; }

        public float OverrideMultiplier { get; set; }
        public float SaveMultiplier { get; set; }
        public float Multiplier { get; set; }

        public void Init()
        {
            OverrideFromIncome = 0.1f;
            OverrideMultiplier = 1f;

            SaveFromIncome = OverrideFromIncome;
            SaveMultiplier = OverrideMultiplier;

            FromIncome = SaveFromIncome;
            Multiplier = SaveMultiplier;
        }

        public void Reset()
        {
            FromIncome = SaveFromIncome;
            Multiplier = SaveMultiplier;
        }

        public void Restart()
        {
            FromIncome = OverrideFromIncome;
            Multiplier = OverrideMultiplier;
        }

        public void Click()
        {
            Vars.Instance.clocksManager.Clocks += GetClocksOnClick();
        }

        public float GetClocksOnClick()
        {
            // Debug.Log($"Income: {Vars.Instance.incomeManager.GetIncome()}, FromIncome: {FromIncome}, Multiplier: {Multiplier}");
            return (Vars.Instance.incomeManager.GetIncome() * FromIncome * Multiplier) + 1f;
        }
    }

    public class RebirthsManager
    {
        public int Rebirths { get; set; }
        public int OverrideRebirths { get; private set; }

        public const int neededRebirths = 2;
        public const float firstRebirthPrice = 100000f;

        public const float incomeMultiplier = 0.2f;
        public const float clicksFromIncome = 0.1f;

        public void Init()
        {
            OverrideRebirths = 0;
            Rebirths = OverrideRebirths;
        }

        public void Restart()
        {
            Rebirths = OverrideRebirths;
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
            Vars.Instance.incomeManager.SaveMultiplier += incomeMultiplier;
            Vars.Instance.incomeManager.Multiplier += incomeMultiplier;

            Vars.Instance.clicksManager.SaveFromIncome += clicksFromIncome;
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

        public void Restart()
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

    public class BuffsManager
    {
        public class DisplayedBuff
        {
            public float destroyDelay;
            public bool destroyed;
            public Buff buff;
        }

        public List<DisplayedBuff> displayedBuffs = new();

        public float SpawnDelay { get; private set; }
        public float VanishDelay { get; private set; }
        private float curSpawnDelay = 0f;

        // private bool deapply = true;
        private Unity.Mathematics.Random random;

        public void Init()
        {
            random = new((uint)Mathf.Max(Time.time, 1f));

            SpawnDelay = 90f;
            VanishDelay = 10f;
            curSpawnDelay = SpawnDelay;
        }

        public void Reset()
        {
            // deapply = false;

            // foreach (var buff in displayedBuffs)
            // {
            //     buff.destroyed = true;
            // }

            // displayedBuffs.Clear();

            // curSpawnDelay = SpawnDelay;
        }
        public void Restart()
        {
            // deapply = false;

            // foreach (var buff in displayedBuffs)
            // {
            //     buff.destroyed = true;
            // }

            // displayedBuffs.Clear();

            // curSpawnDelay = SpawnDelay;
        }

        public void Update()
        {
            for (int i = 0; i < displayedBuffs.Count; i++)
            {
                var buff = displayedBuffs[i];

                if (buff.destroyDelay <= 0)
                {
                    buff.destroyed = true;
                    displayedBuffs.RemoveAt(i);
                    i--;
                }

                buff.destroyDelay -= Time.deltaTime;
            }

            if (curSpawnDelay <= 0)
            {
                curSpawnDelay = SpawnDelay;
                SpawnBuff(GetRandomBuff());
            }
            curSpawnDelay -= Time.deltaTime;
        }

        public Buff GetRandomBuff()
        {
            float randomValue = random.NextFloat();

            float curChance = 0f;

            foreach (var buff in Buffs.All)
            {
                curChance += buff.Chance;

                if (curChance >= randomValue)
                {
                    return buff;
                }
            }

            return Buffs.All.First();
        }

        public void SpawnBuff(Buff buff)
        {
            DisplayedBuff displayedBuff = new DisplayedBuff()
            {
                destroyDelay = VanishDelay,
                buff = buff,
                destroyed = false
            };
            displayedBuffs.Add(displayedBuff);

            // deapply = true;
        }

        public void ApplyBuff(DisplayedBuff buff)
        {
            // deapply = false;
            Vars.Instance.sceneInjection._StartCoroutine(ApplyBuffCoroutine(buff));
        }
        private IEnumerator ApplyBuffCoroutine(DisplayedBuff buff)
        {
            displayedBuffs.Remove(buff);
            buff.destroyed = true;

            Vars.Instance.incomeManager.DelayedMultiplier += buff.buff.IncomeMultiplier;

            yield return new WaitForSeconds(buff.buff.Duration);

            Vars.Instance.incomeManager.DelayedMultiplier -= buff.buff.IncomeMultiplier;
        }
    }
}