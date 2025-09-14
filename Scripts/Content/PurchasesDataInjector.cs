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
            ClockMaker.StartPrice = 10;
            ClockMaker.RawIncome = 0.1f;
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
            Basement.StartPrice = 200;
            Basement.RawIncome = 1.75f;
            Basement.Name = () =>
            {
                return "Basement";
            };
            Basement.Description = () =>
            {
                return "Local production unit";
            };
            Basement.ClocksToUnlock = 175;

            Factory = Purchase.Default;
            Factory.StartPrice = 3000;
            Factory.RawIncome = 25;
            Factory.Name = () =>
            {
                return "Factory";
            };
            Factory.Description = () =>
            {
                return "Produces a large number of clocks";
            };
            Factory.ClocksToUnlock = 2500;

            Office = Purchase.Default;
            Office.StartPrice = 40000;
            Office.RawIncome = 300f;
            Office.Name = () =>
            {
                return "Office";
            };
            Office.Description = () =>
            {
                return "A bunch of workers are working on the clocks";
            };
            Office.ClocksToUnlock = 35000;

            Bank = Purchase.Default;
            Bank.StartPrice = 500000;
            Bank.RawIncome = 40000;
            Bank.Name = () =>
            {
                return "Bank";
            };
            Bank.Description = () =>
            {
                return "Uses clocks as currency";
            };
            Bank.ClocksToUnlock = 450000;

            FactoryTown = Purchase.Default;
            FactoryTown.StartPrice = 6000000;
            FactoryTown.RawIncome = 450000f;
            FactoryTown.Name = () =>
            {
                return "Factory-Town";
            };
            FactoryTown.Description = () =>
            {
                return "Factory, but so huge that a whole city was built around it";
            };
            FactoryTown.ClocksToUnlock = 580000;

            MolecularReassemler = Purchase.Default;
            MolecularReassemler.StartPrice = 70000000;
            MolecularReassemler.RawIncome = 500000f;
            MolecularReassemler.Name = () =>
            {
                return "Molecular Reassembler";
            };
            MolecularReassemler.Description = () =>
            {
                return "Reassembles arbitrary molecules into clocks";
            };
            MolecularReassemler.ClocksToUnlock = 68000000;

            PlanetDuplicator = Purchase.Default;
            PlanetDuplicator.StartPrice = 800000000;
            PlanetDuplicator.RawIncome = 4800000f;
            PlanetDuplicator.Name = () =>
            {
                return "Planet Duplicator";
            };
            PlanetDuplicator.Description = () =>
            {
                return "Creates an exact copy of our planet";
            };
            PlanetDuplicator.ClocksToUnlock = 780000000;


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
            foreach (var puchase in All)
            {
                puchase.Bought = 0;
            }
        }

        public static void Restart()
        {
            foreach (var puchase in All)
            {
                puchase.Bought = 0;
            }
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