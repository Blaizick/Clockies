


using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Clockies
{
    public class BuffsDataInjector : MonoBehaviour
    {
        public BuffData atomicClock;

        public void Init()
        {
            InjectData(Buffs.AtomicClock, atomicClock);
        }

        public void InjectData(Buff buff, BuffData data)
        {
            buff.Sprite = data.sprite;
        }
    }

    [System.Serializable]
    public struct BuffData
    {
        public Sprite sprite;
    }

    public class Buff : INamedItem
    {
        public float IncomeMultiplier { get; set; }
        public float Duration { get; set; }
        public float Chance { get; set; }
        public Sprite Sprite { get; set; }

        public Func<string> Name { get; set; }
        public Func<string> Description { get; set; }

        public static Buff Default
        {
            get
            {
                return new Buff()
                {
                    IncomeMultiplier = 0f,
                    Duration = 1f,
                    Chance = 1f,
                    Sprite = null,
                    Name = () =>
                    {
                        return "";
                    },
                    Description = () =>
                    {
                        return "";
                    }
                };
            }
        }
    }

    public static class Buffs
    {
        public static Buff AtomicClock { get; private set; }

        public static List<Buff> All { get; private set; }

        public static void Init()
        {
            AtomicClock = Buff.Default;
            AtomicClock.IncomeMultiplier = 3f;
            AtomicClock.Duration = 10f;
            AtomicClock.Chance = 1f;
            AtomicClock.Name = () =>
            {
                return "Atomic Clock";
            };
            AtomicClock.Description = () =>
            {
                return $"Speeds up production by {AtomicClock.IncomeMultiplier} times for {AtomicClock.Duration} seconds";
            };

            All = new();
            All.Add(AtomicClock);
        }
    }
}