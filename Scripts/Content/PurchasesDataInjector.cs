using System;
using System.Collections.Generic;
using UnityEngine;

namespace Clockies
{
    public class PurchasesDataInjector : MonoBehaviour
    {
        public PurchaseData clockMaker;
        public PurchaseData basement;
        public PurchaseData factory;
        public PurchaseData office;
        public PurchaseData bank;
        public PurchaseData factoryTown;
        public PurchaseData molecularReassemler;
        public PurchaseData planetDuplicator;


        public void Init()
        {
            InjectPurchase(Purchases.ClockMaker, clockMaker);
            InjectPurchase(Purchases.Basement, basement);
            InjectPurchase(Purchases.Factory, factory);
            InjectPurchase(Purchases.Office, office);
            InjectPurchase(Purchases.Bank, bank);
            InjectPurchase(Purchases.FactoryTown, factoryTown);
            InjectPurchase(Purchases.MolecularReassemler, molecularReassemler);
            InjectPurchase(Purchases.PlanetDuplicator, planetDuplicator);
        }

        public void InjectPurchase(Purchase purchase, PurchaseData purchaseData)
        {
            purchase.Sprite = purchaseData.sprite;
        }
    }

    [Serializable]
    public struct PurchaseData
    {
        public Sprite sprite;
    }

    public static class Purchases
    {
        public static Purchase ClockMaker { get; set; }
        public static Purchase Basement { get; set; }
        public static Purchase Factory { get; set; }
        public static Purchase Office { get; set; }
        public static Purchase Bank { get; set; }
        public static Purchase FactoryTown { get; set; }
        public static Purchase MolecularReassemler { get; set; }
        public static Purchase PlanetDuplicator { get; set; }

        public static List<Purchase> All { get; set; }

        public static void Init()
        {
            All = new();

            ClockMaker = Purchase.Default;
            ClockMaker.StartPrice = 100;
            ClockMaker.RawIncome = 1f;
            ClockMaker.Name = () =>
            {
                return "Clock Maker";
            };
            ClockMaker.Description = () =>
            {
                return "Knows how to make clocks";
            };
            ClockMaker.ClocksToUnlock = 0;

            Basement = Purchase.Default;
            Basement.StartPrice = 2000;
            Basement.RawIncome = 20f;
            Basement.Name = () =>
            {
                return "Basement";
            };
            Basement.Description = () =>
            {
                return "Local production unit";
            };
            Basement.ClocksToUnlock = 1500;

            Factory = Purchase.Default;
            Factory.StartPrice = 2000;
            Factory.RawIncome = 20f;
            Factory.Name = () =>
            {
                return "Factory";
            };
            Factory.Description = () =>
            {
                return "Produces a large number of clocks";
            };
            Factory.ClocksToUnlock = 1700;

            Office = Purchase.Default;
            Office.StartPrice = 8000;
            Office.RawIncome = 80f;
            Office.Name = () =>
            {
                return "Office";
            };
            Office.Description = () =>
            {
                return "A bunch of workers are working on the clocks";
            };
            Office.ClocksToUnlock = 7000;

            Bank = Purchase.Default;
            Bank.StartPrice = 20000;
            Bank.RawIncome = 200f;
            Bank.Name = () =>
            {
                return "Bank";
            };
            Bank.Description = () =>
            {
                return "Uses clocks as currency";
            };
            Bank.ClocksToUnlock = 16000;

            FactoryTown = Purchase.Default;
            FactoryTown.StartPrice = 45000;
            FactoryTown.RawIncome = 450f;
            FactoryTown.Name = () =>
            {
                return "Factory-Town";
            };
            FactoryTown.Description = () =>
            {
                return "Factory, but so huge that a whole city was built around it";
            };
            FactoryTown.ClocksToUnlock = 40000;

            MolecularReassemler = Purchase.Default;
            MolecularReassemler.StartPrice = 80000;
            MolecularReassemler.RawIncome = 800f;
            MolecularReassemler.Name = () =>
            {
                return "Molecular Reassembler";
            };
            MolecularReassemler.Description = () =>
            {
                return "Reassembles arbitrary molecules into clocks";
            };
            MolecularReassemler.ClocksToUnlock = 70000;

            PlanetDuplicator = Purchase.Default;
            PlanetDuplicator.StartPrice = 140000;
            PlanetDuplicator.RawIncome = 140f;
            PlanetDuplicator.Name = () =>
            {
                return "Planet Duplicator";
            };
            PlanetDuplicator.Description = () =>
            {
                return "Creates an exact copy of our planet";
            };
            PlanetDuplicator.ClocksToUnlock = 120000;


            All.Add(ClockMaker);
            All.Add(Basement);
            All.Add(Factory);
            All.Add(Office);
            All.Add(FactoryTown);
            All.Add(Bank);
            All.Add(MolecularReassemler);
            All.Add(PlanetDuplicator);
        }

        public static void Reset()
        {
            Init();
        }

        public static void Restart()
        {
            Init();
        }
    }

    public class Purchase : INamedItem
    {
        public Func<string> Name { get; set; }
        public Func<string> Description { get; set; }
        public Sprite Sprite { get; set; }

        public int StartPrice { get; set; }
        public float PriceMultiplier { get; set; }

        public float ClocksToUnlock { get; set; }

        public int Bought { get; set; }

        public float RawIncome { get; set; }
        public float IncomeMultiplier { get; set; }

        public int Price
        {
            get
            {
                return (int)(StartPrice * Mathf.Pow(PriceMultiplier, Bought));
            }
        }
        public float Income
        {
            get
            {
                return RawIncome * IncomeMultiplier;
            }
        }
        public float TotalIncome
        {
            get
            {
                return (float)Bought * Income;
            }
        }

        public Purchase() { }

        public Purchase(Func<string> name, Func<string> description, Sprite sprite)
        {
            Name = name;
            Description = description;
            Sprite = sprite;
        }


        public static Purchase Default
        {
            get
            {
                return new Purchase()
                {
                    Name = () =>
                    {
                        return "";
                    },
                    Description = () =>
                    {
                        return "";
                    },
                    StartPrice = 10,
                    PriceMultiplier = 1.1f,
                    ClocksToUnlock = 0,
                    Bought = 0,
                    RawIncome = 0.1f,
                    IncomeMultiplier = 1f
                };
            }
        }
    }
}